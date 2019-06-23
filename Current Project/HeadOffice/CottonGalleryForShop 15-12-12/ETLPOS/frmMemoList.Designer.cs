namespace ETLPOS
{
    partial class frmMemoList
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
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lvMemoList = new System.Windows.Forms.ListView();
            this.cSlNo = new System.Windows.Forms.ColumnHeader();
            this.cMemoNo = new System.Windows.Forms.ColumnHeader();
            this.cMemoDate = new System.Windows.Forms.ColumnHeader();
            this.cQty = new System.Windows.Forms.ColumnHeader();
            this.cTotalAmount = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "From Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "To Date:";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd:MM:yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(110, 16);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(81, 23);
            this.dtpFromDate.TabIndex = 2;
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd:MM:yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(320, 16);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(81, 23);
            this.dtpToDate.TabIndex = 3;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
            // 
            // lvMemoList
            // 
            this.lvMemoList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cSlNo,
            this.cMemoNo,
            this.cMemoDate,
            this.cQty,
            this.cTotalAmount});
            this.lvMemoList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvMemoList.FullRowSelect = true;
            this.lvMemoList.GridLines = true;
            this.lvMemoList.Location = new System.Drawing.Point(1, 75);
            this.lvMemoList.Name = "lvMemoList";
            this.lvMemoList.Size = new System.Drawing.Size(559, 437);
            this.lvMemoList.TabIndex = 4;
            this.lvMemoList.UseCompatibleStateImageBehavior = false;
            this.lvMemoList.View = System.Windows.Forms.View.Details;
            this.lvMemoList.SelectedIndexChanged += new System.EventHandler(this.lvMemoList_SelectedIndexChanged);
            this.lvMemoList.DoubleClick += new System.EventHandler(this.lvMemoList_DoubleClick);
            // 
            // cSlNo
            // 
            this.cSlNo.Text = "SL No";
            // 
            // cMemoNo
            // 
            this.cMemoNo.Text = "Memo No";
            this.cMemoNo.Width = 150;
            // 
            // cMemoDate
            // 
            this.cMemoDate.Text = "Memo Date";
            this.cMemoDate.Width = 150;
            // 
            // cQty
            // 
            this.cQty.Text = "QTY";
            // 
            // cTotalAmount
            // 
            this.cTotalAmount.Text = "Total Amount";
            this.cTotalAmount.Width = 100;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(22, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(446, 44);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date";
            // 
            // frmMemoList
            // 
            this.ClientSize = new System.Drawing.Size(559, 509);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvMemoList);
            this.Name = "frmMemoList";
            this.Text = "Memo List";
            this.Load += new System.EventHandler(this.frmMemoList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.ListView lvMemoList;
        private System.Windows.Forms.ColumnHeader cSlNo;
        private System.Windows.Forms.ColumnHeader cMemoNo;
        private System.Windows.Forms.ColumnHeader cMemoDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader cQty;
        private System.Windows.Forms.ColumnHeader cTotalAmount;
    }
}
