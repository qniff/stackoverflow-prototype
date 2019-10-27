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
    /// Interaction logic for QuestionControl.xaml
    /// </summary>
    public partial class QuestionControl : UserControl
    {
        private int QuestionId;
        private string Title;
        private string Desription;
        private int Author;
        private DateTime Date;
        private int userId;

        public QuestionControl(int questionId, string title, string description, int authorId, DateTime date, int userId)
        {
            InitializeComponent();
            lblTitle.Content = title;
            lblDescription.Content = description;
            this.QuestionId = questionId;
            this.Title = title;
            this.Desription = description;
            this.Author = authorId;
            this.userId = userId;
            this.Date = date;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AnswersWindow win = new AnswersWindow(this.QuestionId, userId);
            win.Show();
        }
    }
}
