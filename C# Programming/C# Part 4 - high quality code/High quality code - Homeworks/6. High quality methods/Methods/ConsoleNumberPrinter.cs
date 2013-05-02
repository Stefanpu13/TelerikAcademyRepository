using System;

namespace Methods
{
    public static class ConsoleNumberPrinter
    {
        /// <summary>
        /// Prints the provided object as a number formatted with the round-trip number format.
        /// </summary>
        /// <param name="number">The object to be displayed on the console.</param>
        /// <param name="format">The format applied to the given object.</param>
        /// <exception cref="ArgumentNullException">Number or format is null.</exception>
        /// <exception cref="ArgumentException"> Format provided is not round-trip format -or-
        /// Number is of type that does not support round-trip format</exception>
        /// <remarks>The method prints the number using the default round-trip format
        /// for the respective type</remarks>
        public static void PrintAsRoundTrippedNumber(object number, string format)
        {
            NumberFormatValidator.ThrowExceptionIfNull(number, format);

            RoundTripFormatValidator validator = new RoundTripFormatValidator();
            validator.ThrowExceptionIfIsInvalid(format);
            validator.ThrowExceptionIfCanNotBeFormatted(number);

            string roundTripFormat = "{0:" + format + "}";
            Console.WriteLine(roundTripFormat, number);
        }

        /// <summary>
        /// Prints the provided object as a number formatted with the percentage number format.
        /// </summary>
        /// <param name="number">The object to be displayed on the console.</param>
        /// <param name="format">The format applied to the given object.</param>
        /// <exception cref="ArgumentNullException">Number or format is null.</exception>
        /// <exception cref="ArgumentException"> Format provided is not percentage format -or-
        /// Number is of type that does not support percentage format</exception>
        /// <remarks>Prints the number as percent without displaying decimal places.</remarks>
        public static void PrintAsPercentage(object number, string format)
        {
            NumberFormatValidator.ThrowExceptionIfNull(number, format);

            PercentageFormatValidator validator = new PercentageFormatValidator();
            validator.ThrowExceptionIfIsInvalid(format);
            validator.ThrowExceptionIfCanNotBeFormatted(number);

            Console.WriteLine("{0:p0}", number);
        }

        /// <summary>
        /// Prints the provided object as a number formatted with the fixed point number format.
        /// </summary>
        /// <param name="number">The object to be displayed on the console.</param>
        /// <param name="format">The format applied to the given object.</param>
        /// <exception cref="ArgumentNullException">Number or format is null.</exception>
        /// <exception cref="ArgumentException"> Format provided is not fixed point format -or-
        /// Number is of type that does not support fixed point format</exception>        
        /// <remarks>Prints the number as fixed point with two decimal digits.</remarks>
        public static void PrintAsFixedNumber(object number, string format)
        {
            NumberFormatValidator.ThrowExceptionIfNull(number, format);

            FixedPointFormatValidator validator = new FixedPointFormatValidator();
            validator.ThrowExceptionIfIsInvalid(format);
            validator.ThrowExceptionIfCanNotBeFormatted(number);

            Console.WriteLine("{0:f2}", number);
        }
    }
}
