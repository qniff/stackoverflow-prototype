using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MainApp
{
    public class DataBaseHelper
    {
        string connectionString = "server=localhost;" +
                                    "database=assignment;" +
                                    "user id=root;" +
                                    "password=pass;";
        SqlConnection conn;
        SqlCommand cmd;

        public DataBaseHelper()
        {
            conn = new SqlConnection(connectionString);
        }

        public Question GetQuestion(int questionId)
        {
            cmd = new SqlCommand($@"
            select * from question where questionid = @questionid", conn);
            cmd.Parameters.AddWithValue("@questionId", questionId);
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            Question q = null;
            while (rdr.Read())
            {
                string title = rdr["title"].ToString();
                string description = rdr["description"].ToString();
                int author = Convert.ToInt32(rdr["author"]);
                DateTime date = (DateTime)rdr["date"];
                q = new Question(questionId, title, description, author, date);
            }
            conn.Close();
            return q;
        }

        public string getAuthor(int authorId)
        {
            cmd = new SqlCommand($@"
            select firstName, lastName from [user] where userid = @authorid", conn);
            cmd.Parameters.AddWithValue("@authorId", authorId);
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            string name = null;
            while (rdr.Read())
            {
                name = rdr["firstName"].ToString() + " " + rdr["lastName"].ToString();
            }
            conn.Close();
            return name;
        }

        public List<Answer> GetAnswers(int questionId)
        {
            List<Answer> answers = new List<Answer>();
            cmd = new SqlCommand($@"
            select * from answer where questionid = @questionid", conn);
            cmd.Parameters.AddWithValue("@questionId", questionId);
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int answerId = Convert.ToInt32(rdr["answerId"]);
                string text = rdr["text"].ToString();
                int author = Convert.ToInt32(rdr["author"]);
                DateTime date = (DateTime)rdr["date"];
                Answer a = new Answer(answerId, questionId, text, author, date);
                answers.Add(a);
            }
            conn.Close();
            return answers;
        }

        public void AddAnswer(int authorId, int questionId, string text)
        {
            cmd = new SqlCommand($@"
            insert into answer (questionId, text, author, date)
            values (@questionId, @text, @author, GETDATE())", conn);
            cmd.Parameters.AddWithValue("@questionId", questionId);
            cmd.Parameters.AddWithValue("@author", authorId);
            cmd.Parameters.AddWithValue("@text", text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<Comment> GetQuestionComments(int questionId)
        {
            List<Comment> comments = new List<Comment>();
            cmd = new SqlCommand($@"
            select * from comment where questionid = @questionid and answerid = -1", conn);
            cmd.Parameters.AddWithValue("@questionId", questionId);
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int commentId = Convert.ToInt32(rdr["commentId"]);
                string text = rdr["text"].ToString();
                int author = Convert.ToInt32(rdr["author"]);
                DateTime date = (DateTime)rdr["date"];
                Comment c = new Comment(commentId, -1, questionId, text, author, date);
                comments.Add(c);
            }
            conn.Close();
            return comments;
        }

        public List<Comment> GetAnswerComments(int answerId)
        {
            List<Comment> comments = new List<Comment>();
            cmd = new SqlCommand($@"
            select * from comment where answerid = @answerid and questionid = -1", conn);
            cmd.Parameters.AddWithValue("@answerId", answerId);
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int commentId = Convert.ToInt32(rdr["commentId"]);
                string text = rdr["text"].ToString();
                int author = Convert.ToInt32(rdr["author"]);
                DateTime date = (DateTime)rdr["date"];
                Comment c = new Comment(commentId, answerId, -1, text, author, date);
                comments.Add(c);
            }
            conn.Close();
            return comments;
        }

        public List<Question> GetQuestions()
        {
            List<Question> questions = new List<Question>();
            cmd = new SqlCommand($@"
            select * from question", conn);
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int questionId = Convert.ToInt32(rdr["questionId"]);
                string title = rdr["title"].ToString();
                string description = rdr["description"].ToString();
                int author = Convert.ToInt32(rdr["author"]);
                DateTime date = (DateTime)rdr["date"];
                Question q = new Question(questionId, title, description, author, date);
                questions.Add(q);
            }
            conn.Close();
            return questions;
        }


        public void AddComment(int questionId, int answerId, string text, int authorId)
        {
            cmd = new SqlCommand($@"
            insert into comment (questionId, answerId, text, author, date)
            values (@questionId, @answerId, @text, @author, GETDATE())", conn);
            cmd.Parameters.AddWithValue("@questionId", questionId);
            cmd.Parameters.AddWithValue("@answerId", answerId);
            cmd.Parameters.AddWithValue("@text", text);
            cmd.Parameters.AddWithValue("@author", authorId);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void AddQuestion(string titleText, string descriptionText, int authorId)
        {
            cmd = new SqlCommand($@"
            insert into question (title, description, author, date)
            values (@titleText, @descriptionText, @authorId, GETDATE())", conn);
            cmd.Parameters.AddWithValue("@titleText", titleText);
            cmd.Parameters.AddWithValue("@descriptionText", descriptionText);
            cmd.Parameters.AddWithValue("@authorId", authorId);         
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public int GetUserId(string username, string password)
        {
            int userId = -1;
            cmd = new SqlCommand($@"
            select * from [user] where username = @username and password = @password", conn);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@username", username);
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                userId = Convert.ToInt32(rdr["userId"]);
            }
            conn.Close();
            return userId;

        }

        public int Register(string username, string password, string first, string last, string title, string description)
        {
            if (this.Login(username, password)) return -1;
            cmd = new SqlCommand($@"
            insert into [user] (firstName, lastName, title, description, username, password)
            values (@first, @last, @title, @description, @username, @password)", conn);
            cmd.Parameters.AddWithValue("@first", first);
            cmd.Parameters.AddWithValue("@last", last);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            return this.GetUserId(username, password);
        }

        public bool Login(string username, string password)
        {
            bool ret = false;
            cmd = new SqlCommand($@"
            select * from [user] where username = @username and password = @password", conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read()) ret = true;
            conn.Close();
            return ret;
        }
    }
}