namespace ETLPOS
{
    partial class frmItemStatus
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
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lvItemList = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.btnExit = new System.Windows.Forms.Button();
            this.rdbtnCatg = new System.Windows.Forms.RadioButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtp_To = new System.Windows.Forms.DateTimePicker();
            this.dtp_From = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbtnDate = new System.Windows.Forms.RadioButton();
            this.ddlCategory = new System.Windows.Forms.ComboBox();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Item Code";
            this.columnHeader1.Width = 130;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lvItemList);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(36, 97);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(766, 339);
            this.groupBox6.TabIndex = 74;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Item List";
            // 
            // lvItemList
            // 
            this.lvItemList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader5});
            this.lvItemList.FullRowSelect = true;
            this.lvItemList.GridLines = true;
            this.lvItemList.Location = new System.Drawing.Point(10, 19);
            this.lvItemList.Name = "lvItemList";
            this.lvItemList.Size = new System.Drawing.Size(743, 312);
            this.lvItemList.TabIndex = 0;
            this.lvItemList.UseCompatibleStateImageBehavior = false;
            this.lvItemList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "SE";
            this.columnHeader4.Width = 33;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Item Name";
            this.columnHeader2.Width = 290;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Quantity";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "S Price";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 63;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(427, 442);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(68, 28);
            this.btnExit.TabIndex = 75;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // rdbtnCatg
            // 
            this.rdbtnCatg.AutoSize = true;
            this.rdbtnCatg.Checked = true;
            this.rdbtnCatg.Location = new System.Drawing.Point(57, 21);
            this.rdbtnCatg.Name = "rdbtnCatg";
            this.rdbtnCatg.Size = new System.Drawing.Size(133, 21);
            this.rdbtnCatg.TabIndex = 73;
            this.rdbtnCatg.TabStop = true;
            this.rdbtnCatg.Text = "Generic Group";
            this.rdbtnCatg.UseVisualStyleBackColor = true;
            this.rdbtnCatg.CheckedChanged += new System.EventHandler(this.rdbtnCatg_CheckedChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(422, 50);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(79, 28);
            this.btnSearch.TabIndex = 72;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtp_To
            // 
            this.dtp_To.CustomFormat = "dd-MMM-yy";
            this.dtp_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_To.Location = new System.Drawing.Point(308, 50);
            this.dtp_To.Name = "dtp_To";
            this.dtp_To.Size = new System.Drawing.Size(97, 23);
            this.dtp_To.TabIndex = 70;
            // 
            // dtp_From
            // 
            this.dtp_From.CustomFormat = "dd-MMM-yy";
            this.dtp_From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_From.Location = new System.Drawing.Point(168, 53);
            this.dtp_From.Name = "dtp_From";
            this.dtp_From.Size = new System.Drawing.Size(94, 23);
            this.dtp_From.TabIndex = 69;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 17);
            this.label2.TabIndex = 71;
            this.label2.Text = "To";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbtnCatg);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.dtp_To);
            this.groupBox1.Controls.Add(this.dtp_From);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rdbtnDate);
            this.groupBox1.Controls.Add(this.ddlCategory);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(36, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(540, 87);
            this.groupBox1.TabIndex = 73;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Criteria";
            // 
            // rdbtnDate
            // 
            this.rdbtnDate.AutoSize = true;
            this.rdbtnDate.Location = new System.Drawing.Point(57, 52);
            this.rdbtnDate.Name = "rdbtnDate";
            this.rdbtnDate.Size = new System.Drawing.Size(88, 21);
            this.rdbtnDate.TabIndex = 68;
            this.rdbtnDate.TabStop = true;
            this.rdbtnDate.Text = "Duration";
            this.rdbtnDate.UseVisualStyleBackColor = true;
            this.rdbtnDate.CheckedChanged += new System.EventHandler(this.rdbtnDate_CheckedChanged);
            // 
            // ddlCategory
            // 
            this.ddlCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCategory.FormattingEnabled = true;
            this.ddlCategory.Location = new System.Drawing.Point(220, 18);
            this.ddlCategory.Name = "ddlCategory";
            this.ddlCategory.Size = new System.Drawing.Size(196, 24);
            this.ddlCategory.TabIndex = 66;
            this.ddlCategory.SelectedIndexChanged += new System.EventHandler(this.ddlCategory_SelectedIndexChanged);
            // 
            // frmItemStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 497);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmItemStatus";
            this.Text = "frmItemStatus";
            this.Load += new System.EventHandler(this.frmItemStatus_Load);
            this.groupBox6.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ListView lvItemList;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.RadioButton rdbtnCatg;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtp_To;
        private System.Windows.Forms.DateTimePicker dtp_From;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbtnDate;
        private System.Windows.Forms.ComboBox ddlCategory;
    }
}