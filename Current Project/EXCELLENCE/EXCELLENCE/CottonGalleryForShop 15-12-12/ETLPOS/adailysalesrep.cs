using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ETLPOS.Reports;
using CrystalDecisions.Windows.Forms;
using ETL.Model;
using System.IO;
using System.Security.Cryptography;
using ETL.Common;
using ETL.BLL;
using Model;

namespace ETLPOS
{
    public partial class adailysalesrep : BaseForm
    {
        public adailysalesrep()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.ShowReport();
        }
        private void ShowReport()
        {
            List<CSOMaster> oListSOMaster = LoadSOData();

            POS posdateset = new POS();
            DataTable dtDailySale = posdateset.DailySales;

            foreach (CSOMaster oSOMaster in oListSOMaster)
            {
                int i = 0;
                foreach (CSODetails oSODetails in oSOMaster.SOMstr_DetailsList)
                {
                    DataRow drDailySale = dtDailySale.NewRow();

                    //drDailySale["InvoiceNo"] = dr1["InvoiceNo"];
                    drDailySale["BranchName"] = oSOMaster.SOMstr_Branch;
                    drDailySale["Address"] = currentBranch.CompBrn_Street;
                    drDailySale["Road"] = currentBranch.CompBrn_Road;
                    drDailySale["City"] = currentBranch.CompBrn_City;
                    drDailySale["Phone"] = currentBranch.CompBrn_Phone;
                    drDailySale["Mobile"] = currentBranch.CompBrn_Mobile;
                    drDailySale["ItemName"] = oSODetails.SODet_ItemName;
                    drDailySale["Qty"] = oSODetails.SODet_QTY;
                    drDailySale["Rate"] = oSODetails.SODet_Price;
                    drDailySale["Amount"] = oSODetails.SODet_Amount;
                    drDailySale["TotalAmount"] = oSOMaster.SOMstr_TotalAmt;
                    drDailySale["TotalReturn"] = oSOMaster.TotalReturn;
                    if (i == 0)
                    {
                        drDailySale["DiscAmount"] = oSOMaster.SOMstr_DiscAmt;
                    }
                    if (i != 0)
                    {
                        drDailySale["DiscAmount"] = 0;
                    }
                    drDailySale["NetAmount"] = oSOMaster.SOMstr_NetAmt;
                    drDailySale["PPrice"] = oSODetails.SODet_PPrice;


                    dtDailySale.Rows.Add(drDailySale);
                    i++;
                }
            }

             List<CReturnItem> oListCReturnItem = new List<CReturnItem>();
            //List<CSOMaster> oListSOMasterretu = new List<CSOMaster>();
            CSOBO oCSOBO = new CSOBO();
            CResult oResult = new CResult();
            DateTime date = dtpDate.Value.Date;
            oListCReturnItem = oCSOBO.ReadSalesReturn(dtpDate.Value.Date, currentBranch.CompBrn_Code);
            //oListCReturnItem.Add(oListSOMasterretu);
            New PosDataSet11 = new New();
            DataTable dtReturn = PosDataSet11.ReturnItems;
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
                //odr["ReturnDate"] = oSoDetail.date;

                dtReturn.Rows.Add(odr);
            }


            //ReturnReport re = new ReturnReport();
            //re.SetDataSource(PosDataSet11);

            //rptDailySales orpt = new rptDailySales();
            //orpt.SetDataSource(posdateset);
            ////orpt.Load("ReturnReport.rpt");
            //orpt.OpenSubreport("ReturnReport.rpt").SetDataSource(PosDataSet11);
            //orpt.SetParameterValue(0, currentBranch.CompBrn_Name.Trim());
            //orpt.SetParameterValue(1, dtpDate.Value.Date);


            rptDailySales1 orpt = new rptDailySales1();
            orpt.SetDataSource(posdateset);
            orpt.OpenSubreport("ReturnReport.rpt").SetDataSource(PosDataSet11);
            orpt.SetParameterValue(0, currentBranch.CompBrn_Name.Trim());
            orpt.SetParameterValue(1, dtpDate.Value.Date);

            frmReportView ofrmReportView = new frmReportView();
            CrystalReportViewer orptviewer = (CrystalReportViewer)ofrmReportView.Controls["rptviewer"];
            orptviewer.ReportSource = orpt;
            // orptviewer.AutoSize = false;

            orptviewer.Show();
            ofrmReportView.Show();

            //crystalReportViewer1.ReportSource = orpt;
            //crystalReportViewer1.Show();
        }

        private List<CSOMaster> LoadSOData()
        {
            List<CSOMaster> oListSOMaster = new List<CSOMaster>();

            CSOBO oCSOBO = new CSOBO();
            CResult oResult = new CResult();
            DateTime date = dtpDate.Value.Date;
            oResult = oCSOBO.ReadSalesBranNDateWise(dtpDate.Value.Date, ddlRptBranch.SelectedValue.ToString().Trim(), ddlExportedBranch.SelectedValue.ToString().Trim());

            if (oResult.IsSuccess)
            {
                oListSOMaster = (List<CSOMaster>)oResult.Data;
            }
            else
            {
                MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                oListSOMaster = null;
            }

            // Advance Start
            if (!defaultUserMode)
            {
                string m_sAdvanceConfigFileName = "AdvanceConfigAndLogFile.config";

                List<CSOMaster> oListSOMaster2 = new List<CSOMaster>();

                System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                if (File.Exists(m_sAdvanceConfigFileName))
                {
                    using (Stream stream = new FileStream(m_sAdvanceConfigFileName, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        byte[] baKey = { 51, 208, 75, 59, 223, 134, 241, 155, 170, 229, 177, 160, 246, 71, 77, 141, 66, 7, 223, 103, 97, 80, 235, 82, 94, 107, 226, 190, 76, 94, 31, 43 };
                        byte[] baIV = { 142, 96, 41, 14, 206, 132, 173, 19, 12, 50, 124, 121, 42, 27, 35, 9 };
                        Rijndael rijndael = Rijndael.Create();
                        CryptoStream cryptoStream = new CryptoStream(stream, rijndael.CreateDecryptor(baKey, baIV), CryptoStreamMode.Read);
                        //
                        oListSOMaster2 = (List<CSOMaster>)formatter.Deserialize(cryptoStream);

                        //
                        cryptoStream.Close();
                    }
                }
                if (oListSOMaster2.Count > 0)
                {
                    foreach (CSOMaster oSOMaster in oListSOMaster2)
                    {
                        if (oSOMaster.SOMstr_Date.ToShortDateString() == dtpDate.Value.Date.ToShortDateString())
                        {
                            oListSOMaster.Add(oSOMaster);
                        }
                    }
                }
            }
            // Advance End

            return oListSOMaster;
        }

        private void LoadExportedBranch()
        {
            CResult oResult = new CResult();
            CCompanyBranchBO oCompanyBranchBO = new CCompanyBranchBO();
            oResult = oCompanyBranchBO.ReadAll();

            if (oResult.IsSuccess)
            {
                ddlExportedBranch.DataSource = oResult.Data as List<CCompanyBranch>;
                ddlExportedBranch.DisplayMember = "CompBrn_Code";
                ddlExportedBranch.ValueMember = "CompBrn_OId";
            }
            else
            {
                MessageBox.Show("Loading error...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void adailysalesrep_Load(object sender, EventArgs e)
        {
            LoadExportedBranch();
            LoadReportBranch();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmReportReturn a = new frmReportReturn();
            a.Show();
        }

    }
}
