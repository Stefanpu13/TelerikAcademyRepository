using System;
using System.Numerics;
using Methods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MethodsTests
{
    [TestClass]
    public class PrintAsRoundTrippedNumberTests
    {
        [TestMethod]
        public void SmallLetterRoundTripFormat_ShouldNotThrowArgumentException()
        {
            string format = "r";

            // Double is one of the types that is formattable with the Round-trip format.
            double number = 12;

            // See: http://stackoverflow.com/questions/9417213/c-how-do-i-check-no-exception-occurred-in-my-unit-test
            try
            {
                ConsoleNumberPrinter.PrintAsRoundTrippedNumber(number, format);
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
        public void CapitalLetterRoundTripFormat_ShouldNotThrowArgumentException()
        {
            string format = "R";
            double number = 12;

            // See: http://stackoverflow.com/questions/9417213/c-how-do-i-check-no-exception-occurred-in-my-unit-test
            try
            {
                ConsoleNumberPrinter.PrintAsRoundTrippedNumber(number, format);
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
        public void NonRoundTripFormatLetter_ShouldThrowArgumentException()
        {
            string format = "E";
            double number = 12;

            ConsoleNumberPrinter.PrintAsRoundTrippedNumber(number, format);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NonRoundTripFormatSymbol_ShouldThrowArgumentException()
        {
            string format = "$";
            double number = 12;

            ConsoleNumberPrinter.PrintAsRoundTrippedNumber(number, format);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyString_ShouldThrowArgumentException()
        {
            string format = string.Empty;
            double number = 12;

            ConsoleNumberPrinter.PrintAsRoundTrippedNumber(number, format);
        }

        [TestMethod]
        public void FormattableDoubleNumber_ShouldNotThrowArgumentException()
        {
            string format = "r";
            double number = 12.0d;

            // Alternative approach for test of type: "Should Not Throw...".
            // As the link says: "..one of the few situations where no 
            // assertion is necessary...".
            // See: http://stackoverflow.com/questions/9417213/c-how-do-i-check-no-exception-occurred-in-my-unit-test
            ConsoleNumberPrinter.PrintAsRoundTrippedNumber(number, format);
        }

        [TestMethod]
        public void FormattableSingleNumber_ShouldNotThrowArgumentException()
        {
            string format = "r";
            float number = 12.0f;

            ConsoleNumberPrinter.PrintAsRoundTrippedNumber(number, format);
        }

        [TestMethod]
        public void FormattableBigIntegerNumber_ShouldNotThrowArgumentException()
        {
            string format = "r";
            BigInteger number = 12;

            ConsoleNumberPrinter.PrintAsRoundTrippedNumber(number, format);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NonFormattableIntegerNumber_ShouldThrowArgumentException()
        {
            string format = "r";
            int number = 12;

            ConsoleNumberPrinter.PrintAsRoundTrippedNumber(number, format);
        }
    }
}