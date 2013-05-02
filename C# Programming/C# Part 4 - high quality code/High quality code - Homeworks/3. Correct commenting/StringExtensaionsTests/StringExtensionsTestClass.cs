namespace StringExtensionsTests
{
    using Extensions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    /* Note:
     * Only a few methods are tested for training purposes.
     * In addition, "ToValidLatinFileName()" method is changed
     * to throw ArgumentNullException, again only for training purposes.      
     */

    [TestClass]
    public class StringExtensionsTestClass
    {
        [TestMethod]
        public void ToValidUsername_InputWithInvalidSymbols_ShouldRemoveInvalidSymbols()
        {
            var input = "Стефaн ?";
            string validatedUserName = input.ToValidUsername();
            var expected = "Stefan";

            Assert.AreEqual(expected, validatedUserName);
        }

        // Ain`t that name beautiful :)? more than 100 symbols long!!!
        [TestMethod]
        public void ConvertCyrillicToLatinLetters_CapitalLetterWithTwoLetterLatinEquivalent_ShouldCapitalizeOnlyFirstLetterInLatinEquivalent()
        {
            var input = "Ютията ще падне.";
            string inputToLatin = input.ConvertCyrillicToLatinLetters();
            var expected = "Yutiyata shte padne.";

            Assert.AreEqual(expected, inputToLatin);
        }

        [TestMethod]
        public void ToValidLatinFilename_SpacesInInput_ShouldReplaceSpacesWithHypens()
        {
            var validInput = "Тхиs will have   some hypенс";
            string validatedFilename = validInput.ToValidLatinFileName();
            var expected = "This-will-have---some-hypens";

            Assert.AreEqual(expected, validatedFilename);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToValidLatinFilename_MethodCalledOnNull_ShouldThrowArgumentNullException()
        {
            string nullInput = null;
            Assert.AreEqual(null, nullInput.ToValidLatinFileName());
        }
    }
}
