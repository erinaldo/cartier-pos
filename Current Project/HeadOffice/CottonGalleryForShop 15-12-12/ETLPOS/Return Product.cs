using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ETL.Common;
using ETL.BLL;
using ETL.Model;

namespace ETLPOS
{
    public partial class Return_Product : BaseForm
    {
        public Return_Product()
        {
            InitializeComponent();
            this.LoadItemList();
        }
        private Dictionary<string, CItemSales> oItemTemp;
        private void txtbarcode_TextChanged(object sender, EventArgs e)
        {
            if (txtbarcode.Text.Trim() != "")
            {
                if (txtItemName.Text.Trim() != "")
                {
                    txtItemName.Text = "";
                }
                LoadBarCodeItem();
            }
        }

        private void LoadBarCodeItem()
        {
            CResult oResult = new CResult();
            CItemBO oItemBO = new CItemBO();
            List<CItemSales> oSalesList = new List<CItemSales>();
            if (txtbarcode.Text.Trim() != "")
            {
                oResult = oItemBO.ReadAllFGForSalesByBranchAndItem(currentBranch.CompBrn_OId, txtbarcode.Text.Trim());
            }
            else if (txtItemName.Text.Trim() != "")
            {
                oResult = oItemBO.ReadAllFGForSalesByBranchAndName(currentBranch.CompBrn_OId, txtItemName.Text.Trim());
            }

            if (oResult.IsSuccess)
            {
                oSalesList = (List<CItemSales>)oResult.Data;
                if (oSalesList.Count > 0)
                {
                    CItemSales oItem = (CItemSales)oSalesList[0];
                    if (oItem != null)
                    {
                        if (oItem.Item_Price == 0)
                        {
                            MessageBox.Show("Please set the item Seles Price!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //this.Close();
                            return;
                        }
                        //if (oItem.Item_ExistQTY == 0)
                        //{
                        //    MessageBox.Show("Sales Item Quantity is Empty!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    return;
                        //}
                        foreach (DataGridViewRow dgvr2 in this.dgvSaleItemList.Rows)
                        {
                            if (dgvr2.Index != this.dgvSaleItemList.Rows.Count - 1)
                            {
                                if (dgvr2.Cells["chItemOId"].Value.ToString() == oItem.Item_OID)
                                {
                                    dgvr2.Cells["chQty"].Value = Convert.ToString(Convert.ToInt32(dgvr2.Cells["chQty"].Value) + 1);
                                    this.CalculateTotal();
                                    txtbarcode.Text = "";
                                    return;
                                }
                            }
                        }
                        this.dgvSaleItemList.Rows.Add();
                        DataGridViewRow dgvr = this.dgvSaleItemList.Rows[this.dgvSaleItemList.Rows.Count - 2];

                        dgvr.Cells["chSLNum"].Value = (this.dgvSaleItemList.Rows.Count - 1).ToString();
                        dgvr.Cells["chItemOId"].Value = oItem.Item_OID;
                        dgvr.Cells["chItemName"].Value = oItem.Item_ItemName;
                        dgvr.Cells["chRate"].Value = oItem.Item_Price;
                        dgvr.Cells["chVatPercent"].Value = oItem.Item_VatPercent;

                        dgvr.Cells["chUOMOID"].Value = oItem.Item_UOMOID;
                        dgvr.Cells["chValue"].Value = "0";
                        dgvr.Cells["chCurrencyOID"].Value = oItem.Item_CurrencyOID;
                        dgvr.Cells["chVatValue"].Value = "0";
                        dgvr.Cells["chQty"].Value = "1";
                        dgvr.Cells["cPPrice"].Value = oItem.Item_PPrice;
                        dgvr.Tag = oItem;

                        this.CalculateTotal();

                        //this.lastSelection = LastSelected.ItemList;
                        dgvr.Selected = true;
                        //this.txtDiscountperc.BackColor = Color.White;
                        //this.txtCustomerPaid.BackColor = Color.White;

                        //IsAddedMode = false;


                    }
                    txtbarcode.Text = "";
                }

            }
        }

        private void CalculateTotal()
        {
            //this.LoadItemList();
            float fTotalAmount = 0;
            float fTotalDiscountAmount = 0;
            float fTotalVatAmount = 0;
            if (this.dgvSaleItemList.Rows.Count > 0)
            {
                for (int i = 0; i < this.dgvSaleItemList.Rows.Count - 1; i++)
                {
                    DataGridViewRow dgvr = this.dgvSaleItemList.Rows[i];

                    CItemSales oItem = this.oItemTemp[dgvr.Cells["chItemOId"].Value.ToString()];
                    if (oItem != null)
                    {
                        if (int.Parse(dgvr.Cells["chQty"].Value.ToString()) > oItem.Item_ExistQTY)
                        {
                            dgvr.Cells["chQty"].Value = oItem.Item_ExistQTY.ToString();
                        }
                    }
                    dgvr.Cells["chValue"].Value = (float.Parse(dgvr.Cells["chRate"].Value.ToString()) * int.Parse(dgvr.Cells["chQty"].Value.ToString())).ToString();
                    //if (txtDiscountAmount.Text.Trim() != "" && Convert.ToInt32(txtDiscountAmount.Text.Trim()) != 0)
                    //{
                    //    //dgvr.Cells["chDiscountAmount"].Value = (float.Parse(dgvr.Cells["chValue"].Value.ToString()) * float.Parse(txtDiscountperc.Text.Trim())) / 100;
                    //    dgvr.Cells["chDiscountAmount"].Value = float.Parse(txtDiscountAmount.Text.Trim());
                    //}
                    //else
                    //{
                    dgvr.Cells["chDiscountAmount"].Value = 0;
                    //}
                    dgvr.Cells["chVatValue"].Value = (((float.Parse(dgvr.Cells["chValue"].Value.ToString()) - float.Parse(dgvr.Cells["chDiscountAmount"].Value.ToString())) * float.Parse(dgvr.Cells["chVatPercent"].Value.ToString())) / 100).ToString();
                    dgvr.Cells["chTotalValue"].Value = float.Parse(dgvr.Cells["chValue"].Value.ToString()) - float.Parse(dgvr.Cells["chDiscountAmount"].Value.ToString()) + float.Parse(dgvr.Cells["chVatValue"].Value.ToString());

                    fTotalAmount += float.Parse(dgvr.Cells["chValue"].Value.ToString());
                    //fTotalDiscountAmount += float.Parse(dgvr.Cells["chDiscountAmount"].Value.ToString());
                    fTotalVatAmount += float.Parse(dgvr.Cells["chVatValue"].Value.ToString());
                }
            }
            //txtTotalAmount.Text = fTotalAmount.ToString();
            //txtVat.Text = fTotalVatAmount.ToString();
            //if (txtDiscountAmount.Text.Trim() == "")
            //{
            //    txtNetPay.Text = (Math.Ceiling(float.Parse(txtTotalAmount.Text.Trim())).ToString()) + float.Parse(txtVat.Text.Trim()).ToString();
            //    txtDiscountAmount.Text = "0";
            //}
            //else
            //{
            //    txtNetPay.Text = (Math.Ceiling(float.Parse(txtTotalAmount.Text.Trim()) - float.Parse(txtDiscountAmount.Text.Trim()))).ToString() + float.Parse(txtVat.Text.Trim()).ToString();
            //}
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            if (txtItemName.Text.Trim() != "")
            {
                if (txtbarcode.Text.Trim() != "")
                {
                    txtbarcode.Text = "";
                }
                LoadBarCodeItem();
            }
        }

        private void LoadItemList()
        {

            CResult oResult = new CResult();
            this.oItemTemp = new Dictionary<string, CItemSales>();

            CItemBO oItemBO = new CItemBO();
            List<CItemSales> oItemList = new List<CItemSales>();

            oResult = oItemBO.ReadAllFGForSalesByBranch(currentBranch.CompBrn_OId);

            if (oResult.IsSuccess)
            {
                oItemList = (List<CItemSales>)oResult.Data;
                foreach (CItemSales objItem in oItemList)
                {
                    this.oItemTemp.Add(objItem.Item_OID, objItem);
                }
            }
            else
            {
                MessageBox.Show(oResult.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private CSOMaster GetToSOFormData()
        {
            CSOMaster oSOMaster = new CSOMaster();

            oSOMaster.SOMstr_OID = string.Empty;
            oSOMaster.SOMstr_Branch = currentBranch.CompBrn_Code;
            oSOMaster.SOMstr_Code = string.Empty;
            oSOMaster.SOMstr_Date = DateTime.Now.Date;
            oSOMaster.SOMstr_By = string.Empty;
            oSOMaster.SOMstr_CustomerID = string.Empty;            
            oSOMaster.SOMstr_FinalDest = string.Empty;
            oSOMaster.SOMstr_TransportType = string.Empty;
            oSOMaster.SOMstr_TransportNo = string.Empty;
            oSOMaster.SOMstr_VatClnNo = string.Empty;
            oSOMaster.SOMstr_VatDate = DateTime.Now.Date;
            oSOMaster.SOMstr_PricingDate = DateTime.Now.Date;
            oSOMaster.Creator = currentUser.User_OID;
            oSOMaster.CreationDate = DateTime.Now.Date;
            oSOMaster.UpdateBy = currentUser.User_OID;
            oSOMaster.UpdateDate = DateTime.Now.Date;
            oSOMaster.IsActive = "Y";
            oSOMaster.Remarks = string.Empty;

            for (int i = 0; i < this.dgvSaleItemList.Rows.Count - 1; i++)
            {
                DataGridViewRow dgvr = this.dgvSaleItemList.Rows[i];

                //if (float.Parse(dgvr.Cells["chQty"].Value.ToString()) > 0)
                //{
                    CSODetails oSODetails = new CSODetails();

                    oSODetails.SODet_OID = string.Empty;
                    oSODetails.SODet_Branch = currentBranch.CompBrn_Code;
                    oSODetails.SODet_MStrOID = string.Empty;
                    oSODetails.SODet_ItemSLNum = dgvr.Cells["chSLNum"].Value.ToString();
                    oSODetails.SODet_ItemOID = dgvr.Cells["chItemOId"].Value.ToString();
                    oSODetails.SODet_ItemName = dgvr.Cells["chItemName"].Value.ToString();
                    oSODetails.SODet_QTY = float.Parse(dgvr.Cells["chQty"].Value.ToString());
                    oSODetails.SODet_UOM = dgvr.Cells["chUOMOID"].Value.ToString();
                    oSODetails.SODet_Price = float.Parse(dgvr.Cells["chRate"].Value.ToString());
                    oSODetails.SODet_PPrice = float.Parse(dgvr.Cells["cPPrice"].Value.ToString());
                    oSODetails.SODet_Currency = dgvr.Cells["chCurrencyOID"].Value.ToString();
                    oSODetails.SODet_Amount = float.Parse(dgvr.Cells["chValue"].Value.ToString());
                    oSODetails.SODet_Discount = float.Parse(dgvr.Cells["chDiscountAmount"].Value.ToString());
                    oSODetails.SODet_VATValue = float.Parse(dgvr.Cells["chVatValue"].Value.ToString());

                    oSODetails.SODet_SDValue = 0.00f;
                    oSODetails.SODet_SDAmount = 0.00f;
                    oSODetails.SODet_VATAmount = 0.00f;
                    oSODetails.SODet_NetAmount = 0.00f;

                    oSODetails.SODet_BranchOID = currentBranch.CompBrn_OId;
                    // Advance Start
                    if (!defaultUserMode)
                    {
                        oSODetails.SODet_MStrOID = "SOMstrXX" + currentBranch.CompBrn_Code.Trim() + (("XXXXXX").Substring(0, 6 - currentBranch.CompBrn_Code.Trim().Length)) + "00" + VatClnNo;
                    }
                    // Advance End
                    //ReturnProduct oReturnProduct = new ReturnProduct();
                    //oReturnProduct.Ret_DiscountAmount = float.Parse(txtDiscountAmount.Text.Trim());
                    //oSOMaster.oReturnItemsList.Add(oReturnProduct);
                    oSOMaster.SOMstr_DetailsList.Add(oSODetails);
                    
               // }
            }

            // Advance Start
            if (!defaultUserMode)
            {
                oSOMaster.SOMstr_OID = "SOMstrXX" + currentBranch.CompBrn_Code.Trim() + (("XXXXXX").Substring(0, 6 - currentBranch.CompBrn_Code.Trim().Length)) + "00" + VatClnNo;

                string sTemp = currentBranch.CompBrn_Code.Trim() + (("XXXXXX").Substring(0, 6 - currentBranch.CompBrn_Code.Trim().Length));
                sTemp += DateTime.Now.ToString("yyddMM");
                sTemp += VatClnNo.Substring(4, 4);
                oSOMaster.SOMstr_Code = sTemp;

                oSOMaster.SOMstr_VatClnNo = VatClnNo;

                VatClnNo = ("00000001").Substring(0, 8 - (long.Parse(VatClnNo) + 1).ToString().Length) + (long.Parse(VatClnNo) + 1).ToString();
            }
            // Advance End

            return oSOMaster;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            CResult oResult = new CResult();
            CSOBO oSOBO = new CSOBO();
            CSOMaster oSOMaster = GetToSOFormData();
            float DisAmt = float.Parse(txtDiscountAmount.Text.Trim());
            if (oSOMaster.SOMstr_DetailsList.Count > 0)
            {
                oResult = oSOBO.Return(oSOMaster, DisAmt);

                if (oResult.IsSuccess)
                {
                    //MessageBox.Show("Successfully Done. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string SOMstID = (string)oResult.Data;
                    txtbarcode.Select();
                    this.LoadItemList();
                    MessageBox.Show("save success");
                    this.dgvSaleItemList.Rows.Clear();
                    this.txtItemName.Clear();
                }
                else
                {
                    MessageBox.Show(oResult.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void txtDiscountAmount_TextChanged(object sender, EventArgs e)
        {
            if (this.dgvSaleItemList.Rows.Count > 0)
            {
                for (int i = 0; i < this.dgvSaleItemList.Rows.Count - 1; i++)
                {
                    DataGridViewRow dgvr = this.dgvSaleItemList.Rows[i];
                    int DiscountAmount = Convert.ToInt32(txtDiscountAmount.Text.ToString());
                    dgvr.Cells["chDiscountAmount"].Value = DiscountAmount.ToString();
                    //dgvr.Cells["chValue"].Value = (float.Parse(dgvr.Cells["chRate"].Value.ToString()) * int.Parse(dgvr.Cells["chQty"].Value.ToString())).ToString();
                    //dgvr.Cells["chDiscountAmount"].Value = 0;
                    //dgvr.Cells["chVatValue"].Value = (((float.Parse(dgvr.Cells["chValue"].Value.ToString()) - float.Parse(dgvr.Cells["chDiscountAmount"].Value.ToString())) * float.Parse(dgvr.Cells["chVatPercent"].Value.ToString())) / 100).ToString();
                    dgvr.Cells["chTotalValue"].Value = float.Parse(dgvr.Cells["chValue"].Value.ToString()) - float.Parse(dgvr.Cells["chDiscountAmount"].Value.ToString());

                    //fTotalAmount += float.Parse(dgvr.Cells["chValue"].Value.ToString());
                    //fTotalVatAmount += float.Parse(dgvr.Cells["chVatValue"].Value.ToString());

                    //fTotalVatAmount += float.Parse(dgvr.Cells["chVatValue"].Value.ToString());
                }
            }
        }

    }
}
