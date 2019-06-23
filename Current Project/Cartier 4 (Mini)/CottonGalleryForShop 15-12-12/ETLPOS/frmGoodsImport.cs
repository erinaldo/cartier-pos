using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using ETL.DAO;
using ETL.Model;
using ETL.Common;
using ETL.BLL;

namespace ETLPOS
{
    public partial class frmGoodsImport : ETLPOS.BaseForm
    {
        public frmGoodsImport()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                progressBarImport.Value = 0;
                Cursor = Cursors.WaitCursor;
                string selectGRFromHomeMaster = "select *from t_GRMstr where GRMatr_IsImported=0";
                SqlConnection oConnectionForHomeDB = new CConManager().GetConnectionForRemote();
                DataTable dtHome = new DataTable();
                SqlCommand oCommandForHome = new SqlCommand(selectGRFromHomeMaster, oConnectionForHomeDB);
                oCommandForHome.CommandType = CommandType.Text;
                SqlDataAdapter oSqlAdapter = new SqlDataAdapter(oCommandForHome);
                oSqlAdapter.Fill(dtHome);
                List<CGRMaster> oGRMasterList = new List<CGRMaster>();
                progressBarImport.Value = 70;
                if (dtHome.Rows.Count > 0)
                {

                    progressBarImport.Value = 70;
                    foreach (DataRow dr in dtHome.Rows)
                    {
                        CGRMaster oGRMaster = new CGRMaster();
                        oGRMaster.GRMstr_OID = "";
                        oGRMaster.GRMstr_Branch = currentBranch.CompBrn_Code;
                        oGRMaster.GRMstr_Code = GetGRmstrCode();
                        oGRMaster.GRMstr_Type = int.Parse(dr["GRMstr_Type"].ToString());
                        oGRMaster.GRMstr_Date = DateTime.Parse(dr["GRMstr_Date"].ToString());
                        oGRMaster.GRMstr_By = dr["GRMstr_By"].ToString();
                        oGRMaster.Remarks = dr["GRMstr_Remarks"].ToString();
                        oGRMaster.GRMstr_RefBy = dr["GRMstr_RefBy"].ToString();
                        oGRMaster.Creator = dr["GRMstr_Creator"].ToString();
                        oGRMaster.CreationDate = DateTime.Parse( dr["GRMstr_CreationDate"].ToString());
                        oGRMaster.UpdateBy = dr["GRMstr_UpdateBy"].ToString();
                        oGRMaster.UpdateDate = DateTime.Parse( dr["GRMstr_UpdateDate"].ToString());
                        oGRMaster.IsActive = "Y";
                        oGRMaster.GRMstr_IsImported = 1;
                        string selectGRForHomeDetail = "select *from t_GRDet where GRDet_MStrOID='" + dr["GRMstr_OID"].ToString()+"'";
                        SqlConnection oConnectionForHomeDBDetail = new CConManager().GetConnectionForRemote();
                        DataTable dtHomedetail = new DataTable();
                        SqlCommand oCommand = new SqlCommand(selectGRForHomeDetail, oConnectionForHomeDBDetail);
                        oCommand.CommandType = CommandType.Text;
                        SqlDataAdapter oDataAdapter = new SqlDataAdapter(oCommand);
                        oDataAdapter.Fill(dtHomedetail);
                        //List<CGRDetails> oGRDetailList = new List<CGRDetails>();
                        if (dtHomedetail.Rows.Count > 0)
                        {
                            foreach (DataRow drDetail in dtHomedetail.Rows)
                            {
                                CGRDetails oGRDetails = new CGRDetails();
                                oGRDetails.GRDet_Branch = currentBranch.CompBrn_Code;
                                oGRDetails.GRDet_ItemOID = drDetail["GRDet_ItemOID"].ToString();
                                oGRDetails.GRDet_QTY = float.Parse(drDetail["GRDet_QTY"].ToString());
                                oGRDetails.GRDet_UOM = drDetail["GRDet_UOM"].ToString();
                                oGRDetails.GRDet_BranchOID = currentBranch.CompBrn_OId;
                                oGRDetails.GRDet_LocOID = drDetail["GRDet_LocOID"].ToString();
                                oGRDetails.GRDet_InvType = int.Parse(drDetail["GRDet_InvType"].ToString());
                                oGRDetails.GRDet_Price = float.Parse(drDetail["GRDet_Price"].ToString());
                                oGRDetails.GRDet_Currency = drDetail["GRDet_Currency"].ToString();
                                oGRDetails.GRDet_Amount = float.Parse(drDetail["GRDet_Amount"].ToString());
                                //oGRDetailList.Add(oGRDetails);
                                oGRMaster.GRMstr_DetailsList.Add(oGRDetails);

                            }
                        }
                        //oGRMaster.GRMstr_DetailsList = oGRDetailList;
                        oGRMasterList.Add(oGRMaster);
                    }
                    if (oGRMasterList.Count > 0)
                    {
                        foreach (CGRMaster oGRMaster in oGRMasterList)
                        {
                            progressBarImport.Value = 50;
                            CResult oResult = new CResult();
                            CGRBO oGRBO = new CGRBO();
                            if (oGRMaster != null)
                            {
                                oResult = oGRBO.Create(oGRMaster);
                            }
                            if (oResult.IsSuccess)
                            {
                                progressBarImport.Value = 100;
                                this.Cursor = Cursors.Default;
                                oResult = oGRBO.UpdateHomeGRTable();
                            }
                            progressBarImport.Value = 100;
                            MessageBox.Show("Goods are successfully Imported", "ETLPOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }
                else if (dtHome.Rows.Count <= 0)
                {
                   DialogResult oDR= MessageBox.Show("You Have No Goods For Import", "ETLPOS", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                   if (oDR.ToString() == "OK")
                   {
                       this.Cursor = Cursors.Default;
                       progressBarImport.Value = 0;
                   }
                }
            }
            catch
            {
                MessageBox.Show("You Have No Goods For Import", "ETLPOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string GetGRmstrCode()
        {
            CResult oResult = new CResult();
            CCommonBO oCommonBO = new CCommonBO();
            string grmstrCode=null;
            oResult = oCommonBO.ReadLastCodeNo("GRMstr_Code", "GRMstr", currentBranch.CompBrn_Code);
            if (oResult.IsSuccess)
            {
                grmstrCode = oResult.Data.ToString();
            }
            else
            {
                MessageBox.Show("Loading error...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return grmstrCode;
        }
    }
}
