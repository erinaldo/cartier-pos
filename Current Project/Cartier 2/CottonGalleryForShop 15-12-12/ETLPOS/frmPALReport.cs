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
using ETLPOS.Reports;
using CrystalDecisions.Windows.Forms;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

namespace ETLPOS
{
    public partial class frmPALReport : BaseForm
    {
        public frmPALReport()
        {
            InitializeComponent();
        }
        #region Private Methods
        //private void LoadBranch()
        //{
        //    CResult oResult = new CResult();
        //    CCompanyBranchBO oCompanyBranchBO = new CCompanyBranchBO();
        //    oResult = oCompanyBranchBO.ReadAll();

        //    if (oResult.IsSuccess)
        //    {
        //        ddlRptBranch.DataSource = oResult.Data as List<CCompanyBranch>;
        //        ddlRptBranch.DisplayMember = "CompBrn_Code";
        //        ddlRptBranch.ValueMember = "CompBrn_OId";
        //        ddlRptBranch.SelectedValue = currentBranch.CompBrn_OId.Trim();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Loading error...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        ////private List<CGRDetails> LoadGRDataInDuration()
        ////{
        ////    List<CGRDetails> oListCGRDetails = new List<CGRDetails>();

        ////    CGRBO oCGRBO = new CGRBO();
        ////    CResult oResult = new CResult();
        ////    oResult = oCGRBO.ReadByBranchAndDate(ddlRptBranch.Text.Trim(), dtpDateFrom.Value.Date, dtpDateTo.Value.Date);

        ////    if (oResult.IsSuccess)
        ////    {
        ////        oListCGRDetails = (List<CGRDetails>)oResult.Data;
        ////    }
        ////    else
        ////    {
        ////        MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        ////        oListCGRDetails = null;
        ////    }
        ////    return oListCGRDetails;
        ////}
        ////private List<CSOMaster> LoadSODataInDuration()
        ////{
        ////    List<CSOMaster> oListSOMaster = new List<CSOMaster>();

        ////    CSOBO oCSOBO = new CSOBO();
        ////    CResult oResult = new CResult();
        ////    oResult = oCSOBO.ReadSalesBranNDateDurationWise(dtpDateFrom.Value.Date, dtpDateTo.Value.Date, ddlRptBranch.SelectedValue.ToString().Trim(), ddlRptBranch.SelectedValue.ToString().Trim());

        ////    if (oResult.IsSuccess)
        ////    {
        ////        oListSOMaster = (List<CSOMaster>)oResult.Data;
        ////    }
        ////    else
        ////    {
        ////        MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        ////        oListSOMaster = null;
        ////    }
        ////    return oListSOMaster;
        ////}
    
        //private void ShowReport()
        //{
        //    List<CSOMaster> oListSOMaster = LoadSODataInDuration();
        //    List<CGRDetails> oListGRDetails = LoadGRDataInDuration();
        //    POS posdateset = new POS();
        //    DataTable dtSODet = posdateset.SODet;

        //    foreach (CSOMaster oSOMaster in oListSOMaster)
        //    {
        //        foreach (CSODetails oSODetails in oSOMaster.SOMstr_DetailsList)
        //        {
        //            DataRow drSODet = dtSODet.NewRow();

        //            drSODet["SODet_BranchCode"] = oSOMaster.SOMstr_Branch;
        //            drSODet["SODet_ItemCode"] = oSODetails.SODet_ItemCode;
        //            drSODet["SODet_ItemName"] = oSODetails.SODet_ItemName;
        //            drSODet["SODet_QTY"] = oSODetails.SODet_QTY;
        //            drSODet["SODet_Pprice"] = oSODetails.SODet_ItemPprice;
        //            drSODet["SODet_Sprice"] = oSODetails.SODet_Price;
        //            drSODet["SODet_BranchName"] = currentBranch.CompBrn_Name;
        //            dtSODet.Rows.Add(drSODet);
        //        }
        //    }

        //    DataTable dtGRDet = posdateset.GRDet;
        //    foreach (CGRDetails oGRDetails in oListGRDetails)
        //    {
        //        DataRow drSODet = dtGRDet.NewRow();

        //        drSODet["GRDet_Branch"] = oGRDetails.GRDet_BranchOID;
        //        drSODet["GRDet_ItemOID"] = oGRDetails.GRDet_ItemOID;
        //        drSODet["GRDet_QTY"] = oGRDetails.GRDet_QTY;
        //        drSODet["GRDet_Price"] = oGRDetails.GRDet_Price;
        //        drSODet["GRDet_Amount"] = oGRDetails.GRDet_Amount;
        //        drSODet["GRDet_ItemName"] = oGRDetails.GRDet_ItemName;

        //        dtGRDet.Rows.Add(drSODet);
        //    }

        //    rptProfitAndLoss orpt = new rptProfitAndLoss();
        //    orpt.SetDataSource(posdateset);
        //    //orpt.SetParameterValue(0, currentBranch.CompBrn_Name.Trim());
        //    //orpt.SetParameterValue(1, dtpDateFrom.Value.Date);
        //    //orpt.SetParameterValue(2, dtpDateTo.Value.Date);



        //    frmReportView ofrmReportView = new frmReportView();
        //    CrystalReportViewer orptviewer = (CrystalReportViewer)ofrmReportView.Controls["rptviewer"];
        //    orptviewer.ReportSource = orpt;

        //    orptviewer.Show();
        //    ofrmReportView.Show();
           
        //}

        #endregion

        #region Events
        private void frmPALReport_Load(object sender, EventArgs e)
        {
            dtpDateFrom.Value = dtpDateFrom.Value.AddMonths(-1).Date;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
          //  ShowReport();

            rptProfitAndLoss obj = new rptProfitAndLoss();
            frmReportView ofrmReportView = new frmReportView();
            CrystalReportViewer orptviewer = (CrystalReportViewer)ofrmReportView.Controls["rptviewer"];
            orptviewer.ReportSource = obj; 

            orptviewer.Show();
            ofrmReportView.Show();
        }
        #endregion
    }
}
