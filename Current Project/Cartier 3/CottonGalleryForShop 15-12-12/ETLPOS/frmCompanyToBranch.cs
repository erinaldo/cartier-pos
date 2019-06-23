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
    public partial class frmCompanyToBranch : BaseForm
    {
        public frmCompanyToBranch()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmCompanyToBranch_Load(object sender, EventArgs e)
        {
            LoadALL();
            LoadAllCompany();
            LoadAllBranch();
        }




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
                cmbBranch.ValueMember = "CompBrn_OId";
                cmbBranch.SelectedIndex = -1;




            }
        }

        private void LoadAllCompany()
        {
            List<CCompany> oList;
            CCompanyBO oCompanyBO = new CCompanyBO();
            CResult oResult = new CResult();

            oResult = oCompanyBO.ReadAll();

            if (oResult.IsSuccess)
            {
                oList = (List<CCompany>)oResult.Data;
                //Load_lv_CCSDDSS(oList);

                // ArrayList oEmployeeList = oResult.Data as ArrayList;
                cmbCompany.DataSource = oList;
                cmbCompany.DisplayMember = "Comp_Name";
                cmbCompany.ValueMember = "Comp_OID";
                cmbCompany.SelectedIndex = -1;




            }
        }

        private void btnCompany_Click(object sender, EventArgs e)
        {
            frmCompany oComp = new frmCompany();
            oComp.Show();
        }

        private void btnBranch_Click(object sender, EventArgs e)
        {
            frmCompanyBranch oCBran = new frmCompanyBranch();
            oCBran.Show();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CCVBBO oCVBO = new CCVBBO();
            CResult oResult = new CResult();


            if (ValidateToSaveData())
            {
                oResult = oCVBO.Create(GetToSaveData());


                if (oResult.IsSuccess)
                {
                    if (oResult.Data.ToString() == "0")
                    {

                        MessageBox.Show("Duplicate Relation Is Not Possible", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFormData();
                        LoadALL();

                    }
                    else
                    {
                        MessageBox.Show("Successfully Saved");
                        ClearFormData();
                        LoadALL();
                    }
                }
                
                             
           
            else
            {
                MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
            
            
            }

        }
        private bool ValidateToSaveData()
        {
            
            if (cmbCompany.Text == "")
            {
                MessageBox.Show("Please Enter Company Name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbCompany.Focus();
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
            oCVB.OID = txtHiddenOID.Text;
            oCVB.Company = cmbCompany.SelectedValue.ToString();
            oCVB.Branch = cmbBranch.SelectedValue.ToString();

            return oCVB;
        }

        private void ClearFormData()
        {
            txtHiddenOID.Text = "";
            cmbCompany.SelectedIndex = -1;
            cmbBranch.SelectedIndex = -1;
              
        
        }

        private void LoadALL()
        {
            lvCVBList.Items.Clear();
            CCVBBO oCVBBO = new CCVBBO();
            CResult oResult = new CResult();
            CCVB oCVB = new CCVB();

            oResult = oCVBBO.ReadAllCVB(oCVB);
            if (oResult.IsSuccess)
            {
                foreach (CCVB obj in oResult.Data as  ArrayList)
                {
                    ListViewItem oItem = new ListViewItem();
                    oItem.Text = obj.OID.ToString();
                    oItem.SubItems.Add(obj.Comp_OID).ToString();
                    oItem.SubItems.Add(obj.Bran_OID).ToString();
                    oItem.SubItems.Add(obj.Company.ToString());
                    oItem.SubItems.Add(obj.Branch).ToString();


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
                    cmbCompany.Text = oItem.SubItems[3].Text;
                    cmbBranch.Text = oItem.SubItems[4].Text;
                    
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Are you want to delete " + cmbCompany.Text + " ?", "Confirmation!", MessageBoxButtons.OKCancel))
            {
              //  CCVB oCVB = GetToSaveData();
                CCVBBO oCVBBO = new CCVBBO();
                CResult oResult = new CResult();
                string oid = txtHiddenOID.Text;
                string Branch = cmbBranch.SelectedValue.ToString(); 
                if (txtHiddenOID.Text != string.Empty)
                {
                    oResult = oCVBBO.Delete(oid, Branch);
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
                LoadALL();
            }
        }





    }
}
