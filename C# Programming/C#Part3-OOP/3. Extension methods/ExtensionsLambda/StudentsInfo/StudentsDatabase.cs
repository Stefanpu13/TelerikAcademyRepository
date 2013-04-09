using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Threading.Tasks;

namespace StudentsInfo
{
    class StudentsDatabase
    {
        public static Student[] Students { get; set; }

        static StudentsDatabase()
        {
            Students = new Student[] 
            {
                //A list of object initalisers
                new Student {FirstName = "Pesho", LastName ="Ivanov", Age = 23},
                new Student {FirstName = "Pesho", LastName ="Georgiev", Age = 23},
                new Student {FirstName = "Ivan", LastName ="Peshev", Age = 20},
                new Student {FirstName = "Georgi", LastName ="Ivanov", Age = 21},
                new Student {FirstName = "Todor", LastName ="Stoyanov", Age = 25},
                new Student {FirstName = "Todor", LastName ="Todorov", Age = 27},
                new Student {FirstName = "Miroslav", LastName ="Ivanov", Age = 24},
                new Student {FirstName = "Alesandro", LastName ="Nesta", Age = 24}
            };
        }        

        public static void PrintStudents()
        {
            foreach (var student in Students)
            {
                Console.WriteLine(student);
            }
        }

        public static void PrintStudents(IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
    }
}
