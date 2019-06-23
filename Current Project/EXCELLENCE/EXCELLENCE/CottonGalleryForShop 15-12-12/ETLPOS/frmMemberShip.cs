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
    public partial class frmMemberShip : BaseForm
    {
        CResult MemberList = null;
        public frmMemberShip()
        {
            InitializeComponent();
            LoadMemberList();
        }

        private void LoadMemberList()
        {
            CMemberShipBO oMembershipBO = new CMemberShipBO();
            CResult oresult = new CResult();
            oresult =oMembershipBO.ReadAllByBranch(currentBranch.CompBrn_Code);
            MemberList = oresult;
            if (oresult.IsSuccess)
            {
                gdvMemberList.AutoGenerateColumns = false;
                gdvMemberList.DataSource = oresult.Data;

            }
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CMemberShip oMembership = Getformdata();
            CMemberShipBO oMembershipBO = new CMemberShipBO();
            CResult oresult = new CResult();
            if (validatedata())
            {
              oresult = oMembershipBO.Create(oMembership);
              if (oresult.IsSuccess)
              {
                  MessageBox.Show("Member Data Successfully Saved", "ETLIT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  ClearFromData(groupBox1);
              }
            }
        }

        private void ClearFromData(GroupBox groupBox1)
        {
            foreach (Control oControl in groupBox1.Controls)
            {
                if (oControl.GetType() == typeof(TextBox)||oControl.GetType()==typeof(ComboBox))
                {
                    oControl.Text = "";
                }
            }
        }

        private bool validatedata()
        {
            if (txtMembershipID.Text == "")
            {
                MessageBox.Show("Please Insert Membership ID", "ETLIT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtMobile.Text == "")
            {
                MessageBox.Show("Please Insert Mobile No", "ETLIT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Please Insert Member Name", "ETLIT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;

        }

        private CMemberShip Getformdata()
        {
            CMemberShip oMembership = new CMemberShip();
            oMembership.Branch = currentBranch.CompBrn_Code;
            oMembership.MembershipID = txtMembershipID.Text.Trim();
            oMembership.MemberName = txtName.Text.Trim();
            oMembership.Mobile = txtMobile.Text.Trim();
            oMembership.Fromdate = dtpFromDate.Value;
            oMembership.Todate = dtpToDate.Value;
            oMembership.Member_DiscountAmount = Convert.ToInt32(txtDiscount.Text);
            oMembership.Creator = currentUser.User_OID;
            oMembership.CreationDate = DateTime.Now;
            return oMembership;
        }

        private void frmMemberShip_Load(object sender, EventArgs e)
        {
            dtpToDate.Value = DateTime.Now.AddYears(1);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearFromData(groupBox1);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length>4)
            {
                if (MemberList!=null)
                {
                    var result = (List<CMemberShip>)MemberList.Data;
                    var findresult = result.FindAll(a => a.Mobile.Contains(txtSearch.Text) || a.MembershipID.Contains(txtSearch.Text));
                    gdvMemberList.AutoGenerateColumns = false;
                    gdvMemberList.DataSource = findresult;
                }
            }
        }
    }
}
