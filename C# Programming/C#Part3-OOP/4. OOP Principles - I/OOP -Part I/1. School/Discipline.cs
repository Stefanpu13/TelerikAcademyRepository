using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _1.School
{
    public class Discipline : ICommentable
    {
        private string name;
        private int lecturesCount;
        private int exercisesCount;


        public Discipline(string name, int lecturesCount, int exercisesCount)
        {
            this.name = name;
            this.lecturesCount = lecturesCount;
            this.exercisesCount = exercisesCount;
            this.Comments = new Dictionary<string, Comment>();
        }

        public string DisciplineName
        {
            get { return name; }
            set { name = value; }
        }

        public int LecturesCount
        {
            get { return lecturesCount; }
            set { lecturesCount = value; }
        }       

        public int ExercisesCount
        {
            get { return exercisesCount; }
            set { exercisesCount = value; }
        }

        public Dictionary<string, Comment> Comments { get; set; }


        public void AddComment(string title)
        {
            this.AddComment(new Comment(title, ""));
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
                Comments.Add(comment.Title, comment);
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

        public override string ToString()
        {
            Type disciplineType = typeof(Discipline);

            PropertyInfo[] disiplineProperties = 
                disciplineType.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            StringBuilder disciplineInfo = new StringBuilder();
            foreach (var property in disiplineProperties)
            {
                if (property.Name.Contains("Comments"))
                {
                    if (this.Comments.Count>0)
                    {
                        disciplineInfo.AppendLine(property.Name + ": " + property.GetValue(this));
                    }
                }
                else
                {
                    disciplineInfo.AppendLine(property.Name + ": " + property.GetValue(this));
                }

                

            }

            return disciplineInfo.ToString();
        }
    }
}
