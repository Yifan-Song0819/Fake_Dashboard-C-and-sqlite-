using System;
using Gtk;
using System.Data.SQLite;

namespace Fake_D
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Application.Init();
            MainWindow win = new MainWindow();
            win.Show();
            Application.Run();


            DataBase dataBaseObject = new DataBase();
            dataBaseObject.myConnection.Open();


            string myInsertQuery = "INSERT INTO Dean VALUES ('yson','188')";
            SQLiteCommand sqCommand = new SQLiteCommand(myInsertQuery);
            sqCommand.Connection = dataBaseObject.myConnection;
            sqCommand.ExecuteNonQuery();
            dataBaseObject.myConnection.Close();
            Console.ReadKey();
        }
    }
}
