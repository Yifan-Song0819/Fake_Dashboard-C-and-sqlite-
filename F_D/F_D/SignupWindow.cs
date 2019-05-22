using System;
using System.Text.RegularExpressions; 
using System.Windows.Forms;
using Gtk;
using System.Data.SQLite;
using F_D;
using System.Collections.Generic;

namespace F_D
{
    public partial class SignupWindow : Gtk.Window
    {
        //public static List<string> userList = new List<string>();
        public static Boolean duplicateUserName;
        public SignupWindow(): base(Gtk.WindowType.Toplevel)
        {
            Build();
            UpdateNames();
        }

        protected void UpdateNames()
        {
            //12 and 13 are used to username and passwd
            label12.Text = "The username cannot be empty!";
            label13.Text = "Passwords cannot be different or empty, try again!";
            label12.Hide();
            label13.Hide();

            //14 and 15 are used to email and phone
            label14.Text = "Wrong email format!";
            label15.Text = "Phone number can only be numbers!";
            label14.Hide();
            label15.Hide();

            label1.Text = "Sign Up";
            label2.Text = "Please choose your role:";
            label3.Text = "Username:";
            label4.Text = "Password:";
            label5.Text = "ReEnter your password:";
            label6.Text = "First Name:";
            label7.Text = "Family Name:";
            label8.Text = "Gender:";
            label9.Text = "Date of Birth:";
            label10.Text = "Email:";
            label11.Text = "Phone Number:";
            label16.Text = "D(2)/M(2)/Y(4)";
            radiobutton1.Label = "Dean";
            radiobutton2.Label = "Lecturer";
            radiobutton3.Label = "Student";
            button1.Label = "Cancel";
            button2.Label = "Sign up";
        }

        protected void Goback_btn(object sender, EventArgs e)
        {
            MainWindow.signUpWin.Destroy();
            MainClass.win.Show();
        }

        protected Boolean check_empty_user(string name)
        {
            return name.Equals("");
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

        //find the role user picked
        protected string find_role(Boolean b1, Boolean b2, Boolean b3)
        {
            string role_picked = "";
            int true_index = 0;
            Boolean[] pick_array = {b1, b2, b3};
            for (int i = 0; i < pick_array.Length; i++)
            {
                if (pick_array[i] == true)
                {
                    true_index = i;
                    break;
                }
            }
            string[] role_array = { "Dean", "Lecturer", "Student" };
            role_picked = role_array[true_index];
            return role_picked;
        }


        //check the wrong message and if not pop up the message box
        protected Boolean check_wrong_message(Boolean empty_user, Boolean same_passwd, Boolean checkEmail, Boolean checkPhone)
        {
            if (empty_user == true)
            {
                label12.Show();
            }
            else
            {
                label12.Hide();
            }

            if (same_passwd == false)
            {
                label13.Show();
            }
            else
            {
                label13.Hide();
            }

            if (checkEmail == false)
            {
                label14.Show();
            }
            else
            {
                label14.Hide();
            }

            if (checkPhone == false)
            {
                label15.Show();
            }
            else
            {
                label15.Hide();
            }

            if (empty_user == false && same_passwd == true && checkEmail == true && checkPhone == true && duplicateUserName == true)
            {
                //MessageBox.Show("Sign up successful!");
                return true;
            }
            else
            {
                return false;
            }
        }

        protected Boolean check_duplicate_username(string a_user)
        {
            List<string> userList = new List<string>();
            db dataBaseObject = new db();
            dataBaseObject.myConnection.Open();
            SQLiteCommand a_command = dataBaseObject.myConnection.CreateCommand();
            a_command.CommandText = "select UPI from People";
            SQLiteDataReader r = a_command.ExecuteReader();
            while (r.Read())
            {
                userList.Add(Convert.ToString(r["UPI"]));
            }
            dataBaseObject.myConnection.Close();
            //for (int i = 0; i < userList.Count; i++)
            //{
            //    Console.WriteLine(userList[i]);
            //}
            Boolean res = true;
            if (userList.Contains(a_user)){
                res = false;
            }
            return res;
        }


        protected void insert_into_people(People a_people)
        { 
            db dataBaseObject = new db();
            dataBaseObject.myConnection.Open();
            SQLiteCommand a_command = dataBaseObject.myConnection.CreateCommand();
            a_command.CommandText = "insert into People Values(@param1, @param2, @param3, @param4, @param5, @param6, @param7, @param8,  @param9)";
            a_command.Parameters.Add(new SQLiteParameter("@param1", a_people.UPI));
            a_command.Parameters.Add(new SQLiteParameter("@param2", a_people.passwd));
            a_command.Parameters.Add(new SQLiteParameter("@param3", a_people.firstName));
            a_command.Parameters.Add(new SQLiteParameter("@param4", a_people.familyName));
            a_command.Parameters.Add(new SQLiteParameter("@param5", a_people.gender));
            a_command.Parameters.Add(new SQLiteParameter("@param6", a_people.dob));
            a_command.Parameters.Add(new SQLiteParameter("@param7", a_people.email));
            a_command.Parameters.Add(new SQLiteParameter("@param8", a_people.phone));
            a_command.Parameters.Add(new SQLiteParameter("@param9", a_people.role));
            a_command.ExecuteNonQuery();
            dataBaseObject.myConnection.Close();

            // need to update the role table
            insert_into_role(a_people);
        }


        protected int find_the_max_id(People a_people)
        {

            string column_name = a_people.role + "ID";
            Console.WriteLine(column_name);
            db dataBaseObject = new db();
            dataBaseObject.myConnection.Open();
            SQLiteCommand a_command = dataBaseObject.myConnection.CreateCommand();

            if (a_people.role == "Dean")
            {
                a_command.CommandText = "select MAX(DeanID) from Dean";
            }
            else if(a_people.role == "Lecturer")
            {
                a_command.CommandText = "select MAX(LecturerID) from Lecturer";
            }
            else
            {
                a_command.CommandText = "select MAX(StudentID) from Student";
            }

            int res = Int32.Parse(a_command.ExecuteScalar().ToString());
            dataBaseObject.myConnection.Close();
            return res;

            //db dataBaseObject = new db();
            //dataBaseObject.myConnection.Open();
            //SQLiteCommand a_command = dataBaseObject.myConnection.CreateCommand();
            //a_command.CommandText = "select MAX(StudentID) from Student";
            //object val = a_command.ExecuteScalar();
            //int res = int.Parse(val.ToString());
            //dataBaseObject.myConnection.Close();
            //return res;
        }


        protected void insert_into_role(People a_people)
        {
            int max_id = find_the_max_id(a_people);
            Console.WriteLine(max_id);

            db dataBaseObject = new db();
            dataBaseObject.myConnection.Open();
            SQLiteCommand a_command = dataBaseObject.myConnection.CreateCommand();

            if (a_people.role == "Dean")
            {
                a_command.CommandText = "insert into Dean values(@param1, @param2)";
            }
            else if (a_people.role == "Lecturer")
            {
                a_command.CommandText = "insert into Lecturer values(@param1, @param2)";
            }
            else
            {
                a_command.CommandText = "insert into Student values(@param1, @param2)";
            }

            a_command.Parameters.Add(new SQLiteParameter("@param1", a_people.UPI));
            a_command.Parameters.Add(new SQLiteParameter("@param2", max_id + 1));
            a_command.ExecuteNonQuery();
            dataBaseObject.myConnection.Close();

        }


        protected void sign_up_people(string userName, string passwd, string firstName, string familyName, string gender, string dob, string email, string phoneNum, string role_picked)
        {


                People a_people = new People(userName, passwd, role_picked);
                a_people.firstName = firstName;
                a_people.familyName = familyName;
                a_people.gender = gender;
                a_people.dob = dob;
                a_people.email = email;
                a_people.phone = phoneNum;
                string[] a_list = a_people.create_variables_array();


                //if user did not input anything, we set the variable to "NA"
                for (int i = 0; i < a_list.Length; i++)
                {
                    if (String.IsNullOrEmpty(a_list[i]))
                    {
                        a_list[i] = "NA";
                    }
                }

                insert_into_people(a_people);
            

            //for(int i = 0; i<a_list.Length; i++)
            //{
            //    Console.WriteLine(a_list[i]);
            //}

        }

        protected void CreateAccount(object sender, EventArgs e)
        {

            Boolean dean_pick = radiobutton1.Active;
            Boolean lecturer_pick = radiobutton2.Active;
            Boolean student_pick = radiobutton3.Active;

            string role_picked = find_role(dean_pick, lecturer_pick, student_pick);
            //Console.WriteLine(role_picked);

            //check if name is empty
            string userName = entry1.Text;
            Boolean empty_user = check_empty_user(userName);


            //checking if two passwords are the same
            string passwd = entry2.Text;
            string rePasswd = entry3.Text;
            Boolean same_passwd = check_same_passwd(passwd, rePasswd);

            string firstName = entry4.Text;
            string familyName = entry5.Text;

            //the value from combobox
            string gender = combobox1.ActiveText;
            string dob = entry7.Text;

            string email = entry8.Text;
            string phoneNum = entry9.Text;
            Boolean checkEmail = check_email(email);
            Boolean checkPhone = check_phoneNum(phoneNum);



            duplicateUserName = check_duplicate_username(userName);
            if (duplicateUserName == false)
            {
                MessageBox.Show("Username already exists, try another one please!");
            }
            else
            {
                Boolean check_all = check_wrong_message(empty_user, same_passwd, checkEmail, checkPhone);
                //Console.WriteLine(check_all);
                if (check_all == true)
                {
                    sign_up_people(userName, passwd, firstName, familyName, gender, dob, email, phoneNum, role_picked);
                    MessageBox.Show("Sign up successful!");
                }
            }

            // worked
            //db dataBaseObject = new db();
            //dataBaseObject.myConnection.Open();
            //string sqlStatement = "insert into People(UPI, Password, Gender) Values('yson', '123', 'male')";
            //SQLiteCommand sqlCommand = new SQLiteCommand(sqlStatement);
            //sqlCommand.Connection = dataBaseObject.myConnection;
            //sqlCommand.ExecuteNonQuery();
            //dataBaseObject.myConnection.Close();
        }
    }
}
