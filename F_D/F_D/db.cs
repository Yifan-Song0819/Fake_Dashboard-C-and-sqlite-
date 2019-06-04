using System;
using System.Data.SQLite;

//namespace F_D
//{
//    public class db
//    {
//        public SQLiteConnection myCon;
//        public db()
//        {
//            myCon = new SQLiteConnection("data source = Fake_Dashboard.db");
//        }
//    }
//}
namespace F_D
{
    public class db
    {
        public SQLiteConnection myConnection;
        public db()
        {
            myConnection = new SQLiteConnection("data source = Fake_Dashboard.db");
        }
    }
}
