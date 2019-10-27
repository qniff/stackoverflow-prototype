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
    /// Interaction logic for NewQuestionWindow.xaml
    /// </summary>
    public partial class NewQuestionWindow : Window
    {
        private DataBaseHelper db;
        private int authorId;

        public NewQuestionWindow(int userId)
        {
            InitializeComponent();
            db = new DataBaseHelper();
            this.authorId = userId;
        }
        private void btnSubmitQuestion_Click(object sender, RoutedEventArgs e)
        {
            string titleText = txtQuestionTitle.Text;
            string descriptionText = txtQuestionDescription.Text;

            if (!String.IsNullOrEmpty(titleText) && !String.IsNullOrEmpty(descriptionText))
            {
                db.AddQuestion(titleText, descriptionText, authorId);
                MessageBox.Show("Question added!");
                this.Close();
            }
        }

    }
}
