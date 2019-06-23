using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ETL.BLL;
using ETL.Model;
using ETL.Common;


namespace ETLPOS
{
    public partial class frmItemType : BaseForm
    {

        #region "Declaration"


        bool IsUpdateMode = false;


        #endregion
        
        public frmItemType()
        {
            InitializeComponent();
        }

        private void frmIT_Load(object sender, EventArgs e)
        {
            LoadItemType();
            Clearformdata();
           
        }

        private void LoadItemType()
        {
            CItemBO oitembo = new CItemBO();
            CResult oresult = new CResult();
            CItemType oitemtype = new CItemType();
            oresult = oitembo.ReadAll(oitemtype);
            if (oresult.IsSuccess)
            {
                try
                {
                    LLItemType.DataSource = oresult.Data;
                    LLItemType.DisplayMember = "ITyp_Code";
                    LLItemType.ValueMember = "ITyp_OID";
                }
                catch (Exception ex) { }
            }
            else
            {
                MessageBox.Show(oresult.ErrMsg);
            }
        }

        private void LLItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LLItemType.SelectedIndex != -1)
            {
                if (LLItemType.Items.Count > 0)
                {
                    CItemType oitemtype = (CItemType)LLItemType.SelectedItem;
                    txttypeid.Text = oitemtype.ITyp_OID.ToString();
                    txtCode.Text = oitemtype.ITyp_Code;
                    txtName.Text = oitemtype.ITyp_Name;
                    txtRemarks.Text = oitemtype.Remarks;
                    FormControlMode(1);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Clearformdata();
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


        private void Clearformdata()
        {
            LLItemType.SelectedIndex = -1;
            txtCode.Text = "";
            txttypeid.Text = "";
            txtRemarks.Text = "";
            txtName.Text = "";
            FormControlMode(0);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            CItemType oitemtype = Getformdata();
            CItemBO oitembo = new CItemBO();
            CResult oresult= new CResult();
            if (validatedata())
            {
                if (txttypeid.Text.Trim() != string.Empty)
                {
                    if (DialogResult.OK == MessageBox.Show("Are you wanted to upadte " + txtCode.Text + " ?", "Confirmation!", MessageBoxButtons.OKCancel))
                    {
                        oresult = oitembo.Update(oitemtype);
                    }
                }
                else
                {
                    oresult = oitembo.Create(oitemtype);

                }

                if (oresult.IsSuccess)
                {
                    LoadItemType();
                    Clearformdata();
                }
                else
                {
                    MessageBox.Show("Not Saved" + oresult.ErrMsg + "");

                }



            }
        }
        private bool validatedata()
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Please Give Item Type  name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCode.Focus();
                return false;
            }
            //if (txtdesc.Text.Trim() == "")
            //{
            //    MessageBox.Show("Please Give Description.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtdesc.Focus();
            //    return false;
            //}


            return true;
        }
        private CItemType Getformdata()
        {
            CItemType oitemtype = new CItemType();
            if (txttypeid.Text!="")
            oitemtype.ITyp_OID = txttypeid.Text.Trim();
            oitemtype.ITyp_Branch = currentBranch.CompBrn_Code;
            oitemtype.ITyp_Code = txtCode.Text.Trim();
            oitemtype.ITyp_Name = txtName.Text.Trim();
            oitemtype.Remarks = txtRemarks.Text.Trim();
            oitemtype.CreationDate = DateTime.Now;
            oitemtype.Creator = currentUser.User_OID;
            oitemtype.UpdateBy = currentUser.User_OID;
            oitemtype.UpdateDate = DateTime.Now;
            return oitemtype;
        }

        private void gbItemType_Enter(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
             CItemType oitemtype = Getformdata();
            CItemBO oitembo = new CItemBO();
            CResult oresult = new CResult();
            if (validatedata())
            {
                if ((MessageBox.Show("Do u really want to delete this item. ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) == DialogResult.Yes)
                    {
                        oresult = oitembo.Delete(oitemtype);
                    }
               
                if (oresult.IsSuccess == true)
                {

                    if (oresult.Data.ToString() == "0")
                    {

                        MessageBox.Show("Deletion Not Possible", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadItemType();
                        Clearformdata();

                    }
                    else
                    {
                        MessageBox.Show("Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadItemType();
                        Clearformdata();
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
