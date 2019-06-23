using System;
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
        public class CUserBO
        {

            #region "Member variables"

            private SqlConnection conn;
            private CResult oResult;
            private CConManager oConnManager;

            string s_DBError = "";

            #endregion

            #region "Constructor"
            public CUserBO()
            {
                oConnManager = new CConManager();
            }

            #endregion

            #region "Methods"
            
            public CResult Create(CUser oUser)
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
                        cmd.CommandText = "sp_UserInsert";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Branch", oUser.User_Branch);
                        cmd.Parameters.AddWithValue("@UserID", oUser.User_UserID);
                        cmd.Parameters.AddWithValue("@UserName", oUser.User_UserName);
                        cmd.Parameters.AddWithValue("@Passward", oUser.User_Passward);
                        cmd.Parameters.AddWithValue("@UserType", oUser.User_UserType);
                        cmd.Parameters.AddWithValue("@UserStatus", oUser.User_UserStatus);
                      //  cmd.Parameters.AddWithValue("@CreatedDate", oUser.User_CreatedDate);

                     //   cmd.Parameters.AddWithValue("@Phone", oUser.Phone);
                       
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

            public CResult Update(string User_OID, string Type, string Staus,string Pass)
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
                        cmd.CommandText = "sp_User_Update";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@User_OID", User_OID);
                     //   cmd.Parameters.AddWithValue("@Branch", oUser.User_Branch);
                     //   cmd.Parameters.AddWithValue("@UserID", oUser.User_UserID);
                     //   cmd.Parameters.AddWithValue("@UserName", oUser.User_UserName);
                      //  cmd.Parameters.AddWithValue("@Passward", oUser.User_Passward);
                        cmd.Parameters.AddWithValue("@UserType", Type);
                        cmd.Parameters.AddWithValue("@UserStatus", Staus);
                        cmd.Parameters.AddWithValue("@Pass", Pass);
                        //  cmd.Parameters.AddWithValue("@CreatedDate", oUser.User_CreatedDate);

                        //   cmd.Parameters.AddWithValue("@Phone", oUser.Phone);

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


            public CResult Delete(CUser oUser)
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
                        cmd.CommandText = "sp_UserDelete";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UserName", oUser.User_UserName);
                        //cmd.Parameters.AddWithValue("@Passward", oUser.User_Passward);
                        cmd.Parameters.AddWithValue("@UserType", oUser.User_UserType);
                        ////   cmd.Parameters.AddWithValue("@Phone", oUser.Phone);

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

            public CResult Login(string UserID, string Password)
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
                        cmd.CommandText = "sp_Login";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        cmd.Parameters.AddWithValue("@Passward", Password);
                       // cmd.Parameters.AddWithValue("@Branch", Branch);
                        //cmd.Parameters.AddWithValue("@", Password);
                        cmd.Parameters.Add("@IsSuccess",SqlDbType.Char,1);
                        cmd.Parameters["@IsSuccess"].Direction = ParameterDirection.ReturnValue;
                        cmd.ExecuteNonQuery();
                        string st = cmd.Parameters["@IsSuccess"].Value.ToString();



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
            public CResult UserLogin(string UserID, string Password)
            {
                string strSQL = "SELECT * FROM t_User WHERE User_Name ='" + UserID + "' and User_Password = '" + Password + "'and User_Status = 'Active'";
                oResult = new CResult();
                CUser oUser = null;
                SqlDataReader dr = null;
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    cmd.Transaction = oConnManager.BeginTransaction();
                    try
                    {
                        cmd.CommandText = strSQL;
                        cmd.CommandType = CommandType.Text;
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            oUser = new CUser();
                            oUser.User_OID = dr["User_OID"].ToString();
                            oUser.User_UserID = dr["User_Name"].ToString();
                            oUser.User_Passward = dr["User_Password"].ToString();
                            oUser.User_UserType = dr["User_UserType"].ToString();
                        }

                        oResult.Data = oUser;
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


            public CResult ReadAllUserData(CUser oUser)
            {

                ArrayList oUserList = new ArrayList();
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {


                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "select * from t_User where User_Status = 'Active'";

                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dt = ds.Tables[0];

                        foreach (DataRow dr in dt.Rows)
                        {
                            oUserList.Add(GetresultoUser(dr));

                        }

                        oResult.Data = dt;

                        oResult.Data = oUserList;

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

            public CResult ReadCurrentUserAndBrance(string cuser, string cbrance)
            {
                CUserAndBranch oUserAndBranch = new CUserAndBranch();
                
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_ReadCurrentUserAndBrance";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@cuser", cuser);
                        cmd.Parameters.AddWithValue("@cbrance",cbrance);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);

                        DataTable dt = ds.Tables[0];
                        foreach (DataRow dr in dt.Rows)
                        {
                            oUserAndBranch.User = GetresultoUser(dr);
                        }

                        DataTable dt2 = ds.Tables[1];
                        foreach (DataRow dr in dt2.Rows)
                        {
                            oUserAndBranch.Branch = GetResultSetToCompanyBranch(dr);
                        
                        }


                        oResult.IsSuccess = true;
                        oResult.Data = oUserAndBranch;

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


            private CUser GetresultoUser(DataRow dr)
            {
                CUser oUser = new CUser();
                oUser.User_OID = dr[0].ToString();
                oUser.User_Branch = dr[1].ToString();
                oUser.User_UserID = dr[2].ToString();
                oUser.User_UserName = dr[3].ToString();
                oUser.User_Passward = dr[4].ToString();
              //  oUser.User_UserID = dr[4].ToString();
                oUser.User_UserType = dr[6].ToString();
                oUser.User_UserStatus = dr[15].ToString();


                
                return oUser;
            }



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

            public CResult Import(CUser oUser)
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
                        cmd.CommandText = "sp_User_Import";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@User_OID", oUser.User_OID.Trim());
                        cmd.Parameters.AddWithValue("@Branch", oUser.User_Branch);
                        cmd.Parameters.AddWithValue("@UserID", oUser.User_UserID);
                        cmd.Parameters.AddWithValue("@UserName", oUser.User_UserName);
                        cmd.Parameters.AddWithValue("@Passward", oUser.User_Passward);
                        cmd.Parameters.AddWithValue("@UserType", oUser.User_UserType);
                        cmd.Parameters.AddWithValue("@UserStatus", oUser.User_UserStatus);

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