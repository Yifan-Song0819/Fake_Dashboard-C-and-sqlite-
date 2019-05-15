using System;
using Gtk;
using F_D;



namespace F_D
{
    public partial class StudentWindow : Gtk.Window
    {
        public StudentWindow() : base(Gtk.WindowType.Toplevel)
        //[Obsolete]
        //public StudentWindow(): base(GType)
        {
            Build();
            UpdateNames();
        }

        protected void UpdateNames()
        {
            label5.Text = "Student!";
        }
    }
}
