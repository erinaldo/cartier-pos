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
    public partial class frmMTExpItems : BaseForm
    {
        public frmMTExpItems()
        {
            InitializeComponent();
        }

        public frmMTExpItems(string stDelvNo )
        {
            InitializeComponent();
            txtDelvNO.Text = stDelvNo;
        }

        private void GenerateReport()
        {

            CMaterialTransferBO oMaterialTransferBO = new CMaterialTransferBO();
            CResult oResult = new CResult();
            oResult = oMaterialTransferBO.ReadAllMTForExportRpt(txtDelvNO.Text.Trim());

            if (oResult.IsSuccess)
            {
                DataSet dsOUT = (DataSet)oResult.Data;
                DataTable dtOUT = dsOUT.Tables[0];

                if (dtOUT.Rows.Count > 0)
                {

                    POS posdateset = new POS();
                    DataTable dtMTIN = posdateset.MT;

                    foreach (DataRow drOUT in dtOUT.Rows)
                    {
                        DataRow drIN = dtMTIN.NewRow();

                        drIN["ItemName"] = drOUT["ItemName"];
                        drIN["Qty"] = drOUT["Qty"];
                        drIN["UOMCode"] = drOUT["UOMCode"];
                        drIN["SBranchName"] = drOUT["SBranchName"];
                        drIN["DBranchName"] = drOUT["DBranchName"];


                        dtMTIN.Rows.Add(drIN);
                    }

                    rptMT orpt = new rptMT();
                    orpt.SetDataSource(posdateset);
                    orpt.SetParameterValue(0, currentBranch.CompBrn_Name.Trim());
                    orpt.SetParameterValue(1, txtDelvNO.Text.Trim());
                    orpt.SetParameterValue(2, currentUser.User_UserName);

                    crystalReportViewer1.ReportSource = orpt;
                    crystalReportViewer1.Show();
                }
                else
                {
                    MessageBox.Show("NO data available to this delivery no", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportItems_Click(object sender, EventArgs e)
        {
            if (txtDelvNO.Text.Trim() != "")
            {
                List<CMTMaster> olistMT = new List<CMTMaster>();
                CMTMaster oMTMaster = new CMTMaster();

                CMaterialTransferBO oMTBO = new CMaterialTransferBO();
                CResult oResult = new CResult();
                if (txtDelvNO.Text.Trim() != "")
                {
                    oResult = oMTBO.ReadByIDDate(DateTime.Now.Date, DateTime.Now.Date, txtDelvNO.Text.Trim());
                }

                if (oResult.IsSuccess)
                {
                    olistMT = (List<CMTMaster>)oResult.Data;

                    oMTMaster = (CMTMaster)olistMT[0];
                }
                else
                {
                    MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    oMTMaster = null;
                }


                string m_sMTExportFileName = txtDelvNO.Text.Trim();

                saveFileDialog1.FileName = m_sMTExportFileName;
                saveFileDialog1.InitialDirectory = @"H:\";
                saveFileDialog1.Filter = "Delivery File (*.dlvexp)|*.dlvexp";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    m_sMTExportFileName = saveFileDialog1.FileName;

                    if (oMTMaster != null)
                    {
                        IFormatter formatter = new BinaryFormatter();
                        using (Stream stream = new FileStream(m_sMTExportFileName, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            byte[] baKey = { 51, 208, 75, 59, 223, 134, 241, 155, 170, 229, 177, 160, 246, 71, 77, 141, 66, 7, 223, 103, 97, 80, 235, 82, 94, 107, 226, 190, 76, 94, 31, 43 };
                            byte[] baIV = { 142, 96, 41, 14, 206, 132, 173, 19, 12, 50, 124, 121, 42, 27, 35, 9 };
                            Rijndael rijndael = Rijndael.Create();
                            CryptoStream cryptoStream = new CryptoStream(stream, rijndael.CreateEncryptor(baKey, baIV), CryptoStreamMode.Write);

                            //
                            formatter.Serialize(cryptoStream, oMTMaster);
                            //                    

                            cryptoStream.Close();
                        }
                    }
                }
            }
        }

        private void bntShowRpt_Click(object sender, EventArgs e)
        {
            if (txtDelvNO.Text.Trim() != "")
            {
                GenerateReport();
            }
        }
    }
}
