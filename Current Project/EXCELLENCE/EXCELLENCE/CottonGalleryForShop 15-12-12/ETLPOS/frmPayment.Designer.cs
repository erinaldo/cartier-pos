namespace ETLPOS
{
    partial class frmPayment
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
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlPartyName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPaymentAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCurrencyRate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPaymentInBDT = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPaymentMedia = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rbYes = new System.Windows.Forms.RadioButton();
            this.rbNo = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpPaymentReceipetDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtOId = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ddlCurrency = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lvPaymentList = new System.Windows.Forms.ListView();
            this.cSL = new System.Windows.Forms.ColumnHeader();
            this.cPartyName = new System.Windows.Forms.ColumnHeader();
            this.cPaymentDate = new System.Windows.Forms.ColumnHeader();
            this.cPaymentInBDT = new System.Windows.Forms.ColumnHeader();
            this.cPaymentMedia = new System.Windows.Forms.ColumnHeader();
            this.cReceivedStatus = new System.Windows.Forms.ColumnHeader();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Payment Date";
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.CustomFormat = "dd:MM:yyy";
            this.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPaymentDate.Location = new System.Drawing.Point(176, 47);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.Size = new System.Drawing.Size(201, 20);
            this.dtpPaymentDate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Partyt Name";
            // 
            // ddlPartyName
            // 
            this.ddlPartyName.FormattingEnabled = true;
            this.ddlPartyName.Location = new System.Drawing.Point(176, 76);
            this.ddlPartyName.Name = "ddlPartyName";
            this.ddlPartyName.Size = new System.Drawing.Size(201, 21);
            this.ddlPartyName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(125, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Amount";
            // 
            // txtPaymentAmount
            // 
            this.txtPaymentAmount.Location = new System.Drawing.Point(176, 106);
            this.txtPaymentAmount.Name = "txtPaymentAmount";
            this.txtPaymentAmount.Size = new System.Drawing.Size(201, 20);
            this.txtPaymentAmount.TabIndex = 2;
            this.txtPaymentAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPaymentAmount_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Payment Currency";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Currency Rate";
            // 
            // txtCurrencyRate
            // 
            this.txtCurrencyRate.Location = new System.Drawing.Point(176, 164);
            this.txtCurrencyRate.Name = "txtCurrencyRate";
            this.txtCurrencyRate.Size = new System.Drawing.Size(201, 20);
            this.txtCurrencyRate.TabIndex = 4;
            this.txtCurrencyRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPaymentAmount_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(83, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Payment In BDT";
            // 
            // txtPaymentInBDT
            // 
            this.txtPaymentInBDT.Location = new System.Drawing.Point(178, 193);
            this.txtPaymentInBDT.Name = "txtPaymentInBDT";
            this.txtPaymentInBDT.Size = new System.Drawing.Size(201, 20);
            this.txtPaymentInBDT.TabIndex = 5;
            this.txtPaymentInBDT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPaymentAmount_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(88, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Payment Media";
            // 
            // txtPaymentMedia
            // 
            this.txtPaymentMedia.Location = new System.Drawing.Point(178, 222);
            this.txtPaymentMedia.Name = "txtPaymentMedia";
            this.txtPaymentMedia.Size = new System.Drawing.Size(201, 20);
            this.txtPaymentMedia.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 287);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Payment Receiept Confirmation";
            // 
            // rbYes
            // 
            this.rbYes.AutoSize = true;
            this.rbYes.Location = new System.Drawing.Point(178, 284);
            this.rbYes.Name = "rbYes";
            this.rbYes.Size = new System.Drawing.Size(43, 17);
            this.rbYes.TabIndex = 8;
            this.rbYes.TabStop = true;
            this.rbYes.Text = "Yes";
            this.rbYes.UseVisualStyleBackColor = true;
            // 
            // rbNo
            // 
            this.rbNo.AutoSize = true;
            this.rbNo.Location = new System.Drawing.Point(227, 284);
            this.rbNo.Name = "rbNo";
            this.rbNo.Size = new System.Drawing.Size(39, 17);
            this.rbNo.TabIndex = 9;
            this.rbNo.TabStop = true;
            this.rbNo.Text = "No";
            this.rbNo.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(48, 254);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Payment Receipet Date";
            // 
            // dtpPaymentReceipetDate
            // 
            this.dtpPaymentReceipetDate.CustomFormat = "dd:MM:yyy";
            this.dtpPaymentReceipetDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPaymentReceipetDate.Location = new System.Drawing.Point(178, 250);
            this.dtpPaymentReceipetDate.Name = "dtpPaymentReceipetDate";
            this.dtpPaymentReceipetDate.Size = new System.Drawing.Size(201, 20);
            this.dtpPaymentReceipetDate.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtOId);
            this.groupBox3.Controls.Add(this.btnClear);
            this.groupBox3.Controls.Add(this.btnDelete);
            this.groupBox3.Controls.Add(this.btnUpdate);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Location = new System.Drawing.Point(12, 456);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(960, 49);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // txtOId
            // 
            this.txtOId.Location = new System.Drawing.Point(367, 21);
            this.txtOId.Name = "txtOId";
            this.txtOId.Size = new System.Drawing.Size(26, 20);
            this.txtOId.TabIndex = 42;
            this.txtOId.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(760, 18);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(87, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(663, 18);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(87, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(566, 18);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(87, 23);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(469, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(857, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbNo);
            this.groupBox1.Controls.Add(this.rbYes);
            this.groupBox1.Controls.Add(this.txtPaymentMedia);
            this.groupBox1.Controls.Add(this.txtPaymentInBDT);
            this.groupBox1.Controls.Add(this.txtCurrencyRate);
            this.groupBox1.Controls.Add(this.txtPaymentAmount);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ddlCurrency);
            this.groupBox1.Controls.Add(this.ddlPartyName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpPaymentReceipetDate);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.dtpPaymentDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(572, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 345);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // ddlCurrency
            // 
            this.ddlCurrency.FormattingEnabled = true;
            this.ddlCurrency.Location = new System.Drawing.Point(176, 135);
            this.ddlCurrency.Name = "ddlCurrency";
            this.ddlCurrency.Size = new System.Drawing.Size(201, 21);
            this.ddlCurrency.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpToDate);
            this.groupBox2.Controls.Add(this.dtpFromDate);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lvPaymentList);
            this.groupBox2.Location = new System.Drawing.Point(9, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(557, 440);
            this.groupBox2.TabIndex = 9;
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
            this.dtpToDate.TabIndex = 1;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd:MM:yyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(181, 21);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(82, 20);
            this.dtpFromDate.TabIndex = 0;
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
            // lvPaymentList
            // 
            this.lvPaymentList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cSL,
            this.cPartyName,
            this.cPaymentDate,
            this.cPaymentInBDT,
            this.cPaymentMedia,
            this.cReceivedStatus});
            this.lvPaymentList.FullRowSelect = true;
            this.lvPaymentList.GridLines = true;
            this.lvPaymentList.Location = new System.Drawing.Point(5, 47);
            this.lvPaymentList.Name = "lvPaymentList";
            this.lvPaymentList.Size = new System.Drawing.Size(546, 388);
            this.lvPaymentList.TabIndex = 0;
            this.lvPaymentList.UseCompatibleStateImageBehavior = false;
            this.lvPaymentList.View = System.Windows.Forms.View.Details;
            this.lvPaymentList.DoubleClick += new System.EventHandler(this.lvPaymentList_DoubleClick);
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
            // cPaymentDate
            // 
            this.cPaymentDate.Text = "Payment Date";
            this.cPaymentDate.Width = 100;
            // 
            // cPaymentInBDT
            // 
            this.cPaymentInBDT.Text = "Payment In BDT";
            this.cPaymentInBDT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cPaymentInBDT.Width = 100;
            // 
            // cPaymentMedia
            // 
            this.cPaymentMedia.Text = "Payment Media";
            this.cPaymentMedia.Width = 100;
            // 
            // cReceivedStatus
            // 
            this.cReceivedStatus.Text = "Received Status";
            this.cReceivedStatus.Width = 100;
            // 
            // frmPayment
            // 
            this.ClientSize = new System.Drawing.Size(984, 513);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "frmPayment";
            this.Text = "Payment";
            this.Load += new System.EventHandler(this.frmPayment_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlPartyName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPaymentAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCurrencyRate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPaymentInBDT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPaymentMedia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbYes;
        private System.Windows.Forms.RadioButton rbNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpPaymentReceipetDate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtOId;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lvPaymentList;
        private System.Windows.Forms.ColumnHeader cSL;
        private System.Windows.Forms.ColumnHeader cPartyName;
        private System.Windows.Forms.ColumnHeader cPaymentInBDT;
        private System.Windows.Forms.ColumnHeader cPaymentDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ColumnHeader cPaymentMedia;
        private System.Windows.Forms.ColumnHeader cReceivedStatus;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox ddlCurrency;

    }
}
