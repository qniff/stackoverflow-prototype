using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PrototypeDemo
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

    }
}
