
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::CrystalReports_G5.Properties.Resources.Captura_de_pantalla_2023_05_18_200701;
            this.pictureBox1.Location = new System.Drawing.Point(72, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(475, 173);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Bauhaus 93", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(823, 89);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(380, 39);
            this.Title.TabIndex = 2;
            this.Title.Text = "Grand Prix Information";
            this.Title.Click += new System.EventHandler(this.label2_Click);
            // 
            // LabelFile
            // 
            this.LabelFile.AutoSize = true;
            this.LabelFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFile.Location = new System.Drawing.Point(109, 236);
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
            this.FileBox.Location = new System.Drawing.Point(184, 236);
            this.FileBox.Multiline = true;
            this.FileBox.Name = "FileBox";
            this.FileBox.Size = new System.Drawing.Size(616, 30);
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
            this.LoadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.TypeEmployeeMultiBox.FormattingEnabled = true;
            this.TypeEmployeeMultiBox.Items.AddRange(new object[] {
            "Grand Prix",
            "Pilot",
            "Racing Team"});
            this.TypeEmployeeMultiBox.Location = new System.Drawing.Point(184, 327);
            this.TypeEmployeeMultiBox.Name = "TypeEmployeeMultiBox";
            this.TypeEmployeeMultiBox.Size = new System.Drawing.Size(242, 24);
            this.TypeEmployeeMultiBox.TabIndex = 7;
            this.TypeEmployeeMultiBox.SelectedIndexChanged += new System.EventHandler(this.TypeEmployeeMultiBox_SelectedIndexChanged);
            // 
            // NameMultiBox
            // 
            this.NameMultiBox.FormattingEnabled = true;
            this.NameMultiBox.Location = new System.Drawing.Point(558, 327);
            this.NameMultiBox.Name = "NameMultiBox";
            this.NameMultiBox.Size = new System.Drawing.Size(242, 24);
            this.NameMultiBox.Sorted = true;
            this.NameMultiBox.TabIndex = 8;
            this.NameMultiBox.SelectedIndexChanged += new System.EventHandler(this.NameMultiBox_SelectedIndexChanged);
            // 
            // SaveAsCSVbutton
            // 
            this.SaveAsCSVbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveAsCSVbutton.Location = new System.Drawing.Point(954, 314);
            this.SaveAsCSVbutton.Name = "SaveAsCSVbutton";
            this.SaveAsCSVbutton.Size = new System.Drawing.Size(359, 37);
            this.SaveAsCSVbutton.TabIndex = 9;
            this.SaveAsCSVbutton.Text = "Save as CSV";
            this.SaveAsCSVbutton.UseVisualStyleBackColor = true;
            this.SaveAsCSVbutton.Click += new System.EventHandler(this.SaveAsCSVbutton_Click);
            // 
            // QueryTextBox
            // 
            this.QueryTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QueryTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QueryTextBox.Location = new System.Drawing.Point(72, 399);
            this.QueryTextBox.Multiline = true;
            this.QueryTextBox.Name = "QueryTextBox";
            this.QueryTextBox.Size = new System.Drawing.Size(837, 317);
            this.QueryTextBox.TabIndex = 10;
            this.QueryTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // searchbutton
            // 
            this.searchbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchbutton.Location = new System.Drawing.Point(954, 399);
            this.searchbutton.Name = "searchbutton";
            this.searchbutton.Size = new System.Drawing.Size(359, 37);
            this.searchbutton.TabIndex = 11;
            this.searchbutton.Text = "Search";
            this.searchbutton.UseVisualStyleBackColor = true;
            this.searchbutton.Click += new System.EventHandler(this.searchbutton_Click);
            // 
            // appendbutton
            // 
            this.appendbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appendbutton.Location = new System.Drawing.Point(954, 460);
            this.appendbutton.Name = "appendbutton";
            this.appendbutton.Size = new System.Drawing.Size(359, 37);
            this.appendbutton.TabIndex = 13;
            this.appendbutton.Text = "Append";
            this.appendbutton.UseVisualStyleBackColor = true;
            this.appendbutton.Click += new System.EventHandler(this.appendbutton_Click);
            // 
            // statisticsbutton
            // 
            this.statisticsbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statisticsbutton.Location = new System.Drawing.Point(954, 524);
            this.statisticsbutton.Name = "statisticsbutton";
            this.statisticsbutton.Size = new System.Drawing.Size(359, 37);
            this.statisticsbutton.TabIndex = 14;
            this.statisticsbutton.Text = "Statistics";
            this.statisticsbutton.UseVisualStyleBackColor = true;
            // 
            // F1StatsXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
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
            this.Name = "F1StatsXML";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.F1StatsXML_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
    }
}