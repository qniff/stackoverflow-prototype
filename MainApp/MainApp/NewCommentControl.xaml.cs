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
    /// Interaction logic for NewCommentControl.xaml
    /// </summary>
    public partial class NewCommentControl : UserControl
    {
        DataBaseHelper db;
        private int questionId, answerId, authorId;
        public NewCommentControl(int questionId, int answerId, int authorId)
        {
            InitializeComponent();
            db = new DataBaseHelper();
            this.questionId = questionId;
            this.answerId = answerId;
            this.authorId = authorId;
        }

        private void BtNewComment_Click(object sender, RoutedEventArgs e)
        {
            string text = tbNewComment.Text;
            if (!String.IsNullOrEmpty(text))
            {
                db.AddComment(questionId, answerId, text, authorId);
                AnswersWindow win = (AnswersWindow)Window.GetWindow(this);
                win.fillQuestion();
                win.fillAnswers();
            }
        }
    }
}
