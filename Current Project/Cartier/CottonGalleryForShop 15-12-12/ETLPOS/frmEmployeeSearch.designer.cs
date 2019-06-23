namespace ETLPOS
{
    partial class frmEmployeeSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstEmployeeList = new System.Windows.Forms.ListView();
            this.ID = new System.Windows.Forms.ColumnHeader();
            this.EmpID = new System.Windows.Forms.ColumnHeader();
            this.Name = new System.Windows.Forms.ColumnHeader();
            this.Unit = new System.Windows.Forms.ColumnHeader();
            this.Floor = new System.Windows.Forms.ColumnHeader();
            this.Section = new System.Windows.Forms.ColumnHeader();
            this.Block = new System.Windows.Forms.ColumnHeader();
            this.Shift = new System.Windows.Forms.ColumnHeader();
            this.Designation = new System.Windows.Forms.ColumnHeader();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Location = new System.Drawing.Point(1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 372);
            this.panel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstEmployeeList);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(12, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(503, 360);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Person Information";
            // 
            // lstEmployeeList
            // 
            this.lstEmployeeList.AllowDrop = true;
            this.lstEmployeeList.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lstEmployeeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.EmpID,
            this.Name,
            this.Unit,
            this.Floor,
            this.Section,
            this.Block,
            this.Shift,
            this.Designation});
            this.lstEmployeeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstEmployeeList.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lstEmployeeList.FullRowSelect = true;
            this.lstEmployeeList.GridLines = true;
            this.lstEmployeeList.Location = new System.Drawing.Point(3, 19);
            this.lstEmployeeList.Name = "lstEmployeeList";
            this.lstEmployeeList.Size = new System.Drawing.Size(497, 338);
            this.lstEmployeeList.TabIndex = 0;
            this.lstEmployeeList.UseCompatibleStateImageBehavior = false;
            this.lstEmployeeList.View = System.Windows.Forms.View.Details;
            this.lstEmployeeList.DoubleClick += new System.EventHandler(this.lstEmployeeList_DoubleClick);
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 1;
            // 
            // EmpID
            // 
            this.EmpID.Text = "Employee  ID";
            this.EmpID.Width = 120;
            // 
            // Name
            // 
            this.Name.Text = "Name";
            this.Name.Width = 200;
            // 
            // Unit
            // 
            this.Unit.Text = "Employee Type";
            this.Unit.Width = 160;
            // 
            // Floor
            // 
            this.Floor.Text = "Floor";
            this.Floor.Width = 1;
            // 
            // Section
            // 
            this.Section.Text = "Section";
            this.Section.Width = 1;
            // 
            // Block
            // 
            this.Block.Text = "Block";
            this.Block.Width = 1;
            // 
            // Shift
            // 
            this.Shift.Text = "Shift";
            this.Shift.Width = 1;
            // 
            // Designation
            // 
            this.Designation.Text = "Designation";
            this.Designation.Width = 1;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnExit.Location = new System.Drawing.Point(430, 385);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(85, 32);
            this.btnExit.TabIndex = 73;
            this.btnExit.Text = "Close";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmEmployeeSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(561, 439);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnExit);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            //this.Name = "frmEmployeeSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Search";
            this.Load += new System.EventHandler(this.frmEmployeeSearch_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lstEmployeeList;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader EmpID;
        private System.Windows.Forms.ColumnHeader Name;
        private System.Windows.Forms.ColumnHeader Unit;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ColumnHeader Floor;
        private System.Windows.Forms.ColumnHeader Section;
        private System.Windows.Forms.ColumnHeader Block;
        private System.Windows.Forms.ColumnHeader Shift;
        private System.Windows.Forms.ColumnHeader Designation;
    }
}