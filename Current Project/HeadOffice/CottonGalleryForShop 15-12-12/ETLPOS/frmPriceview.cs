using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ETL.BLL;
using ETL.Common;
using ETL.Model;


namespace ETLPOS
{
    public partial class frmPriceview : Form
    {
        

        public frmPriceview(List<CItemSales> itemList)
        {
           
            InitializeComponent();
            this.LoadItem(itemList);
        }
        private void LoadItem(List<CItemSales> oitemList)
        {
            int i = 1;
            if (oitemList.Count > 0)
            {
                foreach (CItemSales item in oitemList)
                {
                    if (item != null)
                    {
                        ListViewItem listViewItem = new ListViewItem();
                        listViewItem.Text = i.ToString();
                        listViewItem.SubItems.Add(item.Item_Code.ToString());
                        listViewItem.SubItems.Add(item.Item_ItemName.ToString());
                        listViewItem.SubItems.Add(item.Item_ExistQTY.ToString());
                        listViewItem.SubItems.Add(item.Item_PPrice.ToString());
                        listViewItem.SubItems.Add(item.Item_Price.ToString());
                        lvItemList.Items.Add(listViewItem);
                        listViewItem = null;
                    }
                    i++;
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
