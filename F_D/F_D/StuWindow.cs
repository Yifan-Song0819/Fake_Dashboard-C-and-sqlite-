using System;
using Gtk;
using System.Data.SQLite;
using System.Collections.Generic;// for List


namespace F_D
{
    public partial class StuWindow : Gtk.Window
    {
        public string user;
        public ListStore storeModel;
        public StuWindow(string user) :
                base(Gtk.WindowType.Toplevel)
        {
            this.user = user;
            this.Build();
            updateNames();
            HandleNodeView();

        }

        // we can parameterize the table and column names
        protected List<int> getData(string studentId, string target)
        {
            Console.WriteLine("hahaha");
            List<int> res = new List<int>();
            db dataBaseOb = new db();
            dataBaseOb.myConnection.Open();
            SQLiteCommand b_command = new SQLiteCommand("select " + target + " from StudentCourse where StudentID = @param2", dataBaseOb.myConnection);

            b_command.Parameters.Add(new SQLiteParameter("@param2", studentId));

            SQLiteDataReader reader_1 = b_command.ExecuteReader();
            while (reader_1.Read())
            {
                res.Add(reader_1.GetInt32(0));
            }

            //for (int i = 0; i < res.Count; i++)
            //{
            //    Console.WriteLine(res[i]);
            //}
            return res;
        }

        protected void updateNames()
        {
            label9.Text = "Welcome!";
            label10.Text = user;
            button11.Label = "check gpa";
            button12.Label = "OK";
        }

        protected void HandleNodeView()
        {
            treeview1.SetSizeRequest(450, 200);
            storeModel = new ListStore(typeof(string), typeof(string), typeof(string));
            var courseCol = new TreeViewColumn("Courses", new CellRendererText(), "text", 0);
            treeview1.AppendColumn(courseCol);
            var markCol = new TreeViewColumn("Mark", new CellRendererText(), "text", 1);
            treeview1.AppendColumn(markCol);
            var gradeCol = new TreeViewColumn("Grade", new CellRendererText(), "text", 2);
            treeview1.AppendColumn(gradeCol);

            courseCol.MaxWidth = 150;
            courseCol.MinWidth = 150;
            markCol.MaxWidth = 150;
            markCol.MinWidth = 150;
            gradeCol.MaxWidth = 150;
            gradeCol.MinWidth = 150;

            treeview1.Model = storeModel;
            Display_data();
        }

        protected void Display_data()
        {
            //string s1 = "cs350";
            //string s2 = "88";
            //string s3 = "A";
            //storeModel.AppendValues(s1 + s2, s2, s3);


            db dataBaseOb = new db();
            dataBaseOb.myConnection.Open();
            SQLiteCommand a_command = dataBaseOb.myConnection.CreateCommand();
            a_command.CommandText = "select StudentID from Student where UPI = @param1";
            a_command.Parameters.Add(new SQLiteParameter("@param1", user));
            //int res = Int32.Parse(a_command.ExecuteScalar().ToString());
            string studentId = "";
            object a_ob = a_command.ExecuteScalar();
            studentId = a_ob.ToString();

            dataBaseOb.myConnection.Close();

            //Console.WriteLine(studentId);




            //List<int> res = new List<int>();
            //SQLiteCommand b_command = dataBaseOb.myConnection.CreateCommand();
            //b_command.CommandText = "select CourseID from StudentCourse where StudentID = @param2";
            //b_command.Parameters.Add(new SQLiteParameter("@param2", studentId));
            //SQLiteDataReader reader_1 = b_command.ExecuteReader();
            //while (reader_1.Read())
            //{
            //    res.Add(reader_1.GetInt32(0));
            //}
            //Console.WriteLine("dfddddddd");
            //Console.WriteLine(res.Count);
            //for (int i = 0; i < res.Count; i++)
            //{
            //    Console.WriteLine(res[i]);
            //}


            //List<int> res = new List<int>();
            //string courseID = "CourseID";
            //SQLiteCommand b_command = new SQLiteCommand("select " + courseID + " from StudentCourse where StudentID = @param2", dataBaseOb.myConnection);
            //b_command.Parameters.Add(new SQLiteParameter("@param2", studentId));
            //SQLiteDataReader reader_1 = b_command.ExecuteReader();
            //while (reader_1.Read())
            //{
            //    res.Add(reader_1.GetInt32(0));
            //}
            //Console.WriteLine("dfddddddd");
            //Console.WriteLine(res.Count);
            //for (int i = 0; i < res.Count; i++)
            //{
            //    Console.WriteLine(res[i]);
            //}





            List<int> courseIdList = getData(studentId, "CourseID");
            Console.WriteLine("lmao");
            List<int> courseMarkList = getData(studentId, "CourseMark");
            List<int> gradeIdList = getData(studentId, "GradeID");


            //Console.WriteLine("courseIdList");
            //for (int i = 0; i < courseIdList.Count; i++)
            //{
            //    Console.WriteLine(courseIdList[i]);
            //}
            //Console.WriteLine("courseMarkList");
            //for (int i = 0; i < courseMarkList.Count; i++)
            //{
            //    Console.WriteLine(courseMarkList[i]);
            //}
            //Console.WriteLine("gradeIdList");
            //for (int i = 0; i < gradeIdList.Count; i++)
            //{
            //    Console.WriteLine(gradeIdList[i]);
            //}




        }
    }
}
