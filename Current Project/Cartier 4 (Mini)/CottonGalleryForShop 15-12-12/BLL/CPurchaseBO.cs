using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ETL.Common;
using ETL.DAO;
using Model;
using System.Data;
using System.Collections;

namespace BLL
{
    public class CPurchaseBO
    {
        #region"Private Variable"

        private SqlConnection conn;
        private CResult oResult;
        private CConManager oConnManager;
        string s_DBError = "";

        #endregion

        #region"Constructor"
        public CPurchaseBO()
        {
            oConnManager = new CConManager();
        }
        #endregion


        #region"Methode"

        public CResult Create(CPurchase oPurchase)
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
                    cmd.CommandText = "sp_Purchase_Insert";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Purchase_Branch", oPurchase.Purchase_Branch);
                    cmd.Parameters.AddWithValue("@Purchase_PartyOID", oPurchase.Purchase_PartyOID);
                    cmd.Parameters.AddWithValue("@Purchase_GroupID", oPurchase.Purchase_GroupID);
                    cmd.Parameters.AddWithValue("@Purchase_Description", oPurchase.Purchase_Description);
                    cmd.Parameters.AddWithValue("@Purchase_Quantity", oPurchase.Purchase_Quantity);
                    cmd.Parameters.AddWithValue("@Purchase_Amount", oPurchase.Purchase_Amount);
                    cmd.Parameters.AddWithValue("@Purchase_CurrencyOID", oPurchase.Purchase_CurrencyOID);
                    cmd.Parameters.AddWithValue("@Purchase_CurrencyRate", oPurchase.Purchase_CurrencyRate);
                    cmd.Parameters.AddWithValue("@Purchase_Invoice", oPurchase.Purchase_Invoice);
                    cmd.Parameters.AddWithValue("@Purchase_Date", oPurchase.Purchase_Date);
                    cmd.Parameters.AddWithValue("@Purchase_Status", oPurchase.Purchase_Status);
                    cmd.Parameters.AddWithValue("@Purchase_Creator", oPurchase.Purchase_Creator);
                    cmd.Parameters.AddWithValue("@Purchase_CreationDate", oPurchase.Purchase_CreationDate);
                    cmd.Parameters.AddWithValue("@Purchase_UpdateBy", oPurchase.Purchase_UpdateBy);
                    cmd.Parameters.AddWithValue("@Purchase_UpdateDate", oPurchase.Purchase_UpdateDate);
                    
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

        public CResult Update(CPurchase oPurchase)
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
                    cmd.CommandText = "sp_Purchase_Update";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Purchase_OID", oPurchase.Purchase_OID);
                    cmd.Parameters.AddWithValue("@Purchase_Branch", oPurchase.Purchase_Branch);
                    cmd.Parameters.AddWithValue("@Purchase_PartyOID", oPurchase.Purchase_PartyOID);
                    cmd.Parameters.AddWithValue("@Purchase_GroupID", oPurchase.Purchase_GroupID);
                    cmd.Parameters.AddWithValue("@Purchase_Description", oPurchase.Purchase_Description);
                    cmd.Parameters.AddWithValue("@Purchase_Quantity", oPurchase.Purchase_Quantity);
                    cmd.Parameters.AddWithValue("@Purchase_Amount", oPurchase.Purchase_Amount);
                    cmd.Parameters.AddWithValue("@Purchase_CurrencyOID", oPurchase.Purchase_CurrencyOID);
                    cmd.Parameters.AddWithValue("@Purchase_CurrencyRate", oPurchase.Purchase_CurrencyRate);
                    cmd.Parameters.AddWithValue("@Purchase_Invoice", oPurchase.Purchase_Invoice);
                    cmd.Parameters.AddWithValue("@Purchase_Date", oPurchase.Purchase_Date);
                    cmd.Parameters.AddWithValue("@Purchase_Status", oPurchase.Purchase_Status);
                    cmd.Parameters.AddWithValue("@Purchase_UpdateBy", oPurchase.Purchase_UpdateBy);
                    cmd.Parameters.AddWithValue("@Purchase_UpdateDate", oPurchase.Purchase_UpdateDate);

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
        public CResult Delete(CPurchase oPurchase)
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
                    cmd.CommandText = "sp_Purchase_Delete";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Purchase_OID", oPurchase.Purchase_OID);
                    cmd.Parameters.Add("@IsSuccess", SqlDbType.Char, 1);
                    cmd.Parameters["@IsSuccess"].Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    string st = cmd.Parameters["@IsSuccess"].Value.ToString();

                    oConnManager.Commit();
                    oResult.Data = st;
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


        public CResult ReadAll()
        {
            ArrayList oPartyList = new ArrayList();
            oResult = new CResult();
            conn = oConnManager.GetConnection(out s_DBError);
            if (conn != null)
            {
                try
                {
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = conn;
                    cmd.CommandText = "sp_Purchase_ReadAll";

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];

                    foreach (DataRow dr in dt.Rows)
                    {
                        oPartyList.Add(GetResultSetToParty(dr));
                    }

                    oResult.IsSuccess = true;
                    oResult.Data = oPartyList;

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

        private CPurchase GetResultSetToParty(DataRow dr)
        {
            CPurchase oPurchase = new CPurchase();
            oPurchase.Purchase_OID = dr[0].ToString();
            oPurchase.Purchase_Branch = dr[1].ToString();
            oPurchase.Purchase_PartyOID = dr[2].ToString();
            oPurchase.Purchase_PartyName = dr[16].ToString();
            oPurchase.Purchase_GroupID = dr[3].ToString();
            oPurchase.Purchase_GroupName = dr[17].ToString();
            oPurchase.Purchase_Description = dr[4].ToString();
            oPurchase.Purchase_Quantity =float.Parse( dr[5].ToString());
            oPurchase.Purchase_Amount = float.Parse( dr[6].ToString());
            oPurchase.Purchase_CurrencyName = dr[18].ToString();
            oPurchase.Purchase_CurrencyOID =  dr[7].ToString();
            oPurchase.Purchase_CurrencyRate = float.Parse(dr[8].ToString());
            oPurchase.Purchase_Invoice = dr[9].ToString();
            oPurchase.Purchase_Date = DateTime.Parse( dr[10].ToString());
            if ((bool)dr[11] == true)
            {
                oPurchase.Purchase_Status = 1;
            }
            else if ((bool)dr[11] == false)
            {
                oPurchase.Purchase_Status = 0;
            }
            oPurchase.Purchase_Creator = dr[12].ToString();
            oPurchase.Purchase_CreationDate = DateTime.Parse( dr[13].ToString());
            oPurchase.Purchase_UpdateBy = dr[14].ToString();
            oPurchase.Purchase_UpdateDate = DateTime.Parse( dr[15].ToString());
            return oPurchase;
        }

        public CResult ReadAllByFromToDate(DateTime fromDate, DateTime toDate)
        {
            ArrayList oPartyList = new ArrayList();
            oResult = new CResult();
            conn = oConnManager.GetConnection(out s_DBError);
            if (conn != null)
            {
                try
                {
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = conn;
                    cmd.CommandText = "sp_Purchase_ReadAll_ByFromToDate";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
                    cmd.Parameters.AddWithValue("@ToDate", toDate.Date);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];

                    foreach (DataRow dr in dt.Rows)
                    {
                        oPartyList.Add(GetResultSetToParty(dr));
                    }

                    oResult.IsSuccess = true;
                    oResult.Data = oPartyList;

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

        public CResult ReadAllByFromToDateAndPartyOID(string partyOID,DateTime fromDate, DateTime toDate)
        {
            ArrayList oPartyList = new ArrayList();
            oResult = new CResult();
            conn = oConnManager.GetConnection(out s_DBError);
            if (conn != null)
            {
                try
                {
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = conn;
                    cmd.CommandText = "sp_Purchase_ReadAll_ByFromToDateAndPartyOID";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
                    cmd.Parameters.AddWithValue("@ToDate", toDate.Date);
                    cmd.Parameters.AddWithValue("@partyOID", partyOID);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];

                    foreach (DataRow dr in dt.Rows)
                    {
                        oPartyList.Add(GetResultSetToParty(dr));
                    }

                    oResult.IsSuccess = true;
                    oResult.Data = oPartyList;

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
