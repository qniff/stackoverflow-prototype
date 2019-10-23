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
        public AnswerForm(string text, string author, DateTime date)
        {
            InitializeComponent();
            txtText.Text = text;
            lbAuthor.Content = author;
            lbDate.Content = date.ToString();
        }
        public AnswerForm(string text, string author, DateTime date, List<Comment> comments)
        {
            InitializeComponent();
            txtText.Text = text;
            lbAuthor.Content = author;
            lbDate.Content = date.ToString();
        }

        private void BtnComment_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
