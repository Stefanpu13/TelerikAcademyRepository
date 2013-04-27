using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Extensions;

namespace StringExtensionsTests
{    
    /* Note:
     * Only a few methods are tested for training purposes.
     * In addition, "ToValidLatinFileName()" method is changed
     * to throw ArgumentNullException, again only for training purposes.      
     */

    [TestClass]
    public class StringExtensionsTestClass
    {
        [TestMethod]
        public void ToValidUsernameTest()
        {
            var input = "Стефan ?";
            string validatedUserName = input.ToValidUsername();
            var expected = "Stefan";

            Assert.AreEqual(expected , validatedUserName);
        }

        [TestMethod]
        public void ConvertCyrillicToLatinLettersTest() 
        {
            var input = "Ютията ще падне.";
            string inputToLatin = input.ConvertCyrillicToLatinLetters();
            var expected = "Yutiyata shte padne.";

            Assert.AreEqual(expected, inputToLatin);
        }

        [TestMethod]        
        public void ToValidLatinFilenameNormalTest() 
        {
            var validInput = "Тхиs will =have   some hypенс.";
            string validatedFilename = validInput.ToValidLatinFileName();
            var expected = "This-will-have---some-hypens.";

            Assert.AreEqual(expected, validatedFilename);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToValidLatinFilenameExceptionTest()
        {
            string nullInput = null;
            Assert.AreEqual(null, nullInput.ToValidLatinFileName());
        }
    }
}
