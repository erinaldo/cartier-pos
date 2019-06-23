using System.Data;
using System.Collections.Generic;
using System.Text;


using ETL.Model;
using ETL.Common;
using ETL.DAO;
using System.Data.SqlClient;


namespace ETL
{
    namespace BLL
    {
        public class CCurrencyBO
        {
            #region "Member variables"

            private SqlConnection conn;
            private CResult oResult;
            private CConManager oConnManager;

            string s_DBError = "";

            #endregion

            #region "Costructor"

            public CCurrencyBO()
            {
                oConnManager = new CConManager();
            }
            #endregion

            #region "Currency"

            public CResult Create(CCurrency oCurrency)
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
                        StringBuilder sBuilder = new StringBuilder();
                        sBuilder.Append("DECLARE @NextId NCHAR(24);");
                        sBuilder.Append("EXEC sp_GetNextId 'Curr_OID','Curr', @Curr_Branch, @NextId OUTPUT;");
                        sBuilder.Append(" Insert into t_Curr values(@NextId,@Curr_Branch,@Curr_Code,@Curr_Name)");

                        cmd.CommandText = sBuilder.ToString();
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@Curr_Branch", oCurrency.Curr_Branch);
                        cmd.Parameters.AddWithValue("@Curr_Code", oCurrency.Curr_Code);
                        cmd.Parameters.AddWithValue("@Curr_Name", oCurrency.Curr_Name);

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
            public CResult Update(CCurrency oCurrency)
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
                        StringBuilder sBuilder = new StringBuilder();
                        sBuilder.Append("Update t_Curr set Curr_Branch=@Curr_Branch,Curr_Code=@Curr_Code,Curr_Name=@Curr_Name where Curr_OID=@Curr_OID");

                        cmd.CommandText = sBuilder.ToString();
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@Curr_OID", oCurrency.Curr_OID);
                        cmd.Parameters.AddWithValue("@Curr_Branch", oCurrency.Curr_Branch);
                        cmd.Parameters.AddWithValue("@Curr_Code", oCurrency.Curr_Code);
                        cmd.Parameters.AddWithValue("@Curr_Name", oCurrency.Curr_Name);

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
            public CResult Delete(CCurrency oCurrency)
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
                        StringBuilder sBuilder = new StringBuilder();

                       // sBuilder.Append("");
                        //sBuilder.Append("Delete from t_Curr where Curr_OID = @Curr_OID");
                        cmd.CommandText = "sp_Currency_Delete";
                        //cmd.CommandText = sBuilder.ToString();
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Curr_OID", oCurrency.Curr_OID);
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
                List<CCurrency> oList = new List<CCurrency>();
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "Select * from t_Curr order by Curr_OID";
                        cmd.CommandType = CommandType.Text;

                        SqlDataReader oReader = cmd.ExecuteReader();
                        if (oReader.HasRows)
                        {
                            while (oReader.Read())
                            {
                                CCurrency objCurr = new CCurrency();
                                objCurr.Curr_OID=oReader["Curr_OID"].ToString();
                                objCurr.Curr_Branch = oReader["Curr_Branch"].ToString();
                                objCurr.Curr_Code= oReader["Curr_Code"].ToString();
                                objCurr.Curr_Name= oReader["Curr_Name"].ToString();
                                oList.Add(objCurr);
                            }
                        }
                        oReader.Close();

                        oResult.IsSuccess = true;
                        oResult.Data = oList;
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

            public CResult Import(CCurrency oCurrency)
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
                        cmd.CommandText = "sp_Currency_Import";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Curr_OID", oCurrency.Curr_OID);
                        cmd.Parameters.AddWithValue("@Curr_Branch", oCurrency.Curr_Branch);
                        cmd.Parameters.AddWithValue("@Curr_Code", oCurrency.Curr_Code);
                        cmd.Parameters.AddWithValue("@Curr_Name", oCurrency.Curr_Name);

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
