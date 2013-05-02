using System;
using System.Numerics;
using Methods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MethodsTests
{
    [TestClass]
    public class PrintAsPercentFormatNumberTests
    {
        [TestMethod]
        public void SmallLetterPercentFormat_ShouldNotThrowArgumentException()
        {
            string format = "p";

            // All built-in numeric types can be foramted with fixed point format string.
            double number = 12;

            // See: http://stackoverflow.com/questions/9417213/c-how-do-i-check-no-exception-occurred-in-my-unit-test
            try
            {
                ConsoleNumberPrinter.PrintAsPercentage(number, format);
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
        public void CapitalLetterpercentFormat_ShouldNotThrowArgumentException()
        {
            string format = "P";
            double number = 12;

            // See: http://stackoverflow.com/questions/9417213/c-how-do-i-check-no-exception-occurred-in-my-unit-test
            try
            {
                ConsoleNumberPrinter.PrintAsPercentage(number, format);
            }
            catch (ArgumentException)
            {
                Assert.Fail(
                    "Should not throwed execption, but throwed ArgumentException",
                    format);
            }
        }

        [TestMethod]
        public void PercentageSymbolPercentFormat_ShouldNotThrowArgumentException()
        {
            string format = "%";
            double number = 12;

            try
            {
                ConsoleNumberPrinter.PrintAsPercentage(number, format);
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
        public void NonPercentFormatLetter_ShouldThrowArgumentException()
        {
            string format = "E";
            double number = 12;

            ConsoleNumberPrinter.PrintAsPercentage(number, format);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NonPercentFormatSymbol_ShouldThrowArgumentException()
        {
            string format = "$";
            double number = 12;

            ConsoleNumberPrinter.PrintAsPercentage(number, format);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyString_ShouldThrowArgumentException()
        {
            string format = string.Empty;
            double number = 12;

            ConsoleNumberPrinter.PrintAsPercentage(number, format);
        }

        [TestMethod]
        public void FormattableNumber_ShouldNotThrowArgumentException()
        {
            string format = "p";
            double number = 12.0d;

            // Alternative approach. As the link says: "..one of the few situations where no 
            // assertion is necessary...".
            // See: http://stackoverflow.com/questions/9417213/c-how-do-i-check-no-exception-occurred-in-my-unit-test
            ConsoleNumberPrinter.PrintAsPercentage(number, format);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NonFormattableBigIntegerNumber_ShouldThrowArgumentException()
        {
            string format = "f";
            BigInteger number = 12;

            ConsoleNumberPrinter.PrintAsPercentage(number, format);
        }
    }
}