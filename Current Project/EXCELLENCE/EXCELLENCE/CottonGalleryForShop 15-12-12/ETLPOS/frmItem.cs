using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

using System.Windows.Forms;
using System.Collections;

using ETL.BLL;
using ETL.Model;
using ETL.Common;


namespace ETLPOS
{
    public partial class frmItem : BaseForm
    {
        #region "Declaration"


        bool IsUpdateMode = false;


        #endregion
        
        public byte[] ItemImage { get; set; }

        public frmItem()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void frmItem_Load(object sender, EventArgs e)
        {


            populatetreenode();
            FormControlMode(0);
            LoadItemSize();


        }
        private void LoadItemSize()
        {
            CItemBO oitembo = new CItemBO();
            CResult oresult = new CResult();
            oresult = oitembo.ReadAllItemSize();
            if (oresult.IsSuccess)
            {
                cmbItemSize.DataSource = oresult.Data;
                cmbItemSize.DisplayMember = "Size_Name";
                //cmbItemSize.ValueMember = "Size_OID";
                cmbItemSize.SelectedIndex = -1;
            }
            else
            {
                ddlUOM.Text = "ERROR in loading";
            }
        }
        private void Getmaxdata()
        {
            CItemBO oitembo = new CItemBO();
            CResult oresult = new CResult();
            
            oresult = oitembo.ReadAll();
            ArrayList oitemlist = (ArrayList)oresult.Data;
            // GenerateCode(oitemlist);

            int maxitemrow = oitemlist.Count;
            if (maxitemrow == 0)
            {
                txthiddenitemid.Text = "0";
            }
            else
            {

                CItem oitem2 = (CItem)oitemlist[maxitemrow - 1];
                txthiddenitemid.Text = oitem2.Item_OID;
            }
        }
      
        private void LoadGroupType()
        {
            CItemBO oitembo = new CItemBO();
            CResult oresult = new CResult();
            CItemGroup oitemGroup = new CItemGroup();
            oresult = oitembo.ReadAll(oitemGroup);
            if (oresult.IsSuccess)
            {
                try
                {
                    ddlGroupNAme.DataSource = oresult.Data;
                    ddlGroupNAme.DisplayMember = "Catg_Name";
                    ddlGroupNAme.ValueMember = "Catg_OID";
                   // ddlGroupNAme.SelectedIndex = 0;
                }
                catch (Exception ex) { }
            }
            else
            {
                ddlGroupNAme.Text = "ERROR in loading";
            }
        }

        private void LoadItemType()
        {

            CItemBO oitembo = new CItemBO();
            CResult oresult = new CResult();
            CItemType oitemtype = new CItemType();
            oresult = oitembo.ReadAll(oitemtype);
            if (oresult.IsSuccess)
            {
                ArrayList oItemList = oresult.Data as ArrayList;
                ddlItemType.DataSource = oItemList;
                ddlItemType.DisplayMember = "ITyp_Code";
                ddlItemType.ValueMember = "ITyp_OID";
                ddlItemType.SelectedIndex = 0;
            }
            else
            {
                ddlItemType.Text = "ERROR in loading";
            }
        }

        private void LoadUOMType()
        {
            CUOMBO oUOMBO = new CUOMBO();
            CResult oresult = new CResult();
            oresult = oUOMBO.ReadAll();
            if (oresult.IsSuccess)
            {
                ddlUOM.DataSource = oresult.Data;
                ddlUOM.DisplayMember = "UOM_Code";
                ddlUOM.ValueMember = "UOM_OID";
                ddlUOM.SelectedIndex = 0;
            }
            else
            {
                ddlUOM.Text = "ERROR in loading";
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
                    txtItemCode.Enabled = true;
                    ddlGroupNAme.Enabled = true;
                    btnNewPOB.Enabled = true;
                    break;
                case 1:
                    btnSave.Text = "Update";
                    btnDelete.Enabled = false;
                    IsUpdateMode = true;
                    txtItemCode.Enabled = false;
                    ddlGroupNAme.Enabled = false;
                    btnNewPOB.Enabled = false;
                    break;
            }
        }


        private void gbItemNAme_Enter(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Clearformdata();
        }

        private void Clearformdata()
        {
            txtItemCode.Text = "";
            //txtItemName.Text = "";
            txtpprice.Text = "0";
            txtRemarks.Text = "";
            txtRQTY.Text = "0";
            txtSprice.Text = "0";
            cmbItemSize.SelectedItem = null;

            nupdnItemPriority.Value = 1;

            txthiddenitemid.Text = "";
            chkIsActive.Checked = true;
            pbImage.Image = null;
            this.ItemImage = null;
            FormControlMode(0);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int groupselecteditem=ddlGroupNAme.SelectedIndex;
            if (IsValidFormData())
            {
                if (txtItemCode.Text == "")
                {
                    GetItemCode();
                }
                CItem oitem = Getformdata();
                CItemBO oitembo = new CItemBO();
                CResult oresult = new CResult();

                if (txthiddenitemid.Text == "")
                {
                    Getmaxdata();
                    oitem = Getformdata();
                    oresult = oitembo.Create(oitem);
                }
                else
                {
                    oitem = Getformdata();
                    oresult = oitembo.Update(oitem);
                }
                if (oresult.IsSuccess)
                {

                    MessageBox.Show("Meassage Saved successfully");
                    Clearformdata();
                    populatetreenode();
                    ddlGroupNAme.SelectedIndex = groupselecteditem;
                }
                else
                {

                    MessageBox.Show(oresult.ErrMsg);
                }
            }
        }
        private bool IsValidFormData()
        {
           
            if (txtItemName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter item name.");
                txtItemName.Focus();
                return false;
            }
            if (ddlGroupNAme.SelectedValue == null)
            {
                MessageBox.Show("Please select item Group Name.");
                ddlGroupNAme.Focus();
                return false;
            }
            return true;
        }

        private void GetItemCode()
        {
            string strItemCode=string.Empty;
            CItemBO oitembo = new CItemBO();
            CResult oresult = new CResult();

            oresult = oitembo.ReadAllByCond(ddlGroupNAme.SelectedValue.ToString());
            ArrayList oitemlist = (ArrayList)oresult.Data;

            int maxitemrow = oitemlist.Count;
            if (maxitemrow == 0)
            {
                strItemCode =   ((CItemGroup)ddlGroupNAme.SelectedItem).Catg_Code.ToString() + "00001";
            }
            else
            {
                CItem oitem2 = (CItem)oitemlist[maxitemrow - 1];
                strItemCode = ((CItemGroup)ddlGroupNAme.SelectedItem).Catg_Code.Substring(0,4);
                string strCode =""+ Convert.ToString(Convert.ToInt32(oitem2.Item_Code.Substring(4)) + 1);
                for (int j = 5; j>(strCode.Length) ; j--)
                {
                    strItemCode += "0";
                }
                strItemCode += strCode;
            }

            txtItemCode.Text = strItemCode;
        }

        private CItem Getformdata()
        {
            CItem oitem = new CItem();
            CItemType oItemType = (CItemType)ddlItemType.SelectedItem;
            CItemGroup oitemgroup = (CItemGroup)ddlGroupNAme.SelectedItem;
            CUOM oUOM = (CUOM)ddlUOM.SelectedItem;
            CSize oSize = (CSize)cmbItemSize.SelectedItem;

            oitem.Item_OID = txthiddenitemid.Text;
            oitem.Item_Branch = currentBranch.CompBrn_Code;
            oitem.Item_GroupID = oitemgroup.Catg_OID;
            oitem.Item_TypeID = oItemType.ITyp_OID;
            oitem.Item_UOMID = oUOM.UOM_OID;
            oitem.Item_Code = txtItemCode.Text.Trim();
            if (cmbItemSize.SelectedItem != null && txtICode.Text !="")
            {
                oitem.Item_ItemName = txtItemName.Text +"-"+ txtICode.Text + "-- " + oSize.Size_Name;
            }
            if (txtICode.Text != "")
            {
                oitem.Item_ItemName = txtItemName.Text + "-" + txtICode.Text;
 
            }
            else
            {
                oitem.Item_ItemName = txtItemName.Text;
            }
            //oitem.Item_ItemName = txtItemName.Text;
            oitem.Item_Pprice = float.Parse(txtpprice.Text);
            oitem.Remarks = txtRemarks.Text;
            oitem.Item_RQTY = float.Parse(txtRQTY.Text);
            oitem.Item_Sprice = float.Parse(txtSprice.Text);
            oitem.Creator = currentUser.User_OID;
            oitem.CreationDate = DateTime.Now;
            oitem.UpdateBy = currentUser.User_OID;
            oitem.UpdateDate = DateTime.Now;
            oitem.CreationDate = DateTime.Now.Date;
            if (chkIsActive.Checked)
                oitem.IsActive = "Y";
            else
                oitem.IsActive = "N";

            oitem.Item_Priority = int.Parse(nupdnItemPriority.Text.Trim());

            oitem.ItemImage = this.ItemImage;

            return oitem;
        }
        
        private void populatetreenode()
        {
            LoadUOMType();
            LoadItemType();
            LoadGroupType();
            treeView1.Nodes.Clear();

            CItemBO oitembo = new CItemBO();
            CResult oresult = new CResult();
            
            oresult = oitembo.ReadAll();


            foreach (CItemGroup oitemGroup in ddlGroupNAme.DataSource as ArrayList)
            {
                System.Windows.Forms.TreeNode root = new System.Windows.Forms.TreeNode(oitemGroup.Catg_Code);
                this.treeView1.Nodes.Add(root);

                if (oresult.IsSuccess)
                {
                    foreach (CItem oitem1 in oresult.Data as ArrayList)
                    {
                        System.Windows.Forms.TreeNode childnode = new System.Windows.Forms.TreeNode(oitem1.Item_ItemName);

                        if (oitemGroup.Catg_OID == oitem1.Item_GroupID)
                            root.Nodes.Add(childnode);
                    }
                }
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            frmUOM ofrmuom = new frmUOM();
            ofrmuom.ShowDialog();
            LoadUOMType();
        }



        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                CItemBO oitembo = new CItemBO();
                CResult oresult = new CResult();
                
                oresult = oitembo.ReadAll();

                foreach (CItem oitem1 in oresult.Data as ArrayList)
                {
                    if (oitem1.Item_ItemName == e.Node.Text)
                    {
                        txthiddenitemid.Text = oitem1.Item_OID;
                        txtItemName.Text = oitem1.Item_ItemName;
                        txtItemCode.Text = oitem1.Item_Code;
                        txtpprice.Text = oitem1.Item_Pprice.ToString();
                        txtRemarks.Text = oitem1.Remarks;
                        txtRQTY.Text = oitem1.Item_RQTY.ToString();
                        txtSprice.Text = oitem1.Item_Sprice.ToString();
                        if (oitem1.IsActive == "Y")
                            chkIsActive.Checked = true;
                        else
                            chkIsActive.Checked = false;
                        nupdnItemPriority.Value = oitem1.Item_Priority;

                        if (oitem1.ItemImage != null)
                        {
                            pbImage.Image = Image.FromStream(Helper.GetMemoryStream(oitem1.ItemImage));
                        }
                        else
                        {
                            pbImage.Image = null;
                        }
                        this.ItemImage = oitem1.ItemImage;

                        int i = 0;
                        foreach (CItemGroup oitemGroup in ddlGroupNAme.Items)
                        {
                            if (oitem1.Item_GroupID == oitemGroup.Catg_OID)
                            {
                                ddlGroupNAme.SelectedIndex = i;
                                break;
                            }
                            i++;
                        }
                        i = 0;
                        foreach (CItemType oitemType in ddlItemType.Items)
                        {
                            if (oitem1.Item_TypeID == oitemType.ITyp_OID)
                            {
                                ddlItemType.SelectedIndex = i;
                                break;
                            }
                            i++;
                        }
                        i = 0;
                        foreach (CUOM oCUOM2 in ddlUOM.Items)
                        {
                            if (oitem1.Item_UOMID == oCUOM2.UOM_OID)
                            {
                                ddlUOM.SelectedIndex = i; ;
                                break;
                            }
                            i++;
                        }
                        FormControlMode(1);
                        break;
                    }
                    
                }
            }
                
        }

        private void btnNewPOB_Click_2(object sender, EventArgs e)
        {
            frmItemGroup ofrmgrp = new frmItemGroup();
            ofrmgrp.ShowDialog();

            populatetreenode();
        }

        private void btnNewAppr_Click_2(object sender, EventArgs e)
        {
            frmProductSize ofrmIt = new frmProductSize();
            ofrmIt.ShowDialog();

            //populatetreenode();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            frmUOM ofrmuom = new frmUOM();
            ofrmuom.ShowDialog();
            LoadUOMType();
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            ofdImage.Filter = "Jpeg (*.jpg)|*.jpg|Bitmap (*.bmp)|*.bmp|GIF (*.gif)|*.gif";
            ofdImage.Title = "Select Student Photograph";
            ofdImage.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();

            if ((ofdImage.ShowDialog()) == DialogResult.OK)
            {
                pbImage.Image = null;
                byte[] baNewImageTemp = Helper.ResizeImageFile(Helper.GetBytesFromSource(ofdImage.FileName), pbImage.Size, ImageFormat.Jpeg);
                pbImage.Image = Image.FromStream(Helper.GetMemoryStream(baNewImageTemp));

                this.ItemImage = baNewImageTemp;
            }
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            pbImage.Image = null;
            this.ItemImage = null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            CItem oitem = Getformdata();
            CItemBO oitembo = new CItemBO();
            CResult oresult = new CResult();

            if ((txtItemName.Text != ""))
            {
                if ((MessageBox.Show("Do u really want to delete this item. ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) == DialogResult.Yes)
                {
                    oitem = Getformdata();
                    oresult = oitembo.Delete(oitem);
                    Clearformdata();
                    populatetreenode();
                }
            }
            if (oresult.IsSuccess)
            {
                if (oresult.Data.ToString() == "0")
                {

                    MessageBox.Show("Deletion Not Possible", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clearformdata();
                    populatetreenode();

                }
                else
                {
                    MessageBox.Show("Deleted successfully");
                    Clearformdata();
                    populatetreenode();
                }
            }
            else
            {
                MessageBox.Show("Not Success" + oresult.ErrMsg + "");

            }
        }
    }
}