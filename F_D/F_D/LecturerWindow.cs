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
            // !!!
            using (Button abtn = new Button("lol"))
            {
                //abtn.SetSizeRequest(100, 100);
                //abtn.SetUposition(100, 100);
                //abtn.Clicked += new EventHandler(abtn_Clicked);
                //EventArgs ee = new EventArgs();
                //abtn_Clicked(abtn, ee);
                //this.fixed1.Add(abtn);
                //abtn.Show(); 


                abtn.SetSizeRequest(100, 100);
                abtn.SetUposition(100, 100);
                abtn.Clicked += delegate
                {
                    Console.WriteLine("111111");
                };
                this.fixed1.Add(abtn);
                abtn.Show(); 
            }
        }

        //protected void abtn_Clicked(object sender, EventArgs e)
        //{
        //    Dialog dialog = new Dialog();
        //    dialog.Title = "Warning:";
        //    dialog.Modal = true;
        //    dialog.AllowGrow = true;
        //    dialog.AllowShrink = true;
        //    dialog.Modal = true;
        //    dialog.AddActionWidget(new Label("1111111"), ResponseType.Ok);
        //    dialog.AddActionWidget(new Button(Stock.Ok), ResponseType.Ok);
        //    dialog.SetPosition(WindowPosition.Center);
        //    //show and get response
        //    dialog.ShowAll();
        //    ResponseType response = (ResponseType)dialog.Run();
        //    dialog.Destroy();
        //}
    }
}
