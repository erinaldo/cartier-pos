namespace ETLPOS
{
    partial class frmPurchaseView
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
            this.lvPurchasetList = new System.Windows.Forms.ListView();
            this.cSL = new System.Windows.Forms.ColumnHeader();
            this.cPartyName = new System.Windows.Forms.ColumnHeader();
            this.cGroupName = new System.Windows.Forms.ColumnHeader();
            this.cInvoiceNo = new System.Windows.Forms.ColumnHeader();
            this.cPurchaseDate = new System.Windows.Forms.ColumnHeader();
            this.cPurchaseQuantity = new System.Windows.Forms.ColumnHeader();
            this.cPurchaseAmount = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ddlPartyName = new System.Windows.Forms.ComboBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cCurrencyRate = new System.Windows.Forms.ColumnHeader();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvPurchasetList);
            this.groupBox2.Location = new System.Drawing.Point(12, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(718, 307);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Purchase Information";
            // 
            // lvPurchasetList
            // 
            this.lvPurchasetList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cSL,
            this.cPartyName,
            this.cGroupName,
            this.cInvoiceNo,
            this.cPurchaseDate,
            this.cPurchaseQuantity,
            this.cPurchaseAmount,
            this.cCurrencyRate});
            this.lvPurchasetList.FullRowSelect = true;
            this.lvPurchasetList.GridLines = true;
            this.lvPurchasetList.Location = new System.Drawing.Point(6, 19);
            this.lvPurchasetList.Name = "lvPurchasetList";
            this.lvPurchasetList.Size = new System.Drawing.Size(706, 283);
            this.lvPurchasetList.TabIndex = 1;
            this.lvPurchasetList.UseCompatibleStateImageBehavior = false;
            this.lvPurchasetList.View = System.Windows.Forms.View.Details;
            // 
            // cSL
            // 
            this.cSL.Text = "SL";
            this.cSL.Width = 40;
            // 
            // cPartyName
            // 
            this.cPartyName.Text = "Party Name";
            this.cPartyName.Width = 200;
            // 
            // cGroupName
            // 
            this.cGroupName.Text = "Group Name";
            this.cGroupName.Width = 80;
            // 
            // cInvoiceNo
            // 
            this.cInvoiceNo.Text = "Invoice No";
            this.cInvoiceNo.Width = 70;
            // 
            // cPurchaseDate
            // 
            this.cPurchaseDate.Text = "P. Date";
            this.cPurchaseDate.Width = 80;
            // 
            // cPurchaseQuantity
            // 
            this.cPurchaseQuantity.Text = "P.  Qty";
            this.cPurchaseQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cPurchaseAmount
            // 
            this.cPurchaseAmount.Text = "Purchase Amount";
            this.cPurchaseAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cPurchaseAmount.Width = 100;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ddlPartyName);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(36, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(636, 54);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // ddlPartyName
            // 
            this.ddlPartyName.FormattingEnabled = true;
            this.ddlPartyName.Location = new System.Drawing.Point(86, 22);
            this.ddlPartyName.Name = "ddlPartyName";
            this.ddlPartyName.Size = new System.Drawing.Size(168, 21);
            this.ddlPartyName.TabIndex = 3;
            this.ddlPartyName.SelectedIndexChanged += new System.EventHandler(this.ddlPartyName_SelectedIndexChanged);
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd:MM:yyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(518, 19);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(82, 20);
            this.dtpToDate.TabIndex = 2;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd:MM:yyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(348, 19);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(82, 20);
            this.dtpFromDate.TabIndex = 2;
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(467, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "To Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Party Name:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(285, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "From Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(621, 394);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "TK";
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.Location = new System.Drawing.Point(502, 391);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.Size = new System.Drawing.Size(116, 20);
            this.txtGrandTotal.TabIndex = 16;
            this.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(408, 394);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Grand Total:";
            // 
            // cCurrencyRate
            // 
            this.cCurrencyRate.Text = "C. Rate";
            // 
            // frmPurchaseView
            // 
            this.ClientSize = new System.Drawing.Size(742, 418);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtGrandTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmPurchaseView";
            this.Text = "Purchase View";
            this.Load += new System.EventHandler(this.frmPurchaseView_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ddlPartyName;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListView lvPurchasetList;
        private System.Windows.Forms.ColumnHeader cSL;
        private System.Windows.Forms.ColumnHeader cPartyName;
        private System.Windows.Forms.ColumnHeader cGroupName;
        private System.Windows.Forms.ColumnHeader cInvoiceNo;
        private System.Windows.Forms.ColumnHeader cPurchaseDate;
        private System.Windows.Forms.ColumnHeader cPurchaseQuantity;
        private System.Windows.Forms.ColumnHeader cPurchaseAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGrandTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader cCurrencyRate;
    }
}
