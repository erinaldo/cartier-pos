using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ETL.BLL;
using ETL.Model;
using ETL.Common;

namespace ETLPOS
{        
    public partial class frmCCSDDSS : Form
    {
        CEnum.ETables eTable;

        public frmCCSDDSS()
        {
            InitializeComponent();
        }

        public frmCCSDDSS(CEnum.ETables eTable)
        {
            InitializeComponent();

            InitializeControls(eTable);

            LoadAllCCSDDSS();
        }

        private void InitializeControls(CEnum.ETables eTable)
        {
            this.eTable = eTable;

            switch (this.eTable)
            {
                case CEnum.ETables.Company:
                    this.Text = "Company (Group)";
                    addressToolStripMenuItem1.Visible = true;
                    break;
                case CEnum.ETables.CompanyCode:
                    this.Text = "Company Code";
                    addressToolStripMenuItem1.Visible = true;
                    break;
                case CEnum.ETables.SalesOrganization:
                    this.Text = "Sales Organization";
                    addressToolStripMenuItem1.Visible = true;
                    break;
                case CEnum.ETables.DistributionChannel:
                    this.Text = "Distribution Channel";
                    addressToolStripMenuItem1.Visible = false;
                    break;
                case CEnum.ETables.Division:
                    this.Text = "Division";
                    addressToolStripMenuItem1.Visible = false;
                    break;
                case CEnum.ETables.SalesOffice:
                    this.Text = "Sales Office";
                    addressToolStripMenuItem1.Visible = true;
                    break;
                case CEnum.ETables.SalesGroup:
                    this.Text = "Sales Group";
                    addressToolStripMenuItem1.Visible = false;
                    break;
            }            
        }

        private void LoadAllCCSDDSS()
        {
            lv_CCSDDSS.Items.Clear();

            List<CCCSDDSS> oList;
            CCCSDDSSBO oCCSDDSSBO = new CCCSDDSSBO();
            CResult oResult = new CResult();

            oResult = oCCSDDSSBO.ReadAll(this.eTable);
            
            if (oResult.IsSuccess)
            {
                oList = (List<CCCSDDSS>) oResult.Data;
                Load_lv_CCSDDSS(oList);
            }
        }
        private void Load_lv_CCSDDSS(List<CCCSDDSS> oList)
        {
            lv_CCSDDSS.Items.Clear();

            if (oList.Count > 0)
            {
                foreach (CCCSDDSS oCCSDDSS in oList)
                {
                    ListViewItem oItem = new ListViewItem();

                    oItem.Name = oCCSDDSS.Code;
                    oItem.Text = oCCSDDSS.Code;
                    oItem.SubItems.Add(oCCSDDSS.Name);

                    lv_CCSDDSS.Items.Add(oItem);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CCCSDDSS oCCSDDSS = GetFormData();
            CCCSDDSSBO oCCSDDSSBO = new CCCSDDSSBO();
            CResult oResult = new CResult();

            oResult = oCCSDDSSBO.Create(oCCSDDSS, this.eTable);

            if (oResult.IsSuccess)
            {
                MessageBox.Show("Saved successfully");
            }
            else
            {
                MessageBox.Show(oResult.ErrMsg);
            }
            LoadAllCCSDDSS();
        }
        
        private CCCSDDSS GetFormData()
        {
            CCCSDDSS oCCSDDSS = new CCCSDDSS();

            oCCSDDSS.Code = txtCode.Text.Trim();
            oCCSDDSS.Name = txtName.Text.Trim();

            oCCSDDSS.IsActive = true;

            return oCCSDDSS;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CCCSDDSS oCCSDDSS = GetFormData();
            CCCSDDSSBO oCCSDDSSBO = new CCCSDDSSBO();
            CResult oResult = new CResult();

            oResult = oCCSDDSSBO.Update(oCCSDDSS, this.eTable);

            if (oResult.IsSuccess)
            {
                MessageBox.Show("Updated successfully");
            }
            else
            {
                MessageBox.Show(oResult.ErrMsg);
            }
            LoadAllCCSDDSS();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Are you want to delete " + txtCode.Text + " ?", "Confirmation!", MessageBoxButtons.OKCancel))
            {
                CCCSDDSS oCCSDDSS = GetFormData();
                CCCSDDSSBO oCCSDDSSBO = new CCCSDDSSBO();
                CResult oResult = new CResult();

                oResult = oCCSDDSSBO.Delete(oCCSDDSS, this.eTable);

                if (oResult.IsSuccess)
                {
                    MessageBox.Show("Deleted successfully");
                }
                else
                {
                    MessageBox.Show(oResult.ErrMsg);
                }
                LoadAllCCSDDSS();
            }
        }

        private void addressToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new frmAddress(this.eTable, txtCode.Text.Trim()).ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void lv_CCSDDSS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_CCSDDSS.SelectedItems.Count > 0)
            {
                ListViewItem oItem = lv_CCSDDSS.SelectedItems[0];
                if (oItem != null)
                {
                    txtCode.Text = oItem.Text;
                    txtName.Text = oItem.SubItems[1].Text;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            txtName.Text = "";
        }        
    }
}