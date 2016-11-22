using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MPP_TextAnalyzer.TextProcessor
{
    public static class TextProcessor
    {

        public static String[] GetStringArrayFromFile(String path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("File not found.");
            Encoding rusEncoding = Encoding.GetEncoding(1251);
            StringBuilder text = new StringBuilder();
            String tmp;
            StreamReader streamReader = new StreamReader(@path, rusEncoding);
            while ((tmp = (streamReader.ReadLine())) != null)
                text.Append(tmp);
            return SplitTextOnWords(text.ToString());
        }

        private static String[] SplitTextOnWords(String text)
        {
            Char[] punctuationMarks = { ' ', ',', ':', '?', '!',';' };
            return text.Split(punctuationMarks, StringSplitOptions.RemoveEmptyEntries);
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
