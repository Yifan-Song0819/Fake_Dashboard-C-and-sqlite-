using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Gtk;
using System.Data.SQLite;
using F_D;

namespace F_D
{
    public partial class SignupWindow : Gtk.Window
    {
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

        protected void check_wrong_message(Boolean empty_user, Boolean same_passwd, Boolean checkEmail, Boolean checkPhone)
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

            if (empty_user == false && same_passwd == true && checkEmail == true && checkPhone == true)
            {
                MessageBox.Show("Sign up successful!");
            }
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


            string email = entry8.Text;
            string phoneNum = entry9.Text;
            Boolean checkEmail = check_email(email);
            Boolean checkPhone = check_phoneNum(phoneNum);

            //the value from combobox
            string f_c = combobox1.ActiveText;
            Console.WriteLine(f_c);

            //db dataBaseObject = new db();
            //dataBaseObject.myConnection.Open();
            //string sqlStatement = "insert into Course(CourseID, CourseNum, CourseDes) Values(100, '120', 22222)";
            //SQLiteCommand sqlCommand = new SQLiteCommand(sqlStatement);
            //sqlCommand.Connection = dataBaseObject.myConnection;
            //sqlCommand.ExecuteNonQuery();
            //dataBaseObject.myConnection.Close();




            check_wrong_message(empty_user, same_passwd, checkEmail, checkPhone);
        }


    }
}
