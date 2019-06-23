using ETL.Model;
using ETL.Common;
using ETL.DAO;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace ETL
{
    namespace BLL
    {
        public class CCVBBO
        {
              #region "Member variables"

            private SqlConnection conn;
            private CResult oResult;
            private CConManager oConnManager;

            string s_DBError = "";

            #endregion

            #region "Constructor"
            public CCVBBO()
            {
                oConnManager = new CConManager();
            }

            #endregion

            public CResult Create(CCVB oCVB)
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
                        cmd.CommandText = "sp_CVB_Insert";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CVB_Company", oCVB.Company);
                        cmd.Parameters.AddWithValue("@CVB_Branch", oCVB.Branch);
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

            public CResult Delete(string oid, string branch)
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
                        cmd.CommandText = "sp_CVB_Delete";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CVB_OID", oid);
                        //cmd.Parameters.AddWithValue("@CVB_Company", oCVB.Company);
                        cmd.Parameters.AddWithValue("@CVB_Branch", branch);
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

            public CResult ReadAllCVB(CCVB oCVB)
            {

                ArrayList oCVBList = new ArrayList();
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {


                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "sp_ReadAllCVB";
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dt = ds.Tables[0];

                        foreach (DataRow dr in dt.Rows)
                        {
                            oCVBList.Add(GetresultoCVB(dr));

                        }


                        oResult.Data = oCVBList;

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
            private CCVB GetresultoCVB(DataRow dr)
            {
                CCVB oCVB = new CCVB();
                oCVB.OID = dr[0].ToString();
                oCVB.Comp_OID = dr[1].ToString();
                oCVB.Bran_OID = dr[2].ToString();
                oCVB.Company = dr[3].ToString();
                oCVB.Branch = dr[4].ToString();
               
              
                return oCVB;
            }

            public CResult Import(CCVB oCVB)
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
                        cmd.CommandText = "sp_CVB_Import";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CVB_OID", oCVB.OID);
                        cmd.Parameters.AddWithValue("@CVB_Company", oCVB.Comp_OID);
                        cmd.Parameters.AddWithValue("@CVB_Branch", oCVB.Bran_OID);
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

            private CCVB GetresultoBVL(DataRow dr)
            {
                CCVB oCVB = new CCVB();
                oCVB.OID = dr[0].ToString();
               // oCVB.Comp_OID = dr[1].ToString();
                oCVB.Bran_OID = dr[1].ToString();
              //  oCVB.Company = dr[3].ToString();
              
                oCVB.Loc_OID = dr[2].ToString();
                  oCVB.Branch = dr[3].ToString();
                oCVB.Location = dr[4].ToString();


                return oCVB;
            }

            public CResult ReadAllBVL(CCVB oCVB)
            {

                ArrayList oCVBList = new ArrayList();
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {


                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "sp_ReadAllBVL";
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dt = ds.Tables[0];

                        foreach (DataRow dr in dt.Rows)
                        {
                            oCVBList.Add(GetresultoBVL(dr));

                        }


                        oResult.Data = oCVBList;

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
            public CResult CreateBVL(string Branch, string Location)
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
                        cmd.CommandText = "sp_BVL_Insert";
                        cmd.CommandType = CommandType.StoredProcedure;
                      //  cmd.Parameters.AddWithValue("@CVB_Company", oCVB.Company);
                        cmd.Parameters.AddWithValue("@CVB_Branch", Branch);
                        cmd.Parameters.AddWithValue("@CVB_Location", Location);
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
            public CResult DeleteBVL(string oid, string location)
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
                        cmd.CommandText = "sp_BVL_Delete";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@BVL_OID", oid);
                        //cmd.Parameters.AddWithValue("@BVL_Branch", oCVB.Branch);
                        cmd.Parameters.AddWithValue("@BVL_Location", location);
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

            public CResult ImportBVL(CCVB oCVB)
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
                        cmd.CommandText = "sp_BVL_Import";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@BVL_OID", oCVB.OID);
                        cmd.Parameters.AddWithValue("@BVL_Location", oCVB.Loc_OID);
                        cmd.Parameters.AddWithValue("@BVL_Branch", oCVB.Bran_OID);
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


        }
    }
}