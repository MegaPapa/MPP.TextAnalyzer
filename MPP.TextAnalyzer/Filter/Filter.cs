using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPP_TextAnalyzer.ExpressionBuilder.ExpressionTreeCreator;

namespace MPP_TextAnalyzer.Filter
{
    public class Filter : IFilter
    {
        private Func<String[], Boolean> filter;

        public void CreateFilter(String filter)
        {
            this.filter = new ExpressionTreeCreator(filter).CreateLambda();
        }

        public Boolean Verify(String[] words) 
        {
            if (filter == null)
                throw new NullReferenceException("Filter is not initialized");
            if (words == null)
                throw new ArgumentNullException("Words can not be null.");
            return filter.Invoke(words);
        }
    }
}
