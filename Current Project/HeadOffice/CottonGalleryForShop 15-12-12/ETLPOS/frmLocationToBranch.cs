using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ETL.BLL;
using ETL.Model;
using ETL.Common;


namespace ETLPOS
{
    public partial class frmLocationToBranch : BaseForm
    {
        public frmLocationToBranch()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtLoginID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtPassward_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbUserName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtCPassward_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmLocationToBranch_Load(object sender, EventArgs e)
        {
            LoadAllBranch();
            LoadAllLocation();
            LoadALLBVL();
        }




        //private void LoadBranch()
        //{
        //   // lvUserList.Items.Clear();
        //    CCompanyBranchBO oCompanyBranchBO = new CCompanyBranchBO();
        //    CResult oResult = new CResult();
        //    CCompanyBranch oCompanyBranch = new CCompanyBranch();

        //    oResult = oCompanyBranchBO.ReadAll();
        //    if (oResult.IsSuccess)
        //    {
        //        foreach (CCompanyBranch obj in oResult.Data as ArrayList)
        //        {
                    
                    
        //           // ListViewItem oItem = new ListViewItem();
        //            ArrayList oItemList = oResult.Data as ArrayList;
        //            cmbBranch.DataSource = oItemList;
        //            cmbBranch.DisplayMember = "CompBrn_Name";
        //            cmbBranch.ValueMember = "CompBrn_Code";
        //            cmbBranch.SelectedIndex = -1;
                    
                    
        //            //oItem.Text = obj.CompBrn_Name.ToString();
        //            //oItem.SubItems.Add(obj.CompBrn_Code.ToString());
                
        //           // lvUserList.Items.Add(oItem);
        //        }







        //        //dgvUserList.DataSource = oResult.Data;
        //    }
        //    else
        //    {
        //        MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}


        private void LoadAllBranch()
        {
            List<CCompanyBranch> oList;
            CCompanyBranchBO oCompanyBranchBO = new CCompanyBranchBO();
            CResult oResult = new CResult();

            oResult = oCompanyBranchBO.ReadAll();

            if (oResult.IsSuccess)
            {
                oList = (List<CCompanyBranch>)oResult.Data;
                //Load_lv_CCSDDSS(oList);

                // ArrayList oEmployeeList = oResult.Data as ArrayList;
                cmbBranch.DataSource = oList;
                cmbBranch.DisplayMember = "CompBrn_Name";
                cmbBranch.ValueMember = "CompBrn_OID";
                cmbBranch.SelectedIndex = -1;




            }
        }



        private void LoadAllLocation()
        {
           // List<CLocation> oList;
            CLocBO oLocationBO = new CLocBO();
            CResult oResult = new CResult();
            CLocation oLocation = new CLocation();

            oResult = oLocationBO.ReadAll();

            if (oResult.IsSuccess)
            {
               // oList = (List<CLocation>)oResult.Data;
                //Load_lv_CCSDDSS(oList);

                ArrayList oLocList = oResult.Data as ArrayList;
                cmbLocation.DataSource = oLocList;
                cmbLocation.DisplayMember = "Loc_Name";
                cmbLocation.ValueMember = "Loc_OId";
                cmbLocation.SelectedIndex = -1;




            }
        }

        private void btnBranch_Click(object sender, EventArgs e)
        {
            frmCompanyBranch obran = new frmCompanyBranch();
            obran.Show();
        }

        private void btnLocation_Click(object sender, EventArgs e)
        {
            frmLocation oLoc = new frmLocation();
            oLoc.Show();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CCVBBO oCVBO = new CCVBBO();
            CResult oResult = new CResult();
            string Branch = cmbBranch.SelectedValue.ToString();
            string Location = cmbLocation.SelectedValue.ToString();

            if (ValidateToSaveData())
            {
                oResult = oCVBO.CreateBVL(Branch, Location);
            }


            if (oResult.IsSuccess)
            {
                if (oResult.Data.ToString() == "0")
                {

                    MessageBox.Show("Duplicate Relation Is Not Possible", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFormData();
                    LoadALLBVL();

                }
                else
                {
                    MessageBox.Show("Successfully Saved");
                    ClearFormData();
                    LoadALLBVL();
                }
            }



            else
            {
                MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
 
        }


        private bool ValidateToSaveData()
        {

            if (cmbLocation.Text == "")
            {
                MessageBox.Show("Please Enter Company Name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbLocation.Focus();
                return false;
            }

            if (cmbBranch.Text == "")
            {
                MessageBox.Show("Please Select Branch", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbBranch.Focus();
                return false;
            }

            else
                return true;
        }

        private CCVB GetToSaveData()
        {
            CCVB oCVB = new CCVB();
            oCVB.OID = txtHiddenOID.Text.ToString();
           // oCVB.Company = cmbLocation.SelectedValue.ToString();
            oCVB.Branch = cmbBranch.SelectedValue.ToString();
            oCVB.Location = cmbLocation.SelectedValue.ToString();

            return oCVB;
        }

        private void ClearFormData()
        {
            cmbLocation.SelectedIndex = -1;
            cmbBranch.SelectedIndex = -1;


        }

        private void LoadALLBVL()
        {
            lvCVBList.Items.Clear();
            CCVBBO oCVBBO = new CCVBBO();
            CResult oResult = new CResult();
            CCVB oCVB = new CCVB();

            oResult = oCVBBO.ReadAllBVL(oCVB);
            if (oResult.IsSuccess)
            {
                foreach (CCVB obj in oResult.Data as ArrayList)
                {
                    ListViewItem oItem = new ListViewItem();

                    oItem.Text = obj.OID.ToString();
                    oItem.SubItems.Add(obj.Bran_OID).ToString();
                    oItem.SubItems.Add(obj.Loc_OID).ToString();
                    oItem.SubItems.Add(obj.Branch).ToString();
                    oItem.SubItems.Add(obj.Location).ToString();


                    lvCVBList.Items.Add(oItem);
                }
            }
            else
            {
                MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lvCVBList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCVBList.SelectedIndices.Count > 0)
            {
                ListViewItem oItem = lvCVBList.SelectedItems[0];
                if (oItem != null)
                {
                    txtHiddenOID.Text = oItem.Text;
                    cmbBranch.Text = oItem.SubItems[3].Text;
                    cmbLocation.Text = oItem.SubItems[4].Text;
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Are you want to delete " + cmbBranch.Text + " ?", "Confirmation!", MessageBoxButtons.OKCancel))
            {
              //  CCVB oCVB = GetToSaveData();
                CCVBBO oCVBBO = new CCVBBO();
                CResult oResult = new CResult();
                string oid = txtHiddenOID.Text;
                string location = cmbLocation.SelectedValue.ToString();
                if (txtHiddenOID.Text != string.Empty)
                {
                    oResult = oCVBBO.DeleteBVL(oid, location);
                }

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
                    MessageBox.Show(oResult.ErrMsg);
                }
                LoadALLBVL();
            }
        }




    
    }
}
