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
    public partial class Profile : Form
    {
        private string UPI;
        public Profile(string upi)
        {
            UPI = upi;
            InitializeComponent();

            setTextBox(UPI);
        }

        public void setTextBox(string upi)
        {
            PeopleProfile profile = DatabaseQuery.GetProfile(upi);
            this.UpiTextBox.Text = upi;
            this.PasswordTextBox.Text = profile.Password;
            this.SurnameTextBox.Text = profile.Surname;
            this.FirstNameTextBox.Text = profile.FirstName;
            this.GenderTextBox.Text = profile.Gender;
            this.DOBTextBox.Text = profile.DateOfBirth;
            this.EmailTextBox.Text = profile.Email;
            this.PhoneNumTextBox.Text = profile.PhoneNum;

        }
    }
}
