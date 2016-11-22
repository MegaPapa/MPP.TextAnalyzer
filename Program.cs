using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPP_TextAnalyzer.TextProcessor;
using System.Linq.Expressions;
using MPP_TextAnalyzer.ExpressionBuilder.ExpressionTreeCreator;
using MPP_TextAnalyzer.Filter;

namespace MPP_TextAnalyzer
{
    public class Program
    {
        static void Main(string[] args)
        {

            Filter.Filter filter = new Filter.Filter();
            filter.CreateFilter("Maxim@AND@(@Minsk@OR@Molodechno@)@AND@NOT@Durachek");
            String[] words = { "Maxim","Durasim","Ehal","V","On","Molodechno" };
            for (int i = 0; i < 1000; i++ )
                Console.WriteLine(filter.Verify(words));
            Console.ReadKey();
            
        }
    }
}
