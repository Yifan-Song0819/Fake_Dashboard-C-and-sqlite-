using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Fake_Dashboard
{
    public partial class DashBorad : Form
    {
        public DashBorad()
        {
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            var dbconnection = new SQLiteConnection("data source = Fake_Dashboard.db");
            dbconnection.Open();
            int upitemp = 123456;
            string passwordtemp = "123456";
            string sql = "SELECT UPI,Password FROM People";
            SQLiteCommand command = new SQLiteCommand(sql,dbconnection);
            SQLiteDataReader reader = command.ExecuteReader();
            bool a = false;
            while (reader.Read())
            {
                if(UPITextBox.Text == reader["UPI"].ToString() & PasswordTextBox.Text == reader["Password"].ToString())
                {
                    a = true;
                }
            }
            if ( a == false)
            {
                this.LoginDetailLabel.Visible = true;
            }
            else
            {
                MessageBox.Show("Welcome");
            }
        }
    }
}
