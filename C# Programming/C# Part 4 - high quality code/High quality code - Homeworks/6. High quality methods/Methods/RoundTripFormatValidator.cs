using System;
using System.Numerics;

namespace Methods
{
    internal class RoundTripFormatValidator : NumberFormatValidator
    {
        /// <summary>
        /// Throws <see cref="ArgumentException"/> if the object can not be formatted using
        /// the round-trip format specifier.
        /// </summary>
        /// <param name="number">The number to be examined.</param>
        internal override void ThrowExceptionIfCanNotBeFormatted(object number)
        {
            bool numberCanBeFormatted = this.CanBeFormatted(number);

            if (!numberCanBeFormatted)
            {
                string message = "Number must be of type Single, Double or BigInteger " +
                    "to successfully apply round-trip format specifier. ";
                throw new ArgumentException(message);
            }
        }

        /// <summary>
        /// Throws <see cref="ArgumentException"/> if the format provided is not 
        /// the round-trip format specifier.
        /// </summary>
        /// <param name="format">The format to be examined.</param>
        internal override void ThrowExceptionIfIsInvalid(string format)
        {
            if (format.ToLower() != "r")
            {
                throw new ArgumentException("Format provided is not round-trip.");
            }
        }

        /// <summary>
        /// Checks if the object is a numeric type that can be formatted using
        /// the round-trip number format. The object must of type <see cref="System.Double"/>,
        /// <see cref="System.Single"/> or <see cref="System.Numerics.BigInteger"/> in order
        /// to successfully formatted.
        /// </summary>
        /// <param name="number">The number to be examined.</param>
        /// <returns>True if object can be formatted, false otherwise.</returns>
        protected override bool CanBeFormatted(object number)
        {
            if ((number is float) || (number is double) || (number is BigInteger))
            {
                return true;
            }

            return false;
        }
    }
}
