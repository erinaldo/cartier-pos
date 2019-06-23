namespace deletevat
{
    partial class GoodsReceive
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
            this.dgvGoodsReceive = new System.Windows.Forms.DataGridView();
            this.Rec_OID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rec_ReqID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rec_IssueID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rec_BranchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rec_ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rec_WantedQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rec_IssueQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rec_Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rec_ReceivedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoodsReceive)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvGoodsReceive
            // 
            this.dgvGoodsReceive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGoodsReceive.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rec_OID,
            this.Rec_ReqID,
            this.Rec_IssueID,
            this.Rec_BranchID,
            this.Rec_ProductID,
            this.Rec_WantedQTY,
            this.Rec_IssueQTY,
            this.Rec_Remark,
            this.Rec_ReceivedQty,
            this.Column1});
            this.dgvGoodsReceive.Location = new System.Drawing.Point(7, 41);
            this.dgvGoodsReceive.Name = "dgvGoodsReceive";
            this.dgvGoodsReceive.Size = new System.Drawing.Size(1063, 261);
            this.dgvGoodsReceive.TabIndex = 0;
            this.dgvGoodsReceive.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGoodsReceive_CellClick);
            // 
            // Rec_OID
            // 
            this.Rec_OID.HeaderText = "GR  ID";
            this.Rec_OID.Name = "Rec_OID";
            this.Rec_OID.Width = 160;
            // 
            // Rec_ReqID
            // 
            this.Rec_ReqID.HeaderText = "GR Req";
            this.Rec_ReqID.Name = "Rec_ReqID";
            // 
            // Rec_IssueID
            // 
            this.Rec_IssueID.HeaderText = "GR IssueID";
            this.Rec_IssueID.Name = "Rec_IssueID";
            // 
            // Rec_BranchID
            // 
            this.Rec_BranchID.HeaderText = "GRBranch ID";
            this.Rec_BranchID.Name = "Rec_BranchID";
            // 
            // Rec_ProductID
            // 
            this.Rec_ProductID.HeaderText = "GRProduct ID";
            this.Rec_ProductID.Name = "Rec_ProductID";
            // 
            // Rec_WantedQTY
            // 
            this.Rec_WantedQTY.HeaderText = "GR WantedQTY";
            this.Rec_WantedQTY.Name = "Rec_WantedQTY";
            // 
            // Rec_IssueQTY
            // 
            this.Rec_IssueQTY.HeaderText = "GR IssueQTY";
            this.Rec_IssueQTY.Name = "Rec_IssueQTY";
            // 
            // Rec_Remark
            // 
            this.Rec_Remark.HeaderText = "GR Remark";
            this.Rec_Remark.Name = "Rec_Remark";
            // 
            // Rec_ReceivedQty
            // 
            this.Rec_ReceivedQty.HeaderText = "GR ReceivedQty";
            this.Rec_ReceivedQty.Name = "Rec_ReceivedQty";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Delete";
            this.Column1.Name = "Column1";
            this.Column1.Text = "Delete";
            this.Column1.UseColumnTextForButtonValue = true;
            this.Column1.Width = 60;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1032, 358);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dgvGoodsReceive);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1095, 310);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Good Receive ";
            // 
            // GoodsReceive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 409);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Name = "GoodsReceive";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GoodsReceive";
            this.Load += new System.EventHandler(this.GoodsReceive_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoodsReceive)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGoodsReceive;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rec_OID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rec_ReqID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rec_IssueID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rec_BranchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rec_ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rec_WantedQTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rec_IssueQTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rec_Remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rec_ReceivedQty;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
    }
}