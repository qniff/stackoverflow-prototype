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
    /// Interaction logic for NewAnswerControl.xaml
    /// </summary>
    public partial class NewAnswerControl : UserControl
    {
        private DataBaseHelper db;
        private int questionid;
        private int authorId;

        public NewAnswerControl(int questionId, int authorId)
        {
            InitializeComponent();
            db = new DataBaseHelper();
            this.questionid = questionId;
            this.authorId = authorId;
        }

        private void BtNewAnswer_Click(object sender, RoutedEventArgs e)
        {
            string text = tbNewAnswer.Text;
            if (!String.IsNullOrEmpty(text))
            {
                db.AddAnswer(authorId, questionid, text);
                AnswersWindow win = (AnswersWindow)Window.GetWindow(this);
                win.fillAnswers();
            }
        }
    }
}
