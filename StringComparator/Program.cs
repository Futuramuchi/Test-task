using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringComparator
{
    class Program
    {
        private static Dictionary<string, double> _englishStrings { get; set; } = new Dictionary<string, double>();
        private static Dictionary<string, double> _russianStrings { get; set; } = new Dictionary<string, double>();

        private static void Main(string[] args)
        {
            var strings = ReadDataFromFile();

            for (int i = 0; i < strings.Count(); i++)
            {
                var currentstring = strings[i];

                if (currentstring != string.Empty)
                {
                    if (Regex.IsMatch(currentstring, @"[A-z0-9]"))
                    {
                        SplitStringWithComment(currentstring, out string text, out string comment);

                        var textIndex = CalculatePetrenkoIndex(text);
                        var commentIndex = CalculatePetrenkoIndex(comment);

                        _englishStrings.Add(currentstring, textIndex + commentIndex);
                    }

                    else
                    {
                        _russianStrings.Add(currentstring, CalculatePetrenkoIndex(currentstring));
                    }
                }
            }

            var mathes = FindStringsMatches();

            if (mathes.Count() > 0)
                foreach (var stringMatch in mathes)
                    Console.WriteLine($"{stringMatch.English} - {stringMatch.Russian}");
            else
                Console.WriteLine("Совпадений не найдено");

            Console.ReadKey();
        }

        private static double CalculatePetrenkoIndex(string text)
        {
            var matches = Regex.Matches(text, @"\w");
            string filteredText = string.Empty;

            foreach (Match match in matches) // Separating all the word characters from the others
                filteredText += match.Value;

            var index = 0.5;

            for (int i = 1; i < filteredText.Count(); i++)
                index += i + 0.5;

            var result = index * filteredText.Length;

            return result;
        }

        private static void SplitStringWithComment(string content, out string text, out string comment)
        {
            var splittedText = content.Split('|');

            text = splittedText[0];
            comment = splittedText[1];
        }


        private static IEnumerable<StringMatch> FindStringsMatches()
        {
            var matches = new List<StringMatch>();

            foreach (var englishString in _englishStrings) // Looking for the strings at the same index
            {
                foreach (var russianString in _russianStrings)
                { 
                    if (englishString.Value == russianString.Value)
                        matches.Add(new StringMatch(englishString.Key, russianString.Key));
                }
            }

            return matches;
        }

        private static string[] ReadDataFromFile()
        {
            Console.WriteLine("Путь до файла с текстом: ");

            string filePath = Console.ReadLine();
            string[] data = File.ReadAllLines(filePath);
            
            return data;
        }

        private struct StringMatch
        {
            public StringMatch(string english, string russian)
            {
                English = english;
                Russian = russian;
            }

            public string English;
            public string Russian;
        }
    }
}
