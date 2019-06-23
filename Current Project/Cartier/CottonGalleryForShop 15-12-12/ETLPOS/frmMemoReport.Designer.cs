namespace ETLPOS
{
    partial class frmMemoReport
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtMenoNo = new System.Windows.Forms.TextBox();
            this.btnMemoSearch = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Memo No";
            // 
            // txtMenoNo
            // 
            this.txtMenoNo.Location = new System.Drawing.Point(73, 34);
            this.txtMenoNo.Name = "txtMenoNo";
            this.txtMenoNo.Size = new System.Drawing.Size(152, 20);
            this.txtMenoNo.TabIndex = 1;
            // 
            // btnMemoSearch
            // 
            this.btnMemoSearch.Location = new System.Drawing.Point(228, 34);
            this.btnMemoSearch.Name = "btnMemoSearch";
            this.btnMemoSearch.Size = new System.Drawing.Size(25, 21);
            this.btnMemoSearch.TabIndex = 2;
            this.btnMemoSearch.Text = "+";
            this.btnMemoSearch.UseVisualStyleBackColor = true;
            this.btnMemoSearch.Click += new System.EventHandler(this.btnMemoSearch_Click);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(50, 87);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 3;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(139, 87);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnShow);
            this.groupBox1.Controls.Add(this.btnMemoSearch);
            this.groupBox1.Controls.Add(this.txtMenoNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(11, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 145);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Memo Details";
            // 
            // frmMemoReport
            // 
            this.ClientSize = new System.Drawing.Size(295, 174);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMemoReport";
            this.Text = "Memo";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMenoNo;
        private System.Windows.Forms.Button btnMemoSearch;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
