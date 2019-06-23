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
       public class CLocBO
        {
            #region "Member variables"

            private SqlConnection conn;
            private CResult oResult;
            private CConManager oConnManager;

            string s_DBError = "";

            #endregion

            #region "Costructor"

            public CLocBO()
            {
                oConnManager = new CConManager();
            }
            #endregion

            #region "Loc"

            public CResult Create(CLocation oLoc)
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
                        cmd.CommandText = "sp_Loc_Insert";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Loc_Branch", oLoc.Loc_Branch);
                        cmd.Parameters.AddWithValue("@Loc_Code", oLoc.Loc_Code);
                        cmd.Parameters.AddWithValue("@Loc_Name", oLoc.Loc_Name);

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

            public CResult Update(CLocation oLoc)
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
                        cmd.CommandText = "sp_Loc_Update";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Loc_OID", oLoc.Loc_OID);
                        cmd.Parameters.AddWithValue("@Loc_Branch", oLoc.Loc_Branch);
                        cmd.Parameters.AddWithValue("@Loc_Code", oLoc.Loc_Code);
                        cmd.Parameters.AddWithValue("@Loc_Name", oLoc.Loc_Name);

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

            public CResult Delete(CLocation oLoc)
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
                        cmd.CommandText = "sp_Loc_Delete";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Loc_OID", oLoc.Loc_OID);
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

            private CLocation GetResultSetToLoc(DataRow dr)
            {
                CLocation oLoc = new CLocation();

                oLoc.Loc_OID = dr[0].ToString();
                oLoc.Loc_Branch = dr[1].ToString();
                oLoc.Loc_Code = dr[2].ToString();
                oLoc.Loc_Name = dr[3].ToString();

                return oLoc;
            }

            public CResult ReadAll()
            {
                ArrayList oLocList = new ArrayList();
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_Loc_ReadAll";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dt = ds.Tables[0];

                        foreach (DataRow dr in dt.Rows)
                        {
                            oLocList.Add(GetResultSetToLoc(dr));
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oLocList;

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

            public CResult ReadAllBranchwise(string stBranchOID)
            {
                ArrayList oLocList = new ArrayList();
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "select * from t_loc where Loc_OID in(Select BVL_Location from t_BVL where BVL_Branch=@Branch_OID)";
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@Branch_OID", stBranchOID);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dt = ds.Tables[0];

                        foreach (DataRow dr in dt.Rows)
                        {
                            oLocList.Add(GetResultSetToLoc(dr));
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oLocList;

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


            public CResult Import(CLocation oLoc)
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
                        cmd.CommandText = "sp_Loc_Import";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Loc_OID", oLoc.Loc_OID);
                        cmd.Parameters.AddWithValue("@Loc_Branch", oLoc.Loc_Branch);
                        cmd.Parameters.AddWithValue("@Loc_Code", oLoc.Loc_Code);
                        cmd.Parameters.AddWithValue("@Loc_Name", oLoc.Loc_Name);

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

