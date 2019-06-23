using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using ETL.BLL;
using ETL.Model;
using ETL.Common;
using ETL.DAO;



namespace ETLPOS
{
    public partial class frmEmployee : BaseForm
    {
        public frmEmployee()
        {
            InitializeComponent();
        }

        #region "Declarations"

        ArrayList arDesignationList;
        ArrayList arGradeList;
        ArrayList arUnitList;
        ArrayList arSectionList;
        ArrayList arBlockList;
        ArrayList arFloorList;
        ArrayList arEmployeeList;
        ArrayList arShiftList;
        ArrayList arEducationList;

        bool IsUpdateMode = false;

        #endregion
      

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            //LoadEmployeeData();
            //btnDelete.Enabled = false;
            // btnSave.Enabled = false;
           // btnClear.Enabled = false;
            //LoadDesignation();
            //LoadGrade();
            //LoadUnit();
            //LoadSection();
            //LoadBlock();
            //LoadFloor();
            //LoadShift();
            //LoadEducationalData();
            cmdType.SelectedIndex = 0;
            cmdBloodGroup.SelectedIndex = 0;
            cmbSex.SelectedIndex = 0;
            FormControlMode(0);
            
            // Displaydata();

        }



        //private void LoadEmployeeData()
        //{
            
        //    CEmployeeBO oBO = new CEmployeeBO();
        //    CResult oResult = new CResult();
        //    CEmployee oEmployee = new CEmployee();

        //    oResult = oBO.ReadAllEmployee(oEmployee);
        //    if (oResult.IsSuccess)
        //    {
        //        arEmployeeList = (ArrayList)oResult.Data;

        //    }
        //    else
        //    {
        //        MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        
        
        
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            ClearFormData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateToSaveData())
            {
                CEmployeeBO oEmployeeBO = new CEmployeeBO();
                CResult oResult = new CResult();
                string ID = txtHiddenID.Text;
                if (txtHiddenID.Text.Trim() != string.Empty)
                {
                    if (DialogResult.OK == MessageBox.Show("Are you want to upadte " + txtName.Text + " ?", "Confirmation!", MessageBoxButtons.OKCancel))
                    {
                        oResult = oEmployeeBO.Update(GetToSaveData());
                    }
                }
                else
                {
                    oResult = oEmployeeBO.Create(GetToSaveData());
                }
                if (oResult.IsSuccess)
                {
                    ClearFormData();
                    // LoadUnitData();
                    MessageBox.Show("Successfully Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // btnSave.Enabled = false;
                   // btnAddNew.Enabled = true;
                }
                else
                {
                    MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }




        }



        private bool ValidateToSaveData()
        {

            if (txtEmployee.Text == "")
            {
                MessageBox.Show("Please Enter Employee ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmployee.Focus();
                return false;
            }

            if (txtName.Text == "")
            {
                MessageBox.Show("Please Enter Employee Name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return false;
            }


            else
                return true;
        }
        private CEmployee GetToSaveData()
        {
            CEmployee oEmployee = new CEmployee();
            oEmployee.ID = txtHiddenID.Text;
            oEmployee.EmpID = txtEmployee.Text;
            oEmployee.Name = txtName.Text;
            oEmployee.FName = txtFName.Text;
            oEmployee.MName = txtMName.Text;
            oEmployee.SName = txtSName.Text;
            oEmployee.PerAddress = txtPerAdd.Text;
            oEmployee.PerDistrict = txtPerDistrict.Text;
            oEmployee.PreAddress = txtPreAdd.Text;
            oEmployee.PreDistrict = txtPreDistrict.Text;
            oEmployee.DOB = dtDOB.Value.Date;
            oEmployee.BloodGroup = cmdBloodGroup.Text;
            oEmployee.DOJ = dtDOJ.Value.Date;
            oEmployee.PcardNo = txtPCardNo.Text;
            oEmployee.Sex = cmbSex.Text;
            oEmployee.UnitID = cmdUnitList.Text;
            oEmployee.EmployeeType = cmdType.Text;
            oEmployee.FloorID = cmdFloorList.Text;
            oEmployee.SectionID = cmdSectionList.Text;
            oEmployee.BlockID = cmdBlockList.Text;
            oEmployee.DesignationID = cmdDesignationList.Text;
            oEmployee.GradeID = cmdGradeList.Text;
            oEmployee.Shift = cmbShift.Text;
            oEmployee.Basic = txtBasic.Text;
            oEmployee.HouseRent = txtHRent.Text;
            oEmployee.Medical = txtMedical.Text;
            oEmployee.Conveyance = txtConveyance.Text;
            oEmployee.IsAllowance = chkAllowance.Checked;
            oEmployee.IsAttendanceBonus = chkAttendanceBonus.Checked;
            oEmployee.IsOT = chkOT.Checked;
            oEmployee.IsActive = chkStatus.Checked;
            oEmployee.Education = cmbEducation.Text;
            oEmployee.Remarks = txtRemarks.Text;




            return oEmployee;
        }
        private void ClearFormData()
        {
            txtHiddenID.Text = "";
            txtEmployee.Text = "";
            txtName.Text = "";
            cmdType.SelectedIndex = -1;
            txtFName.Text = "";
            txtMName.Text = "";
            txtSName.Text = "";
            txtPerAdd.Text = "";
            txtPerDistrict.Text = "";
            txtPreAdd.Text = "";
            txtPreDistrict.Text = "";
            txtPCardNo.Text = "";
            FormControlMode(0);

        }


        void ofrmEmployeeSearch_EEvent(object Sender, EEventArgEmployee e)
        {
            ClearFormData();
            CEmployee obj = (CEmployee)e.Employee;
            Displaydata(obj);

        }

        private void FormControlMode(int i)
        {
            switch (i)
            {
                case 0:
                    btnSave.Text = "Save";
                    btnDelete.Enabled = false;
                    IsUpdateMode = false;
                    txtEmployee.Enabled = true;
                    break;
                case 1:
                    btnSave.Text = "Update";
                    btnDelete.Enabled = true;
                    IsUpdateMode = true;
                    txtEmployee.Enabled = false;
                    break;
            }
        }

        private void Displaydata(CEmployee objEmployee)
        {
            txtHiddenID.Text = objEmployee.ID;
            txtEmployee.Text = objEmployee.EmpID;
            txtName.Text = objEmployee.Name;
            DisplaySelectedEmployeeData();           
           
        }
                
        private void btnLoad_Click(object sender, EventArgs e)
        {
            frmEmployeeSearch ofrmEmployeeSearch = new frmEmployeeSearch();
            ofrmEmployeeSearch.EEvent += new frmEmployeeSearch.EEventhandler(ofrmEmployeeList_EEvent);
            ofrmEmployeeSearch.ShowDialog();
                     
        }

        void ofrmEmployeeList_EEvent(object Sender, EEventArgEmployee e)
        {
            ClearFormData();
            CEmployee obj = (CEmployee)e.Employee;
            Displaydata(obj);
        }


        //void ofrmEmployeeSearch_EEvent(object Sender, EEventArg e)
        //{
        //    ClearFormData();
        //    CEmployee obj = (CEmployee)e.Employee;
        //    Displaydata(obj);

        //}


        //private void Displaydata(CEmployee objEmployee)
        //{

        //    txtEmployee.Text = objEmployee.EmpID;
        //    txtName.Text = objEmployee.Name;




        //    //txtOrderID.Text = objEmployee.OrderID;
        //    //txtBankRef.Text = objEmployee.BankRef.Trim();
        //    //txtReceivingDate.Text = objEmployee.ODate.ToString("dd-MM-yyyy");
        //    //txtSubmissiondate.Text = objEmployee.RelDate.ToString("dd-MM-yyyy");
        //    DisplaySelectedEmployeeData();
        //    // gbPersonalDetails.Focus();
        //}


        private void DisplaySelectedEmployeeData()
        {

            DataTable dtEmployee = new DataTable();

            CEmployeeBO oEmployeeBO = new CEmployeeBO();
            CResult oResult = new CResult();
            CEmployee oEmployee = new CEmployee();
            oEmployee.EmpID = txtEmployee.Text.Trim();  // txtOrderID.Text.Trim();
            oResult = oEmployeeBO.ReadEmployeeByCond(oEmployee);

            if ((oResult.IsSuccess))
            {
                dtEmployee = oResult.Data as DataTable;
            }

            else
            {

                MessageBox.Show("Error");

            }


            DataRow drEmployee = dtEmployee.Rows[0];
            txtName.Text = drEmployee[2].ToString();
            txtFName.Text = drEmployee[3].ToString();
                     
            txtMName.Text = drEmployee[4].ToString();
            txtSName.Text = drEmployee[5].ToString();
            txtPerAdd.Text = drEmployee[6].ToString();
            txtPerDistrict.Text = drEmployee[7].ToString();
            txtPreAdd.Text = drEmployee[8].ToString();
            txtPreDistrict.Text = drEmployee[9].ToString();
            cmdType.Text = drEmployee[16].ToString();
            cmdBloodGroup.Text = drEmployee[11].ToString();
            cmbSex.Text = drEmployee[14].ToString();
            dtDOB.Text = drEmployee[10].ToString();
            cmbEducation.Text = drEmployee[31].ToString();
            

            FormControlMode(1);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ValidateToSaveData())
            {
                CEmployeeBO oEmployeeBO = new CEmployeeBO();
                CResult oResult = new CResult();
                string ID = txtHiddenID.Text;
                if (txtHiddenID.Text.Trim() != string.Empty)
                {
                    if (DialogResult.OK == MessageBox.Show("Are You Want to Delete " + txtName.Text + " ?", "Confirmation!", MessageBoxButtons.OKCancel))
                    {
                        oResult = oEmployeeBO.Delete(GetToSaveData());
                    }
                                    
                }
                if (oResult.IsSuccess)
                {
                    ClearFormData();
            
                    MessageBox.Show("Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

        }

       

        
        //private void DisplaySelectedEmployeeData()
        //{

        //    DataTable dtEmployee = new DataTable();

        //    CEmployeeBO oEmployeeBO = new CEmployeeBO();
        //    CResult oResult = new CResult();
        //    CEmployee oEmployee = new CEmployee();
        //    oEmployee.EmpID = txtEmployee.Text.Trim();  // txtOrderID.Text.Trim();
        //    oResult = oEmployeeBO.ReadEmployeeByCond(oEmployee);

        //    if ((oResult.IsSuccess))
        //    {
        //        dtEmployee = oResult.Data as DataTable;
        //    }

        //    else
        //    {

        //        MessageBox.Show("Error");
            
        //    }
           

        //    DataRow drEmployee = dtEmployee.Rows[0];
        //    txtName.Text = drEmployee[2].ToString();
        //    cmdType.Text = drEmployee[16].ToString();
        //    txtFName.Text = drEmployee[3].ToString();

        //    //// string[] arDataList = new string[280];

        //    //// arDataList[0] = "";
        //    ////arDataList[1] = "";
        //    //txtApplicantsName.Text = drEmployee[2].ToString();
        //    ////arDataList[3] = "";
        //    ////arDataList[4] = "";
        //    //if (drEmployee[4].ToString() == "Yes")
        //    //{
        //    //    txtApplicantNamechk1.Checked = true;
        //    //}
        //    //else if (drEmployee[4].ToString() == "No")
        //    //{
        //    //    txtApplicantNamechk2.Checked = true;
        //    //}


        //    ////arDataList[5] = 
        //    //txtProfession.Text = drEmployee[5].ToString();
        //    ////arDataList[6] = "";
        //    ////arDataList[7] = "";
        //    //if (drEmployee[7].ToString() == "Yes")
        //    //{
        //    //    txtProfessionchk1.Checked = true;
        //    //}
        //    //else if (drEmployee[7].ToString() == "No")
        //    //{
        //    //    txtProfessionchk2.Checked = true;
        //    //}

        //    //txtNoOfEmp.Text = drEmployee[102].ToString();
        //    //if (drEmployee[104].ToString() == "Yes")
        //    //{
        //    //    NOEAuthenticityChk1.Checked = true;
        //    //}
        //    //else if (drEmployee[104].ToString() == "No")
        //    //{
        //    //    NOEAuthenticityChk2.Checked = true;

        //    //}


        //    ////arDataList[8] = txtPhoneOff.Text;
        //    //txtPhoneOff.Text = drEmployee[8].ToString();
        //    ////    arDataList[9] = "";
        //    ////  arDataList[10] = "";
        //    //if (drEmployee[10].ToString() == "Yes")
        //    //{
        //    //    txtPhoneOffchk1.Checked = true;
        //    //}
        //    //else if (drEmployee[10].ToString() == "No")
        //    //{
        //    //    txtPhoneOffchk2.Checked = true;
        //    //}

        //    ////arDataList[11] = txtPhoneOff.Text;
        //    //txtRsidence.Text = drEmployee[11].ToString();

        //    //// arDataList[12] = "";
        //    ////arDataList[13] = "";
        //    //if (drEmployee[13].ToString() == "Yes")
        //    //{
        //    //    txtRsidencechk1.Checked = true;
        //    //}
        //    //else if (drEmployee[13].ToString() == "No")
        //    //{
        //    //    txtRsidencechk2.Checked = true;
        //    //}

        //    ////arDataList[14] = txtMobile.Text;
        //    //txtMobile.Text = drEmployee[14].ToString();
        //    //// arDataList[15] = "";
        //    ////arDataList[16] = "";
        //    //if (drEmployee[16].ToString() == "Yes")
        //    //{
        //    //    txtMobilechk1.Checked = true;
        //    //}
        //    //else if (drEmployee[16].ToString() == "No")
        //    //{
        //    //    txtMobilechk2.Checked = true;
        //    //}

           


        //}   

       


        //private void LoadDesignation()
        //{
        //    CEmployeeBO oEmployeeBO = new CEmployeeBO();

        //    CResult oResult = new CResult();
        //    CDesignation oDesignation = new CDesignation();

        //    oResult = oEmployeeBO.ReadDesignation(oDesignation);
        //    if (oResult.IsSuccess)
        //    {
        //        arDesignationList = oResult.Data as ArrayList;

        //        cmdDesignationList.DisplayMember = "Name";
        //        cmdDesignationList.ValueMember = "ID";

        //        cmdDesignationList.DataSource = arDesignationList;

        //        //foreach (CCompany obj in arCompanyList)
        //        //{
        //        //    ddlCompanyList.Items.Add(obj);

        //        //    ddlCompanyList.DisplayMember = "CompanyName";
        //        //    ddlCompanyList.ValueMember = "CompanyID";
        //        //}
        //    }
        //    else
        //    {
        //        MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    cmdDesignationList.SelectedIndex = -1;
        //}

        //private void LoadGrade()
        //{
        //    CEmployeeBO oEmployeeBO = new CEmployeeBO();

        //    CResult oResult = new CResult();
        //    CGrade oGrade = new CGrade();

        //    oResult = oEmployeeBO.ReadGrade(oGrade);
        //    if (oResult.IsSuccess)
        //    {
        //        arGradeList = oResult.Data as ArrayList;

        //        cmdGradeList.DisplayMember = "Name";
        //        cmdGradeList.ValueMember = "ID";

        //        cmdGradeList.DataSource = arGradeList;

        //        //foreach (CCompany obj in arCompanyList)
        //        //{
        //        //    ddlCompanyList.Items.Add(obj);

        //        //    ddlCompanyList.DisplayMember = "CompanyName";
        //        //    ddlCompanyList.ValueMember = "CompanyID";
        //        //}
        //    }
        //    else
        //    {
        //        MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    cmdGradeList.SelectedIndex = -1;
        //}

        //private void LoadUnit()
        //{
        //    CEmployeeBO oEmployeeBO = new CEmployeeBO();

        //    CResult oResult = new CResult();
        //    CUnit oUnit = new CUnit();

        //    oResult = oEmployeeBO.ReadUnit(oUnit);
        //    if (oResult.IsSuccess)
        //    {
        //        arUnitList = oResult.Data as ArrayList;

        //        cmdUnitList.DisplayMember = "Name";
        //        cmdUnitList.ValueMember = "ID";

        //        cmdUnitList.DataSource = arUnitList;

        //        //foreach (CCompany obj in arCompanyList)
        //        //{
        //        //    ddlCompanyList.Items.Add(obj);

        //        //    ddlCompanyList.DisplayMember = "CompanyName";
        //        //    ddlCompanyList.ValueMember = "CompanyID";
        //        //}
        //    }
        //    else
        //    {
        //        MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //   cmdUnitList.SelectedIndex = -1;
        //}

        //private void LoadSection()
        //{
        //    CEmployeeBO oEmployeeBO = new CEmployeeBO();

        //    CResult oResult = new CResult();
        //    CSection oSection = new CSection();

        //    oResult = oEmployeeBO.ReadSection(oSection);
        //    if (oResult.IsSuccess)
        //    {
        //        arSectionList = oResult.Data as ArrayList;

        //        cmdSectionList.DisplayMember = "Name";
        //        cmdSectionList.ValueMember = "ID";

        //        cmdSectionList.DataSource = arSectionList;

        //        //foreach (CCompany obj in arCompanyList)
        //        //{
        //        //    ddlCompanyList.Items.Add(obj);

        //        //    ddlCompanyList.DisplayMember = "CompanyName";
        //        //    ddlCompanyList.ValueMember = "CompanyID";
        //        //}
        //    }
        //    else
        //    {
        //        MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    cmdSectionList.SelectedIndex = -1;
        //}

        //private void LoadBlock()
        //{
        //    CEmployeeBO oEmployeeBO = new CEmployeeBO();

        //    CResult oResult = new CResult();
        //    CBlock oBlock = new CBlock();

        //    oResult = oEmployeeBO.ReadBlock(oBlock);
        //    if (oResult.IsSuccess)
        //    {
        //        arBlockList = oResult.Data as ArrayList;

        //        cmdBlockList.DisplayMember = "Name";
        //        cmdBlockList.ValueMember = "ID";

        //        cmdBlockList.DataSource = arBlockList;

        //        //foreach (CCompany obj in arCompanyList)
        //        //{
        //        //    ddlCompanyList.Items.Add(obj);

        //        //    ddlCompanyList.DisplayMember = "CompanyName";
        //        //    ddlCompanyList.ValueMember = "CompanyID";
        //        //}
        //    }
        //    else
        //    {
        //        MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    cmdBlockList.SelectedIndex = 0;
        //}

        //private void LoadFloor()
        //{
        //    CEmployeeBO oEmployeeBO = new CEmployeeBO();

        //    CResult oResult = new CResult();
        //    CFloor oFloor = new CFloor();

        //    oResult = oEmployeeBO.ReadFloor(oFloor);
        //    if (oResult.IsSuccess)
        //    {
        //        arFloorList = oResult.Data as ArrayList;

        //        cmdFloorList.DisplayMember = "Name";
        //        cmdFloorList.ValueMember = "ID";

        //        cmdFloorList.DataSource = arFloorList;

        //        //foreach (CCompany obj in arCompanyList)
        //        //{
        //        //    ddlCompanyList.Items.Add(obj);

        //        //    ddlCompanyList.DisplayMember = "CompanyName";
        //        //    ddlCompanyList.ValueMember = "CompanyID";
        //        //}
        //    }
        //    else
        //    {
        //        MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //   // ddlFloorList.SelectedIndex = 0;
        //}

        //private void LoadShift()
        //{
        //    CEmployeeBO oEmployeeBO = new CEmployeeBO();
            
        //    CResult oResult = new CResult();
        //    CShift oShift = new CShift();

        //    oResult = oEmployeeBO.ReadShift(oShift);
        //    if (oResult.IsSuccess)
        //    {
        //        arShiftList = oResult.Data as ArrayList;

        //        cmbShift.DisplayMember = "Name";
        //        cmbShift.ValueMember = "ID";

        //        cmbShift.DataSource = arShiftList;

        //        //foreach (CCompany obj in arCompanyList)
        //        //{
        //        //    ddlCompanyList.Items.Add(obj);

        //        //    ddlCompanyList.DisplayMember = "CompanyName";
        //        //    ddlCompanyList.ValueMember = "CompanyID";
        //        //}
        //    }
        //    else
        //    {
        //        MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //   cmbShift.SelectedIndex = -1;
        //}

        //private void LoadEducationalData()
        //{
        //    CEmployeeBO oEmployeeBO = new CEmployeeBO();

        //    CResult oResult = new CResult();
        //    CEducation oEducation = new CEducation();
            
        //    oResult = oEmployeeBO.ReadEducationData(oEducation);
        //    if (oResult.IsSuccess)
        //    {
        //        arEducationList = oResult.Data as ArrayList;

        //        cmdEducation.DisplayMember = "Name";
        //        cmdEducation.ValueMember = "ID";

        //        cmdEducation.DataSource = arEducationList;

        //        //foreach (CCompany obj in arCompanyList)
        //        //{
        //        //    ddlCompanyList.Items.Add(obj);

        //        //    ddlCompanyList.DisplayMember = "CompanyName";
        //        //    ddlCompanyList.ValueMember = "CompanyID";
        //        //}
        //    }
        //    else
        //    {
        //        MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    cmdEducation.SelectedIndex = -1;
        //}



        //private void btnLoad_Click(object sender, EventArgs e)
        //{
        //    frmEmployeeSearch ofrmEmployeeSearch = new frmEmployeeSearch();

        //    //frmSearchPersonSrvc ofrmSearchPersonSrvc = new frmSearchPersonSrvc();

        //    ofrmEmployeeSearch.EEvent += new frmEmployeeSearch.EEventhandler(ofrmEmployeeSearch_EEvent);
        //    //   ofrmSearchPersonSrvc.PSEvent += new frmSearchPersonSrvc.PSEventhandler(ofrmSearchPersonSrvc_PSEvent);
        //    ofrmEmployeeSearch.ShowDialog();

        //}

        //private void ddlGradeList_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if ((cmdDesignationList.Text == "MD") && (cmdGradeList.Text == "Grade A"))
        //    {
        //        txtBasic.Text = "20000";
        //        txtHRent.Text = "8000";
        //        txtMedical.Text = "2000";
        //        txtConveyance.Text = "3000";
               
                        
        //    }
        //    if ((cmdDesignationList.Text == "Programmer") && (cmdGradeList.Text == "Grade A"))
        //    {
        //        txtBasic.Text = "10000";
        //        txtHRent.Text = "4000";
        //        txtMedical.Text = "500";
        //        txtConveyance.Text = "500";


        //    }
        
        
        
        
        //}

     
       




    }
}