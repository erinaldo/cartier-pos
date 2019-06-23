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
    public partial class frmCompany : BaseForm
    {

        #region "Declaration"


        bool IsUpdateMode = false;


        #endregion


        public frmCompany()
        {
            InitializeComponent();
            LoadAllCompany();
        }

        private void LoadAllCompany()
        {
            lv_CCSDDSS.Items.Clear();

            List<CCompany> oList;
            CCompanyBO oCompanyBO = new CCompanyBO();
            CResult oResult = new CResult();

            oResult = oCompanyBO.ReadAll();
            
            if (oResult.IsSuccess)
            {
                oList = (List<CCompany>) oResult.Data;
                Load_lv_CCSDDSS(oList);
            }
        }
        private void Load_lv_CCSDDSS(List<CCompany> oList)
        {
            lv_CCSDDSS.Items.Clear();

            if (oList.Count > 0)
            {
                foreach (CCompany oCompany in oList)
                {
                    ListViewItem oItem = new ListViewItem();

                    oItem.Name = oCompany.Comp_OId;
                    oItem.Text = oCompany.Comp_Code;
                    oItem.SubItems.Add(oCompany.Comp_Name);
                    oItem.SubItems.Add(oCompany.Comp_Branch);
                    
                    oItem.SubItems.Add(oCompany.Comp_FullName);
                    oItem.SubItems.Add(oCompany.Comp_Street);
                    oItem.SubItems.Add(oCompany.Comp_Road);
                    oItem.SubItems.Add(oCompany.Comp_City);
                    oItem.SubItems.Add(oCompany.Comp_Country);
                    oItem.SubItems.Add(oCompany.Comp_Phone);
                    oItem.SubItems.Add(oCompany.Comp_Mobile);
                    oItem.SubItems.Add(oCompany.Comp_Email);
                    oItem.SubItems.Add(oCompany.Comp_Web);
                    oItem.SubItems.Add(oCompany.Comp_PostalCode);
                    oItem.SubItems.Add(oCompany.Creator);
                    oItem.SubItems.Add(oCompany.CreationDate.ToString());
                    oItem.SubItems.Add(oCompany.UpdateBy);
                    oItem.SubItems.Add(oCompany.UpdateDate.ToString());
                    oItem.SubItems.Add(oCompany.IsActive);
                    
                    lv_CCSDDSS.Items.Add(oItem);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CCompany oCompany = GetFormData();
            CCompanyBO oCompanyBO = new CCompanyBO();
            CResult oResult = new CResult();
            if (validatedata())
            {

                if (txtOId.Text.Trim() != string.Empty)
                {
                    if (DialogResult.OK == MessageBox.Show("Are you wanted to upadte " + txtName.Text + " ?", "Confirmation!", MessageBoxButtons.OKCancel))
                    {
                        oResult = oCompanyBO.Update(oCompany);
                    }
                }

                else
                {
                    if (!IsUpdateMode)
                    {

                        oResult = oCompanyBO.Create(oCompany);

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
                LoadAllCompany();
            }
        }
        
        private CCompany GetFormData()
        {
            CCompany oCompany = new CCompany();

            oCompany.Comp_OId = this.txtOId.Text;
            oCompany.Comp_Branch = currentBranch.CompBrn_Code;
            oCompany.Comp_Code = this.txtCode.Text;
            oCompany.Comp_Name = this.txtName.Text;
            oCompany.Comp_FullName = this.txtFullName.Text;
            oCompany.Comp_Street = this.txtStreet.Text;
            oCompany.Comp_Road = this.txtRoad.Text;
            oCompany.Comp_City = this.txtCity.Text;
            oCompany.Comp_Country = this.txtCountry.Text;
            oCompany.Comp_Phone = this.txtPhone.Text;
            oCompany.Comp_Mobile = this.txtMobile.Text;
            oCompany.Comp_Email = this.txtEmail.Text;
            oCompany.Comp_Web = this.txtWeb.Text;
            oCompany.Comp_PostalCode = this.txtPostalCode.Text;
            oCompany.Creator = currentUser.User_OID;
            oCompany.CreationDate = DateTime.Now;
            oCompany.UpdateBy = currentUser.User_OID;
            oCompany.UpdateDate = DateTime.Now;
            oCompany.IsActive = this.chkIsActive.Checked ? "Y" : "N";

            return oCompany;
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CCompany oCompany = GetFormData();
            CCompanyBO oCompanyBO = new CCompanyBO();
            CResult oResult = new CResult();
            if (DialogResult.OK == MessageBox.Show("Are you want to delete " + txtCode.Text + " ?", "Confirmation!", MessageBoxButtons.OKCancel))
            {
                oResult = oCompanyBO.Update(oCompany);
            }
            if (oResult.IsSuccess)
            {
                MessageBox.Show("Updated successfully");
            }
            else
            {
                MessageBox.Show(oResult.ErrMsg);
            }
            LoadAllCompany();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Are you want to delete " + txtCode.Text + " ?", "Confirmation!", MessageBoxButtons.OKCancel))
            {
                CCompany oCompany = GetFormData();
                CCompanyBO oCompanyBO = new CCompanyBO();
                CResult oResult = new CResult();

                oResult = oCompanyBO.Delete(oCompany);

                if (oResult.IsSuccess)
                {
                    if (oResult.Data.ToString() == "0")
                    {

                        MessageBox.Show("Deletion Not Possible", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("Deleted successfully");
                       
                    }
                }
                else
                {
                    MessageBox.Show(oResult.ErrMsg);
                }
                LoadAllCompany();
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
                    FormControlMode(1);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFormData();
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


        private void ClearFormData()
        {
            this.txtOId.Text = "";
            txtCode.Text = "";
            txtName.Text = "";

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
            FormControlMode(0);
        }

        private void frmCompany_Load(object sender, EventArgs e)
        {
            FormControlMode(0);
        }
    }
}