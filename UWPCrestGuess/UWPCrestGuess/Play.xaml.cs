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
    //Sends data 
    public class SendData
    {
        public int correctAnswer { get; set; } //Sets correct answer
        public int totalQuestion { get; set; } //Sets total number of questions
        public int score { get; set; } //Sets score
    }

    public sealed partial class Play : Page
    {
        List<Question> listQuestion = new List<Question>(); //List question
        DBHelper db; //Database helper
        //Setting variables
        int index = 0;
        int score = 0;
        int correctAnswer = 0;
        int totalQuestion = 20;
        int thisQuestion = 1;

        public Play()
        {
            this.InitializeComponent();
            db = new DBHelper(); //Initializing database
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            //Get Question from database
            listQuestion = db.getQuery().OrderBy(s => Guid.NewGuid()).ToList();

            //Show first question
            showQuestion(index);
        }

        //Function to check answer
        public void AnswerAccept(Button btn)
        {

            //If user provides correct answer
            if (btn.Content.Equals(listQuestion[index].CorrectAnswer))
            {
                score += 10; //Score increases by 10
                correctAnswer++; //Correct answers increases by 1
                txtScore.Text = score.ToString(); //Adds score to string for end of game
            }

            thisQuestion++; //Next question
            index++;
            showQuestion(index); //Show next question/crest

        }

        //Function to show question
        public void showQuestion(int index)
        {
            //If the the question number is greater than the index it tells it to go to the next question
            if (index < listQuestion.Count)
            {
                //Retrieving the images from the Assets folder, getting image url
                string imgUrl = "ms-appx:///Assets/crests/" + listQuestion[index].Image;
                //Adds image to image control
                imageLoad.Source = new BitmapImage(new Uri(imgUrl));

                //Sets content of button to data from listQuestion
                answerA.Content = listQuestion[index].AnswerA;
                answerB.Content = listQuestion[index].AnswerB;
                answerC.Content = listQuestion[index].AnswerC;
                answerD.Content = listQuestion[index].AnswerD;

                //Sets status of question
                txtNum.Text = $"{thisQuestion}/{totalQuestion}";//Interpolated string
            }
            else //if index > totalQuestion -> The 20 questions have been answered
            {
                //Navigate to Finished page and send result
                Frame.Navigate(typeof(Finished), new SendData() { correctAnswer = this.correctAnswer, totalQuestion = this.totalQuestion, score = this.score });
            }

        }

        //Function to accept answer when button is clicked
        private void answerA_Click(object sender, RoutedEventArgs e)
        {
            AnswerAccept(sender as Button); //'as' is a sort of cast method
        }

        //Function to accept answer when button is clicked
        private void answerB_Click(object sender, RoutedEventArgs e)
        {
            AnswerAccept(sender as Button);
        }

        //Function to accept answer when button is clicked
        private void answerC_Click(object sender, RoutedEventArgs e)
        {
            AnswerAccept(sender as Button);
        }

        //Function to accept answer when button is clicked
        private void answerD_Click(object sender, RoutedEventArgs e)
        {
            AnswerAccept(sender as Button);
        }
    }
}
