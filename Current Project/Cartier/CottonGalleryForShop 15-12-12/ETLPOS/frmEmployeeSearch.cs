using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ETL.Model;
using ETL.Common;
using ETL.BLL;


namespace ETLPOS
{
    public partial class frmEmployeeSearch : BaseForm
    {

        #region "Declarations"
        ArrayList arrList;
        public delegate void EEventhandler(object Sender, EEventArgEmployee e);
        public event EEventhandler EEvent;


        public virtual void ESelectedEvent(EEventArgEmployee arg)
        {
            if (EEvent != null)
                EEvent(this, arg);
        }



        
        #endregion
        
        
        
        
        
        public frmEmployeeSearch()
        {
            InitializeComponent();
        }

        private void frmEmployeeSearch_Load(object sender, EventArgs e)
        {
            //LoadUnit();
            //LoadFloor();
            //LoadSection();
            //LoadBlock();
            //LoadShift();
            //LoadDesignation();
            //LoadEducation();


            LoadEmployeeData();
          
        }

        //private void LoadUnit()
        //{
        //    CSetUpBO oSetUpBO = new CSetUpBO();

        //    CResult oResult = new CResult();
        //    CUnit oUnit = new CUnit();

        //    oResult = oSetUpBO.ReadUnit(oUnit);
        //    if (oResult.IsSuccess)
        //    {
        //        arrList = oResult.Data as ArrayList;

        //        cmbUnit.DisplayMember = "Name";
        //        cmbUnit.ValueMember = "ID";

        //        cmbUnit.DataSource = arrList;

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
        //  cmbUnit.SelectedIndex = -1;
        //}
        ////private void LoadFloor()
        //{
        //    CSetUpBO oSetUpBO = new CSetUpBO();

        //    CResult oResult = new CResult();
        //    CFloor oFloor = new CFloor();

        //    oResult = oSetUpBO.ReadFloor(oFloor);
        //    if (oResult.IsSuccess)
        //    {
        //        arrList = oResult.Data as ArrayList;
                
        //        cmbFloor.DisplayMember = "Name";
        //        cmbFloor.ValueMember = "ID";

        //        cmbFloor.DataSource = arrList;

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
        //   cmbFloor.SelectedIndex = -1;
        //}
        //private void LoadSection()
        //{
        //    CSetUpBO oSetUpBO = new CSetUpBO();

        //    CResult oResult = new CResult();
        //    CSection oSection = new CSection();

        //    oResult = oSetUpBO.ReadSection(oSection);
        //    if (oResult.IsSuccess)
        //    {
        //        arrList = oResult.Data as ArrayList;

        //        cmbSection.DisplayMember = "Name";
        //        cmbSection.ValueMember = "ID";

        //        cmbSection.DataSource = arrList;

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
        //   cmbSection.SelectedIndex = -1;
        //}
        //private void LoadBlock()
        //{
        //    CSetUpBO oSetUpBO = new CSetUpBO();

        //    CResult oResult = new CResult();
        //    CBlock oBlock = new CBlock();

        //    oResult = oSetUpBO.ReadBlock(oBlock);
        //    if (oResult.IsSuccess)
        //    {
        //        arrList = oResult.Data as ArrayList;

        //        cmbBlock.DisplayMember = "Name";
        //        cmbBlock.ValueMember = "ID";

        //        cmbBlock.DataSource = arrList;

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
        //    cmbBlock.SelectedIndex = -1;
        //}
        //private void LoadShift()
        //{
        //    CSetUpBO oSetUpBO = new CSetUpBO();

        //    CResult oResult = new CResult();
        //    CShift oShift = new CShift();

        //    oResult = oSetUpBO.ReadShift(oShift);
        //    if (oResult.IsSuccess)
        //    {
        //        arrList = oResult.Data as ArrayList;

        //        cmbShift.DisplayMember = "Name";
        //        cmbShift.ValueMember = "ID";

        //        cmbShift.DataSource = arrList;

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
        //    cmbShift.SelectedIndex = -1;
        //}
        //private void LoadDesignation()
        //{
        //    CSetUpBO oSetUpBO = new CSetUpBO();

        //    CResult oResult = new CResult();
        //    CDesignation oDesignation = new CDesignation();

        //    oResult = oSetUpBO.ReadDesignation(oDesignation);
        //    if (oResult.IsSuccess)
        //    {
        //        arrList = oResult.Data as ArrayList;

        //        cmbDesignation.DisplayMember = "Name";
        //        cmbDesignation.ValueMember = "ID";

        //        cmbDesignation.DataSource = arrList;

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
        //    cmbDesignation.SelectedIndex = -1;
        //}
        //private void LoadEducation()
        //{
        //    CSetUpBO oSetUpBO = new CSetUpBO();

        //    CResult oResult = new CResult();
        //    CEducation oEducation = new CEducation();

        //    oResult = oSetUpBO.ReadEducationData(oEducation);
        //    if (oResult.IsSuccess)
        //    {
        //        arrList = oResult.Data as ArrayList;

        //        cmbEducation.DisplayMember = "Name";
        //        cmbEducation.ValueMember = "ID";

        //        cmbEducation.DataSource = arrList;

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
        //   cmbEducation.SelectedIndex = -1;
        //}





        private void LoadEmployeeData()
        {
            lstEmployeeList.Items.Clear();
            CEmployeeBO oEmployeeBO = new CEmployeeBO();
            CResult oResult = new CResult();
            CEmployee oEmployee = new CEmployee();
            //string Unit = cmbUnit.Text.Trim();
            //string Floor = cmbFloor.Text.Trim();
            //string Secion = cmbSection.Text.Trim();
            //string Block = cmbBlock.Text.Trim();
            //string Shift = cmbShift.Text.Trim();
            //string Designation = cmbDesignation.Text.Trim();
            //string Education = cmbEducation.Text.Trim();
            //string EmpID = txtEmpID.Text.Trim();

            oResult = oEmployeeBO.ReadAllEmployee(oEmployee);
            if (oResult.IsSuccess)
            {
                arrList = oResult.Data as ArrayList;

                foreach (CEmployee obj in oResult.Data as ArrayList)
                {
                    ListViewItem oItem = new ListViewItem();
                    oItem.Text = obj.ID.ToString();
                    oItem.SubItems.Add(obj.EmpID).ToString();
                    oItem.SubItems.Add(obj.Name).ToString();
                    oItem.SubItems.Add(obj.EmployeeType).ToString();
                   // oItem.SubItems.Add(obj.UnitID).ToString();
                    // oItem.SubItems.Add(obj.CompanyAddress);

                    lstEmployeeList.Items.Add(oItem);
                }
            }
            else
            {
                MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void LoadTestEmployeeData(object sender, EventArgs e)
        //{
        //    Connection oConnection = new Connection();
        //    string str = "Select EmpID,EmployeeID,Name,Designation,Unit,Section,Block,Floor,EmployeeType from vPerson ";
        //    int temp = 0;
        //    SuppliedInfo oSuppliedInfo = new SuppliedInfo(1);
        //    if (cmbUnit.SelectedIndex != -1)
        //    {
        //        Unit oUnit = new Unit(cmbUnit.SelectedItem.ToString().Trim());
        //        if (oUnit.ID != oSuppliedInfo.HGID)
        //        {
        //            str = str + "v Where v.Unit = '" + cmbUnit.SelectedItem.ToString().Trim() + "'";
        //            temp = 1;
        //        }
        //    }
        //    if (cmbSection.SelectedIndex != -1)
        //    {
        //        if (temp == 1)
        //        {
        //            str = str + " And v.Section = '" + cmbSection.SelectedItem.ToString().Trim() + "'";
        //        }
        //        else
        //        {
        //            str = str + "v Where v.Section = '" + cmbSection.SelectedItem.ToString().Trim() + "'";
        //            temp = 1;
        //        }
        //    }
        //    if (cmbBolck.SelectedIndex != -1)
        //    {
        //        if (temp == 1)
        //        {
        //            str = str + " And v.Block = '" + cmbBolck.SelectedItem.ToString().Trim() + "'";
        //        }
        //        else
        //        {
        //            str = str + "v Where v.Block = '" + cmbBolck.SelectedItem.ToString().Trim() + "'";
        //            temp = 1;
        //        }
        //    }
        //    if (cmbFloor.SelectedIndex != -1)
        //    {
        //        if (temp == 1)
        //        {
        //            str = str + " And v.Floor = '" + cmbFloor.SelectedItem.ToString().Trim() + "'";
        //        }
        //        else
        //        {
        //            str = str + "v Where v.Floor = '" + cmbFloor.SelectedItem.ToString().Trim() + "'";
        //            temp = 1;
        //        }
        //    }
        //    if (cmbDesignation.SelectedIndex != -1)
        //    {
        //        if (temp == 1)
        //        {
        //            str = str + " And v.Designation = '" + cmbDesignation.SelectedItem.ToString().Trim() + "'";
        //        }
        //        else
        //        {
        //            str = str + "v Where v.Designation = '" + cmbDesignation.SelectedItem.ToString().Trim() + "'";
        //            temp = 1;
        //        }
        //    }
        //    if (cmbEmployeeType.SelectedIndex != -1)
        //    {
        //        if (temp == 1)
        //        {
        //            str = str + " And v.EmployeeType = '" + cmbEmployeeType.SelectedItem.ToString().Trim() + "'";
        //        }
        //        else
        //        {
        //            str = str + "v Where v.EmployeeType = '" + cmbEmployeeType.SelectedItem.ToString().Trim() + "'";
        //            temp = 1;
        //        }
        //    }


        //    dt.Clear();
        //    SqlDataAdapter oDtr = new SqlDataAdapter(str, oConnection.GetSqlConnection());
        //    oDtr.Fill(dt);
        //    dgPerson.DataSource = dt;
        //}


      
       
        
        
        private void btnsearch_Click(object sender, EventArgs e)
        {

        }

        private void lstEmployeeList_DoubleClick(object sender, EventArgs e)
        {
            if (lstEmployeeList.Items.Count > 0)
            {
                // ArrayList checkedpersnsrvclist = new ArrayList();
                ListViewItem oItem = (ListViewItem)lstEmployeeList.SelectedItems[0];

                foreach (CEmployee oEmployee in arrList as ArrayList)
                {
                    if (oEmployee.ID == oItem.SubItems[0].Text.Trim())
                    {
                        EEventArgEmployee arg = new EEventArgEmployee(oEmployee);
                        ESelectedEvent(arg);
                        break;
                    }
                }

                this.Dispose();
            }



        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnsearch_Click_1(object sender, EventArgs e)
        {
            LoadEmployeeData();
        }

   
      
      
      
       
    
       

    }


    public class EEventArgEmployee : EventArgs
    {
        private CEmployee m_Employee;

        public EEventArgEmployee(CEmployee objE)
        {
            this.m_Employee = objE;
        }

        public CEmployee Employee
        {
            get { return this.m_Employee; }
        }

    }







}