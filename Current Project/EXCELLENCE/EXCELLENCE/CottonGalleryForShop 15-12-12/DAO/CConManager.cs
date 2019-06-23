/* File Name		: CConManager.cs
 * Author			: Tanvir
 * Creation Date	: 29-09-07
 * 
 * Modification History 
 * 
 * Author						Modification Date		Purpose
 * 
 * 
 * 
 * Copyright@ 2007 Epsilonn Technilogies Ltd.
 * 
 * */

using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Text;

namespace ETL
{
    namespace DAO
    {
        public class CConManager
        {
            /// <summary>
            /// Default constructor.
            /// </summary>
            public CConManager()
            {
                GetConnectionString();
            }

            public CConManager(string sConnectionString)
            {
                this.ConnString = sConnectionString;
            }
            #region "Member variables"

            SqlConnection oConnection;
            SqlTransaction oSqlTrans;

            protected string m_sConnString = "";
            protected string m_sConnStringForRemote = "";
            protected string m_sErrMessage = "";

            #endregion

            #region "Properties"

            public string ConnString
            {
                get { return m_sConnString; }
                set { m_sConnString = value; }
            }

            public string ConnStringForRemote
            {
                get { return m_sConnStringForRemote; }
                set { m_sConnStringForRemote = value; }
            }

            public string ErrMessage
            {
                get { return m_sErrMessage; }
                set { m_sErrMessage = value; }
            }

            #endregion

            #region "Methodes"


            protected void GetConnectionStringForRemote()
            {
                ConnectionStringSettings oConStringSettingsForRemote;
                try
                {
                    oConStringSettingsForRemote = ConfigurationManager.ConnectionStrings["DBConnectionStringForRemote"];
                    if (oConStringSettingsForRemote != null)
                    {
                        this.ConnStringForRemote = oConStringSettingsForRemote.ConnectionString;
                    }
                }
                catch (Exception ex)
                {
                    this.ConnStringForRemote = string.Empty;
                    this.ErrMessage = ex.Message;
                }
            }
            protected void GetConnectionString()
            {
                ConnectionStringSettings oConStringSettings;
                try
                {
                    oConStringSettings = ConfigurationManager.ConnectionStrings["DBConnectionString"];
                    if (oConStringSettings != null)
                    {
                        this.ConnString = oConStringSettings.ConnectionString;
                    }
                }
                catch (Exception ex)
                {
                    this.ConnString = string.Empty;
                    this.ErrMessage = ex.Message;
                }

            }

            public SqlConnection GetConnection(out string sErrorMessage)
            {
                try
                {
                    oConnection = new SqlConnection(this.ConnString);
                    oConnection.Open();
                }
                catch (SqlException e)
                {
                    ErrMessage = GetErrorMessage(e);
                    oConnection = null;
                }

                sErrorMessage = ErrMessage;

                return oConnection;
            }

            public SqlConnection GetConnectionForRemote()
            {
                try
                {
                    this.GetConnectionStringForRemote();
                    oConnection = new SqlConnection(this.ConnStringForRemote);
                    oConnection.Open();
                }
                catch (SqlException e)
                {
                    oConnection = null;
                }
                return oConnection;
            }
            

            public SqlTransaction BeginTransaction()
            {
                oSqlTrans = oConnection.BeginTransaction();

                return oSqlTrans;
            }

            public string Rollback()
            {
                string errorMessages = "";

                try
                {
                    oSqlTrans.Rollback();
                }
                catch (SqlException ex)
                {
                    if (oSqlTrans.Connection != null)
                    {
                        errorMessages = GetErrorMessage(ex);
                    }
                }

                return errorMessages;
            }


            public void Commit()
            {
                if (oSqlTrans.Connection != null)
                {
                    oSqlTrans.Commit();
                }

            }

            public void Close()
            {
                if (oConnection != null)
                {
                    oConnection.Close();
                }
            }

            public string GetErrorMessage(SqlException e)
            {
                string errorMessages = "";

                for (int i = 0; i < e.Errors.Count; i++)
                {
                    errorMessages += "Index #" + i + "\n" +
                        "Message: " + e.Errors[i].Message + "\n" +
                        "LineNumber: " + e.Errors[i].LineNumber + "\n" +
                        "Source: " + e.Errors[i].Source + "\n" +
                        "Procedure: " + e.Errors[i].Procedure + "\n";
                }

                return errorMessages;
            }

            #endregion
        }
    }
}
