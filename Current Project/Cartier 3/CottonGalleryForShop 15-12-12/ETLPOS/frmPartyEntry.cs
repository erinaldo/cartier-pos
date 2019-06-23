using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Model;
using BLL;
using ETL.Common;
using System.Collections;

namespace ETLPOS
{
    public partial class frmPartyEntry : ETLPOS.BaseForm
    {
        public frmPartyEntry()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CParty oParty = new CParty();
            CPartyBO oPartyBO = new CPartyBO();
            CResult oResult = new CResult();
            if (validatedata())
            {
                oResult = oPartyBO.Create(GetFormData(oParty));
                if (oResult.IsSuccess)
                {
                    MessageBox.Show("Saved successfully");
                }
                else
                {
                    //MessageBox.Show(oResult.ErrMsg);
                    MessageBox.Show("Not Saved" + oResult.ErrMsg + "");

                }
                ClearControl(groupBox4);
                LoadParty();
            }
        }

        private void ClearControl(GroupBox groupBox4)
        {
            foreach (Control oControls in groupBox4.Controls)
            {
                if(oControls.GetType()==typeof(TextBox))
                {
                    oControls.Text = "";
                }
                else if (oControls.GetType() == typeof(ComboBox))
                {
                    oControls.Text = "";
                }
            }
        }

        private bool validatedata()
        {
            if (txtPartyName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Party Name", "ETLPOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (txtMobile.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Mobile Number", "ETLPOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (txtCountry.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Country Name", "ETLPOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private CParty GetFormData(CParty oParty)
        {
            oParty.Party_Branch = currentBranch.CompBrn_Code;
            oParty.Party_Name = txtPartyName.Text.Trim();
            oParty.Party_Address = txtAddress.Text.Trim();
            oParty.Party_City = txtCity.Text.Trim();
            oParty.Party_Country = txtCountry.Text.Trim();
            oParty.Party_Phone = txtPhone.Text.Trim();
            oParty.Party_Mobile = txtMobile.Text.Trim();
            oParty.Party_Email = txtEmail.Text.Trim();
            oParty.Party_ContactPerson1 = txtContactPerson1.Text.Trim();
            oParty.Party_Phone1 = txtPhone1.Text.Trim();
            oParty.Party_Contactperson2 = txtContactPerson2.Text.Trim();
            oParty.Party_Phone2 = txtPhone2.Text.Trim();
            oParty.Creator = currentUser.User_OID;
            oParty.CreationDate = DateTime.Now;
            oParty.UpdateBy = currentUser.User_OID;
            oParty.UpdateDate = DateTime.Now;
            return oParty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtOId.Text!=string.Empty)
            {
                if ((MessageBox.Show("Do u really want to delete this item. ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) == DialogResult.Yes)
                {
                    CParty oParty = Getformdata();
                    CPartyBO oPartyBO = new CPartyBO();
                    CResult oresult = new CResult();
                    oresult = oPartyBO.Delete(oParty);
                    if (oresult.IsSuccess == true)
                    {

                        if (oresult.Data.ToString() == "0")
                        {

                            MessageBox.Show("Deletion Not Possible", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadParty();
                            ClearControl(groupBox4);

                        }

                        else
                        {

                            MessageBox.Show("Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadParty();
                            ClearControl(groupBox4);
                        }
                    }

                    else
                    {
                        MessageBox.Show("Error" + oresult.ErrMsg + "");

                    }
                }


                
            }
        }

        private void LoadParty()
        {
            lvParty.Items.Clear();
            CPartyBO oPartyBO = new CPartyBO();
            CResult oresult = new CResult();
            List<CParty> oPartyList = new List<CParty>();
            oresult = oPartyBO.ReadAll();
            if (oresult.IsSuccess)
            {
                if (oresult.Data != null)
                {
                    int i = 0;
                    foreach (CParty oParty in oresult.Data as ArrayList)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = (i + 1).ToString("00");
                        lvi.SubItems.Add(oParty.Party_Name);
                        lvi.SubItems.Add(oParty.Party_Mobile);
                        lvi.SubItems.Add(oParty.Party_Country);
                        lvi.Tag = oParty;
                        lvParty.Items.Add(lvi);
                        i++;
                    }
                }
            }
            else
            {
                MessageBox.Show(oresult.ErrMsg);
            }
        }

        private CParty Getformdata()
        {
            CParty oParty = new CParty();
            oParty.Party_OID = txtOId.Text.Trim();
            return oParty;
        }

        private void lvParty_DoubleClick(object sender, EventArgs e)
        {
            CParty oParty = lvParty.FocusedItem.Tag as CParty;
            txtOId.Text = oParty.Party_OID;
            txtPartyName.Text = oParty.Party_Name;
            txtAddress.Text = oParty.Party_Address;
            txtCity.Text = oParty.Party_City;
            txtCountry.Text = oParty.Party_Country;
            txtPhone.Text = oParty.Party_Phone;
            txtMobile.Text = oParty.Party_Mobile;
            txtEmail.Text = oParty.Party_Email;
            txtContactPerson1.Text = oParty.Party_ContactPerson1;
            txtPhone1.Text = oParty.Party_Phone1;
            txtContactPerson2.Text = oParty.Party_Contactperson2;
            txtPhone2.Text = oParty.Party_Phone2;
        }

        private void frmParty_Load(object sender, EventArgs e)
        {
            LoadParty();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControl(groupBox4);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
                CParty oParty = lvParty.FocusedItem.Tag as CParty;
                CPartyBO oPartyBO = new CPartyBO();
                CResult oResult = new CResult();
                if (validatedata())
                {
                    oResult = oPartyBO.Update(GetFormData(oParty));
                    if (oResult.IsSuccess)
                    {
                        MessageBox.Show("Update successfully");
                    }
                    else
                    {
                        MessageBox.Show("Not Updated" + oResult.ErrMsg + "");

                    }
                    ClearControl(groupBox4);
                    LoadParty();
                }
        }
    }
}
