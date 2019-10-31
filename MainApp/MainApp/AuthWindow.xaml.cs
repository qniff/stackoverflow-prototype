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
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        DataBaseHelper db;
        public AuthWindow()
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
            
            if(inputOk(username) &&
                inputOk(password) &&
                inputOk(first) &&
                inputOk(last) &&
                inputOk(title) &&
                inputOk(description))
            {
                int userId = db.Register(username, password, first, last, title, description);
                if (userId != -1)
                {
                    ChoiceWindow main = new ChoiceWindow(userId);
                    this.Hide();
                    main.Show();
                    this.Close();
                }
            } else
            {
                MessageBox.Show("Fill all the fields");
            }

            
        }

        public bool inputOk(string text)
        {
            if (!String.IsNullOrEmpty(text) && !String.IsNullOrEmpty(text)) return true;
            return false;
        }

        private void BtLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = tbaUsername.Text;
            string password = tbaPassword.Password;

            if(db.Login(username, password))
            {
                ChoiceWindow main = new ChoiceWindow(db.GetUserId(username, password));
                this.Hide();
                main.Show();
                this.Close();
            }
        }
    }
}
