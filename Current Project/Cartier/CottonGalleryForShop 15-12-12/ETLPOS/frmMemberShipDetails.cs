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

namespace ETLPOS
{
    public partial class frmMemberShipDetails : ETLPOS.BaseForm
    {
        public frmMemberShipDetails()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CMemberShip oMemberShip = new CMemberShip();
            CMemberShipBO oMemberBO = new CMemberShipBO();
            CResult oResult = new CResult();
            if (ValidateFormData())
            {
                if (txtMembeHiddenID.Text != "")
                {
                    oResult = oMemberBO.Update(GetFormData());
                    if (oResult.IsSuccess)
                    {
                        MessageBox.Show("Data Upated Successfully", "ETLIT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFromData(groupBox1);
                        LoadMemberList();
                    }
                }
            }
        }

        private void ClearFromData(GroupBox groupBox1)
        {
            foreach (Control oControl in groupBox1.Controls)
            {
                if (oControl.GetType() == typeof(TextBox) || oControl.GetType() == typeof(ComboBox))
                {
                    oControl.Text = "";
                }
            }
        }

        private CMemberShip GetFormData()
        {
            CMemberShip oMember = new CMemberShip();
            oMember.Branch = currentBranch.CompBrn_Branch;
            oMember.ID = txtMembeHiddenID.Text.Trim();
            oMember.MembershipID = txtMemberID.Text.Trim();
            oMember.MemberName = txtMemberName.Text.Trim();
            oMember.Mobile = txtMobile.Text.Trim();
            oMember.DateOfBirth = dtpDateOfBirth.Value;
            oMember.Fromdate = dtpFromDate.Value;
            oMember.Todate = dtpToDate.Value;
            oMember.Address = txtAddress.Text.Trim();
            oMember.Area = txtArea.Text.Trim();
            oMember.PostCode = txtPostCode.Text.Trim();
            oMember.Phone = txtPhone.Text.Trim();
            oMember.Email = txtEmail.Text.Trim();
            oMember.Occupation = txtOccuption.Text.Trim();
            oMember.FamilyMember = int.Parse(txtFamilyMember.Text.Trim());
            oMember.Member_DiscountAmount = float.Parse(txtMemberDiscountAmount.Text.Trim());
            if (rbYes.Checked)
            {
                oMember.IsActiveMenber = 1;
            }
            else if (rbNo.Checked)
            {
                oMember.IsActiveMenber = 0;
            }
            oMember.UpdateBy = currentUser.User_OID;
            oMember.UpdateDate = DateTime.Now;
            return oMember;
        }

        private bool ValidateFormData()
        {
            if (txtMemberID.Text == "")
            {
                MessageBox.Show("Please Insert Membership ID", "ETLIT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtMobile.Text == "")
            {
                MessageBox.Show("Please Insert Mobile No", "ETLIT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtMemberName.Text == "")
            {
                MessageBox.Show("Please Insert Member Name", "ETLIT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void frmMemberShipDetails_Load(object sender, EventArgs e)
        {
            LoadMemberList();
        }

        private void LoadMemberList()
        {
            lvMemberList.Items.Clear();
            CMemberShipBO oMemberBO = new CMemberShipBO();
            CResult oResult = new CResult();
            oResult = oMemberBO.ReadAllByBranch(currentBranch.CompBrn_Branch);
            if (oResult.IsSuccess)
            {int i=0;
                List<CMemberShip> oMemberList = oResult.Data as List<CMemberShip>;
                foreach (CMemberShip oMember in oMemberList)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = (i + 1).ToString("000");
                    lvi.SubItems.Add(oMember.MemberName);
                    lvi.SubItems.Add(oMember.Mobile);
                    lvi.SubItems.Add(oMember.Fromdate.ToShortDateString());
                    lvi.SubItems.Add(oMember.Todate.ToShortDateString());
                    lvi.Tag = oMember;
                    lvMemberList.Items.Add(lvi);
                    i++;
                }
            }
        }

        private void lvMemberList_DoubleClick(object sender, EventArgs e)
        {
            if (lvMemberList.Items.Count > 0)
            {
                CMemberShip oMembership = lvMemberList.SelectedItems[0].Tag as CMemberShip;
                if (oMembership != null)
                {
                    txtMembeHiddenID.Text = oMembership.ID;
                    txtMemberID.Text = oMembership.MembershipID;
                    txtMemberName.Text = oMembership.MemberName;
                    txtMobile.Text = oMembership.Mobile;
                    dtpDateOfBirth.Value = oMembership.DateOfBirth;
                    dtpFromDate.Value = oMembership.Fromdate;
                    dtpToDate.Value = oMembership.Todate;
                    txtAddress.Text = oMembership.Address;
                    txtArea.Text = oMembership.Area;
                    txtPostCode.Text = oMembership.PostCode;
                    txtPhone.Text = oMembership.Phone;
                    txtEmail.Text = oMembership.Email;
                    txtOccuption.Text = oMembership.Occupation;
                    txtFamilyMember.Text = oMembership.FamilyMember.ToString();
                    if (oMembership.IsActiveMenber == 1)
                    {
                        rbYes.Checked = true;
                    }
                    else if (oMembership.IsActiveMenber == 0)
                    {
                        rbNo.Checked = true;
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearFromData(groupBox1);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            CMemberShipBO oMemberBO = new CMemberShipBO();
            CResult oResult = new CResult();
            if (MessageBox.Show("Are You Sure You want to delete", "ETL", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                oResult = oMemberBO.Delete(txtMembeHiddenID.Text.Trim());
                if (oResult.IsSuccess)
                {
                    MessageBox.Show("Selected Data Successfully Deleted", "ETL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFromData(groupBox1);
                    LoadMemberList();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
