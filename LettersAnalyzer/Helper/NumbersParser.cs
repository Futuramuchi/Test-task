using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LettersAnalyzer.Helper
{
    public static class NumbersParser
    {
        public static List<int> Parse(string text)
        {
            var neededValues = new List<int>();
            
            var matches = Regex.Matches(text, @"(\d)+"); // Adding numbers to the list for further processing

            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                    neededValues.Add(Convert.ToInt32(match.Value));
            }

            IEnumerable<int> result = neededValues.Distinct();
            return result.ToList();
        }
    }
}
