using System;
using System.Collections.Generic;
using System.Text;
using ETL.DAO;
using System.Collections;
using ETL.Common;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class CCashCardBO
    {
          #region "Member variables"

            private SqlConnection conn;
            private CResult oResult;
            private CConManager oConnManager;

            string s_DBError = "";

            #endregion

            #region "Costructor"

            public CCashCardBO()
            {
                oConnManager = new CConManager();
            }
            #endregion

            public DataTable ReadAll(DateTime dat,string branchcode)
            {
                DataTable dt = new DataTable();
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
                        cmd.CommandText = "sp_CardCashSale";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SOMstr_Date", dat);
                        cmd.Parameters.AddWithValue("@CompBrn_OID", branchcode);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        dt = ds.Tables[0];
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

                return dt;
            }
    }
}
