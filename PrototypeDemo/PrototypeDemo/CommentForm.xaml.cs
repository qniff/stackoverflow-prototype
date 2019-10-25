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
    /// Interaction logic for CommentForm.xaml
    /// </summary>
    public partial class CommentForm : UserControl
    {

        public CommentForm(string text, string author, DateTime date)
        {
            InitializeComponent();
            lbText.Content = text;
            lbAuthor.Content = author;
            lbDate.Content = date.ToString();
        }
    }
}
