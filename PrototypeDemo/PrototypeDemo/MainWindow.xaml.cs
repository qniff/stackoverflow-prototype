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
using System.Timers;
using System.Threading;

namespace PrototypeDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int authorId;
        private int questionId;
        private DataBaseHelper db;
        public MainWindow()
        {
            InitializeComponent();
            db = new DataBaseHelper();
            this.questionId = 1;
            this.authorId = 1;
            fillQuestion();
            fillAnswers();
        }

        public void fillQuestion()
        {
            Question q = db.GetQuestion(questionId);
            lbTitle.Content = q.Title;
            this.Title += ": " + q.Title;
            lbDescription.Content = q.Desription;
            lbAuthor.Content = db.getAuthor(q.Author);
            lbDate.Content = q.Date.ToString();
        }

        public void fillAnswers()
        {
            stkAnswers.Children.Clear();
            List<Answer> answers = db.GetAnswers(questionId);
            foreach (Answer a in answers)
            {
                AnswerForm answerForm = new AnswerForm(a.Text, db.getAuthor(a.Author), a.Date);
                stkAnswers.Children.Add(answerForm);
            }
            stkAnswers.Children.Add(new NewAnswerForm(questionId, authorId));
        }


    }
    }

