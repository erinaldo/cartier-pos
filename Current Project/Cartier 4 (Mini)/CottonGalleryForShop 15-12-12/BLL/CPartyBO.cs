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
    public class CPartyBO
    {
        #region"Private Variable"

        private SqlConnection conn;
        private CResult oResult;
        private CConManager oConnManager;
        string s_DBError = "";

        #endregion

        #region"Constructor"
        public CPartyBO()
        {
            oConnManager = new CConManager();
        }
        #endregion


        #region"Methode"

        public CResult Create(CParty oParty)
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
                    cmd.CommandText = "sp_Party_Insert";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Party_Branch", oParty.Party_Branch);
                    cmd.Parameters.AddWithValue("@Party_Name", oParty.Party_Name);
                    cmd.Parameters.AddWithValue("@Party_Address", oParty.Party_Address);
                    cmd.Parameters.AddWithValue("@Party_City", oParty.Party_City);
                    cmd.Parameters.AddWithValue("@Party_Country", oParty.Party_Country);
                    cmd.Parameters.AddWithValue("@Party_Phone", oParty.Party_Phone);
                    cmd.Parameters.AddWithValue("@Party_Mobile", oParty.Party_Mobile);
                    cmd.Parameters.AddWithValue("@Party_Email", oParty.Party_Email);
                    cmd.Parameters.AddWithValue("@Party_ContactPerson1", oParty.Party_ContactPerson1);
                    cmd.Parameters.AddWithValue("@Party_Phone1", oParty.Party_Phone1);
                    cmd.Parameters.AddWithValue("@Party_Contactperson2", oParty.Party_Contactperson2);
                    cmd.Parameters.AddWithValue("@Party_Phone2", oParty.Party_Phone2);
                    cmd.Parameters.AddWithValue("@Party_Creator", oParty.Creator);
                    cmd.Parameters.AddWithValue("@Party_CreationDate", oParty.CreationDate);
                    cmd.Parameters.AddWithValue("@Party_UpdateBy", oParty.UpdateBy);
                    cmd.Parameters.AddWithValue("@Party_UpdateDate", oParty.UpdateDate);

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

        public CResult Update(CParty oParty)
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
                    cmd.CommandText = "sp_Party_Update";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Party_OID", oParty.Party_OID);
                    cmd.Parameters.AddWithValue("@Party_Branch", oParty.Party_Branch);
                    cmd.Parameters.AddWithValue("@Party_Name", oParty.Party_Name);
                    cmd.Parameters.AddWithValue("@Party_Address", oParty.Party_Address);
                    cmd.Parameters.AddWithValue("@Party_City", oParty.Party_City);
                    cmd.Parameters.AddWithValue("@Party_Country", oParty.Party_Country);
                    cmd.Parameters.AddWithValue("@Party_Phone", oParty.Party_Phone);
                    cmd.Parameters.AddWithValue("@Party_Mobile", oParty.Party_Mobile);
                    cmd.Parameters.AddWithValue("@Party_Email", oParty.Party_Email);
                    cmd.Parameters.AddWithValue("@Party_ContactPerson1", oParty.Party_ContactPerson1);
                    cmd.Parameters.AddWithValue("@Party_Phone1", oParty.Party_Phone1);
                    cmd.Parameters.AddWithValue("@Party_Contactperson2", oParty.Party_Contactperson2);
                    cmd.Parameters.AddWithValue("@Party_Phone2", oParty.Party_Phone2);
                    cmd.Parameters.AddWithValue("@Party_Creator", oParty.Creator);
                    cmd.Parameters.AddWithValue("@Party_CreationDate", oParty.CreationDate);
                    cmd.Parameters.AddWithValue("@Party_UpdateBy", oParty.UpdateBy);
                    cmd.Parameters.AddWithValue("@Party_UpdateDate", oParty.UpdateDate);

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
        public CResult Delete(CParty oParty)
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
                    cmd.CommandText = "sp_Party_Delete";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Party_OID", oParty.Party_OID);
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
                    cmd.CommandText = "sp_Party_ReadAll";

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

        private CParty GetResultSetToParty(DataRow dr)
        {
            CParty oParty = new CParty();
            oParty.Party_OID = dr[0].ToString();
            oParty.Party_Branch = dr[1].ToString();
            oParty.Party_Name = dr[2].ToString();
            oParty.Party_Address = dr[3].ToString();
            oParty.Party_City = dr[4].ToString();
            oParty.Party_Country = dr[5].ToString();
            oParty.Party_Phone = dr[6].ToString();
            oParty.Party_Mobile = dr[7].ToString();
            oParty.Party_Email = dr[8].ToString();
            oParty.Party_ContactPerson1 = dr[9].ToString();
            oParty.Party_Phone1 = dr[10].ToString();
            oParty.Party_Contactperson2 = dr[11].ToString();
            oParty.Party_Phone2 = dr[12].ToString();
            oParty.Creator = dr[13].ToString();
            oParty.CreationDate = DateTime.Parse(dr[14].ToString());
            oParty.UpdateBy = dr[15].ToString();
            oParty.UpdateDate = DateTime.Parse(dr[16].ToString());
            return oParty;
        }


        #endregion

    }
}
