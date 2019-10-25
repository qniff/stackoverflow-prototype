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

namespace PrototypeDemo
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        DataBaseHelper db;
        public Login()
        {
            InitializeComponent();
            db = new DataBaseHelper();
        }

        private void BtRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = tbrUsername.Text;
            string password = tbrPassword.Text;
            string first = tbrFirst.Text;
            string last = tbrLast.Text;
            string title = tbrTitle.Text;
            string description = tbrDescription.Text;
            db.Register(username, password, first, last, title, description);
            MainWindow main = new MainWindow();
        }
    }
}
