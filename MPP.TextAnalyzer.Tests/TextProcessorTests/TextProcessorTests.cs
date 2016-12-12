using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPP_TextAnalyzer.TextProcessor;

namespace MPP_TextAnalyzerTests.TextProcessorTests
{
    [TestClass]
    public class TextProcessorTests
    {
        [TestMethod]
        public void FindInText_whenWordInWords_shouldTrue()
        {
            //arrange
            String[] words = { "Cake","is","a","lie" };
            String word = "Cake";
            
            //act
            Boolean actual = TextProcessor.FindInText(word,words);

            //assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void GetStringArrayFromFile_whenFilePathIsTrue_shouldTrue()
        {
            //arrange
            String[] actual;
            String[] expected = { "This", "is", "temp", "file", "text"};

            //act
            actual = TextProcessor.GetStringArrayFromFile("../../TempFiles/tmpFile.txt");
            
            //assert
            for (int i = 0; i < actual.Length - 1; i++)
            {
                Assert.AreEqual(expected[i],actual[i]);
            }
        } 
    }
}
