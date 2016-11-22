using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MPP_TextAnalyzer.TextProcessor
{
    public static class TextProcessor
    {

        public static Boolean FindInText(String word,String[] words)
        {
            if (Array.IndexOf(words,word) != -1)
                return true;
            else
                return false;
        }
    }
}
