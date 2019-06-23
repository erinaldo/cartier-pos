namespace ETLPOS
{
    partial class frmMTExpItems
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.txtDelvNO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bntShowRpt = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnExportItems = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.crystalReportViewer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 495);
            this.panel1.TabIndex = 0;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.DisplayGroupTree = false;
            this.crystalReportViewer1.DisplayStatusBar = false;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(932, 495);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // txtDelvNO
            // 
            this.txtDelvNO.Location = new System.Drawing.Point(125, 15);
            this.txtDelvNO.Name = "txtDelvNO";
            this.txtDelvNO.Size = new System.Drawing.Size(207, 20);
            this.txtDelvNO.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Delivery No.";
            // 
            // bntShowRpt
            // 
            this.bntShowRpt.Location = new System.Drawing.Point(370, 13);
            this.bntShowRpt.Name = "bntShowRpt";
            this.bntShowRpt.Size = new System.Drawing.Size(151, 23);
            this.bntShowRpt.TabIndex = 1;
            this.bntShowRpt.Text = "Show Report";
            this.bntShowRpt.UseVisualStyleBackColor = true;
            this.bntShowRpt.Click += new System.EventHandler(this.bntShowRpt_Click);
            // 
            // btnExportItems
            // 
            this.btnExportItems.Location = new System.Drawing.Point(527, 13);
            this.btnExportItems.Name = "btnExportItems";
            this.btnExportItems.Size = new System.Drawing.Size(156, 24);
            this.btnExportItems.TabIndex = 4;
            this.btnExportItems.Text = "Export Data";
            this.btnExportItems.UseVisualStyleBackColor = false;
            this.btnExportItems.Click += new System.EventHandler(this.btnExportItems_Click);
            // 
            // frmMTExpItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 555);
            this.Controls.Add(this.btnExportItems);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDelvNO);
            this.Controls.Add(this.bntShowRpt);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmMTExpItems";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export Data";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.TextBox txtDelvNO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bntShowRpt;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnExportItems;
    }
}