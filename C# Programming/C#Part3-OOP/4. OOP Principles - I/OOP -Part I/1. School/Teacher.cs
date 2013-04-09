using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.School
{
    public class Teacher : Person, ICommentable
    {
        public List<Discipline> DisciplinesSet { get; set; }
       

        public Teacher(string name, List<Discipline> disciplines) 
        {
            this.Name = name;
            this.DisciplinesSet = disciplines;
            this.Comments = new Dictionary<string, Comment>();
        }

        public void ShowTeacherDisciplines() 
        {
            if (this.DisciplinesSet!=null)
            {
                foreach (var dispipline in DisciplinesSet)
                {
                    Console.WriteLine(dispipline);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder teacherInfo = new StringBuilder();

            teacherInfo.AppendLine("Name: " + this.Name);

            foreach (var discipline in this.DisciplinesSet)
            {
                teacherInfo.AppendLine(discipline.ToString());
            }

            return teacherInfo.ToString();
        }
    }
}
