using System;
using System.Numerics;
using Methods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MethodsTests
{
    [TestClass]
    public class PrintAsFixedPointNumberTests
    {
        [TestMethod]
        public void SmallLetterFixedPointFormat_ShouldNotThrowArgumentException()
        {
            string format = "f";

            // All built-in numeric types can be foramted with fixed point format string.
            double number = 12;

            // See: http://stackoverflow.com/questions/9417213/c-how-do-i-check-no-exception-occurred-in-my-unit-test
            try
            {
                ConsoleNumberPrinter.PrintAsFixedNumber(number, format);
            }
            catch (ArgumentException)
            {
                // If ArgumentException is thrown, the test fails unconditionally.
                Assert.Fail(
                    "Should not throwed execption, but throwed ArgumentException",
                    format);
            }
        }

        [TestMethod]
        public void CapitalLetterFixedPointFormat_ShouldNotThrowArgumentException()
        {
            string format = "F";
            double number = 12;

            // See: http://stackoverflow.com/questions/9417213/c-how-do-i-check-no-exception-occurred-in-my-unit-test
            try
            {
                ConsoleNumberPrinter.PrintAsFixedNumber(number, format);
            }
            catch (ArgumentException)
            {
                Assert.Fail(
                    "Should not throwed execption, but throwed ArgumentException",
                    format);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NonFixedPointFormatLetter_ShouldThrowArgumentException()
        {
            string format = "E";
            double number = 12;

            ConsoleNumberPrinter.PrintAsFixedNumber(number, format);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NonFixedPointFormatSymbol_ShouldThrowArgumentException()
        {
            string format = "$";
            double number = 12;

            ConsoleNumberPrinter.PrintAsFixedNumber(number, format);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyString_ShouldThrowArgumentException()
        {
            string format = string.Empty;
            double number = 12;

            ConsoleNumberPrinter.PrintAsFixedNumber(number, format);
        }

        [TestMethod]
        public void FormattableNumber_ShouldNotThrowArgumentException()
        {
            string format = "f";
            double number = 12.0d;

            // Alternative approach. As the link says: "..one of the few situations where no 
            // assertion is necessary...".
            // See: http://stackoverflow.com/questions/9417213/c-how-do-i-check-no-exception-occurred-in-my-unit-test
            ConsoleNumberPrinter.PrintAsFixedNumber(number, format);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NonFormattableBigIntegerNumber_ShouldThrowArgumentException()
        {
            string format = "f";
            BigInteger number = 12;

            ConsoleNumberPrinter.PrintAsFixedNumber(number, format);
        }
    }
}