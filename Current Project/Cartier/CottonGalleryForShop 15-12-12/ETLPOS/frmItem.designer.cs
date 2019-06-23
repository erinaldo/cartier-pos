namespace ETLPOS
{
    partial class frmItem
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("");
            this.gbItemNAme = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.ofdImage = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtICode = new System.Windows.Forms.TextBox();
            this.cmbItemSize = new System.Windows.Forms.ComboBox();
            this.nupdnItemPriority = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.btnRemoveImage = new System.Windows.Forms.Button();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txthiddenitemid = new System.Windows.Forms.TextBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ddlUOM = new System.Windows.Forms.ComboBox();
            this.btnNewPOB = new System.Windows.Forms.Button();
            this.btnNewAppr = new System.Windows.Forms.Button();
            this.ddlItemType = new System.Windows.Forms.ComboBox();
            this.ddlGroupNAme = new System.Windows.Forms.ComboBox();
            this.lblItemType = new System.Windows.Forms.Label();
            this.lblgrname = new System.Windows.Forms.Label();
            this.txtSprice = new System.Windows.Forms.TextBox();
            this.txtRQTY = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblUOM = new System.Windows.Forms.Label();
            this.txtpprice = new System.Windows.Forms.TextBox();
            this.lblRQTY = new System.Windows.Forms.Label();
            this.lblSprice = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.gbItemNAme.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupdnItemPriority)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // gbItemNAme
            // 
            this.gbItemNAme.Controls.Add(this.treeView1);
            this.gbItemNAme.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbItemNAme.Location = new System.Drawing.Point(12, 6);
            this.gbItemNAme.Name = "gbItemNAme";
            this.gbItemNAme.Size = new System.Drawing.Size(203, 403);
            this.gbItemNAme.TabIndex = 3;
            this.gbItemNAme.TabStop = false;
            this.gbItemNAme.Text = "Item Name";
            this.gbItemNAme.Enter += new System.EventHandler(this.gbItemNAme_Enter);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(7, 19);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node3";
            treeNode1.Tag = "GroupID";
            treeNode1.Text = "";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(188, 355);
            this.treeView1.TabIndex = 61;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Location = new System.Drawing.Point(12, 415);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(699, 61);
            this.groupBox2.TabIndex = 51;
            this.groupBox2.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(386, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 29);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(615, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 28);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(462, 15);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(72, 29);
            this.btnReset.TabIndex = 22;
            this.btnReset.Text = "Clear";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(539, 15);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(72, 28);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.txtICode);
            this.groupBox1.Controls.Add(this.cmbItemSize);
            this.groupBox1.Controls.Add(this.nupdnItemPriority);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnAddImage);
            this.groupBox1.Controls.Add(this.btnRemoveImage);
            this.groupBox1.Controls.Add(this.pbImage);
            this.groupBox1.Controls.Add(this.txtItemCode);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txthiddenitemid);
            this.groupBox1.Controls.Add(this.chkIsActive);
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.ddlUOM);
            this.groupBox1.Controls.Add(this.btnNewPOB);
            this.groupBox1.Controls.Add(this.btnNewAppr);
            this.groupBox1.Controls.Add(this.ddlItemType);
            this.groupBox1.Controls.Add(this.ddlGroupNAme);
            this.groupBox1.Controls.Add(this.lblItemType);
            this.groupBox1.Controls.Add(this.lblgrname);
            this.groupBox1.Controls.Add(this.txtSprice);
            this.groupBox1.Controls.Add(this.txtRQTY);
            this.groupBox1.Controls.Add(this.lblPrice);
            this.groupBox1.Controls.Add(this.lblUOM);
            this.groupBox1.Controls.Add(this.txtpprice);
            this.groupBox1.Controls.Add(this.lblRQTY);
            this.groupBox1.Controls.Add(this.lblSprice);
            this.groupBox1.Controls.Add(this.txtItemName);
            this.groupBox1.Controls.Add(this.lblItemName);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(221, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 403);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entry Item ";
            // 
            // txtICode
            // 
            this.txtICode.Location = new System.Drawing.Point(326, 158);
            this.txtICode.Name = "txtICode";
            this.txtICode.Size = new System.Drawing.Size(121, 23);
            this.txtICode.TabIndex = 75;
            // 
            // cmbItemSize
            // 
            this.cmbItemSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbItemSize.FormattingEnabled = true;
            this.cmbItemSize.Location = new System.Drawing.Point(139, 204);
            this.cmbItemSize.Name = "cmbItemSize";
            this.cmbItemSize.Size = new System.Drawing.Size(177, 24);
            this.cmbItemSize.TabIndex = 74;
            // 
            // nupdnItemPriority
            // 
            this.nupdnItemPriority.Location = new System.Drawing.Point(138, 260);
            this.nupdnItemPriority.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nupdnItemPriority.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupdnItemPriority.Name = "nupdnItemPriority";
            this.nupdnItemPriority.Size = new System.Drawing.Size(67, 23);
            this.nupdnItemPriority.TabIndex = 6;
            this.nupdnItemPriority.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(51, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 72;
            this.label5.Text = "Priority";
            // 
            // btnAddImage
            // 
            this.btnAddImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddImage.Location = new System.Drawing.Point(214, 19);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(131, 31);
            this.btnAddImage.TabIndex = 71;
            this.btnAddImage.Text = "Add Image";
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // btnRemoveImage
            // 
            this.btnRemoveImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveImage.Location = new System.Drawing.Point(214, 53);
            this.btnRemoveImage.Name = "btnRemoveImage";
            this.btnRemoveImage.Size = new System.Drawing.Size(131, 33);
            this.btnRemoveImage.TabIndex = 70;
            this.btnRemoveImage.Text = "Remove Image";
            this.btnRemoveImage.UseVisualStyleBackColor = true;
            this.btnRemoveImage.Click += new System.EventHandler(this.btnRemoveImage_Click);
            // 
            // pbImage
            // 
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage.Enabled = false;
            this.pbImage.Location = new System.Drawing.Point(69, 19);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(100, 100);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbImage.TabIndex = 69;
            this.pbImage.TabStop = false;
            // 
            // txtItemCode
            // 
            this.txtItemCode.Location = new System.Drawing.Point(138, 136);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(103, 23);
            this.txtItemCode.TabIndex = 1;
            this.txtItemCode.UseWaitCursor = true;
            this.txtItemCode.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(51, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 67;
            this.label4.Text = "Item Code";
            this.label4.UseWaitCursor = true;
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(286, 319);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 17);
            this.label3.TabIndex = 66;
            this.label3.Text = "days";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(242, 321);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(38, 20);
            this.textBox2.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(188, 317);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 64;
            this.label2.Text = "month";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(138, 321);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(44, 20);
            this.textBox1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 62;
            this.label1.Text = "Holding Time";
            // 
            // txthiddenitemid
            // 
            this.txthiddenitemid.Location = new System.Drawing.Point(292, 137);
            this.txthiddenitemid.Name = "txthiddenitemid";
            this.txthiddenitemid.Size = new System.Drawing.Size(23, 23);
            this.txthiddenitemid.TabIndex = 61;
            this.txthiddenitemid.Visible = false;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsActive.Location = new System.Drawing.Point(255, 370);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(79, 21);
            this.chkIsActive.TabIndex = 10;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(138, 343);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(178, 20);
            this.txtRemarks.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(45, 346);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 17);
            this.label6.TabIndex = 56;
            this.label6.Text = "Remarks";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(318, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 24);
            this.button1.TabIndex = 55;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // ddlUOM
            // 
            this.ddlUOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlUOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlUOM.FormattingEnabled = true;
            this.ddlUOM.Location = new System.Drawing.Point(138, 227);
            this.ddlUOM.Name = "ddlUOM";
            this.ddlUOM.Size = new System.Drawing.Size(178, 24);
            this.ddlUOM.TabIndex = 5;
            // 
            // btnNewPOB
            // 
            this.btnNewPOB.Location = new System.Drawing.Point(318, 182);
            this.btnNewPOB.Name = "btnNewPOB";
            this.btnNewPOB.Size = new System.Drawing.Size(27, 24);
            this.btnNewPOB.TabIndex = 49;
            this.btnNewPOB.Text = "...";
            this.btnNewPOB.UseVisualStyleBackColor = true;
            this.btnNewPOB.Click += new System.EventHandler(this.btnNewPOB_Click_2);
            // 
            // btnNewAppr
            // 
            this.btnNewAppr.Location = new System.Drawing.Point(318, 205);
            this.btnNewAppr.Name = "btnNewAppr";
            this.btnNewAppr.Size = new System.Drawing.Size(27, 24);
            this.btnNewAppr.TabIndex = 48;
            this.btnNewAppr.Text = "...";
            this.btnNewAppr.UseVisualStyleBackColor = true;
            this.btnNewAppr.Click += new System.EventHandler(this.btnNewAppr_Click_2);
            // 
            // ddlItemType
            // 
            this.ddlItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlItemType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlItemType.FormattingEnabled = true;
            this.ddlItemType.Location = new System.Drawing.Point(138, 204);
            this.ddlItemType.Name = "ddlItemType";
            this.ddlItemType.Size = new System.Drawing.Size(178, 24);
            this.ddlItemType.TabIndex = 4;
            // 
            // ddlGroupNAme
            // 
            this.ddlGroupNAme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGroupNAme.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlGroupNAme.FormattingEnabled = true;
            this.ddlGroupNAme.Location = new System.Drawing.Point(138, 181);
            this.ddlGroupNAme.Name = "ddlGroupNAme";
            this.ddlGroupNAme.Size = new System.Drawing.Size(178, 24);
            this.ddlGroupNAme.TabIndex = 3;
            // 
            // lblItemType
            // 
            this.lblItemType.AutoSize = true;
            this.lblItemType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemType.Location = new System.Drawing.Point(51, 203);
            this.lblItemType.Name = "lblItemType";
            this.lblItemType.Size = new System.Drawing.Size(65, 17);
            this.lblItemType.TabIndex = 52;
            this.lblItemType.Text = "Item Size";
            // 
            // lblgrname
            // 
            this.lblgrname.AutoSize = true;
            this.lblgrname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblgrname.Location = new System.Drawing.Point(51, 180);
            this.lblgrname.Name = "lblgrname";
            this.lblgrname.Size = new System.Drawing.Size(75, 17);
            this.lblgrname.TabIndex = 50;
            this.lblgrname.Text = "Item Name";
            // 
            // txtSprice
            // 
            this.txtSprice.Location = new System.Drawing.Point(434, 257);
            this.txtSprice.Name = "txtSprice";
            this.txtSprice.Size = new System.Drawing.Size(44, 23);
            this.txtSprice.TabIndex = 46;
            this.txtSprice.Text = "0";
            this.txtSprice.Visible = false;
            // 
            // txtRQTY
            // 
            this.txtRQTY.Location = new System.Drawing.Point(434, 302);
            this.txtRQTY.Multiline = true;
            this.txtRQTY.Name = "txtRQTY";
            this.txtRQTY.Size = new System.Drawing.Size(44, 20);
            this.txtRQTY.TabIndex = 47;
            this.txtRQTY.Text = "0";
            this.txtRQTY.Visible = false;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(373, 277);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(53, 17);
            this.lblPrice.TabIndex = 44;
            this.lblPrice.Text = "P Price";
            this.lblPrice.Visible = false;
            // 
            // lblUOM
            // 
            this.lblUOM.AutoSize = true;
            this.lblUOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUOM.Location = new System.Drawing.Point(51, 225);
            this.lblUOM.Name = "lblUOM";
            this.lblUOM.Size = new System.Drawing.Size(81, 17);
            this.lblUOM.TabIndex = 45;
            this.lblUOM.Text = "UOM Name";
            // 
            // txtpprice
            // 
            this.txtpprice.Location = new System.Drawing.Point(434, 279);
            this.txtpprice.Name = "txtpprice";
            this.txtpprice.Size = new System.Drawing.Size(44, 23);
            this.txtpprice.TabIndex = 43;
            this.txtpprice.Text = "0";
            this.txtpprice.Visible = false;
            // 
            // lblRQTY
            // 
            this.lblRQTY.AutoSize = true;
            this.lblRQTY.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRQTY.Location = new System.Drawing.Point(373, 300);
            this.lblRQTY.Name = "lblRQTY";
            this.lblRQTY.Size = new System.Drawing.Size(47, 17);
            this.lblRQTY.TabIndex = 41;
            this.lblRQTY.Text = "RQTY";
            this.lblRQTY.Visible = false;
            // 
            // lblSprice
            // 
            this.lblSprice.AutoSize = true;
            this.lblSprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSprice.Location = new System.Drawing.Point(373, 254);
            this.lblSprice.Name = "lblSprice";
            this.lblSprice.Size = new System.Drawing.Size(53, 17);
            this.lblSprice.TabIndex = 42;
            this.lblSprice.Text = "S Price";
            this.lblSprice.Visible = false;
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(138, 159);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(178, 23);
            this.txtItemName.TabIndex = 2;
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.Location = new System.Drawing.Point(46, 160);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(87, 17);
            this.lblItemName.TabIndex = 39;
            this.lblItemName.Text = "Model Name";
            // 
            // frmItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 493);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbItemNAme);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item";
            this.Load += new System.EventHandler(this.frmItem_Load);
            this.gbItemNAme.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupdnItemPriority)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbItemNAme;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txthiddenitemid;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox ddlUOM;
        private System.Windows.Forms.Button btnNewPOB;
        private System.Windows.Forms.Button btnNewAppr;
        private System.Windows.Forms.ComboBox ddlItemType;
        private System.Windows.Forms.ComboBox ddlGroupNAme;
        private System.Windows.Forms.Label lblItemType;
        private System.Windows.Forms.Label lblgrname;
        private System.Windows.Forms.TextBox txtSprice;
        private System.Windows.Forms.TextBox txtRQTY;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblUOM;
        private System.Windows.Forms.TextBox txtpprice;
        private System.Windows.Forms.Label lblRQTY;
        private System.Windows.Forms.Label lblSprice;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.Button btnRemoveImage;
        private System.Windows.Forms.OpenFileDialog ofdImage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nupdnItemPriority;
        private System.Windows.Forms.ComboBox cmbItemSize;
        private System.Windows.Forms.TextBox txtICode;
    }
}