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
                            reader.Close();
                            return 1;
                        case "Lecturer":
                            reader.Close();
                            return 2;
                        case "Dean":
                            reader.Close();
                            return 3;
                    }
                }
            }
            reader.Close();
            return 0;
        }

        public static void ShowStudentDataTable(DataGridView dataview,string courseNum)
        {
            string sqlQuery = "SELECT p.UPI,S.StudentID,p.FirstName,p.SurName,sc.CourseMark FROM People p INNER JOIN Student s ON p.UPI = s.UPI INNER JOIN StudentCourse sc ON s.StudentID = sc.StudentID INNER JOIN Course c ON sc.CourseID = c.CourseID WHERE c.courseNum = '" + courseNum + "'";
            SQLiteDataAdapter mAdapter = new SQLiteDataAdapter(sqlQuery, dbconnection);
            //MessageBox.Show(mAdapter);
            DataTable dt = new DataTable();
            mAdapter.Fill(dt);
            dataview.DataSource = dt;

        }

        public static void ShowLecturerDataTable(DataGridView dataview, string courseNum)
        {
            string sqlQuery = "SELECT p.UPI,p.FirstName,p.SurName FROM People p INNER JOIN Lecturer l ON p.UPI = l.UPI INNER JOIN LecturerCourse lc ON l.LecturerID = lc.LecturerID INNER JOIN Course c ON lc.CourseID = c.CourseID WHERE c.courseNum = '" + courseNum + "'";
            SQLiteDataAdapter mAdapter = new SQLiteDataAdapter(sqlQuery, dbconnection);
            DataTable dt = new DataTable();
            mAdapter.Fill(dt);
            dataview.DataSource = dt;
        }

        public static void AddStudentToCourse(string upi, string courseNum)
        {

        }

        public static void SetCourseNumComboBox(ComboBox cb)
        {
            string sqlQuery = "SELECT CourseNum From Course;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, dbconnection);
            SQLiteDataReader reader = command.ExecuteReader();
            List<string> CourseNumList = new List<string>();
            while (reader.Read())
            {
                CourseNumList.Add(reader["CourseNum"].ToString());
            }
            cb.Items.AddRange(CourseNumList.ToArray());
            cb.Text = cb.Items[0].ToString();
            reader.Close();
        }

        public static void ShowCourseDataTable(DataGridView dataview, string upi)
        {
            string sqlQuery = "SELECT c.CourseNum, sc.CourseMark From StudentCourse sc INNER JOIN Student s on sc.StudentID = s.StudentID INNER JOIN Course c on sc.CourseID = c.CourseID WHERE s.UPI = '" + upi + "'";
            SQLiteDataAdapter mAdapter = new SQLiteDataAdapter(sqlQuery, dbconnection);
            DataTable dt = new DataTable();
            mAdapter.Fill(dt);
            dataview.DataSource = dt;
        }

        public static PeopleProfile GetProfile(string upi)
        {
            string sql = "SELECT * FROM People WHERE UPI = '" + upi + "'";
            SQLiteCommand command = new SQLiteCommand(sql, dbconnection);
            SQLiteDataReader reader = command.ExecuteReader();
            PeopleProfile profile = new PeopleProfile(upi);
            while (reader.Read())
            {
                MessageBox.Show("DATABASEREADER NO PROBLEM");
                profile.Password = reader["Password"].ToString();
                profile.FirstName = reader["FirstName"].ToString();
                profile.Surname = reader["Surname"].ToString();
                profile.Gender = reader["Gender"].ToString();
                profile.DateOfBirth = reader["DateOfBirth"].ToString();
                profile.Email = reader["Email"].ToString();
                profile.PhoneNum = reader["PhoneNum"].ToString();
            }
            return profile;
        }
    }
}
