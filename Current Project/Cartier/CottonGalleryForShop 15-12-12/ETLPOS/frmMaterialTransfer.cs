using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using CrystalDecisions.Windows.Forms;

using ETL.BLL;
using ETL.Common;
using ETL.Model;

namespace ETLPOS
{
    public partial class frmMaterialTransfer : BaseForm
    {
        #region "Declarations"

        bool IsUpdateMode = false;
        ArrayList arrItemList = new ArrayList();
        ArrayList arrUOMList = new ArrayList();
        ArrayList arrLocationList= new ArrayList();
        List<CCompanyBranch> lBranchList = new List<CCompanyBranch>();
        List<CCVB> oCVBList = new List<CCVB>();

        #endregion

        #region "Methods"

        public frmMaterialTransfer()
        {
            InitializeComponent();

        }

        private void FormControlMode(int i)
        {
            switch (i)
            {
                case 0:
                    btnSave.Text = "Save";
                    btnDelete.Enabled = false;
                    IsUpdateMode = false;
                    break;
                case 1:
                    btnSave.Text = "Update";
                    btnDelete.Enabled = true;
                    IsUpdateMode = true;
                    break;
            }
        }

        private void GetDeliverID()
        {
            CResult oResult = new CResult();
            CCommonBO oCommonBO = new CCommonBO();

            oResult = oCommonBO.ReadLastCodeNo("MTMstr_DOrder", "MTMstr", currentBranch.CompBrn_Code);
            if (oResult.IsSuccess)
            {
                txtDeliverOrder.Text = oResult.Data.ToString();
            }
            else
            {
                MessageBox.Show("Loading error...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComapanyBranch()
        {
            CResult oResult = new CResult();
            CCompanyBranchBO oCompanyBranchBO = new CCompanyBranchBO();
            oResult = oCompanyBranchBO.ReadAll();

            if (oResult.IsSuccess)
            {
                lBranchList = oResult.Data as List<CCompanyBranch>;
                //ddlBranch.DataSource = oResult.Data as List<CCompanyBranch>;
                //ddlBranch.DisplayMember = "CompBrn_Code";
                //ddlBranch.ValueMember = "CompBrn_OId";
            }
            else
            {
                MessageBox.Show("Loading error...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void LoadLocationData()
        {
            CResult oResult = new CResult();
            CLocBO oLocBO = new CLocBO();
            oResult = oLocBO.ReadAll();

            if (oResult.IsSuccess)
            {
                arrLocationList = oResult.Data as ArrayList;
            }
            else
            {
                MessageBox.Show("Loading error...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRelationData()
        {
            CResult oResult = new CResult();
            CCVB oCVB = new CCVB();
            CMaterialTransferBO oMTBO = new CMaterialTransferBO();
            oResult = oMTBO.ReadAll(oCVB);

            if (oResult.IsSuccess)
            {
                oCVBList = oResult.Data as List<CCVB>;
            }
            else
            {
                MessageBox.Show("Loading error...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private float InventoryItemData(int i)
        {
            CResult oResult = new CResult();
            CInventoryBO oInventoryBO = new CInventoryBO();

            CInventory oInventory = new CInventory();
           
                if (dgItemList.Rows[i].Cells["colItem"].Value != null)
                oInventory.Invt_ItemOID = ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colItem"]).Value.ToString();
                if (dgItemList.Rows[i].Cells["colSrcBranch"].Value != null)
                oInventory.Invt_BranchOID = ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colSrcBranch"]).Value.ToString();
                if (dgItemList.Rows[i].Cells["colSourceLoc"].Value != null)
                oInventory.Invt_LocOID = ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colSourceLoc"]).Value.ToString();
                if (dgItemList.Rows[i].Cells["colSrcInvType"].Value != null)
                    oInventory.Invt_InvType = Convert.ToInt32(Enum.Parse(typeof(EInvType), ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colSrcInvType"]).Value.ToString()));

            oResult = oInventoryBO.ReadQtyByCond(oInventory);

            if (oResult.IsSuccess)
            {
                return  ((CInventory)oResult.Data).Invt_QTY;
            }
            else
            {
                MessageBox.Show("Loading error...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return 0.00f;
        }

        private void LoadDataGridItem()
        {
            foreach (DataGridViewColumn oColumn in dgItemList.Columns)
            {
               
                if (oColumn.CellType == typeof(DataGridViewComboBoxCell))
                {
                    if (oColumn.Name == "colItem")
                    {
                        if (arrItemList.Count > 0)
                        {
                            ((DataGridViewComboBoxColumn)oColumn).DataSource = arrItemList;
                            ((DataGridViewComboBoxColumn)oColumn).DisplayMember = "Item_Code";
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
                    else if (oColumn.Name == "colSrcBranch" || oColumn.Name == "colDesBranch")
                    {
                        if (lBranchList.Count > 0)
                        {
                            ((DataGridViewComboBoxColumn)oColumn).DataSource = lBranchList;
                            ((DataGridViewComboBoxColumn)oColumn).DisplayMember = "CompBrn_Code";
                            ((DataGridViewComboBoxColumn)oColumn).ValueMember = "CompBrn_OId";
                        }
                    }
                    else if (oColumn.Name == "colSourceLoc")
                    {
                        foreach (CLocation obj in arrLocationList)
                        {
                            foreach (CCVB objCVB in oCVBList)
                            {
                                if (objCVB.Branch.Trim() == currentBranch.CompBrn_OId.Trim())
                                {
                                    if (obj.Loc_OID.Trim() == objCVB.Location.Trim())
                                    {
                                        ((DataGridViewComboBoxColumn)oColumn).Items.Add(obj);
                                        ((DataGridViewComboBoxColumn)oColumn).DisplayMember = "Loc_Code";
                                        ((DataGridViewComboBoxColumn)oColumn).ValueMember = "Loc_OID";

                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else if (oColumn.Name == "colDesLocation")
                    {
                        foreach (CLocation obj in arrLocationList)
                        {
                            foreach (CCVB objCVB in oCVBList)
                            {
                                if (objCVB.Branch.Trim() == currentBranch.CompBrn_OId.Trim())
                                {
                                    if (obj.Loc_OID.Trim() == objCVB.Location.Trim())
                                    {
                                        ((DataGridViewComboBoxColumn)oColumn).Items.Add(obj);
                                        ((DataGridViewComboBoxColumn)oColumn).DisplayMember = "Loc_Code";
                                        ((DataGridViewComboBoxColumn)oColumn).ValueMember = "Loc_OID";

                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else if (oColumn.Name == "colStatus")
                    {
                        ((DataGridViewComboBoxColumn)oColumn).Items.AddRange(Enum.GetNames(typeof(EMTStatus)));
                    }
                    else if (oColumn.Name == "colSrcInvType" || oColumn.Name == "colDesInvType")
                    {
                        ((DataGridViewComboBoxColumn)oColumn).Items.AddRange(Enum.GetNames(typeof(EInvType)));
                    }
                }
            }            
            SetDefaultValue();
        }
        private void SetDefaultValue()
        {
            for (int i = 0; i < dgItemList.Rows.Count; i++)
            {
                DataGridViewComboBoxCell cmbSrcBrn = ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colSrcBranch"]);

                foreach (object obj in cmbSrcBrn.Items)
                {
                    CCompanyBranch oCompanyBranch = (CCompanyBranch)obj;
                    if (oCompanyBranch.CompBrn_OId.Trim() == currentBranch.CompBrn_OId.Trim())
                    {
                        cmbSrcBrn.Value = oCompanyBranch.CompBrn_OId.Trim();
                        break;
                    }
                }

                DataGridViewComboBoxCell cmbSrcInvTyp = ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colSrcInvType"]);
                foreach (object obj in cmbSrcInvTyp.Items)
                {
                    cmbSrcInvTyp.Value = obj; 
                    break;
                }

                DataGridViewComboBoxCell cmbDesInvTyp = ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colDesInvType"]);
                foreach (object obj in cmbDesInvTyp.Items)
                {
                    cmbDesInvTyp.Value = obj;
                    break;
                }
            }
        }

        private void ClearFormData()
        {
            txtDeliverOrder.Text = "";
            dtpMTDate.Value = DateTime.Now.Date;

            dgItemList.Rows.Clear();
            FormControlMode(0);
            GetDeliverID();
        }

        private bool ValidateListItem(DataGridViewRow oRow)
        {
            StringBuilder oBuilder = new StringBuilder();
            oBuilder.Append("Please insert ");
            if (oRow.Cells["colItem"].Value == null)
            {
                oBuilder.Append("Item");
            }
            if (oRow.Cells["colIssueqty"].Value == null)
            {
                oBuilder.Append(", Qty ");
            }
            if (oRow.Cells["colSrcBranch"].Value == null)
            {
                oBuilder.Append(", Source Branch ");
            }
            if (oRow.Cells["colSourceLoc"].Value == null)
            {
                oBuilder.Append(", Source Location ");
            }
            if (oRow.Cells["colDesBranch"].Value == null)
            {
                oBuilder.Append(", Destination Branch ");
            }
            if (oRow.Cells["colDesLocation"].Value == null)
            {
                oBuilder.Append(", Destination Location ");
            }
            if (oBuilder.ToString() != "Please insert ")
            {
                MessageBox.Show(oBuilder.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }


        // Update inventory
        Dictionary<string, CMTDetails> oMTFinalQtyDic = new Dictionary<string, CMTDetails>();

        private CMTMaster GetToBSavedData()
        {
            oMTFinalQtyDic.Clear();

            CMTMaster oMTMaster = new CMTMaster();

            oMTMaster.MTMstr_OID = txtSelectedMTOID.Text.Trim();
            oMTMaster.MTMstr_DOrder = txtDeliverOrder.Text.Trim();
            oMTMaster.MTMstr_Branch = currentBranch.CompBrn_Code;
            oMTMaster.MTMstr_Date = dtpMTDate.Value.Date;

            oMTMaster.Creator = currentUser.User_OID;
            oMTMaster.CreationDate = DateTime.Now.Date;
            oMTMaster.UpdateBy = currentUser.User_OID;
            oMTMaster.UpdateDate = DateTime.Now.Date;
            oMTMaster.IsActive = "Y";
            oMTMaster.Remarks = "";

            for (int i = 0; i < dgItemList.Rows.Count - 1; i++)
            {
                if (ValidateListItem(dgItemList.Rows[i]))
                {
                    CMTDetails oMTDetails = new CMTDetails();

                    oMTDetails.MTDtls_Branch = currentBranch.CompBrn_Code;
                    oMTDetails.MTDtls_ItemOID = ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colItem"]).Value.ToString();
                    if (dgItemList.Rows[i].Cells["colIssueqty"].Value != null)
                        oMTDetails.MTDtls_IssQty = float.Parse(((DataGridViewTextBoxCell)dgItemList.Rows[i].Cells["colIssueqty"]).Value.ToString());
                    if (dgItemList.Rows[i].Cells["colIssueUOM"].Value != null)
                        oMTDetails.MTDtls_IssUOMOID = ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colIssueUOM"]).Value.ToString();

                    if (dgItemList.Rows[i].Cells["colSrcBranch"].Value != null)
                        oMTDetails.MTDtls_SBranOID = ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colSrcBranch"]).Value.ToString();

                    if (dgItemList.Rows[i].Cells["colSourceLoc"].Value != null)
                        oMTDetails.MTDtls_SrcLocOID = ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colSourceLoc"]).Value.ToString();

                    if (dgItemList.Rows[i].Cells["colSrcInvType"].Value != null)
                    {
                        oMTDetails.MTDtls_SrcInvTyp = Convert.ToInt32(Enum.Parse(typeof(EInvType), ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colSrcInvType"]).Value.ToString()));
                    }
                    if (dgItemList.Rows[i].Cells["colDesBranch"].Value != null)
                        oMTDetails.MTDtls_DBranOID = ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colDesBranch"]).Value.ToString();

                    if (dgItemList.Rows[i].Cells["colDesLocation"].Value != null)
                        oMTDetails.MTDtls_DestLocOID = ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colDesLocation"]).Value.ToString();
                    if (dgItemList.Rows[i].Cells["colDesInvType"].Value != null)
                        oMTDetails.MTDtls_DesInvtyp = Convert.ToInt32(Enum.Parse(typeof(EInvType), ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colDesInvType"]).Value.ToString()));
                    
                    oMTMaster.MTMstr_DetailsList.Add(oMTDetails);

                    //update inmv
                    if (IsUpdateMode)
                    {
                        CMTDetails oInvMTDetails = new CMTDetails();

                        oInvMTDetails.MTDtls_ItemOID = oMTDetails.MTDtls_ItemOID;
                        oInvMTDetails.MTDtls_Branch = oMTDetails.MTDtls_Branch;
                        oInvMTDetails.MTDtls_SBranOID = oMTDetails.MTDtls_SBranOID;
                        oInvMTDetails.MTDtls_SrcLocOID = oMTDetails.MTDtls_SrcLocOID;
                        oInvMTDetails.MTDtls_SrcInvTyp = oMTDetails.MTDtls_SrcInvTyp;

                        oInvMTDetails.MTDtls_DBranOID = oMTDetails.MTDtls_DBranOID;
                        oInvMTDetails.MTDtls_DestLocOID = oMTDetails.MTDtls_DestLocOID;
                        oInvMTDetails.MTDtls_DesInvtyp = oMTDetails.MTDtls_DesInvtyp;

                        if (dgItemList.Rows[i].Cells["colFinalQty"].Value != null)
                        {
                            oInvMTDetails.MTDtls_IssQty = float.Parse(((DataGridViewTextBoxCell)dgItemList.Rows[i].Cells["colFinalQty"]).Value.ToString());
                        }
                        else
                        {
                            oInvMTDetails.MTDtls_IssQty = 0.00f;
                        }
                        oMTFinalQtyDic.Add(oInvMTDetails.MTDtls_ItemOID, oInvMTDetails);
                    }
                }
                else
                {
                    return null;
                }
            }

            //for update inv
            foreach (string obj in oMTExistingQtyDic.Keys)
            {
                if (!oMTFinalQtyDic.ContainsKey(obj))
                {
                    CMTDetails oInvMTDetails = new CMTDetails();

                    oInvMTDetails.MTDtls_ItemOID = oMTExistingQtyDic[obj].MTDtls_ItemOID;
                    oInvMTDetails.MTDtls_Branch = oMTExistingQtyDic[obj].MTDtls_Branch;
                    oInvMTDetails.MTDtls_SBranOID = oMTExistingQtyDic[obj].MTDtls_SBranOID;
                    oInvMTDetails.MTDtls_SrcLocOID = oMTExistingQtyDic[obj].MTDtls_SrcLocOID;
                    oInvMTDetails.MTDtls_SrcInvTyp = oMTExistingQtyDic[obj].MTDtls_SrcInvTyp;

                    oInvMTDetails.MTDtls_DBranOID = oMTExistingQtyDic[obj].MTDtls_DBranOID;
                    oInvMTDetails.MTDtls_DestLocOID = oMTExistingQtyDic[obj].MTDtls_DestLocOID;
                    oInvMTDetails.MTDtls_DesInvtyp = oMTExistingQtyDic[obj].MTDtls_DesInvtyp;

                    oInvMTDetails.MTDtls_IssQty = oMTExistingQtyDic[obj].MTDtls_IssQty * -1;

                    oMTFinalQtyDic.Add(obj, oInvMTDetails);
                }
            }
            return oMTMaster;
        }

        private bool ValidationData()
        {
            if (dgItemList.Rows.Count <= 1)
            {
                MessageBox.Show("No details Item to save. ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        Dictionary<string, CMTDetails> oMTExistingQtyDic = new Dictionary<string, CMTDetails>();
        private void FillForm(CMTMaster oMTMaster)
        {
            oMTExistingQtyDic.Clear();

            txtSelectedMTOID.Text = oMTMaster.MTMstr_OID.Trim();
            txtDeliverOrder.Text = oMTMaster.MTMstr_DOrder;
            dtpMTDate.Value = oMTMaster.MTMstr_Date;

            dgItemList.Rows.Clear();

            foreach (CMTDetails oMTDetails in oMTMaster.MTMstr_DetailsList)
            {
                dgItemList.Rows.Add();
                DataGridViewRow odgRow = dgItemList.Rows[dgItemList.Rows.Count - 2];

                odgRow.Cells["colItem"].Value = oMTDetails.MTDtls_ItemOID.Trim();
                odgRow.Cells["colIssueqty"].Value = oMTDetails.MTDtls_IssQty.ToString("F2");
                odgRow.Cells["colIssueUOM"].Value = oMTDetails.MTDtls_IssUOMOID.Trim();
                odgRow.Cells["colSrcBranch"].Value = oMTDetails.MTDtls_SBranOID.Trim();
                odgRow.Cells["colSourceLoc"].Value = oMTDetails.MTDtls_SrcLocOID.Trim();
                odgRow.Cells["colSrcInvType"].Value = Enum.GetName(typeof(EInvType), oMTDetails.MTDtls_SrcInvTyp);
                odgRow.Cells["colDesBranch"].Value = oMTDetails.MTDtls_DBranOID.Trim();
                odgRow.Cells["colDesLocation"].Value = oMTDetails.MTDtls_DestLocOID.Trim();
                odgRow.Cells["colDesInvType"].Value = Enum.GetName(typeof(EInvType), oMTDetails.MTDtls_DesInvtyp);

                if (IsUpdateMode)
                {
                    oMTExistingQtyDic.Add(oMTDetails.MTDtls_ItemOID.Trim(), oMTDetails);
                }
            }
        }


        private bool ValidatateMTList()
        {
            for (int i = 1; i < dgItemList.Rows.Count-1 ; i++)
            {
                if (((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colItem"]).Value != null)
                {
                    if (((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colItem"]).Value.ToString() == ((DataGridViewComboBoxCell)dgItemList.Rows[i - 1].Cells["colItem"]).Value.ToString()
                        && ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colSrcBranch"]).Value.ToString() == ((DataGridViewComboBoxCell)dgItemList.Rows[i - 1].Cells["colSrcBranch"]).Value.ToString()
                        && ((DataGridViewComboBoxCell)dgItemList.Rows[i].Cells["colSourceLoc"]).Value.ToString() == ((DataGridViewComboBoxCell)dgItemList.Rows[i - 1].Cells["colSourceLoc"]).Value.ToString()
                        )
                    {
                        return false;
                    }
                }
            }
            return true;
        }



        #endregion

        #region "Events"

        private void frmMaterialTransfer_Load(object sender, EventArgs e)
        {
            FormControlMode(0);
            GetDeliverID();
            LoadComapanyBranch();
            LoadItemData();
            LoadUOMData();
            LoadLocationData();
            LoadRelationData();
            LoadDataGridItem();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgItemList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 )
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
                // Validation End

                if (dgItemList.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn == dgItemList.Rows[e.RowIndex].Cells["colItem"].OwningColumn)
                {
                    if (ValidatateMTList())
                    {
                        foreach (CItem oItem in arrItemList)
                        {
                            if (string.Equals(oItem.Item_OID.Trim(), dgItemList.Rows[e.RowIndex].Cells["colItem"].Value.ToString().Trim()))
                            {
                                dgItemList.Rows[e.RowIndex].Cells["colItemName"].Value = oItem.Item_ItemName;
                                dgItemList.Rows[e.RowIndex].Cells["colIssueUOM"].Value = oItem.Item_UOMID;
                                break;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Duplicat Entry is not allowed. ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.dgItemList.Rows.Remove(dgItemList.Rows[e.RowIndex]);
                    }
                }
                if (dgItemList.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn == dgItemList.Rows[e.RowIndex].Cells["colSourceLoc"].OwningColumn)
                {
                    if (!ValidatateMTList())
                    {
                        MessageBox.Show("Duplicat Entry is not allowed. ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.dgItemList.Rows.Remove(dgItemList.Rows[e.RowIndex]);
                    }
                }
                if (dgItemList.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn == dgItemList.Rows[e.RowIndex].Cells["colSrcBranch"].OwningColumn)
                {
                    if (!ValidatateMTList())
                    {
                        MessageBox.Show("Duplicat Entry is not allowed. ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.dgItemList.Rows.Remove(dgItemList.Rows[e.RowIndex]);
                    }
                    else
                    {
                        DataGridViewComboBoxCell cmbSrcLoc = (DataGridViewComboBoxCell)dgItemList.Rows[e.RowIndex].Cells["colSourceLoc"];
                        cmbSrcLoc.Items.Clear();


                        foreach (CLocation obj in arrLocationList)
                        {
                            foreach (CCVB objCVB in oCVBList)
                            {
                                if (objCVB.Branch.Trim() == dgItemList.Rows[e.RowIndex].Cells["colSrcBranch"].Value.ToString())
                                {
                                    if (obj.Loc_OID.Trim() == objCVB.Location.Trim())
                                    {
                                        cmbSrcLoc.Items.Add(obj);
                                        cmbSrcLoc.DisplayMember = "Loc_Code";
                                        cmbSrcLoc.ValueMember = "Loc_OID";

                                        break;
                                    }
                                }
                            }
                        }
                        if (cmbSrcLoc.Items.Count > 0)
                        {
                            foreach (object obj in cmbSrcLoc.Items)
                            {
                                CLocation objLoc = (CLocation)obj;
                                cmbSrcLoc.Value = objLoc.Loc_OID.ToString();
                                break;
                            }
                        }
                    }
                }

                if (dgItemList.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn == dgItemList.Rows[e.RowIndex].Cells["colDesBranch"].OwningColumn)
                {
                    DataGridViewComboBoxCell cmbDesLoc = (DataGridViewComboBoxCell)dgItemList.Rows[e.RowIndex].Cells["colDesLocation"];
                    cmbDesLoc.Items.Clear();

                    foreach (CLocation obj in arrLocationList)
                    {
                        foreach (CCVB objCVB in oCVBList)
                        {
                            if (objCVB.Branch.Trim() == dgItemList.Rows[e.RowIndex].Cells["colDesBranch"].Value.ToString())
                            {
                                if (obj.Loc_OID.Trim() == objCVB.Location.Trim())
                                {
                                    cmbDesLoc.Items.Add(obj);
                                    cmbDesLoc.DisplayMember = "Loc_Code";
                                    cmbDesLoc.ValueMember = "Loc_OID";

                                    break;
                                }
                            }
                        }
                    }
                    foreach (object obj in cmbDesLoc.Items)
                    {
                        CLocation objLoc = (CLocation)obj;
                        cmbDesLoc.Value = objLoc.Loc_OID.ToString();
                        break;
                    }
                }

                if (dgItemList.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn == dgItemList.Rows[e.RowIndex].Cells["colItem"].OwningColumn || dgItemList.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn == dgItemList.Rows[e.RowIndex].Cells["colSrcBranch"].OwningColumn || dgItemList.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn == dgItemList.Rows[e.RowIndex].Cells["colSourceLoc"].OwningColumn)
                {
                    if(dgItemList.Rows[e.RowIndex].Cells["colItem"].Value!=null)
                    ((DataGridViewTextBoxCell)dgItemList.Rows[e.RowIndex].Cells["colInvQty"]).Value = InventoryItemData(e.RowIndex).ToString();
                }

                if (dgItemList.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn == dgItemList.Rows[e.RowIndex].Cells["colIssueqty"].OwningColumn)
                {
                    if (float.Parse(((DataGridViewTextBoxCell)dgItemList.Rows[e.RowIndex].Cells["colInvQty"]).Value.ToString()) < float.Parse(((DataGridViewTextBoxCell)dgItemList.Rows[e.RowIndex].Cells["colIssueqty"]).Value.ToString()))
                    {
                        ((DataGridViewTextBoxCell)dgItemList.Rows[e.RowIndex].Cells["colIssueqty"]).Value = ((DataGridViewTextBoxCell)dgItemList.Rows[e.RowIndex].Cells["colInvQty"]).Value.ToString();
                    }
                }

                //for update inventory
                if (oMTExistingQtyDic.Count > 0 && IsUpdateMode == true && dgItemList.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn == dgItemList.Rows[e.RowIndex].Cells["colIssueqty"].OwningColumn)
                {
                    float fVAL = float.Parse(dgItemList.Rows[e.RowIndex].Cells["colIssueqty"].Value.ToString());

                    if (oMTExistingQtyDic.ContainsKey(dgItemList.Rows[e.RowIndex].Cells["colItem"].Value.ToString().Trim()))
                    {
                        fVAL = fVAL - oMTExistingQtyDic[dgItemList.Rows[e.RowIndex].Cells["colItem"].Value.ToString().Trim()].MTDtls_IssQty;
                    }

                    dgItemList.Rows[e.RowIndex].Cells["colFinalQty"].Value = fVAL.ToString("F2");
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidationData())
            {
                CResult oResult = new CResult();
                CMaterialTransferBO oMaterialTransferBO = new CMaterialTransferBO();
                CMTMaster oMaster = GetToBSavedData();

                if (oMaster != null)
                {

                    if (!IsUpdateMode)
                    {
                        oResult = oMaterialTransferBO.Create(oMaster);
                    }
                    else
                    {
                        oResult = oMaterialTransferBO.Update(oMaster,oMTFinalQtyDic);
                    }

                    if (oResult.IsSuccess)
                    {
                        if (currentBranch.CompBrn_IsHeadoffice=="Y")
                        {
                            if (MessageBox.Show("Successfully Done. Do u want to Export these data? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                frmMTExpItems objMTExpItems = new frmMTExpItems(txtDeliverOrder.Text.Trim());
                                objMTExpItems.Show();
                            }
                        }
                        ClearFormData();
                        GetDeliverID();
                    }
                    else
                    {
                        MessageBox.Show(oResult.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDeliverOrder_Click(object sender, EventArgs e)
        {
            frmSearchGeneric<CMTMaster> oSearch = new frmSearchGeneric<CMTMaster>();
            oSearch.SelectedEvent += new frmSearchGeneric<CMTMaster>.EventHandler(oSearch_SelectedEvent);
            oSearch.ShowDialog();
        }

        void oSearch_SelectedEvent(object sender, SearchEventArgs<CMTMaster> e)
        {
            FormControlMode(1);
            CMTMaster oMTMaster = e.t;
            FillForm(oMTMaster);
        }

        private void dgItemList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (dgItemList.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn == dgItemList.Rows[e.RowIndex].Cells["colCopy"].OwningColumn)
                {
                    if (dgItemList.Rows.Count - 1 > 0)
                    {
                        if (dgItemList.Rows[dgItemList.Rows.Count - 1].Cells["colItem"].Value == null)
                        {
                            int nTop2Index = dgItemList.Rows.Count - 2;
                            int nTop1Index = dgItemList.Rows.Count - 1;

                            dgItemList.Rows[nTop1Index].Cells["colItem"].Value = dgItemList.Rows[nTop2Index].Cells["colItem"].Value;
                            dgItemList.Rows[nTop1Index].Cells["colIssueqty"].Value = dgItemList.Rows[nTop2Index].Cells["colIssueqty"].Value;
                            dgItemList.Rows[nTop1Index].Cells["colIssueUOM"].Value = dgItemList.Rows[nTop2Index].Cells["colIssueUOM"].Value;
                            dgItemList.Rows[nTop1Index].Cells["colSourceLoc"].Value = dgItemList.Rows[nTop2Index].Cells["colSourceLoc"].Value;
                            dgItemList.Rows[nTop1Index].Cells["colSrcInvType"].Value = dgItemList.Rows[nTop2Index].Cells["colSrcInvType"].Value;
                            dgItemList.Rows[nTop1Index].Cells["colDesLocation"].Value = dgItemList.Rows[nTop2Index].Cells["colDesLocation"].Value;
                            dgItemList.Rows[nTop1Index].Cells["colDesInvType"].Value = dgItemList.Rows[nTop2Index].Cells["colDesInvType"].Value;
                        }
                    }
                }
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
                CMaterialTransferBO oMaterialTransferBO = new CMaterialTransferBO();

                if (IsUpdateMode)
                {
                    oResult = oMaterialTransferBO.Delete(txtSelectedMTOID.Text.Trim());
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

        private void dgItemList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
            SetDefaultValue();

        }
        #endregion
    }
}

