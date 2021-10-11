using System.Linq;

namespace LettersAnalyzer.Helper
{
    public static class VowelsAnalyzer
    {
        private static readonly char[] _vowels = new char[]
        {
            'а', 'о', 'у', 'э', 'ю', 'я', 'и', 'ё', 'ы', 'е',   //rus
            'a', 'i', 'o', 'e', 'y', 'u',                       //eng, it
            'á', 'é', 'í', 'ó', 'ú', 'ý', 'æ', 'ö', 'ä', 'ü',   //da, de, is
            'ø', 'å', 'ӯ', 'ӣ'                                  //tg, is
        };

        public static int CountVowels(string text) => text.ToLower().Count(x => _vowels.Contains(x));
    }
}
