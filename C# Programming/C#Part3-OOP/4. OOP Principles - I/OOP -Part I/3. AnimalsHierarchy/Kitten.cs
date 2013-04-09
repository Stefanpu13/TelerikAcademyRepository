using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3.AnimalsHierarchy
{
    public class Kitten: Cat
    {

         public Kitten(int age, string name) 
         {
             this.Age = age;
             this.Name = name;
         }

         public Kitten() 
         {
             this.Age = 0;
             this.Name = "Undefined";
         }

        // Read only property so that no accidental wrong gender is entered.
        public override Sex Gender
        {
            get
            {
                return Sex.Female;
            }
        }

        public override void Move(int distance)
        {
            Console.WriteLine("Kitten {0} moved  {1} meters.", this.Name, distance);
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Kitten {0} says miayy", this.Name);
        }

        public override void EatCatFood()
        {
            Console.WriteLine("Kitten {0} is still small and prefers milk.", this.Name);
        }

    }
}