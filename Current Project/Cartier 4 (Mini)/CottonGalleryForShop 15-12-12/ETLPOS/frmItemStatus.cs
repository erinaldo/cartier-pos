using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ETL.Common;
using ETL.BLL;
using ETL.Model;
using System.Collections;

namespace ETLPOS
{
    public partial class frmItemStatus : BaseForm
    {
        public string oItem = null;
        public List<string> oItemOIDList;
        public frmItemStatus()
        {
            InitializeComponent();
        }

        private void frmItemStatus_Load(object sender, EventArgs e)
        {
            try
            {
                LoadItemCategoryData();
                LoadItemList(ddlCategory.SelectedValue.ToString());

                dtp_From.Enabled = false;
                dtp_To.Enabled = false;
            }
            catch { }
        }

        private void LoadItemList(string stCatOID)
        {
            lvItemList.Items.Clear();
            CItemBO oItembo = new CItemBO();
            CResult oResult = new CResult();
            List<CItemSales> oItemList = new List<CItemSales>();
            if (rdbtnCatg.Checked)
            {
                oResult = oItembo.ReadAllFByCatg(currentBranch.CompBrn_OId, stCatOID);
            }
            else
            {
                oResult = oItembo.ReadAllFByCatgAndDate(currentBranch.CompBrn_OId, stCatOID, dtp_From.Value.Date, dtp_To.Value.Date);
            }
            if (oResult.IsSuccess)
            {
                oItemList = (List<CItemSales>)oResult.Data;
                int i = 1;
                foreach (CItemSales oItem in oItemList)
                {
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = "" + i++;
                    listViewItem.SubItems.Add(oItem.Item_Code);
                    listViewItem.SubItems.Add(oItem.Item_ItemName);
                    listViewItem.SubItems.Add(oItem.Item_ExistQTY.ToString()); 
                    listViewItem.SubItems.Add(oItem.Item_Price.ToString());
                    listViewItem.Tag = oItem;
                    lvItemList.Items.Add(listViewItem);
                }
            }
            else
            {
                MessageBox.Show(oResult.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadItemCategoryData()
        {
            try
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
                }
                else
                {
                    MessageBox.Show("Loading error...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch { }
        }

        private void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItemList(ddlCategory.SelectedValue.ToString());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdbtnCatg_CheckedChanged(object sender, EventArgs e)
        {
            dtp_From.Enabled = false;
            dtp_To.Enabled = false;
        }

        private void rdbtnDate_CheckedChanged(object sender, EventArgs e)
        {
            dtp_From.Enabled = true;
            dtp_To.Enabled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadItemList(ddlCategory.SelectedValue.ToString());
        }

       
    }
}
