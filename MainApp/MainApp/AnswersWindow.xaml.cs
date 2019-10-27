using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MainApp
{
    /// <summary>
    /// Interaction logic for AnswersWindow.xaml
    /// </summary>
    public partial class AnswersWindow : Window
    {
        private int userId;
        private int questionId;
        private DataBaseHelper db;
        public AnswersWindow(int questionId, int userId)
        {
            InitializeComponent();
            db = new DataBaseHelper();
            this.questionId = questionId;
            this.userId = userId;
            fillQuestion();
            fillAnswers();
        }

        public void fillQuestion()
        {
            try
            {
                Question q = db.GetQuestion(questionId);
                lbTitle.Content = q.Title;
                this.Title += ": " + q.Title;
                lbDescription.Content = q.Desription;
                lbAuthor.Content = db.getAuthor(q.Author);
                lbDate.Content = q.Date.ToString();
                fillQuestionComments();
            }
            catch (Exception)
            {
                MessageBox.Show("There are not questions yet");
            }

        }

        public void fillAnswers()
        {
            stkAnswers.Children.Clear();
            List<Answer> answers = db.GetAnswers(questionId);
            foreach (Answer a in answers)
            {
                AnswerControl answerForm = new AnswerControl(a.AnswerId, a.Text, a.Author, a.Date, userId);
                stkAnswers.Children.Add(answerForm);
            }
            stkAnswers.Children.Add(new NewAnswerControl(questionId, userId));
        }

        public void fillQuestionComments()
        {
            stkComments.Children.Clear();
            List<Comment> comments = db.GetQuestionComments(questionId);
            foreach (Comment c in comments)
            {
                CommentControl commentForm = new CommentControl(c.Text, db.getAuthor(c.Author), c.Date);
                stkComments.Children.Add(commentForm);
            }
            stkComments.Children.Add(new NewCommentControl(questionId, -1, userId));
        }
    }
}
