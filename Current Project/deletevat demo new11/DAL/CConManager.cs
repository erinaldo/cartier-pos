/* File Name		: CConManager.cs
 * Author			: Pulak
 * Creation Date	: 16-01-12
 * 
 * Modification History 
 * 
 * Author						Modification Date		Purpose
 * 
 * 
 * 
 * Copyright@ 2012 Maksud Saifullah Pulak.
 * Phone: 01674574675
 * Email:pulak.maksud@gmail.com
 * */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace PULAK
{
    namespace DAL
    {
        public class CConManager
        {
            public string s_ErrorMessage = "";
            private string PULAKConnString = string.Empty;

            public CConManager()
            {
                this.GetConnectionString();
            }

            #region Connection
            private void GetConnectionString()
            {
                try
                {
                    PULAKConnString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
                }
                catch (Exception ex)
                {
                    this.s_ErrorMessage = ex.Message;

                }
            }

            private SqlConnection GetConnection()
            {
                SqlConnection oConnection = null;
                try
                {
                    if (this.PULAKConnString.Equals("")) { GetConnectionString(); }
                    oConnection = new SqlConnection(this.PULAKConnString);
                    oConnection.Open();
                }
                catch (SqlException ex)
                {
                    this.s_ErrorMessage = ex.Message;
                    oConnection = null;
                }

                return oConnection;
            }

            private void Close(SqlConnection oConnection)
            {
                if (oConnection != null)
                {
                    oConnection.Close();
                }
            }
            #endregion

            #region Create
            public bool Create(string SQL, string uID)
            {
                bool flag = false;
                SqlConnection oConn = null;
                SqlCommand oCmd = null;
                try
                {
                    oConn = this.GetConnection();
                    if (oConn != null)
                    {
                        oCmd = new SqlCommand(SQL, oConn);
                        oCmd.ExecuteNonQuery();
                        flag = true;
                    }
                }
                catch (Exception ex)
                {
                    this.s_ErrorMessage = ex.Message;
                    flag = false;
                }
                finally
                {
                    this.Close(oConn);
                }
                return flag;
            }
            public int CreateUnique(string SQL, string uID)
            {
                int flag = -1;
                SqlConnection oConn = null;
                SqlCommand oCmd = null;
                try
                {
                    oConn = this.GetConnection();
                    if (oConn != null)
                    {
                        oCmd = new SqlCommand(SQL, oConn);
                        flag = oCmd.ExecuteNonQuery();

                    }
                }
                catch (SqlException eSql)
                {
                    this.s_ErrorMessage = eSql.Message;
                    flag = eSql.ErrorCode;
                }
                catch (Exception ex)
                {
                    this.s_ErrorMessage = ex.Message;
                    flag = -1;
                }

                finally
                {
                    this.Close(oConn);
                }
                return flag;
            }
            public bool Create(List<string> SQLList, string uID)
            {
                bool flag = false;
                SqlConnection oConn = null;
                SqlTransaction oTran = null;
                SqlCommand oCmd = null;
                try
                {
                    oConn = this.GetConnection();
                    if (oConn != null)
                    {
                        oTran = oConn.BeginTransaction();
                        foreach (string sql in SQLList)
                        {
                            oCmd = new SqlCommand(sql, oConn);
                            oCmd.Transaction = oTran;
                            oCmd.ExecuteNonQuery();
                            oCmd = null;
                        }
                        oTran.Commit();
                        flag = true;
                    }
                }
                catch (Exception ex)
                {
                    this.s_ErrorMessage = ex.Message;
                    flag = false;
                    oTran.Rollback();
                }
                finally
                {
                    this.Close(oConn);
                    if (oTran != null)
                    {
                        oTran = null;
                    }
                }
                return flag;
            }
            #endregion

            #region Update
            public int UpdateUnique(string SQL, string uID)
            {
                int flag = -1;
                SqlConnection oConn = null;
                SqlCommand oCmd = null;
                try
                {
                    oConn = this.GetConnection();
                    if (oConn != null)
                    {
                        oCmd = new SqlCommand(SQL, oConn);
                        flag = oCmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException eSql)
                {
                    this.s_ErrorMessage = eSql.Message;
                    flag = eSql.ErrorCode;
                }
                catch (Exception ex)
                {
                    this.s_ErrorMessage = ex.Message;
                    flag = -1;
                }
                finally
                {
                    this.Close(oConn);
                }
                return flag;
            }
            public int Update(string SQL, string uID)
            {
                int flag = -1;
                SqlConnection oConn = null;
                SqlCommand oCmd = null;
                try
                {
                    oConn = this.GetConnection();
                    if (oConn != null)
                    {
                        oCmd = new SqlCommand(SQL, oConn);
                        flag = oCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    this.s_ErrorMessage = ex.Message;
                    flag = -1;
                }
                finally
                {
                    this.Close(oConn);
                }
                return flag;
            }
            public int Update(List<string> SQLList, string uID)
            {
                int flag = -1;
                SqlConnection oConn = null;
                SqlTransaction oTran = null;
                SqlCommand oCmd = null;
                try
                {
                    oConn = this.GetConnection();
                    if (oConn != null)
                    {
                        flag = 0;
                        oTran = oConn.BeginTransaction();
                        foreach (string sql in SQLList)
                        {
                            oCmd = new SqlCommand(sql, oConn);
                            oCmd.Transaction = oTran;
                            flag += oCmd.ExecuteNonQuery();
                            oCmd = null;
                        }
                        oTran.Commit();
                    }
                }
                catch (Exception ex)
                {
                    this.s_ErrorMessage = ex.Message;
                    flag = -1;
                    oTran.Rollback();
                }
                finally
                {
                    this.Close(oConn);
                    if (oTran != null)
                    {
                        oTran = null;
                    }
                }
                return flag;
            }
            #endregion

            #region Delete
            public int Delete(string SQL, string uID)
            {
                int flag = -1;
                SqlConnection oConn = null;
                SqlCommand oCmd = null;
                try
                {
                    oConn = this.GetConnection();
                    if (oConn != null)
                    {
                        flag = 0;
                        oCmd = new SqlCommand(SQL, oConn);
                        flag = oCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    this.s_ErrorMessage = ex.Message;
                    flag = -1;
                }
                finally
                {
                    this.Close(oConn);
                }
                return flag;
            }
            public int Delete(List<string> SQLList, string uID)
            {
                int flag = -1;
                SqlConnection oConn = null;
                SqlTransaction oTran = null;
                SqlCommand oCmd = null;
                try
                {
                    oConn = this.GetConnection();
                    if (oConn != null)
                    {
                        oTran = oConn.BeginTransaction();
                        foreach (string sql in SQLList)
                        {
                            oCmd = new SqlCommand(sql, oConn);
                            oCmd.Transaction = oTran;
                            flag += oCmd.ExecuteNonQuery();
                            oCmd = null;
                        }
                        oTran.Commit();
                    }
                }
                catch (Exception ex)
                {
                    this.s_ErrorMessage = ex.Message;
                    flag = -1;
                    oTran.Rollback();
                }
                finally
                {
                    this.Close(oConn);
                    if (oTran != null)
                    {
                        oTran = null;
                    }
                }
                return flag;
            }
            #endregion

            #region Read
            public DataTable Read(string SQL)
            {
                DataTable oDt = null;
                SqlConnection oConn = null;
                SqlDataAdapter oDa = null;

                try
                {
                    oConn = this.GetConnection();
                    if (oConn != null)
                    {
                        oDt = new DataTable();
                        oDa = new SqlDataAdapter(SQL, oConn);
                        oDa.Fill(oDt);
                    }
                }
                catch (Exception ex)
                {
                    this.s_ErrorMessage = ex.Message;
                }
                finally
                {
                    this.Close(oConn);
                }
                return oDt;
            }
            #endregion

        }
    }
}
