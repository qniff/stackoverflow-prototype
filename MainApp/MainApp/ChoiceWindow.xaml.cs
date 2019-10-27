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
    /// Interaction logic for ChoiceWindow.xaml
    /// </summary>
    public partial class ChoiceWindow : Window
    {
        DataBaseHelper db;
        private int userId;
        public ChoiceWindow(int userId)
        {
            InitializeComponent();
            db = new DataBaseHelper();
            this.userId = userId;
            this.Title = db.getAuthor(userId);
        }

        private void BtAsk_Click(object sender, RoutedEventArgs e)
        {
            NewQuestionWindow win = new NewQuestionWindow(userId);
            win.Show();
        }

        private void BtBrowse_Click(object sender, RoutedEventArgs e)
        {
            BrowseWindow win = new BrowseWindow(userId);
            win.Show();
        }
    }
}
