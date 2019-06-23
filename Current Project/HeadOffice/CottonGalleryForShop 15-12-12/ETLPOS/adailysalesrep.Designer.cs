namespace ETLPOS
{
    partial class adailysalesrep
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
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ddlRptBranch = new System.Windows.Forms.ComboBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.gb_Export = new System.Windows.Forms.GroupBox();
            this.ddlExportedBranch = new System.Windows.Forms.ComboBox();
            this.btnExportData = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            this.gb_Export.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(-135, 182);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(14, 13);
            this.radioButton1.TabIndex = 16;
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ddlRptBranch);
            this.groupBox4.Controls.Add(this.btnShow);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.dtpDate);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(510, 90);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Daily Sales";
            // 
            // ddlRptBranch
            // 
            this.ddlRptBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlRptBranch.FormattingEnabled = true;
            this.ddlRptBranch.Location = new System.Drawing.Point(73, 37);
            this.ddlRptBranch.Name = "ddlRptBranch";
            this.ddlRptBranch.Size = new System.Drawing.Size(121, 24);
            this.ddlRptBranch.TabIndex = 8;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(387, 31);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(108, 35);
            this.btnShow.TabIndex = 4;
            this.btnShow.Text = "Show Report";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Branch";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(214, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Date";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd-MM-yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(266, 37);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(97, 23);
            this.dtpDate.TabIndex = 7;
            // 
            // gb_Export
            // 
            this.gb_Export.Controls.Add(this.ddlExportedBranch);
            this.gb_Export.Controls.Add(this.btnExportData);
            this.gb_Export.Controls.Add(this.label2);
            this.gb_Export.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Export.Location = new System.Drawing.Point(57, 314);
            this.gb_Export.Name = "gb_Export";
            this.gb_Export.Size = new System.Drawing.Size(447, 105);
            this.gb_Export.TabIndex = 17;
            this.gb_Export.TabStop = false;
            this.gb_Export.Text = "Data Export";
            this.gb_Export.Visible = false;
            // 
            // ddlExportedBranch
            // 
            this.ddlExportedBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlExportedBranch.FormattingEnabled = true;
            this.ddlExportedBranch.Location = new System.Drawing.Point(151, 31);
            this.ddlExportedBranch.Name = "ddlExportedBranch";
            this.ddlExportedBranch.Size = new System.Drawing.Size(143, 24);
            this.ddlExportedBranch.TabIndex = 10;
            // 
            // btnExportData
            // 
            this.btnExportData.Location = new System.Drawing.Point(297, 31);
            this.btnExportData.Name = "btnExportData";
            this.btnExportData.Size = new System.Drawing.Size(91, 23);
            this.btnExportData.TabIndex = 8;
            this.btnExportData.Text = "Export Data";
            this.btnExportData.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Export to Branch";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(539, 348);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 35);
            this.button1.TabIndex = 18;
            this.button1.Text = "Show Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // adailysalesrep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 122);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gb_Export);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.groupBox4);
            this.Name = "adailysalesrep";
            this.Text = "adailysalesrep";
            this.Load += new System.EventHandler(this.adailysalesrep_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gb_Export.ResumeLayout(false);
            this.gb_Export.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox ddlRptBranch;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.GroupBox gb_Export;
        private System.Windows.Forms.ComboBox ddlExportedBranch;
        private System.Windows.Forms.Button btnExportData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}