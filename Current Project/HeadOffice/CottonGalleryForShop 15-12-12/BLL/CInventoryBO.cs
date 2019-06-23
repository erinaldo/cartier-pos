using System.Data;
using System.Collections.Generic;
using System.Collections;
using System.Data.SqlClient;

using ETL.Model;
using ETL.Common;
using ETL.DAO;

namespace ETL
{
    namespace BLL
    {
        public class CInventoryBO
        {

            #region "Member variables"

            private SqlConnection conn;
            private CResult oResult;
            private CConManager oConnManager;

            string s_DBError = "";

            #endregion

            #region "Costructor"

            public CInventoryBO()
            {
                oConnManager = new CConManager();
            }
            #endregion


            //public CResult Update(CInventory oInventory)
            //{
            //    oResult = new CResult();
            //    conn = oConnManager.GetConnection(out s_DBError);
            //    if (conn != null)
            //    {
            //        SqlCommand cmd = new SqlCommand();
            //        cmd.Connection = conn;
            //        cmd.Parameters.Clear();

            //        cmd.Transaction = oConnManager.BeginTransaction();
            //        try
            //        {
            //            cmd.CommandText = "sp_Inventory_Update";
            //            cmd.CommandType = CommandType.StoredProcedure;
                        
            //            cmd.Parameters.AddWithValue("@Invt_OID", oInventory.Invt_OID);
            //            cmd.Parameters.AddWithValue("@Invt_Branch", oInventory.Invt_Branch);
            //            cmd.Parameters.AddWithValue("@Invt_ItemOID", oInventory.Invt_ItemOID);
            //            cmd.Parameters.AddWithValue("@Invt_QTY", oInventory.Invt_QTY);
            //            cmd.Parameters.AddWithValue("@Invt_InvType", oInventory.Invt_InvType);
            //            cmd.Parameters.AddWithValue("@Invt_BranchOID", oInventory.Invt_BranchOID);
            //            cmd.Parameters.AddWithValue("@Invt_LocOID", oInventory.Invt_LocOID);
                        
            //            cmd.ExecuteNonQuery();
                        
            //            oConnManager.Commit();

            //            oResult.IsSuccess = true;
            //        }
            //        catch (SqlException e)
            //        {
            //            oResult.ErrMsg = e.Message;
            //            oResult.IsSuccess = false;
            //            string sRollbackError = oConnManager.Rollback();                        
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

            public CResult ReadQtyByCond(CInventory oInventory)
            {
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_Invt_ReadQtyByCond";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Invt_BranchOID", oInventory.Invt_BranchOID);
                        cmd.Parameters.AddWithValue("@Invt_LocOID", oInventory.Invt_LocOID);
                        cmd.Parameters.AddWithValue("@Invt_ItemOID", oInventory.Invt_ItemOID);
                        cmd.Parameters.AddWithValue("@Invt_InvType", oInventory.Invt_InvType);

                        SqlDataReader oReader = cmd.ExecuteReader();

                        if (oReader.HasRows)
                        {
                            while (oReader.Read())
                            {
                                oInventory.Invt_QTY = float.Parse(oReader["Invt_QTY"].ToString());
                            }
                            oReader.Close();
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oInventory;

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

            public CResult InvtIncExportBranch(List<CInventory> oInvList)
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
                        cmd.CommandText = "[sp_Invt_IncExportBranch]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach (CInventory oInventory in oInvList)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@Invt_OID", oInventory.Invt_OID);
                            cmd.Parameters.AddWithValue("@Invt_Branch", oInventory.Invt_Branch);
                            cmd.Parameters.AddWithValue("@Invt_ItemOID", oInventory.Invt_ItemOID);
                            cmd.Parameters.AddWithValue("@Invt_QTY", oInventory.Invt_QTY);
                            cmd.Parameters.AddWithValue("@Invt_InvType", oInventory.Invt_InvType);
                            cmd.Parameters.AddWithValue("@Invt_BranchOID", oInventory.Invt_BranchOID);
                            cmd.Parameters.AddWithValue("@Invt_LocOID", oInventory.Invt_LocOID);

                            cmd.ExecuteNonQuery();
                        }

                        oConnManager.Commit();
                        oResult.IsSuccess = true;
                    }
                    catch (SqlException e)
                    {
                        oResult.ErrMsg = e.Message;
                        oResult.IsSuccess = false;
                        string sRollbackError = oConnManager.Rollback();
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

            public CResult InvtInc(List<CInventory> oInvList)
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
                        cmd.CommandText = "sp_Invt_Inc";
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach (CInventory oInventory in oInvList)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@Invt_OID", oInventory.Invt_OID);
                            cmd.Parameters.AddWithValue("@Invt_Branch", oInventory.Invt_Branch);
                            cmd.Parameters.AddWithValue("@Invt_ItemOID", oInventory.Invt_ItemOID);
                            cmd.Parameters.AddWithValue("@Invt_QTY", oInventory.Invt_QTY);
                            cmd.Parameters.AddWithValue("@Invt_InvType", oInventory.Invt_InvType);
                            cmd.Parameters.AddWithValue("@Invt_BranchOID", oInventory.Invt_BranchOID);
                            cmd.Parameters.AddWithValue("@Invt_LocOID", oInventory.Invt_LocOID);

                            cmd.ExecuteNonQuery();
                        }
                        
                        oConnManager.Commit();
                        oResult.IsSuccess = true;
                    }
                    catch (SqlException e)
                    {
                        oResult.ErrMsg = e.Message;
                        oResult.IsSuccess = false;
                        string sRollbackError = oConnManager.Rollback();
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

            public CResult ReturnProductCreate(List<ReturnProduct> oInvList,float DisAmt)
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
                        cmd.CommandText = "sp_ReturnProduct_Insert";
                        cmd.CommandType = CommandType.StoredProcedure;
                        

                        foreach (ReturnProduct oReturnProduct in oInvList)
                        {
                            cmd.Parameters.Clear();
                            //cmd.Parameters.AddWithValue("@Ret_OID", oInventory.Ret_OID);
                            cmd.Parameters.AddWithValue("@Ret_Branch", oReturnProduct.Ret_Branch);
                            cmd.Parameters.AddWithValue("@Ret_ItemOID", oReturnProduct.Ret_ItemOID);
                            cmd.Parameters.AddWithValue("@Ret_QTY", oReturnProduct.Ret_QTY);
                            cmd.Parameters.AddWithValue("@Ret_Type", oReturnProduct.Ret_InvType);
                            cmd.Parameters.AddWithValue("@Ret_BranchOID", oReturnProduct.Ret_BranchOID);
                            cmd.Parameters.AddWithValue("@Ret_LocOID", oReturnProduct.Ret_LocOID);
                            

                            
                        }
                        cmd.Parameters.AddWithValue("@Ret_DiscountAmount", DisAmt);
                        cmd.ExecuteNonQuery();
                        oConnManager.Commit();
                        oResult.IsSuccess = true;

                        oConnManager.Commit();
                        oResult.IsSuccess = true;
                    }
                    catch (SqlException e)
                    {
                        oResult.ErrMsg = e.Message;
                        oResult.IsSuccess = false;
                        string sRollbackError = oConnManager.Rollback();
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

            public CResult InvtDec(List<CInventory> oInvList)
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
                        cmd.CommandText = "sp_Invt_Dec";
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach (CInventory oInventory in oInvList)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@Invt_OID", oInventory.Invt_OID);
                            cmd.Parameters.AddWithValue("@Invt_Branch", oInventory.Invt_Branch);
                            cmd.Parameters.AddWithValue("@Invt_ItemOID", oInventory.Invt_ItemOID);
                            cmd.Parameters.AddWithValue("@Invt_QTY", oInventory.Invt_QTY);
                            cmd.Parameters.AddWithValue("@Invt_InvType", oInventory.Invt_InvType);
                            cmd.Parameters.AddWithValue("@Invt_BranchOID", oInventory.Invt_BranchOID);
                            cmd.Parameters.AddWithValue("@Invt_LocOID", oInventory.Invt_LocOID);

                            cmd.ExecuteNonQuery();
                        }

                        oConnManager.Commit();
                        oResult.IsSuccess = true;
                    }
                    catch (SqlException e)
                    {
                        oResult.ErrMsg = e.Message;
                        oResult.IsSuccess = false;
                        string sRollbackError = oConnManager.Rollback();
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

            public CResult Update(CInventory oInventory)
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
                        cmd.CommandText = "sp_Inventory_Update";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Invt_OID", oInventory.Invt_OID);
                        cmd.Parameters.AddWithValue("@Invt_Branch", oInventory.Invt_Branch);
                        cmd.Parameters.AddWithValue("@Invt_ItemOID", oInventory.Invt_ItemOID);
                        cmd.Parameters.AddWithValue("@Invt_QTY", oInventory.Invt_QTY);
                        cmd.Parameters.AddWithValue("@Invt_InvType", oInventory.Invt_InvType);
                        cmd.Parameters.AddWithValue("@Invt_BranchOID", oInventory.Invt_BranchOID);
                        cmd.Parameters.AddWithValue("@Invt_LocOID", oInventory.Invt_LocOID);

                        cmd.ExecuteNonQuery();

                        oConnManager.Commit();

                        oResult.IsSuccess = true;
                    }
                    catch (SqlException e)
                    {
                        oResult.ErrMsg = e.Message;
                        oResult.IsSuccess = false;
                        string sRollbackError = oConnManager.Rollback();
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


        public CResult InvtDecInc(List<CInventory> oSrcInvtList,List<CInventory> oDesInvtList)
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
                        cmd.CommandText = "sp_Invt_Dec";
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach (CInventory oInventory in oSrcInvtList)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@Invt_OID", oInventory.Invt_OID);
                            cmd.Parameters.AddWithValue("@Invt_Branch", oInventory.Invt_Branch);
                            cmd.Parameters.AddWithValue("@Invt_ItemOID", oInventory.Invt_ItemOID);
                            cmd.Parameters.AddWithValue("@Invt_QTY", oInventory.Invt_QTY);
                            cmd.Parameters.AddWithValue("@Invt_InvType", oInventory.Invt_InvType);
                            cmd.Parameters.AddWithValue("@Invt_BranchOID", oInventory.Invt_BranchOID);
                            cmd.Parameters.AddWithValue("@Invt_LocOID", oInventory.Invt_LocOID);

                            cmd.ExecuteNonQuery();
                        }

                        cmd.CommandText = "sp_Invt_Inc";
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach (CInventory oInventory in oDesInvtList)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@Invt_OID", oInventory.Invt_OID);
                            cmd.Parameters.AddWithValue("@Invt_Branch", oInventory.Invt_Branch);
                            cmd.Parameters.AddWithValue("@Invt_ItemOID", oInventory.Invt_ItemOID);
                            cmd.Parameters.AddWithValue("@Invt_QTY", oInventory.Invt_QTY);
                            cmd.Parameters.AddWithValue("@Invt_InvType", oInventory.Invt_InvType);
                            cmd.Parameters.AddWithValue("@Invt_BranchOID", oInventory.Invt_BranchOID);
                            cmd.Parameters.AddWithValue("@Invt_LocOID", oInventory.Invt_LocOID);

                            cmd.ExecuteNonQuery();
                        }

                        oConnManager.Commit();
                        oResult.IsSuccess = true;
                    }
                    catch (SqlException e)
                    {
                        oResult.ErrMsg = e.Message;
                        oResult.IsSuccess = false;
                        string sRollbackError = oConnManager.Rollback();
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

        public CResult InvtIncForMT(List<CInventory> oSrcInvtList, List<CInventory> oDesInvtList)
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
                    cmd.CommandText = "sp_Invt_Dec";
                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach (CInventory oInventory in oSrcInvtList)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Invt_OID", oInventory.Invt_OID);
                        cmd.Parameters.AddWithValue("@Invt_Branch", oInventory.Invt_Branch);
                        cmd.Parameters.AddWithValue("@Invt_ItemOID", oInventory.Invt_ItemOID);
                        cmd.Parameters.AddWithValue("@Invt_QTY", oInventory.Invt_QTY);
                        cmd.Parameters.AddWithValue("@Invt_InvType", oInventory.Invt_InvType);
                        cmd.Parameters.AddWithValue("@Invt_BranchOID", oInventory.Invt_BranchOID);
                        cmd.Parameters.AddWithValue("@Invt_LocOID", oInventory.Invt_LocOID);

                        cmd.ExecuteNonQuery();
                    }

                    cmd.CommandText = "sp_Invt_Inc";
                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach (CInventory oInventory in oDesInvtList)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Invt_OID", oInventory.Invt_OID);
                        cmd.Parameters.AddWithValue("@Invt_Branch", oInventory.Invt_Branch);
                        cmd.Parameters.AddWithValue("@Invt_ItemOID", oInventory.Invt_ItemOID);
                        cmd.Parameters.AddWithValue("@Invt_QTY", oInventory.Invt_QTY);
                        cmd.Parameters.AddWithValue("@Invt_InvType", oInventory.Invt_InvType);
                        cmd.Parameters.AddWithValue("@Invt_BranchOID", oInventory.Invt_BranchOID);
                        cmd.Parameters.AddWithValue("@Invt_LocOID", oInventory.Invt_LocOID);

                        cmd.ExecuteNonQuery();
                    }

                    oConnManager.Commit();
                    oResult.IsSuccess = true;
                }
                catch (SqlException e)
                {
                    oResult.ErrMsg = e.Message;
                    oResult.IsSuccess = false;
                    string sRollbackError = oConnManager.Rollback();
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

        public CResult ReadForROL(CInventory oInventory)
        {
            ArrayList oInventoryList = new ArrayList();
            oResult = new CResult();
            conn = oConnManager.GetConnection(out s_DBError);
            if (conn != null)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = conn;
                    cmd.CommandText = "sp_Invt_ReadForROL";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Invt_BranchOID", oInventory.Invt_BranchOID);
                    cmd.Parameters.AddWithValue("@Invt_LocOID", oInventory.Invt_LocOID);
                    cmd.Parameters.AddWithValue("@Invt_ItemOID", oInventory.Invt_ItemOID);

                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];

                    foreach (DataRow dr in dt.Rows)
                    {
                        oInventoryList.Add(GetresultoInventory(dr));

                    }

                    //SqlDataReader oReader = cmd.ExecuteReader();

                    //if (oReader.HasRows)
                    //{
                    //    while (oReader.Read())
                    //    {
                    //        oInventory.Invt_QTY = float.Parse(oReader["Invt_QTY"].ToString());
                    //    }
                    //    oReader.Close();
                    //}

                    oResult.IsSuccess = true;
                    oResult.Data = oInventoryList;

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

        private CInventory GetresultoInventory(DataRow dr)
        {
            CInventory oInventory = new CInventory();
            oInventory.Invt_OID = dr[0].ToString();
            oInventory.Invt_Branch = dr[1].ToString();
            oInventory.Invt_ItemOID = dr[2].ToString();
            oInventory.Invt_QTY = float.Parse(dr[3].ToString());
            oInventory.Invt_InvType = int.Parse(dr[4].ToString());
            oInventory.Invt_BranchOID = dr[5].ToString();
            oInventory.Invt_LocOID = dr[6].ToString();
            oInventory.Invt_ItemName = dr[7].ToString();

            return oInventory;
        }






        public CResult InvtDecInt(List<CInventory> oInvtList1)
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
                    cmd.CommandText = "sp_Invt_DecInventoryDec";
                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach (CInventory oInventory in oInvtList1)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Invt_OID", oInventory.Invt_OID);
                        cmd.Parameters.AddWithValue("@Invt_Branch", oInventory.Invt_Branch);
                        cmd.Parameters.AddWithValue("@Invt_ItemOID", oInventory.Invt_ItemOID);
                        cmd.Parameters.AddWithValue("@Invt_QTY", oInventory.Invt_QTY);
                        cmd.Parameters.AddWithValue("@Invt_InvType", oInventory.Invt_InvType);
                        cmd.Parameters.AddWithValue("@Invt_BranchOID", oInventory.Invt_BranchOID);
                        cmd.Parameters.AddWithValue("@Invt_LocOID", oInventory.Invt_LocOID);

                        cmd.ExecuteNonQuery();
                    }

                    oConnManager.Commit();
                    oResult.IsSuccess = true;
                }
                catch (SqlException e)
                {
                    oResult.ErrMsg = e.Message;
                    oResult.IsSuccess = false;
                    string sRollbackError = oConnManager.Rollback();
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
