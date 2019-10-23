using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeDemo
{
    public class Comment
    {
        public int CommentId;
        public int AnswerId;
        public int QuestionId;
        public string Text;
        public int Author;
        public DateTime Date;

        public Comment(int commentId, int answerId, int questionId, string text, int author, DateTime date)
        {
            this.CommentId = commentId;
            this.AnswerId = answerId;
            this.QuestionId = questionId;
            this.Text = text;
            this.Author = author;
            this.Date = date;
        }
    }
}
