using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeDemo
{
    public class Answer
    {
        public int AnswerId;
        public int QuestionId;
        public string Text;
        public int Author;
        public DateTime Date;

        public Answer(int answerId, int questionId, string text, int author, DateTime date)
        {
            this.AnswerId = answerId;
            this.QuestionId = questionId;
            this.Text = text;
            this.Author = author;
            this.Date = date;
        }
    }
}
