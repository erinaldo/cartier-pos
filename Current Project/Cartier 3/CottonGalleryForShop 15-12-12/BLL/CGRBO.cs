using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using ETL.Model;
using ETL.Common;
using ETL.DAO;
using System.Reflection;
using System.IO;
using System.ComponentModel;

namespace ETL
{
    namespace BLL
    {

        public class CGRBO
        {

            #region "Member variables"

            private SqlConnection conn;
            private CResult oResult;
            private CConManager oConnManager;

            string s_DBError = "";

            #endregion

            #region "Costructor"

            public CGRBO()
            {
                oConnManager = new CConManager();
            }
            #endregion

           
           
            public CResult Create(CGRMaster oMaster)
            {
                List<CInventory> oInvtList=new List<CInventory>();
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
                        //
                        cmd.CommandText = "sp_GRMaster_Insert";
                        cmd.CommandType = CommandType.StoredProcedure;
                                              
                        cmd.Parameters.Add("@GRMstr_OID",SqlDbType.Char,24);
                        cmd.Parameters["@GRMstr_OID"].Direction = ParameterDirection.Output;

                        cmd.Parameters.AddWithValue("@GRMstr_Branch", oMaster.GRMstr_Branch);
                        cmd.Parameters.AddWithValue("@GRMstr_Code", oMaster.GRMstr_Code);
                        cmd.Parameters.AddWithValue("@GRMstr_Date", oMaster.GRMstr_Date);
                        cmd.Parameters.AddWithValue("@GRMstr_Type", oMaster.GRMstr_Type);
                        cmd.Parameters.AddWithValue("@GRMstr_By", oMaster.GRMstr_By);
                        cmd.Parameters.AddWithValue("@GRMstr_RefBy", oMaster.GRMstr_RefBy);
                        cmd.Parameters.AddWithValue("@GRMstr_VendorID", oMaster.GRMstr_VendorID);
                        cmd.Parameters.AddWithValue("@GRMstr_TotalAmt", oMaster.GRMstr_TotalAmt);

                        cmd.Parameters.AddWithValue("@Creator", oMaster.Creator);
                        cmd.Parameters.AddWithValue("@CreationDate", oMaster.CreationDate);
                        cmd.Parameters.AddWithValue("@UpdateBy", oMaster.UpdateBy);
                        cmd.Parameters.AddWithValue("@UpdateDate", oMaster.UpdateDate);
                        cmd.Parameters.AddWithValue("@IsActive", (oMaster.IsActive == "Y") ? 1 : 0);
                        cmd.Parameters.AddWithValue("@Remarks", oMaster.Remarks);
                        cmd.Parameters.AddWithValue("@IsImported", oMaster.GRMstr_IsImported);

                        cmd.ExecuteNonQuery();
                        string stGRMStr_OID = cmd.Parameters["@GRMstr_OID"].Value.ToString();

                        if (stGRMStr_OID.Trim() == "")
                        {
                            oResult.ErrMsg = "This delivered data is already exists.";
                            oResult.IsSuccess = false;
                            return oResult;
                        }

                        foreach (CGRDetails oDetails in oMaster.GRMstr_DetailsList)
                        {
                            cmd.CommandText = "sp_GRDetails_Insert";
                            cmd.Parameters.Clear();

                            cmd.Parameters.AddWithValue("@GRDet_Branch", oDetails.GRDet_Branch);
                            cmd.Parameters.AddWithValue("@GRDet_OID", oDetails.GRDet_OID);
                            cmd.Parameters.AddWithValue("@GRDet_MStrOID", stGRMStr_OID);
                            cmd.Parameters.AddWithValue("@GRDet_ItemOID", oDetails.GRDet_ItemOID);
                            cmd.Parameters.AddWithValue("@GRDet_QTY", oDetails.GRDet_QTY);
                            cmd.Parameters.AddWithValue("@GRDet_UOM", oDetails.GRDet_UOM);
                            cmd.Parameters.AddWithValue("@GRDet_BranchOID", oDetails.GRDet_BranchOID);
                            cmd.Parameters.AddWithValue("@GRDet_LocOID", oDetails.GRDet_LocOID);
                            cmd.Parameters.AddWithValue("@GRDet_InvType", oDetails.GRDet_InvType);
                            cmd.Parameters.AddWithValue("@GRDet_Price", oDetails.GRDet_Price);
                            cmd.Parameters.AddWithValue("@GRDet_Currency", oDetails.GRDet_Currency);
                            cmd.Parameters.AddWithValue("@GRDet_Amount", oDetails.GRDet_Amount);

                            cmd.ExecuteNonQuery();

                            // populate inv list
                            CInventory oInventory = new CInventory();

                            oInventory.Invt_Branch = oDetails.GRDet_Branch;
                            oInventory.Invt_BranchOID = oDetails.GRDet_BranchOID;
                            oInventory.Invt_InvType = oDetails.GRDet_InvType;
                            oInventory.Invt_ItemOID = oDetails.GRDet_ItemOID;
                            oInventory.Invt_LocOID = oDetails.GRDet_LocOID;
                            oInventory.Invt_QTY = oDetails.GRDet_QTY;

                            oInvtList.Add(oInventory);
                        }
                        
                        //Update inv

                        CInventoryBO oInventoryBO = new CInventoryBO();
                        oResult = oInventoryBO.InvtInc(oInvtList);

                        if (oResult.IsSuccess)
                        {
                            oConnManager.Commit();

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


            public CResult CreateExportInBranch(CGRMaster oMaster)
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
                        //
                        cmd.CommandText = "sp_GRMaster_InsertExportProduct";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@GRMstr_OID", SqlDbType.Char, 24);
                        cmd.Parameters["@GRMstr_OID"].Direction = ParameterDirection.Output;

                        cmd.Parameters.AddWithValue("@GRMstr_Branch", oMaster.GRMstr_Branch);
                        cmd.Parameters.AddWithValue("@GRMstr_Code", oMaster.GRMstr_Code);
                        cmd.Parameters.AddWithValue("@GRMstr_Date", oMaster.GRMstr_Date);
                        cmd.Parameters.AddWithValue("@GRMstr_Type", oMaster.GRMstr_Type);
                        cmd.Parameters.AddWithValue("@GRMstr_By", oMaster.GRMstr_By);
                        cmd.Parameters.AddWithValue("@GRMstr_RefBy", oMaster.GRMstr_RefBy);
                        cmd.Parameters.AddWithValue("@GRMstr_VendorID", oMaster.GRMstr_VendorID);
                        cmd.Parameters.AddWithValue("@GRMstr_TotalAmt", oMaster.GRMstr_TotalAmt);

                        cmd.Parameters.AddWithValue("@Creator", oMaster.Creator);
                        cmd.Parameters.AddWithValue("@CreationDate", oMaster.CreationDate);
                        cmd.Parameters.AddWithValue("@UpdateBy", oMaster.UpdateBy);
                        cmd.Parameters.AddWithValue("@UpdateDate", oMaster.UpdateDate);
                        cmd.Parameters.AddWithValue("@IsActive", (oMaster.IsActive == "Y") ? 1 : 0);
                        cmd.Parameters.AddWithValue("@Remarks", oMaster.Remarks);
                        cmd.Parameters.AddWithValue("@IsImported", oMaster.GRMstr_IsImported);
                        

                        cmd.ExecuteNonQuery();
                        string stGRMStr_OID = cmd.Parameters["@GRMstr_OID"].Value.ToString();

                        if (stGRMStr_OID.Trim() == "")
                        {
                            oResult.ErrMsg = "This delivered data is already exists.";
                            oResult.IsSuccess = false;
                            return oResult;
                        }

                        foreach (CGRDetails oDetails in oMaster.GRMstr_DetailsList)
                        {
                            cmd.CommandText = "sp_GRDetails_InsertExportProduct";
                            cmd.Parameters.Clear();

                            cmd.Parameters.AddWithValue("@GRDet_Branch", oDetails.GRDet_Branch);
                            cmd.Parameters.AddWithValue("@GRDet_OID", oDetails.GRDet_OID);
                            cmd.Parameters.AddWithValue("@GRDet_MStrOID", stGRMStr_OID);
                            cmd.Parameters.AddWithValue("@GRDet_ItemOID", oDetails.GRDet_ItemOID);
                            cmd.Parameters.AddWithValue("@GRDet_QTY", oDetails.GRDet_QTY);
                            cmd.Parameters.AddWithValue("@GRDet_UOM", oDetails.GRDet_UOM);
                            cmd.Parameters.AddWithValue("@GRDet_BranchOID", oDetails.GRDet_BranchOID);
                            cmd.Parameters.AddWithValue("@GRDet_LocOID", oDetails.GRDet_LocOID);
                            cmd.Parameters.AddWithValue("@GRDet_InvType", oDetails.GRDet_InvType);
                            cmd.Parameters.AddWithValue("@GRDet_Price", oDetails.GRDet_Price);
                            cmd.Parameters.AddWithValue("@GRDet_Currency", oDetails.GRDet_Currency);
                            cmd.Parameters.AddWithValue("@GRDet_Amount", oDetails.GRDet_Amount);
                            cmd.Parameters.AddWithValue("@GR_Date", oDetails.GR_Date);

                            cmd.ExecuteNonQuery();

                            // populate inv list
                            CInventory oInventory = new CInventory();

                            oInventory.Invt_Branch = oDetails.GRDet_Branch;
                            oInventory.Invt_BranchOID = oDetails.GRDet_BranchOID;
                            oInventory.Invt_InvType = oDetails.GRDet_InvType;
                            oInventory.Invt_ItemOID = oDetails.GRDet_ItemOID;
                            oInventory.Invt_LocOID = oDetails.GRDet_LocOID;
                            oInventory.Invt_QTY = oDetails.GRDet_QTY;

                            oInvtList.Add(oInventory);
                        }

                        //Update inv

                        CInventoryBO oInventoryBO = new CInventoryBO();
                        oResult = oInventoryBO.InvtIncExportBranch(oInvtList);

                        if (oResult.IsSuccess)
                        {
                            oConnManager.Commit();

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


            public CResult ReadByIDDate(DateTime dtFrom, DateTime dtTo, string sID,string stCond)
            {
                List<CGRDetails> oGRDetailsList = new List<CGRDetails>();
                List<CGRMaster> oGRMasterList = new List<CGRMaster>();

                CResult oResult = new CResult();
                oResult.IsSuccess = false;
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlDataAdapter da;
                    DataSet ds;
                    cmd.Connection = conn;

                    cmd.Transaction = oConnManager.BeginTransaction();
                    try
                    {
                        cmd.CommandText = "sp_GRMaster_ReadByIDDate";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();

                        if (sID == null)
                        {
                            cmd.Parameters.AddWithValue("@frmDate", dtFrom);
                            cmd.Parameters.AddWithValue("@toDate", dtTo);
                            cmd.Parameters.AddWithValue("@OID", DBNull.Value);
                            cmd.Parameters.AddWithValue("@Cond", int.Parse(stCond));
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@frmDate", dtFrom);
                            cmd.Parameters.AddWithValue("@toDate", dtTo);
                            cmd.Parameters.AddWithValue("@OID", sID);
                            cmd.Parameters.AddWithValue("@Cond", int.Parse(stCond));
                        }

                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        if (ds.Tables.Count > 0)
                        {
                            DataTable dtMaster = ds.Tables[0] as DataTable;
                            DataTable dtDetails = ds.Tables[1] as DataTable;

                            foreach (DataRow dr in dtDetails.Rows)
                            {
                                oGRDetailsList.Add(GetResultSetToGRDetails(dr));
                            }

                            foreach (DataRow dr in dtMaster.Rows)
                            {
                                CGRMaster oGRMaster = new CGRMaster();
                                oGRMaster = GetResultSetToGRMaster(dr);
                                foreach (CGRDetails oGRDetails in oGRDetailsList)
                                {
                                    if (oGRDetails.GRDet_MStrOID == oGRMaster.GRMstr_OID)
                                    {
                                        oGRMaster.GRMstr_DetailsList.Add(oGRDetails);
                                    }
                                }
                                oGRMasterList.Add(oGRMaster);
                            }
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oGRMasterList;
                        oConnManager.Commit();
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

            private CGRMaster GetResultSetToGRMaster(DataRow dr)
            {
                CGRMaster oGRMaster = new CGRMaster();

                oGRMaster.GRMstr_OID = dr["GRMstr_OID"].ToString();
                oGRMaster.GRMstr_Branch = dr["GRMstr_Branch"].ToString();
                oGRMaster.GRMstr_Code = dr["GRMstr_Code"].ToString();
                oGRMaster.GRMstr_Date = DateTime.Parse(dr["GRMstr_Date"].ToString()).Date;
                oGRMaster.GRMstr_Type = int.Parse( dr["GRMstr_Type"].ToString());

                oGRMaster.GRMstr_By = dr["GRMstr_By"].ToString();
                oGRMaster.GRMstr_RefBy = dr["GRMstr_RefBy"].ToString();
                oGRMaster.GRMstr_VendorID = dr["GRMstr_VendorID"].ToString();
                oGRMaster.GRMstr_TotalAmt = float.Parse(dr["GRMstr_TotalAmt"].ToString());


                oGRMaster.Creator = dr["GRMstr_Creator"].ToString();
                oGRMaster.CreationDate = DateTime.Parse(dr["GRMstr_CreationDate"].ToString()).Date;
                oGRMaster.UpdateBy = dr["GRMstr_UpdateBy"].ToString();
                oGRMaster.UpdateDate = DateTime.Parse(dr["GRMstr_UpdateDate"].ToString()).Date;
                oGRMaster.IsActive = dr["GRMstr_IsActive"].ToString();
                oGRMaster.Remarks = dr["GRMstr_Remarks"].ToString();

                return oGRMaster;
            }

            private CGRDetails GetResultSetToGRDetails(DataRow dr)
            {
                CGRDetails oGRDetails = new CGRDetails();

                oGRDetails.GRDet_OID = dr["GRDet_OID"].ToString();
                oGRDetails.GRDet_MStrOID = dr["GRDet_MStrOID"].ToString();
                oGRDetails.GRDet_ItemOID = dr["GRDet_ItemOID"].ToString();
                oGRDetails.GRDet_QTY = float.Parse(dr["GRDet_QTY"].ToString());
                oGRDetails.GRDet_UOM = dr["GRDet_UOM"].ToString();
                oGRDetails.GRDet_BranchOID = dr["GRDet_BranchOID"].ToString();
                oGRDetails.GRDet_LocOID = dr["GRDet_LocOID"].ToString();
                oGRDetails.GRDet_InvType = int.Parse(dr["GRDet_InvType"].ToString());
                oGRDetails.GRDet_Currency = dr["GRDet_Currency"].ToString();
                oGRDetails.GRDet_Price = float.Parse(dr["GRDet_Price"].ToString());
                oGRDetails.GRDet_Amount = float.Parse(dr["GRDet_Amount"].ToString());

                return oGRDetails;
            }

            public CResult Update(CGRMaster oMaster, Dictionary<string, CGRDetails> oGRFinalQtyDic)
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
                        cmd.CommandText = "sp_GRMaster_Update";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();

                        cmd.Parameters.AddWithValue("@GRMstr_OID", oMaster.GRMstr_OID);
                        cmd.Parameters.AddWithValue("@GRMstr_Branch", oMaster.GRMstr_Branch);
                        cmd.Parameters.AddWithValue("@GRMstr_Code", oMaster.GRMstr_Code);
                        cmd.Parameters.AddWithValue("@GRMstr_Date", oMaster.GRMstr_Date);
                        cmd.Parameters.AddWithValue("@GRMstr_Type", oMaster.GRMstr_Type);
                        cmd.Parameters.AddWithValue("@GRMstr_By", oMaster.GRMstr_By);
                        cmd.Parameters.AddWithValue("@GRMstr_RefBy", oMaster.GRMstr_RefBy);
                        cmd.Parameters.AddWithValue("@GRMstr_VendorID", oMaster.GRMstr_VendorID);
                        cmd.Parameters.AddWithValue("@GRMstr_TotalAmt", oMaster.GRMstr_TotalAmt);

                        cmd.Parameters.AddWithValue("@Creator", oMaster.Creator);
                        cmd.Parameters.AddWithValue("@CreationDate", oMaster.CreationDate);
                        cmd.Parameters.AddWithValue("@UpdateBy", oMaster.UpdateBy);
                        cmd.Parameters.AddWithValue("@UpdateDate", oMaster.UpdateDate);
                        cmd.Parameters.AddWithValue("@IsActive", (oMaster.IsActive == "Y") ? 1 : 0);
                        cmd.Parameters.AddWithValue("@Remarks", oMaster.Remarks);
                      
                        cmd.ExecuteNonQuery();


                        cmd.CommandText = "Delete from t_GRDet where GRDet_MStrOID=@GRMstr_OID";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@GRMstr_OID", oMaster.GRMstr_OID);
                        cmd.ExecuteNonQuery();

                        foreach (CGRDetails oDetails in oMaster.GRMstr_DetailsList)
                        {
                            cmd.CommandText = "sp_GRDetails_Insert";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();

                            cmd.Parameters.AddWithValue("@GRDet_Branch", oDetails.GRDet_Branch);
                            cmd.Parameters.AddWithValue("@GRDet_OID", oDetails.GRDet_OID);
                            cmd.Parameters.AddWithValue("@GRDet_MStrOID", oMaster.GRMstr_OID);
                            cmd.Parameters.AddWithValue("@GRDet_ItemOID", oDetails.GRDet_ItemOID);
                            cmd.Parameters.AddWithValue("@GRDet_QTY", oDetails.GRDet_QTY);
                            cmd.Parameters.AddWithValue("@GRDet_UOM", oDetails.GRDet_UOM);
                            cmd.Parameters.AddWithValue("@GRDet_BranchOID", oDetails.GRDet_BranchOID);
                            cmd.Parameters.AddWithValue("@GRDet_LocOID", oDetails.GRDet_LocOID);
                            cmd.Parameters.AddWithValue("@GRDet_InvType", oDetails.GRDet_InvType);
                            cmd.Parameters.AddWithValue("@GRDet_Price", oDetails.GRDet_Price);
                            cmd.Parameters.AddWithValue("@GRDet_Currency", oDetails.GRDet_Currency);
                            cmd.Parameters.AddWithValue("@GRDet_Amount", oDetails.GRDet_Amount);

                            cmd.ExecuteNonQuery();
                        }

                        // update inventory

                        foreach (CGRDetails oGRDetails in oGRFinalQtyDic.Values)
                        {
                            // populate inv list
                            CInventory oInventory = new CInventory();

                            oInventory.Invt_Branch = oGRDetails.GRDet_Branch;
                            oInventory.Invt_BranchOID = oGRDetails.GRDet_BranchOID;
                            oInventory.Invt_InvType = oGRDetails.GRDet_InvType;
                            oInventory.Invt_ItemOID = oGRDetails.GRDet_ItemOID;
                            oInventory.Invt_LocOID = oGRDetails.GRDet_LocOID;
                            oInventory.Invt_QTY = oGRDetails.GRDet_QTY;

                            oInvtList.Add(oInventory);
                        }

                        //Update inv

                        CInventoryBO oInventoryBO = new CInventoryBO();
                        oResult = oInventoryBO.InvtInc(oInvtList);

                        if (oResult.IsSuccess)
                        {
                            oConnManager.Commit();

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

            public CResult Delete(string stGRMstr_OID)
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
                        cmd.CommandText = "DELETE FROM t_GRMstr WHERE GRMstr_OID=@GRMstr_OID;DELETE FROM t_GRDet WHERE GRDet_MStrOID=@GRMstr_OID";
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@GRMstr_OID", stGRMstr_OID);



                        cmd.ExecuteNonQuery();

                        oConnManager.Commit();
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

            public CResult ReduceByItemOID(List<CSODetails> oListSODetails)
            {
                List<CInventory> oInvtList = new List<CInventory>();
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    cmd.Transaction = oConnManager.BeginTransaction();
                    try
                    {
                        foreach (CSODetails oSODetails in oListSODetails)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("DECLARE @GRDet_OID char(24); ");
                            sb.Append("DECLARE @GRDet_QTY float; ");
                            sb.Append("DECLARE @TempQTY float; ");
                            sb.Append("WHILE (@ItemQTY > 0) BEGIN ");
                            sb.Append("SELECT @GRDet_QTY = 0; ");
                            sb.Append("SELECT @TempQTY = 0; ");
                            sb.Append("SELECT TOP(1) @GRDet_OID = [GRDet_OID], @GRDet_QTY = [GRDet_QTY] ");
                            sb.Append("FROM t_GRDet ");
                            sb.Append("WHERE [GRDet_ItemOID] = @ItemOID	AND [GRDet_BranchOID] = @BranchOID AND [GRDet_QTY] > 0 ");
                            sb.Append("IF (@GRDet_OID IS NOT NULL) BEGIN ");
                            sb.Append("IF(@ItemQTY > @GRDet_QTY) BEGIN ");
                            sb.Append("SELECT @TempQTY = 0; ");
                            sb.Append("SELECT @ItemQTY = @ItemQTY - @GRDet_QTY; ");
                            sb.Append("END ELSE BEGIN ");
                            sb.Append("SELECT @TempQTY = @GRDet_QTY - @ItemQTY; ");
                            sb.Append("SELECT @ItemQTY = 0; ");
                            sb.Append("END ");
                            sb.Append("UPDATE t_GRDet ");
                            sb.Append("SET ");
                            sb.Append("[GRDet_QTY] = @TempQTY ");
                            sb.Append("WHERE ");
                            sb.Append("[GRDet_OID] = @GRDet_OID; ");
                            sb.Append("END ");
                            sb.Append("SELECT @GRDet_OID = NULL; ");
                            sb.Append("END");

                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Clear();

                            cmd.CommandText = sb.ToString();
                            cmd.Parameters.AddWithValue("@ItemOID", oSODetails.SODet_ItemOID);
                            cmd.Parameters.AddWithValue("@ItemQTY", oSODetails.SODet_QTY);
                            cmd.Parameters.AddWithValue("@BranchOID", oSODetails.SODet_BranchOID);

                            cmd.ExecuteNonQuery();

                            // populate inv list
                            CInventory oInventory = new CInventory();

                            oInventory.Invt_Branch = oSODetails.SODet_Branch;
                            oInventory.Invt_BranchOID = oSODetails.SODet_BranchOID;
                            oInventory.Invt_InvType = (int)EInvType.GOOD;
                            oInventory.Invt_ItemOID = oSODetails.SODet_ItemOID;
                            oInventory.Invt_LocOID = oSODetails.SODet_LocOID;
                            oInventory.Invt_QTY = oSODetails.SODet_QTY;

                            oInvtList.Add(oInventory);
                        }

                        //Update inv
                        CInventoryBO oInventoryBO = new CInventoryBO();
                        oResult = oInventoryBO.InvtDec(oInvtList);

                        if (oResult.IsSuccess)
                        {
                            oConnManager.Commit();
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

            public CResult UpdateHomeGRTable()
            {
                try
                {
                    conn = oConnManager.GetConnectionForRemote();
                    if (conn != null)
                    {
                        SqlCommand oCommand = new SqlCommand("Update t_GRMstr set GRMatr_IsImported=1", conn);
                        oCommand.CommandType = CommandType.Text;
                        oCommand.ExecuteNonQuery();
                        oConnManager.Commit();
                        oResult.IsSuccess = true;

                    }
                }
                catch (SqlException e)
                {
                    oResult.IsSuccess = false;
                    oConnManager.Close();
                }
                finally
                {
                }
                return oResult;
            }

            //public CResult ReadByBranchAndDate(string BranchCode, DateTime FromDate, DateTime ToDate)
            //{
            //    List<CGRDetails> oItemList = new List<CGRDetails>();


            //    oResult = new CResult();
            //    conn = oConnManager.GetConnection(out s_DBError);
            //    if (conn != null)
            //    {
            //        try
            //        {
            //            DataSet ds = new DataSet();
            //            SqlCommand cmd = new SqlCommand();

            //            cmd.Connection = conn;
            //            cmd.CommandText = "sp_GRDetail_ReadByBrnIdAndDate";
            //            cmd.CommandType = CommandType.StoredProcedure;
            //            cmd.Parameters.Clear();

            //            cmd.Parameters.AddWithValue("@BranchID", BranchCode);
            //            cmd.Parameters.AddWithValue("@SOMstr_DateFrom", FromDate);
            //            cmd.Parameters.AddWithValue("@SOMstr_DateTo", ToDate);

            //            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //            da.Fill(ds);
            //            DataTable dtItem = ds.Tables[0];

            //            //  oItemList.Add("");
            //            foreach (DataRow dr in dtItem.Rows)
            //            {
            //                CGRDetails oGRDetails = new CGRDetails();

            //                oGRDetails.GRDet_ItemOID = dr["GRDet_ItemOID"].ToString();
            //                oGRDetails.GRDet_QTY = float.Parse(dr["GRDet_QTY"].ToString());
            //                oGRDetails.GRDet_BranchOID = dr["GRDet_Branch"].ToString();
            //                oGRDetails.GRDet_Price = float.Parse(dr["GRDet_Price"].ToString());
            //                oGRDetails.GRDet_Amount = float.Parse(dr["GRDet_Amount"].ToString());
            //                oGRDetails.GRDet_ItemName = dr["GRDet_ItemName"].ToString();

            //                oItemList.Add(oGRDetails);

            //            }

            //            oResult.IsSuccess = true;
            //            oResult.Data = oItemList;

            //        }
            //        catch (SqlException e)
            //        {
            //            oResult.IsSuccess = false;
            //            oResult.ErrMsg = e.Message;
            //        }
            //        finally
            //        {
            //            oConnManager.Close();
            //        }
            //    }
            //    else
            //    {
            //        oResult.IsSuccess = false;
            //        oResult.ErrMsg = s_DBError;
            //    }

            //    return oResult;
            //}
            //public CResult ReduceByItemOID(List<CSODetails> oListSODetails)
            //{
            //    oResult = new CResult();
            //    conn = oConnManager.GetConnection(out s_DBError);
            //    if (conn != null)
            //    {
            //        SqlCommand cmd = new SqlCommand();
            //        cmd.Connection = conn;

            //        cmd.Transaction = oConnManager.BeginTransaction();
            //        try
            //        {
            //            foreach (CSODetails oSODetails in oListSODetails)
            //            {
            //                cmd.CommandText = "sp_GRDetails_ReduceByItemOID";
            //                cmd.CommandType = CommandType.StoredProcedure;
            //                cmd.Parameters.Clear();

            //                cmd.Parameters.AddWithValue("@ItemOID", oSODetails.SODet_ItemOID);
            //                cmd.Parameters.AddWithValue("@ItemQTY", oSODetails.SODet_QTY);
            //                cmd.Parameters.AddWithValue("@BranchOID", oSODetails.SODet_BranchOID);

            //                cmd.ExecuteNonQuery();
            //            }

            //            oConnManager.Commit();

            //            oResult.IsSuccess = true;
            //        }
            //        catch (SqlException e)
            //        {
            //            string sRollbackError = oConnManager.Rollback();

            //            oResult.IsSuccess = false;
            //            oResult.ErrMsg = sRollbackError.Equals("") ? oConnManager.GetErrorMessage(e) : sRollbackError;
            //        }
            //        finally
            //        {
            //            oConnManager.Close();
            //        }
            //    }
            //    else
            //    {
            //        oResult.IsSuccess = false;
            //        oResult.ErrMsg = s_DBError;
            //    }

            //    return oResult;
            //}


            public CResult ExportAndUpdate(CGRMaster oMaster, string url)
            {
                CInventory oInventory = new CInventory();
                CResult oResult = new CResult();
                DataTable dt = new DataTable();
                List<CInventory> oInvtList = new List<CInventory>();
                List<CGRDetails> exportExcelList = new List<CGRDetails>();
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
                        foreach (CGRDetails oDetails in oMaster.GRMstr_DetailsList)
                        {
                            oInventory = new CInventory();
                            oInventory.Invt_Branch = oDetails.GRDet_Branch;
                            oInventory.Invt_BranchOID = oDetails.GRDet_BranchOID;
                            oInventory.Invt_InvType = oDetails.GRDet_InvType;
                            oInventory.Invt_ItemOID = oDetails.GRDet_ItemOID;
                            oInventory.Invt_LocOID = oDetails.GRDet_LocOID;
                            oInventory.Invt_QTY = oDetails.GRDet_QTY;

                            oInvtList.Add(oInventory);
                            exportExcelList.Add(oDetails);
                        }
                        CsvExport<CGRDetails> csv = new CsvExport<CGRDetails>(exportExcelList);
                        //csv.Export();
                      //  csv.ExportToFile(url);

                        // InventoryDT = ConvertToDataTable<CGRDetails>(exportExcelList);

                        CInventoryBO oInventoryBO = new CInventoryBO();
                        oResult = oInventoryBO.InvtDec(oInvtList);

                        if (oResult.IsSuccess)
                        {
                            oConnManager.Commit();
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

            public class CsvExport<T> where T : class
            {
                public List<T> Objects;

                public CsvExport(List<T> objects)
                {
                    Objects = objects;
                }

                public string Export()
                {
                    return Export(true);
                }

                public string Export(bool includeHeaderLine)
                {

                    StringBuilder sb = new StringBuilder();
                    //Get properties using reflection.
                    IList<PropertyInfo> propertyInfos = typeof(T).GetProperties();

                    if (includeHeaderLine)
                    {
                        //add header line.
                        foreach (PropertyInfo propertyInfo in propertyInfos)
                        {
                            sb.Append(propertyInfo.Name).Append(",");
                        }
                        sb.Remove(sb.Length - 1, 1).AppendLine();
                    }

                    //add value for each property.
                    foreach (T obj in Objects)
                    {
                        foreach (PropertyInfo propertyInfo in propertyInfos)
                        {
                            sb.Append(MakeValueCsvFriendly(propertyInfo.GetValue(obj, null))).Append(",");
                        }
                        sb.Remove(sb.Length - 1, 1).AppendLine();
                    }

                    return sb.ToString();
                }

                //export to a file.
                public void ExportToFile(string path)
                {
                    File.WriteAllText(path, Export());
                }

                //export as binary data.
                public byte[] ExportToBytes()
                {
                    return Encoding.UTF8.GetBytes(Export());
                }

                //get the csv value for field.
                private string MakeValueCsvFriendly(object value)
                {
                    if (value == null) return "";
                    if (value is Nullable && ((System.Data.SqlTypes.INullable)value).IsNull) return "";

                    if (value is DateTime)
                    {
                        if (((DateTime)value).TimeOfDay.TotalSeconds == 0)
                            return ((DateTime)value).ToString("yyyy-MM-dd");
                        return ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    string output = value.ToString();

                    if (output.Contains(",") || output.Contains("\""))
                        output = '"' + output.Replace("\"", "\"\"") + '"';

                    return output;

                }
            }

            public DataTable ConvertToDataTable<T>(IList<T> data)
            {
                PropertyDescriptorCollection properties =
                   TypeDescriptor.GetProperties(typeof(T));
                DataTable table = new DataTable();
                foreach (PropertyDescriptor prop in properties)
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                foreach (T item in data)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    table.Rows.Add(row);
                }
                return table;

            }
        }
    }
}
            