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
    /// Interaction logic for NewQuestionForm.xaml
    /// </summary>
    public partial class NewQuestionForm : UserControl
    {
        private DataBaseHelper db;
        private int questionId = 1;
        private int authorId = 1;

        public NewQuestionForm()
        {
            InitializeComponent();
            db = new DataBaseHelper();
        }
        private void btnSubmitQuestion_Click(object sender, RoutedEventArgs e)
        {
            string titleText = txtQuestionTitle.Text;
            string descriptionText = txtQuestionDescription.Text;

            if (!String.IsNullOrEmpty(titleText) && !String.IsNullOrEmpty(descriptionText))
            {
                db.AddQuestion(questionId, authorId, titleText, descriptionText);
                MainWindow win = (MainWindow)Window.GetWindow(this);
                win.fillQuestion();
            }  
        }
    }
}
