
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

namespace MainApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class BrowseWindow : Window
    {
        DataBaseHelper db;
        int userId;
        public BrowseWindow(int userId)
        {
            InitializeComponent();
            db = new DataBaseHelper();
            this.userId = userId;
            getQuestions();

            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer(); dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            getQuestions();
        }

        public void getQuestions()
        {
            stkMain.Children.Clear();
            List<Question> questions = db.GetQuestions();
            foreach(Question q in questions)
            {
                QuestionControl question = new QuestionControl(q.QuestionId, q.Title, q.Desription, q.Author, q.Date, userId);
                stkMain.Children.Add(question);
            }
            if (questions.Count() == 0) MessageBox.Show("There are not questions yet");
        }

    }
}