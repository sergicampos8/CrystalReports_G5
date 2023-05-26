
namespace CrystalReports_G5
{
    partial class F1StatsXML
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F1StatsXML));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Title = new System.Windows.Forms.Label();
            this.LabelFile = new System.Windows.Forms.Label();
            this.FileBox = new System.Windows.Forms.TextBox();
            this.ButtonBrowse = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.TypeEmployeeMultiBox = new System.Windows.Forms.ComboBox();
            this.NameMultiBox = new System.Windows.Forms.ComboBox();
            this.SaveAsCSVbutton = new System.Windows.Forms.Button();
            this.QueryTextBox = new System.Windows.Forms.TextBox();
            this.searchbutton = new System.Windows.Forms.Button();
            this.appendbutton = new System.Windows.Forms.Button();
            this.statisticsbutton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::CrystalReports_G5.Properties.Resources.PNG_RGB_72_DPI_F1_RM_Logo_White_Standard_RGB;
            this.pictureBox1.Location = new System.Drawing.Point(72, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(528, 207);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.Font = new System.Drawing.Font("ROG Fonts", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.White;
            this.Title.Location = new System.Drawing.Point(659, 76);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(674, 46);
            this.Title.TabIndex = 2;
            this.Title.Text = "Grand Prix Information";
            this.Title.Click += new System.EventHandler(this.label2_Click);
            // 
            // LabelFile
            // 
            this.LabelFile.AutoSize = true;
            this.LabelFile.BackColor = System.Drawing.Color.Transparent;
            this.LabelFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFile.ForeColor = System.Drawing.Color.White;
            this.LabelFile.Location = new System.Drawing.Point(67, 236);
            this.LabelFile.Name = "LabelFile";
            this.LabelFile.Size = new System.Drawing.Size(54, 25);
            this.LabelFile.TabIndex = 3;
            this.LabelFile.Text = "File:";
            this.LabelFile.Click += new System.EventHandler(this.LabelFile_Click);
            // 
            // FileBox
            // 
            this.FileBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FileBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileBox.Location = new System.Drawing.Point(127, 236);
            this.FileBox.Multiline = true;
            this.FileBox.Name = "FileBox";
            this.FileBox.Size = new System.Drawing.Size(668, 30);
            this.FileBox.TabIndex = 4;
            this.FileBox.TextChanged += new System.EventHandler(this.FileBox_TextChanged);
            // 
            // ButtonBrowse
            // 
            this.ButtonBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonBrowse.Location = new System.Drawing.Point(839, 236);
            this.ButtonBrowse.Name = "ButtonBrowse";
            this.ButtonBrowse.Size = new System.Drawing.Size(70, 30);
            this.ButtonBrowse.TabIndex = 5;
            this.ButtonBrowse.Text = "...";
            this.ButtonBrowse.UseVisualStyleBackColor = true;
            this.ButtonBrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadButton.Location = new System.Drawing.Point(954, 236);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(359, 30);
            this.LoadButton.TabIndex = 6;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // TypeEmployeeMultiBox
            // 
            this.TypeEmployeeMultiBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TypeEmployeeMultiBox.FormattingEnabled = true;
            this.TypeEmployeeMultiBox.Items.AddRange(new object[] {
            "Grand Prix",
            "Pilot",
            "Racing Team"});
            this.TypeEmployeeMultiBox.Location = new System.Drawing.Point(127, 305);
            this.TypeEmployeeMultiBox.Name = "TypeEmployeeMultiBox";
            this.TypeEmployeeMultiBox.Size = new System.Drawing.Size(294, 24);
            this.TypeEmployeeMultiBox.TabIndex = 7;
            this.TypeEmployeeMultiBox.SelectedIndexChanged += new System.EventHandler(this.TypeEmployeeMultiBox_SelectedIndexChanged);
            // 
            // NameMultiBox
            // 
            this.NameMultiBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameMultiBox.FormattingEnabled = true;
            this.NameMultiBox.Location = new System.Drawing.Point(501, 306);
            this.NameMultiBox.Name = "NameMultiBox";
            this.NameMultiBox.Size = new System.Drawing.Size(294, 24);
            this.NameMultiBox.Sorted = true;
            this.NameMultiBox.TabIndex = 8;
            this.NameMultiBox.SelectedIndexChanged += new System.EventHandler(this.NameMultiBox_SelectedIndexChanged);
            // 
            // SaveAsCSVbutton
            // 
            this.SaveAsCSVbutton.BackgroundImage = global::CrystalReports_G5.Properties.Resources.csv1;
            this.SaveAsCSVbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SaveAsCSVbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveAsCSVbutton.Location = new System.Drawing.Point(954, 306);
            this.SaveAsCSVbutton.Name = "SaveAsCSVbutton";
            this.SaveAsCSVbutton.Size = new System.Drawing.Size(359, 64);
            this.SaveAsCSVbutton.TabIndex = 9;
            this.SaveAsCSVbutton.Text = "Save as CSV";
            this.SaveAsCSVbutton.UseVisualStyleBackColor = true;
            this.SaveAsCSVbutton.Click += new System.EventHandler(this.SaveAsCSVbutton_Click);
            // 
            // QueryTextBox
            // 
            this.QueryTextBox.AcceptsTab = true;
            this.QueryTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QueryTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QueryTextBox.Location = new System.Drawing.Point(72, 399);
            this.QueryTextBox.Multiline = true;
            this.QueryTextBox.Name = "QueryTextBox";
            this.QueryTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.QueryTextBox.Size = new System.Drawing.Size(837, 326);
            this.QueryTextBox.TabIndex = 10;
            this.QueryTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // searchbutton
            // 
            this.searchbutton.BackgroundImage = global::CrystalReports_G5.Properties.Resources.search;
            this.searchbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.searchbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchbutton.Location = new System.Drawing.Point(954, 399);
            this.searchbutton.Name = "searchbutton";
            this.searchbutton.Size = new System.Drawing.Size(359, 64);
            this.searchbutton.TabIndex = 11;
            this.searchbutton.Text = "Search";
            this.searchbutton.UseVisualStyleBackColor = true;
            this.searchbutton.Click += new System.EventHandler(this.searchbutton_Click);
            // 
            // appendbutton
            // 
            this.appendbutton.BackgroundImage = global::CrystalReports_G5.Properties.Resources.append;
            this.appendbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.appendbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appendbutton.Location = new System.Drawing.Point(954, 522);
            this.appendbutton.Name = "appendbutton";
            this.appendbutton.Size = new System.Drawing.Size(359, 64);
            this.appendbutton.TabIndex = 13;
            this.appendbutton.Text = "Append";
            this.appendbutton.UseVisualStyleBackColor = true;
            this.appendbutton.Click += new System.EventHandler(this.appendbutton_Click);
            // 
            // statisticsbutton
            // 
            this.statisticsbutton.BackgroundImage = global::CrystalReports_G5.Properties.Resources.statistics;
            this.statisticsbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.statisticsbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statisticsbutton.Location = new System.Drawing.Point(954, 652);
            this.statisticsbutton.Name = "statisticsbutton";
            this.statisticsbutton.Size = new System.Drawing.Size(359, 64);
            this.statisticsbutton.TabIndex = 14;
            this.statisticsbutton.Text = "Statistics";
            this.statisticsbutton.UseVisualStyleBackColor = true;
            this.statisticsbutton.Click += new System.EventHandler(this.statisticsbutton_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(72)))), ((int)(((byte)(66)))));
            this.pictureBox2.Location = new System.Drawing.Point(63, 392);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(856, 342);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // F1StatsXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1470, 746);
            this.Controls.Add(this.statisticsbutton);
            this.Controls.Add(this.appendbutton);
            this.Controls.Add(this.searchbutton);
            this.Controls.Add(this.QueryTextBox);
            this.Controls.Add(this.SaveAsCSVbutton);
            this.Controls.Add(this.NameMultiBox);
            this.Controls.Add(this.TypeEmployeeMultiBox);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.ButtonBrowse);
            this.Controls.Add(this.FileBox);
            this.Controls.Add(this.LabelFile);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Name = "F1StatsXML";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.F1StatsXML_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label LabelFile;
        private System.Windows.Forms.TextBox FileBox;
        private System.Windows.Forms.Button ButtonBrowse;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.ComboBox TypeEmployeeMultiBox;
        private System.Windows.Forms.ComboBox NameMultiBox;
        private System.Windows.Forms.Button SaveAsCSVbutton;
        private System.Windows.Forms.TextBox QueryTextBox;
        private System.Windows.Forms.Button searchbutton;
        private System.Windows.Forms.Button appendbutton;
        private System.Windows.Forms.Button statisticsbutton;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}