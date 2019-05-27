using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data;

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

        public static void showDataTable(DataGridView dataview,string courseNum)
        {
            string sqlQuery = "SELECT p.UPI,S.StudentID,p.FirstName,p.SurName,sc.CourseMark FROM People p INNER JOIN Student s ON p.UPI = s.UPI INNER JOIN StudentCourse sc ON s.StudentID = sc.StudentID INNER JOIN Course c ON sc.CourseID = c.CourseID WHERE c.courseNum = '" + courseNum + "'";
            SQLiteDataAdapter mAdapter = new SQLiteDataAdapter(sqlQuery, dbconnection);
            //MessageBox.Show(mAdapter);
            DataTable dt = new DataTable();
            mAdapter.Fill(dt);
            dataview.DataSource = dt;

        }
    }
}
