using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Linq;
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
    public partial class frmDailySalesNew : BaseForm
    {
        public frmDailySalesNew()
        {
            InitializeComponent();
            if (currentBranch.CompBrn_IsHeadoffice == "Y")
            {
                this.gb_Export.Enabled = false;
                this.gb_Import.Enabled = true;
            }
            else
            {
                this.gb_Export.Enabled = true;
                this.gb_Import.Enabled = false;
            }
        }

        private void frmDailySalesNew_Load(object sender, EventArgs e)
        {
            LoadExportedBranch();
            LoadReportBranch();
            LoadReportBranch2();
            LoadReportItem();
            radioButton1.Checked = true;
            groupBox4.Enabled = true;
            groupBox5.Enabled = false;
            groupBox6.Enabled = false;
        }

        private void LoadReportItem()
        {
            CResult oResult = new CResult();
            CItemBO oItemBO = new CItemBO();
            oResult = oItemBO.ReadAll();

            if (oResult.IsSuccess)
            {

                cmbItemName.DataSource = oResult.Data as ArrayList;   //  List<CItem>;
                cmbItemName.DisplayMember = "Item_ItemName";
                cmbItemName.ValueMember = "Item_OId";
                cmbItemName.SelectedValue = cmbItemName.SelectedIndex.ToString();
                cmbItemName.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Loading error...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReportBranch2()
        {
            CResult oResult = new CResult();
            CCompanyBranchBO oCompanyBranchBO = new CCompanyBranchBO();
            oResult = oCompanyBranchBO.ReadAll();

            if (oResult.IsSuccess)
            {
                ddlRptBranch2.DataSource = oResult.Data as List<CCompanyBranch>;
                ddlRptBranch2.DisplayMember = "CompBrn_Code";
                ddlRptBranch2.ValueMember = "CompBrn_OId";

                ddlRptBranch2.SelectedValue = currentBranch.CompBrn_OId.Trim();
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

                ddlRptBranch3.DataSource = oResult.Data as List<CCompanyBranch>;
                ddlRptBranch3.DisplayMember = "CompBrn_Code";
                ddlRptBranch3.ValueMember = "CompBrn_OId";
                ddlRptBranch3.SelectedValue = currentBranch.CompBrn_OId.Trim();


            }
            else
            {
                MessageBox.Show("Loading error...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                ddlExportedBranch.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Loading error...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            rptDailySales orpt = new rptDailySales();
            orpt.SetDataSource(posdateset);
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

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExportData_Click(object sender, EventArgs e)
        {
            if (currentBranch.CompBrn_OId.Trim() != this.ddlExportedBranch.SelectedValue.ToString().Trim())
            {
                List<CSOMaster> oListSOMaster = LoadSOData();

                string m_sMTExportFileName = dtpDate.Value.Date.ToString("dd-MMM-yyyy") + currentBranch.CompBrn_Name;

                saveFileDialog1.FileName = m_sMTExportFileName;
                saveFileDialog1.InitialDirectory = @"H:\";
                saveFileDialog1.Filter = "Sales File (*.Salexp)|*.Salexp";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    m_sMTExportFileName = saveFileDialog1.FileName;

                    if (oListSOMaster != null)
                    {
                        IFormatter formatter = new BinaryFormatter();
                        using (Stream stream = new FileStream(m_sMTExportFileName, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            byte[] baKey = { 51, 208, 75, 59, 223, 134, 241, 155, 170, 229, 177, 160, 246, 71, 77, 141, 66, 7, 223, 103, 97, 80, 235, 82, 94, 107, 226, 190, 76, 94, 31, 43 };
                            byte[] baIV = { 142, 96, 41, 14, 206, 132, 173, 19, 12, 50, 124, 121, 42, 27, 35, 9 };
                            Rijndael rijndael = Rijndael.Create();
                            CryptoStream cryptoStream = new CryptoStream(stream, rijndael.CreateEncryptor(baKey, baIV), CryptoStreamMode.Write);

                            //
                            formatter.Serialize(cryptoStream, oListSOMaster);
                            //                    

                            cryptoStream.Close();
                        }
                    }
                }
            }
        }



        private void btnImportData_Click(object sender, EventArgs e)
        {
            List<CSOMaster> oListSOMaster = new List<CSOMaster>();

            openFileDialog1.InitialDirectory = @"H:\";
            openFileDialog1.Filter = "Sales File (*.Salexp)|*.Salexp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                IFormatter formatter = new BinaryFormatter();
                if (File.Exists(openFileDialog1.FileName))
                {
                    using (Stream stream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        byte[] baKey = { 51, 208, 75, 59, 223, 134, 241, 155, 170, 229, 177, 160, 246, 71, 77, 141, 66, 7, 223, 103, 97, 80, 235, 82, 94, 107, 226, 190, 76, 94, 31, 43 };
                        byte[] baIV = { 142, 96, 41, 14, 206, 132, 173, 19, 12, 50, 124, 121, 42, 27, 35, 9 };
                        Rijndael rijndael = Rijndael.Create();
                        CryptoStream cryptoStream = new CryptoStream(stream, rijndael.CreateDecryptor(baKey, baIV), CryptoStreamMode.Read);

                        //
                        oListSOMaster = (List<CSOMaster>)formatter.Deserialize(cryptoStream);
                        //
                        cryptoStream.Close();
                    }
                }
            }

            if (oListSOMaster.Count > 0)
            {

                if (currentBranch.CompBrn_OId.Trim() == ((CSOMaster)oListSOMaster[0]).ExportedToBrnOID.Trim())
                {
                    //Show Data
                    if (oListSOMaster.Count > 0)
                    {
                        ShowImportedDataasRpt(oListSOMaster);
                    }
                }
                else
                {
                    MessageBox.Show("You can not access the selected file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    oListSOMaster = null;
                }
            }
        }


        private void ShowImportedDataasRpt(List<CSOMaster> oListSOMaster)
        {
            POS posdateset = new POS();
            DataTable dtDailySale = posdateset.DailySales;


            foreach (CSOMaster oSOMaster in oListSOMaster)
            {
                foreach (CSODetails oSODetails in oSOMaster.SOMstr_DetailsList)
                {
                    DataRow drDailySale = dtDailySale.NewRow();

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
                    drDailySale["DiscAmount"] = oSOMaster.SOMstr_DiscAmt;
                    drDailySale["NetAmount"] = oSOMaster.SOMstr_NetAmt;


                    dtDailySale.Rows.Add(drDailySale);
                }
            }

            rptDailySales orpt = new rptDailySales();
            orpt.SetDataSource(posdateset);
            orpt.SetParameterValue(0, currentBranch.CompBrn_Name.Trim());
            orpt.SetParameterValue(1, oListSOMaster[0].SOMstr_Date.Date);

            frmReportView ofrmReportView = new frmReportView();
            CrystalReportViewer orptviewer = (CrystalReportViewer)ofrmReportView.Controls["rptviewer"];
            orptviewer.ReportSource = orpt;
            // orptviewer.AutoSize = false;

            orptviewer.Show();
            ofrmReportView.Show();

            //crystalReportViewer1.ReportSource = orpt;
            //crystalReportViewer1.Show();


        }

        private void btnSaveImportedData_Click(object sender, EventArgs e)
        {
            List<CSOMaster> oListSOMaster = new List<CSOMaster>();
            openFileDialog1.InitialDirectory = @"H:\";
            openFileDialog1.Filter = "Sales File (*.Salexp)|*.Salexp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                IFormatter formatter = new BinaryFormatter();
                if (File.Exists(openFileDialog1.FileName))
                {
                    using (Stream stream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        byte[] baKey = { 51, 208, 75, 59, 223, 134, 241, 155, 170, 229, 177, 160, 246, 71, 77, 141, 66, 7, 223, 103, 97, 80, 235, 82, 94, 107, 226, 190, 76, 94, 31, 43 };
                        byte[] baIV = { 142, 96, 41, 14, 206, 132, 173, 19, 12, 50, 124, 121, 42, 27, 35, 9 };
                        Rijndael rijndael = Rijndael.Create();
                        CryptoStream cryptoStream = new CryptoStream(stream, rijndael.CreateDecryptor(baKey, baIV), CryptoStreamMode.Read);

                        //
                        oListSOMaster = (List<CSOMaster>)formatter.Deserialize(cryptoStream);
                        //
                        cryptoStream.Close();
                    }
                }
            }

            if (oListSOMaster.Count > 0)
            {
                if (currentBranch.CompBrn_OId.Trim() == ((CSOMaster)oListSOMaster[0]).ExportedToBrnOID.Trim())
                {
                    //Save data to t_somstr and t_sodet
                    if (oListSOMaster.Count > 0)
                    {
                        CResult oResult = new CResult();
                        CSOBO oSOBO = new CSOBO();
                        if (oListSOMaster.Count > 0)
                        {
                            foreach (CSOMaster oSOMaster in oListSOMaster)
                            {
                                oResult = oSOBO.Import(oSOMaster, currentBranch.CompBrn_Branch, currentBranch.CompBrn_OId);

                                if (!oResult.IsSuccess)
                                {
                                    MessageBox.Show(oResult.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                            }

                            if (oResult.IsSuccess)
                            {
                                MessageBox.Show("Successfully Done ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            // UPdate inventory

                        }
                    }
                }
                else
                {
                    MessageBox.Show("You can not access the selected file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    oListSOMaster = null;
                }
            }
        }

        private void btnReportShow_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }


        private void GenerateReport()
        {
            List<CSOMaster> oListSOMaster = LoadSODataInDuration();

            POS posdateset = new POS();
            DataTable dtDailySale = posdateset.DailySales;

            foreach (CSOMaster oSOMaster in oListSOMaster)
            {
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
                    drDailySale["DiscAmount"] = oSOMaster.SOMstr_DiscAmt;
                    drDailySale["NetAmount"] = oSOMaster.SOMstr_NetAmt;
                    drDailySale["PPrice"] = oSODetails.SODet_PPrice;

                    dtDailySale.Rows.Add(drDailySale);
                }
            }

            rptDateDurationSales orpt = new rptDateDurationSales();
            orpt.SetDataSource(posdateset);
            orpt.SetParameterValue(0, currentBranch.CompBrn_Name.Trim());
            orpt.SetParameterValue(1, dtpDateFrom.Value.Date);
            orpt.SetParameterValue(2, dtpDateTo.Value.Date);
            //  orpt.SetParameterValue(1, currentUser.User_UserName.Trim());



            frmReportView ofrmReportView = new frmReportView();
            CrystalReportViewer orptviewer = (CrystalReportViewer)ofrmReportView.Controls["rptviewer"];
            orptviewer.ReportSource = orpt;
            // orptviewer.AutoSize = false;

            orptviewer.Show();
            ofrmReportView.Show();


            //crystalReportViewer1.ReportSource = orpt;
            //crystalReportViewer1.Show();
        }

        private List<CSOMaster> LoadSODataInDuration()
        {
            List<CSOMaster> oListSOMaster = new List<CSOMaster>();

            CSOBO oCSOBO = new CSOBO();
            CResult oResult = new CResult();
            DateTime date = dtpDate.Value.Date;
            oResult = oCSOBO.ReadSalesBranNDateDurationWise(dtpDateFrom.Value.Date, dtpDateTo.Value.Date, ddlRptBranch2.SelectedValue.ToString().Trim(), ddlExportedBranch.SelectedValue.ToString().Trim());

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


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                groupBox5.Enabled = true;
                radioButton1.Checked = false;
                radioButton3.Checked = false;
                groupBox4.Enabled = false;
                groupBox6.Enabled = false;
            }
            else if (radioButton3.Checked)
            {
                groupBox6.Enabled = true;
                groupBox4.Enabled = false;
                groupBox5.Enabled = false;
                radioButton1.Checked = false;
                radioButton2.Checked = false;

            }

            else
            {
                groupBox4.Enabled = true;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                groupBox5.Enabled = false;
                groupBox6.Enabled = false;


            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
            {
                groupBox4.Enabled = true;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                groupBox5.Enabled = false;
                groupBox6.Enabled = false;
            }

            else if (radioButton3.Checked)
            {
                groupBox6.Enabled = true;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                groupBox4.Enabled = false;
                groupBox5.Enabled = false;

            }
            else
            {
                groupBox5.Enabled = true;
                radioButton1.Checked = false;
                radioButton3.Checked = false;
                groupBox4.Enabled = false;
                groupBox6.Enabled = false;
            }

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                groupBox4.Enabled = true;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                groupBox5.Enabled = false;
                groupBox6.Enabled = false;
            }
            else if (radioButton2.Checked)
            {
                groupBox5.Enabled = true;
                radioButton1.Checked = false;
                radioButton3.Checked = false;
                groupBox4.Enabled = false;
                groupBox6.Enabled = false;
            }
            else
            {
                groupBox6.Enabled = true;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                groupBox4.Enabled = false;
                groupBox5.Enabled = false;

            }
        }

        private void btnShowItemWiseReport_Click(object sender, EventArgs e)
        {
            GenerateItemWiseReport();
        }

        private void GenerateItemWiseReport()
        {
            List<CSOMaster> oListSOMaster = LoadItemWiseSales();

            POS posdateset = new POS();
            DataTable dtDailySale = posdateset.DailySales;

            foreach (CSOMaster oSOMaster in oListSOMaster)
            {
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
                    drDailySale["DiscAmount"] = oSOMaster.SOMstr_DiscAmt;
                    drDailySale["NetAmount"] = oSOMaster.SOMstr_NetAmt;

                    dtDailySale.Rows.Add(drDailySale);
                }
            }

            rptItemWiseSales orpt = new rptItemWiseSales();
            orpt.SetDataSource(posdateset);
            orpt.SetParameterValue(0, currentBranch.CompBrn_Name.Trim());
            orpt.SetParameterValue(1, dtpDateFrom2.Value.Date);
            orpt.SetParameterValue(2, dtpDateTo2.Value.Date);
            //  orpt.SetParameterValue(3, cmbItemName.SelectedText.ToString());
            //  orpt.SetParameterValue(1, currentUser.User_UserName.Trim());



            frmReportView ofrmReportView = new frmReportView();
            CrystalReportViewer orptviewer = (CrystalReportViewer)ofrmReportView.Controls["rptviewer"];
            orptviewer.ReportSource = orpt;
            // orptviewer.AutoSize = false;

            orptviewer.Show();
            ofrmReportView.Show();


            //crystalReportViewer1.ReportSource = orpt;
            //crystalReportViewer1.Show();
        }

        private List<CSOMaster> LoadItemWiseSales()
        {
            List<CSOMaster> oListSOMaster = new List<CSOMaster>();

            CSOBO oCSOBO = new CSOBO();
            CResult oResult = new CResult();
            DateTime date = dtpDate.Value.Date;
            oResult = oCSOBO.ReadSalesItemWise(dtpDateFrom2.Value.Date, dtpDateTo2.Value.Date, ddlRptBranch3.SelectedValue.ToString().Trim(), cmbItemName.SelectedValue.ToString(), ddlExportedBranch.SelectedValue.ToString().Trim());

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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
