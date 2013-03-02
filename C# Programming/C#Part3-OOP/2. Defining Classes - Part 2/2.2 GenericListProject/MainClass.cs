using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListProject
{
    class MainClass
    {
        static void Main(string[] args)
        {
            //List<int> numbers = new List<int>() { 1, 2, 3, 4,5 };

            ////Console.WriteLine(numbers[-1]);
            //Console.WriteLine(numbers.Capacity);
            //numbers.Capacity = 6;

            //Console.WriteLine(numbers.Capacity);
           
            //numbers.Clear();
            //Console.WriteLine();

            GenericList<int> numbers = new GenericList<int>();
            numbers.Add(23);
            numbers.Add(14);

            Console.WriteLine(numbers);
            Console.WriteLine("Inserting 45 at position 1...");
            numbers.Insert(1, 45);
            Console.WriteLine(numbers);


            Console.WriteLine("Removing at position 1...");
            numbers.RemoveAt(1);
            Console.WriteLine(numbers);

            Console.WriteLine("Removing at position 1 again...");
            numbers.RemoveAt(1);
            Console.WriteLine(numbers);

            Console.WriteLine("Adding 24...");
            numbers.Add(24);
            Console.WriteLine("Adding 37...");
            numbers.Add(37);
            Console.WriteLine("Adding 1...");
            numbers.Add(1);

            Console.WriteLine(numbers);

            Console.WriteLine("Clearing Generic list...");
            numbers.Clear();
            Console.WriteLine(numbers);

            Console.WriteLine("Adding 124...");
            numbers.Add(124);
            Console.WriteLine("Adding 31...");
            numbers.Add(31);
            Console.WriteLine("Adding 1...");
            numbers.Add(1);
            Console.WriteLine("Adding 2...");
            numbers.Add(2);

            
            Console.WriteLine("Min: "+numbers.Min<int>());
            Console.WriteLine("Max: " + numbers.Max<int>());


            
        }
    }


}
