using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MPP_TextAnalyzer.ExpressionBuilder.ReversePolandNotationBuilder;

namespace MPP_TextAnalyzerTests.ExpressionBuilderTests.ReversePolandNotationBuilderTests
{
    [TestClass]
    public class NotationBuilderTests
    {
        [TestMethod]
        public void CreatePolandList_whenAAndBORC_shouldTripleFalseORAND()
        {
            //arrange
            Char splitter = '@';
            List<String> filterList = new List<String>();
            String actual = "";
            String exprected = "FalseFalseFalseORAND";
            filterList.Add("A");
            filterList.Add("AND");
            filterList.Add("(");
            filterList.Add("B");
            filterList.Add("OR");
            filterList.Add("C");
            filterList.Add(")");
            String[] words = { "NaN" };

            //act
            List<Object> resultList = NotationBuilder.CreatePolandList(words,filterList);

            //assert
            foreach (Object value in resultList)
            {
                actual += value.ToString();
            }
            Assert.AreEqual(exprected, actual);
        }
    }
}
