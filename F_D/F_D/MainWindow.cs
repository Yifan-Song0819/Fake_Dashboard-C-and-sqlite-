using System;
using Gtk;
using System.Data.SQLite;
//using System.Windows.Forms;
using System.Windows;

using F_D;

public partial class MainWindow : Gtk.Window
{

    public static SignupWindow signUpWin;
    public static StuWindow studentWin;
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        //signUpWin.Hide();
        UpdateNames();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        //Application.Quit();
        Application.Quit();
        a.RetVal = true;
    }

    protected void UpdateNames()
    {
        label1.Text = "Welcome!";
        label4.Text = "Your Identity";
        label2.Text = "Username: ";
        label3.Text = "Password: ";
        button1.Label = "Log in";
        button3.Label = "Sign up";
        button2.Label = "Leave";
    }

    protected void Close_button(object sender, EventArgs e)
    {
        //closing the window
        Application.Quit();
    }


    protected Boolean check_empty(string s1, string s2)
    {
        if (String.IsNullOrEmpty(s1) || String.IsNullOrEmpty(s2))
        {
            Dialog dialog = new Dialog();
            dialog.Title = "Warning:";
            dialog.Modal = true;
            dialog.AllowGrow = true;
            dialog.AllowShrink = true;
            dialog.Modal = true;
            dialog.AddActionWidget(new Label("Username or password cannot be empty!"), ResponseType.Ok);
            dialog.AddActionWidget(new Button(Stock.Ok), ResponseType.Ok);
            dialog.SetPosition(WindowPosition.Center);
            //show and get response
            dialog.ShowAll();
            ResponseType response = (ResponseType)dialog.Run();
            dialog.Destroy();
            return false;
        }
        else
        {
            return true;
        }
    }

    protected Boolean check_in_db(string role, string user, string passwd)
    {
        db dataBaseOb = new db();
        dataBaseOb.myConnection.Open();
        SQLiteCommand a_command = dataBaseOb.myConnection.CreateCommand();
        a_command.CommandText = "select Password from People where UPI = @param1 and Identity = @param2";
        a_command.Parameters.Add(new SQLiteParameter("@param1", user));
        a_command.Parameters.Add(new SQLiteParameter("@param2", role));
        //int res = Int32.Parse(a_command.ExecuteScalar().ToString());
        string res = "";
        object a_ob = a_command.ExecuteScalar();
        if (a_ob == null)
        {
            Dialog dialog = new Dialog();
            dialog.Title = "Warning:";
            dialog.Modal = true;
            dialog.AllowGrow = true;
            dialog.AllowShrink = true;
            dialog.Modal = true;
            dialog.AddActionWidget(new Label("User does not exist or wrong role picked, try again please!"), ResponseType.Ok);
            dialog.AddActionWidget(new Button(Stock.Ok), ResponseType.Ok);
            dialog.SetPosition(WindowPosition.Center);
            //show and get response
            dialog.ShowAll();
            ResponseType response = (ResponseType)dialog.Run();
            dialog.Destroy();
            dataBaseOb.myConnection.Close();
            return false;
        }
        else
        {
            res = a_ob.ToString();
            //Console.WriteLine(res);
            if (res == passwd)
            {
                return true;
            }
            else
            {
                Dialog dialog = new Dialog();
                dialog.Title = "Warning:";
                dialog.Modal = true;
                dialog.AllowGrow = true;
                dialog.AllowShrink = true;
                dialog.Modal = true;
                dialog.AddActionWidget(new Label("Wrong password, try it again!"), ResponseType.Ok);
                dialog.AddActionWidget(new Button(Stock.Ok), ResponseType.Ok);
                dialog.SetPosition(WindowPosition.Center);
                //show and get response
                dialog.ShowAll();
                ResponseType response = (ResponseType)dialog.Run();
                dialog.Destroy();
                dataBaseOb.myConnection.Close();

                return false;
            }

        }
    }
    public void Login_button(object sender, EventArgs e)
    {
        //string s = combobox1.ActiveText;
        //Console.WriteLine(s);

        string role_pick = combobox1.ActiveText;
        string userName = entry1.Text;
        string passWd = entry2.Text;
        //Console.WriteLine(role_pick);
        //Console.WriteLine(userName);
        //Console.WriteLine(passWd);
        Boolean empty_user_pass = check_empty(userName, passWd);
        //Boolean user_paswd_db;
        if (empty_user_pass == true)
        {
            empty_user_pass = check_in_db(role_pick, userName, passWd);
            if (empty_user_pass == true)
            {
                MainClass.win.Destroy();
                studentWin = new StuWindow(userName);
                studentWin.SetPosition(WindowPosition.CenterAlways);
                studentWin.Show();
            }

        }
    }

    protected void Signup_btn(object sender, EventArgs e)
    {

        MainClass.win.Hide();

        signUpWin = new SignupWindow();
        signUpWin.SetPosition(WindowPosition.CenterAlways);
        signUpWin.Show();

        //MainWindow.signUpWin.Hide();
        //MainClass.win.Show();
    }
}
