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
        string path;
        SQLiteConnection conn;

        public DBHelper()
        {

            path = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, "Database", "crestGuess.db");
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

        }


        public List<Question>getQuery()
        {
            var data = conn.Table<Question>();
            return data.ToList();
        }
        
    }
}
