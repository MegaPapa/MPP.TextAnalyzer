using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MPP_TextAnalyzer.TextProcessor
{
    public class TextProcessor
    {

        private static String[] words;
        public static String[] Words
        {
            get { return words; }
            set { words = value; }
        }
        public static Boolean FindInText(String word,String[] words)
        {
            if (Array.IndexOf(words,word) != -1)
                return true;
            else
                return false;
        }
    }
}
