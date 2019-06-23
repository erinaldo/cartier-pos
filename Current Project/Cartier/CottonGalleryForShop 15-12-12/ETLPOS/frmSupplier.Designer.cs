namespace ETLPOS
{
    partial class frmSupplier
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.txtcontactper = new System.Windows.Forms.TextBox();
            this.lblcontac = new System.Windows.Forms.Label();
            this.txtcell = new System.Windows.Forms.TextBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.txtfax = new System.Windows.Forms.TextBox();
            this.lbladdress = new System.Windows.Forms.Label();
            this.lblweb = new System.Windows.Forms.Label();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.lblphn = new System.Windows.Forms.Label();
            this.lblcell = new System.Windows.Forms.Label();
            this.txtweb = new System.Windows.Forms.TextBox();
            this.lblfax = new System.Windows.Forms.Label();
            this.txtphn = new System.Windows.Forms.TextBox();
            this.lblemail = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.txtOId = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtdiscrate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(567, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(478, 16);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(390, 16);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(84, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Clear";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(301, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Location = new System.Drawing.Point(9, 353);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(686, 48);
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
            this.groupBox3.Location = new System.Drawing.Point(9, 128);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(685, 218);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Contact Information";
            // 
            // txtaddress
            // 
            this.txtaddress.Location = new System.Drawing.Point(159, 66);
            this.txtaddress.Multiline = true;
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(381, 40);
            this.txtaddress.TabIndex = 2;
            // 
            // txtcontactper
            // 
            this.txtcontactper.Location = new System.Drawing.Point(159, 39);
            this.txtcontactper.Name = "txtcontactper";
            this.txtcontactper.Size = new System.Drawing.Size(381, 20);
            this.txtcontactper.TabIndex = 1;
            // 
            // lblcontac
            // 
            this.lblcontac.AutoSize = true;
            this.lblcontac.Location = new System.Drawing.Point(156, 24);
            this.lblcontac.Name = "lblcontac";
            this.lblcontac.Size = new System.Drawing.Size(128, 13);
            this.lblcontac.TabIndex = 7;
            this.lblcontac.Text = "Contact person if any";
            // 
            // txtcell
            // 
            this.txtcell.Location = new System.Drawing.Point(159, 112);
            this.txtcell.Name = "txtcell";
            this.txtcell.Size = new System.Drawing.Size(135, 20);
            this.txtcell.TabIndex = 3;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Location = new System.Drawing.Point(386, 164);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(76, 17);
            this.chkIsActive.TabIndex = 8;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // txtfax
            // 
            this.txtfax.Location = new System.Drawing.Point(159, 138);
            this.txtfax.Name = "txtfax";
            this.txtfax.Size = new System.Drawing.Size(135, 20);
            this.txtfax.TabIndex = 5;
            // 
            // lbladdress
            // 
            this.lbladdress.AutoSize = true;
            this.lbladdress.Location = new System.Drawing.Point(96, 69);
            this.lbladdress.Name = "lbladdress";
            this.lbladdress.Size = new System.Drawing.Size(52, 13);
            this.lbladdress.TabIndex = 11;
            this.lbladdress.Text = "Address";
            // 
            // lblweb
            // 
            this.lblweb.AutoSize = true;
            this.lblweb.Location = new System.Drawing.Point(342, 140);
            this.lblweb.Name = "lblweb";
            this.lblweb.Size = new System.Drawing.Size(35, 13);
            this.lblweb.TabIndex = 21;
            this.lblweb.Text = "WEB";
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(159, 165);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(135, 20);
            this.txtemail.TabIndex = 7;
            // 
            // lblphn
            // 
            this.lblphn.AutoSize = true;
            this.lblphn.Location = new System.Drawing.Point(332, 114);
            this.lblphn.Name = "lblphn";
            this.lblphn.Size = new System.Drawing.Size(43, 13);
            this.lblphn.TabIndex = 20;
            this.lblphn.Text = "Phone";
            // 
            // lblcell
            // 
            this.lblcell.AutoSize = true;
            this.lblcell.Location = new System.Drawing.Point(124, 115);
            this.lblcell.Name = "lblcell";
            this.lblcell.Size = new System.Drawing.Size(28, 13);
            this.lblcell.TabIndex = 13;
            this.lblcell.Text = "Cell";
            // 
            // txtweb
            // 
            this.txtweb.Location = new System.Drawing.Point(386, 137);
            this.txtweb.Name = "txtweb";
            this.txtweb.Size = new System.Drawing.Size(153, 20);
            this.txtweb.TabIndex = 6;
            // 
            // lblfax
            // 
            this.lblfax.AutoSize = true;
            this.lblfax.Location = new System.Drawing.Point(120, 141);
            this.lblfax.Name = "lblfax";
            this.lblfax.Size = new System.Drawing.Size(30, 13);
            this.lblfax.TabIndex = 15;
            this.lblfax.Text = "FAX";
            // 
            // txtphn
            // 
            this.txtphn.Location = new System.Drawing.Point(386, 111);
            this.txtphn.Name = "txtphn";
            this.txtphn.Size = new System.Drawing.Size(153, 20);
            this.txtphn.TabIndex = 4;
            // 
            // lblemail
            // 
            this.lblemail.AutoSize = true;
            this.lblemail.Location = new System.Drawing.Point(111, 168);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(37, 13);
            this.lblemail.TabIndex = 16;
            this.lblemail.Text = "Email";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSupplier);
            this.groupBox1.Controls.Add(this.txtOId);
            this.groupBox1.Controls.Add(this.txtId);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblname);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtdiscrate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(685, 119);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Supplier Details";
            // 
            // btnSupplier
            // 
            this.btnSupplier.Location = new System.Drawing.Point(337, 25);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(48, 23);
            this.btnSupplier.TabIndex = 2;
            this.btnSupplier.Text = "--";
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click_1);
            // 
            // txtOId
            // 
            this.txtOId.Location = new System.Drawing.Point(616, 33);
            this.txtOId.Name = "txtOId";
            this.txtOId.Size = new System.Drawing.Size(21, 20);
            this.txtOId.TabIndex = 62;
            this.txtOId.Visible = false;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(160, 27);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(170, 20);
            this.txtId.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(304, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "%";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(67, 56);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(89, 13);
            this.lblname.TabIndex = 5;
            this.lblname.Text = "Supplier Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(160, 53);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(391, 20);
            this.txtName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Disc Rate";
            // 
            // txtdiscrate
            // 
            this.txtdiscrate.Location = new System.Drawing.Point(160, 78);
            this.txtdiscrate.Name = "txtdiscrate";
            this.txtdiscrate.Size = new System.Drawing.Size(140, 20);
            this.txtdiscrate.TabIndex = 4;
            this.txtdiscrate.Text = "0";
            this.txtdiscrate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsValidKeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Supplier ID";
            // 
            // frmSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 410);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmSupplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier";
            this.Load += new System.EventHandler(this.frmSupplier_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.TextBox txtcontactper;
        private System.Windows.Forms.Label lblcontac;
        private System.Windows.Forms.TextBox txtcell;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.TextBox txtfax;
        private System.Windows.Forms.Label lbladdress;
        private System.Windows.Forms.Label lblweb;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.Label lblphn;
        private System.Windows.Forms.Label lblcell;
        private System.Windows.Forms.TextBox txtweb;
        private System.Windows.Forms.Label lblfax;
        private System.Windows.Forms.TextBox txtphn;
        private System.Windows.Forms.Label lblemail;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.TextBox txtOId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtdiscrate;
        private System.Windows.Forms.Label label1;
    }
}