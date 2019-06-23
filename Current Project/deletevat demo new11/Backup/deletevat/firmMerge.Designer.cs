namespace deletevat
{
    partial class firmMerge
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
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOMstr_NetAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.txtTotalNetAmount = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpScarch = new System.Windows.Forms.DateTimePicker();
            this.btnScarch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtDeletedAmount = new System.Windows.Forms.TextBox();
            this.ddlbranch = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleaProduct)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSaleaProduct
            // 
            this.dgvSaleaProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaleaProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CSalesID,
            this.CBranch,
            this.date,
            this.SOMstr_NetAmt,
            this.Column1});
            this.dgvSaleaProduct.Location = new System.Drawing.Point(6, 53);
            this.dgvSaleaProduct.Name = "dgvSaleaProduct";
            this.dgvSaleaProduct.Size = new System.Drawing.Size(1074, 371);
            this.dgvSaleaProduct.TabIndex = 0;
            this.dgvSaleaProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSaleaProduct_CellClick_1);
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
            // date
            // 
            this.date.HeaderText = "date";
            this.date.Name = "date";
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
            this.Column1.Width = 50;
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPrice.Location = new System.Drawing.Point(791, 465);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(112, 13);
            this.lblTotalPrice.TabIndex = 3;
            this.lblTotalPrice.Text = "% of Total Deleted";
            // 
            // txtTotalNetAmount
            // 
            this.txtTotalNetAmount.Location = new System.Drawing.Point(909, 460);
            this.txtTotalNetAmount.Name = "txtTotalNetAmount";
            this.txtTotalNetAmount.Size = new System.Drawing.Size(100, 20);
            this.txtTotalNetAmount.TabIndex = 20;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ddlbranch);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.dtpScarch);
            this.groupBox3.Controls.Add(this.btnScarch);
            this.groupBox3.Controls.Add(this.dgvSaleaProduct);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(3, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1103, 430);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(305, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Date";
            // 
            // dtpScarch
            // 
            this.dtpScarch.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpScarch.Location = new System.Drawing.Point(371, 18);
            this.dtpScarch.Name = "dtpScarch";
            this.dtpScarch.Size = new System.Drawing.Size(100, 20);
            this.dtpScarch.TabIndex = 11;
            // 
            // btnScarch
            // 
            this.btnScarch.Location = new System.Drawing.Point(489, 18);
            this.btnScarch.Name = "btnScarch";
            this.btnScarch.Size = new System.Drawing.Size(75, 23);
            this.btnScarch.TabIndex = 10;
            this.btnScarch.Text = "Scarch";
            this.btnScarch.UseVisualStyleBackColor = true;
            this.btnScarch.Click += new System.EventHandler(this.btnScarch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Sales Master";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(1021, 456);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.Location = new System.Drawing.Point(573, 462);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(109, 15);
            this.lblQty.TabIndex = 29;
            this.lblQty.Text = "Deleted Amount";
            // 
            // txtDeletedAmount
            // 
            this.txtDeletedAmount.Location = new System.Drawing.Point(687, 462);
            this.txtDeletedAmount.Name = "txtDeletedAmount";
            this.txtDeletedAmount.Size = new System.Drawing.Size(100, 20);
            this.txtDeletedAmount.TabIndex = 30;
            // 
            // ddlbranch
            // 
            this.ddlbranch.FormattingEnabled = true;
            this.ddlbranch.Items.AddRange(new object[] {
            "CART  ",
            "EXCE  "});
            this.ddlbranch.Location = new System.Drawing.Point(164, 16);
            this.ddlbranch.Name = "ddlbranch";
            this.ddlbranch.Size = new System.Drawing.Size(121, 21);
            this.ddlbranch.TabIndex = 13;
            // 
            // firmMerge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 494);
            this.Controls.Add(this.txtTotalNetAmount);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.txtDeletedAmount);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox3);
            this.Name = "firmMerge";
            this.Text = "firmMerge";
            this.Load += new System.EventHandler(this.firmMerge_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleaProduct)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSaleaProduct;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.TextBox txtTotalNetAmount;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.TextBox txtDeletedAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpScarch;
        private System.Windows.Forms.Button btnScarch;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSalesID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOMstr_NetAmt;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.ComboBox ddlbranch;
    }
}