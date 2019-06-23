namespace ETLPOS
{
    partial class frmProductSize
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSizeid = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lbgroupType = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSIZEName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSIZECode = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gbUOMType = new System.Windows.Forms.GroupBox();
            this.txtUOMid = new System.Windows.Forms.TextBox();
            this.LLSIZEType = new System.Windows.Forms.ListBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbUOMType.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSizeid);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Location = new System.Drawing.Point(8, 217);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(432, 50);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // txtSizeid
            // 
            this.txtSizeid.Location = new System.Drawing.Point(4, 0);
            this.txtSizeid.Multiline = true;
            this.txtSizeid.Name = "txtSizeid";
            this.txtSizeid.Size = new System.Drawing.Size(105, 20);
            this.txtSizeid.TabIndex = 39;
            this.txtSizeid.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(115, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(193, 17);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(72, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Clear";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(349, 17);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(271, 17);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(72, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // lbgroupType
            // 
            this.lbgroupType.AutoSize = true;
            this.lbgroupType.BackColor = System.Drawing.Color.Transparent;
            this.lbgroupType.Location = new System.Drawing.Point(6, 17);
            this.lbgroupType.Name = "lbgroupType";
            this.lbgroupType.Size = new System.Drawing.Size(55, 13);
            this.lbgroupType.TabIndex = 38;
            this.lbgroupType.Text = "Size Code";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSIZEName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSIZECode);
            this.groupBox1.Controls.Add(this.lbgroupType);
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(189, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 209);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Entry";
            // 
            // txtSIZEName
            // 
            this.txtSIZEName.Location = new System.Drawing.Point(72, 40);
            this.txtSIZEName.Multiline = true;
            this.txtSIZEName.Name = "txtSIZEName";
            this.txtSIZEName.Size = new System.Drawing.Size(162, 20);
            this.txtSIZEName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Size Name";
            // 
            // txtSIZECode
            // 
            this.txtSIZECode.Location = new System.Drawing.Point(72, 14);
            this.txtSIZECode.Multiline = true;
            this.txtSIZECode.Name = "txtSIZECode";
            this.txtSIZECode.Size = new System.Drawing.Size(162, 20);
            this.txtSIZECode.TabIndex = 0;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(72, 75);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRemarks.Size = new System.Drawing.Size(162, 99);
            this.txtRemarks.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Remarks";
            // 
            // gbUOMType
            // 
            this.gbUOMType.Controls.Add(this.txtUOMid);
            this.gbUOMType.Controls.Add(this.LLSIZEType);
            this.gbUOMType.Location = new System.Drawing.Point(8, 8);
            this.gbUOMType.Name = "gbUOMType";
            this.gbUOMType.Size = new System.Drawing.Size(160, 209);
            this.gbUOMType.TabIndex = 7;
            this.gbUOMType.TabStop = false;
            this.gbUOMType.Text = "Size List";
            // 
            // txtUOMid
            // 
            this.txtUOMid.Location = new System.Drawing.Point(181, 25);
            this.txtUOMid.Multiline = true;
            this.txtUOMid.Name = "txtUOMid";
            this.txtUOMid.Size = new System.Drawing.Size(69, 63);
            this.txtUOMid.TabIndex = 36;
            this.txtUOMid.Visible = false;
            // 
            // LLSIZEType
            // 
            this.LLSIZEType.FormattingEnabled = true;
            this.LLSIZEType.Location = new System.Drawing.Point(12, 19);
            this.LLSIZEType.Name = "LLSIZEType";
            this.LLSIZEType.Size = new System.Drawing.Size(134, 173);
            this.LLSIZEType.TabIndex = 17;
            this.LLSIZEType.SelectedIndexChanged += new System.EventHandler(this.LLSIZEType_SelectedIndexChanged);
            // 
            // frmProductSize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 279);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbUOMType);
            this.Name = "frmProductSize";
            this.Text = "frmProductSize";
            this.Load += new System.EventHandler(this.frmProductSize_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbUOMType.ResumeLayout(false);
            this.gbUOMType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbgroupType;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSIZEName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSIZECode;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gbUOMType;
        private System.Windows.Forms.TextBox txtUOMid;
        private System.Windows.Forms.ListBox LLSIZEType;
        private System.Windows.Forms.TextBox txtSizeid;
    }
}