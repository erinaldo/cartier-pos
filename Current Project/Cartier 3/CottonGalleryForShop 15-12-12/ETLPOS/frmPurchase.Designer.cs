namespace ETLPOS
{
    partial class frmPurchase
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
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPurchaseQuantity = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.ddlGroupName = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ddlPartyName = new System.Windows.Forms.ComboBox();
            this.txtPurchaseAmount = new System.Windows.Forms.TextBox();
            this.txtPurchaseCurrencyRate = new System.Windows.Forms.TextBox();
            this.txtPurchaseInvoiceNo = new System.Windows.Forms.TextBox();
            this.rbNo = new System.Windows.Forms.RadioButton();
            this.rbYes = new System.Windows.Forms.RadioButton();
            this.dtpPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ddlCurrencyName = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtOId = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lvPurchasetList = new System.Windows.Forms.ListView();
            this.cSL = new System.Windows.Forms.ColumnHeader();
            this.cPartyName = new System.Windows.Forms.ColumnHeader();
            this.cGroupName = new System.Windows.Forms.ColumnHeader();
            this.cPurchaseQuantity = new System.Windows.Forms.ColumnHeader();
            this.cPurchaseDate = new System.Windows.Forms.ColumnHeader();
            this.cPurchaseAmount = new System.Windows.Forms.ColumnHeader();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(78, 325);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Status :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 287);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Purchase Date :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(65, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Invice No.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Currency Rate :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Purchase Amount :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Purchase Quantity :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Description :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Group Name :";
            // 
            // txtPurchaseQuantity
            // 
            this.txtPurchaseQuantity.Location = new System.Drawing.Point(127, 148);
            this.txtPurchaseQuantity.Name = "txtPurchaseQuantity";
            this.txtPurchaseQuantity.Size = new System.Drawing.Size(207, 20);
            this.txtPurchaseQuantity.TabIndex = 3;
            this.txtPurchaseQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPurchaseQuantity_KeyPress);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(127, 81);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(207, 58);
            this.txtDescription.TabIndex = 2;
            // 
            // ddlGroupName
            // 
            this.ddlGroupName.FormattingEnabled = true;
            this.ddlGroupName.Location = new System.Drawing.Point(127, 49);
            this.ddlGroupName.Name = "ddlGroupName";
            this.ddlGroupName.Size = new System.Drawing.Size(207, 21);
            this.ddlGroupName.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(53, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Party Name :";
            // 
            // ddlPartyName
            // 
            this.ddlPartyName.FormattingEnabled = true;
            this.ddlPartyName.Location = new System.Drawing.Point(127, 20);
            this.ddlPartyName.Name = "ddlPartyName";
            this.ddlPartyName.Size = new System.Drawing.Size(207, 21);
            this.ddlPartyName.TabIndex = 0;
            // 
            // txtPurchaseAmount
            // 
            this.txtPurchaseAmount.Location = new System.Drawing.Point(127, 176);
            this.txtPurchaseAmount.Name = "txtPurchaseAmount";
            this.txtPurchaseAmount.Size = new System.Drawing.Size(207, 20);
            this.txtPurchaseAmount.TabIndex = 4;
            this.txtPurchaseAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPurchaseQuantity_KeyPress);
            // 
            // txtPurchaseCurrencyRate
            // 
            this.txtPurchaseCurrencyRate.Location = new System.Drawing.Point(127, 231);
            this.txtPurchaseCurrencyRate.Name = "txtPurchaseCurrencyRate";
            this.txtPurchaseCurrencyRate.Size = new System.Drawing.Size(207, 20);
            this.txtPurchaseCurrencyRate.TabIndex = 6;
            // 
            // txtPurchaseInvoiceNo
            // 
            this.txtPurchaseInvoiceNo.Location = new System.Drawing.Point(127, 259);
            this.txtPurchaseInvoiceNo.Name = "txtPurchaseInvoiceNo";
            this.txtPurchaseInvoiceNo.Size = new System.Drawing.Size(207, 20);
            this.txtPurchaseInvoiceNo.TabIndex = 7;
            // 
            // rbNo
            // 
            this.rbNo.AutoSize = true;
            this.rbNo.Location = new System.Drawing.Point(176, 325);
            this.rbNo.Name = "rbNo";
            this.rbNo.Size = new System.Drawing.Size(39, 17);
            this.rbNo.TabIndex = 10;
            this.rbNo.TabStop = true;
            this.rbNo.Text = "No";
            this.rbNo.UseVisualStyleBackColor = true;
            // 
            // rbYes
            // 
            this.rbYes.AutoSize = true;
            this.rbYes.Location = new System.Drawing.Point(127, 325);
            this.rbYes.Name = "rbYes";
            this.rbYes.Size = new System.Drawing.Size(43, 17);
            this.rbYes.TabIndex = 9;
            this.rbYes.TabStop = true;
            this.rbYes.Text = "Yes";
            this.rbYes.UseVisualStyleBackColor = true;
            // 
            // dtpPurchaseDate
            // 
            this.dtpPurchaseDate.CustomFormat = "dd:MM:yyy";
            this.dtpPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPurchaseDate.Location = new System.Drawing.Point(127, 287);
            this.dtpPurchaseDate.Name = "dtpPurchaseDate";
            this.dtpPurchaseDate.Size = new System.Drawing.Size(207, 20);
            this.dtpPurchaseDate.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpPurchaseDate);
            this.groupBox1.Controls.Add(this.rbNo);
            this.groupBox1.Controls.Add(this.rbYes);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPurchaseInvoiceNo);
            this.groupBox1.Controls.Add(this.txtPurchaseCurrencyRate);
            this.groupBox1.Controls.Add(this.txtPurchaseAmount);
            this.groupBox1.Controls.Add(this.txtPurchaseQuantity);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.ddlPartyName);
            this.groupBox1.Controls.Add(this.ddlCurrencyName);
            this.groupBox1.Controls.Add(this.ddlGroupName);
            this.groupBox1.Location = new System.Drawing.Point(584, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 356);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(66, 204);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Currency :";
            // 
            // ddlCurrencyName
            // 
            this.ddlCurrencyName.FormattingEnabled = true;
            this.ddlCurrencyName.Location = new System.Drawing.Point(127, 204);
            this.ddlCurrencyName.Name = "ddlCurrencyName";
            this.ddlCurrencyName.Size = new System.Drawing.Size(207, 21);
            this.ddlCurrencyName.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtOId);
            this.groupBox3.Controls.Add(this.btnClear);
            this.groupBox3.Controls.Add(this.btnDelete);
            this.groupBox3.Controls.Add(this.btnUpdate);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Location = new System.Drawing.Point(12, 457);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(922, 49);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            // 
            // txtOId
            // 
            this.txtOId.Location = new System.Drawing.Point(268, 18);
            this.txtOId.Name = "txtOId";
            this.txtOId.Size = new System.Drawing.Size(19, 20);
            this.txtOId.TabIndex = 42;
            this.txtOId.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(661, 15);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(87, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(564, 15);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(87, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(467, 15);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(87, 23);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(370, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(758, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpToDate);
            this.groupBox2.Controls.Add(this.dtpFromDate);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lvPurchasetList);
            this.groupBox2.Location = new System.Drawing.Point(9, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(561, 447);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Payment Information";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd:MM:yyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(381, 21);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(82, 20);
            this.dtpToDate.TabIndex = 2;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd:MM:yyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(181, 21);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(82, 20);
            this.dtpFromDate.TabIndex = 2;
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(330, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "To Date:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(118, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "From Date:";
            // 
            // lvPurchasetList
            // 
            this.lvPurchasetList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cSL,
            this.cPartyName,
            this.cGroupName,
            this.cPurchaseQuantity,
            this.cPurchaseDate,
            this.cPurchaseAmount});
            this.lvPurchasetList.FullRowSelect = true;
            this.lvPurchasetList.GridLines = true;
            this.lvPurchasetList.Location = new System.Drawing.Point(5, 47);
            this.lvPurchasetList.Name = "lvPurchasetList";
            this.lvPurchasetList.Size = new System.Drawing.Size(546, 388);
            this.lvPurchasetList.TabIndex = 0;
            this.lvPurchasetList.UseCompatibleStateImageBehavior = false;
            this.lvPurchasetList.View = System.Windows.Forms.View.Details;
            this.lvPurchasetList.DoubleClick += new System.EventHandler(this.lvPurchasetList_DoubleClick);
            // 
            // cSL
            // 
            this.cSL.Text = "SL";
            this.cSL.Width = 40;
            // 
            // cPartyName
            // 
            this.cPartyName.Text = "Party Name";
            this.cPartyName.Width = 100;
            // 
            // cGroupName
            // 
            this.cGroupName.Text = "GroupName";
            this.cGroupName.Width = 100;
            // 
            // cPurchaseQuantity
            // 
            this.cPurchaseQuantity.Text = "Purchase Quantity";
            this.cPurchaseQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cPurchaseQuantity.Width = 100;
            // 
            // cPurchaseDate
            // 
            this.cPurchaseDate.Text = "Purchase Date";
            this.cPurchaseDate.Width = 100;
            // 
            // cPurchaseAmount
            // 
            this.cPurchaseAmount.Text = "Purchase Amount";
            this.cPurchaseAmount.Width = 100;
            // 
            // frmPurchase
            // 
            this.ClientSize = new System.Drawing.Size(954, 513);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPurchase";
            this.Text = "Purchase";
            this.Load += new System.EventHandler(this.frmPurchase_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPurchaseQuantity;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ComboBox ddlGroupName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox ddlPartyName;
        private System.Windows.Forms.TextBox txtPurchaseAmount;
        private System.Windows.Forms.TextBox txtPurchaseCurrencyRate;
        private System.Windows.Forms.TextBox txtPurchaseInvoiceNo;
        private System.Windows.Forms.RadioButton rbNo;
        private System.Windows.Forms.RadioButton rbYes;
        private System.Windows.Forms.DateTimePicker dtpPurchaseDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtOId;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListView lvPurchasetList;
        private System.Windows.Forms.ColumnHeader cSL;
        private System.Windows.Forms.ColumnHeader cPartyName;
        private System.Windows.Forms.ColumnHeader cGroupName;
        private System.Windows.Forms.ColumnHeader cPurchaseQuantity;
        private System.Windows.Forms.ColumnHeader cPurchaseDate;
        private System.Windows.Forms.ColumnHeader cPurchaseAmount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox ddlCurrencyName;
    }
}
