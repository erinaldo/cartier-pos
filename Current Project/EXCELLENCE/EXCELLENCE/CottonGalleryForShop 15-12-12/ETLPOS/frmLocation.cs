using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using ETL.BLL;
using ETL.Common;
using ETL.Model;

namespace ETLPOS
{
    public partial class frmLocation : BaseForm
    {

        #region "Declarations"
        private bool m_IsUpdateMode = false;
        #endregion

        #region "Methods"

        public frmLocation()
        {
            InitializeComponent();
        }

      //  string m_sCurrentCode = string.Empty;
        //private void GenerateCode()
        //{
        //    txtCode.Text = "";
        //    string m_sMaxID = string.Empty;
        //    string m_sMaxID1 = string.Empty;
        //    int maxrow = arLocationList.Count;
        //    if (maxrow > 0)
        //    {
        //        m_sMaxID = ((CLocation)arLocationList[maxrow - 1]).LocCode.ToString();
        //    }
           
        //    if (m_sMaxID == "")
        //    {
        //        m_sMaxID1 = "0000000001";
        //    }
        //    else
        //    {

        //        int incID = (int.Parse(m_sMaxID) + 1);

        //        string stID2 = incID.ToString();
        //        int stLen = stID2.Length;
               
        //        for (int i = 0; i < 10 - stLen; i++)
        //        {
        //            m_sMaxID1 = m_sMaxID1 + '0';
        //        }
        //        m_sMaxID1 = m_sMaxID1 + stID2;
        //    }
        //    txtCode.Text = m_sMaxID1.ToString();
        //}

        ArrayList arLocationList = new ArrayList();

        private void ReadLocationAllData()
        {
            CLocBO oBO = new CLocBO();
            CResult oResult = new CResult();
            
            oResult = oBO.ReadAll();
            if (oResult.IsSuccess)
            {
                arLocationList = (ArrayList)oResult.Data;

                if (arLocationList.Count > 0)
                {
                   
                    lstLocationList.DataSource = arLocationList;
                    lstLocationList.DisplayMember = "Loc_Code";
                    lstLocationList.ValueMember = "Loc_OID";

                }
                //GenerateCode();
            }
            else
            {
                MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormControlMode(int Mode)
        {
            switch (Mode)
            { 
                case 0:
                    btnSave.Text = "Save";
                    btnDelete.Enabled = false;
                    m_IsUpdateMode = false;
                    txtCode.Enabled = true;
                    break;

                case 1:
                    btnSave.Text = "Update";
                    btnDelete.Enabled = true;
                    m_IsUpdateMode = true;
                    txtCode.Enabled = false;
                    break;
            }
        }

        private void ClearFormData()
        {
            //GenerateCode();
           
            if (m_IsUpdateMode)
            {
                ReadLocationAllData();
               
            }
            FormControlMode(0);
            txtName.Text = "";
            txtCode.Text = "";
        }

        private bool ValidateToSavedData()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Please Input Location name. ","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtName.Focus();
                return false;
            }

            return true;
        }

        private CLocation GetToSavedData()
        {
            CLocation oLoc = new CLocation();

            oLoc.Loc_OID = txtSelectedID.Text.Trim();
            oLoc.Loc_Branch=currentBranch.CompBrn_Code;
            oLoc.Loc_Code = txtCode.Text;
            oLoc.Loc_Name = txtName.Text;

            return oLoc;
        }


        #endregion

        #region "Events"
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateToSavedData())
            {
                CLocBO oBO = new CLocBO();
                CResult oResult = new CResult();
                CLocation oLoc = new CLocation();
                oLoc = GetToSavedData();
                if (!m_IsUpdateMode)
                {
                    oResult = oBO.Create(oLoc);
                }
                else
                {
                    oLoc.Loc_OID = txtSelectedID.Text.Trim();
                    oResult = oBO.Update(oLoc);
                }
                if (oResult.IsSuccess)
                {
                    ClearFormData();
                    ReadLocationAllData();
                }
                else
                {
                    MessageBox.Show(oResult.ErrMsg.ToString(), "Error  ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            CLocBO oBO = new CLocBO();
            CResult oResult = new CResult();
            CLocation oLoc = new CLocation();
            oLoc = GetToSavedData();
            if (m_IsUpdateMode)
            {
                if ((MessageBox.Show("Are you sure to Delete this ? ", "Warning  ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) == DialogResult.Yes)
                {
                    oLoc.Loc_OID = txtSelectedID.Text.Trim();
                    oResult = oBO.Delete(oLoc);

                    if (oResult.IsSuccess)
                    {
                        if (oResult.Data.ToString() == "0")
                        {

                            MessageBox.Show("Deletion Not Possible", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFormData();


                        }
                        else
                        {
                            MessageBox.Show("Deleted successfully");
                            ClearFormData();

                        }
                    }
                    
                    else
                    {
                        MessageBox.Show(oResult.ErrMsg.ToString(), "Error  ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearFormData();
            ReadLocationAllData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
        #endregion

        private void frmLocation_Load(object sender, EventArgs e)
        {
            FormControlMode(0);
            ReadLocationAllData();
            
        }

        private void lstLocationList_Click(object sender, EventArgs e)
        {
            if (lstLocationList.Items.Count > 0)
            {
                CLocation objLoc = (CLocation)lstLocationList.SelectedItem;
                txtSelectedID.Text = objLoc.Loc_OID.ToString();
                txtCode.Text = objLoc.Loc_Code;
                txtName.Text = objLoc.Loc_Name;
                FormControlMode(1);
            }
        }
        
    }
}