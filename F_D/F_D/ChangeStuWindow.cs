using System;
using Gtk;
using System.Data.SQLite;
using System.Collections.Generic;// for List
using System.Text.RegularExpressions; // for regex
//using System.Windows.Forms;

namespace F_D
{
    public partial class ChangeStuWindow : Gtk.Window
    {
        public string user;
        public List<string> previous_data_list;
        public ChangeStuWindow(string user) :
                base(Gtk.WindowType.Toplevel)
        {
            this.user = user;
            this.Build();
            UpdateNames();
            Select_previous_datas();
        }

        protected void UpdateNames()
        {
            label1.Text = "New Password";
            label2.Text = "Password again";
            label3.Text = "First Name";
            label4.Text = "Family Name";
            label5.Text = "Gender";
            label6.Text = "Date of Birth";
            label7.Text = "Email";
            label8.Text = "Phone Number";

            button1.Label = "Cancel";
            button2.Label = "Confirm";


            label9.Text = "Passwords cannot be different or empty, try again!";
            label9.Hide();
            label10.Text = "Wrong email format!";
            label10.Hide();
            label11.Text = "Phone number can only be numbers!";
            label11.Hide();

            //entry1.AppendText("123");
        }

        protected void Select_previous_datas()
        {
            previous_data_list = new List<string>();
            db dataBaseOb = new db();
            dataBaseOb.myConnection.Open();
            SQLiteCommand b_command = new SQLiteCommand("select Password,FirstName, SurName, Gender, DateOfBirth, Email, PhoneNum from People where UPI = @param2", dataBaseOb.myConnection);
            b_command.Parameters.Add(new SQLiteParameter("@param2", user));
            SQLiteDataReader reader_1 = b_command.ExecuteReader();

            while (reader_1.Read())
            {
                for(int c = 0; c < 7; c++)
                {
                    previous_data_list.Add(reader_1.GetString(c));
                }
            }
            dataBaseOb.myConnection.Close();

            Add_previous_datas();
            //for (int i = 0; i < res.Count; i++)
            //{
            //    Console.WriteLine(res[i]);
            //}
        }

        protected void Add_previous_datas()
        {
            entry1.Text = previous_data_list[0];
            entry2.Text = previous_data_list[0];
            entry3.Text = previous_data_list[1];
            entry4.Text = previous_data_list[2];
            entry5.Text = previous_data_list[3];
            entry6.Text = previous_data_list[4];
            entry7.Text = previous_data_list[5];
            entry8.Text = previous_data_list[6];
        }


        protected Boolean check_same_passwd(string pass1, string pass2)
        {
            if (pass1.Equals("") | pass2.Equals(""))
            {
                return false;
            }
            else if (!pass1.Equals(pass2))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected Boolean check_email(string email)
        {
            var regex = new Regex(@"^\S+@\S+");
            Boolean res = regex.IsMatch(email);
            return res;
        }

        protected Boolean check_phoneNum(string phone)
        {
            //The ^ will anchor the beginning of the string, 
            //the $ will anchor the end of the string.
            var regex = new Regex(@"^\d+$");
            Boolean res = regex.IsMatch(phone);
            return res;
        }

        protected void insert_new_values(People new_people)
        {
            db dataBaseOb = new db();
            dataBaseOb.myConnection.Open();
            string[] column_name = { "Password", "FirstName", "SurName", "Gender", "DateOfBirth", "Email", "PhoneNum" };
            for(int i = 1; i < 8; i++)
            {
                SQLiteCommand b_command = new SQLiteCommand("update People set " + column_name[i-1] + "=@param1 where UPI = @param2", dataBaseOb.myConnection);
                b_command.Parameters.Add(new SQLiteParameter("@param1", new_people.create_variables_array()[i]));
                b_command.Parameters.Add(new SQLiteParameter("@param2", user));
                b_command.ExecuteReader();
            }

            dataBaseOb.myConnection.Close();
        }

        protected void Confirm_changes(object sender, EventArgs e)
        {
            string passwd = entry1.Text;
            string rePasswd = entry2.Text;
            Boolean same_passwd = check_same_passwd(passwd, rePasswd);

            string email = entry7.Text;
            string phoneNum = entry8.Text;

            Boolean checkEmail = check_email(email);
            Boolean checkPhone = check_phoneNum(phoneNum);

            People new_people = new People(user, passwd);
            new_people.passwd = passwd;
            new_people.firstName = entry3.Text;
            new_people.familyName = entry4.Text;
            new_people.gender = entry5.Text;
            new_people.dob = entry6.Text;
            new_people.email = email;
            new_people.phone = phoneNum;

            string[] a_list = new_people.create_variables_array();


            //if user did not input anything, we set the variable to "NA"
            for (int i = 0; i < a_list.Length; i++)
            {
                if (String.IsNullOrEmpty(a_list[i]))
                {
                    a_list[i] = "NA";
                }
            }


            if (same_passwd == true && checkEmail == true && checkPhone == true)
            {
                label9.Hide();
                label10.Hide();
                label11.Hide();
                Console.WriteLine("do it");
                insert_new_values(new_people);

                Dialog dialog = new Dialog();
                dialog.Title = "Warning:";
                dialog.Modal = true;
                dialog.AllowGrow = true;
                dialog.AllowShrink = true;
                dialog.Modal = true;
                dialog.AddActionWidget(new Label("Info successfully changed"), ResponseType.Ok);
                dialog.AddActionWidget(new Button(Stock.Ok), ResponseType.Ok);
                dialog.SetPosition(WindowPosition.Center);
                //show and get response
                dialog.ShowAll();
                ResponseType response = (ResponseType)dialog.Run();
                dialog.Destroy();
            }

            else
            {
                if(same_passwd == false)
                {
                    label9.Show();
                }
                else
                {
                    label9.Hide();
                }
                if (checkEmail == false)
                {
                    label10.Show();
                }
                else
                {
                    label10.Hide();
                }
                if (checkPhone == false)
                {
                    label11.Show();
                }
                else
                {
                    label11.Hide();
                }
            }
        }

        protected void Go_back(object sender, EventArgs e)
        {
            StuWindow.ChangeSwin.Destroy();
            MainWindow.studentWin.Show();
        }
    }
}
