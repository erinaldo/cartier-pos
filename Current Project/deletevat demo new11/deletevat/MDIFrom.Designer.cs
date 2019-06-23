namespace deletevat
{
    partial class MDIFrom
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goodReceiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goodRcvMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.margeOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.margeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.salesToolStripMenuItem,
            this.goodReceiveToolStripMenuItem,
            this.margeOptionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1366, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.logOutToolStripMenuItem.Text = "LogOut";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // salesToolStripMenuItem
            // 
            this.salesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salesMasterToolStripMenuItem});
            this.salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            this.salesToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.salesToolStripMenuItem.Text = "Sales";
            // 
            // salesMasterToolStripMenuItem
            // 
            this.salesMasterToolStripMenuItem.Name = "salesMasterToolStripMenuItem";
            this.salesMasterToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.salesMasterToolStripMenuItem.Text = "Sales Master And Details";
            this.salesMasterToolStripMenuItem.Click += new System.EventHandler(this.salesMasterToolStripMenuItem_Click);
            // 
            // goodReceiveToolStripMenuItem
            // 
            this.goodReceiveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goodRcvMasterToolStripMenuItem});
            this.goodReceiveToolStripMenuItem.Name = "goodReceiveToolStripMenuItem";
            this.goodReceiveToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.goodReceiveToolStripMenuItem.Text = "Good Receive";
            // 
            // goodRcvMasterToolStripMenuItem
            // 
            this.goodRcvMasterToolStripMenuItem.Name = "goodRcvMasterToolStripMenuItem";
            this.goodRcvMasterToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.goodRcvMasterToolStripMenuItem.Text = "Good Rcv And Details";
            this.goodRcvMasterToolStripMenuItem.Click += new System.EventHandler(this.goodRcvMasterToolStripMenuItem_Click);
            // 
            // margeOptionsToolStripMenuItem
            // 
            this.margeOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.margeToolStripMenuItem});
            this.margeOptionsToolStripMenuItem.Name = "margeOptionsToolStripMenuItem";
            this.margeOptionsToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.margeOptionsToolStripMenuItem.Text = "Marge Options";
            // 
            // margeToolStripMenuItem
            // 
            this.margeToolStripMenuItem.Name = "margeToolStripMenuItem";
            this.margeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.margeToolStripMenuItem.Text = "Marge";
            this.margeToolStripMenuItem.Click += new System.EventHandler(this.margeToolStripMenuItem_Click);
            // 
            // MDIFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 746);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MDIFrom";
            this.Text = "MDIFrom";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goodReceiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goodRcvMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem margeOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem margeToolStripMenuItem;
    }
}