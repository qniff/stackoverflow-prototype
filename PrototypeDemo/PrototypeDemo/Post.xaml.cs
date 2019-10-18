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
    /// Interaction logic for Post.xaml
    /// </summary>
    public partial class Post : UserControl
    {
        public Post(string title, string content, string theDate, string user)
        {
            InitializeComponent();
            lblUserName.Content = user;
            lblPostDate.Content = theDate;
            lblPostTitle.Content = title;
            txtContent.Text = content;
        }

        private void BtnComment_Click(object sender, RoutedEventArgs e)
        {
            Post p = new Post("Comment", "Test comment content", DateTime.Now.ToString(), "Comment user");
            stkComment.Children.Add(p);
        }
    }
}
