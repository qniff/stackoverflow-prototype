using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    public class Question
    {
        public int QuestionId;
        public string Title;
        public string Desription;
        public int Author;
        public DateTime Date;

        public Question(int questionId, string title, string description, int author, DateTime date)
        {
            this.QuestionId = questionId;
            this.Title = title;
            this.Desription = description;
            this.Author = author;
            this.Date = date;
        }
    }
}