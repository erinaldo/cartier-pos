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
        public class CCompanyBO
        {

            #region "Member variables"

            private SqlConnection conn;
            private CResult oResult;
            private CConManager oConnManager;

            string s_DBError = "";

            #endregion

            #region "Costructor"

            public CCompanyBO()
            {
                oConnManager = new CConManager();
            }
            #endregion


            #region "CCompanyBO"

            public CResult ReadAll()
            {
                List<CCompany> oList = new List<CCompany>();

                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_Company_ReadAll";
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dtItem = ds.Tables[0];

                        foreach (DataRow dr in dtItem.Rows)
                        {
                            oList.Add(GetResultSetToCompany(dr));
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
            //    CCompany oCompany = new CCompany();

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
            //                oCompany = GetResultSetToCompany(dr, eTables);
            //            }

            //            oResult.IsSuccess = true;
            //            oResult.Data = oCompany;

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

            private CCompany GetResultSetToCompany(DataRow dr)
            {
                CCompany oCompany = new CCompany();
                int iIndex = 0;
                oCompany.Comp_OId = dr[iIndex++].ToString();
                oCompany.Comp_Branch = dr[iIndex++].ToString();
                oCompany.Comp_Code = dr[iIndex++].ToString();
                oCompany.Comp_Name = dr[iIndex++].ToString();
                oCompany.Comp_FullName = dr[iIndex++].ToString();
                oCompany.Comp_Street = dr[iIndex++].ToString();
                oCompany.Comp_Road = dr[iIndex++].ToString();
                oCompany.Comp_City = dr[iIndex++].ToString();
                oCompany.Comp_Country = dr[iIndex++].ToString();
                oCompany.Comp_Phone = dr[iIndex++].ToString();
                oCompany.Comp_Mobile = dr[iIndex++].ToString();
                oCompany.Comp_Email = dr[iIndex++].ToString();
                oCompany.Comp_Web = dr[iIndex++].ToString();
                oCompany.Comp_PostalCode = dr[iIndex++].ToString();
                oCompany.Creator = dr[iIndex++].ToString();
                oCompany.CreationDate = DateTime.Parse(dr[iIndex++].ToString());
                oCompany.UpdateBy = dr[iIndex++].ToString();
                oCompany.UpdateDate = DateTime.Parse(dr[iIndex++].ToString());
                oCompany.IsActive = dr[iIndex++].ToString();

                return oCompany;
            }

            public CResult Create(CCompany oCompany)
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
                        cmd.CommandText = "sp_Company_Insert";
                        cmd.CommandType = CommandType.StoredProcedure;
                        
                        cmd.Parameters.AddWithValue("@Comp_OId", oCompany.Comp_OId);
                        cmd.Parameters.AddWithValue("@Comp_Branch", oCompany.Comp_Branch);
                        cmd.Parameters.AddWithValue("@Comp_Code", oCompany.Comp_Code);
                        cmd.Parameters.AddWithValue("@Comp_Name", oCompany.Comp_Name);
                        cmd.Parameters.AddWithValue("@Comp_FullName", oCompany.Comp_FullName);
                        cmd.Parameters.AddWithValue("@Comp_Street", oCompany.Comp_Street);
                        cmd.Parameters.AddWithValue("@Comp_Road", oCompany.Comp_Road);
                        cmd.Parameters.AddWithValue("@Comp_City", oCompany.Comp_City);
                        cmd.Parameters.AddWithValue("@Comp_Country", oCompany.Comp_Country);
                        cmd.Parameters.AddWithValue("@Comp_Phone", oCompany.Comp_Phone);
                        cmd.Parameters.AddWithValue("@Comp_Mobile", oCompany.Comp_Mobile);
                        cmd.Parameters.AddWithValue("@Comp_Email", oCompany.Comp_Email);
                        cmd.Parameters.AddWithValue("@Comp_Web", oCompany.Comp_Web);
                        cmd.Parameters.AddWithValue("@Comp_PostalCode", oCompany.Comp_PostalCode);
                        cmd.Parameters.AddWithValue("@Comp_Creator", oCompany.Creator);
                        cmd.Parameters.AddWithValue("@Comp_CreationDate", oCompany.CreationDate);
                        cmd.Parameters.AddWithValue("@Comp_UpdateBy", oCompany.UpdateBy);
                        cmd.Parameters.AddWithValue("@Comp_UpdateDate", oCompany.UpdateDate);
                        cmd.Parameters.AddWithValue("@Comp_IsActive", oCompany.IsActive);
                        
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

            public CResult Update(CCompany oCompany)
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
                        cmd.CommandText = "sp_Company_Update";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Comp_OId", oCompany.Comp_OId);
                        cmd.Parameters.AddWithValue("@Comp_Branch", oCompany.Comp_Branch);
                        cmd.Parameters.AddWithValue("@Comp_Code", oCompany.Comp_Code);
                        cmd.Parameters.AddWithValue("@Comp_Name", oCompany.Comp_Name);
                        cmd.Parameters.AddWithValue("@Comp_FullName", oCompany.Comp_FullName);
                        cmd.Parameters.AddWithValue("@Comp_Street", oCompany.Comp_Street);
                        cmd.Parameters.AddWithValue("@Comp_Road", oCompany.Comp_Road);
                        cmd.Parameters.AddWithValue("@Comp_City", oCompany.Comp_City);
                        cmd.Parameters.AddWithValue("@Comp_Country", oCompany.Comp_Country);
                        cmd.Parameters.AddWithValue("@Comp_Phone", oCompany.Comp_Phone);
                        cmd.Parameters.AddWithValue("@Comp_Mobile", oCompany.Comp_Mobile);
                        cmd.Parameters.AddWithValue("@Comp_Email", oCompany.Comp_Email);
                        cmd.Parameters.AddWithValue("@Comp_Web", oCompany.Comp_Web);
                        cmd.Parameters.AddWithValue("@Comp_PostalCode", oCompany.Comp_PostalCode);
                        cmd.Parameters.AddWithValue("@Comp_Creator", oCompany.Creator);
                        cmd.Parameters.AddWithValue("@Comp_CreationDate", oCompany.CreationDate);
                        cmd.Parameters.AddWithValue("@Comp_UpdateBy", oCompany.UpdateBy);
                        cmd.Parameters.AddWithValue("@Comp_UpdateDate", oCompany.UpdateDate);
                        cmd.Parameters.AddWithValue("@Comp_IsActive", oCompany.IsActive);
                        
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

            public CResult Delete(CCompany oCompany)
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
                        cmd.CommandText = "sp_Company_Delete";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Comp_OId", oCompany.Comp_OId);
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

            public CResult Import(CCompany oCompany)
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
                        cmd.CommandText = "sp_Company_Import";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Comp_OId", oCompany.Comp_OId);
                        cmd.Parameters.AddWithValue("@Comp_Branch", oCompany.Comp_Branch);
                        cmd.Parameters.AddWithValue("@Comp_Code", oCompany.Comp_Code);
                        cmd.Parameters.AddWithValue("@Comp_Name", oCompany.Comp_Name);
                        cmd.Parameters.AddWithValue("@Comp_FullName", oCompany.Comp_FullName);
                        cmd.Parameters.AddWithValue("@Comp_Street", oCompany.Comp_Street);
                        cmd.Parameters.AddWithValue("@Comp_Road", oCompany.Comp_Road);
                        cmd.Parameters.AddWithValue("@Comp_City", oCompany.Comp_City);
                        cmd.Parameters.AddWithValue("@Comp_Country", oCompany.Comp_Country);
                        cmd.Parameters.AddWithValue("@Comp_Phone", oCompany.Comp_Phone);
                        cmd.Parameters.AddWithValue("@Comp_Mobile", oCompany.Comp_Mobile);
                        cmd.Parameters.AddWithValue("@Comp_Email", oCompany.Comp_Email);
                        cmd.Parameters.AddWithValue("@Comp_Web", oCompany.Comp_Web);
                        cmd.Parameters.AddWithValue("@Comp_PostalCode", oCompany.Comp_PostalCode);
                        cmd.Parameters.AddWithValue("@Comp_Creator", oCompany.Creator);
                        cmd.Parameters.AddWithValue("@Comp_CreationDate", oCompany.CreationDate);
                        cmd.Parameters.AddWithValue("@Comp_UpdateBy", oCompany.UpdateBy);
                        cmd.Parameters.AddWithValue("@Comp_UpdateDate", oCompany.UpdateDate);
                        cmd.Parameters.AddWithValue("@Comp_IsActive", oCompany.IsActive);

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
