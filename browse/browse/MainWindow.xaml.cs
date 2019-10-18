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
using System.Data.SqlClient;

namespace browse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString = "server=localhost;" +
                                    "database=assignment;" +
                                    "user id=root;" +
                                    "password=pass;";
        public MainWindow()
        {
            InitializeComponent();
            getQuestions();
        }

        public void getQuestions()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "select * from dbo.question";
            using(SqlCommand cmd = new SqlCommand(query, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    string title = reader.GetString(1);
                    string description = reader.GetString(2);
                    question q = new question(title, description);
                    stkMain.Children.Add(q);
                }
            }
        }

    }
}
