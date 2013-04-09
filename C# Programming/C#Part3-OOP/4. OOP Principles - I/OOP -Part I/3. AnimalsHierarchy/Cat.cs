using System;
using System.Linq;


namespace _3.AnimalsHierarchy
{
    public abstract class Cat : Animal
    {
        public Cat(int age, string name, Sex gender) : base(age, name, gender) { }

        public Cat() : base() { }


        public override void Move(int distance)
        {
            Console.WriteLine("Cat {0} moved  {1} meters.", this.Name, distance);
        }

        public abstract void EatCatFood();

    }
}