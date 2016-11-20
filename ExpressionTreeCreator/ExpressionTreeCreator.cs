using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPP_TextAnalyzer.TextProcessor;
using System.Linq.Expressions;
using System.Reflection;

namespace MPP_TextAnalyzer.ExpressionTreeCreator
{
    public class ExpressionTreeCreator
    {
        private String[] operators = { "NOT","AND","OR","(",")" };
        private List<Object> polandList;
        private Stack<String> stack;

        private const Char SPLITTER = '@';
        private const byte NOT_INDEX = 0;
        private const byte AND_INDEX = 1;
        private const byte OR_INDEX = 2;
        private List<String> filterList;
        public ExpressionTreeCreator(String filter)
        {
            filterList = filter.Split(SPLITTER).ToList();
            polandList = new List<Object>();
            stack = new Stack<String>();
        }

        private void CleanUpStack() 
        {
            String value;
            while (stack.Count != 0)
            {
                if (!((value = stack.Pop()).Equals("(")))
                    polandList.Add(value);
                
            }
        }

        public void CreatePolandList(String[] words) //Words - массив слов файла, в котором мы ищем значение
        {
            polandList.Clear();
            foreach (String value in filterList)
            {
                if (Array.IndexOf(operators, value) == -1)
                    polandList.Add(TextProcessor.TextProcessor.FindInText(value,words));
                else if (!value.Equals(")"))
                    stack.Push(value);
                
                if (value.Equals(")"))
                    CleanUpStack();

            }
            
        }

        public void BuildExpressionTree() 
        {
            int index;
            while (polandList.Count > 1)
            {
                index = 0;
                foreach (Object value in polandList)
                {
                    if (value.Equals(operators[NOT_INDEX]))
                    {
                        Object parameter;
                        if (polandList.ElementAt(index - 1) is Boolean)
                            parameter = Expression.Constant(polandList.ElementAt(index - 1));
                        else
                            parameter = polandList.ElementAt(index - 1);
                        Expression notExpression = Expression.Not((Expression)parameter);
                        polandList.Insert(index + 1, notExpression);
                        RemoveElemetsFromList(1, index);
                        break;
                    }

                    if (value.Equals(operators[AND_INDEX]))
                    {
                        Object left;
                        Object right;
                        if (polandList.ElementAt(index - 2) is Boolean)
                            left = Expression.Constant(polandList.ElementAt(index - 2));
                        //left = tmpLeft;
                        else
                            left = polandList.ElementAt(index - 2);
                        //left = tmpLeft;

                        if (polandList.ElementAt(index - 1) is Boolean)
                            right = Expression.Constant(polandList.ElementAt(index - 1));
                        else
                            right = polandList.ElementAt(index - 1);
                        Expression andExpression = Expression.AndAlso((Expression)left, (Expression)right);
                        polandList.Insert(index + 1, andExpression);
                        RemoveElemetsFromList(2, index);
                        break;
                    }

                    if (value.Equals(operators[OR_INDEX]))
                    {
                        Object left;
                        Object right;
                        if (polandList.ElementAt(index - 2) is Boolean)
                            left = Expression.Constant(polandList.ElementAt(index - 2));
                        //left = tmpLeft;
                        else
                            left = polandList.ElementAt(index - 2);
                        //left = tmpLeft;

                        if (polandList.ElementAt(index - 1) is Boolean)
                            right = Expression.Constant(polandList.ElementAt(index - 1));
                        else
                            right = polandList.ElementAt(index - 1);
                        Expression orExpression = Expression.OrElse((Expression)left, (Expression)right);
                        polandList.Insert(index + 1, orExpression);
                        RemoveElemetsFromList(2, index);
                        break;
                    }
                    index++;
                }

            }
        }

        private void RemoveElemetsFromList(int count, int index) 
        {
            for (int i = 0; i < count + 1; i++)
                polandList.RemoveAt(index - i);
        }

        private Boolean FindInTree(String[] words)
        {
            var result = (Expression)polandList.ElementAt(0);
            LambdaExpression lambdaExpression = Expression.Lambda(result);
            var lambda = (Func<Boolean>)lambdaExpression.Compile();
            return lambda.Invoke();
        }

        public Func<String[], Boolean> CreateLambda()
        {
            Func<String[], Boolean> resultDelegate = words =>
            {
                CreatePolandList(words);
                BuildExpressionTree(); 
                return FindInTree(words);
            };
            return resultDelegate;
        }

    }
}
