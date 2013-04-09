using System;
using System.Linq;
using System.Collections.Generic;


namespace StudentsInfo
{
    class StudentMainClass
    {
        static void Main(string[] args)
        {

            //Task 3: Write a method that from a given array of students finds all students
            //whose first name is before its last name alphabetically. Use LINQ query operators. 
            #region
            var studentsQuery =
                from student in StudentsDatabase.Students
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;

            Console.WriteLine("List of students whose first name is alphabetically before last name: \n");
            foreach (var student in studentsQuery)
            {
                Console.WriteLine("{"+student+"}");
            }
            #endregion

            //Task 4: Write a LINQ query that finds the first name and last name of all
            //students with age between 18 and 24.
            #region
            var studentFirstAndLastNameQuery =
                from student in StudentsDatabase.Students
                where student.Age >= 18 & student.Age <= 24
                select new { student.FirstName, student.LastName };

            //Returns new anonymous type consisting of two strings
            Console.WriteLine("\nNames of students that are between age 18 and 24.\n");
            foreach (var studentName in studentFirstAndLastNameQuery)
            {
                //See type of studentName
                //Console.WriteLine(studentName.GetType());                
                Console.WriteLine("First name: {0} Last name: {1}",
                    studentName.FirstName, studentName.LastName);
            }
            #endregion

            //Task 5:Using the extension methods OrderBy() and ThenBy() with lambda expressions sort 
            //the students by first name and last name in descending order. Rewrite the same with LINQ  
          
            //Note: Although "OrderByDescending()" and "ThenByDescending()" can be used, I followed the task 
            //literally and used OrderBy and ThenBy. The reason is to practice and to read a little about
            //comparers.
            #region
            Console.WriteLine("\nInitial order: \n");
            StudentsDatabase.PrintStudents();
          
            //Using class that is derived from Comparer<T> class
            ReversedComparer descendingComparer = new ReversedComparer();            

            IEnumerable<Student> orderedStudents =
               StudentsDatabase.Students.OrderBy(x=>x.FirstName,descendingComparer).
               ThenBy(y=>y.LastName,descendingComparer);

            Console.WriteLine("\nSorted by name using comparer: \n");
            StudentsDatabase.PrintStudents(orderedStudents);

            //Using class that inherits StringComparer
            Console.WriteLine("\nInitial order: \n");
            StudentsDatabase.PrintStudents();

            ReversedStringComparer descendingStringComparer = new ReversedStringComparer();

            IEnumerable<Student> newOrderedStudents = StudentsDatabase.Students.
                OrderBy(x => x.FirstName, descendingStringComparer).
                ThenBy(y => y.LastName, descendingStringComparer);

            Console.WriteLine("\nSorted by name using StringComparer: \n");
            StudentsDatabase.PrintStudents(newOrderedStudents);            
            #endregion

            //5.Rewrite with LINQ
            #region
            //Using class that inherits StringComparer
            Console.WriteLine("\nInitial order for lambda: \n");
            StudentsDatabase.PrintStudents();

            var descendingStudentsQuery =
                from student in StudentsDatabase.Students
                orderby student.FirstName descending,
                student.LastName descending
                select student;

            Console.WriteLine("\nSorted by name using lambda expressions: \n");
            foreach (var student in descendingStudentsQuery)
            {
                Console.WriteLine(student);
            }

            #endregion
        }
    }
}
