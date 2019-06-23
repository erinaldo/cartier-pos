namespace ETLPOS
{
    partial class frmCustomer
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.txtOId = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtdiscrate = new System.Windows.Forms.TextBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.lblweb = new System.Windows.Forms.Label();
            this.lblphn = new System.Windows.Forms.Label();
            this.txtweb = new System.Windows.Forms.TextBox();
            this.txtphn = new System.Windows.Forms.TextBox();
            this.lblemail = new System.Windows.Forms.Label();
            this.lblfax = new System.Windows.Forms.Label();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.lblcell = new System.Windows.Forms.Label();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.lbladdress = new System.Windows.Forms.Label();
            this.txtfax = new System.Windows.Forms.TextBox();
            this.txtcell = new System.Windows.Forms.TextBox();
            this.lblcontac = new System.Windows.Forms.Label();
            this.txtcontactper = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customer ID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCustomer);
            this.groupBox1.Controls.Add(this.txtOId);
            this.groupBox1.Controls.Add(this.txtId);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblname);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtdiscrate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(587, 119);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Details";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnCustomer
            // 
            this.btnCustomer.Location = new System.Drawing.Point(338, 25);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(41, 23);
            this.btnCustomer.TabIndex = 2;
            this.btnCustomer.Text = "--";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // txtOId
            // 
            this.txtOId.Location = new System.Drawing.Point(528, 33);
            this.txtOId.Name = "txtOId";
            this.txtOId.Size = new System.Drawing.Size(19, 23);
            this.txtOId.TabIndex = 62;
            this.txtOId.Visible = false;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(186, 27);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(146, 23);
            this.txtId.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(310, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 17);
            this.label5.TabIndex = 23;
            this.label5.Text = "%";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(44, 56);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(122, 17);
            this.lblname.TabIndex = 5;
            this.lblname.Text = "Customer Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(186, 53);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(336, 23);
            this.txtName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Disc Rate";
            // 
            // txtdiscrate
            // 
            this.txtdiscrate.Location = new System.Drawing.Point(186, 78);
            this.txtdiscrate.Name = "txtdiscrate";
            this.txtdiscrate.Size = new System.Drawing.Size(121, 23);
            this.txtdiscrate.TabIndex = 4;
            this.txtdiscrate.Text = "0";
            this.txtdiscrate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsValidKeyPress);
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Location = new System.Drawing.Point(361, 164);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(88, 21);
            this.chkIsActive.TabIndex = 8;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // lblweb
            // 
            this.lblweb.AutoSize = true;
            this.lblweb.Location = new System.Drawing.Point(323, 140);
            this.lblweb.Name = "lblweb";
            this.lblweb.Size = new System.Drawing.Size(42, 17);
            this.lblweb.TabIndex = 21;
            this.lblweb.Text = "WEB";
            // 
            // lblphn
            // 
            this.lblphn.AutoSize = true;
            this.lblphn.Location = new System.Drawing.Point(315, 114);
            this.lblphn.Name = "lblphn";
            this.lblphn.Size = new System.Drawing.Size(54, 17);
            this.lblphn.TabIndex = 20;
            this.lblphn.Text = "Phone";
            // 
            // txtweb
            // 
            this.txtweb.Location = new System.Drawing.Point(384, 137);
            this.txtweb.Name = "txtweb";
            this.txtweb.Size = new System.Drawing.Size(132, 23);
            this.txtweb.TabIndex = 6;
            // 
            // txtphn
            // 
            this.txtphn.Location = new System.Drawing.Point(384, 111);
            this.txtphn.Name = "txtphn";
            this.txtphn.Size = new System.Drawing.Size(132, 23);
            this.txtphn.TabIndex = 4;
            // 
            // lblemail
            // 
            this.lblemail.AutoSize = true;
            this.lblemail.Location = new System.Drawing.Point(130, 168);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(47, 17);
            this.lblemail.TabIndex = 16;
            this.lblemail.Text = "Email";
            // 
            // lblfax
            // 
            this.lblfax.AutoSize = true;
            this.lblfax.Location = new System.Drawing.Point(140, 141);
            this.lblfax.Name = "lblfax";
            this.lblfax.Size = new System.Drawing.Size(37, 17);
            this.lblfax.TabIndex = 15;
            this.lblfax.Text = "FAX";
            // 
            // txtaddress
            // 
            this.txtaddress.Location = new System.Drawing.Point(190, 66);
            this.txtaddress.Multiline = true;
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(327, 40);
            this.txtaddress.TabIndex = 2;
            // 
            // lblcell
            // 
            this.lblcell.AutoSize = true;
            this.lblcell.Location = new System.Drawing.Point(142, 115);
            this.lblcell.Name = "lblcell";
            this.lblcell.Size = new System.Drawing.Size(35, 17);
            this.lblcell.TabIndex = 13;
            this.lblcell.Text = "Cell";
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(191, 165);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(116, 23);
            this.txtemail.TabIndex = 7;
            // 
            // lbladdress
            // 
            this.lbladdress.AutoSize = true;
            this.lbladdress.Location = new System.Drawing.Point(110, 69);
            this.lbladdress.Name = "lbladdress";
            this.lbladdress.Size = new System.Drawing.Size(67, 17);
            this.lbladdress.TabIndex = 11;
            this.lbladdress.Text = "Address";
            // 
            // txtfax
            // 
            this.txtfax.Location = new System.Drawing.Point(191, 138);
            this.txtfax.Name = "txtfax";
            this.txtfax.Size = new System.Drawing.Size(116, 23);
            this.txtfax.TabIndex = 5;
            // 
            // txtcell
            // 
            this.txtcell.Location = new System.Drawing.Point(191, 112);
            this.txtcell.Name = "txtcell";
            this.txtcell.Size = new System.Drawing.Size(116, 23);
            this.txtcell.TabIndex = 3;
            // 
            // lblcontac
            // 
            this.lblcontac.AutoSize = true;
            this.lblcontac.Location = new System.Drawing.Point(13, 39);
            this.lblcontac.Name = "lblcontac";
            this.lblcontac.Size = new System.Drawing.Size(163, 17);
            this.lblcontac.TabIndex = 7;
            this.lblcontac.Text = "Contact person if any";
            // 
            // txtcontactper
            // 
            this.txtcontactper.Location = new System.Drawing.Point(190, 39);
            this.txtcontactper.Name = "txtcontactper";
            this.txtcontactper.Size = new System.Drawing.Size(327, 23);
            this.txtcontactper.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(488, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 33);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(400, 16);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 33);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(311, 16);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(84, 33);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Clear";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(222, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 33);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(11, 363);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(587, 61);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtaddress);
            this.groupBox3.Controls.Add(this.txtcontactper);
            this.groupBox3.Controls.Add(this.lblcontac);
            this.groupBox3.Controls.Add(this.txtcell);
            this.groupBox3.Controls.Add(this.chkIsActive);
            this.groupBox3.Controls.Add(this.txtfax);
            this.groupBox3.Controls.Add(this.lbladdress);
            this.groupBox3.Controls.Add(this.lblweb);
            this.groupBox3.Controls.Add(this.txtemail);
            this.groupBox3.Controls.Add(this.lblphn);
            this.groupBox3.Controls.Add(this.lblcell);
            this.groupBox3.Controls.Add(this.txtweb);
            this.groupBox3.Controls.Add(this.lblfax);
            this.groupBox3.Controls.Add(this.txtphn);
            this.groupBox3.Controls.Add(this.lblemail);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(11, 126);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(587, 218);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Contact Information";
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 440);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer";
            this.Load += new System.EventHandler(this.frmCustomer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblfax;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.Label lblcell;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.Label lbladdress;
        private System.Windows.Forms.TextBox txtfax;
        private System.Windows.Forms.TextBox txtcell;
        private System.Windows.Forms.Label lblcontac;
        private System.Windows.Forms.TextBox txtcontactper;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtdiscrate;
        private System.Windows.Forms.Label lblweb;
        private System.Windows.Forms.Label lblphn;
        private System.Windows.Forms.TextBox txtweb;
        private System.Windows.Forms.TextBox txtphn;
        private System.Windows.Forms.Label lblemail;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtOId;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}