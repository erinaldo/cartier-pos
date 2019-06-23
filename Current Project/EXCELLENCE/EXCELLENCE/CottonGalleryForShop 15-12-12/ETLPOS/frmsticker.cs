using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.CrystalReports;
using System.Drawing.Printing;
using CrystalDecisions.CrystalReports.Engine;

using ETL.BLL;
using ETL.Model;
using ETL.Common;
using ETLPOS.Reports;


namespace ETLPOS
{
    public partial class frmsticker : BaseForm
    {
        public frmsticker()
        {
            InitializeComponent();
        }
        #region Private Methods
        private void BindItemName()
        {
            CItemBO oItemBO = new CItemBO();
            CResult oResult = new CResult();
            List<CItemSales> oItemList = new List<CItemSales>();

            oResult = oItemBO.ReadAllFGForSalesByBranch(currentBranch.CompBrn_OId);

            if (oResult.IsSuccess)
            {
                oItemList = (List<CItemSales>)oResult.Data;
                foreach (CItemSales objItem in oItemList)
                {
                    cmbItemName.Items.Add(objItem);
                }
                cmbItemName.DisplayMember = "Item_ItemName";
            }
        }
        private void BindlistView()
        {
            CItemSales oitem = (CItemSales)cmbItemName.SelectedItem;
            ListViewItem listViewItem = new ListViewItem();
            listViewItem.Text = oitem.Item_Code;
            listViewItem.SubItems.Add(oitem.Item_ItemName);
            listViewItem.SubItems.Add(txtnum.Text.Trim());
            listViewItem.SubItems.Add(oitem.Item_Price.ToString());
            listViewItem.Tag = oitem;
            lvItem.Items.Add(listViewItem);
            listViewItem = null;
            cmbItemName.Text = null;
            txtnum.Text = "0";
        }
        private void ShowReport()
        {
            POS posdataset = new POS();
            DataTable stickertbl = (DataTable)posdataset.StickerPrint;

            for (int i = 0; i < lvItem.Items.Count; i++)
            {
                for (int j = 0; j < Convert.ToInt32(lvItem.Items[i].SubItems[2].Text); j++)
                {
                    DataRow row = stickertbl.NewRow();
                    row["ItemCode"] = "*" + lvItem.Items[i].SubItems[0].Text + "*";
                    row["ItemName"] = lvItem.Items[i].SubItems[1].Text;
                    row["Price"] = lvItem.Items[i].SubItems[3].Text;
                    stickertbl.Rows.Add(row);
                }




            //POS posdataset = new POS();
            //DataTable stickertbl = (DataTable)posdataset.StickerPrint;

            //for (int i = 0; i < lvItem.Items.Count; i++)
            //{
            //    for (int j = 0; j < Convert.ToInt32(lvItem.Items[i].SubItems[2].Text); j++)
            //    {
            //        DataRow row = stickertbl.NewRow();
            //        row["ItemCode"] = "*" + lvItem.Items[i].SubItems[0].Text + "*";
            //        string[] itemarray = lvItem.Items[i].SubItems[1].Text.Split('-');
            //        try
            //        {
            //            row["ItemName"] = itemarray[0].ToString();
            //            row["Code"] = itemarray[1].ToString();
            //            row["Size"] = itemarray[3].ToString();
            //        }
            //        catch (Exception ex)
            //        { 
                    
            //        }
            //        row["Price"] = lvItem.Items[i].SubItems[3].Text;
            //        stickertbl.Rows.Add(row);
            //    }
            }

            rptSticker objrpt = new rptSticker();
            objrpt.SetDataSource(stickertbl);

            frmReportView ofrmReportView = new frmReportView();
            CrystalReportViewer orptviewer = (CrystalReportViewer)ofrmReportView.Controls["rptviewer"];
            orptviewer.ReportSource = objrpt;
            orptviewer.AutoSize = false;

            orptviewer.Show();
            ofrmReportView.Show();

        }
        #endregion

        #region Events
        private void frmsticker_Load(object sender, EventArgs e)
        {
            BindItemName();
            BindItemListView();
        }

        private void BindItemListView()
        {
            lvItemName.Items.Clear();
            CItemBO oItemBO = new CItemBO();
            CResult oResult = new CResult();
            List<CItemSales> oItemList = new List<CItemSales>();


            oResult = oItemBO.ReadAllForStickerByBranch(dtpFromDate.Value.Date, dtpToDate.Value.Date, currentBranch.CompBrn_Branch);
            if (oResult.IsSuccess)
            {
                oItemList = (List<CItemSales>)oResult.Data;
                if (oItemList != null)
                {
                    int i = 0;
                    foreach (CItemSales oItemSales in oItemList)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = (i + 1).ToString("00");
                        lvi.SubItems.Add(oItemSales.Item_Code);
                        lvi.SubItems.Add(oItemSales.Item_ItemName);
                        lvi.SubItems.Add(oItemSales.TotalItem.ToString());
                        lvi.SubItems.Add(oItemSales.Item_Price.ToString());
                        lvi.Tag = oItemSales;
                        lvItemName.Items.Add(lvi);
                        i++;
                    }

                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (cmbItemName.Text == "")
            {
                MessageBox.Show("Please Select Item name!!");
                return;
            }
            else if (txtnum.Text == "0")
            {
                MessageBox.Show("Please enter number of copy!");
                return;
            }
            else
            {
                BindlistView();
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            lvItem.Items.Clear();
        }
        private void txtnum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cmbItemName.Text == "")
                {
                    MessageBox.Show("Please Select Item name!!");
                    return;
                }
                else if (txtnum.Text == "0")
                {
                    MessageBox.Show("Please enter number of copy!");
                    return;
                }
                else
                {
                    BindlistView();
                }
            }
        }
        private void btnpreview_Click(object sender, EventArgs e)
        {
            if (lvItem.Items.Count > 0)
            {
                ShowReport();
            }
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lvItem.SelectedItems.Count > 0)
            {
                lvItem.FocusedItem.Remove();
            }
            else
            {
                MessageBox.Show("Select an Item for Remove!!");
            }
        }
        #endregion

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            BindItemListView();
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            BindItemListView();
        }


        private void lvItemName_DoubleClick(object sender, EventArgs e)
        {
            if (lvItemName.SelectedItems.Count > 0)
            {
                CItemSales oItemSales = lvItemName.FocusedItem.Tag as CItemSales;
                if (oItemSales != null)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = oItemSales.Item_Code;
                    lvi.SubItems.Add(oItemSales.Item_ItemName);
                    lvi.SubItems.Add(oItemSales.TotalItem.ToString());
                    lvi.SubItems.Add(oItemSales.Item_Price.ToString());
                    lvi.Tag = oItemSales;
                    lvItem.Items.Add(lvi);
                }
                ListViewItem lviForDelete = lvItemName.FocusedItem;
                lvItemName.Items.Remove(lviForDelete);
            } 
        }
    }
}
