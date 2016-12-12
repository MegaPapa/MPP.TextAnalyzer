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
    public class TextProcessor
    {
        private static TextProcessor _instance;

        public static TextProcessor getInstance()
        {
            if (_instance == null)
            {
                _instance = new TextProcessor();
            }
            return _instance;
        }
        public String[] GetStringArrayFromFile(String path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("File not found.");
            StringBuilder text = new StringBuilder();
            String tmp;
            StreamReader streamReader = new StreamReader(@path);
            while ((tmp = (streamReader.ReadLine())) != null)
                text.Append(tmp);
            return SplitTextOnWords(text.ToString());
        }

        private String[] SplitTextOnWords(String text)
        {
            Char[] punctuationMarks = { ' ', ',', ':', '?', '!',';' };
            return text.Split(punctuationMarks, StringSplitOptions.RemoveEmptyEntries);
        }

        public Boolean FindInText(String word,String[] words)
        {
            if (Array.IndexOf(words,word) != -1)
                return true;
            else
                return false;
        }
    }
}
