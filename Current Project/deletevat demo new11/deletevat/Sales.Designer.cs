namespace deletevat
{
    partial class Sales
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
            this.dgvSaleaProduct = new System.Windows.Forms.DataGridView();
            this.CSalesID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOMstr_TotalAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOMstr_NetAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dgvSaleaDetails = new System.Windows.Forms.DataGridView();
            this.SODet_OID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SODet_Branch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SODet_QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SODet_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SODet_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SODet_SDValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SODet_SDAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SODet_VATValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SODet_VATAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SODet_Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SODet_NetAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTotaln = new System.Windows.Forms.TextBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.txtSaleaVatAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtTotalNetAmount = new System.Windows.Forms.TextBox();
            this.lblSubTotalAmount = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleaProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleaDetails)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSaleaProduct
            // 
            this.dgvSaleaProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaleaProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CSalesID,
            this.CBranch,
            this.CCode,
            this.CDate,
            this.SOMstr_TotalAmt,
            this.SOMstr_NetAmt,
            this.Column1});
            this.dgvSaleaProduct.Location = new System.Drawing.Point(6, 41);
            this.dgvSaleaProduct.Name = "dgvSaleaProduct";
            this.dgvSaleaProduct.Size = new System.Drawing.Size(615, 270);
            this.dgvSaleaProduct.TabIndex = 0;
            this.dgvSaleaProduct.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSaleaProduct_CellContentDoubleClick);
            this.dgvSaleaProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSaleaProduct_CellClick);
            // 
            // CSalesID
            // 
            this.CSalesID.HeaderText = "ID";
            this.CSalesID.Name = "CSalesID";
            this.CSalesID.Width = 160;
            // 
            // CBranch
            // 
            this.CBranch.HeaderText = "Branch";
            this.CBranch.Name = "CBranch";
            // 
            // CCode
            // 
            this.CCode.HeaderText = "Code";
            this.CCode.Name = "CCode";
            // 
            // CDate
            // 
            this.CDate.HeaderText = "Date";
            this.CDate.Name = "CDate";
            // 
            // SOMstr_TotalAmt
            // 
            this.SOMstr_TotalAmt.HeaderText = "Total Amt";
            this.SOMstr_TotalAmt.Name = "SOMstr_TotalAmt";
            // 
            // SOMstr_NetAmt
            // 
            this.SOMstr_NetAmt.HeaderText = "Net Amt";
            this.SOMstr_NetAmt.Name = "SOMstr_NetAmt";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Delete";
            this.Column1.Name = "Column1";
            this.Column1.Text = "Delete";
            this.Column1.ToolTipText = "Delete";
            this.Column1.UseColumnTextForButtonValue = true;
            this.Column1.Width = 70;
            // 
            // dgvSaleaDetails
            // 
            this.dgvSaleaDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaleaDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SODet_OID,
            this.SODet_Branch,
            this.SODet_QTY,
            this.SODet_Price,
            this.SODet_Amount,
            this.SODet_SDValue,
            this.SODet_SDAmount,
            this.SODet_VATValue,
            this.SODet_VATAmount,
            this.SODet_Discount,
            this.SODet_NetAmount,
            this.Column5});
            this.dgvSaleaDetails.Location = new System.Drawing.Point(6, 41);
            this.dgvSaleaDetails.Name = "dgvSaleaDetails";
            this.dgvSaleaDetails.Size = new System.Drawing.Size(627, 270);
            this.dgvSaleaDetails.TabIndex = 1;
            this.dgvSaleaDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSaleaDetails_CellClick);
            // 
            // SODet_OID
            // 
            this.SODet_OID.HeaderText = "ID";
            this.SODet_OID.Name = "SODet_OID";
            this.SODet_OID.Width = 160;
            // 
            // SODet_Branch
            // 
            this.SODet_Branch.HeaderText = "Branch";
            this.SODet_Branch.Name = "SODet_Branch";
            // 
            // SODet_QTY
            // 
            this.SODet_QTY.HeaderText = "Quantity";
            this.SODet_QTY.Name = "SODet_QTY";
            // 
            // SODet_Price
            // 
            this.SODet_Price.HeaderText = "Price";
            this.SODet_Price.Name = "SODet_Price";
            // 
            // SODet_Amount
            // 
            this.SODet_Amount.HeaderText = "Amount";
            this.SODet_Amount.Name = "SODet_Amount";
            // 
            // SODet_SDValue
            // 
            this.SODet_SDValue.HeaderText = "SDValue";
            this.SODet_SDValue.Name = "SODet_SDValue";
            // 
            // SODet_SDAmount
            // 
            this.SODet_SDAmount.HeaderText = "SDAmount";
            this.SODet_SDAmount.Name = "SODet_SDAmount";
            // 
            // SODet_VATValue
            // 
            this.SODet_VATValue.HeaderText = "VATValue";
            this.SODet_VATValue.Name = "SODet_VATValue";
            // 
            // SODet_VATAmount
            // 
            this.SODet_VATAmount.HeaderText = "VATAmount";
            this.SODet_VATAmount.Name = "SODet_VATAmount";
            // 
            // SODet_Discount
            // 
            this.SODet_Discount.HeaderText = "Discount";
            this.SODet_Discount.Name = "SODet_Discount";
            // 
            // SODet_NetAmount
            // 
            this.SODet_NetAmount.HeaderText = "Net Amount";
            this.SODet_NetAmount.Name = "SODet_NetAmount";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Delete";
            this.Column5.Name = "Column5";
            this.Column5.Text = "Delete";
            this.Column5.ToolTipText = "Delete";
            this.Column5.UseColumnTextForButtonValue = true;
            this.Column5.Width = 70;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(1126, 376);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Location = new System.Drawing.Point(10, 13);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(70, 13);
            this.lblTotalPrice.TabIndex = 3;
            this.lblTotalPrice.Text = "Total Amount";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(95, 11);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(100, 20);
            this.txtTotalPrice.TabIndex = 4;
            this.txtTotalPrice.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTotaln);
            this.groupBox1.Controls.Add(this.txtTotalAmount);
            this.groupBox1.Controls.Add(this.lblTotalPrice);
            this.groupBox1.Controls.Add(this.txtTotalPrice);
            this.groupBox1.Controls.Add(this.txtSaleaVatAmount);
            this.groupBox1.Location = new System.Drawing.Point(1006, 335);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(203, 36);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // txtTotaln
            // 
            this.txtTotaln.Location = new System.Drawing.Point(96, 12);
            this.txtTotaln.Name = "txtTotaln";
            this.txtTotaln.Size = new System.Drawing.Size(100, 20);
            this.txtTotaln.TabIndex = 19;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(96, 12);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(100, 20);
            this.txtTotalAmount.TabIndex = 19;
            this.txtTotalAmount.Visible = false;
            // 
            // txtSaleaVatAmount
            // 
            this.txtSaleaVatAmount.Location = new System.Drawing.Point(96, 11);
            this.txtSaleaVatAmount.Name = "txtSaleaVatAmount";
            this.txtSaleaVatAmount.Size = new System.Drawing.Size(100, 20);
            this.txtSaleaVatAmount.TabIndex = 18;
            this.txtSaleaVatAmount.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Sales Master";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "Sales Details";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvSaleaProduct);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(11, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(627, 317);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvSaleaDetails);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(642, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(639, 317);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            // 
            // txtTotalNetAmount
            // 
            this.txtTotalNetAmount.Location = new System.Drawing.Point(109, 12);
            this.txtTotalNetAmount.Name = "txtTotalNetAmount";
            this.txtTotalNetAmount.Size = new System.Drawing.Size(100, 20);
            this.txtTotalNetAmount.TabIndex = 15;
            // 
            // lblSubTotalAmount
            // 
            this.lblSubTotalAmount.AutoSize = true;
            this.lblSubTotalAmount.Location = new System.Drawing.Point(6, 15);
            this.lblSubTotalAmount.Name = "lblSubTotalAmount";
            this.lblSubTotalAmount.Size = new System.Drawing.Size(93, 13);
            this.lblSubTotalAmount.TabIndex = 16;
            this.lblSubTotalAmount.Text = "Total Net Amount:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSubTotalAmount);
            this.groupBox2.Controls.Add(this.txtTotalNetAmount);
            this.groupBox2.Location = new System.Drawing.Point(382, 336);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(215, 39);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // Sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 410);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Sales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Data Delete";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleaProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleaDetails)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSaleaProduct;
        private System.Windows.Forms.DataGridView dgvSaleaDetails;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtTotalNetAmount;
        private System.Windows.Forms.Label lblSubTotalAmount;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSaleaVatAmount;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.TextBox txtTotaln;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSalesID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOMstr_TotalAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOMstr_NetAmt;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SODet_OID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SODet_Branch;
        private System.Windows.Forms.DataGridViewTextBoxColumn SODet_QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn SODet_Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn SODet_Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SODet_SDValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn SODet_SDAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SODet_VATValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn SODet_VATAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SODet_Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SODet_NetAmount;
        private System.Windows.Forms.DataGridViewButtonColumn Column5;
    }
}

