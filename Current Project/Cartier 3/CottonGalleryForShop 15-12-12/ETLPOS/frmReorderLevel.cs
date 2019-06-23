using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using ETL.BLL;
using ETL.Model;
using ETL.Common;



namespace ETLPOS
{
    public partial class frmReorderLevel : BaseForm
    {

        #region "Declaration"


        bool IsUpdateMode = false;


        #endregion
        
        
        public frmReorderLevel()
        {
            InitializeComponent();
        }

        private void frmReorderLevel_Load(object sender, EventArgs e)
        {
            LoadReorderLevelData();
            LoadItem();
            LoadAllLocation();
            FormControlMode(0);
        
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
        
        
        private void LoadItem()
        {

            CItemBO oitembo = new CItemBO();
            CResult oresult = new CResult();
            oresult = oitembo.ReadAll();
            if (oresult.IsSuccess)
            {

                //ddlItemType.Items.Add(new ListItem("Select one Item","NA"));
                ArrayList oItemList = oresult.Data as ArrayList;
                cmbItemName.DataSource = oItemList;
                cmbItemName.DisplayMember = "Item_ItemName";
                cmbItemName.ValueMember = "Item_OId";
                cmbItemName.SelectedIndex = -1;
                //foreach (CItemType oitemtype1 in oresult.Data as ArrayList)
                //{
                //    ddlItemType.Items.Add(new ListItem(oitemtype1.TypeName, oitemtype.TypeID.ToString()));

                //}

            }
            else
            {
                cmbItemName.Text = "ERROR in loading";
            }
        }


        private void chkedit_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

                CReorderLevelBO oReorderLevelBO = new CReorderLevelBO();
                CResult oResult = new CResult();


                if (ValidateToSaveData())
                {
                    if (txtID.Text.Trim() != string.Empty)
                    {

                        if (DialogResult.OK == MessageBox.Show("Are you wanted to upadte the Item " + cmbItemName.Text + " ?", "Confirmation!", MessageBoxButtons.OKCancel))
                        {

                            oResult = oReorderLevelBO.Update(GetToSaveData());

                        }
                    }
                    else
                    {

                        oResult = oReorderLevelBO.Create(GetToSaveData());

                    }


                    if (oResult.IsSuccess)
                    {
                        ClearFormData();
                        LoadReorderLevelData();
                        MessageBox.Show("Successfully Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }

        private void FormControlMode(int i)
        {
            switch (i)
            {
                case 0:
                    btnSave.Text = "Save";
                    btnDelete.Enabled = false;
                    IsUpdateMode = false;
                   // txtCode.Enabled = true;
                    break;
                case 1:
                    btnSave.Text = "Update";
                    btnDelete.Enabled = true;
                    IsUpdateMode = true;
                  //  txtCode.Enabled = false;
                    break;
            }
        }





        private bool ValidateToSaveData()
        {

            if (cmbItemName.Text == "")
            {
                MessageBox.Show("Please Enter Item Name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbItemName.Focus();
                return false;
            }

            if (cmbLocation.Text == "")
            {
                MessageBox.Show("Please Enter Location", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbLocation.Focus();
                return false;
            }
            if (txtRQTY.Text == "")
            {
                MessageBox.Show("Please Enter Quantity", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRQTY.Focus();
                return false;
            }

            

            else
                return true;
        }

        private CReorderLevel GetToSaveData()
        {
            CReorderLevel oReorderLevel = new CReorderLevel();
            oReorderLevel.OID = txtID.Text;
            oReorderLevel.Branch_ID = currentBranch.CompBrn_OId.Trim().ToString();
            oReorderLevel.Item_ID = cmbItemName.SelectedValue.ToString();
            oReorderLevel.Location_ID = cmbLocation.SelectedValue.ToString();
            oReorderLevel.Quantity = txtRQTY.Text;
            oReorderLevel.Remarks = txtRemarks.Text;

            return oReorderLevel;
        }

       

        private void LoadReorderLevelData()
        {
            lvReorderList.Items.Clear();
            CReorderLevelBO oReorderLevelBO = new CReorderLevelBO();
            CResult oResult = new CResult();
            CReorderLevel oReorderLevel = new CReorderLevel();

            oResult = oReorderLevelBO.ReadAllReorderLevelData(oReorderLevel);
            if (oResult.IsSuccess)
            {
                foreach (CReorderLevel obj in oResult.Data as ArrayList)
                {
                    ListViewItem oItem = new ListViewItem();
                    oItem.Text = obj.OID.ToString();

                    oItem.SubItems.Add(obj.Item_ID).ToString();
                    oItem.SubItems.Add(obj.Location_ID).ToString();
                    oItem.SubItems.Add(obj.Branch_Name).ToString();
                    oItem.SubItems.Add(obj.Item_Name).ToString();
                    oItem.SubItems.Add(obj.Location_Name).ToString();
                    oItem.SubItems.Add(obj.Quantity).ToString();
                    oItem.SubItems.Add(obj.Remarks).ToString();


                    lvReorderList.Items.Add(oItem);
                }
            }
            else
            {
                MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void ClearFormData()
        {
            txtID.Text = "";
            cmbItemName.SelectedIndex = -1;
            cmbLocation.SelectedIndex = -1;
            txtRemarks.Text = "";
            txtRQTY.Text = "";
            FormControlMode(0);
               
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearFormData();
        }

        private void lvReorderList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvReorderList.SelectedItems.Count > 0)
            {
                ListViewItem oItem = lvReorderList.SelectedItems[0];
                if (oItem != null)
                {
                   // txtID.Text = oItem.
                    txtID.Text = oItem.Text;
                    cmbItemName.Text = oItem.SubItems[4].Text;
                    cmbLocation.Text = oItem.SubItems[5].Text;
                    txtRQTY.Text = oItem.SubItems[6].Text;
                    txtRemarks.Text = oItem.SubItems[7].Text;
                    FormControlMode(1);
                    
                }
            }
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Are you want to delete Item " + cmbItemName.Text + " ?", "Confirmation!", MessageBoxButtons.OKCancel))
            {

                CReorderLevelBO oReorderLevelBO = new CReorderLevelBO();
                CResult oResult = new CResult();

                oResult = oReorderLevelBO.Delete(GetToSaveData());
              
               ClearFormData();
                              
                if (oResult.IsSuccess)
                {
                    MessageBox.Show("Deleted successfully");
                }
              
                else
                {
                    MessageBox.Show(oResult.ErrMsg);
                }
                LoadReorderLevelData();
            }
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            frmItem ofrmgrp = new frmItem();
            ofrmgrp.ShowDialog();
            LoadItem();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Are you wanted to upadte the Item " + cmbItemName.Text + " ?", "Confirmation!", MessageBoxButtons.OKCancel))
            {

                CReorderLevelBO oReorderLevelBO = new CReorderLevelBO();
                CResult oResult = new CResult();

                oResult = oReorderLevelBO.Update(GetToSaveData());

                ClearFormData();

                if (oResult.IsSuccess)
                {
                    MessageBox.Show("Updated successfully");
                }

                else
                {
                    MessageBox.Show(oResult.ErrMsg);
                }
                LoadReorderLevelData();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnLocation_Click(object sender, EventArgs e)
        {
            frmLocation oLocation = new frmLocation();
            oLocation.Show();
            LoadAllLocation();
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
