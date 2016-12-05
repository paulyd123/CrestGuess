using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPCrestGuess.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPCrestGuess
{
    public class SendData
    {
        public int correctAnswer { get; set; }
        public int totalQuestion { get; set; }
        public int score { get; set; }
    }

    public sealed partial class Play : Page
    {
        List<Question> listQuestion = new List<Question>();
        DBHelper db;
        int index = 0;
        int score = 0;
        int correctAnswer = 0;
        int totalQuestion = 0;
        int thisQuestion = 1;


        public Play()
        {
            this.InitializeComponent();
            db = new DBHelper();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            listQuestion = db.getQuestion().OrderBy(s => Guid.NewGuid()).ToList();

            showQuestion(index);
        }

        private void btnAnswerA_Click(object sender, RoutedEventArgs e)
        {
            AnswerAccept(sender as Button);
        }

        private void btnAnswerB_Click(object sender, RoutedEventArgs e)
        {
            AnswerAccept(sender as Button);
        }

        private void btnAnswerC_Click(object sender, RoutedEventArgs e)
        {
            AnswerAccept(sender as Button);
        }

        private void btnAnswerD_Click(object sender, RoutedEventArgs e)
        {
            AnswerAccept(sender as Button);
        }


        public void AnswerAccept(Button btn)
        {
          
            if (btn.Content.Equals(listQuestion[index].CorrectAnswer))
            {
                score += 10; 
                correctAnswer++; 
                txtScore.Text = score.ToString();
            }

            thisQuestion++;
            index++;
            showQuestion(index); 

        }

        public void showQuestion(int index)
        {
            if(index < listQuestion.Count)
            {
                
                string imgUrl = "ms-appx:///Assets/crests/" + listQuestion[index].Image + ".jpg";
               
                imageLoad.Source = new BitmapImage(new Uri(imgUrl));

                answerA.Content = listQuestion[index].AnswerA;
                answerB.Content = listQuestion[index].AnswerB;
                answerC.Content = listQuestion[index].AnswerC;
                answerD.Content = listQuestion[index].AnswerD;

                txtNum.Text = $"{thisQuestion}/{totalQuestion}";
            }
            else
            {
                Frame.Navigate(typeof(Finished), new SendData() {correctAnswer = this.correctAnswer, totalQuestion = this.totalQuestion, score = this.score });
            }
            
        }

        private void answerA_Click(object sender, RoutedEventArgs e)
        {

        }

        private void answerB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void answerC_Click(object sender, RoutedEventArgs e)
        {

        }

        private void answerD_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
