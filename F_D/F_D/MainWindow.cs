using System;
using Gtk;
using System.Data.SQLite;
//using System.Windows.Forms;
using System.Windows;

using F_D;

public partial class MainWindow : Gtk.Window
{

    public static SignupWindow signUpWin;
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

    public void Login_button(object sender, EventArgs e)
    {
        string s = combobox1.ActiveText;
        Console.WriteLine(s);
    }

    protected void Signup_btn(object sender, EventArgs e)
    {

        MainClass.win.Hide();

        signUpWin = new SignupWindow();
        signUpWin.Show();

        //MainWindow.signUpWin.Hide();
        //MainClass.win.Show();
    }
}
