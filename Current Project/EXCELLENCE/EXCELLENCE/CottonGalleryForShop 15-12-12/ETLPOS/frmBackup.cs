using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ETL.BLL;
using ETL.Model;
using ETL.Common;

namespace ETLPOS
{
    public partial class frmBackup : Form
    {
        public frmBackup()
        {
            InitializeComponent();
        }
        private bool CheckData()
        {
            if (txtLocation.Text.Trim() == "")
            {
                MessageBox.Show("Select BackUp Location!!");
                return false;
            }
            if (txtFileName.Text.Trim() == "")
            {
                MessageBox.Show("Enter File Name!!");
                txtFileName.Focus();
                return false;
            }
            return true;
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtLocation.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                CCommonBO oCommon = new CCommonBO();
                string loc = txtLocation.Text.Trim() + "\\"+DateTime.Now.Ticks + "" + txtFileName.Text.Trim();
                if (oCommon.Backupdb(loc))
                {
                    MessageBox.Show("BackUp Data Base successfully!!");
                    txtLocation.Text = "";
                    txtFileName.Text = "";
                }
            }
        }
    }
}
