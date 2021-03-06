﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPP_TextAnalyzer.TextProcessor;
using System.Linq.Expressions;
using System.Reflection;
using MPP_TextAnalyzer.ExpressionBuilder;
using MPP_TextAnalyzer.ExpressionBuilder.ReversePolandNotationBuilder;

namespace MPP_TextAnalyzer.ExpressionBuilder.ExpressionTreeCreator
{
    public class ExpressionTreeCreator : Builder
    {
        private List<Object> polandList;
        private List<String> filterList;
        private readonly Dictionary<Expression, Func<Boolean>> Cache;

        public ExpressionTreeCreator(String filter)
        {
            filterList = filter.Split(FILTER_SPLITTER).ToList();
            polandList = new List<Object>();
            Cache = new Dictionary<Expression,Func<Boolean>>();
        }

        private void RemoveElemetsFromList(int count, int index)
        {
            for (int i = 0; i < count + 1; i++)
                polandList.RemoveAt(index - i);
        }

        private void InsertNOTNode(int index)
        {
            Object parameter;
            if (polandList.ElementAt(index - 1) is Boolean)
                parameter = Expression.Constant(polandList.ElementAt(index - 1));
            else
                parameter = polandList.ElementAt(index - 1);
            Expression notExpression = Expression.Not((Expression)parameter);
            polandList.Insert(index + 1, notExpression);
            RemoveElemetsFromList(1, index);
        }

        private void InsertANDNode(int index)
        {
            Object left;
            Object right;
            if (polandList.ElementAt(index - 2) is Boolean)
                left = Expression.Constant(polandList.ElementAt(index - 2));
            else
                left = polandList.ElementAt(index - 2);

            if (polandList.ElementAt(index - 1) is Boolean)
                right = Expression.Constant(polandList.ElementAt(index - 1));
            else
                right = polandList.ElementAt(index - 1);
            Expression andExpression = Expression.AndAlso((Expression)left, (Expression)right);
            polandList.Insert(index + 1, andExpression);
            RemoveElemetsFromList(2, index);
        }

        private void InsertORNode(int index)
        {
            Object left;
            Object right;
            if (polandList.ElementAt(index - 2) is Boolean)
                left = Expression.Constant(polandList.ElementAt(index - 2));
            else
                left = polandList.ElementAt(index - 2);

            if (polandList.ElementAt(index - 1) is Boolean)
                right = Expression.Constant(polandList.ElementAt(index - 1));
            else
                right = polandList.ElementAt(index - 1);
            Expression orExpression = Expression.OrElse((Expression)left, (Expression)right);
            polandList.Insert(index + 1, orExpression);
            RemoveElemetsFromList(2, index);
        }

        public void BuildExpressionTree() 
        {
            int index;
            while (polandList.Count > 1)
            {
                index = 0;
                foreach (Object value in polandList)
                {
                    if (value.Equals(OPERATORS[NOT_INDEX]))
                    {
                        InsertNOTNode(index);
                        break;
                    }

                    if (value.Equals(OPERATORS[AND_INDEX]))
                    {
                        InsertANDNode(index);
                        break;
                    }

                    if (value.Equals(OPERATORS[OR_INDEX]))
                    {
                        InsertORNode(index);
                        break;
                    }
                    index++;
                }

            }
        }

        private Boolean InvokeTreeLambda(String[] words)
        {
            Func<Boolean> lambda;
            var result = (Expression)polandList.ElementAt(0);
            if (!Cache.TryGetValue(result, out lambda))
            {
                LambdaExpression lambdaExpression = Expression.Lambda(result);
                lambda = (Func<Boolean>)lambdaExpression.Compile();
                Cache[result] = lambda;
            }
            return lambda.Invoke();
        }

        public Func<String[], Boolean> CreateLambda()
        {
            Func<String[], Boolean> resultDelegate = words =>
            {
                polandList = NotationBuilder.CreatePolandList(words,filterList);
                BuildExpressionTree(); 
                return InvokeTreeLambda(words);
            };
            return resultDelegate;
        }

    }
}
