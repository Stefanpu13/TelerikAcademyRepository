using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3.AnimalsHierarchy
{
    public class Tomcat:Cat
    {
         public Tomcat(int age, string name) 
         {
             this.Age = age;
             this.Name = name;
         }

         public Tomcat() 
         {
             this.Age = 0;
             this.Name = "Undefined";
         }

         //Read only property so that no accidental wrong gender is entered.
        public override Sex Gender
        {
            get
            {
                return Sex.Male;
            }     
        }

        public override void Move(int distance)
        {
            Console.WriteLine("Tomcat {0} moved  {1} meters.", this.Name, distance);
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Tomcat {0} says huuuuhhuhhyaaaayyy", this.Name);
        }

        public override void EatCatFood()
        {
            Console.WriteLine("Tomcat {} likes catfood but it prefers fish.");
        }

        public void Hunt(object prey) 
        {
            if (prey is Animal)
            {
                Type preyType = prey.GetType();
                Animal preyAsAnimal = prey as Animal;
                Console.WriteLine("Tomcat {0} hunts {1} {2}", this.Name, preyType.Name,preyAsAnimal.Name);
            }
            else
            {
                //Better to throw exception
                Console.WriteLine("Prey {0} is not an animal.", prey.GetType());
            }
        }
    }

}