using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

using ETL.BLL;
using ETL.Common;
using ETL.Model;


namespace ETLPOS
{
    public partial class frmSearchItem : BaseForm
    {
        public string oItem = null;
        public List<string> oItemOIDList;
        public frmSearchItem()
        {
            InitializeComponent();
        }
        public frmSearchItem(bool forLoadGRItem)
        {
            InitializeComponent();
            btnLoadGRItem.Visible = forLoadGRItem;
        }

        #region Private Methods
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
            }
            else
            {
                MessageBox.Show("Loading error...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadItemList(string stCatOID)
        {
            lvItemList.Items.Clear();
            CItemBO oItembo = new CItemBO();
            CResult oResult = new CResult();
            List<CItemSales> oItemList = new List<CItemSales>();
            if (rdbtnCatg.Checked)
            {
                oResult = oItembo.ReadAllFByCatg(currentBranch.CompBrn_OId,stCatOID);
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
                    listViewItem.SubItems.Add(oItem.Item_PPrice.ToString());
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
        
        
        #endregion
        private void frmSearchItem_Load(object sender, EventArgs e)
        {
            LoadItemCategoryData();
            LoadItemList(ddlCategory.SelectedValue.ToString());

            dtp_From.Enabled = false;
            dtp_To.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadItemList(ddlCategory.SelectedValue.ToString());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdbtnDate_CheckedChanged(object sender, EventArgs e)
        {
                dtp_From.Enabled = true;
                dtp_To.Enabled = true;
        }

        private void rdbtnCatg_CheckedChanged(object sender, EventArgs e)
        {
            dtp_From.Enabled = false;
            dtp_To.Enabled = false;
        }

        private void lvItemList_DoubleClick(object sender, EventArgs e)
        {
            oItem = ((CItemSales)lvItemList.FocusedItem.Tag).Item_OID;
            oItemOIDList = new List<string>();
            oItemOIDList.Add(oItem);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lvItemList.SelectedItems.Count > 0)
            {
                frmPriceMaster objpm = new frmPriceMaster((CItemGroup)ddlCategory.SelectedItem, (CItemSales)lvItemList.FocusedItem.Tag);
                objpm.ShowDialog();
            }
            else
            {
                MessageBox.Show("First Select One Item for Set Price", "ETL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItemList(ddlCategory.SelectedValue.ToString());
        }

        private void btnLoadGRItem_Click(object sender, EventArgs e)
        {
            if (lvItemList.SelectedItems.Count > 0)
            {
                oItemOIDList = new List<string>();
                int i = 0;
                foreach (ListViewItem lvi in lvItemList.SelectedItems)
                {
                    string oItemOID;
                    CItemSales oItem = lvItemList.SelectedItems[i].Tag as CItemSales;
                    oItemOID = oItem.Item_OID;
                    oItemOIDList.Add(oItemOID);
                    i++;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Select At Least One Item", "ETL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        string itemcode = "";
        
        private void lvItemList_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(lvItemList,e.Location);
                itemcode = lvItemList.SelectedItems[0].SubItems[1].Text;


            }
            else//left or middle click
            {
                //do something here
            }
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
           
          
        }
              
    }
}
