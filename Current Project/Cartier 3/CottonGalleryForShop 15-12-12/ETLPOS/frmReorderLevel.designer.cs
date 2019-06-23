namespace ETLPOS
{
    partial class frmReorderLevel
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.cmbItemName = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLocation = new System.Windows.Forms.Button();
            this.btnItem = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblgrname = new System.Windows.Forms.Label();
            this.txtRQTY = new System.Windows.Forms.TextBox();
            this.lblRQTY = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.gbItemNAme = new System.Windows.Forms.GroupBox();
            this.lvReorderList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gbItemNAme.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbLocation);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.cmbItemName);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnLocation);
            this.groupBox1.Controls.Add(this.btnItem);
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblgrname);
            this.groupBox1.Controls.Add(this.txtRQTY);
            this.groupBox1.Controls.Add(this.lblRQTY);
            this.groupBox1.Controls.Add(this.lblItemName);
            this.groupBox1.Location = new System.Drawing.Point(516, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 306);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entry Item ";
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(100, 43);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(173, 21);
            this.cmbLocation.TabIndex = 1;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(6, 280);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(20, 20);
            this.txtID.TabIndex = 63;
            this.txtID.Visible = false;
            // 
            // cmbItemName
            // 
            this.cmbItemName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemName.FormattingEnabled = true;
            this.cmbItemName.Location = new System.Drawing.Point(100, 18);
            this.cmbItemName.Name = "cmbItemName";
            this.cmbItemName.Size = new System.Drawing.Size(173, 21);
            this.cmbItemName.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(-505, 252);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 23);
            this.btnClose.TabIndex = 55;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLocation
            // 
            this.btnLocation.Location = new System.Drawing.Point(280, 42);
            this.btnLocation.Name = "btnLocation";
            this.btnLocation.Size = new System.Drawing.Size(32, 23);
            this.btnLocation.TabIndex = 5;
            this.btnLocation.Text = "--";
            this.btnLocation.UseVisualStyleBackColor = true;
            this.btnLocation.Click += new System.EventHandler(this.btnLocation_Click);
            // 
            // btnItem
            // 
            this.btnItem.Location = new System.Drawing.Point(279, 18);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new System.Drawing.Size(32, 23);
            this.btnItem.TabIndex = 4;
            this.btnItem.Text = "--";
            this.btnItem.UseVisualStyleBackColor = true;
            this.btnItem.Click += new System.EventHandler(this.btnItem_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(100, 94);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(173, 20);
            this.txtRemarks.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 56;
            this.label6.Text = "Remarks";
            // 
            // lblgrname
            // 
            this.lblgrname.AutoSize = true;
            this.lblgrname.Location = new System.Drawing.Point(16, 43);
            this.lblgrname.Name = "lblgrname";
            this.lblgrname.Size = new System.Drawing.Size(56, 13);
            this.lblgrname.TabIndex = 50;
            this.lblgrname.Text = "Location";
            // 
            // txtRQTY
            // 
            this.txtRQTY.Location = new System.Drawing.Point(100, 68);
            this.txtRQTY.Multiline = true;
            this.txtRQTY.Name = "txtRQTY";
            this.txtRQTY.Size = new System.Drawing.Size(173, 20);
            this.txtRQTY.TabIndex = 2;
            this.txtRQTY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsValidKeyPress);
            // 
            // lblRQTY
            // 
            this.lblRQTY.AutoSize = true;
            this.lblRQTY.Location = new System.Drawing.Point(16, 72);
            this.lblRQTY.Name = "lblRQTY";
            this.lblRQTY.Size = new System.Drawing.Size(41, 13);
            this.lblRQTY.TabIndex = 41;
            this.lblRQTY.Text = "RQTY";
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(16, 22);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(67, 13);
            this.lblItemName.TabIndex = 39;
            this.lblItemName.Text = "Item Name";
            // 
            // gbItemNAme
            // 
            this.gbItemNAme.Controls.Add(this.lvReorderList);
            this.gbItemNAme.Location = new System.Drawing.Point(14, 12);
            this.gbItemNAme.Name = "gbItemNAme";
            this.gbItemNAme.Size = new System.Drawing.Size(495, 306);
            this.gbItemNAme.TabIndex = 2;
            this.gbItemNAme.TabStop = false;
            this.gbItemNAme.Text = "Item Name";
            // 
            // lvReorderList
            // 
            this.lvReorderList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lvReorderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvReorderList.FullRowSelect = true;
            this.lvReorderList.GridLines = true;
            this.lvReorderList.Location = new System.Drawing.Point(3, 16);
            this.lvReorderList.Name = "lvReorderList";
            this.lvReorderList.Size = new System.Drawing.Size(489, 287);
            this.lvReorderList.TabIndex = 0;
            this.lvReorderList.UseCompatibleStateImageBehavior = false;
            this.lvReorderList.View = System.Windows.Forms.View.Details;
            this.lvReorderList.SelectedIndexChanged += new System.EventHandler(this.lvReorderList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "OID";
            this.columnHeader1.Width = 1;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Item_ID";
            this.columnHeader2.Width = 1;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Location_ID";
            this.columnHeader3.Width = 1;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Branch";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Item Name";
            this.columnHeader5.Width = 130;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Location Name";
            this.columnHeader6.Width = 120;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Quantity";
            this.columnHeader7.Width = 75;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Remarks";
            this.columnHeader8.Width = 120;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(658, 19);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(568, 19);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(84, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Clear";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(479, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Location = new System.Drawing.Point(7, 324);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(839, 54);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
      
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(750, 19);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Close";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmReorderLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 390);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbItemNAme);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReorderLevel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReorderLevel";
            this.Load += new System.EventHandler(this.frmReorderLevel_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbItemNAme.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblgrname;
        private System.Windows.Forms.TextBox txtRQTY;
        private System.Windows.Forms.Label lblRQTY;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.GroupBox gbItemNAme;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListView lvReorderList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnItem;
        private System.Windows.Forms.Button btnLocation;
        private System.Windows.Forms.ComboBox cmbItemName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
    }
}