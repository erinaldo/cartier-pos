using System;
using System.Collections.Generic;
using System.Collections;
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
    public partial class frmItemGroup : BaseForm
    {


        #region "Declaration"


        bool IsUpdateMode = false;


        #endregion

        public frmItemGroup()
        {
            InitializeComponent();
        }

        private void frmIGR_Load(object sender, EventArgs e)
        {
            LoadGroupType();
            Clearformdata();
            FormControlMode(0);
        }

        private void Clearformdata()
        {
            LLGroupType.SelectedIndex = -1;
            txtGroupid.Text = "";
            txtCode.Text = "";
            txtRemarks.Text = "";
            txtName.Text = "";
            FormControlMode(0);
        }

        private void LoadGroupType()
        {
            CItemBO oitembo = new CItemBO();
            CResult oresult = new CResult();
            CItemGroup oitemGroup = new CItemGroup();
            oresult = oitembo.ReadAll(oitemGroup);
            if (oresult.IsSuccess)
            {
                ArrayList arCategoryList=(ArrayList)oresult.Data;
                if (arCategoryList.Count > 0)
                {
                    LLGroupType.DataSource = arCategoryList;
                    LLGroupType.DisplayMember = "Catg_Code";
                    LLGroupType.ValueMember = "Catg_OID";
                }
            }
            else
            {
                MessageBox.Show(oresult.ErrMsg);
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           
        }

        private void LLGroupType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LLGroupType.SelectedIndex != -1)
            {
                if (LLGroupType.Items.Count > 0)
                {

                    CItemGroup oItemGroup = (CItemGroup)LLGroupType.SelectedItem;
                    txtGroupid.Text = oItemGroup.Catg_OID.ToString();
                    txtCode.Text = oItemGroup.Catg_Code;
                    txtName.Text = oItemGroup.Catg_Name;
                    txtRemarks.Text = oItemGroup.Remarks;
                    FormControlMode(1);
                }
            }
        }

        private bool validatedata()
        {
            CCommonBO comBo = new CCommonBO();
            string sql = "Select * From t_Catg Where Catg_Code='" + txtCode.Text.Trim() + "'";
            if (comBo.IsExistCode(sql))
            {
                MessageBox.Show("Item Group Code Already Exist!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCode.Text = "";
                txtCode.Focus();
                return false;
            }
            if (txtCode.Text == "")
            {
                MessageBox.Show("Please Give Group Code", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCode.Focus();
                return false;
            }

            if (txtCode.Text.Length != 4)
            {
                MessageBox.Show("Please Enter Four Char in Group Code", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCode.Focus();
                return false;
            }

            return true;
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

       


        private CItemGroup Getformdata()
        {
            CItemGroup oCItemGroup = new CItemGroup();
            
            oCItemGroup.Catg_OID = txtGroupid.Text.Trim();
            oCItemGroup.Catg_Branch = currentBranch.CompBrn_Code;
            oCItemGroup.Catg_Code = txtCode.Text.Trim();
            oCItemGroup.Catg_Name=txtName.Text.Trim();
            oCItemGroup.Creator = currentUser.User_OID;
            oCItemGroup.CreationDate = DateTime.Now.Date;
            oCItemGroup.UpdateBy = currentUser.User_OID;
            oCItemGroup.UpdateDate = DateTime.Now.Date;
            oCItemGroup.Remarks= txtRemarks.Text.Trim();

            return oCItemGroup;
        }

        

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            Clearformdata();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            CItemGroup oItemGroup = Getformdata();
            CItemBO oitembo = new CItemBO();
            CResult oresult = new CResult();
            if (validatedata())
            {
                if ((MessageBox.Show("Do u really want to delete this item. ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) == DialogResult.Yes)
                {
                    oresult = oitembo.Delete(oItemGroup);
                }
                if (oresult.IsSuccess == true)
                {
                    if (oresult.Data.ToString() == "0")
                    {

                        MessageBox.Show("Deletion Not Possible", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadGroupType();
                        Clearformdata();

                    }
                    else
                    {
                        MessageBox.Show("Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadGroupType();
                        Clearformdata();
                    }
                }
                else
                {
                    MessageBox.Show("Error" + oresult.ErrMsg + "");

                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CItemGroup oItemGroup = Getformdata();
            CItemBO oitembo = new CItemBO();
            CResult oresult = new CResult();
            if (validatedata())
            {
                if (txtGroupid.Text.Trim() != string.Empty)
                {
                    if (DialogResult.OK == MessageBox.Show("Are you wanted to upadte " + txtCode.Text + " ?", "Confirmation!", MessageBoxButtons.OKCancel))
                    {
                        oresult = oitembo.Update(oItemGroup);
                    }
                }
                else
                {

                    oresult = oitembo.Create(oItemGroup);

                }

                if (oresult.IsSuccess)
                {
                    LoadGroupType();
                    Clearformdata();
                }
                else
                {
                    MessageBox.Show("Not Saved" + oresult.ErrMsg + "");
                   // MessageBox.Show(oresult.ErrMsg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}