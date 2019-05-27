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
    public partial class Dean : Form
    {
        public Dean()
        {
            InitializeComponent();
            DatabaseQuery.showDataTable(this.DataTable1, "CS101");
        }

        private void Dean_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
