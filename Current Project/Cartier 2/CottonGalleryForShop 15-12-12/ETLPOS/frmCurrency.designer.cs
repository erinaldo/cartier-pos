namespace ETLPOS
{
    partial class frmCurrency
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbUOMType = new System.Windows.Forms.GroupBox();
            this.lstCurrency = new System.Windows.Forms.ListBox();
            this.txtCurrOID = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lbgroupType = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gbUOMType.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(461, 21);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 34);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(383, 21);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(72, 34);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(305, 21);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(72, 34);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Clear";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(227, 21);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 34);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbUOMType
            // 
            this.gbUOMType.Controls.Add(this.lstCurrency);
            this.gbUOMType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbUOMType.Location = new System.Drawing.Point(8, 7);
            this.gbUOMType.Name = "gbUOMType";
            this.gbUOMType.Size = new System.Drawing.Size(170, 270);
            this.gbUOMType.TabIndex = 16;
            this.gbUOMType.TabStop = false;
            this.gbUOMType.Text = "Currency List";
            this.gbUOMType.Enter += new System.EventHandler(this.gbUOMType_Enter);
            // 
            // lstCurrency
            // 
            this.lstCurrency.FormattingEnabled = true;
            this.lstCurrency.ItemHeight = 16;
            this.lstCurrency.Location = new System.Drawing.Point(16, 19);
            this.lstCurrency.Name = "lstCurrency";
            this.lstCurrency.Size = new System.Drawing.Size(135, 228);
            this.lstCurrency.TabIndex = 17;
            this.lstCurrency.SelectedIndexChanged += new System.EventHandler(this.LLUOMType_SelectedIndexChanged);
            // 
            // txtCurrOID
            // 
            this.txtCurrOID.Location = new System.Drawing.Point(203, 83);
            this.txtCurrOID.Name = "txtCurrOID";
            this.txtCurrOID.Size = new System.Drawing.Size(10, 23);
            this.txtCurrOID.TabIndex = 36;
            this.txtCurrOID.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCurrOID);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.lbgroupType);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(194, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 272);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Entry";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(105, 83);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(92, 20);
            this.txtCode.TabIndex = 0;
            // 
            // lbgroupType
            // 
            this.lbgroupType.AutoSize = true;
            this.lbgroupType.Location = new System.Drawing.Point(46, 86);
            this.lbgroupType.Name = "lbgroupType";
            this.lbgroupType.Size = new System.Drawing.Size(45, 17);
            this.lbgroupType.TabIndex = 38;
            this.lbgroupType.Text = "Code";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(105, 111);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(170, 20);
            this.txtName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 17);
            this.label6.TabIndex = 36;
            this.label6.Text = "Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(8, 283);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(541, 81);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            // 
            // frmCurrency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 376);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbUOMType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmCurrency";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Currency";
            this.Load += new System.EventHandler(this.frmUOM_Load);
            this.gbUOMType.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gbUOMType;
        private System.Windows.Forms.TextBox txtCurrOID;
        private System.Windows.Forms.ListBox lstCurrency;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lbgroupType;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}