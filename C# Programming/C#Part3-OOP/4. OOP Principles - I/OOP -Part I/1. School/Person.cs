using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.School
{
    public abstract class Person : ICommentable
    {
        protected string Name
        {
            get;
            set;
        }

        public Dictionary<string, Comment> Comments
        {
            get;
            set;
        }

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
            return this.Name;
        }
    }

    
}
