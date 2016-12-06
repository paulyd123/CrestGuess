using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPCrestGuess.Model
{
    public class DBHelper
    {
        //Variables
        string path;
        //Initializing SQLite connection
        SQLiteConnection conn;


        public DBHelper()
        {
            //Creating a path for the database
            path = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, "Database", "crestGuess.db");
            //Creating the database connection
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

        }

        //This function gets the query from the database where I have made a table named Question
        public List<Question>getQuery()
        {
            //Creates the variable 'data' to get the information from the Question table in crestGuess.db
            var data = conn.Table<Question>();
            //Retruns information to list for questions
            return data.ToList(); 
        }
        
    }
}
