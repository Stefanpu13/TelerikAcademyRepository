using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3.AnimalsHierarchy
{
    public class Dog : Animal
    {

        public Dog(int age, string name, Sex gender) : base(age, name, gender) { }

        public Dog() : base() { }

        public override void Move(int distance) 
        {
            Console.WriteLine("Dog {0} moved  {1} meters.", this.Name, distance);
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Dog {0} says bay-bay",  this.Name);
        }
    }
}