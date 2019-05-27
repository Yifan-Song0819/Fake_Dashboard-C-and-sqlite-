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
            int x = 100;

            for (int i = 1; i < 4; i++)
            {
                Button abtn = new Button("lol");
                abtn.SetSizeRequest(100, 100);
                abtn.SetUposition(x, 100);
                abtn.Clicked += new EventHandler(DynamicButton_Click);
                this.fixed1.Add(abtn);
                abtn.Show();
                x = x + 200;
            }


        }

        protected void DynamicButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("new one!!!!");
        }

    }
}
