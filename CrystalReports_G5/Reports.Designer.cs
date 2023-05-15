
namespace CrystalReports_G5
{
    partial class Reports
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.crystalReportViewer2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.RacingTeamInfo22 = new CrystalReports_G5.RacingTeamInfo2();
            this.RacingTeamInfo21 = new CrystalReports_G5.RacingTeamInfo2();
            this.ClassificacioPerGP1 = new CrystalReports_G5.ClassificacioPerGP();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // crystalReportViewer2
            // 
            this.crystalReportViewer2.ActiveViewIndex = -1;
            this.crystalReportViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer2.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer2.Location = new System.Drawing.Point(-12, 40);
            this.crystalReportViewer2.Name = "crystalReportViewer2";
            this.crystalReportViewer2.Size = new System.Drawing.Size(1229, 701);
            this.crystalReportViewer2.TabIndex = 1;
            this.crystalReportViewer2.Load += new System.EventHandler(this.crystalReportViewer2_Load);
            // 
            // ClassificacioPerGP1
            // 
            this.ClassificacioPerGP1.InitReport += new System.EventHandler(this.ClassificacioPerGP1_InitReport);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "ClassificacioPerGP.rpt",
            "InformacioDeCadaGP.rpt",
            "RacingTeamInfo2.rpt"});
            this.comboBox1.Location = new System.Drawing.Point(195, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(202, 24);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 24);
            this.button1.TabIndex = 3;
            this.button1.Text = "Select Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 722);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.crystalReportViewer2);
            this.Name = "Reports";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Reports_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer2;
        private ClassificacioPerGP ClassificacioPerGP1;
        private RacingTeamInfo2 RacingTeamInfo21;
        private RacingTeamInfo2 RacingTeamInfo22;
        private InformacioDeCadaGP InformaciodeCadaGP1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
    }
}

