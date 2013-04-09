using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.School
{
    
    public class Student : Person, ICommentable, IComparable<Student>
    {
        //These two field are used to make sure that students with different names can be added.
        //Every student that choosed this school has signed in some order - before some students
        //and after others. "globalStudentCounter" counts the total number of students
        private static int globalStudentCounter;
        private int studentCounter;

        public int ClassNumber
        {
            //Return the position of the student within its class
            get {return this.SchoolClass.Students.IndexOfValue(this) + 1; }
        }

        public SchoolClass SchoolClass { get; set; }       

        public Student(string name) 
        {
            this.Name = name;            
            this.Comments = new Dictionary<string, Comment>();
            globalStudentCounter++;
            this.studentCounter = globalStudentCounter;
        }


        public int CompareTo(Student otherStudent) 
        {            
            int nameComparison  =  this.Name.CompareTo(otherStudent.Name);
            if (nameComparison==0)
            {
                return this.studentCounter.CompareTo(otherStudent.studentCounter);
            }
            else
            {
                return nameComparison;
            }
        }

        public override string ToString()
        {
            StringBuilder studentInfo = new StringBuilder();
            studentInfo.AppendLine("Student name: " + this.Name);
            studentInfo.AppendLine("Student class number: " + this.ClassNumber);

            return studentInfo.ToString();
        }

       
    }
}
