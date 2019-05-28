namespace Fake_Dashboard
{
    partial class Dean
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DataTable1 = new System.Windows.Forms.DataGridView();
            this.CourseNumComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1)).BeginInit();
            this.SuspendLayout();
            // 
            // DataTable1
            // 
            this.DataTable1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataTable1.Location = new System.Drawing.Point(21, 12);
            this.DataTable1.Name = "DataTable1";
            this.DataTable1.RowTemplate.Height = 23;
            this.DataTable1.Size = new System.Drawing.Size(746, 423);
            this.DataTable1.TabIndex = 0;
            // 
            // CourseNumComboBox
            // 
            this.CourseNumComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CourseNumComboBox.FormattingEnabled = true;
            this.CourseNumComboBox.Location = new System.Drawing.Point(790, 12);
            this.CourseNumComboBox.Name = "CourseNumComboBox";
            this.CourseNumComboBox.Size = new System.Drawing.Size(194, 20);
            this.CourseNumComboBox.TabIndex = 1;
            this.CourseNumComboBox.SelectedIndexChanged += new System.EventHandler(this.CourseNumComboBox_SelectedIndexChanged);
            // 
            // Dean
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.CourseNumComboBox);
            this.Controls.Add(this.DataTable1);
            this.Name = "Dean";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dean";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Dean_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataTable1;
        private System.Windows.Forms.ComboBox CourseNumComboBox;
    }
}