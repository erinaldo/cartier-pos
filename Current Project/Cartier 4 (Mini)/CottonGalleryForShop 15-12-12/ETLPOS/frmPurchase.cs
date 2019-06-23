using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Model;
using BLL;
using ETL.Common;
using System.Collections;
using ETL.BLL;
using ETL.Model;

namespace ETLPOS
{
    public partial class frmPurchase : ETLPOS.BaseForm
    {
        public frmPurchase()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CPurchase oPurchase = new CPurchase();
            CPurchaseBO oPurchaseBO = new CPurchaseBO();
            CResult oResult = new CResult();
            if (ValidateData())
            {
                oResult = oPurchaseBO.Create(GetFormData(oPurchase));
                if (oResult.IsSuccess)
                {
                    MessageBox.Show("          Saved successfully              ");

                    FillPurchaseList();
                }
                else
                {
                    MessageBox.Show("         Not Saved         " + oResult.ErrMsg + "");

                }
                ClearControl(groupBox1);
            }
        }

        private void ClearControl(GroupBox groupBox)
        {
            foreach (Control oControl in groupBox.Controls)
            {
                if (oControl.GetType() == typeof(TextBox))
                {
                    oControl.Text = "";
                }
                else if (oControl.GetType() == typeof(ComboBox))
                {
                    oControl.Text = "";
                }
            }
        }

        private void FillPurchaseList()
        {
            lvPurchasetList.Items.Clear();
            CPurchaseBO oPurchaseBO = new CPurchaseBO();
            CResult oresult = new CResult();
            List<CPurchase> oPurchaseList = new List<CPurchase>();
            oresult = oPurchaseBO.ReadAllByFromToDate(dtpFromDate.Value.Date, dtpToDate.Value.Date);
            if (oresult.IsSuccess)
            {
                if (oresult.Data != null)
                {
                    int i = 0;
                    foreach (CPurchase oPurchase in oresult.Data as ArrayList)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = (i + 1).ToString("00");
                        lvi.SubItems.Add(oPurchase.Purchase_PartyName);
                        lvi.SubItems.Add(oPurchase.Purchase_GroupName);
                        lvi.SubItems.Add(oPurchase.Purchase_Quantity.ToString());
                        lvi.SubItems.Add(oPurchase.Purchase_Date.ToShortDateString());
                        lvi.SubItems.Add(oPurchase.Purchase_Amount.ToString());
                        lvi.Tag = oPurchase;
                        lvPurchasetList.Items.Add(lvi);
                        i++;
                    }
                }
            }
            else
            {
                MessageBox.Show(oresult.ErrMsg);
            }
        }

        private CPurchase GetFormData(CPurchase oPurchase)
        {
            if (txtOId.Text != "")
            {
                oPurchase.Purchase_OID = txtOId.Text.Trim();
            }
            oPurchase.Purchase_Branch = currentBranch.CompBrn_Code;
            oPurchase.Purchase_PartyOID = ddlPartyName.SelectedValue.ToString();
            oPurchase.Purchase_PartyName = ddlPartyName.SelectedText;
            oPurchase.Purchase_GroupID = ddlGroupName.SelectedValue.ToString();
            oPurchase.Purchase_GroupName = ddlGroupName.SelectedText;
            oPurchase.Purchase_Description = txtDescription.Text.Trim();
            oPurchase.Purchase_Quantity = float.Parse(txtPurchaseQuantity.Text.Trim());
            oPurchase.Purchase_Amount = float.Parse(txtPurchaseAmount.Text.Trim());
            oPurchase.Purchase_CurrencyOID = ddlCurrencyName.SelectedValue.ToString();
            oPurchase.Purchase_CurrencyRate = float.Parse(txtPurchaseCurrencyRate.Text.Trim());
            oPurchase.Purchase_Invoice = txtPurchaseInvoiceNo.Text.Trim();
            oPurchase.Purchase_Date = dtpPurchaseDate.Value.Date;
            if (rbYes.Checked == true)
            {
                oPurchase.Purchase_Status = 1;
            }
            else if (rbYes.Checked == false)
            {
                oPurchase.Purchase_Status = 0;
            }
            oPurchase.Purchase_Creator = currentUser.User_OID;
            oPurchase.CreationDate = DateTime.Now.Date;
            oPurchase.Purchase_UpdateBy = currentUser.User_OID;
            oPurchase.UpdateDate = DateTime.Now.Date;


            return oPurchase;
        }

        private bool ValidateData()
        {
            if (ddlPartyName.Text.Trim() == "")
            {
                MessageBox.Show("Please Select Party Name", "ETLPOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (ddlGroupName.Text.Trim() == "")
            {
                MessageBox.Show("Please Select Group Name", "ETLPOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (txtPurchaseQuantity.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Purchase Quantity", "ETLPOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (txtPurchaseAmount.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Purchase Amount", "ETLPOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (txtPurchaseCurrencyRate.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Purchase Currency", "ETLPOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (txtPurchaseInvoiceNo.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Purchase Invoice No", "ETLPOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (rbYes.Checked == false && rbNo.Checked == false)
            {
                MessageBox.Show("Please Checke The Payment Receipet Confirmation", "ETLPOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void frmPurchase_Load(object sender, EventArgs e)
        {
            BindPartyName();
            BindGroupName();
            BindCurrency();
            FillPurchaseList();
        }

        private void BindCurrency()
        {
            CCurrencyBO oCurrencyBO = new CCurrencyBO();
            CResult oresult = new CResult();
            oresult = oCurrencyBO.ReadAll();
            if (oresult.IsSuccess)
            {
                try
                {
                    ddlCurrencyName.DataSource = oresult.Data;
                    ddlCurrencyName.DisplayMember = "Curr_Code";
                    ddlCurrencyName.ValueMember = "Curr_OID";
                    ddlCurrencyName.SelectedIndex = 0;
                }
                catch (Exception ex) { }
            }
            else
            {
                ddlCurrencyName.Text = "ERROR in loading";
            }
        }

        private void BindGroupName()
        {
            CItemBO oitembo = new CItemBO();
            CResult oresult = new CResult();
            CItemGroup oitemGroup = new CItemGroup();
            oresult = oitembo.ReadAll(oitemGroup);
            if (oresult.IsSuccess)
            {
                try
                {
                    ddlGroupName.DataSource = oresult.Data;
                    ddlGroupName.DisplayMember = "Catg_Name";
                    ddlGroupName.ValueMember = "Catg_OID";
                    ddlGroupName.SelectedValue="CatgXXXXBRN01 0000000024";
                    //ddlGroupName.SelectedIndex = 0;
                }
                catch (Exception ex) { }
            }
            else
            {
                ddlGroupName.Text = "ERROR in loading";
            }
        }

        private void BindPartyName()
        {
            CPartyBO oPartyBO = new CPartyBO();
            CResult oResult = oPartyBO.ReadAll();
            if (oResult.IsSuccess)
            {
                ArrayList oPartyList = oResult.Data as ArrayList;
                ddlPartyName.DataSource = oPartyList;
                ddlPartyName.DisplayMember = "Party_Name";
                ddlPartyName.ValueMember = "Party_OID";
                ddlPartyName.SelectedIndex = 0;
            }
            else
            {
                ddlPartyName.Text = "Error In Loading";
            }
        }

        private void lvPurchasetList_DoubleClick(object sender, EventArgs e)
        {
            if (lvPurchasetList.SelectedItems.Count > 0)
            {
                CPurchase oPurchase = lvPurchasetList.FocusedItem.Tag as CPurchase;
                txtOId.Text = oPurchase.Purchase_OID;
                ddlPartyName.SelectedText = oPurchase.Purchase_PartyName;
                ddlPartyName.SelectedValue = oPurchase.Purchase_PartyOID;
                ddlGroupName.SelectedText = oPurchase.Purchase_GroupName;
                ddlGroupName.SelectedValue = oPurchase.Purchase_GroupID;
                txtDescription.Text = oPurchase.Purchase_Description.Trim();
                txtPurchaseQuantity.Text = oPurchase.Purchase_Quantity.ToString();
                txtPurchaseAmount.Text = oPurchase.Purchase_Amount.ToString();
                ddlCurrencyName.SelectedText = oPurchase.Purchase_CurrencyName;
                ddlCurrencyName.SelectedValue = oPurchase.Purchase_CurrencyOID;
                txtPurchaseCurrencyRate.Text = oPurchase.Purchase_CurrencyRate.ToString();
                txtPurchaseInvoiceNo.Text = oPurchase.Purchase_Invoice;
                dtpPurchaseDate.Value = oPurchase.Purchase_Date.Date;
                if (oPurchase.Purchase_Status == 1)
                {
                    rbYes.Select();
                }
                else if (oPurchase.Purchase_Status != 1)
                {
                    rbNo.Select();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CPurchase oPayment = lvPurchasetList.FocusedItem.Tag as CPurchase;
            CPurchaseBO oPartyBO = new CPurchaseBO();
            CResult oResult = new CResult();
            if (ValidateData())
            {
                oResult = oPartyBO.Update(GetFormData(oPayment));
                if (oResult.IsSuccess)
                {
                    MessageBox.Show("Update successfully");
                    FillPurchaseList();
                }
                else
                {
                    MessageBox.Show("Not Updated" + oResult.ErrMsg + "");

                }
                ClearControl(groupBox1);
                FillPurchaseList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtOId.Text != string.Empty)
            {
                if ((MessageBox.Show("Do u really want to delete this item. ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) == DialogResult.Yes)
                {
                    CPurchase oPurchase = GetFormData();
                    CPurchaseBO oPurchaseBO = new CPurchaseBO();
                    CResult oresult = new CResult();
                    oresult = oPurchaseBO.Delete(oPurchase);
                    if (oresult.IsSuccess == true)
                    {

                        //if (oresult.Data.ToString() == "0")
                        //{

                        //    MessageBox.Show("Deletion Not Possible", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    FillPaymentList();
                        //    ClearControl(groupBox1);

                        //}

                        //else
                        //{

                        MessageBox.Show("Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FillPurchaseList();
                        ClearControl(groupBox1);
                        //}
                    }

                    else
                    {
                        MessageBox.Show("Error" + oresult.ErrMsg + "");

                    }
                }
            }
        }

        private CPurchase GetFormData()
        {
            CPurchase oPurchase = new CPurchase();
            oPurchase.Purchase_OID = txtOId.Text.Trim();
            return oPurchase;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControl(groupBox1);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            FillPurchaseList();
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            FillPurchaseList();
        }

        private void txtPurchaseQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(e.KeyChar >= 48 && e.KeyChar <= 57) && !(e.KeyChar == 8) && !(e.KeyChar==46))
            {
                e.Handled = true;
            }
        }
    }
}
