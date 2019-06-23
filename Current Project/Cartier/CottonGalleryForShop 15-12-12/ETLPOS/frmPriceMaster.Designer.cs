namespace ETLPOS
{
    partial class frmPriceMaster
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
            this.ddl_ItemName = new System.Windows.Forms.ComboBox();
            this.lblgrname = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ddlCategory = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ddlCurrency = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txt_FactoryPrice = new System.Windows.Forms.TextBox();
            this.lblRQTY = new System.Windows.Forms.Label();
            this.txtDiscPrice = new System.Windows.Forms.TextBox();
            this.txt_VATPrice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiscPer = new System.Windows.Forms.TextBox();
            this.txt_ListPrice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_VATPercent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOId = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtp_To = new System.Windows.Forms.DateTimePicker();
            this.dtp_From = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lvPriceList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.colCurrency = new System.Windows.Forms.ColumnHeader();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // ddl_ItemName
            // 
            this.ddl_ItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ddl_ItemName.FormattingEnabled = true;
            this.ddl_ItemName.Location = new System.Drawing.Point(143, 52);
            this.ddl_ItemName.Name = "ddl_ItemName";
            this.ddl_ItemName.Size = new System.Drawing.Size(383, 24);
            this.ddl_ItemName.TabIndex = 2;
            this.ddl_ItemName.SelectedIndexChanged += new System.EventHandler(this.ddl_ItemName_SelectedIndexChanged);
            this.ddl_ItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ddl_ItemName_KeyPress);
            // 
            // lblgrname
            // 
            this.lblgrname.AutoSize = true;
            this.lblgrname.Location = new System.Drawing.Point(31, 55);
            this.lblgrname.Name = "lblgrname";
            this.lblgrname.Size = new System.Drawing.Size(84, 17);
            this.lblgrname.TabIndex = 50;
            this.lblgrname.Text = "Item Name";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.ddlCategory);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.ddlCurrency);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.txtOId);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.ddl_ItemName);
            this.groupBox1.Controls.Add(this.lblgrname);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(9, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(972, 240);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item ";
            // 
            // ddlCategory
            // 
            this.ddlCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCategory.FormattingEnabled = true;
            this.ddlCategory.Location = new System.Drawing.Point(143, 22);
            this.ddlCategory.Name = "ddlCategory";
            this.ddlCategory.Size = new System.Drawing.Size(380, 24);
            this.ddlCategory.TabIndex = 1;
            this.ddlCategory.SelectedIndexChanged += new System.EventHandler(this.ddlCategory_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 17);
            this.label9.TabIndex = 65;
            this.label9.Text = "Item Category";
            // 
            // ddlCurrency
            // 
            this.ddlCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCurrency.FormattingEnabled = true;
            this.ddlCurrency.Location = new System.Drawing.Point(143, 81);
            this.ddlCurrency.Name = "ddlCurrency";
            this.ddlCurrency.Size = new System.Drawing.Size(382, 24);
            this.ddlCurrency.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 65;
            this.label5.Text = "Currency";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txt_FactoryPrice);
            this.groupBox4.Controls.Add(this.lblRQTY);
            this.groupBox4.Controls.Add(this.txtDiscPrice);
            this.groupBox4.Controls.Add(this.txt_VATPrice);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txtDiscPer);
            this.groupBox4.Controls.Add(this.txt_ListPrice);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.txt_VATPercent);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox4.Location = new System.Drawing.Point(555, 9);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(400, 218);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Price Information";
            // 
            // txt_FactoryPrice
            // 
            this.txt_FactoryPrice.Location = new System.Drawing.Point(219, 43);
            this.txt_FactoryPrice.Multiline = true;
            this.txt_FactoryPrice.Name = "txt_FactoryPrice";
            this.txt_FactoryPrice.Size = new System.Drawing.Size(141, 20);
            this.txt_FactoryPrice.TabIndex = 1;
            this.txt_FactoryPrice.Text = "0";
            this.txt_FactoryPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsValidKeyPress);
            // 
            // lblRQTY
            // 
            this.lblRQTY.AutoSize = true;
            this.lblRQTY.Location = new System.Drawing.Point(70, 45);
            this.lblRQTY.Name = "lblRQTY";
            this.lblRQTY.Size = new System.Drawing.Size(118, 17);
            this.lblRQTY.TabIndex = 41;
            this.lblRQTY.Text = "Purchase Price";
            // 
            // txtDiscPrice
            // 
            this.txtDiscPrice.Location = new System.Drawing.Point(219, 158);
            this.txtDiscPrice.Multiline = true;
            this.txtDiscPrice.Name = "txtDiscPrice";
            this.txtDiscPrice.Size = new System.Drawing.Size(141, 20);
            this.txtDiscPrice.TabIndex = 6;
            this.txtDiscPrice.Text = "0";
            this.txtDiscPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsValidKeyPress);
            // 
            // txt_VATPrice
            // 
            this.txt_VATPrice.Location = new System.Drawing.Point(219, 113);
            this.txt_VATPrice.Multiline = true;
            this.txt_VATPrice.Name = "txt_VATPrice";
            this.txt_VATPrice.Size = new System.Drawing.Size(141, 20);
            this.txt_VATPrice.TabIndex = 4;
            this.txt_VATPrice.Text = "0";
            this.txt_VATPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsValidKeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(70, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 17);
            this.label8.TabIndex = 61;
            this.label8.Text = "Discount Price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(70, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 17);
            this.label6.TabIndex = 56;
            this.label6.Text = "Sale Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 61;
            this.label3.Text = "VAT Price";
            // 
            // txtDiscPer
            // 
            this.txtDiscPer.Location = new System.Drawing.Point(219, 135);
            this.txtDiscPer.Multiline = true;
            this.txtDiscPer.Name = "txtDiscPer";
            this.txtDiscPer.Size = new System.Drawing.Size(141, 20);
            this.txtDiscPer.TabIndex = 5;
            this.txtDiscPer.Text = "0";
            this.txtDiscPer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsValidKeyPress);
            // 
            // txt_ListPrice
            // 
            this.txt_ListPrice.Location = new System.Drawing.Point(219, 65);
            this.txt_ListPrice.Multiline = true;
            this.txt_ListPrice.Name = "txt_ListPrice";
            this.txt_ListPrice.Size = new System.Drawing.Size(141, 20);
            this.txt_ListPrice.TabIndex = 2;
            this.txt_ListPrice.Text = "0";
            this.txt_ListPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsValidKeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(70, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 17);
            this.label7.TabIndex = 59;
            this.label7.Text = "Discount %";
            // 
            // txt_VATPercent
            // 
            this.txt_VATPercent.Location = new System.Drawing.Point(219, 90);
            this.txt_VATPercent.Multiline = true;
            this.txt_VATPercent.Name = "txt_VATPercent";
            this.txt_VATPercent.Size = new System.Drawing.Size(141, 20);
            this.txt_VATPercent.TabIndex = 3;
            this.txt_VATPercent.Text = "0";
            this.txt_VATPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsValidKeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 59;
            this.label4.Text = "VAT %";
            // 
            // txtOId
            // 
            this.txtOId.Location = new System.Drawing.Point(530, 51);
            this.txtOId.Multiline = true;
            this.txtOId.Name = "txtOId";
            this.txtOId.Size = new System.Drawing.Size(19, 20);
            this.txtOId.TabIndex = 63;
            this.txtOId.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtp_To);
            this.groupBox2.Controls.Add(this.dtp_From);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(24, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(429, 86);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Effective Date";
            // 
            // dtp_To
            // 
            this.dtp_To.CustomFormat = "dd-MMM-yy";
            this.dtp_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_To.Location = new System.Drawing.Point(241, 34);
            this.dtp_To.Name = "dtp_To";
            this.dtp_To.Size = new System.Drawing.Size(95, 23);
            this.dtp_To.TabIndex = 2;
            // 
            // dtp_From
            // 
            this.dtp_From.CustomFormat = "dd-MMM-yy";
            this.dtp_From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_From.Location = new System.Drawing.Point(100, 34);
            this.dtp_From.Name = "dtp_From";
            this.dtp_From.Size = new System.Drawing.Size(95, 23);
            this.dtp_From.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 17);
            this.label2.TabIndex = 53;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 51;
            this.label1.Text = "From";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(872, 17);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 31);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(783, 17);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 30);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(693, 17);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(84, 30);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Clear";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(605, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 31);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Controls.Add(this.btnReset);
            this.groupBox3.Controls.Add(this.btnDelete);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox3.Location = new System.Drawing.Point(15, 442);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(974, 60);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lvPriceList);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(14, 249);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(978, 187);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Item Price List";
            // 
            // lvPriceList
            // 
            this.lvPriceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader8,
            this.columnHeader9,
            this.colCurrency});
            this.lvPriceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPriceList.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lvPriceList.GridLines = true;
            this.lvPriceList.Location = new System.Drawing.Point(3, 19);
            this.lvPriceList.Name = "lvPriceList";
            this.lvPriceList.Size = new System.Drawing.Size(972, 165);
            this.lvPriceList.TabIndex = 0;
            this.lvPriceList.UseCompatibleStateImageBehavior = false;
            this.lvPriceList.View = System.Windows.Forms.View.Details;
            this.lvPriceList.SelectedIndexChanged += new System.EventHandler(this.lvPriceList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Item";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Date From";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Date To";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "P Price";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "S Price";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "VAT Percent";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "VAT Price";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Discount";
            this.columnHeader8.Width = 90;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Discount Price";
            this.columnHeader9.Width = 130;
            // 
            // colCurrency
            // 
            this.colCurrency.Text = "Currency";
            this.colCurrency.Width = 80;
            // 
            // frmPriceMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1010, 532);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPriceMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Price Master";
            this.Load += new System.EventHandler(this.frmPriceMaster_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ddl_ItemName;
        private System.Windows.Forms.Label lblgrname;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_From;
        private System.Windows.Forms.TextBox txtOId;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ListView lvPriceList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.DateTimePicker dtp_To;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader colCurrency;
        private System.Windows.Forms.ComboBox ddlCurrency;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_FactoryPrice;
        private System.Windows.Forms.Label lblRQTY;
        private System.Windows.Forms.TextBox txtDiscPrice;
        private System.Windows.Forms.TextBox txt_VATPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiscPer;
        private System.Windows.Forms.TextBox txt_ListPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_VATPercent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ddlCategory;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
    }
}