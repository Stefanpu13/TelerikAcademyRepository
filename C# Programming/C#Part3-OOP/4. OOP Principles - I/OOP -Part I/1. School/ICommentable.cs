using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.School
{
    internal interface ICommentable
    {
        Dictionary<string,Comment> Comments
        {
            get;
            set;
        }

        void AddComment(Comment comment);
    
        void AddComment(string title);

        void EditComment(string title, string content);

        void DeleteComment(string title);

        void ShowComment(string title);

        void ShowAllComments();
    }
}
