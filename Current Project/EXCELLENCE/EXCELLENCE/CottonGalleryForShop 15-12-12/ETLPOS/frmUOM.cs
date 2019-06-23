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
    public partial class frmUOM : BaseForm
    {
        #region "Declaration"


        bool IsUpdateMode = false;


        #endregion
        
        
        
        
        public frmUOM()
        {
            InitializeComponent();
        }

        private void gbUOMType_Enter(object sender, EventArgs e)
        {

        }

        private void frmUOM_Load(object sender, EventArgs e)
        {
            LoadUOMType();
          //  GetGRNextCode();
            ClearFormData();
           FormControlMode(0);
        }

        private void FormControlMode(int i)
        {
            switch (i)
            {
                case 0:
                    btnSave.Text = "Save";
                    btnDelete.Enabled = false;
                    IsUpdateMode = false;
                    txtUOMCode.Enabled = true;
                    break;
                case 1:
                    btnSave.Text = "Update";
                    btnDelete.Enabled = true;
                    IsUpdateMode = true;
                    txtUOMCode.Enabled = false;
                    break;
            }
        }

        private void ClearFormData()
        {
            LLUOMType.SelectedIndex = -1;
            txtUOMid.Text = "";
            txtUOMCode.Text = "";
            txtRemarks.Text = "";
            txtUOMName.Text = "";
            FormControlMode(0);
        }

        private void LoadUOMType()
        {
            CUOMBO oUOMBO = new CUOMBO();
            CResult oresult = new CResult();
            oresult = oUOMBO.ReadAll();
            if (oresult.IsSuccess)
            {
                LLUOMType.DisplayMember = "UOM_Code";
                LLUOMType.ValueMember = "UOM_OID";
                LLUOMType.DataSource = oresult.Data;
            }
            else
            {
                MessageBox.Show(oresult.ErrMsg);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearFormData();
        }

        private void LLUOMType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LLUOMType.SelectedIndex != -1)
            {
                if (LLUOMType.Items.Count > 0)
                {

                    CUOM oCUOM = (CUOM)LLUOMType.SelectedItem;
                    txtUOMid.Text = oCUOM.UOM_OID.ToString();
                    txtUOMCode.Text = oCUOM.UOM_Code;
                    txtUOMName.Text = oCUOM.UOM_Name;
                    txtRemarks.Text = oCUOM.Remarks;
                    FormControlMode(1);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CUOM oUOM = Getformdata();
            CUOMBO oUOMBO = new CUOMBO();
            CResult oresult = new CResult();
            if (validatedata())
            {
                if (txtUOMid.Text.Trim() != string.Empty)
                {
                    if (DialogResult.OK == MessageBox.Show("Are you wanted to upadte " + txtUOMCode.Text + " ?", "Confirmation!", MessageBoxButtons.OKCancel))
                    {
                        oresult = oUOMBO.Update(oUOM);
                    }
                }
                else
                {
                    if (!IsUpdateMode)
                    {

                        oresult = oUOMBO.Create(oUOM);

                    }
                }

                if (oresult.IsSuccess)
                {
                    LoadUOMType();
                    ClearFormData();
                }
                else
                {
                    MessageBox.Show("Not Saved"+ oresult.ErrMsg +"");

                }
            }


        }



        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    if (validatedata())
        //    {
        //        CResult oResult = new CResult();
        //        CGRBO oGRBO = new CGRBO();
        //        CGRMaster oMaster = GetToBSavedData();

        //        if (oMaster != null)
        //        {
        //            if (!IsUpdateMode)
        //            {
        //                oResult = oGRBO.Create(oMaster);
        //            }
        //            else
        //            {
        //                oResult = oGRBO.Update(oMaster);
        //            }

        //            if (oResult.IsSuccess)
        //            {
        //                MessageBox.Show("Successfully Done. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                ClearFormData();
        //                GetGRNextCode();
        //            }
        //            else
        //            {
        //                MessageBox.Show(oResult.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //    }
        //}


  





        private bool validatedata()
        {
            if (txtUOMCode.Text == "")
            {
                MessageBox.Show("Please Give UOM name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUOMCode.Focus();
                return false;
            }
            return true;
        }


        private CUOM Getformdata()
        {
            CUOM oUOM = new CUOM();
            oUOM.UOM_OID = txtUOMid.Text.Trim();
            oUOM.UOM_Branch = currentBranch.CompBrn_Code;
            oUOM.UOM_Code = txtUOMCode.Text.Trim();
            oUOM.UOM_Name = txtUOMName.Text.Trim();
            oUOM.Remarks= txtRemarks.Text.Trim();
            oUOM.CreationDate = DateTime.Now;
            oUOM.Creator = currentUser.User_OID;
            oUOM.UpdateBy = currentUser.User_OID;
            oUOM.UpdateDate = DateTime.Now;
            oUOM.IsActive = "Y";
            return oUOM;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Do u really want to delete this item. ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) == DialogResult.Yes)
            {
                CUOM oUOM = Getformdata();
                CUOMBO oUOMBO = new CUOMBO();
                CResult oresult = new CResult();
                if (txtUOMid.Text.Trim()!=string.Empty)
                {
                    oresult = oUOMBO.Delete(oUOM);
                    if (oresult.IsSuccess == true)
                    {

                        if (oresult.Data.ToString() == "0")
                        {
                            
                            MessageBox.Show("Deletion Not Possible", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUOMType();
                            ClearFormData();

                        }

                        else
                        {

                            MessageBox.Show("Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUOMType();
                            ClearFormData();
                        }
                    }

                    else
                    {
                        MessageBox.Show("Error" + oresult.ErrMsg + "");

                    }
                
                
                }
            }
        }
       
    }
}