using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.School
{
    public struct Comment
    {
        public Comment(string title, string content) : this() 
        {
            this.Title = title;
            this.Content = content;
        }

        public Comment(string title)
            : this()
        {
            this.Title = title;
            this.Content = "";
        }

        public string Title { get; set; }
        public string Content { get; set; }

        public override string ToString()
        {
            StringBuilder commentInfo = new StringBuilder();

            commentInfo.AppendLine("Title: " +  this.Title);
            commentInfo.AppendLine("Content: " + this.Content);

            return commentInfo.ToString();
        }

    }
}
