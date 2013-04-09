using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.School
{
    class SchoolTest
    {
        static void Main(string[] args)
        {
            //Create a school.
            //Add a few empty classes and print their text identifiers.
            #region
            SchoolClass class11A = new SchoolClass("11A");
            SchoolClass class10A = new SchoolClass("10A");
            SchoolClass class12B = new SchoolClass("12B");
            SchoolClass class11C = new SchoolClass("11C");

            List<SchoolClass> schoolClasses = new List<SchoolClass>() { class10A, class11A, class11C, class12B };

            School MGGeoMilev = new School(schoolClasses);

            Console.WriteLine("Add a few empty classes and print their text identifiers");
            foreach (var schoolClass in schoolClasses)
            {
                Console.WriteLine("class: " + schoolClass);
            }
            Console.WriteLine();
            #endregion

            //Create a few teachers and print info about them
            #region
            List<Discipline> disciplines = new List<Discipline>() 
            {
                new Discipline("Maths", 26, 13), new Discipline("Biology", 26, 13), 
                new Discipline("Informatics", 26, 13), new Discipline("Physics", 26, 13)
            };

            //Teachers are initialised that way so I can practice extension methods and predicates
            List<Teacher> teachers = new List<Teacher>() 
            {
                //Take all disciplines whose name is not "Biology"
                new Teacher("Petar Marinov",(disciplines.Where(x=>x.DisciplineName!="Biology")).ToList()),
                //Take all but the last disciplines
                new Teacher("Violeta Stefanova",(disciplines.Take(disciplines.Count-2).ToList())),
                //Take all disciplines whose index is even number. 
                //NOTE: here i is the index of the dicipline in the collection "disciplines"
                new Teacher("Anika Alexandrova",(disciplines.Where
                    ((discipline,index) => index%2==0).ToList()))                    
            };

            Console.WriteLine("Create a few teachers and print info about them");
            foreach (var teacher in teachers)
            {
                Console.WriteLine(teacher);                
            }
            Console.WriteLine();
            #endregion

            // Add 5-6 students in class "11A" and perform some operations
            #region
            //Two different students
            Student georgi = new Student("Georgi Georgiev");
            Student georgi2 = new Student("Georgi Georgiev");
            //Two different students
            Student ivan = new Student("Ivan Ivanov");
            Student ivan2 = new Student("Ivan Ivanov");
            Student bobi = new Student("Borislav Ivanov");

            class11A.AddStudent(ivan2);
            class11A.AddStudent(georgi);
            class11A.AddStudent(georgi2);
            class11A.AddStudent(ivan);            
            class11A.AddStudent(bobi);

            Console.WriteLine("Add 5-6 students in class \"11A\" and perform some operations\n");

            class11A.ShowStudents();

            //Show students in class that has no students
            try
            {
                class10A.ShowStudents();
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }

            //Add student
            Console.WriteLine("Add new student");
            Student andrian = new Student("Andrian Ivanov");

            class11A.AddStudent(andrian);

            Console.WriteLine("Class \"11A\" after adding Andrian Ivanov.");
            class11A.ShowStudents();

            //Remove first Georgi Ivanov using its class number
            Console.WriteLine("\nRemove first Georgi Georgiev.");

            int georGiClassNumber = georgi.ClassNumber;
            class11A.RemoveStudent(georgi,georGiClassNumber);

            Console.WriteLine("\nClass \"11A\" after removing  first Georgi Georgiev.\n");
            class11A.ShowStudents();

            //Remove first Borislav Ivanov.
            Console.WriteLine("\nRemove Borislav Ivanov.");

            
            class11A.RemoveStudent(bobi);

            Console.WriteLine("\nClass \"11A\" after removing  Borislav Ivanov.\n");
            class11A.ShowStudents();
            #endregion

            //Add few comments to andrian and georgi
            #region
            //Adrian
            Comment andrianFirstComment = new Comment("Good Andrian");
            Comment andrianSecondComment = new Comment("Bad Andrian","Inapropriate behaviour");
            andrian.AddComment(andrianFirstComment);
            andrian.AddComment(andrianSecondComment);

            Comment georgiFirstComment = new Comment("Good Georgi");
            Comment georgiSecondComment = new Comment("Bad Georgi", "Missing");
            georgi.AddComment(georgiFirstComment);
            georgi.AddComment(georgiSecondComment);

            Console.WriteLine("\nShow \"Good Andrian\" comment\n");
            andrian.ShowComment("Good Andrian");

            Console.WriteLine("\nShow Georgi comments\n");
            georgi.ShowAllComments();

            #endregion

        }
    }
}
