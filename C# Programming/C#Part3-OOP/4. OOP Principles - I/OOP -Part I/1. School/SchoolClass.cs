using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.School
{
    public class SchoolClass : ICommentable
    {


        public SchoolClass(string textIdentifier)
        {
            this.TextIdentifier = textIdentifier;
            this.Students = new SortedList<Student, Student>();
            this.Comments = new Dictionary<string, Comment>();           
        }



        public Dictionary<string, Comment> Comments { get; set; }

        public string TextIdentifier { get; set; }

        public List<Teacher> Teachers { get; set; }

        // Students will be sorted according to their names.
        //See "Student" class for more details.
        public SortedList<Student, Student> Students { get; set; }


        public void AddComment(string title)
        {
            this.AddComment(new Comment (title, ""));
        }

        public void AddComment(Comment comment)
        {
            if (Comments.Count > 0)
            {
                if (!Comments.ContainsKey(comment.Title))
                {
                    Comments.Add(comment.Title, comment);
                }
                else
                {
                    Console.WriteLine("Comment with same title exist.");
                    Console.WriteLine("Are you sure you wnat to replace comment?");

                    //Some code that implemensts that functionality....
                }
            }

            else
            {
                Comments.Add(comment.Title,comment);
            }
        }

        public void DeleteComment(string title)
        {
            if (Comments.ContainsKey(title))
            {
                Comments.Remove(title);
            }
            else
            {
                throw new InvalidOperationException("Comment not found!");
            }
        }

        public void EditComment(string title, string content)
        {
            if (Comments.ContainsKey(title))
            {
                Comments[title] = new Comment(Comments[title].Title, content);
            }
            else
            {
                throw new InvalidOperationException("Comment not found!");
            }
        }

        public void ShowComment(string title)
        {
            if (Comments.ContainsKey(title))
            {
                Console.WriteLine(Comments[title]);
            }
            else
            {
                throw new InvalidOperationException("Comment not found!");
            }
        }

        public void ShowAllComments()
        {
            if (this.Comments != null)
            {
                foreach (var comment in this.Comments)
                {
                    Console.WriteLine(comment.Value);
                }
            }
            else
            {
                throw new NullReferenceException("No comments for " + this.ToString());
            }
        }
        
        // "ContainsKey" uses Comparer that is overriden in "Student" class
        // In order to sort srudents by name and to avoid adding students with same keys,
        // addition comparison elements are included.
        //See "Student" class, "studentCounter" field for more info
        public void AddStudent(Student student)
        {            
            if (!Students.ContainsKey(student))
            {
                
                Students.Add(student, student);
                student.SchoolClass = this;
            }
            else
            {
                string message = "Same student can`t be added twice";
                throw new InvalidOperationException(message);
            }
        }

        public void RemoveStudent(Student student)
        {
            this.RemoveStudent(student, 0);
        }

        public void RemoveStudent(Student student, int classNumber)
        {
            if (Students.ContainsKey(student))
            {
                if (classNumber==0)
                {
                    Students.RemoveAt(Students.IndexOfValue(student));
                }
                else
                {
                    Students.RemoveAt(classNumber - 1);
                }
                
            }
            else
            {
                string message = "Student not found in class " + this.TextIdentifier;
                throw new InvalidOperationException(message);
            }
        }

        public void ShowStudents() 
        {
            if (this.Students.Count > 0)
            {
                foreach (var student in this.Students)
                {
                    Console.WriteLine(student.Value);
                }
            }
            else
            {
                string message = "No students in class";
                throw new InvalidOperationException(message);
            }
        }

        //Used in "AddClass" method in "school" class.Two school classes can be compared by their
        //Unique textIdentifiers. If a school class already exists then the new class is not added.
        public override bool Equals(object schoolClass)
        {
            if (schoolClass is SchoolClass)
            {
                SchoolClass other = schoolClass as SchoolClass;
                return this.TextIdentifier.Equals(other.TextIdentifier,StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                string message = "Object is not a school class.";
                throw new ArgumentException(message);
            }
        }

        public override int GetHashCode()
        {
            return this.TextIdentifier.GetHashCode();
        }    

        public override string ToString()
        {        
            return this.TextIdentifier;
        }
    }
}
