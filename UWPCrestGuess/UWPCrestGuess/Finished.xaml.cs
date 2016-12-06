using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPCrestGuess
{
  
    public sealed partial class Finished : Page
    {
        public Finished()
        {
            this.InitializeComponent();
        }

        //Calling this method to prepare for page navigation
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var data = e.Parameter as SendData; //Sends data to Finished page to inform the user how they did
            txtPass.Text = $"Correct : {data.correctAnswer}/{data.totalQuestion}"; //Tells the user their score out of 20
            txtScore.Text = $"Score : {data.score}"; //Tells the user their score which would be out of 200
        }

        //When this button is clicked it sends the user back to the main page
        private void btnTryAgain_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
