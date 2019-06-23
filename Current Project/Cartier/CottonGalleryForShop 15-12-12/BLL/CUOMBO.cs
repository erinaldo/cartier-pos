using System.Data;
using System;
using System.Collections;
using System.Data;


using ETL.Model;
using ETL.Common;
using ETL.DAO;
using System.Data.SqlClient;


namespace ETL
{
    namespace BLL
    {
        public class CUOMBO
        {
            #region "Member variables"

            private SqlConnection conn;
            private CResult oResult;
            private CConManager oConnManager;

            string s_DBError = "";

            #endregion

            #region "Costructor"

            public CUOMBO()
            {
                oConnManager = new CConManager();
            }
            #endregion

            #region "UOM"

            public CResult Create(CUOM oUOM)
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
                        cmd.CommandText = "sp_UOM_Insert";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UOM_Code", oUOM.UOM_Code);
                        cmd.Parameters.AddWithValue("@UOM_Name", oUOM.UOM_Name);
                        cmd.Parameters.AddWithValue("@UOM_Branch", oUOM.UOM_Branch);
                        cmd.Parameters.AddWithValue("@Creator", oUOM.Creator);
                        cmd.Parameters.AddWithValue("@CreationDate", oUOM.CreationDate);
                        cmd.Parameters.AddWithValue("@UpdateBy", oUOM.UpdateBy);
                        cmd.Parameters.AddWithValue("@UpdateDate", oUOM.UpdateDate);
                        cmd.Parameters.AddWithValue("@IsActive", oUOM.IsActive);
                        cmd.Parameters.AddWithValue("@Remarks", oUOM.Remarks);

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
           
            public CResult Update(CUOM oUOM)
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
                        cmd.CommandText = "sp_UOM_Update";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UOM_OID", oUOM.UOM_OID);
                        cmd.Parameters.AddWithValue("@UOM_Code", oUOM.UOM_Code);
                        cmd.Parameters.AddWithValue("@UOM_Name", oUOM.UOM_Name);
                        cmd.Parameters.AddWithValue("@UOM_Branch", oUOM.UOM_Branch);
                        cmd.Parameters.AddWithValue("@Creator", oUOM.Creator);
                        cmd.Parameters.AddWithValue("@CreationDate", oUOM.CreationDate);
                        cmd.Parameters.AddWithValue("@UpdateBy", oUOM.UpdateBy);
                        cmd.Parameters.AddWithValue("@UpdateDate", oUOM.UpdateDate);
                        cmd.Parameters.AddWithValue("@IsActive", oUOM.IsActive);
                        cmd.Parameters.AddWithValue("@Remarks", oUOM.Remarks);

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
            public CResult Delete(CUOM oUOM)
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
                        cmd.CommandText = "sp_UOM_Delete";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UOM_OID", oUOM.UOM_OID);
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

            private CUOM GetResultSetToUOM(DataRow dr)
            {
                CUOM oUOM = new CUOM();

                oUOM.UOM_OID = dr[0].ToString();
                oUOM.UOM_Code= dr[1].ToString();
                oUOM.UOM_Name = dr[2].ToString();
                oUOM.UOM_Branch= dr[3].ToString();
                oUOM.Creator = dr[4].ToString();
                oUOM.CreationDate = DateTime.Parse(dr[5].ToString()).Date;
                oUOM.UpdateBy = dr[6].ToString();
                oUOM.UpdateDate = DateTime.Parse(dr[7].ToString()).Date;
                oUOM.IsActive = dr[8].ToString();
                oUOM.Remarks = dr[9].ToString();

                return oUOM;
            }

            public CResult ReadAll()
            {
                ArrayList oUOMList = new ArrayList();
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_UOM_ReadAll";

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dt = ds.Tables[0];

                        foreach (DataRow dr in dt.Rows)
                        {
                            oUOMList.Add(GetResultSetToUOM(dr));
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oUOMList;

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

            public CResult Import(CUOM oUOM)
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
                        cmd.CommandText = "sp_UOM_Import";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UOM_OID", oUOM.UOM_OID);
                        cmd.Parameters.AddWithValue("@UOM_Code", oUOM.UOM_Code);
                        cmd.Parameters.AddWithValue("@UOM_Name", oUOM.UOM_Name);
                        cmd.Parameters.AddWithValue("@UOM_Branch", oUOM.UOM_Branch);
                        cmd.Parameters.AddWithValue("@Creator", oUOM.Creator);
                        cmd.Parameters.AddWithValue("@CreationDate", oUOM.CreationDate);
                        cmd.Parameters.AddWithValue("@UpdateBy", oUOM.UpdateBy);
                        cmd.Parameters.AddWithValue("@UpdateDate", oUOM.UpdateDate);
                        cmd.Parameters.AddWithValue("@IsActive", oUOM.IsActive);
                        cmd.Parameters.AddWithValue("@Remarks", oUOM.Remarks);

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
