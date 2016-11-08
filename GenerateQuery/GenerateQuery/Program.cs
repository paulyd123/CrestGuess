using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GenerateQuery
{
    class Program
    {
        //For Android
        public static string ConvertToUnsign(string str)
        {
            Regex regex = new Regex("\\p(IsCombiningDiacriticalMarks)+");
            string temp = str.Normalize(System.Text.NormalizationForm.FormD);
            return regex.Replace(temp, string.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        
        //Funtion to get all file names of crests
        public static List<string> getListClubCrests()
        {
            DirectoryInfo d = new DirectoryInfo(@"C:\Users\g0029\Documents\Visual Studio 2015\Projects\Crests\clubCrests"); //Reaching out to directory with club crests
            FileInfo[] files = d.GetFiles("*.jpg");
            List<string> lstNames = new List<string>();

            foreach (var file in files) //Foreach file in the above directory
            {
                //This line renames all upper file names to lower file names
                //Android Drawable Resource can't contains "'" and "-" character
                File.Move(file.FullName, ConvertToUnsign(file.FullName.ToLower().Replace("'", String.Empty).Replace("-", String.Empty)));
                lstNames.Add(file.Name.Replace("*.jpg", String.Empty)); //Liverpool.png -> Liverpool
            }
                return lstNames;
        }

        //Function to get random club name from list without duplication
        private static List<string> getRandomName(string name, List<string> lstNames)
        {
            HashSet<string> myHashSet = new HashSet<string>();
            myHashSet.Add(name); //First add name then randomise other names without duplicating 
            while (myHashSet.Count < 4) //4 names are needed for 4 answers 
            {
                myHashSet.Add(lstNames.OrderBy(s => Guid.NewGuid()).First()); //Add random name to Hashset
            }
            return myHashSet.OrderBy(s => Guid.NewGuid()).ToList(); //Randomise all answers
        }

        //Function to generate query INSERT_INTO for crreating database question
        private static async Task generateQuery()
        {
            List<string> lstQuery = new List<string>();
            List<string> lstClubCrestName = getListClubCrests();
            String query = String.Empty;
            foreach (var name in lstClubCrestName)
            {

                List<string> answerList = getRandomName(name, lstClubCrestName);


                //With one value in lstClubCrestName we create one
                //question with 4 possible answers and one being the right answer
                //Ex
                //INSERT INTO Question(Image, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswer)
                //VALUES('Liverpool', 'Manchester City', 'Arsenal', 'Chelsea')

                query = "INSERT INTO Question(Image, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswer)"
                    + $"VALUES(\"{name}\",\"{answerList[0]}\",\"{answerList[1]}\",\"{answerList[2]}\",\"{answerList[3]}\",\"{name}\");";

                lstQuery.Add(query); //To add query we just create the list
            }
            System.IO.File.WriteAllLines(@".//QueryGenerate.txt", lstQuery); //Write all to file
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Tool Generate Query");
            Console.WriteLine("Please wait..");
            generateQuery();
            Console.WriteLine("Success..");
            Console.ReadKey();
        }
    }
}