namespace ETLPOS
{
    partial class frmGR
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSelectedGROID = new System.Windows.Forms.TextBox();
            this.txtRecievedBy = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGRS = new System.Windows.Forms.Button();
            this.txtGRNo = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtRefNo = new System.Windows.Forms.TextBox();
            this.ddlSupplier = new System.Windows.Forms.ComboBox();
            this.ddlType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpGRDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSearchItem = new System.Windows.Forms.Button();
            this.txtTotalAmt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgItemList = new System.Windows.Forms.DataGridView();
            this.btnDelelefrmList = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.CheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIssueqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NowQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIssueUOM = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colSourceLoc = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colSrcInvType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrency = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvtQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCopy = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItemList)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSelectedGROID);
            this.groupBox1.Controls.Add(this.txtRecievedBy);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtSAddress);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnGRS);
            this.groupBox1.Controls.Add(this.txtGRNo);
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Controls.Add(this.txtRefNo);
            this.groupBox1.Controls.Add(this.ddlSupplier);
            this.groupBox1.Controls.Add(this.ddlType);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.dtpGRDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(87, 25);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Goods Receive";
            this.groupBox1.Visible = false;
            // 
            // txtSelectedGROID
            // 
            this.txtSelectedGROID.Location = new System.Drawing.Point(314, 48);
            this.txtSelectedGROID.Name = "txtSelectedGROID";
            this.txtSelectedGROID.Size = new System.Drawing.Size(194, 23);
            this.txtSelectedGROID.TabIndex = 19;
            // 
            // txtRecievedBy
            // 
            this.txtRecievedBy.Location = new System.Drawing.Point(130, 96);
            this.txtRecievedBy.MaxLength = 24;
            this.txtRecievedBy.Name = "txtRecievedBy";
            this.txtRecievedBy.Size = new System.Drawing.Size(178, 23);
            this.txtRecievedBy.TabIndex = 4;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(25, 27);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(72, 17);
            this.label17.TabIndex = 16;
            this.label17.Text = "GR Type";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(813, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSAddress
            // 
            this.txtSAddress.Location = new System.Drawing.Point(624, 74);
            this.txtSAddress.Multiline = true;
            this.txtSAddress.Name = "txtSAddress";
            this.txtSAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSAddress.Size = new System.Drawing.Size(207, 68);
            this.txtSAddress.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(550, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Address";
            // 
            // btnGRS
            // 
            this.btnGRS.Location = new System.Drawing.Point(284, 49);
            this.btnGRS.Name = "btnGRS";
            this.btnGRS.Size = new System.Drawing.Size(24, 23);
            this.btnGRS.TabIndex = 2;
            this.btnGRS.UseVisualStyleBackColor = true;
            this.btnGRS.Click += new System.EventHandler(this.btnGRS_Click);
            // 
            // txtGRNo
            // 
            this.txtGRNo.Location = new System.Drawing.Point(130, 48);
            this.txtGRNo.Name = "txtGRNo";
            this.txtGRNo.Size = new System.Drawing.Size(148, 23);
            this.txtGRNo.TabIndex = 1;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(130, 121);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(178, 23);
            this.txtRemarks.TabIndex = 5;
            // 
            // txtRefNo
            // 
            this.txtRefNo.Location = new System.Drawing.Point(624, 14);
            this.txtRefNo.Name = "txtRefNo";
            this.txtRefNo.Size = new System.Drawing.Size(207, 23);
            this.txtRefNo.TabIndex = 6;
            // 
            // ddlSupplier
            // 
            this.ddlSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSupplier.FormattingEnabled = true;
            this.ddlSupplier.Location = new System.Drawing.Point(624, 43);
            this.ddlSupplier.Name = "ddlSupplier";
            this.ddlSupplier.Size = new System.Drawing.Size(188, 24);
            this.ddlSupplier.TabIndex = 7;
            this.ddlSupplier.SelectedIndexChanged += new System.EventHandler(this.ddlSupplier_SelectedIndexChanged);
            // 
            // ddlType
            // 
            this.ddlType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlType.FormattingEnabled = true;
            this.ddlType.Location = new System.Drawing.Point(130, 21);
            this.ddlType.Name = "ddlType";
            this.ddlType.Size = new System.Drawing.Size(178, 24);
            this.ddlType.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(550, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 17);
            this.label11.TabIndex = 11;
            this.label11.Text = "Supplier";
            // 
            // dtpGRDate
            // 
            this.dtpGRDate.CustomFormat = "dd-MMM-yy";
            this.dtpGRDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpGRDate.Location = new System.Drawing.Point(130, 72);
            this.dtpGRDate.Name = "dtpGRDate";
            this.dtpGRDate.Size = new System.Drawing.Size(92, 23);
            this.dtpGRDate.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Receive By";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "GR Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Remarks";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(25, 50);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(45, 17);
            this.label15.TabIndex = 0;
            this.label15.Text = "GR #";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(550, 21);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 17);
            this.label16.TabIndex = 0;
            this.label16.Text = "Ref #";
            // 
            // txtItemCode
            // 
            this.txtItemCode.Location = new System.Drawing.Point(334, 14);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(178, 20);
            this.txtItemCode.TabIndex = 21;
            this.txtItemCode.TextChanged += new System.EventHandler(this.txtItemCode_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(233, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Item Code : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(657, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Branch";
            // 
            // cmbBranch
            // 
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(704, 13);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(299, 21);
            this.cmbBranch.TabIndex = 23;
            // 
            // btnImport
            // 
            this.btnImport.Enabled = false;
            this.btnImport.Location = new System.Drawing.Point(12, 15);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(266, 46);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "Export Data";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnSearchItem);
            this.groupBox4.Controls.Add(this.txtTotalAmt);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.dgItemList);
            this.groupBox4.Controls.Add(this.btnDelelefrmList);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(10, 40);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1025, 436);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Goods Receive Details";
            // 
            // btnSearchItem
            // 
            this.btnSearchItem.Location = new System.Drawing.Point(44, 415);
            this.btnSearchItem.Name = "btnSearchItem";
            this.btnSearchItem.Size = new System.Drawing.Size(81, 23);
            this.btnSearchItem.TabIndex = 3;
            this.btnSearchItem.Text = "Search Item";
            this.btnSearchItem.UseVisualStyleBackColor = true;
            this.btnSearchItem.Click += new System.EventHandler(this.btnSearchItem_Click);
            // 
            // txtTotalAmt
            // 
            this.txtTotalAmt.BackColor = System.Drawing.Color.SlateGray;
            this.txtTotalAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmt.ForeColor = System.Drawing.Color.White;
            this.txtTotalAmt.Location = new System.Drawing.Point(882, 419);
            this.txtTotalAmt.Name = "txtTotalAmt";
            this.txtTotalAmt.ReadOnly = true;
            this.txtTotalAmt.Size = new System.Drawing.Size(95, 20);
            this.txtTotalAmt.TabIndex = 21;
            this.txtTotalAmt.Text = "0.00";
            this.txtTotalAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(983, 419);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 17);
            this.label9.TabIndex = 22;
            this.label9.Text = "TK";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(772, 420);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "Total Amount";
            // 
            // dgItemList
            // 
            this.dgItemList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgItemList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgItemList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItemList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckBox,
            this.colItemName,
            this.colItem,
            this.colIssueqty,
            this.NowQty,
            this.colIssueUOM,
            this.colSourceLoc,
            this.colSrcInvType,
            this.colPrice,
            this.colCurrency,
            this.colAmount,
            this.colInvtQty,
            this.colCopy});
            this.dgItemList.Location = new System.Drawing.Point(11, 24);
            this.dgItemList.Name = "dgItemList";
            this.dgItemList.Size = new System.Drawing.Size(1005, 383);
            this.dgItemList.TabIndex = 0;
            this.dgItemList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgItemList_CellValueChanged);
            this.dgItemList.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgItemList_RowsAdded);
            this.dgItemList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgItemList_CellContentClick);
            // 
            // btnDelelefrmList
            // 
            this.btnDelelefrmList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelelefrmList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDelelefrmList.Location = new System.Drawing.Point(11, 415);
            this.btnDelelefrmList.Name = "btnDelelefrmList";
            this.btnDelelefrmList.Size = new System.Drawing.Size(27, 20);
            this.btnDelelefrmList.TabIndex = 1;
            this.btnDelelefrmList.Text = "X";
            this.btnDelelefrmList.UseVisualStyleBackColor = true;
            this.btnDelelefrmList.Click += new System.EventHandler(this.btnDelelefrmList_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnImport);
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Controls.Add(this.btnDelete);
            this.groupBox3.Controls.Add(this.btnReset);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(7, 478);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1028, 84);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(939, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(783, 16);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 29);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(861, 16);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 29);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(705, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // CheckBox
            // 
            this.CheckBox.FillWeight = 20F;
            this.CheckBox.Frozen = true;
            this.CheckBox.HeaderText = "";
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.Width = 20;
            // 
            // colItemName
            // 
            this.colItemName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colItemName.HeaderText = "Item Name";
            this.colItemName.Name = "colItemName";
            this.colItemName.Width = 290;
            // 
            // colItem
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colItem.DefaultCellStyle = dataGridViewCellStyle2;
            this.colItem.HeaderText = "Item Code";
            this.colItem.Name = "colItem";
            this.colItem.ReadOnly = true;
            this.colItem.Width = 130;
            // 
            // colIssueqty
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colIssueqty.DefaultCellStyle = dataGridViewCellStyle3;
            this.colIssueqty.HeaderText = "Qty";
            this.colIssueqty.Name = "colIssueqty";
            this.colIssueqty.Width = 50;
            // 
            // NowQty
            // 
            this.NowQty.HeaderText = "NowQty";
            this.NowQty.Name = "NowQty";
            // 
            // colIssueUOM
            // 
            this.colIssueUOM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colIssueUOM.HeaderText = "UOM";
            this.colIssueUOM.Name = "colIssueUOM";
            this.colIssueUOM.ReadOnly = true;
            this.colIssueUOM.Width = 60;
            // 
            // colSourceLoc
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSourceLoc.DefaultCellStyle = dataGridViewCellStyle4;
            this.colSourceLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colSourceLoc.HeaderText = "Location";
            this.colSourceLoc.Name = "colSourceLoc";
            this.colSourceLoc.Width = 120;
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
            // colPrice
            // 
            this.colPrice.HeaderText = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.Width = 55;
            // 
            // colCurrency
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCurrency.DefaultCellStyle = dataGridViewCellStyle6;
            this.colCurrency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colCurrency.HeaderText = "Currency";
            this.colCurrency.Name = "colCurrency";
            this.colCurrency.Width = 70;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Width = 80;
            // 
            // colInvtQty
            // 
            this.colInvtQty.HeaderText = "InvtQty";
            this.colInvtQty.Name = "colInvtQty";
            this.colInvtQty.Visible = false;
            // 
            // colCopy
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Blue;
            this.colCopy.DefaultCellStyle = dataGridViewCellStyle7;
            this.colCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colCopy.HeaderText = "Copy";
            this.colCopy.Name = "colCopy";
            this.colCopy.Text = "V";
            this.colCopy.UseColumnTextForButtonValue = true;
            this.colCopy.Visible = false;
            this.colCopy.Width = 30;
            // 
            // frmGR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 577);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtItemCode);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbBranch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmGR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Goods Receive";
            this.Load += new System.EventHandler(this.frmGR_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItemList)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ddlSupplier;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpGRDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGRS;
        private System.Windows.Forms.TextBox txtGRNo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtRefNo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtSAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox ddlType;
        private System.Windows.Forms.TextBox txtRecievedBy;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgItemList;
        private System.Windows.Forms.Button btnDelelefrmList;
        private System.Windows.Forms.TextBox txtTotalAmt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtSelectedGROID;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnSearchItem;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIssueqty;
        private System.Windows.Forms.DataGridViewTextBoxColumn NowQty;
        private System.Windows.Forms.DataGridViewComboBoxColumn colIssueUOM;
        private System.Windows.Forms.DataGridViewComboBoxColumn colSourceLoc;
        private System.Windows.Forms.DataGridViewComboBoxColumn colSrcInvType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewComboBoxColumn colCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvtQty;
        private System.Windows.Forms.DataGridViewButtonColumn colCopy;
    }
}