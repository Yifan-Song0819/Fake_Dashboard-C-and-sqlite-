using System;

namespace F_D
{
    public class People
    {
        public string UPI { get; set; }
        public string passwd { get; set; }
        public string firstName { get; set; }
        public string familyName { get; set; }
        public string gender { get; set; }
        public string dob { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string role { get; set; }
        public People(string UPI, string passwd, string role)
        {
            this.UPI = UPI;
            this.passwd = passwd;
            this.role = role;
        }


        //used to loop all the instance variables
        public string[] create_variables_array()
        {
            string[] a_list = new string[9];
            a_list[0] = this.UPI;
            a_list[1] = this.passwd;
            a_list[2] = this.firstName;
            a_list[3] = this.familyName;
            a_list[4] = this.gender;
            a_list[5] = this.dob;
            a_list[6] = this.email;
            a_list[7] = this.phone;
            a_list[8] = this.role;
            return a_list;
        }
    }
}
