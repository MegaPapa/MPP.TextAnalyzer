using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPP_TextAnalyzer.TextProcessor;
using System.Linq.Expressions;

namespace MPP_TextAnalyzer
{
    public class Program
    {
        static void Main(string[] args)
        {
        
            ExpressionTreeCreator.ExpressionTreeCreator tree = new ExpressionTreeCreator.ExpressionTreeCreator("Maxim@AND@(@Minsk@OR@Molodechno@)@OR@(@Kek@AND@Lol@)");
            
            String[] text = { "Kek","Lol","Yoba" };
            Func<String[],Boolean> myLambda = tree.CreateLambda();
            
            Console.WriteLine(myLambda(text));
            String[] words = { "Maxim","Minskf","NOMAZ","LELKEKES","ZZZZZ","SASAI","U","LUKOMORIA","DUB","ZELENII" };
            Console.WriteLine(myLambda(words));
            Console.ReadKey();
            
        }
    }
}
