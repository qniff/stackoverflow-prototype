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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainApp
{
    /// <summary>
    /// Interaction logic for AnswerForm.xaml
    /// </summary>
    public partial class AnswerControl : UserControl
    {
        DataBaseHelper db;
        int answerId, userId;
        public AnswerControl(int answerId, string text, int authorId, DateTime date, int userId)
        {
            InitializeComponent();
            db = new DataBaseHelper();
            this.answerId = answerId;
            this.userId = userId;

            txtText.Text = text;
            lbAuthor.Content = db.getAuthor(authorId);
            lbDate.Content = date.ToString();
            fillComments();
        }

        public void fillComments()
        {
            stkComment.Children.Clear();
            List<Comment> comments = db.GetAnswerComments(answerId);
            foreach (Comment c in comments)
            {
                CommentControl commentForm = new CommentControl(c.Text, db.getAuthor(c.Author), c.Date);
                stkComment.Children.Add(commentForm);
            }
            stkComment.Children.Add(new NewCommentControl(-1, answerId, userId));
        }

    }
}
