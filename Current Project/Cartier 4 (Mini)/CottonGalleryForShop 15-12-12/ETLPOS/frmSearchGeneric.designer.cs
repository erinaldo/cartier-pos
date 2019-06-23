namespace ETLPOS
{
    partial class frmSearchGeneric<T>
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbCriteria = new System.Windows.Forms.GroupBox();
            this.pnlDate = new System.Windows.Forms.Panel();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlReqNo = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRequisitionNo = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.rbtnNumber = new System.Windows.Forms.RadioButton();
            this.rbtnDate = new System.Windows.Forms.RadioButton();
            this.Output = new System.Windows.Forms.GroupBox();
            this.lstSearcheResult = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.gbCriteria.SuspendLayout();
            this.pnlDate.SuspendLayout();
            this.pnlReqNo.SuspendLayout();
            this.Output.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbCriteria);
            this.panel1.Controls.Add(this.Output);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 454);
            this.panel1.TabIndex = 2;
            // 
            // gbCriteria
            // 
            this.gbCriteria.Controls.Add(this.pnlDate);
            this.gbCriteria.Controls.Add(this.pnlReqNo);
            this.gbCriteria.Controls.Add(this.btnSearch);
            this.gbCriteria.Controls.Add(this.rbtnNumber);
            this.gbCriteria.Controls.Add(this.rbtnDate);
            this.gbCriteria.Location = new System.Drawing.Point(12, 3);
            this.gbCriteria.Name = "gbCriteria";
            this.gbCriteria.Size = new System.Drawing.Size(219, 118);
            this.gbCriteria.TabIndex = 10;
            this.gbCriteria.TabStop = false;
            this.gbCriteria.Text = "Criteria";
            // 
            // pnlDate
            // 
            this.pnlDate.BackColor = System.Drawing.Color.DarkGray;
            this.pnlDate.Controls.Add(this.dtpDateFrom);
            this.pnlDate.Controls.Add(this.dtpDateTo);
            this.pnlDate.Controls.Add(this.label1);
            this.pnlDate.Controls.Add(this.label2);
            this.pnlDate.Location = new System.Drawing.Point(15, 35);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(190, 54);
            this.pnlDate.TabIndex = 10;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CustomFormat = "dd-MM-yyyy";
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(8, 23);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(83, 20);
            this.dtpDateFrom.TabIndex = 7;
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CustomFormat = "dd-MM-yyyy";
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(99, 23);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(83, 20);
            this.dtpDateTo.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "From";
            // 
            // pnlReqNo
            // 
            this.pnlReqNo.BackColor = System.Drawing.Color.DarkGray;
            this.pnlReqNo.Controls.Add(this.label3);
            this.pnlReqNo.Controls.Add(this.txtRequisitionNo);
            this.pnlReqNo.Location = new System.Drawing.Point(15, 35);
            this.pnlReqNo.Name = "pnlReqNo";
            this.pnlReqNo.Size = new System.Drawing.Size(190, 54);
            this.pnlReqNo.TabIndex = 13;
            this.pnlReqNo.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "No";
            // 
            // txtRequisitionNo
            // 
            this.txtRequisitionNo.Location = new System.Drawing.Point(9, 24);
            this.txtRequisitionNo.Name = "txtRequisitionNo";
            this.txtRequisitionNo.Size = new System.Drawing.Size(172, 20);
            this.txtRequisitionNo.TabIndex = 4;
            this.txtRequisitionNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRequisitionNo_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DarkGray;
            this.btnSearch.Location = new System.Drawing.Point(14, 89);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(192, 23);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rbtnNumber
            // 
            this.rbtnNumber.BackColor = System.Drawing.Color.DarkGray;
            this.rbtnNumber.Location = new System.Drawing.Point(114, 18);
            this.rbtnNumber.Name = "rbtnNumber";
            this.rbtnNumber.Size = new System.Drawing.Size(91, 17);
            this.rbtnNumber.TabIndex = 10;
            this.rbtnNumber.Text = "No wise";
            this.rbtnNumber.UseVisualStyleBackColor = false;
            // 
            // rbtnDate
            // 
            this.rbtnDate.BackColor = System.Drawing.Color.DarkGray;
            this.rbtnDate.Checked = true;
            this.rbtnDate.Location = new System.Drawing.Point(15, 18);
            this.rbtnDate.Name = "rbtnDate";
            this.rbtnDate.Size = new System.Drawing.Size(99, 17);
            this.rbtnDate.TabIndex = 11;
            this.rbtnDate.TabStop = true;
            this.rbtnDate.Text = "Date wise";
            this.rbtnDate.UseVisualStyleBackColor = false;
            this.rbtnDate.CheckedChanged += new System.EventHandler(this.rbtnDate_CheckedChanged);
            // 
            // Output
            // 
            this.Output.Controls.Add(this.lstSearcheResult);
            this.Output.Location = new System.Drawing.Point(12, 124);
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(221, 318);
            this.Output.TabIndex = 0;
            this.Output.TabStop = false;
            this.Output.Text = "Output";
            // 
            // lstSearcheResult
            // 
            this.lstSearcheResult.FormattingEnabled = true;
            this.lstSearcheResult.Location = new System.Drawing.Point(15, 19);
            this.lstSearcheResult.Name = "lstSearcheResult";
            this.lstSearcheResult.Size = new System.Drawing.Size(190, 290);
            this.lstSearcheResult.TabIndex = 0;
            this.lstSearcheResult.DoubleClick += new System.EventHandler(this.lstSearcheResult_DoubleClick);
            // 
            // frmSearchGeneric
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 453);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSearchGeneric";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search";
            this.Load += new System.EventHandler(this.frmSearchGeneric_Load);
            this.panel1.ResumeLayout(false);
            this.gbCriteria.ResumeLayout(false);
            this.pnlDate.ResumeLayout(false);
            this.pnlDate.PerformLayout();
            this.pnlReqNo.ResumeLayout(false);
            this.pnlReqNo.PerformLayout();
            this.Output.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox Output;
        private System.Windows.Forms.ListBox lstSearcheResult;
        private System.Windows.Forms.GroupBox gbCriteria;
        private System.Windows.Forms.Panel pnlReqNo;
        private System.Windows.Forms.Panel pnlDate;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRequisitionNo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RadioButton rbtnNumber;
        private System.Windows.Forms.RadioButton rbtnDate;
    }
}