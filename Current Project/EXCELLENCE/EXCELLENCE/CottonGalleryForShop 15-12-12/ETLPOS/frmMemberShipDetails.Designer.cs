namespace ETLPOS
{
    partial class frmMemberShipDetails
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
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.rbNo = new System.Windows.Forms.RadioButton();
            this.rbYes = new System.Windows.Forms.RadioButton();
            this.txtMembeHiddenID = new System.Windows.Forms.TextBox();
            this.txtFamilyMember = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtOccuption = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPostCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.txtMemberName = new System.Windows.Forms.TextBox();
            this.txtMemberID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lvMemberList = new System.Windows.Forms.ListView();
            this.cSL = new System.Windows.Forms.ColumnHeader();
            this.cName = new System.Windows.Forms.ColumnHeader();
            this.cMobile = new System.Windows.Forms.ColumnHeader();
            this.cFromDate = new System.Windows.Forms.ColumnHeader();
            this.cToDate = new System.Windows.Forms.ColumnHeader();
            this.cMemberID = new System.Windows.Forms.ColumnHeader();
            this.txtMemberDiscountAmount = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd:MM:yyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(102, 156);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(178, 20);
            this.dtpToDate.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtMemberDiscountAmount);
            this.groupBox1.Controls.Add(this.dtpDateOfBirth);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.rbNo);
            this.groupBox1.Controls.Add(this.rbYes);
            this.groupBox1.Controls.Add(this.txtMembeHiddenID);
            this.groupBox1.Controls.Add(this.txtFamilyMember);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtOccuption);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtPhone);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtPostCode);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtArea);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.txtMobile);
            this.groupBox1.Controls.Add(this.txtMemberName);
            this.groupBox1.Controls.Add(this.txtMemberID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(472, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 428);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Member Entry";
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.CustomFormat = "dd:MM:yyy";
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(101, 103);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(178, 20);
            this.dtpDateOfBirth.TabIndex = 49;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(40, 103);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 13);
            this.label14.TabIndex = 48;
            this.label14.Text = "Date Of Birth:";
            // 
            // rbNo
            // 
            this.rbNo.AutoSize = true;
            this.rbNo.Location = new System.Drawing.Point(166, 403);
            this.rbNo.Name = "rbNo";
            this.rbNo.Size = new System.Drawing.Size(39, 17);
            this.rbNo.TabIndex = 47;
            this.rbNo.TabStop = true;
            this.rbNo.Text = "No";
            this.rbNo.UseVisualStyleBackColor = true;
            // 
            // rbYes
            // 
            this.rbYes.AutoSize = true;
            this.rbYes.Location = new System.Drawing.Point(107, 403);
            this.rbYes.Name = "rbYes";
            this.rbYes.Size = new System.Drawing.Size(43, 17);
            this.rbYes.TabIndex = 46;
            this.rbYes.TabStop = true;
            this.rbYes.Text = "Yes";
            this.rbYes.UseVisualStyleBackColor = true;
            // 
            // txtMembeHiddenID
            // 
            this.txtMembeHiddenID.Location = new System.Drawing.Point(6, 56);
            this.txtMembeHiddenID.Name = "txtMembeHiddenID";
            this.txtMembeHiddenID.Size = new System.Drawing.Size(31, 20);
            this.txtMembeHiddenID.TabIndex = 45;
            this.txtMembeHiddenID.Visible = false;
            // 
            // txtFamilyMember
            // 
            this.txtFamilyMember.Location = new System.Drawing.Point(102, 372);
            this.txtFamilyMember.Name = "txtFamilyMember";
            this.txtFamilyMember.Size = new System.Drawing.Size(178, 20);
            this.txtFamilyMember.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 404);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Is Active Member:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 372);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Family Member:";
            // 
            // txtOccuption
            // 
            this.txtOccuption.Location = new System.Drawing.Point(101, 346);
            this.txtOccuption.Name = "txtOccuption";
            this.txtOccuption.Size = new System.Drawing.Size(178, 20);
            this.txtOccuption.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(34, 346);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Occupation:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(101, 320);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(178, 20);
            this.txtEmail.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(64, 320);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Email:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(102, 294);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(178, 20);
            this.txtPhone.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(58, 294);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Phone:";
            // 
            // txtPostCode
            // 
            this.txtPostCode.Location = new System.Drawing.Point(102, 268);
            this.txtPostCode.Name = "txtPostCode";
            this.txtPostCode.Size = new System.Drawing.Size(178, 20);
            this.txtPostCode.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 268);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Post Code:";
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(102, 242);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(178, 20);
            this.txtArea.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(67, 242);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Area:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(102, 216);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(178, 20);
            this.txtAddress.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Address:";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd:MM:yyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(101, 130);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(178, 20);
            this.dtpFromDate.TabIndex = 8;
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(101, 73);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(178, 20);
            this.txtMobile.TabIndex = 7;
            // 
            // txtMemberName
            // 
            this.txtMemberName.Location = new System.Drawing.Point(101, 47);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(178, 20);
            this.txtMemberName.TabIndex = 6;
            // 
            // txtMemberID
            // 
            this.txtMemberID.Location = new System.Drawing.Point(101, 21);
            this.txtMemberID.Name = "txtMemberID";
            this.txtMemberID.ReadOnly = true;
            this.txtMemberID.Size = new System.Drawing.Size(178, 20);
            this.txtMemberID.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "To Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "From Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mobile:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Member ID:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Location = new System.Drawing.Point(463, 449);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(324, 42);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(9, 13);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(72, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(243, 13);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(165, 13);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(72, 23);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(87, 13);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(72, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Clear";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lvMemberList);
            this.groupBox3.Location = new System.Drawing.Point(14, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(449, 449);
            this.groupBox3.TabIndex = 44;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Member LIst";
            // 
            // lvMemberList
            // 
            this.lvMemberList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cSL,
            this.cName,
            this.cMobile,
            this.cFromDate,
            this.cToDate,
            this.cMemberID});
            this.lvMemberList.FullRowSelect = true;
            this.lvMemberList.GridLines = true;
            this.lvMemberList.Location = new System.Drawing.Point(10, 20);
            this.lvMemberList.Name = "lvMemberList";
            this.lvMemberList.Size = new System.Drawing.Size(433, 428);
            this.lvMemberList.TabIndex = 0;
            this.lvMemberList.UseCompatibleStateImageBehavior = false;
            this.lvMemberList.View = System.Windows.Forms.View.Details;
            this.lvMemberList.DoubleClick += new System.EventHandler(this.lvMemberList_DoubleClick);
            // 
            // cSL
            // 
            this.cSL.Text = "SNo";
            this.cSL.Width = 35;
            // 
            // cName
            // 
            this.cName.Text = "Name";
            this.cName.Width = 150;
            // 
            // cMobile
            // 
            this.cMobile.Text = "Mobile";
            this.cMobile.Width = 100;
            // 
            // cFromDate
            // 
            this.cFromDate.Text = "From Date";
            this.cFromDate.Width = 80;
            // 
            // cToDate
            // 
            this.cToDate.Text = "To Date";
            this.cToDate.Width = 80;
            // 
            // cMemberID
            // 
            this.cMemberID.Text = "Member ID";
            // 
            // txtMemberDiscountAmount
            // 
            this.txtMemberDiscountAmount.Location = new System.Drawing.Point(102, 182);
            this.txtMemberDiscountAmount.Name = "txtMemberDiscountAmount";
            this.txtMemberDiscountAmount.Size = new System.Drawing.Size(178, 20);
            this.txtMemberDiscountAmount.TabIndex = 50;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 182);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 13);
            this.label15.TabIndex = 51;
            this.label15.Text = "DiscountAmount:";
            // 
            // frmMemberShipDetails
            // 
            this.ClientSize = new System.Drawing.Size(802, 498);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmMemberShipDetails";
            this.Text = "Member Ship Detail";
            this.Load += new System.EventHandler(this.frmMemberShipDetails_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.TextBox txtMemberName;
        private System.Windows.Forms.TextBox txtMemberID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lvMemberList;
        private System.Windows.Forms.TextBox txtFamilyMember;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtOccuption;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPostCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader cSL;
        private System.Windows.Forms.ColumnHeader cName;
        private System.Windows.Forms.ColumnHeader cMobile;
        private System.Windows.Forms.ColumnHeader cFromDate;
        private System.Windows.Forms.ColumnHeader cToDate;
        private System.Windows.Forms.ColumnHeader cMemberID;
        private System.Windows.Forms.TextBox txtMembeHiddenID;
        private System.Windows.Forms.RadioButton rbNo;
        private System.Windows.Forms.RadioButton rbYes;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtMemberDiscountAmount;
    }
}
