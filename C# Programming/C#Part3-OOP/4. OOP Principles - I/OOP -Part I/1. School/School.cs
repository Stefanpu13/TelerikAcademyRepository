using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.School
{
    public class School
    {        
        
        public List<SchoolClass> Classes { get; set; }
     

        public School() 
        {
            this.Classes = new List<SchoolClass>();
        }

        //NOTE: List of Teachers can aslo be added
        public School(List<SchoolClass> classes) 
        {
            this.Classes = classes;
        }

        public void AddClass(SchoolClass schoolClass) 
        {
            if (Classes.Count > 0)
            {
                if (!Classes.Contains(schoolClass))
                {
                    Classes.Add(schoolClass);
                }
                else
                {
                    string message = "Class already exists!";
                    throw new InvalidOperationException(message);
                }
            }
            else
            {                
                Classes.Add(schoolClass);
            }
        }
    }
}
