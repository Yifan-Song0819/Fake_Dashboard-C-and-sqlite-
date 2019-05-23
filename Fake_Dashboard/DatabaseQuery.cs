using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Fake_Dashboard
{
    static class  DatabaseQuery
    {
        private static SQLiteConnection dbconnection = new SQLiteConnection("data source = Fake_Dashboard.db");
        public static void ConnectingDatabase()
        {
            //var dbconnection = new SQLiteConnection("data source = Fake_Dashboard.db");
            dbconnection.Open();
        }

        public static int Login(string upi, string password)
        {
            //dbconnection.Open();
            string sql = "SELECT UPI,Password,Identity FROM People";
            SQLiteCommand command = new SQLiteCommand(sql, dbconnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (upi == reader["UPI"].ToString() & password == reader["Password"].ToString())
                {
                    switch (reader["Identity"])
                    {
                        case "Student":
                            return 1;
                        case "Lecturer":
                            return 2;
                        case "Dean":
                            return 3;
                    }
                }
            }
            return 0;
        }
    }
}
