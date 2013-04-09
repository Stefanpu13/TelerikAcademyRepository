using System;
using System.Linq;


namespace _3.AnimalsHierarchy
{
    public abstract class Animal: ISound
    {
        public Animal(int age, string name, Sex gender) 
        {
            this.Age = age;
            this.Name = name;
            this.Gender = gender;            
        }

        public Animal() : this(0, "Undefined", Sex.Undefined) { }

        //Readonly property used to distinghuish between different types of animals
        public string AnimalType { 
            get 
            {
                //Gets only the name of the class
                string wholeName = this.GetType().ToString();
                string typeName = wholeName.Substring(wholeName.LastIndexOf('.') + 1);
                return typeName;
            }
        }

        public int Age { get; set; }

        public virtual Sex Gender { get; set; }

        public string Name { get; set; }

        public abstract void ProduceSound();            

        public abstract void Move(int distance);
    }
}