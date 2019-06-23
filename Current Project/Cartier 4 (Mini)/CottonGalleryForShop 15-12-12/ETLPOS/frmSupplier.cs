using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using ETL.BLL;
using ETL.Model;
using ETL.Common;



namespace ETLPOS
{
    public partial class frmSupplier : BaseForm
    {

        #region "Declaration"


        bool IsUpdateMode = false;


        #endregion
        
        public frmSupplier()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validatedata())
            {
                CSupplierBO occsbo = new CSupplierBO();
                CSupplier occs = new CSupplier();
                CResult oResult = new CResult();
                occs = Getformdata();
                if (this.txtOId.Text.Trim() == string.Empty)
                {
                    oResult = occsbo.Create(occs);
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("Are you wanted to upadte supplier " + txtName.Text + " ?", "Confirmation!", MessageBoxButtons.OKCancel))
                    {
                        oResult = occsbo.Update(occs);
                    }
                }
                if (oResult.IsSuccess)
                {

                    MessageBox.Show("Message saved succesfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearformdata();

                }
                else
                {
                    MessageBox.Show("Message can not be saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }

        private void clearformdata()
        {
            this.txtOId.Text = "";
            this.txtId.Text = "";
            txtName.Text = "";
            txtaddress.Text = "";
            txtcell.Text = "";
            txtcontactper.Text = "";
            txtemail.Text = "";
            txtfax.Text = "";
            txtphn.Text = "";
            txtweb.Text = "";
            txtdiscrate.Text = "0";
            chkIsActive.Checked = true;
            GetGRNextCode();
            FormControlMode(0);
        }

        private CSupplier Getformdata()
        {
            CSupplier occs = new CSupplier();
            //
            occs.Cust_OId = txtOId.Text;
            occs.Cust_Branch = currentBranch.CompBrn_Code;
            occs.Cust_Id = txtId.Text;
            occs.Cust_Name = txtName.Text;
            occs.Cust_CSType = ECSType.SUPPLIER;
            occs.Cust_ContactP = txtcontactper.Text;
            occs.Cust_Address = txtaddress.Text;
            occs.Cust_Cell = txtcell.Text;
            occs.Cust_Phone = txtphn.Text;
            occs.Cust_Email = txtemail.Text;
            occs.Cust_Fax = txtfax.Text;
            occs.Cust_Web = txtweb.Text;
            occs.Cust_IsActive = chkIsActive.Checked ? "Y":"N";
            occs.Cust_DiscRate = float.Parse(txtdiscrate.Text);

            occs.Creator = currentUser.User_OID;
            occs.CreationDate = DateTime.Now;
            occs.UpdateBy = currentUser.User_OID;
            occs.UpdateDate = DateTime.Now;
            
            return occs;
            
        }

        private bool validatedata()
        {
            if (txtName.Text=="")
            {
                MessageBox.Show("Please Give Supplier name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return false;
            }
            if (txtaddress.Text.Trim()== "")
            {
                MessageBox.Show("Please Give address.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtaddress.Focus();
                return false;
            }
            if (txtcell.Text.Trim()== "")
            {
                MessageBox.Show("Please give Cell number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtcell.Focus();
                return false;
            }
            //if (txtemail.Text == "")
            //{
            //    MessageBox.Show("Please give e-mail address", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtemail.Focus();
            //    return false;
            //}

            return true;
            
        }

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            GetGRNextCode();
            FormControlMode(0);
        }


        private void FormControlMode(int i)
        {
            switch (i)
            {
                case 0:
                    btnSave.Text = "Save";
                    btnDelete.Enabled = false;
                    IsUpdateMode = false;
                    txtId.Enabled = true;
                    break;
                case 1:
                    btnSave.Text = "Update";
                    btnDelete.Enabled = true;
                    IsUpdateMode = true;
                    txtId.Enabled = false;
                    break;
            }
        }

        private void GetGRNextCode()
        {
            CResult oResult = new CResult();
            CCommonBO oCommonBO = new CCommonBO();

            oResult = oCommonBO.ReadLastCodeNo("Cust_Id", "Cust", currentBranch.CompBrn_Code);
            if (oResult.IsSuccess)
            {
                txtId.Text = oResult.Data.ToString();
            }
            else
            {
                MessageBox.Show("Loading error...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearformdata();
        }

        //private void btnSupplier_Click(object sender, EventArgs e)
        //{
        //    frmSupplierList ofrmSupplierList = new frmSupplierList();
        //    ofrmSupplierList.EEvent += new frmSupplierList.EEventhandler(ofrmSupplierList_EEvent);
        //    ofrmSupplierList.ShowDialog();
        //}
        void ofrmSupplierList_EEvent(object Sender, EEventArg2 e)
        {
            CSupplier obj = (CSupplier)e.Supplier;
            Displaydata(obj);
        }
        private void Displaydata(CSupplier objSupplier)
        {
            txtOId.Text = objSupplier.Cust_OId;
            txtId.Text = objSupplier.Cust_Id;
            txtName.Text = objSupplier.Cust_Name;
            txtdiscrate.Text = objSupplier.Cust_DiscRate.ToString();
            txtcontactper.Text = objSupplier.Cust_ContactP;
            txtemail.Text = objSupplier.Cust_Email;
            txtfax.Text = objSupplier.Cust_Fax;
            txtweb.Text = objSupplier.Cust_Web;
            txtcell.Text = objSupplier.Cust_Cell;
            txtaddress.Text = objSupplier.Cust_Address;
            txtphn.Text = objSupplier.Cust_Phone;
            chkIsActive.Checked = (objSupplier.Cust_IsActive.ToUpper().Trim() == "Y") ? true : false;
            FormControlMode(1);
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            CSupplierBO occsbo = new CSupplierBO();
            CSupplier occs = new CSupplier();
            CResult oResult = new CResult();
            //occs = Getformdata();
            if ((MessageBox.Show("Do u really want to delete. ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) == DialogResult.Yes)
            {
                oResult = occsbo.Delete(this.txtOId.Text);
            }

            if (oResult.IsSuccess)
            {

                MessageBox.Show("Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearformdata();

            }
            else
            {
                MessageBox.Show("Message can not be deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void btnSupplier_Click_1(object sender, EventArgs e)
        {
            frmSupplierList ofrmSupplierList = new frmSupplierList();
            ofrmSupplierList.EEvent += new frmSupplierList.EEventhandler(ofrmSupplierList_EEvent);
            ofrmSupplierList.ShowDialog();
        }


        private void IsValidKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) return;

            Control txtB = (Control)sender;
            bool flag = txtB.Text.Trim().Contains(".");
            if (e.KeyChar == 46 && !flag) return;
            if (e.KeyChar < 48 || e.KeyChar > 57)
                e.Handled = true;
        }


     
    }
}