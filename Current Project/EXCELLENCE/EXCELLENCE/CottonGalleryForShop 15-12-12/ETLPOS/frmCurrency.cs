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
    public partial class frmCurrency : BaseForm
    {

        #region "Declaration"


        bool IsUpdateMode = false;


        #endregion
        
        
        public frmCurrency()
        {
            InitializeComponent();
        }

        private void gbUOMType_Enter(object sender, EventArgs e)
        {

        }

        private void frmUOM_Load(object sender, EventArgs e)
        {
            LoadUOMType();
            Clearformdata();
            FormControlMode(0);
           
        }

        private void Clearformdata()
        {
            txtCurrOID.Text = "";
            txtCode.Text = "";
            txtName.Text = "";
            FormControlMode(0);
        }

        private void LoadUOMType()
        {
            CCurrency oCurrency = Getformdata();
            CCurrencyBO oCurrencyBO = new CCurrencyBO();
            CResult oresult = new CResult();
            oresult = oCurrencyBO.ReadAll();
            if (oresult.IsSuccess)
            {
                List<CCurrency> oList=new List<CCurrency>();
                oList=oresult.Data as List<CCurrency>;

                //if (oList.Count > 0)
                //{
                    lstCurrency.DisplayMember = "Curr_Code";
                    lstCurrency.ValueMember = "Curr_OID";
                    lstCurrency.DataSource = oList;
                //}
            }
            else
            {
                MessageBox.Show(oresult.ErrMsg);
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


        private void btnReset_Click(object sender, EventArgs e)
        {
            Clearformdata();
        }

        private void LLUOMType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCurrency.SelectedIndex != -1)
            {
                if (lstCurrency.Items.Count > 0)
                {
                    CCurrency oCurrency = (CCurrency)lstCurrency.SelectedItem;
                    txtCurrOID.Text = oCurrency.Curr_OID.ToString();
                    txtCode.Text = oCurrency.Curr_Code;
                    txtName.Text = oCurrency.Curr_Name;
                    FormControlMode(1);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CCurrency oCurrency = Getformdata();
            CCurrencyBO oCurrencyBO = new CCurrencyBO();
            CResult oresult = new CResult();
            if (validatedata())
            {
                if (oCurrency.Curr_OID != "")
                {
                    if (DialogResult.OK == MessageBox.Show("Are you wanted to upadte " + txtCode.Text + " ?", "Confirmation!", MessageBoxButtons.OKCancel))
                    {
                        oresult = oCurrencyBO.Update(oCurrency);
                    }
                }
                else
                {

                    oresult = oCurrencyBO.Create(oCurrency);

                }

                if (oresult.IsSuccess)
                {
                    LoadUOMType();
                    Clearformdata();
                }
                else
                {
                   // MessageBox.Show(oresult.ErrMsg);
                    MessageBox.Show("Not Saved" + oresult.ErrMsg + "");

                }

            }  

        }

        private bool validatedata()
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Please input Currency code. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCode.Focus();
                return false;
            }
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Please input Currency Name. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return false;
            }
            return true;
        }
        
        private CCurrency Getformdata()
        {
            CCurrency oCurrency = new CCurrency();
            if (txtCurrOID.Text != "")
                oCurrency.Curr_OID = txtCurrOID.Text.Trim();
            oCurrency.Curr_Branch= currentBranch.CompBrn_Code;
            oCurrency.Curr_Code=txtCode.Text.Trim();
            oCurrency.Curr_Name=txtName.Text.Trim();

            return oCurrency;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            CCurrency oCurrency = Getformdata();
            CCurrencyBO oCurrencyBO = new CCurrencyBO();
            CResult oResult = new CResult();
            if (validatedata())
            {
                if (DialogResult.OK == MessageBox.Show("Are you want to delete " + txtCode.Text + " ?", "Confirmation!", MessageBoxButtons.OKCancel))
                {
                    oResult = oCurrencyBO.Delete(oCurrency);
                }
                if (oResult.IsSuccess)
                {
                    if (oResult.Data.ToString() == "0")
                    {

                        MessageBox.Show("Deletion Not Possible", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clearformdata();
                        LoadUOMType();

                    }
                    else
                    {
                        MessageBox.Show("Deleted successfully");
                        Clearformdata();
                        LoadUOMType();
                    }
                }

                else
                {
                    MessageBox.Show(oResult.ErrMsg.ToString(), "Error  ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



                    
            }
        }

    

       
    }
}