
// This file has been generated by the GUI designer. Do not modify.
namespace F_D
{
	public partial class LecturerWindow
	{
		private global::Gtk.Fixed fixed1;

		private global::Gtk.Label label1;

		private global::Gtk.Label label2;

		private global::Gtk.Button button1;

		private global::Gtk.Entry entry3;

		private global::Gtk.Button button3;

		private global::Gtk.Button button4;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gtk.NodeView nodeview2;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget F_D.LecturerWindow
			this.Name = "F_D.LecturerWindow";
			this.Title = global::Mono.Unix.Catalog.GetString("LecturerWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child F_D.LecturerWindow.Gtk.Container+ContainerChild
			this.fixed1 = new global::Gtk.Fixed();
			this.fixed1.Name = "fixed1";
			this.fixed1.HasWindow = false;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("label1");
			this.fixed1.Add(this.label1);
			global::Gtk.Fixed.FixedChild w1 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.label1]));
			w1.X = 50;
			w1.Y = 30;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("label2");
			this.fixed1.Add(this.label2);
			global::Gtk.Fixed.FixedChild w2 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.label2]));
			w2.X = 120;
			w2.Y = 30;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.button1 = new global::Gtk.Button();
			this.button1.CanFocus = true;
			this.button1.Name = "button1";
			this.button1.UseUnderline = true;
			this.button1.Label = global::Mono.Unix.Catalog.GetString("GtkButton");
			this.fixed1.Add(this.button1);
			global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.button1]));
			w3.X = 205;
			w3.Y = 375;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.entry3 = new global::Gtk.Entry();
			this.entry3.CanFocus = true;
			this.entry3.Name = "entry3";
			this.entry3.IsEditable = true;
			this.entry3.InvisibleChar = '●';
			this.fixed1.Add(this.entry3);
			global::Gtk.Fixed.FixedChild w4 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.entry3]));
			w4.X = 461;
			w4.Y = 332;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.button3 = new global::Gtk.Button();
			this.button3.CanFocus = true;
			this.button3.Name = "button3";
			this.button3.UseUnderline = true;
			this.button3.Label = global::Mono.Unix.Catalog.GetString("GtkButton");
			this.fixed1.Add(this.button3);
			global::Gtk.Fixed.FixedChild w5 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.button3]));
			w5.X = 370;
			w5.Y = 379;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.button4 = new global::Gtk.Button();
			this.button4.CanFocus = true;
			this.button4.Name = "button4";
			this.button4.UseUnderline = true;
			this.button4.Label = global::Mono.Unix.Catalog.GetString("123");
			this.fixed1.Add(this.button4);
			global::Gtk.Fixed.FixedChild w6 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.button4]));
			w6.X = 511;
			w6.Y = 370;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.nodeview2 = new global::Gtk.NodeView();
			this.nodeview2.CanFocus = true;
			this.nodeview2.ExtensionEvents = ((global::Gdk.ExtensionMode)(1));
			this.nodeview2.Name = "nodeview2";
			this.GtkScrolledWindow.Add(this.nodeview2);
			this.fixed1.Add(this.GtkScrolledWindow);
			global::Gtk.Fixed.FixedChild w8 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.GtkScrolledWindow]));
			w8.X = 89;
			w8.Y = 94;
			this.Add(this.fixed1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 821;
			this.DefaultHeight = 523;
			this.Show();
		}
	}
}
