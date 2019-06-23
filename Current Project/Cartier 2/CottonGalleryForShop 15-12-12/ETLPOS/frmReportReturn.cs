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
using Model;
using CrystalDecisions.Windows.Forms;
using ETLPOS.Reports;

namespace ETLPOS
{
    public partial class frmReportReturn : BaseForm
    {
       // public static CCompanyBranch currentBranch;
        public frmReportReturn()
        {
            InitializeComponent();
        }

        private void ShowReport()
        {
            List<CReturnItem> oListCReturnItem = new List<CReturnItem>();
            //List<CSOMaster> oListSOMasterretu = new List<CSOMaster>();
            CSOBO oCSOBO = new CSOBO();
            CResult oResult = new CResult();
            DateTime date = dtpDate.Value.Date;
            oListCReturnItem = oCSOBO.ReadSalesReturn(dtpDate.Value.Date, currentBranch.CompBrn_Code);
            //oListCReturnItem.Add(oListSOMasterretu);
            New oPosDataSet11 = new New();
            DataTable dtReturn = oPosDataSet11.ReturnItems;
            //foreach (CSOMaster oSoMaster in oListSOMasterretu)
            //{
            //oListCReturnItem.Add(oSoMaster);  
            //}

            foreach (CReturnItem oSoDetail in oListCReturnItem)
           {
                DataRow odr = dtReturn.NewRow();
                odr["ItemName"] = oSoDetail.ItemName;
                odr["Ret_QTY"] = oSoDetail.Ret_QTY;
                odr["ItemPrice"] = float.Parse(oSoDetail.ItemPrice.ToString());
                odr["BranchName"] = oSoDetail.Ret_BranchOID;
                odr["Ret_DiscountAmount"] = oSoDetail.Ret_DiscountAmount;
                odr["ReturnDate"] = oSoDetail.date;

                dtReturn.Rows.Add(odr);
            }




            ETLPOS.Reports.ReturnReport orpt = new ETLPOS.Reports.ReturnReport();
            orpt.SetDataSource(oPosDataSet11);
            //orpt.SetParameterValue(0, currentBranch.CompBrn_OId.Trim());
            orpt.SetParameterValue(0, dtpDate.Value.Date);

            frmReportView ofrmReportView = new frmReportView();
            CrystalReportViewer orptviewer = (CrystalReportViewer)ofrmReportView.Controls["rptviewer"];
            orptviewer.ReportSource = orpt;
            // orptviewer.AutoSize = false;

            orptviewer.Show();
            ofrmReportView.Show();

            //crystalReportViewer1.ReportSource = orpt;
            //crystalReportViewer1.Show();
        }

        private void LoadReportBranch()
        {
            CResult oResult = new CResult();
            CCompanyBranchBO oCompanyBranchBO = new CCompanyBranchBO();
            oResult = oCompanyBranchBO.ReadAll();

            if (oResult.IsSuccess)
            {
                ddlRptBranch.DataSource = oResult.Data as List<CCompanyBranch>;
                ddlRptBranch.DisplayMember = "CompBrn_Code";
                ddlRptBranch.ValueMember = "CompBrn_OId";
                ddlRptBranch.SelectedValue = currentBranch.CompBrn_OId.Trim();

                //ddlRptBranch3.DataSource = oResult.Data as List<CCompanyBranch>;
                //ddlRptBranch3.DisplayMember = "CompBrn_Code";
                //ddlRptBranch3.ValueMember = "CompBrn_OId";
                //ddlRptBranch3.SelectedValue = currentBranch.CompBrn_OId.Trim();


            }
            else
            {
                MessageBox.Show("Loading error...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmReportReturn_Load(object sender, EventArgs e)
        {
            LoadReportBranch();

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.ShowReport();
        }
    }
}
