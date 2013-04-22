namespace _2.Statistics
{
    using System;

    class StatisticsPrinter
    {
        /// <summary>
        /// Prints information about a given array of numbers.
        /// </summary>
        /// <param name="data">The examined array of numbers.</param>
        /// <param name="elementsCount">The number of actually examined elements in the array.</param>
        public void PrintStatistics(double[] data, int elementsCount)
        {
            if (data == null)
            {
                string message = "Can not print statistics of null";
                throw new ArgumentNullException("data", message);
            }
            else
            {
                if (elementsCount <= 0 || elementsCount > data.Length)
                {
                    string message = "Elements count must be positive and smaller than the size of " +
                        "data array.";
                    throw new ArgumentException(message);
                }

                double max = StatisticsCalcs.GetMax(data, elementsCount);
                this.PrintValue(max);

                double min = StatisticsCalcs.GetMin(data, elementsCount);
                this.PrintValue(min);

                double sum = StatisticsCalcs.GetSum(data, elementsCount);

                double average = sum / elementsCount;
                this.PrintValue(average);
            }
        }

        private void PrintValue(double value)
        {
            // Note: Methods is intentionally left unimplemented.
            throw new NotImplementedException();
        }
    }
}
