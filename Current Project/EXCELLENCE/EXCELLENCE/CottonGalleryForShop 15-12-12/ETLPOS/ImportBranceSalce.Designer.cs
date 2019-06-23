namespace ETLPOS
{
    partial class ImportBranceSalce
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
            this.btnSalesImport = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnSalesImport
            // 
            this.btnSalesImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalesImport.Location = new System.Drawing.Point(5, 86);
            this.btnSalesImport.Name = "btnSalesImport";
            this.btnSalesImport.Size = new System.Drawing.Size(307, 57);
            this.btnSalesImport.TabIndex = 0;
            this.btnSalesImport.Text = "Import Brance To Headoffice";
            this.btnSalesImport.UseVisualStyleBackColor = true;
            this.btnSalesImport.Click += new System.EventHandler(this.btnSalesExport_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ImportBranceSalce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 152);
            this.Controls.Add(this.btnSalesImport);
            this.Name = "ImportBranceSalce";
            this.Text = "ExportBranceToHead";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalesImport;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}