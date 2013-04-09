using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.PrintDivisibleBy21
{
    /*Write a program that prints from given array of integers all numbers that are divisible by 7 and 3.
     * Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.
*/
    class Program
    {
        static void Main(string[] args)
        {
            //1. Using labmda
            #region
            int[] arrayOfNumbers = InitialiseArray(225);

           IEnumerable<int> numbersWithLambda = arrayOfNumbers.Where(x => x % 21 == 0);

            Console.WriteLine("Numbers divisible by 21 using lambda: ");
            foreach (var number in numbersWithLambda)
            {
                Console.WriteLine(number);
            }
            #endregion

            //2. Using LINQ
            #region
            

            var numbersWithLINQ =
                from number in arrayOfNumbers
                where number % 21 == 0
                select number;

            Console.WriteLine("Numbers divisible by 21 using LINQ: ");
            foreach (var number in numbersWithLINQ)
            {
                Console.WriteLine(number);
            }
            #endregion
        }

        private static int[] InitialiseArray(int numberOfElements)
        {
            int[] array = new int[numberOfElements];

            for (int i = 0; i < numberOfElements; i++)
            {
                array[i] = i;
            }

            return array;
        }
    }
}
