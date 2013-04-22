namespace _2.Statistics
{
    using System;

    static class StatisticsCalcs
    {
        /// <summary>
        /// Gets the sum of the first "k" elements of a given array, where "k" is a positive integer
        /// smaller than or equal to the size of the array.
        /// </summary>
        /// <param name="data">The array to be summed.</param>
        /// <param name="elementsCount">The quantity of the elements to be summed.</param>
        /// <returns>The sum.</returns>
        internal static double GetSum(double[] data, int elementsCount)
        {
            double sum = 0;

            for (int i = 0; i < elementsCount; i++)
            {
                sum += data[i];
            }

            return sum;
        }

        /// <summary>
        /// Gets the smallest among the first "k" elements, where "k" is a positive integer
        /// smaller than or equal to the size of the array.
        /// </summary>
        /// <param name="data">The examined array.</param>
        /// <param name="elementsCount">The quantity of the examined elements.</param>
        /// <returns>The smallest element.</returns>
        internal static double GetMin(double[] data, int elementsCount)
        {
            double min = 0;

            for (int i = 0; i < elementsCount; i++)
            {
                if (data[i] < min)
                {
                    min = data[i];
                }
            }

            return min;
        }

        /// <summary>
        /// Gets the the largest among the first "k" elements, where "k" is a positive integer
        /// smaller than or equal to the size of the array.
        /// </summary>
        /// <param name="data">The examined array.</param>
        /// <param name="elementsCount">The quantity of the examined elements.</param>
        /// <returns>The largest element.</returns>
        internal static double GetMax(double[] data, int elementsCount)
        {
            double max = double.MinValue;

            for (int i = 0; i < elementsCount; i++)
            {
                if (data[i] > max)
                {
                    max = data[i];
                }
            }

            return max;
        }
    }
}
