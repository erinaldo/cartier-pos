using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

using ETL.Model;
using ETL.Common;
using ETL.DAO;


namespace ETL
{
    namespace BLL
    {
        public class CPriceMasterBO
        {
            #region "Member variables"

            private SqlConnection conn;
            private CResult oResult;
            private CConManager oConnManager;

            string s_DBError = "";

            #endregion

            #region "Costructor"

            public CPriceMasterBO()
            {
                oConnManager = new CConManager();
            }
            #endregion

            #region "Price Master"


            public CResult Create(CPriceMaster oPM)
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
                        cmd.CommandText = "sp_Price_Insert";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        //
                        cmd.Parameters.AddWithValue("@Price_OId", oPM.Price_OId);
                        cmd.Parameters.AddWithValue("@Price_Branch", oPM.Price_Branch);
                        cmd.Parameters.AddWithValue("@Price_ItemOId", oPM.Price_ItemOId);
                        cmd.Parameters.AddWithValue("@Price_FromDate", oPM.Price_FromDate);
                        cmd.Parameters.AddWithValue("@Price_ToDate", oPM.Price_ToDate);
                        cmd.Parameters.AddWithValue("@Price_Currency", oPM.Price_Currency);
                        cmd.Parameters.AddWithValue("@Price_FactoryPrice", oPM.Price_FactoryPrice);
                        cmd.Parameters.AddWithValue("@Price_ListPrice", oPM.Price_ListPrice);
                        cmd.Parameters.AddWithValue("@Price_VatPercent", oPM.Price_VatPercent);
                        cmd.Parameters.AddWithValue("@Price_VatPrice", oPM.Price_VatPrice);
                         cmd.Parameters.AddWithValue("@Price_Disc", oPM.Price_Disc);
                         cmd.Parameters.AddWithValue("@Price_DiscPrice", oPM.Price_DiscPrice);

                        cmd.Parameters.AddWithValue("@Price_Creator", oPM.Creator);
                        cmd.Parameters.AddWithValue("@Price_CreationDate", oPM.CreationDate);
                        cmd.Parameters.AddWithValue("@Price_UpdateBy", oPM.UpdateBy);
                        cmd.Parameters.AddWithValue("@Price_UpdateDate", oPM.UpdateDate);

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

            private CPriceMaster GetResultSetToPM(DataRow dr)
            {
                CPriceMaster oPM = new CPriceMaster();

                oPM.Price_OId = dr["Price_OId"].ToString();
                oPM.Price_Branch = dr["Price_Branch"].ToString();
                oPM.Price_ItemOId = dr["Price_ItemOId"].ToString();
                oPM.Price_FromDate = DateTime.Parse(dr["Price_FromDate"].ToString());
                oPM.Price_ToDate = DateTime.Parse(dr["Price_ToDate"].ToString());
                
                oPM.Price_Currency = dr["Price_Currency"].ToString();
                oPM.Price_FactoryPrice = float.Parse(dr["Price_FactoryPrice"].ToString());
                oPM.Price_ListPrice = float.Parse(dr["Price_ListPrice"].ToString());
                oPM.Price_VatPercent = float.Parse(dr["Price_VatPercent"].ToString());

                oPM.Price_VatPrice = float.Parse(dr["Price_VatPrice"].ToString());
                oPM.Price_Disc = float.Parse(dr["Price_Disc"].ToString());
                oPM.Price_DiscPrice = float.Parse(dr["Price_DiscPrice"].ToString());
                oPM.Creator = dr["Price_Creator"].ToString();
                oPM.CreationDate = DateTime.Parse(dr["Price_CreationDate"].ToString());
                oPM.UpdateBy = dr["Price_UpdateBy"].ToString();
                oPM.UpdateDate = DateTime.Parse(dr["Price_UpdateDate"].ToString());
                
                return oPM;
            }

            public CResult ReadAll()
            {
                ArrayList oPMList = new ArrayList();
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_Price_ReadAllData";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dt = ds.Tables[0];

                        foreach (DataRow dr in dt.Rows)
                        {
                            oPMList.Add(GetResultSetToPM(dr));
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oPMList;

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

            public CResult ReadAll(string stItemOID)
            {
                ArrayList oPMList = new ArrayList();
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_Price_ReadAll";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ItemOID", stItemOID);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dt = ds.Tables[0];

                        ////////foreach (DataRow dr in dt.Rows)
                        ////////{
                        ////////    oPMList.Add(GetResultSetToPM(dr));
                        ////////}

                        oResult.IsSuccess = true;
                        oResult.Data = dt;

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

            public CResult Import(CPriceMaster oPM)
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
                        cmd.CommandText = "sp_Price_Import";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        //
                        cmd.Parameters.AddWithValue("@Price_OId", oPM.Price_OId);
                        cmd.Parameters.AddWithValue("@Price_Branch", oPM.Price_Branch);
                        cmd.Parameters.AddWithValue("@Price_ItemOId", oPM.Price_ItemOId);
                        cmd.Parameters.AddWithValue("@Price_FromDate", oPM.Price_FromDate);
                        cmd.Parameters.AddWithValue("@Price_ToDate", oPM.Price_ToDate);
                        cmd.Parameters.AddWithValue("@Price_Currency", oPM.Price_Currency);
                        cmd.Parameters.AddWithValue("@Price_FactoryPrice", oPM.Price_FactoryPrice);
                        cmd.Parameters.AddWithValue("@Price_ListPrice", oPM.Price_ListPrice);
                        cmd.Parameters.AddWithValue("@Price_VatPercent", oPM.Price_VatPercent);
                        cmd.Parameters.AddWithValue("@Price_VatPrice", oPM.Price_VatPrice);
                        cmd.Parameters.AddWithValue("@Price_Disc", oPM.Price_Disc);
                        cmd.Parameters.AddWithValue("@Price_DiscPrice", oPM.Price_DiscPrice);

                        cmd.Parameters.AddWithValue("@Price_Creator", oPM.Creator);
                        cmd.Parameters.AddWithValue("@Price_CreationDate", oPM.CreationDate);
                        cmd.Parameters.AddWithValue("@Price_UpdateBy", oPM.UpdateBy);
                        cmd.Parameters.AddWithValue("@Price_UpdateDate", oPM.UpdateDate);

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

            public CResult ReadAllForAlert()
            {
                ArrayList oPMList = new ArrayList();
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_Price_ReadAllForAlert";
                        cmd.CommandType = CommandType.StoredProcedure;
                        // cmd.Parameters.AddWithValue("@ItemOID", stItemOID);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dt = ds.Tables[0];

                        ////////foreach (DataRow dr in dt.Rows)
                        ////////{
                        ////////    oPMList.Add(GetResultSetToPM(dr));
                        ////////}

                        oResult.IsSuccess = true;
                        oResult.Data = dt;

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


            #endregion
        }
    }
}
