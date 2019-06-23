namespace ETLPOS
{
    partial class frmsticker
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtArticle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lvItem = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnclear = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtnum = new System.Windows.Forms.TextBox();
            this.cmbItemName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnpreview = new System.Windows.Forms.Button();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lvItemName = new System.Windows.Forms.ListView();
            this.cSL = new System.Windows.Forms.ColumnHeader();
            this.cItemCode = new System.Windows.Forms.ColumnHeader();
            this.cItemName = new System.Windows.Forms.ColumnHeader();
            this.cTotalSticker = new System.Windows.Forms.ColumnHeader();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtArticle);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lvItem);
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.btnclear);
            this.groupBox1.Controls.Add(this.btnInsert);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtnum);
            this.groupBox1.Controls.Add(this.cmbItemName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(361, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(561, 360);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Item";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(384, 50);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 76;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.Enter += new System.EventHandler(this.btnSearch_Enter);
            // 
            // txtArticle
            // 
            this.txtArticle.Location = new System.Drawing.Point(144, 50);
            this.txtArticle.Name = "txtArticle";
            this.txtArticle.Size = new System.Drawing.Size(216, 23);
            this.txtArticle.TabIndex = 75;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 17);
            this.label5.TabIndex = 74;
            this.label5.Text = "Article  No:";
            // 
            // lvItem
            // 
            this.lvItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvItem.FullRowSelect = true;
            this.lvItem.GridLines = true;
            this.lvItem.Location = new System.Drawing.Point(82, 194);
            this.lvItem.Name = "lvItem";
            this.lvItem.Size = new System.Drawing.Size(449, 149);
            this.lvItem.TabIndex = 73;
            this.lvItem.UseCompatibleStateImageBehavior = false;
            this.lvItem.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Item Code";
            this.columnHeader1.Width = 83;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Item Name";
            this.columnHeader2.Width = 170;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Number of Sticker";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Price ";
            this.columnHeader4.Width = 88;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(421, 158);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(55, 28);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnclear
            // 
            this.btnclear.Location = new System.Drawing.Point(478, 158);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(53, 28);
            this.btnclear.TabIndex = 2;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(366, 158);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(53, 28);
            this.btnInsert.TabIndex = 2;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(314, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 17);
            this.label1.TabIndex = 71;
            this.label1.Text = "Number Sticker:";
            // 
            // txtnum
            // 
            this.txtnum.Location = new System.Drawing.Point(437, 114);
            this.txtnum.Name = "txtnum";
            this.txtnum.Size = new System.Drawing.Size(98, 23);
            this.txtnum.TabIndex = 1;
            this.txtnum.Text = "0";
            this.txtnum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnum_KeyPress);
            // 
            // cmbItemName
            // 
            this.cmbItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbItemName.FormattingEnabled = true;
            this.cmbItemName.Location = new System.Drawing.Point(6, 137);
            this.cmbItemName.Name = "cmbItemName";
            this.cmbItemName.Size = new System.Drawing.Size(354, 24);
            this.cmbItemName.Sorted = true;
            this.cmbItemName.TabIndex = 0;
            this.cmbItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbItemName_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 17);
            this.label4.TabIndex = 68;
            this.label4.Text = "Select Item Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.btnpreview);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(361, 363);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 57);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(366, 13);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 29);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnpreview
            // 
            this.btnpreview.Location = new System.Drawing.Point(285, 13);
            this.btnpreview.Name = "btnpreview";
            this.btnpreview.Size = new System.Drawing.Size(75, 29);
            this.btnpreview.TabIndex = 0;
            this.btnpreview.Text = "Preview";
            this.btnpreview.UseVisualStyleBackColor = true;
            this.btnpreview.Click += new System.EventHandler(this.btnpreview_Click);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd:MM:yyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(94, 26);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(84, 23);
            this.dtpFromDate.TabIndex = 2;
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd:MM:yyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(254, 26);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(85, 23);
            this.dtpToDate.TabIndex = 3;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lvItemName);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.dtpToDate);
            this.groupBox3.Controls.Add(this.dtpFromDate);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(6, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(350, 341);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // lvItemName
            // 
            this.lvItemName.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cSL,
            this.cItemCode,
            this.cItemName,
            this.cTotalSticker});
            this.lvItemName.FullRowSelect = true;
            this.lvItemName.Location = new System.Drawing.Point(6, 56);
            this.lvItemName.Name = "lvItemName";
            this.lvItemName.Size = new System.Drawing.Size(319, 243);
            this.lvItemName.TabIndex = 6;
            this.lvItemName.UseCompatibleStateImageBehavior = false;
            this.lvItemName.View = System.Windows.Forms.View.Details;
            this.lvItemName.DoubleClick += new System.EventHandler(this.lvItemName_DoubleClick);
            // 
            // cSL
            // 
            this.cSL.Text = "SL";
            this.cSL.Width = 40;
            // 
            // cItemCode
            // 
            this.cItemCode.Text = "Item Code";
            this.cItemCode.Width = 75;
            // 
            // cItemName
            // 
            this.cItemName.Text = "Item Name";
            this.cItemName.Width = 140;
            // 
            // cTotalSticker
            // 
            this.cTotalSticker.Text = "Total Qty";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(180, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "To Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "From Date:";
            // 
            // frmsticker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 432);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmsticker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print Item Sticker";
            this.Load += new System.EventHandler(this.frmsticker_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtnum;
        private System.Windows.Forms.ComboBox cmbItemName;
        private System.Windows.Forms.ListView lvItem;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnpreview;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvItemName;
        private System.Windows.Forms.ColumnHeader cSL;
        private System.Windows.Forms.ColumnHeader cItemName;
        private System.Windows.Forms.ColumnHeader cItemCode;
        private System.Windows.Forms.ColumnHeader cTotalSticker;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtArticle;
        private System.Windows.Forms.Label label5;
    }
}