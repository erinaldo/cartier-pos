using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

using ETL.Model;
using ETL.Common;
using ETL.DAO;

namespace ETL
{
    namespace BLL
    {
        public class CSupplierBO
        {
            #region "Member variables"

            private SqlConnection conn;
            private CResult oResult;
            private CConManager oConnManager;

            string s_DBError = "";

            #endregion

            #region "Costructor"

            public CSupplierBO()
            {
                oConnManager = new CConManager();
            }
            #endregion

            public CResult Create(CSupplier oCS)
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
                        cmd.CommandText = "sp_Cust_Insert";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        //
                        cmd.Parameters.AddWithValue("@Cust_OId", oCS.Cust_OId);
                        cmd.Parameters.AddWithValue("@Cust_Branch", oCS.Cust_Branch);
                        cmd.Parameters.AddWithValue("@Cust_Id", oCS.Cust_Id);
                        cmd.Parameters.AddWithValue("@Cust_Name", oCS.Cust_Name);
                        cmd.Parameters.AddWithValue("@Cust_CSType", oCS.Cust_CSType);
                        cmd.Parameters.AddWithValue("@Cust_ContactP", oCS.Cust_ContactP);
                        cmd.Parameters.AddWithValue("@Cust_Address", oCS.Cust_Address);
                        cmd.Parameters.AddWithValue("@Cust_Cell", oCS.Cust_Cell);
                        cmd.Parameters.AddWithValue("@Cust_Phone", oCS.Cust_Phone);
                        cmd.Parameters.AddWithValue("@Cust_Email", oCS.Cust_Email);
                        cmd.Parameters.AddWithValue("@Cust_Fax", oCS.Cust_Fax);
                        cmd.Parameters.AddWithValue("@Cust_Web", oCS.Cust_Web);
                        cmd.Parameters.AddWithValue("@Cust_IsActive", oCS.Cust_IsActive);
                        cmd.Parameters.AddWithValue("@Cust_DiscRate", oCS.Cust_DiscRate);

                        cmd.Parameters.AddWithValue("@Cust_Creator", oCS.Creator);
                        cmd.Parameters.AddWithValue("@Cust_CreationDate", oCS.CreationDate);
                        cmd.Parameters.AddWithValue("@Cust_UpdateBy", oCS.UpdateBy);
                        cmd.Parameters.AddWithValue("@Cust_UpdateDate", oCS.UpdateDate);
                        
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

            public CResult Update(CSupplier oCS)
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
                        cmd.CommandText = "sp_Cust_Update";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        //
                        cmd.Parameters.AddWithValue("@Cust_OId", oCS.Cust_OId);
                        cmd.Parameters.AddWithValue("@Cust_Branch", oCS.Cust_Branch);
                        cmd.Parameters.AddWithValue("@Cust_Id", oCS.Cust_Id);
                        cmd.Parameters.AddWithValue("@Cust_Name", oCS.Cust_Name);
                        cmd.Parameters.AddWithValue("@Cust_CSType", oCS.Cust_CSType);
                        cmd.Parameters.AddWithValue("@Cust_ContactP", oCS.Cust_ContactP);
                        cmd.Parameters.AddWithValue("@Cust_Address", oCS.Cust_Address);
                        cmd.Parameters.AddWithValue("@Cust_Cell", oCS.Cust_Cell);
                        cmd.Parameters.AddWithValue("@Cust_Phone", oCS.Cust_Phone);
                        cmd.Parameters.AddWithValue("@Cust_Email", oCS.Cust_Email);
                        cmd.Parameters.AddWithValue("@Cust_Fax", oCS.Cust_Fax);
                        cmd.Parameters.AddWithValue("@Cust_Web", oCS.Cust_Web);
                        cmd.Parameters.AddWithValue("@Cust_IsActive", oCS.Cust_IsActive);
                        cmd.Parameters.AddWithValue("@Cust_DiscRate", oCS.Cust_DiscRate);

                        cmd.Parameters.AddWithValue("@Cust_Creator", oCS.Creator);
                        cmd.Parameters.AddWithValue("@Cust_CreationDate", oCS.CreationDate);
                        cmd.Parameters.AddWithValue("@Cust_UpdateBy", oCS.UpdateBy);
                        cmd.Parameters.AddWithValue("@Cust_UpdateDate", oCS.UpdateDate);

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

            public CResult Delete(string sCust_OId)
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
                        cmd.CommandText = "sp_Cust_Delete";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        //
                        cmd.Parameters.AddWithValue("@Cust_OId", sCust_OId);
                        //cmd.Parameters.AddWithValue("@Cust_Branch", oCS.Cust_Branch);
                        //cmd.Parameters.AddWithValue("@Cust_Id", oCS.Cust_Id);
                        //cmd.Parameters.AddWithValue("@Cust_Name", Name);
                        //cmd.Parameters.AddWithValue("@Cust_CSType", oCS.Cust_CSType);
                        //cmd.Parameters.AddWithValue("@Cust_ContactP", oCS.Cust_ContactP);
                        //cmd.Parameters.AddWithValue("@Cust_Address", oCS.Cust_Address);
                        //cmd.Parameters.AddWithValue("@Cust_Cell", oCS.Cust_Cell);
                        //cmd.Parameters.AddWithValue("@Cust_Phone", oCS.Cust_Phone);
                        //cmd.Parameters.AddWithValue("@Cust_Email", oCS.Cust_Email);
                        //cmd.Parameters.AddWithValue("@Cust_Fax", oCS.Cust_Fax);
                        //cmd.Parameters.AddWithValue("@Cust_Web", oCS.Cust_Web);
                        //cmd.Parameters.AddWithValue("@Cust_IsActive", oCS.Cust_IsActive);
                        //cmd.Parameters.AddWithValue("@Cust_DiscRate", oCS.Cust_DiscRate);

                        //cmd.Parameters.AddWithValue("@Cust_Creator", oCS.Creator);
                        //cmd.Parameters.AddWithValue("@Cust_CreationDate", oCS.CreationDate);
                        //cmd.Parameters.AddWithValue("@Cust_UpdateBy", oCS.UpdateBy);
                        //cmd.Parameters.AddWithValue("@Cust_UpdateDate", oCS.UpdateDate);

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

            public CResult ReadAll(CSupplier oCS)
            {
                ArrayList oCSList = new ArrayList();
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_Cust_ReadAll";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Cust_CSType", oCS.Cust_CSType);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);

                        DataTable dt = ds.Tables[0];
                        foreach (DataRow dr in dt.Rows)
                        {
                            oCSList.Add(GetResultSetToCS(dr));
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oCSList;

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

            public CResult ReadAllByType(ECSType eCSType)
            {
                ArrayList oCSList = new ArrayList();
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_Cust_ReadAllByType";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CSType", ((int)eCSType).ToString());
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);

                        DataTable dt = ds.Tables[0];
                        foreach (DataRow dr in dt.Rows)
                        {
                            oCSList.Add(GetResultSetToCS(dr));
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oCSList;

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

            public CResult ReadByID(CSupplier oCS)
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
                        cmd.CommandText = "sp_Cust_ReadByID";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Cust_Id", oCS.Cust_Id);
                        cmd.Parameters.AddWithValue("@Cust_CSType", oCS.Cust_CSType);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);

                        DataTable dt = ds.Tables[0];
                        foreach (DataRow dr in dt.Rows)
                        {
                            oCS = GetResultSetToCS(dr);
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oCS;

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

            public CSupplier GetResultSetToCS(DataRow dr)
            {
                CSupplier oCS = new CSupplier();
            
                oCS.Cust_OId = CUtils.GetDBValue(dr, 0, "-1").ToString();
                oCS.Cust_Branch = CUtils.GetDBValue(dr, 1, string.Empty).ToString();
                oCS.Cust_Id = CUtils.RestoreAPS(CUtils.GetDBValue(dr, 2, string.Empty).ToString());
                oCS.Cust_Name = CUtils.RestoreAPS(CUtils.GetDBValue(dr, 3, string.Empty).ToString());
                oCS.Cust_CSType = (ECSType)Enum.Parse(typeof(ECSType), CUtils.GetDBValue(dr, 4, string.Empty).ToString());
                oCS.Cust_ContactP = CUtils.RestoreAPS(CUtils.GetDBValue(dr, 5, string.Empty).ToString());
                oCS.Cust_Address = CUtils.RestoreAPS(CUtils.GetDBValue(dr, 6, string.Empty).ToString());
                oCS.Cust_Cell = CUtils.RestoreAPS(CUtils.GetDBValue(dr, 7, string.Empty).ToString());
                oCS.Cust_Phone = CUtils.RestoreAPS(CUtils.GetDBValue(dr, 8, string.Empty).ToString());
                oCS.Cust_Email = CUtils.RestoreAPS(CUtils.GetDBValue(dr, 9, string.Empty).ToString());
                oCS.Cust_Fax = CUtils.RestoreAPS(CUtils.GetDBValue(dr, 10, string.Empty).ToString());
                oCS.Cust_Web = CUtils.RestoreAPS(CUtils.GetDBValue(dr, 11, string.Empty).ToString());
                oCS.Cust_IsActive = CUtils.RestoreAPS(CUtils.GetDBValue(dr, 12, "N").ToString());
                oCS.Cust_DiscRate = float.Parse(CUtils.GetDBValue(dr, 13, float.MinValue.ToString()).ToString());
                
                oCS.Creator = CUtils.RestoreAPS(CUtils.GetDBValue(dr, 14, string.Empty).ToString());
                oCS.CreationDate= DateTime.Parse(CUtils.GetDBValue(dr, 15, "12/12/2007").ToString());
                oCS.UpdateBy = CUtils.RestoreAPS(CUtils.GetDBValue(dr, 16, string.Empty).ToString());
                oCS.UpdateDate = DateTime.Parse(CUtils.GetDBValue(dr, 17, "12/12/2007").ToString());

                return oCS;
            }

            public CResult Import(CSupplier oCS)
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
                        cmd.CommandText = "sp_Cust_Import";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        //
                        cmd.Parameters.AddWithValue("@Cust_OId", oCS.Cust_OId);
                        cmd.Parameters.AddWithValue("@Cust_Branch", oCS.Cust_Branch);
                        cmd.Parameters.AddWithValue("@Cust_Id", oCS.Cust_Id);
                        cmd.Parameters.AddWithValue("@Cust_Name", oCS.Cust_Name);
                        cmd.Parameters.AddWithValue("@Cust_CSType", oCS.Cust_CSType);
                        cmd.Parameters.AddWithValue("@Cust_ContactP", oCS.Cust_ContactP);
                        cmd.Parameters.AddWithValue("@Cust_Address", oCS.Cust_Address);
                        cmd.Parameters.AddWithValue("@Cust_Cell", oCS.Cust_Cell);
                        cmd.Parameters.AddWithValue("@Cust_Phone", oCS.Cust_Phone);
                        cmd.Parameters.AddWithValue("@Cust_Email", oCS.Cust_Email);
                        cmd.Parameters.AddWithValue("@Cust_Fax", oCS.Cust_Fax);
                        cmd.Parameters.AddWithValue("@Cust_Web", oCS.Cust_Web);
                        cmd.Parameters.AddWithValue("@Cust_IsActive", oCS.Cust_IsActive);
                        cmd.Parameters.AddWithValue("@Cust_DiscRate", oCS.Cust_DiscRate);

                        cmd.Parameters.AddWithValue("@Cust_Creator", oCS.Creator);
                        cmd.Parameters.AddWithValue("@Cust_CreationDate", oCS.CreationDate);
                        cmd.Parameters.AddWithValue("@Cust_UpdateBy", oCS.UpdateBy);
                        cmd.Parameters.AddWithValue("@Cust_UpdateDate", oCS.UpdateDate);

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
        }
    }
}
