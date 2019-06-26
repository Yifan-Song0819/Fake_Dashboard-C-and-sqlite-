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
        public List<string> gradeLevelList;
        public static ChangeStuWindow ChangeSwin;
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
            //Console.WriteLine("hahaha");
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
            dataBaseOb.myConnection.Close();
            return res;


        }


        protected List<string> get_courseDetails(List<int> courseIdList)
        {
            List<string> res = new List<string>();
            db dataBaseOb = new db();
            dataBaseOb.myConnection.Open();
            for (int i = 0; i < courseIdList.Count; i++)
            {
                SQLiteCommand b_command = new SQLiteCommand("select CourseNum || ' ' || CourseDes from Course where CourseID = @param2", dataBaseOb.myConnection);
                b_command.Parameters.Add(new SQLiteParameter("@param2", courseIdList[i]));
                SQLiteDataReader reader_1 = b_command.ExecuteReader();
                while (reader_1.Read())
                {
                    res.Add(reader_1.GetString(0));
                }
            }
            dataBaseOb.myConnection.Close();
            return res;
        }

        protected List<string> get_grade_level(List<int> gradeIdList)
        {
            List<string> res = new List<string>();
            db dataBaseOb = new db();
            dataBaseOb.myConnection.Open();
            for (int i = 0; i < gradeIdList.Count; i++)
            {
                SQLiteCommand b_command = new SQLiteCommand("select GradeLevel from Grade where GradeID = @param2", dataBaseOb.myConnection);
                b_command.Parameters.Add(new SQLiteParameter("@param2", gradeIdList[i]));
                SQLiteDataReader reader_1 = b_command.ExecuteReader();
                while (reader_1.Read())
                {
                    res.Add(reader_1.GetString(0));
                }
            }
            dataBaseOb.myConnection.Close();
            return res;
        }


        protected void updateNames()
        {
            label9.Text = "Welcome!";
            label10.Text = user;
            button11.Label = "check gpa";
            button12.Label = "Close";
            button1.Label = "Change My Informations";
            label11.Hide();
        }

        protected void HandleNodeView()
        {
            treeview1.SetSizeRequest(550, 150);
            storeModel = new ListStore(typeof(string), typeof(string), typeof(string));
            var courseCol = new TreeViewColumn("Courses", new CellRendererText(), "text", 0);
            treeview1.AppendColumn(courseCol);
            var markCol = new TreeViewColumn("Mark", new CellRendererText(), "text", 1);
            treeview1.AppendColumn(markCol);
            var gradeCol = new TreeViewColumn("Grade", new CellRendererText(), "text", 2);
            treeview1.AppendColumn(gradeCol);

            courseCol.MaxWidth = 350;
            courseCol.MinWidth = 350;
            markCol.MaxWidth = 100;
            markCol.MinWidth = 100;
            gradeCol.MaxWidth = 100;
            gradeCol.MinWidth = 100;

            treeview1.Model = storeModel;
            Display_data();
        }

        protected void Display_data()
        {
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
            List<int> courseIdList = getData(studentId, "CourseID");
            //Console.WriteLine("lmao");
            List<int> courseMarkList = getData(studentId, "CourseMark");
            List<int> gradeIdList = getData(studentId, "GradeID");
            gradeLevelList = get_grade_level(gradeIdList);
            List<string> course_num_des = get_courseDetails(courseIdList);

            for(int i = 0; i < course_num_des.Count; i++)
            {
                storeModel.AppendValues(course_num_des[i], courseMarkList[i].ToString(), gradeLevelList[i]);
            }


        }

        protected void Close_button(object sender, EventArgs e)
        {
            MainWindow.studentWin.Destroy();
        }

        protected void Show_gpa(object sender, EventArgs e)
        {
            string[] grade = { "A+", "A", "A-", "B+", "B", "B-", "C+", "C", "C-", "D"};
            int[] gpa_point = { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };

            int gpa_total = 0;

            for (int i = 0; i< gradeLevelList.Count; i++)
            {
                //Console.WriteLine(gradeLevelList[i]);
                int a_index = Array.IndexOf(grade, gradeLevelList[i]);
                gpa_total += gpa_point[a_index];
            }

            //Console.WriteLine("=======");
            //Console.WriteLine(gradeLevelList.Count);
            if (gradeLevelList.Count == 0)
            {
                label11.Text = "You have not enrolled any papers!";
                label11.Show();
            }
            else
            {
                decimal gpa = (decimal)gpa_total / gradeLevelList.Count;

                decimal a_gpa = Math.Truncate(gpa * 100m) / 100m;
                label11.Text = "Your gpa is " + a_gpa.ToString();
                label11.Show();
            }
        }

        protected void change_profiles(object sender, EventArgs e)
        {
            MainWindow.studentWin.Hide();
            ChangeSwin = new ChangeStuWindow(user);
            ChangeSwin.Title = "Change Student Infos";
            ChangeSwin.SetPosition(WindowPosition.CenterAlways);
            ChangeSwin.Show();

        }
    }
}
