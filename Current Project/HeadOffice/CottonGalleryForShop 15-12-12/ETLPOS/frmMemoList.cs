using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ETL.Common;
using ETL.BLL;
using ETL.Model;
using System.Collections;

namespace ETLPOS
{
    public partial class frmMemoList : BaseForm
    {
        public CSOMaster oSomaster = new CSOMaster();
        public frmMemoList()
        {
            InitializeComponent();
        }

        private void frmMemoList_Load(object sender, EventArgs e)
        {
            LoaddMemoList();
        }

        private void LoaddMemoList()
        {
            lvMemoList.Items.Clear();
            CResult oResult = new CResult();
            CSOBO oSoBo = new CSOBO();
            oResult = oSoBo.ReadSOFromToDate(dtpFromDate.Value.Date, dtpToDate.Value.Date, currentBranch.CompBrn_Code);

            if (oResult.IsSuccess = true)
            {
                List<CSOMaster> oSoMasterList = oResult.Data as List<CSOMaster>;
                if (oSoMasterList != null)
                {
                    int i = 0;
                    foreach (CSOMaster oSoMaste in oSoMasterList)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = (i + 1).ToString("00");
                        lvi.SubItems.Add(oSoMaste.SOMstr_Code);
                        lvi.SubItems.Add(oSoMaste.SOMstr_Date.ToString());
                        lvi.SubItems.Add(oSoMaste.SOMstr_DtailList.SODet_QTY.ToString());
                        lvi.SubItems.Add(oSoMaste.SOMstr_NetAmt.ToString());

                        lvi.Tag = oSoMaste;
                        lvMemoList.Items.Add(lvi);
                        i++;
                    }
                }
                else if (oSoMasterList == null)
                {
                    MessageBox.Show("You have no memo to reprint in the given date", "ETLPOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        private void lvMemoList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            LoaddMemoList();
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            LoaddMemoList();
        }

        private void lvMemoList_DoubleClick(object sender, EventArgs e)
        {
            if (lvMemoList.Items.Count > 0)
            {
                if (lvMemoList.SelectedItems.Count == 1)
                {
                    oSomaster = lvMemoList.FocusedItem.Tag as CSOMaster;
                    this.Close();
                }
            }
        }
    }
}
