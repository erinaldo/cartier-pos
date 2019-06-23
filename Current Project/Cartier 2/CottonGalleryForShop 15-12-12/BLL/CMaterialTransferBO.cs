using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

using ETL.Model;
using ETL.Common;
using ETL.DAO;

namespace ETL
{
    namespace BLL
    {
        public class CMaterialTransferBO
        {
            #region "Member variables"

            private SqlConnection conn;
            private CResult oResult;
            private CConManager oConnManager;

            string s_DBError = "";

            #endregion

            #region "Costructor"

            public CMaterialTransferBO()
            {
                oConnManager = new CConManager();
            }
            #endregion

            public CResult Create(CMTMaster oMTMaster)
            {
                List<CInventory> oSrcInvtList = new List<CInventory>();
                List<CInventory> oDesInvtList = new List<CInventory>();
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    cmd.Transaction = oConnManager.BeginTransaction();
                    try
                    {
                        cmd.CommandText = "sp_MTMstr_Insert";
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@MTMstr_OID", oMTMaster.MTMstr_OID);


                        SqlParameter sParam = new SqlParameter("@MTMstr_OID", SqlDbType.Char, 24);
                        sParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(sParam).Value = "";

                        
                        cmd.Parameters.AddWithValue("@MTMstr_Branch", oMTMaster.MTMstr_Branch);
                        cmd.Parameters.AddWithValue("@MTMstr_Code", oMTMaster.MTMstr_Code);
                        cmd.Parameters.AddWithValue("@MTMstr_Date", oMTMaster.MTMstr_Date);
                        cmd.Parameters.AddWithValue("@MTMstr_DOrder", oMTMaster.MTMstr_DOrder);


                        cmd.Parameters.AddWithValue("@MTMstr_Creator", oMTMaster.Creator);
                        cmd.Parameters.AddWithValue("@MTMstr_CreationDate", oMTMaster.CreationDate);
                        cmd.Parameters.AddWithValue("@MTMstr_UpdatedBy", oMTMaster.UpdateBy);
                        cmd.Parameters.AddWithValue("@MTMstr_UpdateDate", oMTMaster.UpdateDate);
                        cmd.Parameters.AddWithValue("@MTMstr_IsActive", (oMTMaster.IsActive=="Y")?1:0 );
                        cmd.Parameters.AddWithValue("@MTMstr_Remarks", oMTMaster.Remarks);


                        cmd.ExecuteNonQuery();

                        string stMTMstr_OID = cmd.Parameters["@MTMstr_OID"].Value.ToString();
                        
                        foreach (CMTDetails oDetails in oMTMaster.MTMstr_DetailsList)
                        {
                            cmd.CommandText = "sp_MTDtls_Insert";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@MTDtls_Branch", oDetails.MTDtls_Branch);
                            cmd.Parameters.AddWithValue("@MTDtls_OID", oDetails.MTDtls_OID);
                            cmd.Parameters.AddWithValue("@MTDtls_MstrOID", stMTMstr_OID);
                            cmd.Parameters.AddWithValue("@MTDtls_ItemOID", oDetails.MTDtls_ItemOID);
                            cmd.Parameters.AddWithValue("@MTDtls_IssQty", oDetails.MTDtls_IssQty);
                            cmd.Parameters.AddWithValue("@MTDtls_IssUOMOID", oDetails.MTDtls_IssUOMOID);
                            cmd.Parameters.AddWithValue("@MTDtls_SBranOID", oDetails.MTDtls_SBranOID);
                            cmd.Parameters.AddWithValue("@MTDtls_SrcLocOID", oDetails.MTDtls_SrcLocOID);
                            cmd.Parameters.AddWithValue("@MTDtls_SrcInvTyp", oDetails.MTDtls_SrcInvTyp);
                            cmd.Parameters.AddWithValue("@MTDtls_DBranOID", oDetails.MTDtls_DBranOID);
                            cmd.Parameters.AddWithValue("@MTDtls_DestLocOID", oDetails.MTDtls_DestLocOID);
                            cmd.Parameters.AddWithValue("@MTDtls_DesInvtyp", oDetails.MTDtls_DesInvtyp);
                            cmd.Parameters.AddWithValue("@MTDtls_RQty", oDetails.MTDtls_RQty);
                            cmd.Parameters.AddWithValue("@MTDtls_RUOMOID", oDetails.MTDtls_RUOMOID);
                            cmd.Parameters.AddWithValue("@MTDtls_Status", oDetails.MTDtls_Status);

                            cmd.ExecuteNonQuery();

                            // populate inv list(decrease)
                            CInventory oInventory = new CInventory();

                            oInventory.Invt_Branch = oDetails.MTDtls_Branch;
                            oInventory.Invt_BranchOID = oDetails.MTDtls_SBranOID;
                            oInventory.Invt_InvType = oDetails.MTDtls_SrcInvTyp;
                            oInventory.Invt_ItemOID = oDetails.MTDtls_ItemOID;
                            oInventory.Invt_LocOID = oDetails.MTDtls_SrcLocOID;
                            oInventory.Invt_QTY = oDetails.MTDtls_IssQty;

                            oSrcInvtList.Add(oInventory);

                            // populate inv list(increase)
                            oInventory = new CInventory();

                            oInventory.Invt_Branch = oDetails.MTDtls_Branch;
                            oInventory.Invt_BranchOID = oDetails.MTDtls_DBranOID;
                            oInventory.Invt_InvType = oDetails.MTDtls_DesInvtyp;
                            oInventory.Invt_ItemOID = oDetails.MTDtls_ItemOID;
                            oInventory.Invt_LocOID = oDetails.MTDtls_DestLocOID;
                            oInventory.Invt_QTY = oDetails.MTDtls_IssQty;

                            oDesInvtList.Add(oInventory);
                        }

                        //Update inv

                        CInventoryBO oInventoryBO = new CInventoryBO();
                        oResult = oInventoryBO.InvtDecInc(oSrcInvtList, oDesInvtList);

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

            public CResult Update(CMTMaster oMTMaster, Dictionary<string, CMTDetails> oMTFinalQtyDic)
            {
                List<CInventory> oSrcInvtList = new List<CInventory>();
                List<CInventory> oDesInvtList = new List<CInventory>();
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    cmd.Transaction = oConnManager.BeginTransaction();
                    try
                    {
                        cmd.CommandText = "sp_MTMstr_Update";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MTMstr_OID", oMTMaster.MTMstr_OID);
                        cmd.Parameters.AddWithValue("@MTMstr_Branch", oMTMaster.MTMstr_Branch);
                        cmd.Parameters.AddWithValue("@MTMstr_Code", oMTMaster.MTMstr_Code);
                        cmd.Parameters.AddWithValue("@MTMstr_Date", oMTMaster.MTMstr_Date);
                        cmd.Parameters.AddWithValue("@MTMstr_DOrder", oMTMaster.MTMstr_DOrder);

                        cmd.Parameters.AddWithValue("@MTMstr_Creator", oMTMaster.Creator);
                        cmd.Parameters.AddWithValue("@MTMstr_CreationDate", oMTMaster.CreationDate);
                        cmd.Parameters.AddWithValue("@MTMstr_UpdatedBy", oMTMaster.UpdateBy);
                        cmd.Parameters.AddWithValue("@MTMstr_UpdateDate", oMTMaster.UpdateDate);
                        cmd.Parameters.AddWithValue("@MTMstr_IsActive", (oMTMaster.IsActive == "Y") ? 1 : 0);
                        cmd.Parameters.AddWithValue("@MTMstr_Remarks", oMTMaster.Remarks);

                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "Delete from t_MTDtls where MTDtls_MstrOID=@MTMstr_OID";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@MTMstr_OID", oMTMaster.MTMstr_OID);
                        cmd.ExecuteNonQuery();

                        foreach (CMTDetails oDetails in oMTMaster.MTMstr_DetailsList)
                        {
                            cmd.CommandText = "sp_MTDtls_Insert";
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@MTDtls_Branch", oDetails.MTDtls_Branch);
                            cmd.Parameters.AddWithValue("@MTDtls_OID", oDetails.MTDtls_OID);
                            cmd.Parameters.AddWithValue("@MTDtls_MstrOID", oMTMaster.MTMstr_OID);
                            cmd.Parameters.AddWithValue("@MTDtls_ItemOID", oDetails.MTDtls_ItemOID);
                            cmd.Parameters.AddWithValue("@MTDtls_IssQty", oDetails.MTDtls_IssQty);
                            cmd.Parameters.AddWithValue("@MTDtls_IssUOMOID", oDetails.MTDtls_IssUOMOID);
                            cmd.Parameters.AddWithValue("@MTDtls_SBranOID", oDetails.MTDtls_SBranOID);
                            cmd.Parameters.AddWithValue("@MTDtls_SrcLocOID", oDetails.MTDtls_SrcLocOID);
                            cmd.Parameters.AddWithValue("@MTDtls_SrcInvTyp", oDetails.MTDtls_SrcInvTyp);
                            cmd.Parameters.AddWithValue("@MTDtls_DBranOID", oDetails.MTDtls_DBranOID);
                            cmd.Parameters.AddWithValue("@MTDtls_DestLocOID", oDetails.MTDtls_DestLocOID);
                            cmd.Parameters.AddWithValue("@MTDtls_DesInvtyp", oDetails.MTDtls_DesInvtyp);
                            cmd.Parameters.AddWithValue("@MTDtls_RQty", oDetails.MTDtls_RQty);
                            cmd.Parameters.AddWithValue("@MTDtls_RUOMOID", oDetails.MTDtls_RUOMOID);
                            cmd.Parameters.AddWithValue("@MTDtls_Status", oDetails.MTDtls_Status);


                            cmd.ExecuteNonQuery();
                        }

                        foreach (CMTDetails oDetails in oMTFinalQtyDic.Values)
                        {
                            // populate inv list(decrease)
                            CInventory oInventory = new CInventory();

                            oInventory.Invt_Branch = oDetails.MTDtls_Branch;
                            oInventory.Invt_BranchOID = oDetails.MTDtls_SBranOID;
                            oInventory.Invt_InvType = oDetails.MTDtls_SrcInvTyp;
                            oInventory.Invt_ItemOID = oDetails.MTDtls_ItemOID;
                            oInventory.Invt_LocOID = oDetails.MTDtls_SrcLocOID;
                            oInventory.Invt_QTY = oDetails.MTDtls_IssQty;

                            oSrcInvtList.Add(oInventory);

                            // populate inv list(increase)
                            oInventory = new CInventory();

                            oInventory.Invt_Branch = oDetails.MTDtls_Branch;
                            oInventory.Invt_BranchOID = oDetails.MTDtls_DBranOID;
                            oInventory.Invt_InvType = oDetails.MTDtls_DesInvtyp;
                            oInventory.Invt_ItemOID = oDetails.MTDtls_ItemOID;
                            oInventory.Invt_LocOID = oDetails.MTDtls_DestLocOID;
                            oInventory.Invt_QTY = oDetails.MTDtls_IssQty;

                            oDesInvtList.Add(oInventory);
                        }


                        //Update inv

                        CInventoryBO oInventoryBO = new CInventoryBO();
                        oResult = oInventoryBO.InvtIncForMT(oSrcInvtList, oDesInvtList);

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

            public CResult Delete(string stMTMstr_OID)
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
                        cmd.CommandText = "DELETE FROM t_MTMstr WHERE MTMstr_OID=@MTMstr_OID;DELETE FROM t_MTDtls WHERE MTDtls_MstrOID=@MTMstr_OID";
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@MTMstr_OID", stMTMstr_OID);

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

            public CResult ReadAll(CCVB objCVB)
            {
                List<CCVB> oCVBList = new List<CCVB>();

                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "Select * from t_BVL ";
                        cmd.CommandType = CommandType.Text;


                        SqlDataReader oReader = cmd.ExecuteReader();

                        if (oReader.HasRows)
                        {
                            while (oReader.Read())
                            {
                                CCVB oCVB = new CCVB();
                                oCVB.OID = oReader["BVL_OID"].ToString();
                                oCVB.Branch = oReader["BVL_Branch"].ToString();
                                oCVB.Location = oReader["BVL_Location"].ToString();

                                oCVBList.Add(oCVB);
                            }
                            oReader.Close();
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oCVBList;
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


            public CResult ReadMTMasterByOID(string stOID)
            {
                CMTMaster oMTMaster = new CMTMaster();
                List<CMTDetails> oMTDetailsList = new List<CMTDetails>();

                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_MTMstr_ReadByOID";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MTMstr_OID", stOID);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);

                        DataTable dtDetails = ds.Tables[0] as DataTable;
                        DataTable dtMaster = ds.Tables[1] as DataTable;

                        oMTMaster = GetResultSetToMTMaster(dtMaster.Rows[0]);
                        foreach (DataRow dr in dtDetails.Rows)
                        {
                            oMTDetailsList.Add(GetResultSetToMTDtls(dr));
                        }
                        oMTMaster.MTMstr_DetailsList = oMTDetailsList;

                        oResult.IsSuccess = true;
                        oResult.Data = oMTMaster;
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

            public CResult ReadAllMTMaster(string stOID)
            {
                List<CMTDetails> oMTDetailsList = new List<CMTDetails>();
                List<CMTMaster> oMTMasterList = new List<CMTMaster>();

                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_MTMstr_ReadAll";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);

                        DataTable dtDetails = ds.Tables[0] as DataTable;
                        DataTable dtMaster = ds.Tables[1] as DataTable;

                        foreach (DataRow dr in dtDetails.Rows)
                        {
                            oMTDetailsList.Add(GetResultSetToMTDtls(dr));
                        }

                        foreach (DataRow dr in dtMaster.Rows)
                        {
                            CMTMaster oMTMaster = new CMTMaster();
                            oMTMaster = GetResultSetToMTMaster(dr);
                            foreach (CMTDetails oMTDetails in oMTDetailsList)
                            {
                                if (oMTDetails.MTDtls_MstrOID == oMTMaster.MTMstr_OID)
                                {
                                    oMTMaster.MTMstr_DetailsList.Add(oMTDetails);
                                }
                            }
                            oMTMasterList.Add(oMTMaster);
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oMTMasterList;
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

            public CResult ReadByIDDate(DateTime dtFrom, DateTime dtTo, string sID)
            {
                List<CMTDetails> oMTDetailsList = new List<CMTDetails>();
                List<CMTMaster> oMTMasterList = new List<CMTMaster>();
               
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
                        cmd.CommandText = "sp_MTMaster_ReadByIDDate";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();

                        if (sID == null)
                        {
                            cmd.Parameters.AddWithValue("@frmDate", dtFrom);
                            cmd.Parameters.AddWithValue("@toDate", dtTo);
                            cmd.Parameters.AddWithValue("@DOID", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@frmDate", dtFrom);
                            cmd.Parameters.AddWithValue("@toDate", dtTo);
                            cmd.Parameters.AddWithValue("@DOID", sID);
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
                                oMTDetailsList.Add(GetResultSetToMTDtls(dr));
                            }

                            foreach (DataRow dr in dtMaster.Rows)
                            {
                                CMTMaster oMTMaster = new CMTMaster();
                                oMTMaster = GetResultSetToMTMaster(dr);
                                foreach (CMTDetails oMTDetails in oMTDetailsList)
                                {
                                    if (oMTDetails.MTDtls_MstrOID == oMTMaster.MTMstr_OID)
                                    {
                                        oMTMaster.MTMstr_DetailsList.Add(oMTDetails);
                                    }
                                }
                                oMTMasterList.Add(oMTMaster);
                            }
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oMTMasterList;
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

            private CMTMaster GetResultSetToMTMaster(DataRow dr)
            {
                CMTMaster oMTMaster = new CMTMaster();

                oMTMaster.MTMstr_OID = dr["MTMstr_OID"].ToString();
                oMTMaster.MTMstr_Branch = dr["MTMstr_Branch"].ToString();
                oMTMaster.MTMstr_Code = dr["MTMstr_Code"].ToString();
                oMTMaster.MTMstr_Date = DateTime.Parse(dr["MTMstr_Date"].ToString()).Date;
                oMTMaster.MTMstr_DOrder = dr["MTMstr_DOrder"].ToString();
                oMTMaster.Creator = dr["MTMstr_Creator"].ToString();
                oMTMaster.CreationDate = DateTime.Parse(dr["MTMstr_CreationDate"].ToString()).Date;
                oMTMaster.UpdateBy = dr["MTMstr_UpdatedBy"].ToString();
                oMTMaster.UpdateDate = DateTime.Parse(dr["MTMstr_UpdateDate"].ToString()).Date;
                oMTMaster.IsActive = dr["MTMstr_IsActive"].ToString();
                oMTMaster.Remarks = dr["MTMstr_Remarks"].ToString();

                return oMTMaster;
            }

            private CMTDetails GetResultSetToMTDtls(DataRow dr)
            {
                CMTDetails oDetails = new CMTDetails();

                oDetails.MTDtls_OID = dr["MTDtls_OID"].ToString();
                oDetails.MTDtls_Branch = dr["MTDtls_Branch"].ToString();
                oDetails.MTDtls_MstrOID = dr["MTDtls_MstrOID"].ToString();
                oDetails.MTDtls_ItemOID = dr["MTDtls_ItemOID"].ToString();
                oDetails.MTDtls_IssQty = float.Parse(dr["MTDtls_IssQty"].ToString());
                oDetails.MTDtls_IssUOMOID = dr["MTDtls_IssUOMOID"].ToString();
                oDetails.MTDtls_SBranOID = dr["MTDtls_SBranOID"].ToString();
                oDetails.MTDtls_SrcLocOID = dr["MTDtls_SrcLocOID"].ToString();
                oDetails.MTDtls_SrcInvTyp = int.Parse( dr["MTDtls_SrcInvTyp"].ToString());
                oDetails.MTDtls_DBranOID = dr["MTDtls_DBranOID"].ToString();
                oDetails.MTDtls_DestLocOID = dr["MTDtls_DestLocOID"].ToString();
                oDetails.MTDtls_DesInvtyp = int.Parse(dr["MTDtls_DesInvtyp"].ToString());
                oDetails.MTDtls_RQty = float.Parse(dr["MTDtls_RQty"].ToString());
                oDetails.MTDtls_RUOMOID = dr["MTDtls_RUOMOID"].ToString();
                oDetails.MTDtls_Status = int.Parse(dr["MTDtls_Status"].ToString());

                return oDetails;
            }

            public CResult ReadAllMTForExportRpt(string stDelvNO)
            {
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_MT_ExpRpt";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MTMstr_DOrder",stDelvNO);

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
        }
    }
}
