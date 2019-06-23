using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ETL.BLL;
using ETL.Common;
using ETL.Model;
using CrystalDecisions.Windows.Forms;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;


namespace ETLPOS
{
    public partial class frmGR : BaseForm
    {
        #region "Declarations"

        bool IsUpdateMode = false;
        bool IsImportedData = false;
        float gItemQty = 0.00f;

        ArrayList arrItemList = new ArrayList();
        ArrayList arrUOMList = new ArrayList();
        ArrayList arrLocationList = new ArrayList();
        ArrayList arrSupplierList = new ArrayList();
        List<CCurrency> CurrencyList = new List<CCurrency>();


        #endregion

        #region "Constructor"

        public frmGR()
        {
            InitializeComponent();
        }

        #endregion

        #region "Methods"

        private void LoadItemData()
        {
            CResult oResult = new CResult();
            CItemBO oItemBO = new CItemBO();
            oResult = oItemBO.ReadAll();

            if (oResult.IsSuccess)
            {
                arrItemList = oResult.Data as ArrayList;
            }
            else
            {
                MessageBox.Show("Loading error...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUOMData()
        {
            CResult oResult = new CResult();
            CUOMBO oUOMBO = new CUOMBO();
            oResult = oUOMBO.ReadAll();

            if (oResult.IsSuccess)
            {
                arrUOMList = oResult.Data as ArrayList;
            }
            else
            {
                MessageBox.Show("Loading error...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSupplierData()
        {
            CResult oResult = new CResult();
            CSupplierBO oSupplierBO = new CSupplierBO();
            CSupplier oSupplier = new CSupplier();

            oSupplier.Cust_CSType = ECSType.SUPPLIER;
            oResult = oSupplierBO.ReadAll(oSupplier);

            if (oResult.IsSuccess)
            {
                arrSupplierList = oResult.Data as ArrayList;
                ddlSupplier.DataSource = arrSupplierList;
                ddlSupplier.DisplayMember = "Cust_Name";
                ddlSupplier.ValueMember = "Cust_OId";
            }
            else
            {
                MessageBox.Show("Loading error...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCurrencyData()
        {
            CResult oResult = new CResult();
            CCurrencyBO oCurrencyBO = new CCurrencyBO();
            oResult = oCurrencyBO.ReadAll();

            if (oResult.IsSuccess)
            {
                CurrencyList = oResult.Data as List<CCurrency>;
            }
            else
            {
                MessageBox.Show("Loading error...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLocationData()
        {
            CResult oResult = new CResult();
            CLocBO oLocBO = new CLocBO();
            oResult = oLocBO.ReadAllBranchwise(currentBranch.CompBrn_OId.Trim());

            if (oResult.IsSuccess)
            {
                arrLocationList = oResult.Data as ArrayList;
            }
            else
            {
                MessageBox.Show("Loading error...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadDataGridItem()
        {
            foreach (DataGridViewColumn oColumn in dgItemList.Columns)
            {
                if (oColumn.CellType == typeof(DataGridViewComboBoxCell))
                {
                    if (oColumn.Name == "colItemName")
                    {
                        if (arrItemList.Count > 0)
                        {
                            ((DataGridViewComboBoxColumn)oColumn).DataSource = arrItemList;
                            ((DataGridViewComboBoxColumn)oColumn).DisplayMember = "Item_ItemName";
                            ((DataGridViewComboBoxColumn)oColumn).ValueMember = "Item_OID";
                        }
                    }
                    else if (oColumn.Name == "colIssueUOM" || oColumn.Name == "colReceivedUOM")
                    {
                        if (arrUOMList.Count > 0)
                        {
                            ((DataGridViewComboBoxColumn)oColumn).DataSource = arrUOMList;
                            ((DataGridViewComboBoxColumn)oColumn).DisplayMember = "UOM_Code";
                            ((DataGridViewComboBoxColumn)oColumn).ValueMember = "UOM_OID";
                        }
                    }
                    else if (oColumn.Name == "colSourceLoc")
                    {
                        if (arrLocationList.Count > 0)
                        {
                            ((DataGridViewComboBoxColumn)oColumn).DataSource = arrLocationList;
                            ((DataGridViewComboBoxColumn)oColumn).DisplayMember = "Loc_Code";
                            ((DataGridViewComboBoxColumn)oColumn).ValueMember = "Loc_OID";
                        }
                    }
                    else if (oColumn.Name == "colSrcInvType")
                    {
                        ((DataGridViewComboBoxColumn)oColumn).Items.AddRange(Enum.GetNames(typeof(EInvType)));
                    }
                    else if (oColumn.Name == "colCurrency")
                    {
                        if (CurrencyList.Count > 0)
                        {
                            ((DataGridViewComboBoxColumn)oColumn).DataSource = CurrencyList;
                            ((DataGridViewComboBoxColumn)oColumn).DisplayMember = "Curr_Code";
                            ((DataGridViewComboBoxColumn)oColumn).ValueMember = "Curr_OID";
                        }
                    }
                }
            }
            SetDefaultValue();
        }

        private void SetDefaultValue()
        {
            for (int i = 0; i < dgItemList.Rows.Count; i++)
            {
                DataGridViewComboBoxCell cmbSrcLoc = ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colSourceLoc"]);
                foreach (object obj in cmbSrcLoc.Items)
                {
                    CLocation oloc = (CLocation)obj;
                    cmbSrcLoc.Value = oloc.Loc_OID.Trim();
                    break;
                }

                DataGridViewComboBoxCell cmbSrcInvTyp = ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colSrcInvType"]);
                foreach (object obj in cmbSrcInvTyp.Items)
                {
                    cmbSrcInvTyp.Value = obj;
                    break;
                }

                DataGridViewComboBoxCell cmbCurrency = ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colCurrency"]);
                foreach (object obj in cmbCurrency.Items)
                {
                    CCurrency ocur = (CCurrency)obj;
                    cmbCurrency.Value = ocur.Curr_OID;
                    break;
                }

            }
        }

        private void GetGRNextCode()
        {
            CResult oResult = new CResult();
            CCommonBO oCommonBO = new CCommonBO();

            oResult = oCommonBO.ReadLastCodeNo("GRMstr_Code", "GRMstr", currentBranch.CompBrn_Code);
            if (oResult.IsSuccess)
            {
                txtGRNo.Text = oResult.Data.ToString();
            }
            else
            {
                MessageBox.Show("Loading error...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void ClearFormData()
        {
            txtRefNo.Text = "";
            txtGRNo.Text = "";
            txtRemarks.Text = "";
            txtSAddress.Text = "";
            txtSelectedGROID.Text = "";
            txtTotalAmt.Text = "0.00";
            txtRecievedBy.Text = "";
            ///ddlSupplier.SelectedIndex = 0;
            ddlType.SelectedIndex = 2;
            dtpGRDate.Value = DateTime.Now.Date;

            dgItemList.Rows.Clear();
            FormControlMode(0);
            GetGRNextCode();
        }

        private bool ValidateListItem(DataGridViewRow oRow)
        {
            StringBuilder oBuilder = new StringBuilder();
            oBuilder.Append("Please insert ");
            if (oRow.Cells["colItemName"].Value == null)
            {
                oBuilder.Append("ItemName");
            }
            if (oRow.Cells["colIssueqty"].Value == null)
            {
                oBuilder.Append(", Qty ");
            }
            if (oBuilder.ToString() != "Please insert ")
            {
                MessageBox.Show(oBuilder.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }


        // Update inventory
        Dictionary<string, CGRDetails> oGRFinalQtyDic = new Dictionary<string, CGRDetails>();

        private CGRMaster GetToBSavedData()
        {
            oGRFinalQtyDic.Clear();

            CGRMaster oGRMaster = new CGRMaster();

            oGRMaster.GRMstr_OID = txtSelectedGROID.Text.Trim();
            CCompanyBranch branch = (CCompanyBranch)cmbBranch.SelectedItem;
            oGRMaster.GRMstr_Branch = branch.CompBrn_Code;
            oGRMaster.GRMstr_Code = txtGRNo.Text.Trim();
            oGRMaster.GRMstr_Type = Convert.ToInt32(Enum.Parse(typeof(EGRType), ddlType.SelectedItem.ToString()));
            oGRMaster.GRMstr_Date = dtpGRDate.Value.Date;
            oGRMaster.GRMstr_By = txtRecievedBy.Text.Trim();
            oGRMaster.Remarks = txtRemarks.Text.Trim();

            if (currentBranch.CompBrn_OId == "CompBrnXBRN01 0000000001")
            {
                oGRMaster.GRMstr_IsImported = 0;
            }
            else if (currentBranch.CompBrn_OId != "CompBrnXBRN01 0000000001")
            {
                oGRMaster.GRMstr_IsImported = 1;
            }
            // oGRMaster.GRMstr_VendorID = ddlSupplier.SelectedValue.ToString();
            oGRMaster.GRMstr_RefBy = txtRefNo.Text.Trim();


            oGRMaster.Creator = currentUser.User_OID;
            oGRMaster.CreationDate = DateTime.Now.Date;
            oGRMaster.UpdateBy = currentUser.User_OID;
            oGRMaster.UpdateDate = DateTime.Now.Date;
            oGRMaster.IsActive = "Y";
            oGRMaster.Remarks = "";


            for (int i = 0; i < dgItemList.Rows.Count - 1; i++)
            {
                if (ValidateListItem(dgItemList.Rows[i]))
                {
                    CGRDetails oGRDetails = new CGRDetails();

                    oGRDetails.GRDet_Branch = branch.CompBrn_Code;

                    oGRDetails.GRDet_ItemOID = ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colItemName"]).Value.ToString();
                    if (dgItemList.Rows[i].Cells["colIssueqty"].Value != null)
                    {
                        oGRDetails.GRDet_QTY = float.Parse(((DataGridViewTextBoxCell)dgItemList.Rows[i].Cells["colIssueqty"]).Value.ToString());
                    }

                    if (dgItemList.Rows[i].Cells["colIssueUOM"].Value != null)
                        oGRDetails.GRDet_UOM = ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colIssueUOM"]).Value.ToString();

                    oGRDetails.GRDet_BranchOID = currentBranch.CompBrn_OId;

                    if (dgItemList.Rows[i].Cells["colSourceLoc"].Value != null)
                        oGRDetails.GRDet_LocOID = ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colSourceLoc"]).Value.ToString();

                    if (dgItemList.Rows[i].Cells["colSrcInvType"].Value != null)
                    {
                        oGRDetails.GRDet_InvType = Convert.ToInt32(Enum.Parse(typeof(EInvType), ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colSrcInvType"]).Value.ToString()));
                    }

                    if (dgItemList.Rows[i].Cells["colPrice"].Value != null)
                        oGRDetails.GRDet_Price = float.Parse(((DataGridViewTextBoxCell)dgItemList.Rows[i].Cells["colPrice"]).Value.ToString());
                    if (dgItemList.Rows[i].Cells["colCurrency"].Value != null)
                        oGRDetails.GRDet_Currency = ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colCurrency"]).Value.ToString();
                    if (dgItemList.Rows[i].Cells["colAmount"].Value != null)
                        oGRDetails.GRDet_Amount = float.Parse(((DataGridViewTextBoxCell)dgItemList.Rows[i].Cells["colAmount"]).Value.ToString());

                    oGRMaster.GRMstr_DetailsList.Add(oGRDetails);

                    if (IsUpdateMode)
                    {
                            CGRDetails oInvGRDetails = new CGRDetails();

                            oInvGRDetails.GRDet_Branch = oGRDetails.GRDet_Branch;
                            oInvGRDetails.GRDet_BranchOID = oGRDetails.GRDet_BranchOID;
                            oInvGRDetails.GRDet_ItemOID = oGRDetails.GRDet_ItemOID;
                            oInvGRDetails.GRDet_LocOID = oGRDetails.GRDet_LocOID;
                            oInvGRDetails.GRDet_InvType = oGRDetails.GRDet_InvType;
                            if (dgItemList.Rows[i].Cells["colInvtQty"].Value != null)
                            {
                                oInvGRDetails.GRDet_QTY = float.Parse(((DataGridViewTextBoxCell)dgItemList.Rows[i].Cells["colInvtQty"]).Value.ToString());
                            }
                        else
                            {
                                oInvGRDetails.GRDet_QTY = 0.00f;
                            }
                            oGRFinalQtyDic.Add(oInvGRDetails .GRDet_ItemOID, oInvGRDetails);
                    }
                }
                else
                {
                    return null;
                }
            }

            foreach (string obj in oGRExistingQtyDic.Keys)
            {
                if (!oGRFinalQtyDic.ContainsKey(obj))
                {
                    CGRDetails objDetls=new CGRDetails();
                    objDetls.GRDet_Branch = oGRExistingQtyDic[obj].GRDet_Branch;
                    objDetls.GRDet_BranchOID = oGRExistingQtyDic[obj].GRDet_BranchOID;
                    objDetls.GRDet_InvType = oGRExistingQtyDic[obj].GRDet_InvType;
                    objDetls.GRDet_ItemOID = oGRExistingQtyDic[obj].GRDet_ItemOID;
                    objDetls.GRDet_LocOID = oGRExistingQtyDic[obj].GRDet_LocOID;
                    objDetls.GRDet_QTY = oGRExistingQtyDic[obj].GRDet_QTY * -1;

                    oGRFinalQtyDic.Add(obj, objDetls);
                }
            }

            return oGRMaster;
        }


        private CGRMaster GetToBSavedDataExportBranch()
        {
            oGRFinalQtyDic.Clear();

            CGRMaster oGRMaster = new CGRMaster();

            oGRMaster.GRMstr_OID = txtSelectedGROID.Text.Trim();
            oGRMaster.GRMstr_Branch = currentBranch.CompBrn_Code;//cmbBranch.SelectedItem.ToString();
            oGRMaster.GRMstr_Code = txtGRNo.Text.Trim();
            oGRMaster.GRMstr_Type = Convert.ToInt32(Enum.Parse(typeof(EGRType), ddlType.SelectedItem.ToString()));
            oGRMaster.GRMstr_Date = dtpGRDate.Value.Date;
            oGRMaster.GRMstr_By = txtRecievedBy.Text.Trim();
            oGRMaster.Remarks = txtRemarks.Text.Trim();

            if (currentBranch.CompBrn_OId == "CompBrnXBRN01 0000000001")
            {
                oGRMaster.GRMstr_IsImported = 0;
            }
            else if (currentBranch.CompBrn_OId != "CompBrnXBRN01 0000000001")
            {
                oGRMaster.GRMstr_IsImported = 1;
            }
            // oGRMaster.GRMstr_VendorID = ddlSupplier.SelectedValue.ToString();
            oGRMaster.GRMstr_RefBy = txtRefNo.Text.Trim();


            oGRMaster.Creator = currentUser.User_OID;
            oGRMaster.CreationDate = DateTime.Now.Date;
            oGRMaster.UpdateBy = currentUser.User_OID;
            oGRMaster.UpdateDate = DateTime.Now.Date;
            oGRMaster.IsActive = "Y";
            oGRMaster.Remarks = "";


            for (int i = 0; i < dgItemList.Rows.Count - 1; i++)
            {
                if (ValidateListItem(dgItemList.Rows[i]))
                {
                    CGRDetails oGRDetails = new CGRDetails();
                    CCompanyBranch oCompanyBranch =(CCompanyBranch)cmbBranch.SelectedItem;
                    oGRDetails.GR_Date = DateTime.Now.Date;
                    oGRDetails.GRDet_Branch = oCompanyBranch.CompBrn_Code;

                    oGRDetails.GRDet_ItemOID = ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colItemName"]).Value.ToString();
                    if (dgItemList.Rows[i].Cells["colIssueqty"].Value != null)
                    {
                        oGRDetails.GRDet_QTY = float.Parse(((DataGridViewTextBoxCell)dgItemList.Rows[i].Cells["colIssueqty"]).Value.ToString());
                    }

                    if (dgItemList.Rows[i].Cells["colIssueUOM"].Value != null)
                        oGRDetails.GRDet_UOM = ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colIssueUOM"]).Value.ToString();

                    oGRDetails.GRDet_BranchOID = currentBranch.CompBrn_OId;

                    if (dgItemList.Rows[i].Cells["colSourceLoc"].Value != null)
                        oGRDetails.GRDet_LocOID = ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colSourceLoc"]).Value.ToString();

                    if (dgItemList.Rows[i].Cells["colSrcInvType"].Value != null)
                    {
                        oGRDetails.GRDet_InvType = Convert.ToInt32(Enum.Parse(typeof(EInvType), ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colSrcInvType"]).Value.ToString()));
                    }

                    if (dgItemList.Rows[i].Cells["colPrice"].Value != null)
                        oGRDetails.GRDet_Price = float.Parse(((DataGridViewTextBoxCell)dgItemList.Rows[i].Cells["colPrice"]).Value.ToString());
                    if (dgItemList.Rows[i].Cells["colCurrency"].Value != null)
                        oGRDetails.GRDet_Currency = ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colCurrency"]).Value.ToString();
                    if (dgItemList.Rows[i].Cells["colAmount"].Value != null)
                        oGRDetails.GRDet_Amount = float.Parse(((DataGridViewTextBoxCell)dgItemList.Rows[i].Cells["colAmount"]).Value.ToString());

                    oGRMaster.GRMstr_DetailsList.Add(oGRDetails);


                        CGRDetails oInvGRDetails = new CGRDetails();

                        oInvGRDetails.GRDet_Branch = oGRDetails.GRDet_Branch;
                        oInvGRDetails.GRDet_BranchOID = oGRDetails.GRDet_BranchOID;
                        oInvGRDetails.GRDet_ItemOID = oGRDetails.GRDet_ItemOID;
                        oInvGRDetails.GRDet_LocOID = oGRDetails.GRDet_LocOID;
                        oInvGRDetails.GRDet_InvType = oGRDetails.GRDet_InvType;
                        if (dgItemList.Rows[i].Cells["colInvtQty"].Value != null)
                        {
                            oInvGRDetails.GRDet_QTY = float.Parse(((DataGridViewTextBoxCell)dgItemList.Rows[i].Cells["colInvtQty"]).Value.ToString());
                        }
                        else
                        {
                            oInvGRDetails.GRDet_QTY = 0.00f;
                        }
                        oGRFinalQtyDic.Add(oInvGRDetails.GRDet_ItemOID, oInvGRDetails);
                 
                }
                else
                {
                    return null;
                }
            }

            foreach (string obj in oGRExistingQtyDic.Keys)
            {
                if (!oGRFinalQtyDic.ContainsKey(obj))
                {
                    CGRDetails objDetls = new CGRDetails();
                    objDetls.GRDet_Branch = oGRExistingQtyDic[obj].GRDet_Branch;
                    objDetls.GRDet_BranchOID = oGRExistingQtyDic[obj].GRDet_BranchOID;
                    objDetls.GRDet_InvType = oGRExistingQtyDic[obj].GRDet_InvType;
                    objDetls.GRDet_ItemOID = oGRExistingQtyDic[obj].GRDet_ItemOID;
                    objDetls.GRDet_LocOID = oGRExistingQtyDic[obj].GRDet_LocOID;
                    objDetls.GRDet_QTY = oGRExistingQtyDic[obj].GRDet_QTY * -1;

                    oGRFinalQtyDic.Add(obj, objDetls);
                }
            }

            return oGRMaster;
        }


        private bool ValidationData()
        {
            if (dgItemList.Rows.Count <= 1)
            {
                MessageBox.Show("No details Item to save. ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            for (int i = 0; i <= dgItemList.Rows.Count; i++)
            {
                try
                {
                    if (Convert.ToInt32(dgItemList.Rows[i].Cells["colIssueqty"].Value.ToString()) <= 0)
                    {
                        MessageBox.Show("Receive quantity is not valid. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }

                catch(Exception e)
                {
                    
                }
            }
            
            
            return true;
        }

        private void FormControlMode(int i)
        {
            switch (i)
            {
                case 0:
                    btnSave.Text = "Save";
                    btnDelete.Enabled = false;
                    IsUpdateMode = false;
                    ddlType.Enabled = true;
                    IsImportedData = false;
                    txtRefNo.ReadOnly = false;
                    break;
                case 1:
                    //btnSave.Text = "Update";
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    IsUpdateMode = true;
                    IsImportedData = false;
                    txtRefNo.ReadOnly = false;
                    break;
                case 2:
                    ddlType.SelectedIndex = 0;
                    ddlType.Enabled = false;
                    txtRefNo.ReadOnly = true;
                    IsImportedData = true;
                    break;
            }
        }

        Dictionary<string, CGRDetails> oGRExistingQtyDic = new Dictionary<string, CGRDetails>();

        private void  FillForm(CGRMaster oGRMaster)
        {
            oGRExistingQtyDic.Clear();

            txtSelectedGROID.Text = oGRMaster.GRMstr_OID;
            txtGRNo.Text = oGRMaster.GRMstr_Code;
            ddlType.SelectedValue = oGRMaster.GRMstr_Type;
            dtpGRDate.Value = oGRMaster.GRMstr_Date;
            txtRecievedBy.Text = oGRMaster.GRMstr_By;
            txtRemarks.Text = oGRMaster.Remarks;
            ddlSupplier.SelectedValue = oGRMaster.GRMstr_VendorID;
            txtRefNo.Text = oGRMaster.GRMstr_RefBy;

            dgItemList.Rows.Clear();

            foreach (CGRDetails oGRDetails in oGRMaster.GRMstr_DetailsList)
            {
                dgItemList.Rows.Add();
                DataGridViewRow odgRow = dgItemList.Rows[dgItemList.Rows.Count - 2];

                odgRow.Cells["colItemName"].Value = oGRDetails.GRDet_ItemOID.Trim();
                odgRow.Cells["colIssueqty"].Value = oGRDetails.GRDet_QTY.ToString();
                odgRow.Cells["colIssueUOM"].Value = oGRDetails.GRDet_UOM.Trim();
                odgRow.Cells["colSourceLoc"].Value = oGRDetails.GRDet_LocOID.Trim();
                odgRow.Cells["colSrcInvType"].Value = Enum.GetName(typeof(EInvType), oGRDetails.GRDet_InvType);
                odgRow.Cells["colPrice"].Value = oGRDetails.GRDet_Price.ToString("F2").Trim();
                if( oGRDetails.GRDet_Currency.Trim()!="")
                odgRow.Cells["colCurrency"].Value = oGRDetails.GRDet_Currency.Trim();
                odgRow.Cells["colAmount"].Value = oGRDetails.GRDet_Amount.ToString("F2").Trim();
                //odgRow.Cells["NowQty"].Value = oGRDetails.GRdet_InvQ.ToString();


                if (IsUpdateMode)
                {
                    oGRExistingQtyDic.Add(oGRDetails.GRDet_ItemOID.Trim(), oGRDetails);
                //    odgRow.Cells["colInvtQty"].Value = oGRDetails.GRDet_QTY.ToString("F2");
                }
            }
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            float fTotalVal = 0.00f;
            for (int i = 0; i < dgItemList.Rows.Count; i++)
            {
                if (dgItemList.Rows[i].Cells["colAmount"].Value != null)
                {
                    fTotalVal = fTotalVal + float.Parse(dgItemList.Rows[i].Cells["colAmount"].Value.ToString());
                }
            }
            txtTotalAmt.Text = fTotalVal.ToString();
        }


        private CGRMaster LoadImportedData(CMTMaster oMTMaster)
        {
            CGRMaster oGRMaster = new CGRMaster();

            oGRMaster.GRMstr_Branch = currentBranch.CompBrn_Branch;
            oGRMaster.GRMstr_By = currentUser.User_OID;
            oGRMaster.GRMstr_RefBy = oMTMaster.MTMstr_DOrder;
            oGRMaster.GRMstr_Type = 0;
            oGRMaster.Creator = currentUser.User_OID;
            oGRMaster.CreationDate = DateTime.Now.Date;

            foreach (CMTDetails oMTDetails in oMTMaster.MTMstr_DetailsList)
            {
                CGRDetails oGRDetails = new CGRDetails();

                oGRDetails.GRDet_ItemOID = oMTDetails.MTDtls_ItemOID;
                oGRDetails.GRDet_QTY = oMTDetails.MTDtls_IssQty;
                oGRDetails.GRDet_UOM = oMTDetails.MTDtls_IssUOMOID;
                oGRDetails.GRDet_LocOID = oMTDetails.MTDtls_DestLocOID;
                oGRDetails.GRDet_InvType = oMTDetails.MTDtls_DesInvtyp;

                oGRMaster.GRMstr_DetailsList.Add(oGRDetails);
            }

            return oGRMaster;
        }


        //private bool ValidatateGRList()
        //{
        //    for (int i = 1; i < dgItemList.Rows.Count - 1; i++)
        //    {
        //        if (((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colItem"]).Value != null)
        //        {
        //            if (((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colItem"]).Value.ToString() == ((DataGridViewComboBoxCell)dgItemList.Rows[i - 1].Cells["colItem"]).Value.ToString()
        //                && ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colSourceLoc"]).Value.ToString() == ((DataGridViewComboBoxCell)dgItemList.Rows[i - 1].Cells["colSourceLoc"]).Value.ToString()
        //                && ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colSrcInvType"]).Value.ToString() == ((DataGridViewComboBoxCell)dgItemList.Rows[i - 1].Cells["colSrcInvType"]).Value.ToString()
        //                )
        //            {

        //                if (MessageBox.Show("There is another data of Item :" + (DataGridViewTextBoxCell)dgItemList.Rows[i].Cells["colItemName"].Value.ToString(), "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        //                {
        //                    return true;
        //                }
        //                else
        //                {
        //                    return false;
        //                }
        //            }
        //        }
        //    }
        //    return true;
        //}

        #endregion

        #region "Events"

        private void frmGR_Load(object sender, EventArgs e)
        {
            this.btnImport.Enabled = true;
            if (currentBranch.CompBrn_IsHeadoffice != "Y")
            {
                this.btnImport.Enabled = true;
            }

            ddlType.Items.AddRange(Enum.GetNames(typeof(EGRType)));
            ddlType.SelectedIndex = 2;
            ddlSupplier.SelectedIndex = -1;
            FormControlMode(0);
            GetGRNextCode();
            // LoadComapanyBranch();
            LoadSupplierData();
            LoadItemData();
            LoadUOMData();
            LoadLocationData();
            LoadCurrencyData();
            LoadDataGridItem();
            LoadExportedBranch();

        }

        private void LoadExportedBranch()
        {
            CResult oResult = new CResult();
            CCompanyBranchBO oCompanyBranchBO = new CCompanyBranchBO();
            oResult = oCompanyBranchBO.ReadAll();

            if (oResult.IsSuccess)
            {
                cmbBranch.DataSource = oResult.Data as List<CCompanyBranch>;
                cmbBranch.DisplayMember = "CompBrn_Code";
                cmbBranch.ValueMember = "CompBrn_OId";

                cmbBranch.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Loading error...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgItemList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.RowIndex != (dgItemList.Rows.Count - 1))
                {
                    // Validation Start
                    if (dgItemList.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn == dgItemList.Rows[e.RowIndex].Cells["colIssueqty"].OwningColumn)
                    {
                        string sQTYTemp = dgItemList.Rows[e.RowIndex].Cells["colIssueqty"].Value.ToString().Trim();
                        float fQTYTemp = 0f;
                        if (!float.TryParse(sQTYTemp, out fQTYTemp))
                        {
                            dgItemList.Rows[e.RowIndex].Cells["colIssueqty"].Value = fQTYTemp.ToString();
                        }
                    }
                    if (dgItemList.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn == dgItemList.Rows[e.RowIndex].Cells["colPrice"].OwningColumn)
                    {
                        string sQTYTemp = dgItemList.Rows[e.RowIndex].Cells["colPrice"].Value.ToString().Trim();
                        float fQTYTemp = 0f;
                        if (!float.TryParse(sQTYTemp, out fQTYTemp))
                        {
                            dgItemList.Rows[e.RowIndex].Cells["colPrice"].Value = fQTYTemp.ToString();
                        }
                    }
                    // Validation End

                    // Change Item
                    if (dgItemList.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn == dgItemList.Rows[e.RowIndex].Cells["colItemName"].OwningColumn)
                    {
                        foreach (CItem oItem in arrItemList)
                        {
                            if (string.Equals(oItem.Item_OID.Trim(), dgItemList.Rows[e.RowIndex].Cells["colItemName"].Value.ToString().Trim()))
                            {
                                dgItemList.Rows[e.RowIndex].Cells["colItem"].Value = oItem.Item_Code;
                                dgItemList.Rows[e.RowIndex].Cells["colIssueUOM"].Value = oItem.Item_UOMID;
                                dgItemList.Rows[e.RowIndex].Cells["colPrice"].Value = oItem.Item_Sprice;
                                dgItemList.Rows[e.RowIndex].Cells["NowQty"].Value = oItem.InvQty;
                                break;
                            }
                        }
                    }

                    // for imported data
                    if (IsImportedData == true && dgItemList.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn == dgItemList.Rows[e.RowIndex].Cells["colIssueqty"].OwningColumn)
                    {
                        float fVAL = float.Parse(dgItemList.Rows[e.RowIndex].Cells["colIssueqty"].Value.ToString());

                        gItemQty = gItemQty - fVAL;
                        CopyGRDetailsData(dgItemList.Rows.Count - 1, e.RowIndex);
                    }
                    // calculate price amount
                    if (dgItemList.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn == dgItemList.Rows[e.RowIndex].Cells["colIssueqty"].OwningColumn)
                    {
                        if (dgItemList.Rows[e.RowIndex].Cells["colPrice"].Value == null)
                        {
                            dgItemList.Rows[e.RowIndex].Cells["colPrice"].Value = "0";

                            
                        }
                        float fVAL = float.Parse(dgItemList.Rows[e.RowIndex].Cells["colIssueqty"].Value.ToString()) * float.Parse(dgItemList.Rows[e.RowIndex].Cells["colPrice"].Value.ToString());
                        dgItemList.Rows[e.RowIndex].Cells["colAmount"].Value = fVAL.ToString();

                        if (dgItemList.Rows[e.RowIndex].Cells["NowQty"].Value != null)
                        {
                            float aa = float.Parse(dgItemList.Rows[e.RowIndex].Cells["NowQty"].Value.ToString());
                            float fVALQty = aa - float.Parse(dgItemList.Rows[e.RowIndex].Cells["colIssueqty"].Value.ToString());
                            dgItemList.Rows[e.RowIndex].Cells["NowQty"].Value = fVALQty.ToString();
                        }

                        CalculateTotal();

                    }

                    // calculate price amount
                    if (dgItemList.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn == dgItemList.Rows[e.RowIndex].Cells["colPrice"].OwningColumn)
                    {
                        if (dgItemList.Rows[e.RowIndex].Cells["colIssueqty"].Value == null)
                        {
                            dgItemList.Rows[e.RowIndex].Cells["colIssueqty"].Value = "1";
                        }
                        float fVAL = float.Parse(dgItemList.Rows[e.RowIndex].Cells["colIssueqty"].Value.ToString()) * float.Parse(dgItemList.Rows[e.RowIndex].Cells["colPrice"].Value.ToString());
                        dgItemList.Rows[e.RowIndex].Cells["colAmount"].Value = fVAL.ToString();
                        

                        CalculateTotal();
                    }

                    //for update inventory
                    if (oGRExistingQtyDic.Count > 0 && IsUpdateMode == true && dgItemList.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn == dgItemList.Rows[e.RowIndex].Cells["colIssueqty"].OwningColumn)
                    {
                        float fVAL = float.Parse(dgItemList.Rows[e.RowIndex].Cells["colIssueqty"].Value.ToString());

                        if (oGRExistingQtyDic.ContainsKey(dgItemList.Rows[e.RowIndex].Cells["colItem"].Value.ToString().Trim()))
                        {
                            fVAL = fVAL - oGRExistingQtyDic[dgItemList.Rows[e.RowIndex].Cells["colItem"].Value.ToString().Trim()].GRDet_QTY;
                        }

                        dgItemList.Rows[e.RowIndex].Cells["colInvtQty"].Value = fVAL.ToString("F2");
                    }
                    
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidationData())
            {
                CResult oResult = new CResult();
                CGRBO oGRBO = new CGRBO();
                CGRMaster oMaster = GetToBSavedData();

                if (oMaster != null)
                {
                    if (!IsUpdateMode)
                    {
                        oResult = oGRBO.Create(oMaster);
                    }
                    else
                    {
                        oResult = oGRBO.Update(oMaster,oGRFinalQtyDic);
                    }

                    if (oResult.IsSuccess)
                    {
                        MessageBox.Show("Successfully Done. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFormData();
                        GetGRNextCode();
                    }
                    else
                    {
                        MessageBox.Show(oResult.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDelelefrmList_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgItemList.Rows.Count - 1; i++)
            {
                DataGridViewCheckBoxCell oCheckBoxCell = ((DataGridViewCheckBoxCell)dgItemList.Rows[i].Cells["CheckBox"]);

                if ((bool)oCheckBoxCell.FormattedValue)
                {
                    dgItemList.Rows.RemoveAt(i);
                    i--;
                }
            }
        }

        private void dgItemList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                // for imported data
                if (IsImportedData == true && dgItemList.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn == dgItemList.Rows[e.RowIndex].Cells["colIssueqty"].OwningColumn)
                {
                    gItemQty = float.Parse(dgItemList.Rows[e.RowIndex].Cells["colIssueqty"].Value.ToString());
                }


                // to copy previous row of the dg
                if (dgItemList.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn == dgItemList.Rows[e.RowIndex].Cells["colCopy"].OwningColumn)
                {
                    if (dgItemList.Rows.Count - 1 > 0)
                    {

                        // implementation has been stopped 
                        //CopyGRDetailsData(dgItemList.Rows.Count - 1, dgItemList.Rows.Count - 2); 
                    }

                    CalculateTotal();
                }
            }
        }

        private void CopyGRDetailsData(int nTop1Index, int nTop2Index)
        {
            if (dgItemList.Rows[dgItemList.Rows.Count - 1].Cells["colItem"].Value == null)
            {
                dgItemList.Rows[nTop1Index].Cells["colItemName"].Value = dgItemList.Rows[nTop2Index].Cells["colItemName"].Value;
                dgItemList.Rows[nTop1Index].Cells["colItem"].Value = dgItemList.Rows[nTop2Index].Cells["colItem"].Value;
                dgItemList.Rows[nTop1Index].Cells["colIssueqty"].Value = gItemQty.ToString("F2");//dgItemList.Rows[nTop2Index].Cells["colIssueqty"].Value;
                dgItemList.Rows[nTop1Index].Cells["colIssueUOM"].Value = dgItemList.Rows[nTop2Index].Cells["colIssueUOM"].Value;
                dgItemList.Rows[nTop1Index].Cells["colSourceLoc"].Value = dgItemList.Rows[nTop2Index].Cells["colSourceLoc"].Value;
                dgItemList.Rows[nTop1Index].Cells["colSrcInvType"].Value = Enum.GetName(typeof(EInvType), EInvType.SHORTAGE);//EInvType.SHORTAGE;//dgItemList.Rows[nTop2Index].Cells["colSrcInvType"].Value;
                dgItemList.Rows[nTop1Index].Cells["colPrice"].Value = dgItemList.Rows[nTop2Index].Cells["colPrice"].Value;
                dgItemList.Rows[nTop1Index].Cells["colCurrency"].Value = dgItemList.Rows[nTop2Index].Cells["colCurrency"].Value;
                dgItemList.Rows[nTop1Index].Cells["colAmount"].Value = dgItemList.Rows[nTop2Index].Cells["colAmount"].Value;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            FormControlMode(0);
            ClearFormData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Do you really want to delete this Item ? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
            {
                CResult oResult = new CResult();
                CGRBO oGRBO = new CGRBO();

                if (IsUpdateMode)
                {
                    oResult = oGRBO.Delete(txtSelectedGROID.Text.Trim());
                }

                if (oResult.IsSuccess)
                {
                    MessageBox.Show("Successfully Done. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFormData();
                }
                else
                {
                    MessageBox.Show(oResult.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGRS_Click(object sender, EventArgs e)
        {
            frmSearchGeneric<CGRMaster> oSearch = new frmSearchGeneric<CGRMaster>(Convert.ToInt32(Enum.Parse(typeof(EGRType), ddlType.SelectedItem.ToString())).ToString());
            oSearch.SelectedEvent += new frmSearchGeneric<CGRMaster>.EventHandler(oSearch_SelectedEvent);
            oSearch.ShowDialog();
        }

        void oSearch_SelectedEvent(object sender, SearchEventArgs<CGRMaster> e)
        {
            FormControlMode(1);
            CGRMaster oMTMaster = e.t;
            FillForm(oMTMaster);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlSupplier.SelectedIndex != -1)
            {
                foreach (CSupplier oSupplier in arrSupplierList)
                {
                    if (oSupplier.Cust_OId.Trim() == ddlSupplier.SelectedValue.ToString().Trim())
                    {
                        StringBuilder oBuilder = new StringBuilder();

                        oBuilder.Append(oSupplier.Cust_Phone);
                        oBuilder.Append(oSupplier.Cust_Email);
                        oBuilder.Append(oSupplier.Cust_Address);

                        txtSAddress.Text = oBuilder.ToString();
                    }
                }
            }
        }

        private void dgItemList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            SetDefaultValue();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            

            if (ValidationData())
            {
                CResult oResulto = new CResult();
                CGRBO oGRBOo = new CGRBO();
                CGRMaster oMastero = GetToBSavedDataExportBranch();

                if (oMastero != null)
                {
                    oResulto = oGRBOo.CreateExportInBranch(oMastero);

                    //if (oResulto.IsSuccess)
                    //{
                    //    MessageBox.Show("Successfully Done. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    ClearFormData();
                    //    GetGRNextCode();
                    //}
                    //else
                    //{
                    //    MessageBox.Show(oResulto.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }
            }




            #region import

            //if (ValidationData())
            //{
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Save an CSV File";
            saveFileDialog1.FileName = "InventoryExport.csv";
            saveFileDialog1.ShowDialog();
            string url = "";
            if (saveFileDialog1.FileName != "")
            {
                url = saveFileDialog1.FileName;
            }
            else
            {
                url = "InventoryExport.csv";
            }
            
            // Data2PDF();
            CResult oResult = new CResult();
            CGRBO oGRBO = new CGRBO();
            CGRMaster oMaster = GetToBSavedData();

            if (oMaster != null)
            {
                if (!IsUpdateMode)
                {

                    oResult = oGRBO.ExportAndUpdate(oMaster, url);
                    //  SaveExcelFile(dt);
                }
                else
                {
                    oResult = oGRBO.Update(oMaster, oGRFinalQtyDic);
                }

                if (oResult.IsSuccess)
                {
                    MessageBox.Show("Successfully Done. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFormData();
                    GetGRNextCode();
                }
                else
                {
                    MessageBox.Show(oResult.ErrMsg, "Inventory empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // }
            #endregion
        }

        #endregion   

        private void button1_Click(object sender, EventArgs e)
        {
            frmSupplier oSupplier = new frmSupplier();
            oSupplier.Show();
        }

        private void btnSearchItem_Click(object sender, EventArgs e)
        {
            frmSearchItem ofrmSearchItem = new frmSearchItem(true);
            ofrmSearchItem.ShowDialog();
            List<string> oItemOIDList = ofrmSearchItem.oItemOIDList;
            if (oItemOIDList != null)
            {
                foreach (string oItemOID in oItemOIDList)
                {
                    dgItemList.Rows.Add();
                    ((DataGridViewComboBoxCell)dgItemList.Rows[dgItemList.Rows.Count - 2].Cells["colItemName"]).Value = oItemOID;
                }
            }
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            if (txtItemCode.Text.Trim() != "")
            {
                LoadItemByItemCode(txtItemCode.Text.Trim());
            }
        }

        private void LoadItemByItemCode(string oItemCode)
        {
            CResult oResult = new CResult();
            CItemBO oItemBO = new CItemBO();
            oResult = oItemBO.ReadAllByItemCode(oItemCode);
            CItem oItem = new CItem();
            if (oResult.IsSuccess)
            {
                oItem = oResult.Data as CItem;
                if (oItem != null)
                {
                    dgItemList.Rows.Add();
                    ((DataGridViewComboBoxCell)dgItemList.Rows[dgItemList.Rows.Count - 2].Cells["colItemName"]).Value = oItem.Item_OID;
                    txtItemCode.Clear();
                }
            }
            else
            {
                MessageBox.Show("Insert Item Price First and then Set Item Price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
