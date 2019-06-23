using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ETL.BLL;
using ETL.Common;
using ETL.Model;

namespace ETLPOS
{
    public partial class frmPriceMaster : BaseForm
    {
        #region "Declarations"

        ArrayList arItemList = new ArrayList();
        bool IsUpdateMode = false;
        
        bool flag = false;
        CItemGroup oGroup = null;
        CItemSales oSales = null;
        
        #endregion

        #region "Methods"

        private void FormControlMode(int i)
        {
            switch (i)
            {
                case 0:
                    btnSave.Text = "Save";
                    btnDelete.Enabled = false;
                    IsUpdateMode = false;
                    break;
                case 1:
                    btnSave.Text = "Update";
                    btnDelete.Enabled = true;
                    IsUpdateMode = true;
                    break;
            }
        }

        public frmPriceMaster()
        {
            InitializeComponent();
        }
        public frmPriceMaster(CItemGroup oItemGroup,CItemSales oItem)
        {
            InitializeComponent();

            flag = true;
            oGroup = oItemGroup;
            oSales = oItem;
        }

        private void BindItemGroup()
        {
            int i = 0;
            foreach (CItemGroup itemGroup in ddlCategory.Items)
            {
                if (itemGroup.Catg_OID==oGroup.Catg_OID)
                {
                    ddlCategory.SelectedIndex = i;
                    i = 0;
                    foreach (CItem oItem in ddl_ItemName.Items)
                    {
                        if (oItem.Item_OID == oSales.Item_OID)
                        {
                            ddl_ItemName.SelectedIndex = i;
                            return;
                        }
                        i++;
                    }
                
                }
                i++;
            }
        }
        private void clearformdata()
        {
            dtp_From.Value = DateTime.Now.Date;
            dtp_To.Value = DateTime.Now.Date.AddMonths(120);
            //txt_FactoryPrice.Text = "0.00";
            //txt_ListPrice.Text = "0.00";
            txt_VATPrice.Text = "0.00";
            txt_VATPercent.Text = "0.00";
            txtDiscPer.Text = "0.00";
            txtDiscPrice.Text = "0.00";
        }

        private CPriceMaster Getformdata()
        {
            CPriceMaster oPM = new CPriceMaster();

            oPM.Price_OId = txtOId.Text;
            oPM.Price_Branch = currentBranch.CompBrn_Code;

            oPM.Price_ItemOId = ddl_ItemName.SelectedValue.ToString();
            oPM.Price_FromDate = dtp_From.Value;
            oPM.Price_ToDate = dtp_To.Value;
            oPM.Price_Currency = ddlCurrency.SelectedValue.ToString();
            oPM.Price_FactoryPrice = float.Parse(txt_FactoryPrice.Text.Trim());
            oPM.Price_ListPrice = float.Parse(txt_ListPrice.Text.Trim());
            oPM.Price_VatPercent = float.Parse(txt_VATPercent.Text.Trim());
            oPM.Price_VatPrice = float.Parse(txt_VATPrice.Text.Trim());
            oPM.Price_Disc = float.Parse(txtDiscPer.Text.Trim());
            oPM.Price_DiscPrice = float.Parse(txtDiscPrice.Text.Trim());

            oPM.Creator = currentUser.User_OID;
            oPM.CreationDate = DateTime.Now.Date;
            oPM.UpdateBy = currentUser.User_OID;
            oPM.UpdateDate = DateTime.Now.Date;

            return oPM;
        }

        private void LoadCurrencyData()
        {
            CResult oResult = new CResult();
            CCurrencyBO oCurrencyBO = new CCurrencyBO();
            oResult = oCurrencyBO.ReadAll();

            if (oResult.IsSuccess)
            {
                ddlCurrency.DataSource= oResult.Data as List<CCurrency>;
                ddlCurrency.DisplayMember = "Curr_Code";
                ddlCurrency.ValueMember = "Curr_OID";
            }
            else
            {
                MessageBox.Show("Loading error...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadItemCategoryData()
        {
            CResult oResult = new CResult();
            CItemBO oItemBO = new CItemBO();
            CItemGroup oItemGroup = new CItemGroup();
            oResult = oItemBO.ReadAll(oItemGroup);

            if (oResult.IsSuccess)
            {
                ddlCategory.DataSource = oResult.Data as ArrayList;
                ddlCategory.DisplayMember = "Catg_Name";
                ddlCategory.ValueMember = "Catg_OID";
                ddlCategory.SelectedIndex = 0;
                LoadItem(ddlCategory.SelectedValue.ToString());
            }
            else
            {
                MessageBox.Show("Loading error...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPriceMasterData()
        {
            lvPriceList.Items.Clear();
            CPriceMasterBO oPriceMasterBO = new CPriceMasterBO();
            CResult oResult = new CResult();
            CPriceMaster oPriceMaster = new CPriceMaster();

            oResult = oPriceMasterBO.ReadAll(ddl_ItemName.SelectedValue.ToString());
            if (oResult.IsSuccess)
            {
                DataTable dt = oResult.Data as DataTable;

                foreach(DataRow dr in dt.Rows )
                {
                    ListViewItem oItem = new ListViewItem();
                    oItem.Text = dr["ItemName"].ToString();
                    oItem.SubItems.Add(DateTime.Parse(dr["Price_FromDate"].ToString()).Date.ToString("dd-MM-yy"));
                    oItem.SubItems.Add(DateTime.Parse(dr["Price_ToDate"].ToString()).Date.ToString("dd-MM-yy"));
                    oItem.SubItems.Add(dr["Price_FactoryPrice"].ToString());
                    oItem.SubItems.Add(dr["Price_ListPrice"].ToString());
                    oItem.SubItems.Add(dr["Price_VatPercent"].ToString());
                    oItem.SubItems.Add(dr["Price_VatPrice"].ToString());
                    oItem.SubItems.Add(dr["Price_Disc"].ToString());
                    oItem.SubItems.Add(dr["Price_DiscPrice"].ToString());

                    oItem.SubItems.Add(dr["Currency_Code"].ToString());
                    lvPriceList.Items.Add(oItem);
                }
            }
            else
            {
                MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadItem(string stCatOID)
        {
            CItemBO oItembo = new CItemBO();
            CResult oResult = new CResult();
            oResult = oItembo.ReadAllByCond(stCatOID);
            if (oResult.IsSuccess)
            {
                arItemList = (ArrayList)oResult.Data;
                if (arItemList.Count > 0)
                {
                    ddl_ItemName.DataSource = arItemList;
                    ddl_ItemName.DisplayMember = "Item_ItemName";
                    ddl_ItemName.ValueMember = "Item_OID";
                    ddl_ItemName.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show(oResult.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reset()
        {
            ddl_ItemName.SelectedIndex = -1;
            dtp_From.Value = DateTime.Now.Date;
            dtp_To.Value = DateTime.Now.Date;
            txt_FactoryPrice.Text = "";
            txt_ListPrice.Text = "";
            txt_VATPrice.Text = "";
            txt_VATPercent.Text = "";

        }
        #endregion

        #region "Events"
        private void frmPriceMaster_Load(object sender, EventArgs e)
        {
            FormControlMode(0);
            LoadCurrencyData();
            LoadItemCategoryData();
            LoadPriceMasterData();
            dtp_To.Value = DateTime.Now.AddMonths(120);

            if (flag)
            {
                BindItemGroup();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CPriceMasterBO oPMBO = new CPriceMasterBO();
            CPriceMaster oPM = new CPriceMaster();
            CResult oResult = new CResult();
            if (validatedata())
            {
                oResult = oPMBO.Create(Getformdata());
                if (oResult.IsSuccess)
                {
                    MessageBox.Show("saved succesfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPriceMasterData();
                    clearformdata();

                }
                else
                {
                    MessageBox.Show("can not be saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearformdata();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private bool validatedata()
        {
            if (txt_ListPrice.Text == "0")
            {
                MessageBox.Show("Please Give List Price", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_ListPrice.Focus();
                return false;
            }
            DateTime Today = DateTime.Now.Date;
            if (dtp_From.Value.Date < Today)
            {
                MessageBox.Show("From Date is not correct", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtp_From.Focus();
                return false;
            }
            
            if (dtp_From.Value.Date > dtp_To.Value.Date)
            {

                MessageBox.Show("Date Input is not correct", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtp_From.Focus();
                return false;
            }
            
            

            return true;
        }






        private void lvPriceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (lvPriceList.SelectedItems.Count > 0)
            //{
            //    ListViewItem oItem = lvPriceList.SelectedItems[0];
            //    if (oItem != null)
            //    {
            //        ddl_ItemName.Text = oItem.Text;
            //        txt_FactoryPrice.Text = oItem.SubItems[1].Text.ToString();
            //        txt_ListPrice.Text = oItem.SubItems[2].Text.ToString();
            //        txt_VATPercent.Text = oItem.SubItems[3].Text.ToString();
            //        txt_VATPrice.Text = oItem.SubItems[4].Text.ToString();
            //        dtp_From.Text = oItem.SubItems[5].Text.ToString();
            //        dtp_To.Text = oItem.SubItems[6].Text.ToString();





            //    }
            //}
        }
        private void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItem(ddlCategory.SelectedValue.ToString());
        }

        private void ddl_ItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPriceMasterData();
        }
        #endregion

        private void IsValidKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) return;

            Control txtB = (Control)sender;
            bool flag = txtB.Text.Trim().Contains(".");
            if (e.KeyChar == 46 && !flag) return;
            if (e.KeyChar < 48 || e.KeyChar > 57)
                e.Handled = true;
        }

        private void ddl_ItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            AutoComplete(ddl_ItemName, e, false);
        }
        public void AutoComplete(ComboBox cb, System.Windows.Forms.KeyPressEventArgs e)
        {
            this.AutoComplete(cb, e, true);
        }
        public void AutoComplete(ComboBox cb, System.Windows.Forms.KeyPressEventArgs e, bool blnLimitToList)
        {
            string strFindStr = "";

            if (e.KeyChar == (char)8)
            {
                if (cb.SelectionStart <= 1)
                {
                    cb.Text = "";
                    return;
                }

                if (cb.SelectionLength == 0)
                    strFindStr = cb.Text.Substring(0, cb.Text.Length - 1);
                else
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart - 1);
            }
            else
            {
                if (cb.SelectionLength == 0)
                    strFindStr = cb.Text + e.KeyChar;
                else
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart) + e.KeyChar;
            }

            int intIdx = -1;

            // Search the string in the ComboBox list.

            intIdx = cb.FindString(strFindStr);

            if (intIdx != -1)
            {
                cb.SelectedText = "";
                cb.SelectedIndex = intIdx;
                cb.SelectionStart = strFindStr.Length;
                cb.SelectionLength = cb.Text.Length;
                e.Handled = true;
            }
            else
            {
                e.Handled = blnLimitToList;
            }
        }
    }
}