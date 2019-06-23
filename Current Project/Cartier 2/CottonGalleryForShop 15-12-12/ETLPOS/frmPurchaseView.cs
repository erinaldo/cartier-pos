using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using ETL.Common;
using System.Collections;
using Model;

namespace ETLPOS
{
    public partial class frmPurchaseView : ETLPOS.BaseForm
    {
        public frmPurchaseView()
        {
            InitializeComponent();
        }

        private void frmPurchaseView_Load(object sender, EventArgs e)
        {
            BindPartyName();
            FillPurchasetList();
        }

        private void FillPurchasetList()
        {
            lvPurchasetList.Items.Clear();
            CPurchaseBO oPurchaseBO = new CPurchaseBO();
            CResult oresult = new CResult();
            List<CPurchase> oPurchaseList = new List<CPurchase>();
            oresult = oPurchaseBO.ReadAllByFromToDateAndPartyOID(ddlPartyName.SelectedValue.ToString(),dtpFromDate.Value.Date, dtpToDate.Value.Date);
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
                        lvi.SubItems.Add(oPurchase.Purchase_Invoice);
                        lvi.SubItems.Add(oPurchase.Purchase_Date.ToShortDateString());
                        lvi.SubItems.Add(oPurchase.Purchase_Quantity.ToString());
                        lvi.SubItems.Add(oPurchase.Purchase_Amount.ToString());
                        lvi.SubItems.Add(oPurchase.Purchase_CurrencyRate.ToString());
                        lvi.Tag = oPurchase;
                        lvPurchasetList.Items.Add(lvi);
                        i++;
                    }
                    CalculatePurchaseTotal();
                }
            }
            else
            {
                MessageBox.Show(oresult.ErrMsg);
            }
        }

        private void CalculatePurchaseTotal()
        {
            if (lvPurchasetList.Items.Count > 0)
            {
                double total = 0;
                foreach (ListViewItem oLisViewItem in lvPurchasetList.Items)
                {
                    total += double.Parse(oLisViewItem.SubItems[6].Text.Trim());
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

        private void ddlPartyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillPurchasetList();
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            FillPurchasetList();
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            FillPurchasetList();
        }
    }
}
