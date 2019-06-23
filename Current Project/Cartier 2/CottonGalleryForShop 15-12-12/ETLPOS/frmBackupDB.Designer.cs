namespace ETLPOS
{
    partial class frmBackupDB
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        ////////////////protected override void Dispose(bool disposing)
        ////////////////{
        ////////////////    if (disposing && (components != null))
        ////////////////    {
        ////////////////        components.Dispose();
        ////////////////    }
        ////////////////    base.Dispose(disposing);
        ////////////////}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRestoreDB = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbDatabaseName = new System.Windows.Forms.ComboBox();
            this.cmbServerName = new System.Windows.Forms.ComboBox();
            this.chbEnable = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openBackupDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRestoreDB);
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.btnBackup);
            this.groupBox2.Location = new System.Drawing.Point(12, 204);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(407, 39);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // btnRestoreDB
            // 
            this.btnRestoreDB.Location = new System.Drawing.Point(125, 10);
            this.btnRestoreDB.Name = "btnRestoreDB";
            this.btnRestoreDB.Size = new System.Drawing.Size(88, 23);
            this.btnRestoreDB.TabIndex = 2;
            this.btnRestoreDB.Text = "Restore DB";
            this.btnRestoreDB.UseVisualStyleBackColor = true;
            //this.btnRestoreDB.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(316, 10);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(60, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            //this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(229, 10);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(73, 23);
            this.btnBackup.TabIndex = 1;
            this.btnBackup.Text = "BackUp";
            this.btnBackup.UseVisualStyleBackColor = true;
            //this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbDatabaseName);
            this.groupBox1.Controls.Add(this.cmbServerName);
            this.groupBox1.Controls.Add(this.chbEnable);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 186);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // cmbDatabaseName
            // 
            this.cmbDatabaseName.Enabled = false;
            this.cmbDatabaseName.FormattingEnabled = true;
            this.cmbDatabaseName.Location = new System.Drawing.Point(96, 71);
            this.cmbDatabaseName.Name = "cmbDatabaseName";
            this.cmbDatabaseName.Size = new System.Drawing.Size(261, 21);
            this.cmbDatabaseName.TabIndex = 4;
            this.cmbDatabaseName.Text = "ETLPOS_1";
            // 
            // cmbServerName
            // 
            this.cmbServerName.Enabled = false;
            this.cmbServerName.FormattingEnabled = true;
            this.cmbServerName.Location = new System.Drawing.Point(96, 42);
            this.cmbServerName.Name = "cmbServerName";
            this.cmbServerName.Size = new System.Drawing.Size(261, 21);
            this.cmbServerName.TabIndex = 4;
            // 
            // chbEnable
            // 
            this.chbEnable.AutoSize = true;
            this.chbEnable.Location = new System.Drawing.Point(365, 44);
            this.chbEnable.Name = "chbEnable";
            this.chbEnable.Size = new System.Drawing.Size(15, 14);
            this.chbEnable.TabIndex = 3;
            this.chbEnable.UseVisualStyleBackColor = true;
            //this.chbEnable.CheckedChanged += new System.EventHandler(this.chbEnable_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "DB Name";
            // 
            // txtUserName
            // 
            this.txtUserName.Enabled = false;
            this.txtUserName.Location = new System.Drawing.Point(96, 99);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(261, 20);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Text = "sa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "User Name";
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(96, 127);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(261, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Text = "etl";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Server Name";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "Backup.bak";
            this.saveFileDialog1.Filter = "Backup File|*.bak";
            // 
            // openBackupDialog
            // 
            this.openBackupDialog.FileName = "Backup.bak";
            this.openBackupDialog.Filter = "Backup File|*.bak";
            // 
            // frmBackupDB
            // 
            //////////this.ClientSize = new System.Drawing.Size(431, 255);
            //////////this.Controls.Add(this.groupBox2);
            //////////this.Controls.Add(this.groupBox1);
            //////////this.Name = "frmBackupDB";
            //////////this.Text = "Backup/Restore Database";
            //////////this.Load += new System.EventHandler(this.frmBackupDB_Load);
            //////////this.groupBox2.ResumeLayout(false);
            //////////this.groupBox1.ResumeLayout(false);
            //////////this.groupBox1.PerformLayout();
            //////////this.ResumeLayout(false);

        }

        private void SuspendLayout()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chbEnable;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ComboBox cmbDatabaseName;
        private System.Windows.Forms.ComboBox cmbServerName;
        private System.Windows.Forms.Button btnRestoreDB;
        private System.Windows.Forms.OpenFileDialog openBackupDialog;
    }
}
