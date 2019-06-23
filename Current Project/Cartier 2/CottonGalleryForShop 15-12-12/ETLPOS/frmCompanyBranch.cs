using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ETL.BLL;
using ETL.Model;
using ETL.Common;

namespace ETLPOS
{        
    public partial class frmCompanyBranch : BaseForm
    {

        #region "Declaration"


        bool IsUpdateMode = false;


        #endregion
        
        public frmCompanyBranch()
        {
            InitializeComponent();
            LoadAllCompanyBranch();
        }

        private void LoadAllCompanyBranch()
        {
            lv_CCSDDSS.Items.Clear();

            List<CCompanyBranch> oList;
            CCompanyBranchBO oCompanyBranchBO = new CCompanyBranchBO();
            CResult oResult = new CResult();

            oResult = oCompanyBranchBO.ReadAll();
            
            if (oResult.IsSuccess)
            {
                oList = (List<CCompanyBranch>) oResult.Data;
                Load_lv_CCSDDSS(oList);
            }
        }
        private void Load_lv_CCSDDSS(List<CCompanyBranch> oList)
        {
            lv_CCSDDSS.Items.Clear();

            if (oList.Count > 0)
            {
                foreach (CCompanyBranch oCompanyBranch in oList)
                {
                    ListViewItem oItem = new ListViewItem();

                    oItem.Name = oCompanyBranch.CompBrn_OId;
                    oItem.Text = oCompanyBranch.CompBrn_Code;
                    oItem.SubItems.Add(oCompanyBranch.CompBrn_Name);
                    oItem.SubItems.Add(oCompanyBranch.CompBrn_TIN);
                    oItem.SubItems.Add(oCompanyBranch.CompBrn_FullName);
                    oItem.SubItems.Add(oCompanyBranch.CompBrn_Street);
                    oItem.SubItems.Add(oCompanyBranch.CompBrn_Road);
                    oItem.SubItems.Add(oCompanyBranch.CompBrn_City);
                    oItem.SubItems.Add(oCompanyBranch.CompBrn_Country);
                    oItem.SubItems.Add(oCompanyBranch.CompBrn_Phone);
                    oItem.SubItems.Add(oCompanyBranch.CompBrn_Mobile);
                    oItem.SubItems.Add(oCompanyBranch.CompBrn_Email);
                    oItem.SubItems.Add(oCompanyBranch.CompBrn_Web);
                    oItem.SubItems.Add(oCompanyBranch.CompBrn_PostalCode);
                    oItem.SubItems.Add(oCompanyBranch.Creator);
                    oItem.SubItems.Add(oCompanyBranch.CreationDate.ToString());
                    oItem.SubItems.Add(oCompanyBranch.UpdateBy);
                    oItem.SubItems.Add(oCompanyBranch.UpdateDate.ToString());
                    oItem.SubItems.Add(oCompanyBranch.IsActive);
                    oItem.SubItems.Add(oCompanyBranch.CompBrn_IsHeadoffice);
                    
                    lv_CCSDDSS.Items.Add(oItem);
                }
            }
        }

        private void FormControlMode(int i)
        {
            switch (i)
            {
                case 0:
                    btnSave.Text = "Save";
                    btnDelete.Enabled = false;
                    IsUpdateMode = false;
                    txtCode.Enabled = true;
                    break;
                case 1:
                    btnSave.Text = "Update";
                    btnDelete.Enabled = true;
                    IsUpdateMode = true;
                    txtCode.Enabled = false;
                    break;
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            CCompanyBranch oCompanyBranch = GetFormData();
            CCompanyBranchBO oCompanyBranchBO = new CCompanyBranchBO();
            CResult oResult = new CResult();

            oResult = oCompanyBranchBO.Create(oCompanyBranch);

            if (oResult.IsSuccess)
            {
                MessageBox.Show("Saved successfully");
            }
            else
            {
                MessageBox.Show(oResult.ErrMsg);
            }
            LoadAllCompanyBranch();
        }
        
        private CCompanyBranch GetFormData()
        {
            CCompanyBranch oCompanyBranch = new CCompanyBranch();

            oCompanyBranch.CompBrn_OId = this.txtOId.Text;
            oCompanyBranch.CompBrn_Branch = currentBranch.CompBrn_Code;
            oCompanyBranch.CompBrn_Code = this.txtCode.Text;
            oCompanyBranch.CompBrn_Name = this.txtName.Text;
            oCompanyBranch.CompBrn_TIN = this.txtTIN.Text;
            oCompanyBranch.CompBrn_FullName = this.txtFullName.Text;
            oCompanyBranch.CompBrn_Street = this.txtStreet.Text;
            oCompanyBranch.CompBrn_Road = this.txtRoad.Text;
            oCompanyBranch.CompBrn_City = this.txtCity.Text;
            oCompanyBranch.CompBrn_Country = this.txtCountry.Text;
            oCompanyBranch.CompBrn_Phone = this.txtPhone.Text;
            oCompanyBranch.CompBrn_Mobile = this.txtMobile.Text;
            oCompanyBranch.CompBrn_Email = this.txtEmail.Text;
            oCompanyBranch.CompBrn_Web = this.txtWeb.Text;
            oCompanyBranch.CompBrn_PostalCode = this.txtPostalCode.Text;
            oCompanyBranch.Creator = currentUser.User_OID;
            oCompanyBranch.CreationDate = DateTime.Now;
            oCompanyBranch.UpdateBy = currentUser.User_OID;
            oCompanyBranch.UpdateDate = DateTime.Now;
            oCompanyBranch.IsActive = this.chkIsActive.Checked ? "Y" : "N";
            oCompanyBranch.CompBrn_IsHeadoffice = this.chkIsHeadOffice.Checked ? "Y" : "N";
            return oCompanyBranch;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CCompanyBranch oCompanyBranch = GetFormData();
            CCompanyBranchBO oCompanyBranchBO = new CCompanyBranchBO();
            CResult oResult = new CResult();
            if (DialogResult.OK == MessageBox.Show("Are you want to delete " + txtCode.Text + " ?", "Confirmation!", MessageBoxButtons.OKCancel))
            {
                oResult = oCompanyBranchBO.Update(oCompanyBranch);
            }
            if (oResult.IsSuccess)
            {
                MessageBox.Show("Updated successfully");
            }
            else
            {
                MessageBox.Show(oResult.ErrMsg);
            }
            LoadAllCompanyBranch();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Are you want to delete " + txtCode.Text + " ?", "Confirmation!", MessageBoxButtons.OKCancel))
            {
                CCompanyBranch oCompanyBranch = GetFormData();
                CCompanyBranchBO oCompanyBranchBO = new CCompanyBranchBO();
                CResult oResult = new CResult();
                oResult = oCompanyBranchBO.Delete(oCompanyBranch);
                if (oResult.IsSuccess)
                {
                    if (oResult.Data.ToString() == "0")
                    {

                        MessageBox.Show("Deletion Not Possible", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFormData();
                       

                    }
                    else
                    {
                        MessageBox.Show("Deleted successfully");
                        ClearFormData();
                       
                    }
                }
                
                              
                
                else
                {
                    MessageBox.Show(oResult.ErrMsg);
                }
                LoadAllCompanyBranch();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void lv_CCSDDSS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_CCSDDSS.SelectedItems.Count > 0)
            {
                ListViewItem oItem = lv_CCSDDSS.SelectedItems[0];
                if (oItem != null)
                {
                    this.txtOId.Text = oItem.Name;
                    txtCode.Text = oItem.Text;
                    txtName.Text = oItem.SubItems[1].Text;
                    txtTIN.Text = oItem.SubItems[2].Text;
                    this.txtFullName.Text = oItem.SubItems[3].Text;
                    this.txtStreet.Text = oItem.SubItems[4].Text;
                    this.txtRoad.Text = oItem.SubItems[5].Text;
                    this.txtCity.Text = oItem.SubItems[6].Text;
                    this.txtCountry.Text = oItem.SubItems[7].Text;
                    this.txtPhone.Text = oItem.SubItems[8].Text;
                    this.txtMobile.Text = oItem.SubItems[9].Text;
                    this.txtEmail.Text = oItem.SubItems[10].Text;
                    this.txtWeb.Text = oItem.SubItems[11].Text;
                    this.txtPostalCode.Text = oItem.SubItems[12].Text;
                    this.chkIsActive.Checked = (oItem.SubItems[17].Text.Trim().ToUpper() == "Y") ? true : false;
                    this.chkIsHeadOffice.Checked = (oItem.SubItems[18].Text.Trim().ToUpper() == "Y") ? true : false;
                    FormControlMode(1);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFormData();
        }
        private void ClearFormData()
        {
            this.txtOId.Text = "";
            txtCode.Text = "";
            txtName.Text = "";
            txtTIN.Text = "";
            this.txtFullName.Text = "";
            this.txtStreet.Text = "";
            this.txtRoad.Text = "";
            this.txtCity.Text = "";
            this.txtCountry.Text = "";
            this.txtPhone.Text = "";
            this.txtMobile.Text = "";
            this.txtEmail.Text = "";
            this.txtWeb.Text = "";
            this.txtPostalCode.Text = "";
            this.chkIsActive.Checked = true;
            this.chkIsHeadOffice.Checked = false;
            FormControlMode(0);
        }

        private void frmCompanyBranch_Load(object sender, EventArgs e)
        {
            FormControlMode(0);
            chkIsHeadOffice.Checked = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CCompanyBranch oCompanyBranch = GetFormData();
            CCompanyBranchBO oCompanyBranchBO = new CCompanyBranchBO();
            CResult oResult = new CResult();
            if (validatedata())
            {
                if (txtOId.Text.Trim() != string.Empty)
                {

                    if (DialogResult.OK == MessageBox.Show("Are you want to Update " + txtCode.Text + " ?", "Confirmation!", MessageBoxButtons.OKCancel))
                    {
                        oResult = oCompanyBranchBO.Update(oCompanyBranch);
                    }

                }

                else
                {
                    if (!IsUpdateMode)
                    {
                        oResult = oCompanyBranchBO.Create(oCompanyBranch);
                    }
                }
                if (oResult.IsSuccess)
                {
                    MessageBox.Show("Saved successfully");
                }
                else
                {
                    //MessageBox.Show(oResult.ErrMsg);
                    MessageBox.Show("Not Saved" + oResult.ErrMsg + "");

                }
                ClearFormData();
                LoadAllCompanyBranch();
            }
        }


        private bool validatedata()
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Please Give Company Code", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCode.Focus();
                return false;
            }

            if (txtName.Text == "")
            {
                MessageBox.Show("Please Give Company Name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return false;
            }

            return true;
        }

      
    }
}