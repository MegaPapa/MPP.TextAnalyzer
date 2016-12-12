using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPP_TextAnalyzer.ExpressionBuilder.ExpressionTreeCreator;

namespace MPP_TextAnalyzerTests.ExpressionBuilderTests.ExpressionTreeCreatorTests
{
    [TestClass]
    public class ExpressionTreeCreatorTests
    {
        [TestMethod]
        public void CreateLambda_WhenTheFilterIsSpecified_ShouldCreateCorrectLambda()
        {
            //arrange
            Func<String[], Boolean> tmpFunc;
            
            //act
            ExpressionTreeCreator tree = new ExpressionTreeCreator("NOT@Lol");
            tmpFunc = tree.CreateLambda();
            String[] words = { "Lol","Kek","Mamba" };
            
            //assert
            Assert.IsFalse(tmpFunc(words));
        }
    }
}
