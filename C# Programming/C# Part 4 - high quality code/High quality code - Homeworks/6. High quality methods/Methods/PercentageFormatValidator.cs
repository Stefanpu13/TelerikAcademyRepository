using System;

namespace Methods
{
    internal class PercentageFormatValidator : NumberFormatValidator
    {
        /// <summary>
        /// Throws <see cref="ArgumentException"/> if the object can not be formatted using
        /// the percentage format specifier.
        /// </summary>
        /// <param name="number">The number to be examined.</param>
        internal override void ThrowExceptionIfCanNotBeFormatted(object number)
        {
            bool numberCanBeFormatted = CanBeFormatted(number);

            if (!numberCanBeFormatted)
            {
                string message = "Number must be a built-in numeric type " +
                    "to successfully apply percentage format specifier. ";
                throw new ArgumentException(message);
            }
        }

        /// <summary>
        /// Throws <see cref="ArgumentException"/> if the format provided is not 
        /// the percentage format specifier or "%".
        /// </summary>
        /// <param name="format">The format to be examined.</param>
        internal override void ThrowExceptionIfIsInvalid(string format)
        {
            if (format.ToLower() != "p" && format != "%")
            {
                throw new ArgumentException("Format provided is not percentage.");
            }
        }
    }
}
