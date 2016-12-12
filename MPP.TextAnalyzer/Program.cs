using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPP_TextAnalyzer.TextProcessor;
using System.Linq.Expressions;
using MPP_TextAnalyzer.ExpressionBuilder.ExpressionTreeCreator;
using MPP_TextAnalyzer.Filter;
using System.IO;

namespace MPP_TextAnalyzer
{
    public class Program
    {
        static void Main(string[] args)
        {
            Filter.Filter filter = new Filter.Filter();
            TextProcessor.TextProcessor textProcessor = TextProcessor.TextProcessor.getInstance();
            filter.CreateFilter("So@AND@cared@AND@(@YEAH@OR@matters@)@AND@NOT@DaveMustaine");
            String[] words = textProcessor.GetStringArrayFromFile("./test.txt");
            Console.WriteLine(filter.Verify(words));
            Console.ReadKey();
            
        }
    }
}
