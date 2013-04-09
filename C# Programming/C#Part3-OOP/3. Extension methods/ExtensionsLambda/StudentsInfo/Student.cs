using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace StudentsInfo
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        //No constructor in order to use object initialiser

        public override string ToString()
        {
            StringBuilder studentInfoStringBuilder = new StringBuilder();
            Type studentType = this.GetType();

            PropertyInfo[] studentProperties = 
                studentType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
           

            foreach (var studentProperty in studentProperties)
            {
                studentInfoStringBuilder.
                    Append(studentProperty.Name + ": " + studentProperty.GetValue(this) +"; ");
            }

            return studentInfoStringBuilder.ToString();

        }
    }
}
