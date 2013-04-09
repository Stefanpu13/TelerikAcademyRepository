using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.Human
{
    public class Student : Human
    {
        private int grade;

        public Student(string firstName, string lastName) : base(firstName, lastName) 
        {

        }

        public Student(string firstName, string lastName, int grade) : base(firstName, lastName) 
        {
            this.grade = grade;
        }


        public int Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public override string ToString()
        {
            string studentInfo = string.Format( "First name: {0}, Last name: {1},  Grade: {2}" ,
                this.FirstName , this.LastName , this.grade);
            return studentInfo;
        }
    }
}
