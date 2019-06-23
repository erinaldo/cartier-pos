using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml;

using ETL.Model;
using ETL.Common;
using ETL.DAO;
using Model;

namespace ETL
{
    namespace BLL
    {

        public class CSOBO
        {

            #region "Member variables"

            private SqlConnection conn;
            private CResult oResult;
            private CConManager oConnManager;

            string s_DBError = "";

            #endregion

            #region "Costructor"

            public CSOBO()
            {
                oConnManager = new CConManager();
            }
            #endregion

            public CResult Create(CSOMaster oMaster)
            {
                List<CInventory> oInvtList = new List<CInventory>();
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.Parameters.Clear();

                    cmd.Transaction = oConnManager.BeginTransaction();
                    try
                    {
                        cmd.CommandText = "sp_SOMaster_Insert";
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.Add("@SOMstr_OID", SqlDbType.Char, 24);
                        cmd.Parameters["@SOMstr_OID"].Direction = ParameterDirection.Output;

                        cmd.Parameters.AddWithValue("@SOMstr_Branch", oMaster.SOMstr_Branch);
                        cmd.Parameters.AddWithValue("@SOMstr_Code", oMaster.SOMstr_Code);
                        cmd.Parameters.AddWithValue("@SOMstr_Date", oMaster.SOMstr_Date);
                        cmd.Parameters.AddWithValue("@SOMstr_By", oMaster.SOMstr_By);
                        cmd.Parameters.AddWithValue("@SOMstr_CustomerID", oMaster.SOMstr_CustomerID);
                        cmd.Parameters.AddWithValue("@SOMstr_TotalAmt", oMaster.SOMstr_TotalAmt);
                        cmd.Parameters.AddWithValue("@SOMstr_DiscAmt", oMaster.SOMstr_DiscAmt);
                        cmd.Parameters.AddWithValue("@SOMstr_NetAmt", oMaster.SOMstr_NetAmt);
                        cmd.Parameters.AddWithValue("@SOMstr_FinalDest", oMaster.SOMstr_FinalDest);
                        cmd.Parameters.AddWithValue("@SOMstr_TransportType", oMaster.SOMstr_TransportType);
                        cmd.Parameters.AddWithValue("@SOMstr_TransportNo", oMaster.SOMstr_TransportNo);
                        //cmd.Parameters.AddWithValue("@SOMstr_VatClnNo", oMaster.SOMstr_VatClnNo);
                        cmd.Parameters.AddWithValue("@SOMstr_VatDate", oMaster.SOMstr_VatDate);
                        cmd.Parameters.AddWithValue("@SOMstr_PricingDate", oMaster.SOMstr_PricingDate);
                        cmd.Parameters.AddWithValue("@SOMstr_Creator", oMaster.Creator);
                        cmd.Parameters.AddWithValue("@SOMstr_CreationDate", oMaster.CreationDate);
                        cmd.Parameters.AddWithValue("@SOMstr_UpdateBy", oMaster.UpdateBy);
                        cmd.Parameters.AddWithValue("@SOMstr_UpdateDate", oMaster.UpdateDate);
                        cmd.Parameters.AddWithValue("@SOMstr_IsActive", (oMaster.IsActive == "Y") ? 1 : 0);
                        cmd.Parameters.AddWithValue("@SOMstr_Remarks", oMaster.Remarks);
                        cmd.Parameters.AddWithValue("@PaymentType", oMaster.PaymentType);
                        cmd.Parameters.AddWithValue("@SalesMan", oMaster.SalesMan);
                        cmd.Parameters.AddWithValue("@CardType", oMaster.CardType);
                        cmd.ExecuteNonQuery();
                        string stSOMStr_OID = cmd.Parameters["@SOMstr_OID"].Value.ToString();

                        foreach (CSODetails oDetails in oMaster.SOMstr_DetailsList)
                        {
                            cmd.CommandText = "sp_SODetails_Insert";
                            cmd.Parameters.Clear();

                            cmd.Parameters.AddWithValue("@SODet_OID", oDetails.SODet_OID);
                            cmd.Parameters.AddWithValue("@SODet_Branch", oDetails.SODet_Branch);
                            cmd.Parameters.AddWithValue("@SODet_MStrOID", stSOMStr_OID);
                            cmd.Parameters.AddWithValue("@SODet_ItemSLNum", oDetails.SODet_ItemSLNum);
                            cmd.Parameters.AddWithValue("@SODet_ItemOID", oDetails.SODet_ItemOID);
                            cmd.Parameters.AddWithValue("@SODet_QTY", oDetails.SODet_QTY);
                            cmd.Parameters.AddWithValue("@SODet_UOM", oDetails.SODet_UOM);
                            cmd.Parameters.AddWithValue("@SODet_Price", oDetails.SODet_Price);
                            cmd.Parameters.AddWithValue("@SODet_Currency", oDetails.SODet_Currency);
                            cmd.Parameters.AddWithValue("@SODet_Amount", oDetails.SODet_Amount);
                            cmd.Parameters.AddWithValue("@SODet_SDValue", oDetails.SODet_SDValue);
                            cmd.Parameters.AddWithValue("@SODet_SDAmount", oDetails.SODet_SDAmount);
                            cmd.Parameters.AddWithValue("@SODet_VATValue", oDetails.SODet_VATValue);
                            cmd.Parameters.AddWithValue("@SODet_VATAmount", oDetails.SODet_VATAmount);
                            cmd.Parameters.AddWithValue("@SODet_Discount", oDetails.SODet_Discount);
                            cmd.Parameters.AddWithValue("@SODet_NetAmount", oDetails.SODet_NetAmount);
                            cmd.Parameters.AddWithValue("@SODet_BranchOID", oDetails.SODet_BranchOID);
                            cmd.Parameters.AddWithValue("@SODet_LocOID", oDetails.SODet_LocOID);
                            cmd.Parameters.AddWithValue("@SODet_Pprice", oDetails.SODet_PPrice);

                            cmd.ExecuteNonQuery();

                            // populate inv list
                            CInventory oInventory = new CInventory();

                            oInventory.Invt_Branch = oDetails.SODet_Branch;
                            oInventory.Invt_BranchOID = oDetails.SODet_BranchOID;
                            oInventory.Invt_InvType = (int)EInvType.GOOD;
                            oInventory.Invt_ItemOID = oDetails.SODet_ItemOID;
                            oInventory.Invt_LocOID = oDetails.SODet_LocOID;
                            oInventory.Invt_QTY = oDetails.SODet_QTY;

                            oInvtList.Add(oInventory);
                        }

                        //Update inv
                        CInventoryBO oInventoryBO = new CInventoryBO();
                        oResult = oInventoryBO.InvtDec(oInvtList);

                        if (oResult.IsSuccess)
                        {
                            oConnManager.Commit();
                            oResult.Data = stSOMStr_OID;
                            oResult.IsSuccess = true;
                        }
                        else
                        {
                            oResult.ErrMsg = oConnManager.Rollback();
                            oResult.IsSuccess = false;
                        }
                    }
                    catch (SqlException e)
                    {
                        string sRollbackError = oConnManager.Rollback();

                        oResult.IsSuccess = false;
                        oResult.ErrMsg = sRollbackError.Equals("") ? oConnManager.GetErrorMessage(e) : sRollbackError;
                    }
                    finally
                    {
                        oConnManager.Close();
                    }
                }
                else
                {
                    oResult.IsSuccess = false;
                    oResult.ErrMsg = s_DBError;
                }

                return oResult;
            }

            public CResult CreateSalesImport(CSOMaster oMaster)
            {
                List<CInventory> oInvtList = new List<CInventory>();
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.Parameters.Clear();

                    cmd.Transaction = oConnManager.BeginTransaction();
                    try
                    {
                        cmd.CommandText = "sp_SOMaster_Insert_ImportSales";
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@SOMstr_OID", oMaster.SOMstr_OID);
                        cmd.Parameters.AddWithValue("@SOMstr_Branch", oMaster.SOMstr_Branch);
                        cmd.Parameters.AddWithValue("@SOMstr_Code", oMaster.SOMstr_Code);
                        cmd.Parameters.AddWithValue("@SOMstr_Date", oMaster.SOMstr_Date);
                        cmd.Parameters.AddWithValue("@SOMstr_By", oMaster.SOMstr_By);
                        cmd.Parameters.AddWithValue("@SOMstr_CustomerID", oMaster.SOMstr_CustomerID);
                        cmd.Parameters.AddWithValue("@SOMstr_TotalAmt", oMaster.SOMstr_TotalAmt);
                        cmd.Parameters.AddWithValue("@SOMstr_DiscAmt", oMaster.SOMstr_DiscAmt);
                        cmd.Parameters.AddWithValue("@SOMstr_NetAmt", oMaster.SOMstr_NetAmt);
                        cmd.Parameters.AddWithValue("@SOMstr_FinalDest", oMaster.SOMstr_FinalDest);
                        cmd.Parameters.AddWithValue("@SOMstr_TransportType", oMaster.SOMstr_TransportType);
                        cmd.Parameters.AddWithValue("@SOMstr_TransportNo", oMaster.SOMstr_TransportNo);
                        cmd.Parameters.AddWithValue("@SOMstr_VatClnNo", oMaster.SOMstr_VatClnNo);
                        cmd.Parameters.AddWithValue("@SOMstr_VatDate", oMaster.SOMstr_VatDate);
                        cmd.Parameters.AddWithValue("@SOMstr_PricingDate", oMaster.SOMstr_PricingDate);
                        cmd.Parameters.AddWithValue("@SOMstr_Creator", oMaster.Creator);
                        cmd.Parameters.AddWithValue("@SOMstr_CreationDate", oMaster.CreationDate);
                        cmd.Parameters.AddWithValue("@SOMstr_UpdateBy", oMaster.UpdateBy);
                        cmd.Parameters.AddWithValue("@SOMstr_UpdateDate", oMaster.UpdateDate);
                        cmd.Parameters.AddWithValue("@SOMstr_IsActive", (oMaster.IsActive == "Y") ? 1 : 0);
                        cmd.Parameters.AddWithValue("@SOMstr_Remarks", oMaster.Remarks);

                        cmd.ExecuteNonQuery();

                        foreach (CSODetails oDetails in oMaster.SOMstr_DetailsList)
                        {
                            cmd.CommandText = "sp_SODetails_Insert_SalesImport";
                            cmd.Parameters.Clear();

                            cmd.Parameters.AddWithValue("@SODet_OID", oDetails.SODet_OID);
                            cmd.Parameters.AddWithValue("@SODet_Branch", oDetails.SODet_Branch);
                            cmd.Parameters.AddWithValue("@SODet_MStrOID", oMaster.SOMstr_OID);
                            cmd.Parameters.AddWithValue("@SODet_ItemSLNum", oDetails.SODet_ItemSLNum);
                            cmd.Parameters.AddWithValue("@SODet_ItemOID", oDetails.SODet_ItemOID);
                            cmd.Parameters.AddWithValue("@SODet_QTY", oDetails.SODet_QTY);
                            cmd.Parameters.AddWithValue("@SODet_UOM", oDetails.SODet_UOM);
                            cmd.Parameters.AddWithValue("@SODet_Price", oDetails.SODet_Price);
                            cmd.Parameters.AddWithValue("@SODet_Currency", oDetails.SODet_Currency);
                            cmd.Parameters.AddWithValue("@SODet_Amount", oDetails.SODet_Amount);
                            cmd.Parameters.AddWithValue("@SODet_SDValue", oDetails.SODet_SDValue);
                            cmd.Parameters.AddWithValue("@SODet_SDAmount", oDetails.SODet_SDAmount);
                            cmd.Parameters.AddWithValue("@SODet_VATValue", oDetails.SODet_VATValue);
                            cmd.Parameters.AddWithValue("@SODet_VATAmount", oDetails.SODet_VATAmount);
                            cmd.Parameters.AddWithValue("@SODet_Discount", oDetails.SODet_Discount);
                            cmd.Parameters.AddWithValue("@SODet_NetAmount", oDetails.SODet_NetAmount);
                            cmd.Parameters.AddWithValue("@SODet_BranchOID", oDetails.SODet_BranchOID);
                            cmd.Parameters.AddWithValue("@SODet_LocOID", oDetails.SODet_LocOID);
                            cmd.Parameters.AddWithValue("@SODet_Pprice", oDetails.SODet_PPrice);

                            cmd.ExecuteNonQuery();

                            // populate inv list
                            //CInventory oInventory = new CInventory();

                            //oInventory.Invt_Branch = oDetails.SODet_Branch;
                            //oInventory.Invt_BranchOID = oDetails.SODet_BranchOID;
                            //oInventory.Invt_InvType = (int)EInvType.GOOD;
                            //oInventory.Invt_ItemOID = oDetails.SODet_ItemOID;
                            //oInventory.Invt_LocOID = oDetails.SODet_LocOID;
                            //oInventory.Invt_QTY = oDetails.SODet_QTY;

                            //oInvtList.Add(oInventory);
                        }

                        //Update inv
                        CInventoryBO oInventoryBO = new CInventoryBO();
                        oResult = oInventoryBO.InvtDec(oInvtList);

                        if (oResult.IsSuccess)
                        {
                            oConnManager.Commit();
                            oResult.Data = oMaster.SOMstr_OID;
                            oResult.IsSuccess = true;
                        }
                        else
                        {
                            oResult.ErrMsg = oConnManager.Rollback();
                            oResult.IsSuccess = false;
                        }
                    }
                    catch (SqlException e)
                    {
                        string sRollbackError = oConnManager.Rollback();

                        oResult.IsSuccess = false;
                        oResult.ErrMsg = sRollbackError.Equals("") ? oConnManager.GetErrorMessage(e) : sRollbackError;
                    }
                    finally
                    {
                        oConnManager.Close();
                    }
                }
                else
                {
                    oResult.IsSuccess = false;
                    oResult.ErrMsg = s_DBError;
                }

                return oResult;
            }



            public CResult Import(CSOMaster oMaster,string stBranch,string stBranOID )
            {
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.Parameters.Clear();

                    cmd.Transaction = oConnManager.BeginTransaction();
                    try
                    {
                        cmd.CommandText = "sp_SOMaster_Import";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@SOMstr_OID", oMaster.SOMstr_OID.Trim());
                        cmd.Parameters.AddWithValue("@SOMstr_Branch", stBranch);
                        cmd.Parameters.AddWithValue("@SOMstr_Code", oMaster.SOMstr_Code);
                        cmd.Parameters.AddWithValue("@SOMstr_Date", oMaster.SOMstr_Date);
                        cmd.Parameters.AddWithValue("@SOMstr_By", oMaster.SOMstr_By);
                        cmd.Parameters.AddWithValue("@SOMstr_CustomerID", oMaster.SOMstr_CustomerID);
                        cmd.Parameters.AddWithValue("@SOMstr_TotalAmt", oMaster.SOMstr_TotalAmt);
                        cmd.Parameters.AddWithValue("@SOMstr_DiscAmt", oMaster.SOMstr_DiscAmt);
                        cmd.Parameters.AddWithValue("@SOMstr_NetAmt", oMaster.SOMstr_NetAmt);
                        cmd.Parameters.AddWithValue("@SOMstr_FinalDest", oMaster.SOMstr_FinalDest);
                        cmd.Parameters.AddWithValue("@SOMstr_TransportType", oMaster.SOMstr_TransportType);
                        cmd.Parameters.AddWithValue("@SOMstr_TransportNo", oMaster.SOMstr_TransportNo);
                        //cmd.Parameters.AddWithValue("@SOMstr_VatClnNo", oMaster.SOMstr_VatClnNo);
                        cmd.Parameters.AddWithValue("@SOMstr_VatDate", oMaster.SOMstr_VatDate);
                        cmd.Parameters.AddWithValue("@SOMstr_PricingDate", oMaster.SOMstr_PricingDate);
                        cmd.Parameters.AddWithValue("@SOMstr_Creator", oMaster.Creator);
                        cmd.Parameters.AddWithValue("@SOMstr_CreationDate", oMaster.CreationDate);
                        cmd.Parameters.AddWithValue("@SOMstr_UpdateBy", oMaster.UpdateBy);
                        cmd.Parameters.AddWithValue("@SOMstr_UpdateDate", oMaster.UpdateDate);
                        cmd.Parameters.AddWithValue("@SOMstr_IsActive", (oMaster.IsActive == "Y") ? 1 : 0);
                        cmd.Parameters.AddWithValue("@SOMstr_Remarks", "Imported OID: "+oMaster.SOMstr_OID.Trim());


                        cmd.Parameters.Add("@IsExists", SqlDbType.Char,24);
                        cmd.Parameters["@IsExists"].Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();
                        string stSOMStr_OID = cmd.Parameters["@IsExists"].Value.ToString();

                        if (stSOMStr_OID.Trim() == "0")
                        {
                            oResult.ErrMsg = "These data is already exists. ";
                            oResult.IsSuccess = false;
                            return oResult;
                        }

                        foreach (CSODetails oDetails in oMaster.SOMstr_DetailsList)
                        {
                            cmd.CommandText = "sp_SODetails_Insert";
                            cmd.Parameters.Clear();

                            cmd.Parameters.AddWithValue("@SODet_OID", oDetails.SODet_OID);
                            cmd.Parameters.AddWithValue("@SODet_Branch", stBranch);
                            cmd.Parameters.AddWithValue("@SODet_MStrOID", stSOMStr_OID);
                            cmd.Parameters.AddWithValue("@SODet_ItemSLNum", oDetails.SODet_ItemSLNum);
                            cmd.Parameters.AddWithValue("@SODet_ItemOID", oDetails.SODet_ItemOID);
                            cmd.Parameters.AddWithValue("@SODet_QTY", oDetails.SODet_QTY);
                            cmd.Parameters.AddWithValue("@SODet_UOM", oDetails.SODet_UOM);
                            cmd.Parameters.AddWithValue("@SODet_Price", oDetails.SODet_Price);
                            cmd.Parameters.AddWithValue("@SODet_Currency", oDetails.SODet_Currency);
                            cmd.Parameters.AddWithValue("@SODet_Amount", oDetails.SODet_Amount);
                            cmd.Parameters.AddWithValue("@SODet_SDValue", oDetails.SODet_SDValue);
                            cmd.Parameters.AddWithValue("@SODet_SDAmount", oDetails.SODet_SDAmount);
                            cmd.Parameters.AddWithValue("@SODet_VATValue", oDetails.SODet_VATValue);
                            cmd.Parameters.AddWithValue("@SODet_VATAmount", oDetails.SODet_VATAmount);
                            cmd.Parameters.AddWithValue("@SODet_Discount", oDetails.SODet_Discount);
                            cmd.Parameters.AddWithValue("@SODet_NetAmount", oDetails.SODet_NetAmount);
                            cmd.Parameters.AddWithValue("@SODet_BranchOID", stBranOID);
                            cmd.Parameters.AddWithValue("@SODet_LocOID", oDetails.SODet_LocOID);


                            cmd.ExecuteNonQuery();
                        }

                        oConnManager.Commit();

                        oResult.Data = stSOMStr_OID;
                        oResult.IsSuccess = true;
                    }
                    catch (SqlException e)
                    {
                        string sRollbackError = oConnManager.Rollback();

                        oResult.IsSuccess = false;
                        oResult.ErrMsg = sRollbackError.Equals("") ? oConnManager.GetErrorMessage(e) : sRollbackError;
                    }
                    finally
                    {
                        oConnManager.Close();
                    }
                }
                else
                {
                    oResult.IsSuccess = false;
                    oResult.ErrMsg = s_DBError;
                }

                return oResult;
            }
            public CResult ReadInvoiceReport(string InvoiceID)
            {
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    cmd.Transaction = oConnManager.BeginTransaction();
                    try
                    {
                        DataSet ds = new DataSet();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_InvoiceReport";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@InvoiceID", InvoiceID);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);

                        oResult.IsSuccess = true;
                        oResult.Data = ds;

                    }
                    catch (SqlException e)
                    {
                        oResult.IsSuccess = false;
                        oResult.ErrMsg = e.Message;
                    }
                    finally
                    {
                        oConnManager.Close();
                    }
                }
                else
                {
                    oResult.IsSuccess = false;
                    oResult.ErrMsg = s_DBError;
                }

                return oResult;
            }

            //fattah & sarwar  
            public CResult DailySalesReport(DateTime Date, string stBranchOID)
            {
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    cmd.Transaction = oConnManager.BeginTransaction();
                    try
                    {
                        DataSet ds = new DataSet();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_DailySale";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Date", Date);
                        cmd.Parameters.AddWithValue("@BranchOID", stBranchOID);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);

                        oResult.IsSuccess = true;
                        oResult.Data = ds;

                    }
                    catch (SqlException e)
                    {
                        oResult.IsSuccess = false;
                        oResult.ErrMsg = e.Message;
                    }
                    finally
                    {
                        oConnManager.Close();
                    }
                }
                else
                {
                    oResult.IsSuccess = false;
                    oResult.ErrMsg = s_DBError;
                }

                return oResult;
            }

            //sarwar
            public CResult DailyCurrentStockReport(string stBranchOID)
            {
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    cmd.Transaction = oConnManager.BeginTransaction();
                    try
                    {
                        DataSet ds = new DataSet();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_Invt_CurrentStock";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@BranchOID", stBranchOID);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);

                        oResult.IsSuccess = true;
                        oResult.Data = ds;

                    }
                    catch (SqlException e)
                    {
                        oResult.IsSuccess = false;
                        oResult.ErrMsg = e.Message;
                    }
                    finally
                    {
                        oConnManager.Close();
                    }
                }
                else
                {
                    oResult.IsSuccess = false;
                    oResult.ErrMsg = s_DBError;
                }

                return oResult;
            }
            //Report Stock Details
            public CResult ReportStockDatials(string stBranchOID)
            {
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    cmd.Transaction = oConnManager.BeginTransaction();
                    try
                    {
                        DataSet ds = new DataSet();

                        cmd.Connection = conn;
                        cmd.CommandText = "Rpt_Sp_Item_ReadAllFGForSalesByBranchOID";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@BranchOID", stBranchOID);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);

                        oResult.IsSuccess = true;
                        oResult.Data = ds;

                    }
                    catch (SqlException e)
                    {
                        oResult.IsSuccess = false;
                        oResult.ErrMsg = e.Message;
                    }
                    finally
                    {
                        oConnManager.Close();
                    }
                }
                else
                {
                    oResult.IsSuccess = false;
                    oResult.ErrMsg = s_DBError;
                }

                return oResult;
            } 

            //sarwar
            public CResult ReadSalesBranNDateWise(DateTime dtDate,string stBranchOID,string stExportedBrnOID)
            {

                List<CSODetails> oSODetailsList = new List<CSODetails>();
                List<CSOMaster> oSOMasterList= new List<CSOMaster>();

                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_SO_ReadBrNDatWise";
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@SOMstr_Date",dtDate);
                        cmd.Parameters.AddWithValue("@CompBrn_OID", stBranchOID);
                        
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);

                        DataTable dtMaster = ds.Tables[0] as DataTable;
                        DataTable dtDetails = ds.Tables[1] as DataTable;

                        foreach (DataRow dr in dtDetails.Rows)
                        {
                            oSODetailsList.Add(GetResultSetToSODtls(dr));
                        }

                        foreach (DataRow dr in dtMaster.Rows)
                        {
                            CSOMaster oSOMaster = new CSOMaster();
                            oSOMaster = GetResultSetToSOMstr(dr);
                            oSOMaster.ExportedToBrnOID = stExportedBrnOID;

                            foreach ( CSODetails oSODetails in oSODetailsList)
                            {
                                if (oSODetails.SODet_MStrOID == oSOMaster.SOMstr_OID)
                                {
                                     oSOMaster.SOMstr_DetailsList.Add(oSODetails);
                                }
                            }
                            oSOMasterList.Add(oSOMaster);
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oSOMasterList;
                    }
                    catch (SqlException e)
                    {
                        oResult.IsSuccess = false;
                        oResult.ErrMsg = e.Message;
                    }
                    finally
                    {
                        oConnManager.Close();
                    }
                }
                else
                {
                    oResult.IsSuccess = false;
                    oResult.ErrMsg = s_DBError;
                }

                return oResult;
            }

            public CResult ReadSalesReturn(DateTime dtDate, string stBranchOID, string stExportedBrnOID)
            {

                List<CReturnItem> oCReturnItemtList = new List<CReturnItem>();
                List<CSOMaster> oSOMasterList = new List<CSOMaster>();

                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_ReturnItemReport";
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@Date", dtDate);
                        //cmd.Parameters.AddWithValue("@CompBrn_OID", stBranchOID);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);

                        DataTable dtMaster = ds.Tables[0] as DataTable;
                        DataTable dtReturn = ds.Tables[1] as DataTable;

                        foreach (DataRow dr in dtReturn.Rows)
                        {
                            oCReturnItemtList.Add(GetReturnItems(dr));
                        }

                        foreach (DataRow dr in dtMaster.Rows)
                        {
                            CSOMaster oSOMaster = new CSOMaster();
                            oSOMaster = GetResultSetToSOMstr(dr);
                            oSOMaster.ExportedToBrnOID = stExportedBrnOID;

                            foreach (CReturnItem oSODetails in oCReturnItemtList)
                            {
                                if (oSODetails.Ret_OID == oSOMaster.SOMstr_OID)
                                {
                                    oSOMaster.oReturnItemsList.Add(oSODetails);
                                }
                            }
                            oSOMasterList.Add(oSOMaster);
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oSOMasterList;
                    }
                    catch (SqlException e)
                    {
                        oResult.IsSuccess = false;
                        oResult.ErrMsg = e.Message;
                    }
                    finally
                    {
                        oConnManager.Close();
                    }
                }
                else
                {
                    oResult.IsSuccess = false;
                    oResult.ErrMsg = s_DBError;
                }

                return oResult;
            }

            public List<CReturnItem> ReadSalesReturn(DateTime oDt, string stBranchOID)
            {
                List<CReturnItem> oSomasterList = new List<CReturnItem>();
                CSOMaster oSoMaster = null;
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        SqlCommand comm = new SqlCommand();
                        DataTable dt = new DataTable();
                        comm.Connection = conn;
                        comm.CommandText = "sp_ReturnItemReportBranch";
                        comm.CommandType = CommandType.StoredProcedure;
                        //comm.Parameters.AddWithValue("@MemoId", oMemoId);
                        comm.Parameters.AddWithValue("@Date", oDt);
                        comm.Parameters.AddWithValue("@Ret_BranchOID", stBranchOID);
                        SqlDataAdapter da = new SqlDataAdapter(comm);
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                oSoMaster = new CSOMaster();
                                CReturnItem oCReturnItem = new CReturnItem();

                                oCReturnItem.ItemName = dr["Item_ItemName"].ToString();
                                oCReturnItem.Ret_QTY = float.Parse(dr["Ret_QTY"].ToString());
                                oCReturnItem.ItemPrice = float.Parse(dr["Price_ListPrice"].ToString());
                                oCReturnItem.Ret_BranchOID = dr["Ret_BranchOID"].ToString();
                                oCReturnItem.Ret_DiscountAmount = float.Parse(dr["Ret_DiscountAmount"].ToString());


                                //oSoDetail.date = DateTime.Now;
                                //oSoMaster.oReturnItemsList.Add(oSoDetail);

                                oSomasterList.Add(oCReturnItem);
                                //oSoMaster = null;
                            }

                        }
                    }
                    catch (Exception e)
                    {
                        oSomasterList = null;
                    }
                    finally
                    {
                        oConnManager.Close();
                    }
                }
                else
                {
                }
                return oSomasterList;
            }

            public CResult ReadSalesBranNDateDurationWise(DateTime dtDateFrom,DateTime dtDateTo, string stBranchOID, string stExportedBrnOID)
            {

                List<CSODetails> oSODetailsList = new List<CSODetails>();
                List<CSOMaster> oSOMasterList = new List<CSOMaster>();

                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_SO_ReadBrNDatDurationWise";
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@SOMstr_DateFrom", dtDateFrom);
                        cmd.Parameters.AddWithValue("@SOMstr_DateTo", dtDateTo);
                        cmd.Parameters.AddWithValue("@CompBrn_OID", stBranchOID);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);

                        DataTable dtMaster = ds.Tables[0] as DataTable;
                        DataTable dtDetails = ds.Tables[1] as DataTable;

                        foreach (DataRow dr in dtDetails.Rows)
                        {
                            oSODetailsList.Add(GetResultSetToSODtls(dr));
                        }

                        foreach (DataRow dr in dtMaster.Rows)
                        {
                            CSOMaster oSOMaster = new CSOMaster();
                            oSOMaster = GetResultSetToSOMstr(dr);
                            oSOMaster.ExportedToBrnOID = stExportedBrnOID;

                            foreach (CSODetails oSODetails in oSODetailsList)
                            {
                                if (oSODetails.SODet_MStrOID == oSOMaster.SOMstr_OID)
                                {
                                    oSOMaster.SOMstr_DetailsList.Add(oSODetails);
                                }
                            }
                            oSOMasterList.Add(oSOMaster);
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oSOMasterList;
                    }
                    catch (SqlException e)
                    {
                        oResult.IsSuccess = false;
                        oResult.ErrMsg = e.Message;
                    }
                    finally
                    {
                        oConnManager.Close();
                    }
                }
                else
                {
                    oResult.IsSuccess = false;
                    oResult.ErrMsg = s_DBError;
                }

                return oResult;
            }

            public CResult ReadSalesItemWise(DateTime dtDateFrom, DateTime dtDateTo, string stBranchOID, string stItemOID, string stExportedBrnOID)
            {

                List<CSODetails> oSODetailsList = new List<CSODetails>();
                List<CSOMaster> oSOMasterList = new List<CSOMaster>();

                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_SO_ReadSalesItemWise";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SOMstr_DateFrom", dtDateFrom);
                        cmd.Parameters.AddWithValue("@SOMstr_DateTo", dtDateTo);
                        cmd.Parameters.AddWithValue("@CompBrn_OID", stBranchOID);
                        cmd.Parameters.AddWithValue("@Item_OID", stItemOID);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);

                        DataTable dtMaster = ds.Tables[0] as DataTable;
                        DataTable dtDetails = ds.Tables[1] as DataTable;

                        foreach (DataRow dr in dtDetails.Rows)
                        {
                            oSODetailsList.Add(GetResultSetToSODtls(dr));
                        }

                        foreach (DataRow dr in dtMaster.Rows)
                        {
                            CSOMaster oSOMaster = new CSOMaster();
                            oSOMaster = GetResultSetToSOMstr(dr);
                            oSOMaster.ExportedToBrnOID = stExportedBrnOID;

                            foreach (CSODetails oSODetails in oSODetailsList)
                            {
                                if (oSODetails.SODet_MStrOID == oSOMaster.SOMstr_OID)
                                {
                                    oSOMaster.SOMstr_DetailsList.Add(oSODetails);
                                }
                            }
                            oSOMasterList.Add(oSOMaster);
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oSOMasterList;
                    }
                    catch (SqlException e)
                    {
                        oResult.IsSuccess = false;
                        oResult.ErrMsg = e.Message;
                    }
                    finally
                    {
                        oConnManager.Close();
                    }
                }
                else
                {
                    oResult.IsSuccess = false;
                    oResult.ErrMsg = s_DBError;
                }

                return oResult;
            }

            private CReturnItem GetReturnItems(DataRow dr)
            {
                CReturnItem oCReturnItem = new CReturnItem();
                oCReturnItem.Ret_OID = dr["Ret_OID"].ToString().Trim();
                oCReturnItem.ItemName = dr["Ret_ItemOID"].ToString();
                oCReturnItem.Ret_QTY = float.Parse(dr["Ret_QTY"].ToString());
                oCReturnItem.ItemPrice = float.Parse(dr["Price_ItemOId"].ToString());
                //oSODetails.SODet_ItemOID = dr["SODet_ItemOID"].ToString();
                //oSODetails.SODet_ItemName = dr["SODet_ItemName"].ToString();
                //oSODetails.SODet_QTY = float.Parse(dr["SODet_QTY"].ToString());
                //oSODetails.SODet_UOM = dr["SODet_UOM"].ToString();
                //oSODetails.SODet_Price = float.Parse(dr["SODet_Price"].ToString());
                //oSODetails.SODet_PPrice = float.Parse(dr["SODet_Pprice"].ToString());
                //oSODetails.SODet_Currency = dr["SODet_Currency"].ToString();
                //oSODetails.SODet_Amount = float.Parse(dr["SODet_Amount"].ToString());
                //oSODetails.SODet_SDValue = float.Parse(dr["SODet_SDValue"].ToString());
                //oSODetails.SODet_SDAmount = float.Parse(dr["SODet_SDAmount"].ToString());
                //oSODetails.SODet_VATValue = float.Parse(dr["SODet_VATValue"].ToString());
                //oSODetails.SODet_VATAmount = float.Parse(dr["SODet_VATAmount"].ToString());
                //oSODetails.SODet_Discount = float.Parse(dr["SODet_Discount"].ToString());
                //oSODetails.SODet_NetAmount = float.Parse(dr["SODet_NetAmount"].ToString());
                //oSODetails.SODet_BranchOID = dr["SODet_BranchOID"].ToString();
                //oSODetails.SODet_LocOID = dr["SODet_LocOID"].ToString();

                return oCReturnItem;
            }




            private CSODetails GetResultSetToSODtls(DataRow dr)
            {
                CSODetails oSODetails = new CSODetails();
                oSODetails.SODet_OID = dr["SODet_OID"].ToString().Trim();
                oSODetails.SODet_Branch = dr["SODet_Branch"].ToString();
                oSODetails.SODet_MStrOID = dr["SODet_MStrOID"].ToString();
                oSODetails.SODet_ItemSLNum = dr["SODet_ItemSLNum"].ToString();
                oSODetails.SODet_ItemOID = dr["SODet_ItemOID"].ToString();
                oSODetails.SODet_ItemName = dr["SODet_ItemName"].ToString();
                oSODetails.SODet_QTY = float.Parse( dr["SODet_QTY"].ToString());
                oSODetails.SODet_UOM = dr["SODet_UOM"].ToString();
                oSODetails.SODet_Price = float.Parse( dr["SODet_Price"].ToString());
                oSODetails.SODet_PPrice = float.Parse(dr["SODet_Pprice"].ToString());
                oSODetails.SODet_Currency = dr["SODet_Currency"].ToString();
                oSODetails.SODet_Amount = float.Parse( dr["SODet_Amount"].ToString());
                oSODetails.SODet_SDValue = float.Parse( dr["SODet_SDValue"].ToString());
                oSODetails.SODet_SDAmount = float.Parse( dr["SODet_SDAmount"].ToString());
                oSODetails.SODet_VATValue = float.Parse( dr["SODet_VATValue"].ToString());
                oSODetails.SODet_VATAmount = float.Parse( dr["SODet_VATAmount"].ToString());
                oSODetails.SODet_Discount = float.Parse( dr["SODet_Discount"].ToString());
                oSODetails.SODet_NetAmount = float.Parse( dr["SODet_NetAmount"].ToString());
                oSODetails.SODet_BranchOID = dr["SODet_BranchOID"].ToString();
                oSODetails.SODet_LocOID = dr["SODet_LocOID"].ToString();

                return oSODetails;
            }

            private CSOMaster GetResultSetToSOMstr(DataRow dr)
            {
                CSOMaster oSOMaster = new CSOMaster();
                oSOMaster.SOMstr_OID = dr["SOMstr_OID"].ToString().Trim();
                oSOMaster.SOMstr_Branch = dr["SOMstr_Branch"].ToString();
                oSOMaster.SOMstr_Date = DateTime.Parse( dr["SOMstr_Date"].ToString()).Date;
                oSOMaster.SOMstr_By = dr["SOMstr_By"].ToString();
                oSOMaster.SOMstr_CustomerID = dr["SOMstr_CustomerID"].ToString();
                oSOMaster.SOMstr_TotalAmt = float.Parse( dr["SOMstr_TotalAmt"].ToString());
                oSOMaster.SOMstr_DiscAmt = float.Parse( dr["SOMstr_DiscAmt"].ToString());
                oSOMaster.SOMstr_NetAmt = float.Parse( dr["SOMstr_NetAmt"].ToString());
                oSOMaster.SOMstr_FinalDest = dr["SOMstr_FinalDest"].ToString();
                oSOMaster.SOMstr_TransportType = dr["SOMstr_TransportType"].ToString();
                oSOMaster.SOMstr_TransportNo = dr["SOMstr_TransportNo"].ToString();
                oSOMaster.SOMstr_VatClnNo = dr["SOMstr_VatClnNo"].ToString();
                oSOMaster.SOMstr_VatDate = DateTime.Parse( dr["SOMstr_VatDate"].ToString()).Date;
                oSOMaster.SOMstr_PricingDate = DateTime.Parse( dr["SOMstr_PricingDate"].ToString()).Date;

                oSOMaster.Creator = dr["SOMstr_Creator"].ToString();
                oSOMaster.CreationDate = DateTime.Parse(dr["SOMstr_CreationDate"].ToString()).Date;
                oSOMaster.UpdateBy = dr["SOMstr_UpdateBy"].ToString();
                oSOMaster.UpdateDate = DateTime.Parse(dr["SOMstr_UpdateDate"].ToString()).Date;
                oSOMaster.IsActive = (bool.Parse(dr["SOMstr_IsActive"].ToString()) == true) ? "Y" : "N"; 
                oSOMaster.Remarks = dr["SOMstr_Remarks"].ToString();
                oSOMaster.TotalReturn = float.Parse(dr["TotalReturn"].ToString());

                return oSOMaster;
            }
            public CResult ReadSOFromToDate(DateTime FromDate,DateTime Todate,string branghOID)
            {
                oResult = new CResult();
                List<CSOMaster> oSoMasterList = new List<CSOMaster>();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "sp_SO_ReadFromToDate";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FromDate", FromDate.Date);
                        cmd.Parameters.AddWithValue("@ToDate", Todate.Date);
                        cmd.Parameters.AddWithValue("@Branch", branghOID);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dt = ds.Tables[0] as DataTable;
                        foreach (DataRow dr in dt.Rows)
                        {
                            oSoMasterList.Add(GetSOList(dr));
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oSoMasterList;
                    }
                    catch (SqlException e)
                    {
                        oResult.IsSuccess = false;
                        oResult.ErrMsg = e.Message;
                    }
                    finally
                    {
                        oConnManager.Close();
                    }
                }

                else
                {
                    oResult.IsSuccess = false;
                    oResult.ErrMsg = s_DBError;
                }
                return oResult;
            }

            private CSOMaster GetSOList(DataRow dr)
            {
                CSOMaster oSoMaster = new CSOMaster();
                oSoMaster.SOMstr_OID = dr["SOMstr_OID"].ToString().Trim();
                oSoMaster.SOMstr_Branch = dr["SOMstr_Branch"].ToString();
                oSoMaster.SOMstr_Code = dr["SOMstr_Code"].ToString();
                oSoMaster.SOMstr_Date = DateTime.Parse(dr["SOMstr_Date"].ToString()).Date;
                oSoMaster.SOMstr_TotalAmt = float.Parse(dr["SOMstr_TotalAmt"].ToString());
                oSoMaster.SOMstr_NetAmt = float.Parse(dr["SOMstr_NetAmt"].ToString());
                CSODetails oSoDetail = new CSODetails();
                oSoDetail.SODet_QTY = float.Parse(dr["SODet_QTY"].ToString());
                oSoMaster.SOMstr_DtailList = oSoDetail;

                return oSoMaster;
            }

            public List<CSOMaster> GetMemoData(string oMemoId, DateTime oDt, string oBranchId)
            {
                List<CSOMaster> oSomasterList = new List<CSOMaster>();
                CSOMaster oSoMaster = null;
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        SqlCommand comm = new SqlCommand();
                        DataTable dt = new DataTable();
                        comm.Connection=conn;
                        comm.CommandText = "sp_MemoReprint";
                        comm.CommandType=CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@MemoId", oMemoId);
                        comm.Parameters.AddWithValue("@MemoDate", oDt);
                        comm.Parameters.AddWithValue("@BranchId", oBranchId);
                        SqlDataAdapter da = new SqlDataAdapter(comm);
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                oSoMaster = new CSOMaster();
                                CSODetails oSoDetail = new CSODetails();
                                oSoMaster.SOMstr_Branch = dr["SOMstr_Branch"].ToString();
                                oSoMaster.SOMstr_Code = dr["SOMstr_Code"].ToString();
                                oSoMaster.SOMstr_Date = Convert.ToDateTime(dr["SOMstr_Date"].ToString());
                                oSoMaster.SOMstr_DiscAmt = float.Parse(dr["SOMstr_DiscAmt"].ToString());
                                oSoDetail.SODet_QTY = float.Parse(dr["SODet_QTY"].ToString());
                                oSoDetail.SODet_Price = float.Parse(dr["SODet_Price"].ToString());
                                oSoDetail.SODet_SDAmount = float.Parse(dr["SODet_Amount"].ToString());
                                oSoDetail.SODet_ItemName = dr["Item_ItemName"].ToString();
                                oSoMaster.SOMstr_DetailsList.Add(oSoDetail);
                                
                                oSomasterList.Add(oSoMaster);
                                //oSoMaster = null;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        oSomasterList = null;
                    }
                    finally
                    {
                        oConnManager.Close();
                    }
                }
                else
                {
                }
                return oSomasterList;
            }

            public CResult Return(CSOMaster oMaster, float discountAmount)
            {
                List<ReturnProduct> oReturnlist = new List<ReturnProduct>();
                List<CInventory> oInvtList = new List<CInventory>();
                oResult = new CResult();
                try
                {
                    foreach (CSODetails oDetails in oMaster.SOMstr_DetailsList)
                    {
                        // populate inv list
                        CInventory oInventory = new CInventory();

                        oInventory.Invt_Branch = oDetails.SODet_Branch;
                        oInventory.Invt_BranchOID = oDetails.SODet_BranchOID;
                        oInventory.Invt_InvType = (int)EInvType.GOOD;
                        oInventory.Invt_ItemOID = oDetails.SODet_ItemOID;
                        oInventory.Invt_LocOID = oDetails.SODet_LocOID;
                        oInventory.Invt_QTY =1;

                        oInvtList.Add(oInventory);

                        

                        ReturnProduct oReturn = new ReturnProduct();
                        oReturn.Ret_Branch = oDetails.SODet_Branch;
                        oReturn.Ret_BranchOID = oDetails.SODet_BranchOID;
                        oReturn.Ret_InvType = (int)EInvType.GOOD;
                        oReturn.Ret_ItemOID = oDetails.SODet_ItemOID;
                        oReturn.Ret_LocOID = oDetails.SODet_LocOID;
                        oReturn.Ret_QTY = 1;
                        oReturnlist.Add(oReturn);


                    }

                    //Update inv
                    CInventoryBO oInventoryBO = new CInventoryBO();
                    oResult = oInventoryBO.InvtInc(oInvtList);
                    oResult = oInventoryBO.ReturnProductCreate(oReturnlist,discountAmount);

                    if (oResult.IsSuccess)
                    {
                        oResult.IsSuccess = true;
                    }
                    else
                    {
                        oResult.IsSuccess = false;
                    }
                }
                catch (SqlException e)
                {

                    oResult.IsSuccess = false;
                }

                return oResult;
            }


        }
    }
}
            