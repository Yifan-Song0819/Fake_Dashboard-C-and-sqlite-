using System;
using Gtk;
using System.Data.SQLite;
using System.Collections.Generic;

namespace F_D
{
    public partial class LecturerWindow : Gtk.Window
    {
        public string user;
        public LecturerWindow(string user) :
                base(Gtk.WindowType.Toplevel)
        {
            this.user = user;
            this.Build();

            Show_papers();
            //test();
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

        // show the papers what the lecturer in charge
        protected void Show_papers()
        {
            int lecturerID = get_lecturer_id(user);
            //Console.WriteLine(lecturerID);
            List<int> papersID = new List<int>();
            papersID = get_papers_id(lecturerID);
            for(int i = 0; i < papersID.Count; i++)
            {
                Console.WriteLine(papersID[i]);
            }

        }


        protected void test()
        {
            int x = 100;

            for (int i = 1; i < 4; i++)
            {
                Button abtn = new Button("lol");
                abtn.SetSizeRequest(100, 100);
                abtn.SetUposition(x, 100);
                abtn.Clicked += new EventHandler(test_btn);
                this.fixed1.Add(abtn);
                abtn.Show();
                x = x + 200;
            }


        }

        protected void test_btn(object sender, EventArgs e)
        {
            Console.WriteLine("new one!!!!");
        }

    }
}
