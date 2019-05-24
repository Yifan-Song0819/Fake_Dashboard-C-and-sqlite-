using System;
using Gtk;

namespace F_D
{
    public partial class LecturerWindow : Gtk.Window
    {
        public string user;
        public LecturerWindow(string user) :
                base(Gtk.WindowType.Toplevel)
        {
            this.user = user;
            this.Build();
            test();
        }

        protected void test()
        {

        }
    }
}
