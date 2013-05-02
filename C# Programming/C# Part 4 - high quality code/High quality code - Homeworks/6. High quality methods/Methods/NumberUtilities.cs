using System;

namespace Methods
{
    public static class NumberUtilities
    {
        /// <summary>
        /// Checks if the given integer is a digit.
        /// </summary>
        /// <param name="number">The integer to be checked.</param>
        /// <returns>True if number is digit, false otherwise.</returns>
        /// <exception cref="ArgumentException">Number is less than 0 or greater than 9.</exception>
        public static string NumberToDigit(int number)
        {
            string message = "Number is less than zero or greater than nine. It is" +
                "not a digit";

            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentException(message);
            }
        }

        /// <summary>
        /// Finds the maximum integer in a given array of numbers.
        /// </summary>
        /// <param name="elements">The elements to be examined.</param>
        /// <returns>The max number.</returns>
        /// <exception cref="ArgumentNullException">The provided array is null.</exception>
        /// <exception cref="ArgumentException">There no numbers in the provided array.</exception>
        public static int FindMax(params int[] elements)
        {
            // First a null check must be done before any operations with
            // argument "elements" are done.
            if (elements == null)
            {
                throw new ArgumentNullException("elements");
            }

            if (elements.Length == 0)
            {
                string message = "No elements in array.";
                throw new ArgumentException(message);
            }

            var maxElement = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }
    }
}
