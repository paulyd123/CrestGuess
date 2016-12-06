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

## XAML Pages
The XAML pages is where the design occurs and the buttons etc. are set.

XAML Pages | Description
------------ | -------------
MainPage.xaml | This is the home page that is shown to the user when the application is opened. The MainPage consists of an image at the top where I have a random team crest. I then have the menu where the user is provided with the Play and Score Ranking options however as I have already explained I was unable to get the Score Ranking working.
Play.xaml | In this pag an image is loaded in at the top. This is the image that's shown to the user when they are answering the questions. Below this shows the user their score and the number of questions they have answerd out of 20. As the user answers the questions they wil see their score increase by 10 for every correct answer or stay the same if incorrect. Below that are the four buttons for the four possible answers.  
Finished.xaml | The user is navigated to the Finished page automatically when they have answered all 20 questions. This page consists of the users score which is out of 200 (20 questions and 10 points per correct answer) and the users score out of 20. I have also provided a button on the bottom of the page which allows the user to try again if they wish. If the Try Again button is clicked it directs the user back to the main page.

## C# Pages
These classes provide the backbone to the project, piecing everything together behind the scenes.

C# Classes | Description
------------ | -------------
MainPage.xaml.cs | This page contains the navigation fuction which is called when the user clicks play and they are then directed to the game.
Play.xaml.cs | This class is where most of the work happens. It gets and sets the data for the user to see their score as the game progresses. This is where the question develops in that it is where the question is created and where it s called to be shown. It's an informant to know whether or not to go onto another question or finish. Also in this class is the retrieval of images from the Assets folder.
Finished.xaml.cs | This is where the user is directed after they have answered the 20 questions. It provides te user with their score and number of correct answers. The Try Again button is also implemented here which directs the user back to the main page if they wish to have another go.
Question.cs | This is where the question is created. Getters and Setters for the ID, Image, four answers and the correct answer.
DBHelper.cs | Here is where the path and connection to the database is created. It then gets the information from the database for the question.

## Generate Query
I used Generate Query to generate a text file file randomising the names into 20 lists. This is also where I imported the images to use which I had saved on my device. The images are then converted to strings where it returns a list of names. I then created a hashset and randomised the names also making sure I would get the right answer in the four possible answers. I then created a query and generated it to create a text file. I copied everything from the text file and pasted it into the sql in the SQLite Browser to create the database.


## SQLite
I am using an SQLite database to get the names of the teams in random order.
There is only one table in the database named crestCuess.db

Table | Description
------------ | -------------
Question | This table has 5 fields: ID, Image, AnswerA, AnswerB, AnswerC, AnswerD and CorrectAnswer. I generated a query which randomised all the team names.

## SQLite User Guide
Installation guide on SQLite for the project on Visual Studio 2015:
- First you need to go to the SQLite download site at [https://www.sqlite.org/download.html](https://www.sqlite.org/download.html)
- Download SQLite for **Universal Windows Platform**
- Open up Visual Studio 2015
- The first thing you must do is add a reference to SQLite in your project
- Right click on the **References** tab in your project in **Solution Explorer** and then click **Add Reference**
- On the pop up window, navigate to the **Universal Windows section** on the left and click **Extensions** 
- Tick the **SQLite for Universal App platform** box, and also the **C++ Runtime 2015** then click **OK**
- In your project in solution explorer once again right click on the **References** folder and select **Manage Nuget Packages**
- Select **Browse** and then type the following into the search area: **SQLite.Net-PCL**
- You should see the package, then click **install**
- Thats it, SQLite is now installed into the project

## Problems Encountered
* I had various different problems throughout the course of this project. Firstly, I had originally planned to have an easy mode and a hard mode. However I ran into difficulty doing and then had to back track to just one level. This resulted in changing a lot of code which introduced more errors.
