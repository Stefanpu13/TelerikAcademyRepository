using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Human
{
    class HumanTest
    {
        static void Main(string[] args)
        {
            string taskInfo;

            // Initialise 10 students and sort them using LINQ and Extensions
            #region
            List<Student> students = new List<Student>() 
            {
                new Student("Georgi","Ivanov", 6), new Student("Georgi","Botev", 6),
                new Student("Georgi","Stankov", 3),new Student("Stoil","Madarski", 9),
                new Student("Ivelina","Stankova", 5),new Student("Stoqn","Jivkov", 9),
                new Student("Ivanka","Bojkova", 6),new Student("Dimitar","Berbatov", 5),
                new Student("Petar","Dimitrov", 9), new Student("Petyo","Markov", 12)
            };
            PrintTaskInfo("Initialise 10 students and sort them using LINQ and Extensions/n");

            taskInfo = "Print unsorted students: ";
            PrintTaskInfo(taskInfo);
            PrintHumans(students);   
         

            var studentsSortedWithLINQ =
                from student in students
                orderby student.Grade, student.FirstName, student.LastName
                select student;

            taskInfo = "Sort students by grade using LINQ";
            PrintTaskInfo(taskInfo);
            PrintHumans(studentsSortedWithLINQ);


            IEnumerable<Student> studentsSortedWithExtension =
                students.OrderBy(x => x.Grade).ThenBy(x => x.FirstName).ThenBy(x => x.LastName);

            taskInfo = "Sort students by grade using extension methods";
            PrintTaskInfo(taskInfo);
            PrintHumans(studentsSortedWithExtension);
            #endregion

            // Initialise 10 workers and sort them using LINQ and Extensions
            #region
            List<Worker> workers = new List<Worker>()
            {
                new Worker("Poli", "Genova",600, 8), new Worker("Genadi", "Makaveev",700, 8),
                new Worker("Hasan", "Azis",600, 8), new Worker("Ivan", "Borisov - Ivanov",4220, 8),
                new Worker("Mitio", "Pishtova",600, 8), new Worker("Ivan", "Borisov",400, 8),
                new Worker("Stoqn", "Parushev",350, 8), new Worker("Miroslav", "Simov",340, 8),                               
                new Worker("Lidiq", "Hristova",6000, 8), new Worker("Dimitar", "Berbatov",350000, 24),
            };

            

            // Using LINQ
            var workersSortedWithLINQ =
                from worker in workers
                orderby worker.MoneyPerHour() descending, worker.FirstName descending,
                worker.LastName descending
                select worker;

            Console.WriteLine("---------------------------------------");
            PrintTaskInfo("Initialise 10 workers and sort them using LINQ and Extensions");
            taskInfo = "Initial Workers: ";
            PrintTaskInfo(taskInfo);
            PrintHumans(workers);

            taskInfo = "Workers sorted using LINQ: ";
            PrintTaskInfo(taskInfo);
            PrintHumans(workersSortedWithLINQ);

            // USING Extension methods

            IEnumerable<Human> workersSortedWithExtension = workers.OrderByDescending(x=>x.MoneyPerHour()).
                ThenByDescending(x=>x.FirstName).ThenByDescending(x=>x.LastName);
            
            taskInfo = "Initial Workers: ";
            PrintTaskInfo(taskInfo);
            PrintHumans(workers);

            taskInfo = "Workers sorted using Extension: ";
            PrintTaskInfo(taskInfo);
            PrintHumans(workersSortedWithExtension);
            #endregion

            // Merge two lists and sort them by first and last name.
            #region

            IEnumerable<Human> workersAndStudents = students.Union<Human>(workers);
            Console.WriteLine("---------------------------------------");
            PrintTaskInfo("Merge two lists and sort them by first and last name.\n");
            taskInfo = "Workers and students initial list again.";
            PrintTaskInfo(taskInfo);
            PrintHumans(workers);
            PrintHumans(students);           

            taskInfo = "Workers and students combined: ";
            PrintTaskInfo(taskInfo);
            PrintHumans(workersAndStudents);

            var workersAndStudentsSortedbyLINQ =
                from human in workersAndStudents
                orderby human.FirstName, human.LastName
                select human;

            taskInfo = "Workers and students sorted using LINQ:";
            PrintTaskInfo(taskInfo);
            PrintHumans(workersAndStudentsSortedbyLINQ);    
            #endregion


        }

        private static void PrintHumans(IEnumerable<Human> humansSorted)
        {
            Console.WriteLine();
            foreach (var human in humansSorted)
            {
                Console.WriteLine(human);
            }
            Console.WriteLine();
        }

        public static void PrintTaskInfo(string text) 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
