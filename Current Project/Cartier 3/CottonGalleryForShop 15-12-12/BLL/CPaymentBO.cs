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
    public class CPaymentBO
    { 
        #region"Private Variable"

        private SqlConnection conn;
        private CResult oResult;
        private CConManager oConnManager;
        string s_DBError = "";

        #endregion

        #region"Constructor"
        public CPaymentBO()
        {
            oConnManager = new CConManager();
        }
        #endregion


        #region"Methode"

        public CResult Create(CPayment oPayment)
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
                    cmd.CommandText = "sp_Payment_Insert";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Payment_Branch", oPayment.Payment_Branch);
                    cmd.Parameters.AddWithValue("@Payment_Date", oPayment.Payment_Date);
                    cmd.Parameters.AddWithValue("@Payment_PartyOID", oPayment.Payment_PartyOID);
                    cmd.Parameters.AddWithValue("@Payment_Amount", oPayment.Payment_Amount);
                    cmd.Parameters.AddWithValue("@Payment_CurrencyOID", oPayment.Payment_CurrencyOID);
                    cmd.Parameters.AddWithValue("@Payment_CurrencyRate", oPayment.Payment_CurrencyRate);
                    cmd.Parameters.AddWithValue("@Payment_BDT", oPayment.Payment_BDT);
                    cmd.Parameters.AddWithValue("@Payment_Media", oPayment.Payment_Media);
                    cmd.Parameters.AddWithValue("@Payment_RecieptConfirmation", oPayment.Payment_RecieptConfirmation);
                    cmd.Parameters.AddWithValue("@Payment_ReceivedDate", oPayment.Payment_ReceivedDate);
                    cmd.Parameters.AddWithValue("@Payment_Creator", oPayment.Creator);
                    cmd.Parameters.AddWithValue("@Payment_CreationDate", oPayment.CreationDate);
                    cmd.Parameters.AddWithValue("@Payment_UpdateBy", oPayment.UpdateBy);
                    cmd.Parameters.AddWithValue("@Payment_UpdateDate", oPayment.UpdateDate);

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

        public CResult Update(CPayment oPayment)
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
                    cmd.CommandText = "sp_Payment_Update";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Payment_OID", oPayment.Payment_OID);
                    cmd.Parameters.AddWithValue("@Payment_Branch", oPayment.Payment_Branch);
                    cmd.Parameters.AddWithValue("@Payment_Date", oPayment.Payment_Date);
                    cmd.Parameters.AddWithValue("@Payment_PartyOID", oPayment.Payment_PartyOID);
                    cmd.Parameters.AddWithValue("@Payment_Amount", oPayment.Payment_Amount);
                    cmd.Parameters.AddWithValue("@Payment_CurrencyOID", oPayment.Payment_CurrencyOID);
                    cmd.Parameters.AddWithValue("@Payment_CurrencyRate", oPayment.Payment_CurrencyRate);
                    cmd.Parameters.AddWithValue("@Payment_BDT", oPayment.Payment_BDT);
                    cmd.Parameters.AddWithValue("@Payment_Media", oPayment.Payment_Media);
                    cmd.Parameters.AddWithValue("@Payment_RecieptConfirmation", oPayment.Payment_RecieptConfirmation);
                    cmd.Parameters.AddWithValue("@Payment_ReceivedDate", oPayment.Payment_ReceivedDate);
                    cmd.Parameters.AddWithValue("@Payment_UpdateBy", oPayment.UpdateBy);
                    cmd.Parameters.AddWithValue("@Payment_UpdateDate", oPayment.UpdateDate);

                    cmd.ExecuteNonQuery();
                    oConnManager.Commit();
                    oResult.IsSuccess = true;
                }
                //catch (SqlException e)
                //{
                //    string sRollbackError = oConnManager.Rollback();

                //    oResult.IsSuccess = false;
                //    oResult.ErrMsg = sRollbackError.Equals("") ? oConnManager.GetErrorMessage(e) : sRollbackError;
                //}
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
        public CResult Delete(CPayment oPayment)
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
                    cmd.CommandText = "sp_Payment_Delete";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Payment_OID", oPayment.Payment_OID);
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
                    cmd.CommandText = "sp_Payment_ReadAll";

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

        private CPayment GetResultSetToParty(DataRow dr)
        {
            CPayment oPayment = new CPayment();
            oPayment.Payment_OID = dr[0].ToString();
            oPayment.Payment_Branch = dr[1].ToString();
            oPayment.Payment_Date = DateTime.Parse(dr[2].ToString());
            oPayment.Payment_PartyOID = dr[3].ToString();
            oPayment.Payment_PartyName = dr[15].ToString();
            oPayment.Payment_Amount = float.Parse( dr[4].ToString());
            oPayment.Payment_CurrencyOID =  dr[5].ToString();
            oPayment.Payment_CurrencyName = dr[16].ToString();
            oPayment.Payment_CurrencyRate = float.Parse( dr[6].ToString());
            oPayment.Payment_BDT = float.Parse( dr[7].ToString());
            oPayment.Payment_Media = dr[8].ToString();
            if ((bool)dr[9] == true)
            {
                oPayment.Payment_RecieptConfirmation = 1;
            }
            else
            {
                oPayment.Payment_RecieptConfirmation = 0;
            }
            oPayment.Payment_ReceivedDate = DateTime.Parse( dr[10].ToString());
            oPayment.Payment_Creator = dr[11].ToString();
            oPayment.Payment_CreationDate = DateTime.Parse( dr[12].ToString());
            oPayment.Payment_UpdateBy = dr[13].ToString();
            oPayment.Payment_UpdateDate = DateTime.Parse(dr[14].ToString());
            return oPayment;
        }


        public CResult ReadAllByFromToDate(DateTime fromDate,DateTime toDate)
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
                    cmd.CommandText = "sp_Payment_ReadAll_ByFromToDate";
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

        public CResult ReadAllByFromToDateAndPartyOID(string oPartyOID,DateTime fromDate, DateTime toDate)
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
                    cmd.CommandText = "sp_Payment_ReadAll_ByFromToDateAndPartyOID";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
                    cmd.Parameters.AddWithValue("@ToDate", toDate.Date);
                    cmd.Parameters.AddWithValue("@PartyOID", oPartyOID);
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
