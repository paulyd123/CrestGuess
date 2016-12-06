# CrestGuess
A game where the user is given the crest of a soccer club and is given 4 possible answers and must choose one

**Name:** Paul Dolan    
**Student Number:** G00297086    
**Lecturer:** Martin Kenirons    
**Module:** Mobile Applications Development    
**Year:** Fourth Year    
**Course:** Software Development    

## Introduction
This is a Universal Windows Project called CrestGuess. The aim of this game is to guess as many club crests as you can. I stored the team names locally on an SQLite database which retrieves the names at random. You are given the crest of a football team with the name of the team on the crest erased. There are four possible answers with one being the correct answer. For every correct answer the user receives a score of 10 and if the answer is incorrect the user is moved onto the next question. There are 20 questions and 20 different crests. On the start up page you are given two pages, Play and Score Ranking. Unfortunately I was unable to get the Score Ranking working properly however I left the button in there to show you what I had intended to do. It was my intention to post the scores up onto the database. When the Play button is pressed the user is then sent to the game. When the user has answered the 20 question they are then directed to another page to inform them of their score and correct answers out of 20.

XAML Pages | Description
------------ | -------------
MainPage.xaml | This is the home page that is shown to the user when the application is opened. The MainPage consists of an image at the top where I have a random team crest. I then have the menu where the user is provided with the Play and Score Ranking options however as I have already explained I was unable to get the Score Ranking working.
Play.xaml | In this pag an image is loaded in at the top. This is the image that's shown to the user when they are answering the questions. Below this shows the user their score and the number of questions they have answerd out of 20. As the user answers the questions they wil see their score increase by 10 for every correct answer or stay the same if incorrect. Below that are the four buttons for the four possible answers.  
Finished.xaml | The user is navigated to the Finished page automatically when they have answered all 20 questions. This page consists of the users score which is out of 200 (20 questions and 10 points per correct answer) and the users score out of 20. I have also provided a button on the bottom of the page which allows the user to try again if they wish. If the Try Again button is clicked it directs the user back to the main page.

C# Classes | Description
------------ | -------------
MainPage.xaml.cs | This page contains the navigation fuction which is called when the user clicks play and they are then directed to the game.
Play.xaml.cs | This class is where most of the work happens. It gets and sets the data for the user to see their score as the game progresses. This is where the question develops in that it is where the question is created and where it s called to be shown. It's an informant to know whether or not to go onto another question or finish. Also in this class is the retrieval of images from the Assets folder.
Finished.xaml.cs | This is where the user is directed after they have answered the 20 questions. It provides te user with their score and number of correct answers. The Try Again button is also implemented here which directs the user back to the main page if they wish to have another go.
Question.cs | This is where the question is created. Getters and Setters for the ID, Image, four answers and the correct answer.
DBHelper.cs | Here is where the path and connection to the database is created. It then gets the information from the database for the question.


