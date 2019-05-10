using System;
using System.Data.SQLite;
using System.IO;


namespace Fake_D
{
    public class DataBase
    {
        public SQLiteConnection myConnection;
        public DataBase()
        {
            myConnection = new SQLiteConnection("Data Source=database.sqlite3");
            if (!File.Exists("./database.sqlite3"))
            {
                SQLiteConnection.CreateFile("database.sqlite3");
                Console.WriteLine("database created!");
            }
        }
    }
}
