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

namespace PrototypeDemo
{
    /// <summary>
    /// Interaction logic for AnswerForm.xaml
    /// </summary>
    public partial class AnswerForm : UserControl
    {
        DataBaseHelper db;
        int answerId, authorId;
        public AnswerForm(int answerId, string text, int authorId, DateTime date)
        {
            InitializeComponent();
            db = new DataBaseHelper();
            this.answerId = answerId;
            this.authorId = authorId;

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
                CommentForm commentForm = new CommentForm(c.Text, db.getAuthor(c.Author), c.Date);
                stkComment.Children.Add(commentForm);
            }
            stkComment.Children.Add(new NewCommentForm(-1, answerId, authorId));
        }

    }
}
