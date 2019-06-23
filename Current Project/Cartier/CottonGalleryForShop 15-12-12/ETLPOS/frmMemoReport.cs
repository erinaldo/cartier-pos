using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ETL.Model;
using ETL.Common;
using ETL.BLL;
using ETLPOS.Reports;
using CrystalDecisions.Windows.Forms;

namespace ETLPOS
{
    public partial class frmMemoReport : ETLPOS.BaseForm
    {
        public CSOMaster oSoMaster = new CSOMaster();
        public frmMemoReport()
        {
            InitializeComponent();
        }

        private void btnMemoSearch_Click(object sender, EventArgs e)
        {
            frmMemoList ofrmMemoList = new frmMemoList();
            ofrmMemoList.ShowDialog();
            oSoMaster = ofrmMemoList.oSomaster;
            if (oSoMaster != null)
            {
                txtMenoNo.Text = oSoMaster.SOMstr_Code;
                txtMenoNo.Tag = oSoMaster;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtMenoNo.Text != "")
            {
                CSOBO oSoBo = new CSOBO();
                List<CSOMaster> oSoMasterList = oSoBo.GetMemoData((txtMenoNo.Tag as CSOMaster).SOMstr_Code, (txtMenoNo.Tag as CSOMaster).SOMstr_Date, currentBranch.CompBrn_Branch);

                POS oPosDataSet = new POS();
                DataTable oDt = oPosDataSet.Tables["MemoReprint"];
                foreach (CSOMaster  oSoMaster in oSoMasterList)
                {
                    DataRow odr = oDt.NewRow();
                    odr["BranchName"] = oSoMaster.SOMstr_Branch;
                    odr["MemoNo"] = oSoMaster.SOMstr_Code;
                    odr["MemoDate"] = oSoMaster.SOMstr_Date;
                    odr["Discount"] = int.Parse(oSoMaster.SOMstr_DiscAmt.ToString());
                    foreach (CSODetails oSoDetail in oSoMaster.SOMstr_DetailsList)
                    {
                        odr["ItemName"] = oSoDetail.SODet_ItemName;
                        odr["Qty"] = oSoDetail.SODet_QTY;
                        odr["Price"] = float.Parse(oSoDetail.SODet_Price.ToString());
                        odr["Amount"] = float.Parse(oSoDetail.SODet_SDAmount.ToString());
                    }
                    oDt.Rows.Add(odr);
                }
                txtMenoNo.Text = "";
                rptMemoReprint orptMemoReprint = new rptMemoReprint();
                orptMemoReprint.SetDataSource(oPosDataSet);

                frmReportView ofrmReportView = new frmReportView();
                CrystalReportViewer oCristalReportViewer = (CrystalReportViewer)ofrmReportView.Controls["rptViewer"];
                oCristalReportViewer.ReportSource = orptMemoReprint;

                oCristalReportViewer.Show();
                ofrmReportView.Show();
            }
        }
    }
}
