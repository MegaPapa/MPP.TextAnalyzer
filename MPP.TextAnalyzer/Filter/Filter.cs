using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPP_TextAnalyzer.ExpressionBuilder.ExpressionTreeCreator;
using MPP_TextAnalyzer.Exceptions;

namespace MPP_TextAnalyzer.Filter
{
    public class Filter : IFilter
    {
        private Func<String[], Boolean> filter;

        public void CreateFilter(String filter)
        {
            this.filter = new ExpressionTreeCreator(filter).CreateLambda();
            if (this.filter == null)
                throw new NotInitializedFilterException("Filter is not initialized.");
        }

        public Boolean Verify(String[] words) 
        {
            if (words == null)
                throw new ArgumentNullException("Words can not be null.");
            return filter.Invoke(words);
        }
    }
}
