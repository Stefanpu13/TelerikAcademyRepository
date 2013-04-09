using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.StringBuilderExt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter some string: ");
            string text = Console.ReadLine();

            StringBuilder textStringBuilder = new StringBuilder(text);

            int index;
            bool inputedIndexIsNumber = false;
            do
            {
                Console.Write("Enter index: 0 <= index < {0} : ", text.Length);
                inputedIndexIsNumber = int.TryParse(Console.ReadLine(), out index);
                
            } while (!inputedIndexIsNumber || !IndexIsInRange(index,  text.Length));

            StringBuilder substringText = textStringBuilder.Substring(index);

            Console.WriteLine("Substring stringbuilder: {0}", substringText);
        }

        private static bool IndexIsInRange(int index, int upperLimit)
        {
            return index >= 0 && index < upperLimit;
        }
    } 

    
}
