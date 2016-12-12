using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPP_TextAnalyzer.Filter;
using MPP_TextAnalyzer.TextProcessor;

namespace MPP_TextAnalyzerTests.FilterTests
{
    [TestClass]
    public class FilterTests
    {
        [TestMethod]
        public void Verify_whenFilterAndWordsInitialized_shouldTrue()
        {
            //arrange
            Filter filter = new Filter();
            filter.CreateFilter("NOT@Cat");
            String[] words = { "This", "is", "Sparta", "-","says","Leonid" };
            
            //act
            Boolean actual = filter.Verify(words);
            
            //assert
            Assert.IsTrue(actual);
        }
    }
}
