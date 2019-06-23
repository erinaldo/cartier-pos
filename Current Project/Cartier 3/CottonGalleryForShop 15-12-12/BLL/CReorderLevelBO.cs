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
        public class CReorderLevelBO
        {
        
        
         #region "Member variables"

            private SqlConnection conn;
            private CResult oResult;
            private CConManager oConnManager;

            string s_DBError = "";

            #endregion

            #region "Constructor"
            public CReorderLevelBO()
            {
                oConnManager = new CConManager();
            }

            #endregion

            #region "Methods"

            public CResult Create(CReorderLevel oReorderLevel)
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
                        cmd.CommandText = "sp_ReorderLevelInsert";
                        cmd.CommandType = CommandType.StoredProcedure;
                     // cmd.Parameters.AddWithValue("@Cust_OID", oReorderLevel.OID);
                        cmd.Parameters.AddWithValue("@Cust_Branch", oReorderLevel.Branch_ID);
                        cmd.Parameters.AddWithValue("@ItemID", oReorderLevel.Item_ID);
                        cmd.Parameters.AddWithValue("@LocationID", oReorderLevel.Location_ID);
                        cmd.Parameters.AddWithValue("@Quantity", oReorderLevel.Quantity);
                        cmd.Parameters.AddWithValue("@Remarks", oReorderLevel.Remarks);

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
            public CResult Delete(CReorderLevel oReorderLevel)
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
                        cmd.CommandText = "sp_ReorderLevelDelete";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ItemID", oReorderLevel.Item_ID);
                        //cmd.Parameters.AddWithValue("@Location", oReorderLevel.Location);
                        //cmd.Parameters.AddWithValue("@Quantity", oReorderLevel.Quantity);
                        //cmd.Parameters.AddWithValue("@Remarks", oReorderLevel.Remarks);

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
            public CResult Update(CReorderLevel oReorderLevel)
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
                        cmd.CommandText = "sp_ReorderLevelUpdate";
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@Cust_OID", oReorderLevel.OID);
                        //cmd.Parameters.AddWithValue("@Cust_Branch", "XXXXX");
                        cmd.Parameters.AddWithValue("@OID", oReorderLevel.OID);
                        cmd.Parameters.AddWithValue("@ItemID", oReorderLevel.Item_ID);
                        cmd.Parameters.AddWithValue("@LocationID", oReorderLevel.Location_ID);
                        cmd.Parameters.AddWithValue("@Quantity", oReorderLevel.Quantity);
                        cmd.Parameters.AddWithValue("@Remarks", oReorderLevel.Remarks);

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
         
            
            public CResult ReadAllReorderLevelData(CReorderLevel oReorderLevel)
            {

                ArrayList oReorderLevelList = new ArrayList();
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {


                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "sp_ReadALLReOrdLvl";
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dt = ds.Tables[0];

                        foreach (DataRow dr in dt.Rows)
                        {
                            oReorderLevelList.Add(GetresultoReorderLevel(dr));

                        }


                        oResult.Data = oReorderLevelList;

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
         
            private CReorderLevel GetresultoReorderLevel(DataRow dr)
            {
                CReorderLevel oReorderLevel = new CReorderLevel();
                oReorderLevel.OID = dr[0].ToString();
                oReorderLevel.Branch_Name = dr[8].ToString();
                oReorderLevel.Branch_ID = dr["ReOrdLvl_Branch"].ToString();
                oReorderLevel.Item_ID = dr[2].ToString();
                oReorderLevel.Location_ID = dr[3].ToString();
                oReorderLevel.Quantity = dr[4].ToString();
                oReorderLevel.Remarks = dr[5].ToString();
                oReorderLevel.Item_Name = dr[6].ToString();
                oReorderLevel.Location_Name = dr[7].ToString();
                return oReorderLevel;
            }


            public CResult Import(CReorderLevel oReorderLevel)
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
                        cmd.CommandText = "sp_ReorderLevel_Import";
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@Cust_OID", oReorderLevel.OID);
                        //cmd.Parameters.AddWithValue("@Cust_Branch", "XXXXX");
                        cmd.Parameters.AddWithValue("@OID", oReorderLevel.OID);
                        cmd.Parameters.AddWithValue("@Cust_Branch", oReorderLevel.Branch_ID);
                        cmd.Parameters.AddWithValue("@ItemID", oReorderLevel.Item_ID);
                        cmd.Parameters.AddWithValue("@LocationID", oReorderLevel.Location_ID);
                        cmd.Parameters.AddWithValue("@Quantity", oReorderLevel.Quantity);
                        cmd.Parameters.AddWithValue("@Remarks", oReorderLevel.Remarks);

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