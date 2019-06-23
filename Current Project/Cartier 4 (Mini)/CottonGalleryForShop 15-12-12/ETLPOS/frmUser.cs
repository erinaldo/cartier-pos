using System;
using System.Collections.Generic;
using System.Collections;
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
    public partial class frmUser : BaseForm
    {
        #region "Declaration"


        bool IsUpdateMode = false;


        #endregion
        
        
        public frmUser()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormControlMode(int i)
        {
            switch (i)
            {
                case 0:
                    btnSave.Text = "Save User";
                   // btnDelete.Enabled = false;
                    IsUpdateMode = false;
                     txtLoginID.Enabled = true;
                    break;
                case 1:
                    btnSave.Text = "Update User";
                  //  btnDelete.Enabled = true;
                    IsUpdateMode = true;
                      txtLoginID.Enabled = false;
                    break;
            }
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dgUserList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
           
                CUserBO oUserBO = new CUserBO();
                CResult oResult = new CResult();

                if (txtHiddenOID.Text.Trim() != string.Empty)
                {

                    if (DialogResult.OK == MessageBox.Show("Are you wanted to upadte the Item " + txtLoginID.Text + " ?", "Confirmation!", MessageBoxButtons.OKCancel))
                    {
                        string oid = txtHiddenOID.Text;
                        string Status = cmbStatus.Text;
                        string Type = cmbUserType.Text;
                        string Branch =  cmbBranch.Text;
                        string Pass = txtPassward.Text;
                        if (ValidateToSaveData())
                        {
                            oResult = oUserBO.Update(oid, Type, Status, Pass);
                            ClearFormData();
                           // MessageBox.Show("Successfully Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

                else
                {
                    if (ValidateToSaveData())
                    {
                        oResult = oUserBO.Create(GetToSaveData());
                    }
                }
                if (oResult.IsSuccess)
                {
                    ClearFormData();
                    MessageBox.Show("Successfully Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUserData();
                }

                //else
                //{
                //    MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}

            }
        

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private bool ValidateToSaveData()
        {

            if (txtLoginID.Text == "")
            {
                MessageBox.Show("Please Enter User/Login ID", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLoginID.Focus();
                return false;
            }
            //if (cmbUserName.Text == "")
            //{
            //    MessageBox.Show("Please Enter User Name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    cmbUserName.Focus();
            //    return false;
            //}

            if (txtPassward.Text == "")
            {
                MessageBox.Show("Please Enter Passward", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassward.Focus();
                return false;
            }
            if (txtCPassward.Text == "")
            {
                MessageBox.Show("Please Confirm-Passward", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCPassward.Focus();
                return false;
            }

            if (txtPassward.Text != txtCPassward.Text)
            {
                MessageBox.Show("Passward Does Not Match", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCPassward.Focus();
                return false;
            }

            if (cmbUserType.Text=="")
            {
                MessageBox.Show("Please Select User Type", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbUserType.Focus();
                return false;
            }

            if (cmbStatus.Text== "")
            {
                MessageBox.Show("Please Select User Status", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbStatus.Focus();
                return false;
            }

            if (cmbBranch.Text == "")
            {
                MessageBox.Show("Please Select User Branch", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbBranch.Focus();
                return false;
            }

            else
                return true;
        }


        private void ClearFormData()
        {
            txtHiddenOID.Text = "";
            txtLoginID.Text = "";
            cmbUserName.Text = "";
            txtPassward.Text = "";
            txtCPassward.Text = "";
            cmbUserType.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            FormControlMode(0);
        }
        private CUser GetToSaveData()
        {
            CUser oUser = new CUser();
            oUser.User_Branch = currentBranch.CompBrn_Code;
            oUser.User_UserID = txtLoginID.Text;
            oUser.User_UserName = cmbUserName.Text;
            oUser.User_Passward = txtPassward.Text;
            oUser.User_UserType = cmbUserType.Text;
            oUser.User_UserStatus = cmbStatus.Text;
          //  oUser.User_CreatedDate = "Created DAte";
            //oUser.Phone = txtPhone.Text;

            return oUser;
        }

        private void LoadUserData()
        {
            lvUserList.Items.Clear();
            CUserBO oUserBO = new CUserBO();
            CResult oResult = new CResult();
            CUser oUser = new CUser();

            oResult = oUserBO.ReadAllUserData(oUser);
            if (oResult.IsSuccess)
            {
                foreach (CUser obj in oResult.Data as ArrayList)
                {
                    ListViewItem oItem = new ListViewItem();
                    oItem.Text = obj.User_OID.ToString();
                    oItem.SubItems.Add(obj.User_UserID).ToString();

                   // oItem.SubItems.Add(obj.User_UserName).ToString();
                    oItem.SubItems.Add(obj.User_UserType).ToString();
                    oItem.SubItems.Add(obj.User_Branch).ToString();
                    oItem.SubItems.Add(obj.User_UserStatus).ToString();
                    oItem.SubItems.Add(obj.User_Passward).ToString();
                    lvUserList.Items.Add(oItem);
                }







                //dgvUserList.DataSource = oResult.Data;
            }
            else
            {
                MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            LoadUserData();
            LoadEmployee();
            LoadAllCompanyBranch();
           // cmbUserType.SelectedIndex = 0;
           
        }

        private void LoadAllCompanyBranch()
        {
            List<CCompanyBranch> oList;
            CCompanyBranchBO oCompanyBranchBO = new CCompanyBranchBO();
            CResult oResult = new CResult();

            oResult = oCompanyBranchBO.ReadAll();

            if (oResult.IsSuccess)
            {
                oList = (List<CCompanyBranch>)oResult.Data;
                //Load_lv_CCSDDSS(oList);

               // ArrayList oEmployeeList = oResult.Data as ArrayList;
                cmbBranch.DataSource = oList;
                cmbBranch.DisplayMember = "CompBrn_Name";
                cmbBranch.ValueMember = "CompBrn_Code";
                cmbBranch.SelectedIndex = -1;




            }
        }
        private void LoadEmployee()
        {

            CEmployeeBO oEmployeebo = new CEmployeeBO();
            CResult oresult = new CResult();
            CEmployee oEmployee = new CEmployee();
            oresult = oEmployeebo.ReadAllEmployee(oEmployee);
            if (oresult.IsSuccess)
            {

                //ddlEmployeeType.Employees.Add(new ListEmployee("Select one Employee","NA"));
                ArrayList oEmployeeList = oresult.Data as ArrayList;
                cmbUserName.DataSource = oEmployeeList;
                cmbUserName.DisplayMember = "Name";
                cmbUserName.ValueMember = "ID";
                cmbUserName.SelectedIndex = -1;
                //foreach (CEmployeeType oEmployeetype1 in oresult.Data as ArrayList)
                //{
                //    ddlEmployeeType.Employees.Add(new ListEmployee(oEmployeetype1.TypeName, oEmployeetype.TypeID.ToString()));

                //}

            }
            else
            {
                cmbUserName.Text = "ERROR in loading";
            }
        }

     


        private void lvUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvUserList.SelectedIndices.Count > 0)
            {
                ListViewItem oItem = lvUserList.SelectedItems[0];
                if (oItem != null)
                {
                    txtHiddenOID.Text = oItem.Text;
                   // cmbUserName.Text = oItem.SubItems[1].Text;
                    txtLoginID.Text = oItem.SubItems[1].Text;
                    cmbUserType.Text = oItem.SubItems[2].Text;
                    cmbBranch.SelectedItem = oItem.SubItems[3].Text;
                    cmbStatus.Text = oItem.SubItems[4].Text;
                    txtCPassward.Text = oItem.SubItems[5].Text;
                    txtPassward.Text = oItem.SubItems[5].Text;
                    FormControlMode(1);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (DialogResult.OK == MessageBox.Show("Are you want to delete User " + cmbUserName.Text + " ?", "Confirmation!", MessageBoxButtons.OKCancel))
            {

                CUserBO oUserBO = new CUserBO();
                CResult oResult = new CResult();

                oResult = oUserBO.Delete(GetToSaveData());

                ClearFormData();

                if (oResult.IsSuccess)
                {
                    MessageBox.Show("Deleted successfully");
                }

                else
                {
                    MessageBox.Show(oResult.ErrMsg);
                }
                LoadUserData();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtLoginID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            frmEmployee oEmployee = new frmEmployee();
           // oEmployee.MdiParent = this;
            oEmployee.Show();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFormData();
        }

       

       

     
     

        //private void lvUserList_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (lvUserList.Items.Count > 0)
        //    {
        //        ListViewItem oItem = lvUserList.SelectedItems[0];
        //        if (oItem != null)
        //        {

        //            txtUserName.Text = oItem.Text;
        //           // cmbUserType.Text = oItem.SubItems[1].Text.ToString();
        //        }
        //    }


        //    //private void lvUserList_SelectedIndexChanged(object sender, EventArgs e)
        //    //{
        //    //    //if (lvUserList.SelectedItems != -1)
        //    //    //{
        //    //    if (lvUserList.Items.Count > 0)
        //    //    {
        //    //        ListViewItem oUser = lvUserList.SelectedItems[0];
        //    //        if (oUser != null)
        //    //        {

        //    //            txtUserName.Text = oUser.Text;
        //    //            cmbUserType.Text = oUser.SubItems[1].Text;
        //    //        }

        //    //    }
        //    //    //}

        //    //    //if (lv_CCSDDSS.SelectedItems.Count > 0)
        //    //    //{
        //    //    //    ListViewItem oItem = lv_CCSDDSS.SelectedItems[0];
        //    //    //    if (oItem != null)
        //    //    //    {
        //    //    //        txtCode.Text = oItem.Text;
        //    //    //        txtName.Text = oItem.SubItems[1].Text;
        //    //    //    }
        //    //    //}






        //    //}

        //}
    }
}
