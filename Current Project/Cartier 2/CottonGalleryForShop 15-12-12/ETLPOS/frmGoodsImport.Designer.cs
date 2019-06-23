namespace ETLPOS
{
    partial class frmGoodsImport
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
            this.btnImport = new System.Windows.Forms.Button();
            this.progressBarImport = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(118, 102);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(117, 33);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Import Goods";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // progressBarImport
            // 
            this.progressBarImport.Location = new System.Drawing.Point(33, 51);
            this.progressBarImport.Name = "progressBarImport";
            this.progressBarImport.Size = new System.Drawing.Size(296, 23);
            this.progressBarImport.TabIndex = 1;
            // 
            // frmGoodsImport
            // 
            this.ClientSize = new System.Drawing.Size(354, 179);
            this.Controls.Add(this.progressBarImport);
            this.Controls.Add(this.btnImport);
            this.Name = "frmGoodsImport";
            this.Text = "Goods Import";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ProgressBar progressBarImport;
    }
}
