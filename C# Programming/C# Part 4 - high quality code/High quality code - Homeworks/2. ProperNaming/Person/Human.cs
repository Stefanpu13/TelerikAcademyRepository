using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    class Human
    {
        public Gender Sex { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public void MakeHuman(int age) 
        {
            Human newHuman = new Human();

            newHuman.Age = age;

            if (age % 2 == 0)
            {
                newHuman.Name= "Big Brother";
                newHuman.Sex = Gender.Male;
            }
            else
            {
                newHuman.Name = "Chick";
                newHuman.Sex = Gender.Female;
            }
        }
    }
}
