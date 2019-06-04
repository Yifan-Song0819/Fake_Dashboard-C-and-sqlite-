using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fake_Dashboard
{
    public partial class Student : Form
    {
        public Student(string LoginUPI)
        {
            InitializeComponent();
            MessageBox.Show(LoginUPI);
            DatabaseQuery.ShowCourseDataTable(this.StudentDataTable, LoginUPI);
        }

        private void Student_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


    }
}
