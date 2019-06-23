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

namespace ETLPOS
{
    public partial class frmPayment : ETLPOS.BaseForm
    {
        public frmPayment()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CPayment oPayment = new CPayment();
            CPaymentBO oPaymentBO = new CPaymentBO();
            CResult oResult = new CResult();
            if (ValidateData())
            {
                oResult = oPaymentBO.Create(GetFormData(oPayment));
                if (oResult.IsSuccess)
                {
                    MessageBox.Show("          Saved successfully              ");

                    FillPaymentList();
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

        private CPayment GetFormData(CPayment oPayment)
        {
            if (txtOId.Text != "")
            {
                oPayment.Payment_OID = txtOId.Text.Trim();
            }
            oPayment.Payment_Branch = currentBranch.CompBrn_Code;
            oPayment.Payment_Date = dtpPaymentDate.Value.Date;
            oPayment.Payment_PartyOID = ddlPartyName.SelectedValue.ToString();
            oPayment.Payment_Amount = float.Parse(txtPaymentAmount.Text.Trim());
            oPayment.Payment_CurrencyOID = ddlCurrency.SelectedValue.ToString();
            oPayment.Payment_CurrencyRate = float.Parse( txtCurrencyRate.Text.Trim());
            oPayment.Payment_BDT = float.Parse( txtPaymentInBDT.Text.Trim());
            oPayment.Payment_Media = txtPaymentMedia.Text.Trim();
            if (rbYes.Checked == true)
            {
                oPayment.Payment_RecieptConfirmation = 1;
            }
            else if (rbYes.Checked == false)
            {
                oPayment.Payment_RecieptConfirmation = 0;
            }
            oPayment.Payment_ReceivedDate = dtpPaymentReceipetDate.Value.Date;
            oPayment.Creator = currentUser.User_OID;
            oPayment.CreationDate = DateTime.Now.Date;
            oPayment.UpdateBy = currentUser.User_OID;
            oPayment.UpdateDate = DateTime.Now.Date;


            return oPayment;
        }

        private bool ValidateData()
        {
            if (ddlPartyName.Text.Trim() == "")
            {
                MessageBox.Show("Please Select Party Name", "ETLPOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (txtPaymentAmount.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Payment Amount", "ETLPOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (ddlCurrency.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Payment Currency", "ETLPOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (txtCurrencyRate.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Currency Rate", "ETLPOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (txtPaymentInBDT.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Payment In BDT", "ETLPOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (txtPaymentMedia.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Payment Media", "ETLPOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (rbYes.Checked==false && rbNo.Checked==false)
            {
                MessageBox.Show("Please Checke The Payment Receipet Confirmation", "ETLPOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void txtPaymentAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(e.KeyChar>=48&&e.KeyChar<=57) && !(e.KeyChar==8)&& !(e.KeyChar==46))
            {
                e.Handled = true;
            }
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            BindPartyName();
            BindCurrency();
            FillPaymentList();
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
                    ddlCurrency.DataSource = oresult.Data;
                    ddlCurrency.DisplayMember = "Curr_Code";
                    ddlCurrency.ValueMember = "Curr_OID";
                    ddlCurrency.SelectedIndex = 0;
                }
                catch (Exception ex) { }
            }
            else
            {
                ddlCurrency.Text = "ERROR in loading";
            }
        }

        private void FillPaymentList()
        {
            lvPaymentList.Items.Clear();
            CPaymentBO oPartyBO = new CPaymentBO();
            CResult oresult = new CResult();
            List<CPayment> oPartyList = new List<CPayment>();
            oresult = oPartyBO.ReadAllByFromToDate(dtpFromDate.Value.Date, dtpToDate.Value.Date);
            if (oresult.IsSuccess)
            {
                if (oresult.Data != null)
                {
                    int i = 0;
                    foreach (CPayment oPayment in oresult.Data as ArrayList)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = (i + 1).ToString("00");
                        lvi.SubItems.Add(oPayment.Payment_PartyName);
                        lvi.SubItems.Add(oPayment.Payment_Date.ToShortDateString());
                        lvi.SubItems.Add(oPayment.Payment_BDT.ToString());
                        lvi.SubItems.Add(oPayment.Payment_Media);
                        if (oPayment.Payment_RecieptConfirmation == 1)
                        {
                            lvi.SubItems.Add("Received");
                        }
                        else if (oPayment.Payment_RecieptConfirmation != 1)
                        {
                            lvi.SubItems.Add("NotReceived");
                        }
                        lvi.Tag = oPayment;
                        lvPaymentList.Items.Add(lvi);
                        i++;
                    }
                }
            }
            else
            {
                MessageBox.Show(oresult.ErrMsg);
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

        private void lvPaymentList_DoubleClick(object sender, EventArgs e)
        {
            if (lvPaymentList.SelectedItems.Count > 0)
            {
                CPayment oPayment = lvPaymentList.FocusedItem.Tag as CPayment;
                txtOId.Text = oPayment.Payment_OID;
                dtpPaymentDate.Value = oPayment.Payment_Date;
                ddlPartyName.SelectedText = oPayment.Payment_PartyName;
                ddlPartyName.SelectedValue = oPayment.Payment_PartyOID;
                txtPaymentAmount.Text = oPayment.Payment_Amount.ToString();
                ddlCurrency.SelectedText = oPayment.Payment_CurrencyName;
                ddlCurrency.SelectedValue = oPayment.Payment_CurrencyOID;
                txtCurrencyRate.Text = oPayment.Payment_CurrencyRate.ToString();
                txtPaymentInBDT.Text = oPayment.Payment_BDT.ToString();
                txtPaymentMedia.Text = oPayment.Payment_Media;
                dtpPaymentReceipetDate.Value = oPayment.Payment_ReceivedDate;
                if (oPayment.Payment_RecieptConfirmation == 1)
                {
                    rbYes.Select();
                }
                else if (oPayment.Payment_RecieptConfirmation != 1)
                {
                    rbNo.Select();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControl(groupBox1);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CPayment oPayment = lvPaymentList.FocusedItem.Tag as CPayment;
            CPaymentBO oPartyBO = new CPaymentBO();
            CResult oResult = new CResult();
            if (ValidateData())
            {
                oResult = oPartyBO.Update(GetFormData(oPayment));
                if (oResult.IsSuccess)
                {
                    MessageBox.Show("Update successfully");
                    FillPaymentList();
                }
                else
                {
                    MessageBox.Show("Not Updated" + oResult.ErrMsg + "");

                }
                ClearControl(groupBox1);
                FillPaymentList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtOId.Text != string.Empty)
            {
                if ((MessageBox.Show("Do u really want to delete this item. ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) == DialogResult.Yes)
                {
                    CPayment oPayment = GetFormData();
                    CPaymentBO oPaymentBO = new CPaymentBO();
                    CResult oresult = new CResult();
                    oresult = oPaymentBO.Delete(oPayment);
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
                        FillPaymentList();
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

        private CPayment GetFormData()
        {
            CPayment oPayment = new CPayment();
            oPayment.Payment_OID = txtOId.Text.Trim();
            return oPayment;
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            FillPaymentList();
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            FillPaymentList();
        }
    }
}
