using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ETL.Common;
using ETL.DAO;
using System.Data;
using ETL.Model;

namespace ETL
{
    namespace BLL
    {
        public class CSizeBO
        {
            #region "Member variables"

            private SqlConnection conn;
            private CResult oResult;
            private CConManager oConnManager;

            string s_DBError = "";

            #endregion

             #region "Costructor"

            public CSizeBO()
            {
                oConnManager = new CConManager();
            }
            #endregion


            public CResult Create(CSize oCSize)
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
                        cmd.CommandText = "sp_Size_Insert";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Size_Code", oCSize.Size_Code);
                        cmd.Parameters.AddWithValue("@Size_Name", oCSize.Size_Name);
                        cmd.Parameters.AddWithValue("@Size_Branch", oCSize.Size_Branch);
                        cmd.Parameters.AddWithValue("@Creator", oCSize.Creator);
                        cmd.Parameters.AddWithValue("@CreationDate", oCSize.CreationDate);
                        cmd.Parameters.AddWithValue("@UpdateBy", oCSize.UpdateBy);
                        cmd.Parameters.AddWithValue("@UpdateDate", oCSize.UpdateDate);
                        cmd.Parameters.AddWithValue("@IsActive", oCSize.IsActive);
                        cmd.Parameters.AddWithValue("@Remarks", oCSize.Remarks);

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


            public CResult Update(CSize oCSize)
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
                        cmd.CommandText = "sp_Size_Update";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Size_OID", oCSize.Size_OID);
                        cmd.Parameters.AddWithValue("@Size_Code", oCSize.Size_Code);
                        cmd.Parameters.AddWithValue("@Size_Name", oCSize.Size_Name);
                        cmd.Parameters.AddWithValue("@Size_Branch", oCSize.Size_Branch);
                        cmd.Parameters.AddWithValue("@Creator", oCSize.Creator);
                        cmd.Parameters.AddWithValue("@CreationDate", oCSize.CreationDate);
                        cmd.Parameters.AddWithValue("@UpdateBy", oCSize.UpdateBy);
                        cmd.Parameters.AddWithValue("@UpdateDate", oCSize.UpdateDate);
                        cmd.Parameters.AddWithValue("@IsActive", oCSize.IsActive);
                        cmd.Parameters.AddWithValue("@Remarks", oCSize.Remarks);

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

        }
    }
}
