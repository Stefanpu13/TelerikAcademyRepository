using System;
using Methods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MethodsTests
{
    [TestClass]
    public class NumberFormatValidatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullNumberPassed_ShouldThrowArgumentNullException()
        {
            object number = null;
            string format = "r";
            NumberFormatValidator.ThrowExceptionIfNull(number, format);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullFormatPassed_ShouldThrowArgumentNullException()
        {
            object number = 12;
            string format = null;
            NumberFormatValidator.ThrowExceptionIfNull(number, format);
        }
    }
}