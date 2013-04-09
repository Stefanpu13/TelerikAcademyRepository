using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.IEnumerableExtension
{
    /*Implement a set of extension methods for IEnumerable<T>
     * that implement the following group functions: sum, product, min, max, average*/
    class Program
    {
        static void Main(string[] args)
        {
            List<int> intValues = new List<int>() { 3, 9, 3, 0, 2, -45 };

            PrintCollection(intValues);

            Console.WriteLine("\nINT\n");
            Console.WriteLine("Min: {0}", intValues.MinExt());
            Console.WriteLine("Max: {0}", intValues.MaxExt());
            Console.WriteLine("Sum: {0}", intValues.SumExt());
            Console.WriteLine("Product: {0}", intValues.ProductExt());
            //Note: average of int values is an int value.
            Console.WriteLine("Average: {0}", intValues.AverageExt());

            List<double> doubleValues = new List<double>() { 3, 9, 3, 0, 2, -45 };

            Console.WriteLine("\nDOUBLE\n");
            Console.WriteLine("Min: {0}", doubleValues.MinExt());
            Console.WriteLine("Max: {0}", doubleValues.MaxExt());
            Console.WriteLine("Sum: {0}", doubleValues.SumExt());
            Console.WriteLine("Product: {0}", doubleValues.ProductExt());
            //Note: average of int values is an int value.
            Console.WriteLine("Average: {0}", doubleValues.AverageExt());

            List<double> noValues = new List<double>();

            Console.WriteLine("No elements sum with built - in extension: {0}", noValues.Sum());
            Console.WriteLine("No elements sum with custom extendion: {0}", noValues.SumExt());
        }

        private static void PrintCollection(List<int> values)
        {
            Console.Write("Collection values: ");
            foreach (var item in values)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
