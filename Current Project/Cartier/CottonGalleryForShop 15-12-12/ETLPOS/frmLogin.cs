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
using ETL.DAO;

namespace ETLPOS
{
    public partial class frmLogin : BaseForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void UserLogin()
        {
            CUserBO oUserBO = new CUserBO();
            CResult oResult = new CResult();
            string Name = txtUserName.Text;
            string Password = txtPassword.Text;
            // Advance Start
            Password = (txtPassword.Text.Substring(0, 1) == "_") ? txtPassword.Text.Substring(1) : txtPassword.Text;
            defaultUserMode = (txtPassword.Text.Substring(0, 1) == "_") ? false : true;
            // Advance End
            string Branch = cmbBranch.Text.ToString();
            oResult = oUserBO.UserLogin(Name, Password);
            if (oResult.IsSuccess)
            {
                CUser oUser = (CUser)oResult.Data;
                if (oUser!=null)
                {
                    if (oUser.User_UserType == "Admin")
                    {
                        ETLPOSMDI OETLPOSMDI = new ETLPOSMDI();
                        CUserAndBranch oUserAndBranch = new CUserAndBranch();

                        string cuser = txtUserName.Text;
                        string cbrance = cmbBranch.Text;
                        oResult = oUserBO.ReadCurrentUserAndBrance(cuser, cbrance);
                        if (oResult.IsSuccess)
                        {
                            oUserAndBranch = (CUserAndBranch)oResult.Data;

                            currentUser = oUserAndBranch.User;
                            currentBranch = oUserAndBranch.Branch;
                        }
                        else
                        {
                            MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        // Advance Start
                        if (!defaultUserMode) new frmVatClnNo().ShowDialog(this);
                        // Advance End

                        OETLPOSMDI.Show();
                        this.Hide();
                    }
                    else if (oUser.User_UserType == "Sales")
                    {
                        ETLPOSMDI OETLPOSMDI = new ETLPOSMDI(true);
                        CUserAndBranch oUserAndBranch = new CUserAndBranch();

                        string cuser = txtUserName.Text;
                        string cbrance = cmbBranch.Text;
                        oResult = oUserBO.ReadCurrentUserAndBrance(cuser, cbrance);
                        if (oResult.IsSuccess)
                        {
                            oUserAndBranch = (CUserAndBranch)oResult.Data;

                            currentUser = oUserAndBranch.User;
                            currentBranch = oUserAndBranch.Branch;
                        }
                        else
                        {
                            MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        // Advance Start
                        if (!defaultUserMode) new frmVatClnNo().ShowDialog(this);
                        // Advance End

                        OETLPOSMDI.Show();
                        this.Hide();   
                    }
                }

                else
                {
                    MessageBox.Show("Login Information Is Not Valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Advance Start
            defaultUserMode = true;
            // Advance End

            if (ValidateToSaveData())
            {
                UserLogin();
                // this.Dispose();
                // this.Close();
            }
        }

        private bool ValidateToSaveData()
        {

            if (txtUserName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter User/Login ID", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserName.Focus();
                return false;
            }

            if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Password", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
                return false;
            }
            if (cmbBranch.Text == "")
            {
                MessageBox.Show("Please Enter Branch Name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbBranch.Focus();
                return false;
            }

            else
                return true;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            LoadComapanyBranch();
            //if (chkRestoreDB.Checked == true)
            //{
            //    this.LoadComapanyBranch();
            //}
            //else if (chkRestoreDB.Checked == false)
            //{
            //    frmBackupDB ofrmBackupDB = new frmBackupDB();
            //    ofrmBackupDB.ShowDialog();
            //}
        }
        private void LoadComapanyBranch()
        {
            CResult oResult = new CResult();
            CCompanyBranchBO oCompanyBranchBO = new CCompanyBranchBO();
            oResult = oCompanyBranchBO.ReadAll();

            if (oResult.IsSuccess)
            {
                cmbBranch.DataSource = oResult.Data as List<CCompanyBranch>;
                cmbBranch.DisplayMember = "CompBrn_Code";
                cmbBranch.ValueMember = "CompBrn_OId";
            }
            else
            {
                MessageBox.Show("Loading error...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                // Advance Start
                defaultUserMode = true;
                // Advance End

                if (ValidateToSaveData())
                {
                    UserLogin();
                    // this.Dispose();
                    // this.Close();
                }   
            }
        }


        //private void chkBranch_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkBranch.Checked == true)
        //    {
        //        this.LoadComapanyBranch();
        //    }
        //}

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmBackupDB ofrmBackupDB = new frmBackupDB();
           // ofrmBackupDB.ShowDialog();
            this.Cursor = Cursors.Default;
        }
    }
}
    

