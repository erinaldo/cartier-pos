namespace ETLPOS
{
    partial class Return_Product
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnGoodReceive = new System.Windows.Forms.Button();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtbarcode = new System.Windows.Forms.TextBox();
            this.dgvSaleItemList = new System.Windows.Forms.DataGridView();
            this.chSLNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chItemOId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chVatPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chUOMOID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chCurrencyOID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chDiscountAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chVatValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chTotalValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReturn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDiscountAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleItemList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGoodReceive
            // 
            this.btnGoodReceive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoodReceive.Location = new System.Drawing.Point(378, 19);
            this.btnGoodReceive.Name = "btnGoodReceive";
            this.btnGoodReceive.Size = new System.Drawing.Size(23, 25);
            this.btnGoodReceive.TabIndex = 10;
            this.btnGoodReceive.TabStop = false;
            this.btnGoodReceive.Text = "+";
            this.btnGoodReceive.UseVisualStyleBackColor = true;
            // 
            // txtItemName
            // 
            this.txtItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(118, 49);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(254, 22);
            this.txtItemName.TabIndex = 9;
            this.txtItemName.TabStop = false;
            this.txtItemName.TextChanged += new System.EventHandler(this.txtItemName_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(38, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Item Name :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(41, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Item Code :";
            // 
            // txtbarcode
            // 
            this.txtbarcode.BackColor = System.Drawing.SystemColors.Window;
            this.txtbarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbarcode.Location = new System.Drawing.Point(118, 19);
            this.txtbarcode.Name = "txtbarcode";
            this.txtbarcode.Size = new System.Drawing.Size(254, 22);
            this.txtbarcode.TabIndex = 4;
            this.txtbarcode.TextChanged += new System.EventHandler(this.txtbarcode_TextChanged);
            // 
            // dgvSaleItemList
            // 
            this.dgvSaleItemList.AllowUserToDeleteRows = false;
            this.dgvSaleItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaleItemList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chSLNum,
            this.chItemOId,
            this.chItemName,
            this.chRate,
            this.chVatPercent,
            this.chQty,
            this.chUOMOID,
            this.chValue,
            this.chCurrencyOID,
            this.chDiscountAmount,
            this.chVatValue,
            this.chTotalValue,
            this.cPPrice});
            this.dgvSaleItemList.Location = new System.Drawing.Point(8, 106);
            this.dgvSaleItemList.MultiSelect = false;
            this.dgvSaleItemList.Name = "dgvSaleItemList";
            this.dgvSaleItemList.ReadOnly = true;
            this.dgvSaleItemList.RowHeadersWidth = 24;
            this.dgvSaleItemList.Size = new System.Drawing.Size(540, 213);
            this.dgvSaleItemList.TabIndex = 11;
            // 
            // chSLNum
            // 
            this.chSLNum.HeaderText = "SL#";
            this.chSLNum.Name = "chSLNum";
            this.chSLNum.ReadOnly = true;
            this.chSLNum.Width = 30;
            // 
            // chItemOId
            // 
            this.chItemOId.HeaderText = "ItemOId";
            this.chItemOId.Name = "chItemOId";
            this.chItemOId.ReadOnly = true;
            this.chItemOId.Visible = false;
            // 
            // chItemName
            // 
            this.chItemName.HeaderText = "Name";
            this.chItemName.Name = "chItemName";
            this.chItemName.ReadOnly = true;
            this.chItemName.Width = 160;
            // 
            // chRate
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.chRate.DefaultCellStyle = dataGridViewCellStyle1;
            this.chRate.HeaderText = "Rate";
            this.chRate.Name = "chRate";
            this.chRate.ReadOnly = true;
            this.chRate.Width = 50;
            // 
            // chVatPercent
            // 
            this.chVatPercent.HeaderText = "Vat Percent";
            this.chVatPercent.Name = "chVatPercent";
            this.chVatPercent.ReadOnly = true;
            this.chVatPercent.Visible = false;
            // 
            // chQty
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.chQty.DefaultCellStyle = dataGridViewCellStyle2;
            this.chQty.HeaderText = "Qty";
            this.chQty.Name = "chQty";
            this.chQty.ReadOnly = true;
            this.chQty.Width = 45;
            // 
            // chUOMOID
            // 
            this.chUOMOID.HeaderText = "UOMOID";
            this.chUOMOID.Name = "chUOMOID";
            this.chUOMOID.ReadOnly = true;
            this.chUOMOID.Visible = false;
            // 
            // chValue
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.chValue.DefaultCellStyle = dataGridViewCellStyle3;
            this.chValue.HeaderText = "Value";
            this.chValue.Name = "chValue";
            this.chValue.ReadOnly = true;
            this.chValue.Width = 48;
            // 
            // chCurrencyOID
            // 
            this.chCurrencyOID.HeaderText = "CurrencyOID";
            this.chCurrencyOID.Name = "chCurrencyOID";
            this.chCurrencyOID.ReadOnly = true;
            this.chCurrencyOID.Visible = false;
            // 
            // chDiscountAmount
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.chDiscountAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.chDiscountAmount.HeaderText = "Disc";
            this.chDiscountAmount.Name = "chDiscountAmount";
            this.chDiscountAmount.ReadOnly = true;
            this.chDiscountAmount.Width = 48;
            // 
            // chVatValue
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.chVatValue.DefaultCellStyle = dataGridViewCellStyle5;
            this.chVatValue.HeaderText = "Vat";
            this.chVatValue.Name = "chVatValue";
            this.chVatValue.ReadOnly = true;
            this.chVatValue.Width = 48;
            // 
            // chTotalValue
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.chTotalValue.DefaultCellStyle = dataGridViewCellStyle6;
            this.chTotalValue.HeaderText = "Total";
            this.chTotalValue.Name = "chTotalValue";
            this.chTotalValue.ReadOnly = true;
            this.chTotalValue.Width = 85;
            // 
            // cPPrice
            // 
            this.cPPrice.HeaderText = "PPrice";
            this.cPPrice.Name = "cPPrice";
            this.cPPrice.ReadOnly = true;
            this.cPPrice.Visible = false;
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(446, 10);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(103, 36);
            this.btnReturn.TabIndex = 12;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDiscountAmount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dgvSaleItemList);
            this.groupBox1.Controls.Add(this.txtItemName);
            this.groupBox1.Controls.Add(this.btnGoodReceive);
            this.groupBox1.Controls.Add(this.txtbarcode);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(5, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(558, 328);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // txtDiscountAmount
            // 
            this.txtDiscountAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscountAmount.Location = new System.Drawing.Point(118, 77);
            this.txtDiscountAmount.Name = "txtDiscountAmount";
            this.txtDiscountAmount.Size = new System.Drawing.Size(254, 22);
            this.txtDiscountAmount.TabIndex = 13;
            this.txtDiscountAmount.TabStop = false;
            this.txtDiscountAmount.Text = "0";
            this.txtDiscountAmount.TextChanged += new System.EventHandler(this.txtDiscountAmount_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Discount Amount:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnReturn);
            this.groupBox2.Location = new System.Drawing.Point(5, 332);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(558, 51);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            // 
            // Return_Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 398);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Return_Product";
            this.Text = "Return_Product";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleItemList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGoodReceive;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtbarcode;
        private System.Windows.Forms.DataGridView dgvSaleItemList;
        private System.Windows.Forms.DataGridViewTextBoxColumn chSLNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn chItemOId;
        private System.Windows.Forms.DataGridViewTextBoxColumn chItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn chRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn chVatPercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn chQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn chUOMOID;
        private System.Windows.Forms.DataGridViewTextBoxColumn chValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn chCurrencyOID;
        private System.Windows.Forms.DataGridViewTextBoxColumn chDiscountAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn chVatValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn chTotalValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPPrice;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDiscountAmount;
        private System.Windows.Forms.Label label1;
    }
}