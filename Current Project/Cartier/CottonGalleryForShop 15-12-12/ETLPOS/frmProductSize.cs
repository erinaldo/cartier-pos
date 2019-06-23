using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ETL.Model;
using ETL.Common;
using ETL.BLL;

namespace ETLPOS
{
    public partial class frmProductSize : BaseForm
    {
        public frmProductSize()
        {
            InitializeComponent();
        }
        bool IsUpdateMode = false;
        private void btnSave_Click(object sender, EventArgs e)
        {
            CSize oCSize = Getformdata();
            CSizeBO oCSizeBO = new CSizeBO();
            CResult oresult = new CResult();
            if (validatedata())
            {
                if (txtSizeid.Text.Trim() != string.Empty)
                {
                    if (DialogResult.OK == MessageBox.Show("Are you wanted to upadte " + txtSIZECode.Text + " ?", "Confirmation!", MessageBoxButtons.OKCancel))
                    {
                        oresult = oCSizeBO.Update(oCSize);
                    }
                }
                else
                {
                    if (!IsUpdateMode)
                    {

                        oresult = oCSizeBO.Create(oCSize);

                    }
                }

                if (oresult.IsSuccess)
                {
                    LoadSizeName();
                    ClearFormData();
                }
                else
                {
                    MessageBox.Show("Not Saved" + oresult.ErrMsg + "");

                }
            }

        }

        private void LoadSizeName()
        {
            CItemBO oitembo = new CItemBO();
            CResult oresult = new CResult();
            oresult = oitembo.ReadAllItemSize();
            if (oresult.IsSuccess)
            {
                LLSIZEType.DataSource = oresult.Data;
                LLSIZEType.DisplayMember = "Size_Name";
                LLSIZEType.ValueMember = "Size_OID";
                
            }
            else
            {
                MessageBox.Show(oresult.ErrMsg);
            }
        }

        private void ClearFormData()
        {
            LLSIZEType.SelectedIndex = -1;
            txtSizeid.Text = "";
            txtSIZECode.Text = "";
            txtRemarks.Text = "";
            txtSIZEName.Text = "";
            FormControlMode(0);
        }

        private bool validatedata()
        {
            if (txtSIZECode.Text == "")
            {
                MessageBox.Show("Please Give UOM name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSIZECode.Focus();
                return false;
            }
            return true;
        }

        private CSize Getformdata()
        {
            CSize oSize = new CSize();
            oSize.Size_OID = txtSizeid.Text.Trim();
            oSize.Size_Branch = currentBranch.CompBrn_Code;
            oSize.Size_Code = txtSIZECode.Text.Trim();
            oSize.Size_Name = txtSIZEName.Text.Trim();
            oSize.Remarks = txtRemarks.Text.Trim();
            oSize.CreationDate = DateTime.Now;
            oSize.Creator = currentUser.User_OID;
            oSize.UpdateBy = currentUser.User_OID;
            oSize.UpdateDate = DateTime.Now;
            oSize.IsActive = "Y";
            return oSize;
        }

        private void frmProductSize_Load(object sender, EventArgs e)
        {
            LoadSizeName();
        }
        private void FormControlMode(int i)
        {
            switch (i)
            {
                case 0:
                    btnSave.Text = "Save";
                    btnDelete.Enabled = false;
                    IsUpdateMode = false;
                    txtSIZECode.Enabled = true;
                    break;
                case 1:
                    btnSave.Text = "Update";
                    btnDelete.Enabled = true;
                    IsUpdateMode = true;
                    txtSIZECode.Enabled = false;
                    break;
            }
        }
        private void LLSIZEType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LLSIZEType.SelectedIndex != -1)
            {
                if (LLSIZEType.Items.Count > 0)
                {

                    CSize oCSize = (CSize)LLSIZEType.SelectedItem;
                    txtSizeid.Text = oCSize.Size_OID.ToString();
                    txtSIZECode.Text = oCSize.Size_Code;
                    txtSIZEName.Text = oCSize.Size_Name;
                    txtRemarks.Text = oCSize.Remarks;
                    FormControlMode(1);
                }
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearFormData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
