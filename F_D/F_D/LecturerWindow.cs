using System;
using Gtk;
using System.Data.SQLite;
using System.Collections.Generic;

namespace F_D
{
    public partial class LecturerWindow : Gtk.Window
    {
        public string user;
        public ListStore storeModel;
        public LecturerWindow(string user) :
                base(Gtk.WindowType.Toplevel)
        {
            this.user = user;
            this.Build();
            updateNames();
            //test();
            create_nodes();
        }

        protected void updateNames()
        {
            label1.Text = "Welcome!";
            label2.Text = user;
        }

        protected void create_nodes()
        {

            nodeview2.SetSizeRequest(600, 200);
            storeModel = new ListStore(typeof(string), typeof(string), typeof(string));
            var courseCol = new TreeViewColumn("Courses", new CellRendererText(), "text", 0);
            nodeview2.AppendColumn(courseCol);
            //var markCol = new TreeViewColumn("Mark", new CellRendererText(), "text", 1);
            //nodeview2.AppendColumn(markCol);
            //var gradeCol = new TreeViewColumn("Grade", new CellRendererText(), "text", 2);
            //nodeview2.AppendColumn(gradeCol);

            courseCol.MaxWidth = 350;
            courseCol.MinWidth = 350;
            //markCol.MaxWidth = 100;
            //markCol.MinWidth = 100;
            //gradeCol.MaxWidth = 100;
            //gradeCol.MinWidth = 100;

            nodeview2.Model = storeModel;
            storeModel.AppendValues("cs335");
        }


        

        protected int get_lecturer_id(string user)
        {
            db dataBaseOb = new db();
            dataBaseOb.myConnection.Open();
            SQLiteCommand a_command = dataBaseOb.myConnection.CreateCommand();
            a_command.CommandText = "select LecturerID from Lecturer where UPI = @param1";
            a_command.Parameters.Add(new SQLiteParameter("@param1", user));
            //int res = Int32.Parse(a_command.ExecuteScalar().ToString());
            int res = 0;
            object a_ob = a_command.ExecuteScalar();
            if (a_ob == null)
            {
                Dialog dialog = new Dialog();
                dialog.Title = "Warning:";
                dialog.Modal = true;
                dialog.AllowGrow = true;
                dialog.AllowShrink = true;
                dialog.Modal = true;
                dialog.AddActionWidget(new Label("You are not lecturing any papers!"), ResponseType.Ok);
                dialog.AddActionWidget(new Button(Stock.Ok), ResponseType.Ok);
                dialog.SetPosition(WindowPosition.Center);
                //show and get response
                dialog.ShowAll();
                ResponseType response = (ResponseType)dialog.Run();
                dialog.Destroy();
            }
            else
            {
                res = Convert.ToInt32(a_ob);
            }
            dataBaseOb.myConnection.Close();
            return res;

        }

        protected List<int> get_papers_id(int lId)
        {
            List<int> res = new List<int>();
            db dataBaseOb = new db();
            dataBaseOb.myConnection.Open();
            SQLiteCommand b_command = new SQLiteCommand("select CourseID from LecturerCourse where LecturerID = @param2", dataBaseOb.myConnection);
            b_command.Parameters.Add(new SQLiteParameter("@param2", lId));
            SQLiteDataReader reader_1 = b_command.ExecuteReader();

            while (reader_1.Read())
            {
                res.Add(Int32.Parse(Convert.ToString(reader_1["CourseID"])));
            }
            dataBaseOb.myConnection.Close();
            return res;
        }

        protected string get_paper_detail(int courseId)
        {
            string res = "";
            db dataBaseOb = new db();
            dataBaseOb.myConnection.Open();
            SQLiteCommand b_command = new SQLiteCommand("select CourseNum, CourseDes from Course where CourseID = @param2", dataBaseOb.myConnection);
            b_command.Parameters.Add(new SQLiteParameter("@param2", courseId));
            SQLiteDataReader reader_1 = b_command.ExecuteReader();

            while (reader_1.Read())
            {
                res = Convert.ToString(reader_1["CourseNum"]) + " " + Convert.ToString(reader_1["CourseDes"]);
            }
            dataBaseOb.myConnection.Close();

            return res;
        }



        protected void paper_button(object sender, EventArgs e)
        {
            Console.WriteLine();
        }

        // show the papers what the lecturer in charge

    }
}
