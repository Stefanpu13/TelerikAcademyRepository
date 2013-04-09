using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3.AnimalsHierarchy
{
    public class Frog:Animal
    {
            public Frog(int age, string name, Sex gender) : base(age, name, gender) { }

        public Frog() : base() { }

        public override void Move(int distance) 
        {
            Console.WriteLine("Frog {0} moved  {1} meters.", this.Name, distance);
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Frog {0} says qwack-qwack",  this.Name);
        }
    }
}