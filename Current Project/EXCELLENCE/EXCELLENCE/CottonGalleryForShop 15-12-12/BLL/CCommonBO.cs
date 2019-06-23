using System.Data;
using System.Data.SqlClient;
using ETL.Common;
using ETL.DAO;
using System;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace ETL
{
    namespace BLL
    {
        public class CCommonBO
        {
            #region "Member variables"

            private SqlConnection conn;
            private CResult oResult;
            private CConManager oConnManager;

            string s_DBError = "";

            #endregion

            #region "Costructor"

            public CCommonBO()
            {
                oConnManager = new CConManager();
            }
            #endregion

            public CResult ReadLastCodeNo(string stColumnName, string stTableName, string stBranchCode)
            {
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_GetNextCodeNo";
                        cmd.CommandType = CommandType.StoredProcedure;

                        //@ColumnName,@TableName,@NextId,@BranchCode

                        cmd.Parameters.AddWithValue("@ColumnName", stColumnName);
                        cmd.Parameters.AddWithValue("@TableName", stTableName);
                        cmd.Parameters.Add("@NextId", SqlDbType.Char, 16);
                        cmd.Parameters.AddWithValue("@BranchCode", stBranchCode);

                        cmd.Parameters["@NextId"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();

                        oResult.Data = cmd.Parameters["@NextId"].Value.ToString();
                        oResult.IsSuccess = true;
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
            public bool Backupdb(string location)
            {
                bool flag = false;
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        string sql = "BACKUP DATABASE [HeadOffice] TO  DISK = N'" + location + "' WITH NOFORMAT, NOINIT,  NAME = N'HeadOffice-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                        flag = true;

                    }
                    catch (SqlException e)
                    {
                        flag = false;
                    }
                    finally
                    {
                        oConnManager.Close();
                    }
                }
                return flag;

            }
            public bool IsExistCode(string sql)
            {
                bool flag = false;
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = sql;
                        cmd.CommandType = CommandType.Text;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            flag = true;
                        }



                    }
                    catch (SqlException e)
                    {

                    }
                    finally
                    {
                        oConnManager.Close();
                    }
                }
                return flag;
            }

            public void BackupDatabase(String databaseName, String userName,
             String password, String serverName, String destinationPath)
            {

                //Backup sqlBackup = new Backup();

                //sqlBackup.Action = BackupActionType.Database;
                //sqlBackup.BackupSetDescription = "ArchiveDataBase:" +
                //                                 DateTime.Now.ToShortDateString();
                //sqlBackup.BackupSetName = "Archive";

                //sqlBackup.Database = databaseName;

                //BackupDeviceItem deviceItem = new BackupDeviceItem(destinationPath, DeviceType.File);
                //////////////ServerConnection connection = new ServerConnection(serverName);
                //////////////connection.LoginSecure = false;
                //////////////connection.Login = userName;
                //////////////connection.Password = password;
                //////////////Server sqlServer = new Server();
                //////////////sqlServer = new Server(connection);
                //////////////Backup sqlBackup = new Backup();
                //////////////sqlBackup.Action = BackupActionType.Database;
                //////////////sqlBackup.Database = databaseName;
                //BackupDeviceItem bkpDevice = new BackupDeviceItem(saveFileDialog1.FileName, DeviceType.File);
                //sqlBackup.Devices.Add(bkpDevice);
                //Database db = sqlServer.Databases[databaseName];
                //sqlBackup.Initialize = true;
                //sqlBackup.Checksum = true;
                //sqlBackup.ContinueAfterError = true;

                //sqlBackup.Devices.Add(deviceItem);
                //sqlBackup.Incremental = false;

                //sqlBackup.ExpirationDate = DateTime.Now.AddDays(3);
                //sqlBackup.LogTruncation = BackupTruncateLogType.Truncate;

                //sqlBackup.FormatMedia = false;

                /////////////sqlBackup.SqlBackup(sqlServer);
            }
        }
    }
}