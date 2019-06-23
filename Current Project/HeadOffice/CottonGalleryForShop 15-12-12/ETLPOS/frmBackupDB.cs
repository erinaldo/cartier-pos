using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ETL.BLL;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace ETLPOS
{
    public partial class frmBackupDB : ETLPOS.BaseForm
    {
        //public bool buttneVisibility = true;
        //public frmBackupDB()
        //{
        //    InitializeComponent();
        //}


        //private void btnExit_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        ////public Server srvSql = new Server();
        //private void btnBackup_Click(object sender, EventArgs e)
        //{
        //    //if (Vaid())
        //    //{
        //    //    // If there was a SQL connection created
        //    //    if (srvSql != null)
        //    //    {
        //    //        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        //    //        {
        //    //            // Create a new backup operation
        //    //            Backup bkpDatabase = new Backup();
        //    //            // Set the backup type to a database backup
        //    //            bkpDatabase.Action = BackupActionType.Database;
        //    //            // Set the database that we want to perform a backup on
        //    //            bkpDatabase.Database = cmbDatabaseName.SelectedItem.ToString();

        //    //            // Set the backup device to a file
        //    //            BackupDeviceItem bkpDevice = new BackupDeviceItem(saveFileDialog1.FileName, DeviceType.File);
        //    //            // Add the backup device to the backup
        //    //            bkpDatabase.Devices.Add(bkpDevice);
        //    //            // Perform the backup
        //    //            bkpDatabase.SqlBackup(srvSql);
        //    //            MessageBox.Show("Backup Operation Successfully Done", "ETL Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    //        }
        //    //    }

        //    //}
        //}

        //private bool Vaid()
        //{
        //    if (cmbServerName.Text.Trim() == "")
        //    {
        //        MessageBox.Show("Select a Server Name!!");
        //        return false;
        //    }
        //    if (cmbDatabaseName.Text.Trim() == "")
        //    {
        //        MessageBox.Show("Select Database Name!!");
        //        cmbDatabaseName.Focus();
        //        return false;
        //    }
        //    return true;
        //}

        //private void chbEnable_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chbEnable.Checked)
        //    {
        //        cmbServerName.Enabled = true;
        //        txtPassword.Enabled = true;
        //        cmbDatabaseName.Enabled = true;
        //        txtUserName.Enabled = true;
        //    }
        //    else if (!chbEnable.Checked)
        //    {
        //        cmbDatabaseName.Enabled = false;
        //        txtPassword.Enabled = false;
        //        cmbServerName.Enabled = false;
        //        txtUserName.Enabled = false;
        //    }
        //}

        //private void frmBackupDB_Load(object sender, EventArgs e)
        //{
        //    if (buttneVisibility == false)
        //    {
        //        btnRestoreDB.Visible = buttneVisibility;
        //    }
        //    DataTable dtServers = SmoApplication.EnumAvailableSqlServers(true);
        //    if (dtServers.Rows.Count > 0)
        //    {
        //        // Loop through each server in the DataTable
        //        foreach (DataRow drServer in dtServers.Rows)
        //        {
        //            // Add the name to the combobox
        //            cmbServerName.Items.Add(drServer["Name"]);
        //            cmbServerName.SelectedIndex = 0;
        //        }
        //    }
        //    else if (dtServers.Rows.Count == 0)
        //    {
        //        // A server was not selected, show an error message
        //        MessageBox.Show("You have no server to load", "No Server", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //    if (cmbServerName.SelectedItem != null & cmbServerName.SelectedItem.ToString() != "")
        //    {
        //        // Create a new connection to the selected server name
        //        ServerConnection srvConn = new ServerConnection(cmbServerName.SelectedItem.ToString());
        //        // Log in using SQL authentication instead of Windows authentication
        //        srvConn.LoginSecure = false;
        //        // Give the login username
        //        srvConn.Login = txtUserName.Text;
        //        // Give the login password
        //        srvConn.Password = txtPassword.Text;
        //        // Create a new SQL Server object using the connection we created
        //        srvSql = new Server(srvConn);
        //        // Loop through the databases list
        //        foreach (Database dbServer in srvSql.Databases)
        //        {

        //            // Add database to combobox
        //            cmbDatabaseName.Items.Add(dbServer.Name);
        //        }
        //        for (int i = 0; i < cmbDatabaseName.Items.Count; i++)
        //        {
        //            if (cmbDatabaseName.Items[i].ToString() == cmbDatabaseName.Text)
        //            {
        //                cmbDatabaseName.SelectedIndex = i;
        //                break;
        //            }
        //        }
        //    }
        //    else if (cmbServerName.SelectedItem == null || cmbServerName.SelectedItem.ToString() == "")
        //    {
        //        // A server was not selected, show an error message
        //        MessageBox.Show("Please select a server first", "Server Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    // If there was a SQL connection created
        //    if (srvSql != null)
        //    {
        //        // If the user has chosen the file from which he wants the database to be restored
        //        if (openBackupDialog.ShowDialog() == DialogResult.OK)
        //        {
        //            // Create a new database restore operation
        //            Restore rstDatabase = new Restore();
        //            // Set the restore type to a database restore
        //            rstDatabase.Action = RestoreActionType.Database;
        //            // Set the database that we want to perform the restore on
        //            rstDatabase.Database = cmbDatabaseName.SelectedItem.ToString();

        //            // Set the backup device from which we want to restore, to a file
        //            BackupDeviceItem bkpDevice = new BackupDeviceItem(openBackupDialog.FileName, DeviceType.File);
        //            // Add the backup device to the restore type
        //            rstDatabase.Devices.Add(bkpDevice);
        //            // If the database already exists, replace it
        //            rstDatabase.ReplaceDatabase = true;
        //            // Perform the restore
        //            rstDatabase.SqlRestore(srvSql);
        //            MessageBox.Show("Database Successfully Restored", "ETLPOS Restore", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //    else
        //    {
        //        // There was no connection established; probably the Connect button was not clicked
        //        MessageBox.Show("A connection to a SQL server was not established.", "Not Connected to Server", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //}
    }
}
