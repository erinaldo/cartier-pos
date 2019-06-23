using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using ETL.Common;
using System.Collections;
using Model;

namespace ETLPOS
{
    public partial class frmPaymentView : BaseForm
    {
        public frmPaymentView()
        {
            InitializeComponent();
        }

        private void frmPaymentView_Load(object sender, EventArgs e)
        {
            BindPartyName();
            FillPaymentList();
        }

        private void FillPaymentList()
        {
            lvPaymentList.Items.Clear();
            CPaymentBO oPartyBO = new CPaymentBO();
            CResult oresult = new CResult();
            List<CPayment> oPartyList = new List<CPayment>();
            oresult = oPartyBO.ReadAllByFromToDateAndPartyOID(ddlPartyName.SelectedValue.ToString(),dtpFromDate.Value.Date, dtpToDate.Value.Date);
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
                        lvi.SubItems.Add(oPayment.Payment_Amount.ToString());
                        lvi.SubItems.Add(oPayment.Payment_CurrencyRate.ToString());
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
                    CalculateTotalAmmount();
                }
            }
            else
            {
                MessageBox.Show(oresult.ErrMsg);
            }
        }

        private void CalculateTotalAmmount()
        {
            if (lvPaymentList.Items.Count > 0)
            {
                double total = 0;
                foreach (ListViewItem oLisViewItem in lvPaymentList.Items)
                {
                    total += double.Parse(oLisViewItem.SubItems[5].Text.Trim());
                }
                txtGrandTotal.Text = total.ToString();
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

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            FillPaymentList();
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            FillPaymentList();
        }

        private void ddlPartyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillPaymentList();
        }
    }
}
