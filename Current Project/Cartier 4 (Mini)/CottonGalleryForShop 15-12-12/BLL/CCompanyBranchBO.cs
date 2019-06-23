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
        public class CCompanyBranchBO
        {

            #region "Member variables"

            private SqlConnection conn;
            private CResult oResult;
            private CConManager oConnManager;

            string s_DBError = "";

            #endregion

            #region "Costructor"

            public CCompanyBranchBO()
            {
                oConnManager = new CConManager();
            }
            #endregion
            
            #region "CCompanyBranchBO"

            public CResult ReadAll()
            {
                List<CCompanyBranch> oList = new List<CCompanyBranch>();

                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_CompanyBranch_ReadAll";
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dtItem = ds.Tables[0];

                        foreach (DataRow dr in dtItem.Rows)
                        {
                            oList.Add(GetResultSetToCompanyBranch(dr));
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oList;

                    }
                    catch (Exception e)
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

            //public CResult ReadByCode(string sCode, CEnum.ETables eTables)
            //{
            //    CCompanyBranch oCompanyBranch = new CCompanyBranch();

            //    oResult = new CResult();
            //    conn = oConnManager.GetConnection(out s_DBError);
            //    if (conn != null)
            //    {
            //        try
            //        {
            //            DataSet ds = new DataSet();
            //            SqlCommand cmd = new SqlCommand();

            //            cmd.Connection = conn;
            //            cmd.CommandText = "sp_CCSDDSS_ReadByCode";
            //            cmd.CommandType = CommandType.StoredProcedure;
            //            cmd.Parameters.AddWithValue("@Code", sCode);
            //            cmd.Parameters.AddWithValue("@TableID", (int)eTables);

            //            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //            da.Fill(ds);
            //            DataTable dtItem = ds.Tables[0];

            //            foreach (DataRow dr in dtItem.Rows)
            //            {
            //                oCompanyBranch = GetResultSetToCompanyBranch(dr, eTables);
            //            }

            //            oResult.IsSuccess = true;
            //            oResult.Data = oCompanyBranch;

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

            private CCompanyBranch GetResultSetToCompanyBranch(DataRow dr)
            {
                CCompanyBranch oCompanyBranch = new CCompanyBranch();
                int iIndex = 0;
                oCompanyBranch.CompBrn_OId = dr[iIndex++].ToString();
                oCompanyBranch.CompBrn_Branch = dr[iIndex++].ToString();
                oCompanyBranch.CompBrn_Code = dr[iIndex++].ToString();
                oCompanyBranch.CompBrn_Name = dr[iIndex++].ToString();
                oCompanyBranch.CompBrn_FullName = dr[iIndex++].ToString();
                oCompanyBranch.CompBrn_Street = dr[iIndex++].ToString();
                oCompanyBranch.CompBrn_Road = dr[iIndex++].ToString();
                oCompanyBranch.CompBrn_City = dr[iIndex++].ToString();
                oCompanyBranch.CompBrn_Country = dr[iIndex++].ToString();
                oCompanyBranch.CompBrn_Phone = dr[iIndex++].ToString();
                oCompanyBranch.CompBrn_Mobile = dr[iIndex++].ToString();
                oCompanyBranch.CompBrn_Email = dr[iIndex++].ToString();
                oCompanyBranch.CompBrn_Web = dr[iIndex++].ToString();
                oCompanyBranch.CompBrn_PostalCode = dr[iIndex++].ToString();
                oCompanyBranch.Creator = dr[iIndex++].ToString();
                oCompanyBranch.CreationDate = DateTime.Parse(dr[iIndex++].ToString());
                oCompanyBranch.UpdateBy = dr[iIndex++].ToString();
                oCompanyBranch.UpdateDate = DateTime.Parse(dr[iIndex++].ToString());
                oCompanyBranch.IsActive = dr[iIndex++].ToString();
                oCompanyBranch.CompBrn_TIN = dr[iIndex++].ToString();
                oCompanyBranch.CompBrn_IsHeadoffice = dr[iIndex++].ToString();
                return oCompanyBranch;
            }

            public CResult Create(CCompanyBranch oCompanyBranch)
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
                        cmd.CommandText = "sp_CompanyBranch_Insert";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CompBrn_OId", oCompanyBranch.CompBrn_OId);
                        cmd.Parameters.AddWithValue("@CompBrn_Branch", oCompanyBranch.CompBrn_Branch);
                        cmd.Parameters.AddWithValue("@CompBrn_Code", oCompanyBranch.CompBrn_Code);
                        cmd.Parameters.AddWithValue("@CompBrn_Name", oCompanyBranch.CompBrn_Name);
                        cmd.Parameters.AddWithValue("@CompBrn_FullName", oCompanyBranch.CompBrn_FullName);
                        cmd.Parameters.AddWithValue("@CompBrn_Street", oCompanyBranch.CompBrn_Street);
                        cmd.Parameters.AddWithValue("@CompBrn_Road", oCompanyBranch.CompBrn_Road);
                        cmd.Parameters.AddWithValue("@CompBrn_City", oCompanyBranch.CompBrn_City);
                        cmd.Parameters.AddWithValue("@CompBrn_Country", oCompanyBranch.CompBrn_Country);
                        cmd.Parameters.AddWithValue("@CompBrn_Phone", oCompanyBranch.CompBrn_Phone);
                        cmd.Parameters.AddWithValue("@CompBrn_Mobile", oCompanyBranch.CompBrn_Mobile);
                        cmd.Parameters.AddWithValue("@CompBrn_Email", oCompanyBranch.CompBrn_Email);
                        cmd.Parameters.AddWithValue("@CompBrn_Web", oCompanyBranch.CompBrn_Web);
                        cmd.Parameters.AddWithValue("@CompBrn_PostalCode", oCompanyBranch.CompBrn_PostalCode);
                        cmd.Parameters.AddWithValue("@CompBrn_Creator", oCompanyBranch.Creator);
                        cmd.Parameters.AddWithValue("@CompBrn_CreationDate", oCompanyBranch.CreationDate);
                        cmd.Parameters.AddWithValue("@CompBrn_UpdateBy", oCompanyBranch.UpdateBy);
                        cmd.Parameters.AddWithValue("@CompBrn_UpdateDate", oCompanyBranch.UpdateDate);
                        cmd.Parameters.AddWithValue("@CompBrn_IsActive", oCompanyBranch.IsActive);
                        cmd.Parameters.AddWithValue("@CompBrn_TIN", oCompanyBranch.CompBrn_TIN);
                        cmd.Parameters.AddWithValue("@CompBrn_IsHeadoffice", oCompanyBranch.CompBrn_IsHeadoffice);
                        
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

            public CResult Update(CCompanyBranch oCompanyBranch)
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
                        cmd.CommandText = "sp_CompanyBranch_Update";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CompBrn_OId", oCompanyBranch.CompBrn_OId);
                        cmd.Parameters.AddWithValue("@CompBrn_Branch", oCompanyBranch.CompBrn_Branch);
                        cmd.Parameters.AddWithValue("@CompBrn_Code", oCompanyBranch.CompBrn_Code);
                        cmd.Parameters.AddWithValue("@CompBrn_Name", oCompanyBranch.CompBrn_Name);
                        cmd.Parameters.AddWithValue("@CompBrn_FullName", oCompanyBranch.CompBrn_FullName);
                        cmd.Parameters.AddWithValue("@CompBrn_Street", oCompanyBranch.CompBrn_Street);
                        cmd.Parameters.AddWithValue("@CompBrn_Road", oCompanyBranch.CompBrn_Road);
                        cmd.Parameters.AddWithValue("@CompBrn_City", oCompanyBranch.CompBrn_City);
                        cmd.Parameters.AddWithValue("@CompBrn_Country", oCompanyBranch.CompBrn_Country);
                        cmd.Parameters.AddWithValue("@CompBrn_Phone", oCompanyBranch.CompBrn_Phone);
                        cmd.Parameters.AddWithValue("@CompBrn_Mobile", oCompanyBranch.CompBrn_Mobile);
                        cmd.Parameters.AddWithValue("@CompBrn_Email", oCompanyBranch.CompBrn_Email);
                        cmd.Parameters.AddWithValue("@CompBrn_Web", oCompanyBranch.CompBrn_Web);
                        cmd.Parameters.AddWithValue("@CompBrn_PostalCode", oCompanyBranch.CompBrn_PostalCode);
                        cmd.Parameters.AddWithValue("@CompBrn_Creator", oCompanyBranch.Creator);
                        cmd.Parameters.AddWithValue("@CompBrn_CreationDate", oCompanyBranch.CreationDate);
                        cmd.Parameters.AddWithValue("@CompBrn_UpdateBy", oCompanyBranch.UpdateBy);
                        cmd.Parameters.AddWithValue("@CompBrn_UpdateDate", oCompanyBranch.UpdateDate);
                        cmd.Parameters.AddWithValue("@CompBrn_IsActive", oCompanyBranch.IsActive);
                        cmd.Parameters.AddWithValue("@CompBrn_TIN", oCompanyBranch.CompBrn_TIN);
                        cmd.Parameters.AddWithValue("@CompBrn_IsHeadoffice", oCompanyBranch.CompBrn_IsHeadoffice);
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

            public CResult Delete(CCompanyBranch oCompanyBranch)
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
                        cmd.CommandText = "sp_CompanyBranch_Delete";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CompBrn_OId", oCompanyBranch.CompBrn_OId);
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

            public CResult Import(CCompanyBranch oCompanyBranch)
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
                        cmd.CommandText = "sp_CompanyBranch_Import";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CompBrn_OId", oCompanyBranch.CompBrn_OId);
                        cmd.Parameters.AddWithValue("@CompBrn_Branch", oCompanyBranch.CompBrn_Branch);
                        cmd.Parameters.AddWithValue("@CompBrn_Code", oCompanyBranch.CompBrn_Code);
                        cmd.Parameters.AddWithValue("@CompBrn_Name", oCompanyBranch.CompBrn_Name);
                        cmd.Parameters.AddWithValue("@CompBrn_FullName", oCompanyBranch.CompBrn_FullName);
                        cmd.Parameters.AddWithValue("@CompBrn_Street", oCompanyBranch.CompBrn_Street);
                        cmd.Parameters.AddWithValue("@CompBrn_Road", oCompanyBranch.CompBrn_Road);
                        cmd.Parameters.AddWithValue("@CompBrn_City", oCompanyBranch.CompBrn_City);
                        cmd.Parameters.AddWithValue("@CompBrn_Country", oCompanyBranch.CompBrn_Country);
                        cmd.Parameters.AddWithValue("@CompBrn_Phone", oCompanyBranch.CompBrn_Phone);
                        cmd.Parameters.AddWithValue("@CompBrn_Mobile", oCompanyBranch.CompBrn_Mobile);
                        cmd.Parameters.AddWithValue("@CompBrn_Email", oCompanyBranch.CompBrn_Email);
                        cmd.Parameters.AddWithValue("@CompBrn_Web", oCompanyBranch.CompBrn_Web);
                        cmd.Parameters.AddWithValue("@CompBrn_PostalCode", oCompanyBranch.CompBrn_PostalCode);
                        cmd.Parameters.AddWithValue("@CompBrn_Creator", oCompanyBranch.Creator);
                        cmd.Parameters.AddWithValue("@CompBrn_CreationDate", oCompanyBranch.CreationDate);
                        cmd.Parameters.AddWithValue("@CompBrn_UpdateBy", oCompanyBranch.UpdateBy);
                        cmd.Parameters.AddWithValue("@CompBrn_UpdateDate", oCompanyBranch.UpdateDate);
                        cmd.Parameters.AddWithValue("@CompBrn_IsActive", oCompanyBranch.IsActive);
                        cmd.Parameters.AddWithValue("@CompBrn_TIN", oCompanyBranch.CompBrn_TIN);
                        cmd.Parameters.AddWithValue("@CompBrn_IsHeadoffice", oCompanyBranch.CompBrn_IsHeadoffice);
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

            #endregion
        }
    }
}
