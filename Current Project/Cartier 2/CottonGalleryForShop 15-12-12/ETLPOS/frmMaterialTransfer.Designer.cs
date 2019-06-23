namespace ETLPOS
{
    partial class frmMaterialTransfer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtDeliverOrder = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgItemList = new System.Windows.Forms.DataGridView();
            this.CheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colItem = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIssueqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIssueUOM = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colSrcBranch = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colSourceLoc = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colSrcInvType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colDesBranch = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colDesLocation = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colDesInvType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colFinalQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCopy = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnDelelefrmList = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSelectedMTOID = new System.Windows.Forms.TextBox();
            this.dtpMTDate = new System.Windows.Forms.DateTimePicker();
            this.btnDeliverOrder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItemList)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDeliverOrder
            // 
            this.txtDeliverOrder.Location = new System.Drawing.Point(288, 35);
            this.txtDeliverOrder.Name = "txtDeliverOrder";
            this.txtDeliverOrder.ReadOnly = true;
            this.txtDeliverOrder.Size = new System.Drawing.Size(161, 20);
            this.txtDeliverOrder.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(545, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Date";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(936, 475);
            this.panel2.TabIndex = 10;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgItemList);
            this.groupBox4.Controls.Add(this.btnDelelefrmList);
            this.groupBox4.Location = new System.Drawing.Point(11, 108);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(913, 302);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Material Transfer";
            // 
            // dgItemList
            // 
            this.dgItemList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgItemList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgItemList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItemList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckBox,
            this.colItem,
            this.colItemName,
            this.colInvQty,
            this.colIssueqty,
            this.colIssueUOM,
            this.colSrcBranch,
            this.colSourceLoc,
            this.colSrcInvType,
            this.colDesBranch,
            this.colDesLocation,
            this.colDesInvType,
            this.colFinalQty,
            this.colCopy});
            this.dgItemList.Location = new System.Drawing.Point(11, 24);
            this.dgItemList.Name = "dgItemList";
            this.dgItemList.RowHeadersWidth = 30;
            this.dgItemList.Size = new System.Drawing.Size(891, 244);
            this.dgItemList.TabIndex = 17;
            this.dgItemList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgItemList_CellValueChanged);
            this.dgItemList.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgItemList_RowsAdded);
            this.dgItemList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgItemList_CellContentClick);
            // 
            // CheckBox
            // 
            this.CheckBox.FillWeight = 20F;
            this.CheckBox.Frozen = true;
            this.CheckBox.HeaderText = "";
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.Width = 20;
            // 
            // colItem
            // 
            this.colItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colItem.HeaderText = "Item";
            this.colItem.Name = "colItem";
            // 
            // colItemName
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colItemName.DefaultCellStyle = dataGridViewCellStyle2;
            this.colItemName.HeaderText = "Item Name";
            this.colItemName.Name = "colItemName";
            this.colItemName.ReadOnly = true;
            this.colItemName.Width = 120;
            // 
            // colInvQty
            // 
            this.colInvQty.HeaderText = "Inv Qty";
            this.colInvQty.Name = "colInvQty";
            this.colInvQty.ReadOnly = true;
            this.colInvQty.Width = 50;
            // 
            // colIssueqty
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colIssueqty.DefaultCellStyle = dataGridViewCellStyle3;
            this.colIssueqty.HeaderText = "Qty";
            this.colIssueqty.Name = "colIssueqty";
            this.colIssueqty.Width = 50;
            // 
            // colIssueUOM
            // 
            this.colIssueUOM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colIssueUOM.HeaderText = "UOM";
            this.colIssueUOM.Name = "colIssueUOM";
            this.colIssueUOM.Width = 50;
            // 
            // colSrcBranch
            // 
            this.colSrcBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colSrcBranch.HeaderText = "Source Branch";
            this.colSrcBranch.Name = "colSrcBranch";
            this.colSrcBranch.Width = 70;
            // 
            // colSourceLoc
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSourceLoc.DefaultCellStyle = dataGridViewCellStyle4;
            this.colSourceLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colSourceLoc.HeaderText = "Source Loc";
            this.colSourceLoc.Name = "colSourceLoc";
            this.colSourceLoc.Width = 70;
            // 
            // colSrcInvType
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSrcInvType.DefaultCellStyle = dataGridViewCellStyle5;
            this.colSrcInvType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colSrcInvType.HeaderText = "Inv Type";
            this.colSrcInvType.Name = "colSrcInvType";
            this.colSrcInvType.Width = 80;
            // 
            // colDesBranch
            // 
            this.colDesBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colDesBranch.HeaderText = "Destination Branch";
            this.colDesBranch.Name = "colDesBranch";
            this.colDesBranch.Width = 70;
            // 
            // colDesLocation
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDesLocation.DefaultCellStyle = dataGridViewCellStyle6;
            this.colDesLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colDesLocation.HeaderText = "Destination Loc";
            this.colDesLocation.Name = "colDesLocation";
            this.colDesLocation.Width = 70;
            // 
            // colDesInvType
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDesInvType.DefaultCellStyle = dataGridViewCellStyle7;
            this.colDesInvType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colDesInvType.HeaderText = "Inv Type";
            this.colDesInvType.Name = "colDesInvType";
            this.colDesInvType.Width = 80;
            // 
            // colFinalQty
            // 
            this.colFinalQty.HeaderText = "FQty";
            this.colFinalQty.Name = "colFinalQty";
            this.colFinalQty.Visible = false;
            // 
            // colCopy
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Blue;
            this.colCopy.DefaultCellStyle = dataGridViewCellStyle8;
            this.colCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colCopy.HeaderText = "Copy";
            this.colCopy.Name = "colCopy";
            this.colCopy.Text = "V";
            this.colCopy.UseColumnTextForButtonValue = true;
            this.colCopy.Visible = false;
            this.colCopy.Width = 30;
            // 
            // btnDelelefrmList
            // 
            this.btnDelelefrmList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelelefrmList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDelelefrmList.Location = new System.Drawing.Point(11, 274);
            this.btnDelelefrmList.Name = "btnDelelefrmList";
            this.btnDelelefrmList.Size = new System.Drawing.Size(27, 20);
            this.btnDelelefrmList.TabIndex = 0;
            this.btnDelelefrmList.Text = "X";
            this.btnDelelefrmList.UseVisualStyleBackColor = true;
            this.btnDelelefrmList.Click += new System.EventHandler(this.btnDelelefrmList_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Controls.Add(this.btnDelete);
            this.groupBox3.Controls.Add(this.btnReset);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Location = new System.Drawing.Point(12, 416);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(912, 51);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(826, 19);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 22);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(670, 19);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 22);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(748, 19);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 22);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(592, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 22);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSelectedMTOID);
            this.groupBox1.Controls.Add(this.dtpMTDate);
            this.groupBox1.Controls.Add(this.txtDeliverOrder);
            this.groupBox1.Controls.Add(this.btnDeliverOrder);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(912, 96);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Material Transfer";
            // 
            // txtSelectedMTOID
            // 
            this.txtSelectedMTOID.Location = new System.Drawing.Point(485, 35);
            this.txtSelectedMTOID.Name = "txtSelectedMTOID";
            this.txtSelectedMTOID.Size = new System.Drawing.Size(17, 20);
            this.txtSelectedMTOID.TabIndex = 22;
            this.txtSelectedMTOID.Visible = false;
            // 
            // dtpMTDate
            // 
            this.dtpMTDate.CustomFormat = "dd-MM-yyyy";
            this.dtpMTDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMTDate.Location = new System.Drawing.Point(581, 35);
            this.dtpMTDate.Name = "dtpMTDate";
            this.dtpMTDate.Size = new System.Drawing.Size(84, 20);
            this.dtpMTDate.TabIndex = 20;
            // 
            // btnDeliverOrder
            // 
            this.btnDeliverOrder.Location = new System.Drawing.Point(455, 35);
            this.btnDeliverOrder.Name = "btnDeliverOrder";
            this.btnDeliverOrder.Size = new System.Drawing.Size(24, 20);
            this.btnDeliverOrder.TabIndex = 0;
            this.btnDeliverOrder.Text = "...";
            this.btnDeliverOrder.UseVisualStyleBackColor = true;
            this.btnDeliverOrder.Click += new System.EventHandler(this.btnDeliverOrder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Deliver Order #";
            // 
            // frmMaterialTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 475);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmMaterialTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Material Transfer";
            this.Load += new System.EventHandler(this.frmMaterialTransfer_Load);
            this.panel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgItemList)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDeliverOrder;
        private System.Windows.Forms.Button btnDeliverOrder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpMTDate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnDelelefrmList;
        private System.Windows.Forms.DataGridView dgItemList;
        private System.Windows.Forms.TextBox txtSelectedMTOID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn colItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIssueqty;
        private System.Windows.Forms.DataGridViewComboBoxColumn colIssueUOM;
        private System.Windows.Forms.DataGridViewComboBoxColumn colSrcBranch;
        private System.Windows.Forms.DataGridViewComboBoxColumn colSourceLoc;
        private System.Windows.Forms.DataGridViewComboBoxColumn colSrcInvType;
        private System.Windows.Forms.DataGridViewComboBoxColumn colDesBranch;
        private System.Windows.Forms.DataGridViewComboBoxColumn colDesLocation;
        private System.Windows.Forms.DataGridViewComboBoxColumn colDesInvType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFinalQty;
        private System.Windows.Forms.DataGridViewButtonColumn colCopy;
    }
}