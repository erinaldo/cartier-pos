namespace ETLPOS
{
    partial class frmLocationToBranch
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
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvCVBList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtHiddenOID = new System.Windows.Forms.TextBox();
            this.btnBranch = new System.Windows.Forms.Button();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLocation = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 488);
            this.panel1.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(513, 463);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Close";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvCVBList);
            this.groupBox2.Location = new System.Drawing.Point(9, 169);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(584, 292);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Location To Branch";
            // 
            // lvCVBList
            // 
            this.lvCVBList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvCVBList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCVBList.FullRowSelect = true;
            this.lvCVBList.GridLines = true;
            this.lvCVBList.Location = new System.Drawing.Point(3, 16);
            this.lvCVBList.Name = "lvCVBList";
            this.lvCVBList.Size = new System.Drawing.Size(578, 273);
            this.lvCVBList.TabIndex = 0;
            this.lvCVBList.UseCompatibleStateImageBehavior = false;
            this.lvCVBList.View = System.Windows.Forms.View.Details;
            this.lvCVBList.SelectedIndexChanged += new System.EventHandler(this.lvCVBList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "OID";
            this.columnHeader1.Width = 1;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Branch";
            this.columnHeader2.Width = 1;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Center";
            this.columnHeader3.Width = 1;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 150;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtHiddenOID);
            this.groupBox1.Controls.Add(this.btnBranch);
            this.groupBox1.Controls.Add(this.cmbLocation);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbBranch);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnLocation);
            this.groupBox1.Controls.Add(this.Delete);
            this.groupBox1.Controls.Add(this.btnCreate);
            this.groupBox1.Location = new System.Drawing.Point(9, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 160);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Details";
            // 
            // txtHiddenOID
            // 
            this.txtHiddenOID.Location = new System.Drawing.Point(427, 83);
            this.txtHiddenOID.Name = "txtHiddenOID";
            this.txtHiddenOID.Size = new System.Drawing.Size(28, 20);
            this.txtHiddenOID.TabIndex = 71;
            this.txtHiddenOID.Visible = false;
            // 
            // btnBranch
            // 
            this.btnBranch.Location = new System.Drawing.Point(221, 36);
            this.btnBranch.Name = "btnBranch";
            this.btnBranch.Size = new System.Drawing.Size(30, 23);
            this.btnBranch.TabIndex = 4;
            this.btnBranch.Text = "--";
            this.btnBranch.UseVisualStyleBackColor = true;
            this.btnBranch.Click += new System.EventHandler(this.btnBranch_Click);
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(355, 37);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(137, 21);
            this.cmbLocation.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(297, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 67;
            this.label1.Text = "Location";
            // 
            // cmbBranch
            // 
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(78, 36);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(137, 21);
            this.cmbBranch.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 65;
            this.label7.Text = "Branch";
            // 
            // btnLocation
            // 
            this.btnLocation.Location = new System.Drawing.Point(498, 35);
            this.btnLocation.Name = "btnLocation";
            this.btnLocation.Size = new System.Drawing.Size(30, 23);
            this.btnLocation.TabIndex = 5;
            this.btnLocation.Text = "--";
            this.btnLocation.UseVisualStyleBackColor = true;
            this.btnLocation.Click += new System.EventHandler(this.btnLocation_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(456, 126);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(109, 23);
            this.Delete.TabIndex = 3;
            this.Delete.Text = "Delete ";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(323, 126);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(109, 23);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // frmLocationToBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 488);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLocationToBranch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LocationTo Branch";
            this.Load += new System.EventHandler(this.frmLocationToBranch_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lvCVBList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLocation;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnBranch;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHiddenOID;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}