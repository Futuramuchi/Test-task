using LettersAnalyzer.Helper;
using System;

namespace LettersAnalyzer.Model
{
    public class DataFullModel
    {
        public DataModel TextData { get; set; }
        public int WordsAmount
        {
            get
            {
                return TextData.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
            }
        }
        public int VowelsAmount
        {
            get
            {
                return VowelsAnalyzer.CountVowels(TextData.Text);
            }
        }
    }
}
