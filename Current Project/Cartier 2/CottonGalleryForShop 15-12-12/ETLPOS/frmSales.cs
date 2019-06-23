using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ETL.Model;
using ETL.BLL;
using System.Data.SqlClient;
using ETL.Common;
using System.Collections;
using ETLPOS.Reports;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.CrystalReports;
using System.Drawing.Printing;
using CrystalDecisions.CrystalReports.Engine;

using System.IO;
using System.Security.Cryptography;
using Model;
using BLL;

namespace ETLPOS
{
    public partial class frmSales : BaseForm
    {
        private Dictionary <string, CItemSales> oItemTemp;
        private LastSelected lastSelection = LastSelected.ItemList;


        #region "Declarations"

        private bool IsAddedMode = false;
       

        #endregion


        public frmSales()
        {
            InitializeComponent();
            this.LoadItemList();
            LoadEmployeeData();
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
                        if (oItem.Item_ExistQTY== 0)
                        {
                            MessageBox.Show("Sales Item Quantity is Empty!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
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

                        this.lastSelection = LastSelected.ItemList;
                        dgvr.Selected = true;
                        this.txtDiscountperc.BackColor = Color.White;
                        this.txtCustomerPaid.BackColor = Color.White;

                        IsAddedMode = false;

                        
                    }
                    txtbarcode.Text = "";
                }

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

        

        void btnItem_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            CItemSales oItem = this.oItemTemp[btn.Name];
            if (oItem != null)
            {
                foreach (DataGridViewRow dgvr2 in this.dgvSaleItemList.Rows)
                {
                    if (dgvr2.Index != this.dgvSaleItemList.Rows.Count - 1)
                    {
                        if (dgvr2.Cells["chItemOId"].Value.ToString() == oItem.Item_OID)
                        {
                            return;
                        }
                    }
                }
                this.dgvSaleItemList.Rows.Add();
                DataGridViewRow dgvr = this.dgvSaleItemList.Rows[this.dgvSaleItemList.Rows.Count - 2];

                dgvr.Cells["chSLNum"].Value = (this.dgvSaleItemList.Rows.Count-1).ToString();
                dgvr.Cells["chItemOId"].Value = oItem.Item_OID;
                dgvr.Cells["chItemName"].Value = oItem.Item_ItemName;
                dgvr.Cells["chRate"].Value = oItem.Item_Price;
                dgvr.Cells["chVatPercent"].Value = oItem.Item_VatPercent;                
                dgvr.Cells["chQty"].Value = "1";
                dgvr.Cells["chUOMOID"].Value = oItem.Item_UOMOID;
                dgvr.Cells["chValue"].Value = "0";
                dgvr.Cells["chCurrencyOID"].Value = oItem.Item_CurrencyOID;
                dgvr.Cells["chVatValue"].Value = "0";
                this.CalculateTotal();

                this.lastSelection = LastSelected.ItemList;
                //dgvr.Selected = true;
                this.txtDiscountperc.BackColor = Color.White;
                this.txtCustomerPaid.BackColor = Color.White;

                IsAddedMode = false;


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
            txtTotalAmount.Text = fTotalAmount.ToString();
            txtVat.Text = fTotalVatAmount.ToString();
            if (txtDiscountAmount.Text.Trim() == "")
            {
                txtNetPay.Text = (Math.Ceiling(float.Parse(txtTotalAmount.Text.Trim()) + float.Parse(txtVat.Text.Trim()))).ToString();
                txtDiscountAmount.Text = "0";
            }
            else
            {
                txtNetPay.Text = (Math.Ceiling(float.Parse(txtTotalAmount.Text.Trim()) - float.Parse(txtDiscountAmount.Text.Trim()) + float.Parse(txtVat.Text.Trim()))).ToString();
            }
        }

        private void dgvSaleItemList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int i = 0; i < this.dgvSaleItemList.Rows.Count - 1; i++ )
            {
                DataGridViewRow dgvr = this.dgvSaleItemList.Rows[i];
                dgvr.Cells["chSLNum"].Value = (i+1).ToString();
            }
        }
        
        private void btnGoMainPage_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn0To9_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
                        
            switch (this.lastSelection)
            {
                case LastSelected.ItemList:

                    if (this.dgvSaleItemList.SelectedRows.Count > 0)
                    {
                        if (dgvSaleItemList.SelectedRows[0].Index != (dgvSaleItemList.Rows.Count - 1))
                        {
                            DataGridViewRow dgvr = dgvSaleItemList.SelectedRows[0];

                            if (!IsAddedMode)
                            {
                                dgvr.Cells["chQty"].Value= "0";
                            }
                            IsAddedMode = true;



                            if (dgvr.Cells["chQty"].Value.ToString() == "0")
                            {
                                dgvr.Cells["chQty"].Value = btn.Text;
                            }
                            else
                            {
                                dgvr.Cells["chQty"].Value = dgvr.Cells["chQty"].Value + btn.Text;
                            }
                            this.CalculateTotal();
                        }
                    }

                    break;
                
                case LastSelected.DiscountPercent:

                    if (this.txtDiscountperc.Text == "0")
                    {
                        this.txtDiscountperc.Text = btn.Text;
                    }
                    else
                    {
                        this.txtDiscountperc.Text = this.txtDiscountperc.Text + btn.Text;
                    }
                    if (float.Parse(this.txtDiscountperc.Text) > 10)
                    {
                        this.txtDiscountperc.Text = "10";
                    }

                    break;
                case LastSelected.CustomerPaid:

                    if (this.txtCustomerPaid.Text == "0")
                    {
                        this.txtCustomerPaid.Text = btn.Text;
                    }
                    else
                    {
                        this.txtCustomerPaid.Text = this.txtCustomerPaid.Text + btn.Text;
                    }

                    break;

                default:
                    break;
            }
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            switch (this.lastSelection)
            {
                case LastSelected.ItemList:
                    
                    if (this.dgvSaleItemList.SelectedRows.Count > 0)
                    {
                        if (dgvSaleItemList.SelectedRows[0].Index != (dgvSaleItemList.Rows.Count - 1))
                        {
                            DataGridViewRow dgvr = this.dgvSaleItemList.SelectedRows[0];

                            dgvr.Cells["chQty"].Value = dgvr.Cells["chQty"].Value.ToString().Substring(0, dgvr.Cells["chQty"].Value.ToString().Length - 1);

                            if (dgvr.Cells["chQty"].Value.ToString().Length == 0)
                            {
                                dgvr.Cells["chQty"].Value = "0";
                            }
                            this.CalculateTotal();
                        }
                    }

                    break;
               
                case LastSelected.DiscountPercent:

                    this.txtDiscountperc.Text = this.txtDiscountperc.Text.Substring(0, this.txtDiscountperc.Text.Length - 1);
                    
                    if (this.txtDiscountperc.Text.Length == 0)
                    {
                        this.txtDiscountperc.Text = "0";                        
                    }                    

                    break;

                case LastSelected.CustomerPaid:

                    this.txtCustomerPaid.Text = this.txtCustomerPaid.Text.Substring(0, this.txtCustomerPaid.Text.Length - 1);

                    if (this.txtCustomerPaid.Text.Length == 0)
                    {
                        this.txtCustomerPaid.Text = "0";
                    }

                    break;

                default:
                    break;
            }
        }

        private void txtDiscountAmount_Leave(object sender, EventArgs e)
        {

        }

        private void btnCancelItem_Click(object sender, EventArgs e)
        {
            if (this.dgvSaleItemList.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow dgvr in this.dgvSaleItemList.SelectedRows)
                {
                    if (dgvr.Index != (this.dgvSaleItemList.Rows.Count - 1))
                    {
                        this.dgvSaleItemList.Rows.Remove(dgvr);
                    }
                }
                this.CalculateTotal();
                txtbarcode.Select();
            }
        }
        

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            this.ClearAll();
            txtbarcode.Select();
        }

        private void ClearAll()
        {
            txtbarcode.Text = "";
            this.dgvSaleItemList.Rows.Clear();
            this.txtTotalAmount.Text = "0";
            this.txtDiscountAmount.Text = "0";
            this.txtDiscountPersent.Text = "0";
            this.txtNetPay.Text = "0";
            this.txtDiscountperc.Text = "0";
            this.txtCustomerPaid.Text = "0";
            this.txtChange.Text = "0";
            txt_CustomerName.Text = "";
            txtVat.Text = "";
        }
        
        private void dgvSaleItemList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.lastSelection = LastSelected.ItemList;
            this.txtDiscountperc.BackColor = Color.White;
            this.txtCustomerPaid.BackColor = Color.White;
            this.IsAddedMode = false;
        }

        private void dgvSaleItemList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.lastSelection = LastSelected.ItemList;
            this.txtDiscountperc.BackColor = Color.White;
            this.txtCustomerPaid.BackColor = Color.White;
        }

        private bool ValidateToBSaveData()
        {
            if (this.dgvSaleItemList.RowCount <= 1)
            {
                MessageBox.Show("Please select at least one item. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                flpItems01.Focus();
                return false;
            }

            if (this.txtCustomerPaid.Text == "0")
            {
                MessageBox.Show("Please Enter Paid Amount. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCustomerPaid.Focus();
                return false;
            }
            if (Convert.ToInt32(txtNetPay.Text)> Convert.ToInt32(this.txtCustomerPaid.Text.Trim()))
            {
                MessageBox.Show("Customar Paid Amount is less then Total Amount. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCustomerPaid.Focus();
                return false;
            }



            return true;
        }
        ArrayList arrList;
        private void LoadEmployeeData()
        {

            CEmployeeBO oEmployeeBO = new CEmployeeBO();
            CResult oResult = new CResult();
            CEmployee oEmployee = new CEmployee();
            //string Unit = cmbUnit.Text.Trim();
            //string Floor = cmbFloor.Text.Trim();
            //string Secion = cmbSection.Text.Trim();
            //string Block = cmbBlock.Text.Trim();
            //string Shift = cmbShift.Text.Trim();
            //string Designation = cmbDesignation.Text.Trim();
            //string Education = cmbEducation.Text.Trim();
            //string EmpID = txtEmpID.Text.Trim();

            oResult = oEmployeeBO.ReadAllEmployee(oEmployee);
            if (oResult.IsSuccess)
            {
                arrList = oResult.Data as ArrayList;
                CEmployee emp = new CEmployee();
                List<CEmployee> emplist = new List<CEmployee>();
                foreach (CEmployee obj in oResult.Data as ArrayList)
                {
                    emp = new CEmployee();
                    emp.EmpID = obj.EmpID;
                    emp.Name = obj.Name;
                    emplist.Add(emp);
                }
                ddlSalesExecutive.DataSource = emplist;
                ddlSalesExecutive.DisplayMember = "Name";
                ddlSalesExecutive.ValueMember = "EmpID";
            }
            else
            {
                MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSaveAndPrint_Click(object sender, EventArgs e)
        {
            if (defaultUserMode)
            {
                if (ValidateToBSaveData())
                {
                    CResult oResult = new CResult();
                    CSOBO oSOBO = new CSOBO();
                    CSOMaster oSOMaster = GetToSOFormData();

                    if (oSOMaster.SOMstr_DetailsList.Count > 0)
                    {
                        oResult = oSOBO.Create(oSOMaster);

                        if (oResult.IsSuccess)
                        {
                            //MessageBox.Show("Successfully Done. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            string SOMstID = (string)oResult.Data;
                            this.GenerateInvoiceReport(SOMstID);
                            this.ClearAll();
                            txtbarcode.Select();
                            this.LoadItemList();
                        }
                        else
                        {
                            MessageBox.Show(oResult.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                // Advance Start

                string m_sAdvanceConfigFileName = "AdvanceConfigAndLogFile.config";

                if (ValidateToBSaveData())
                {
                    CResult oResult = new CResult();
                    CSOBO oSOBO = new CSOBO();
                    CSOMaster oSOMaster = GetToSOFormData();

                    if (oSOMaster.SOMstr_DetailsList.Count > 0)
                    {
                        List<CSOMaster> oListSOMaster = new List<CSOMaster>();

                        System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        if (File.Exists(m_sAdvanceConfigFileName))
                        {
                            using (Stream stream = new FileStream(m_sAdvanceConfigFileName, FileMode.Open, FileAccess.Read, FileShare.None))
                            {
                                byte[] baKey = { 51, 208, 75, 59, 223, 134, 241, 155, 170, 229, 177, 160, 246, 71, 77, 141, 66, 7, 223, 103, 97, 80, 235, 82, 94, 107, 226, 190, 76, 94, 31, 43 };
                                byte[] baIV = { 142, 96, 41, 14, 206, 132, 173, 19, 12, 50, 124, 121, 42, 27, 35, 9 };
                                Rijndael rijndael = Rijndael.Create();
                                CryptoStream cryptoStream = new CryptoStream(stream, rijndael.CreateDecryptor(baKey, baIV), CryptoStreamMode.Read);
                                //
                                oListSOMaster = (List<CSOMaster>)formatter.Deserialize(cryptoStream);

                                //
                                cryptoStream.Close();
                            }
                        }
                        oListSOMaster.Add(oSOMaster);
                        formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        using (Stream stream = new FileStream(m_sAdvanceConfigFileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                        {
                            byte[] baKey = { 51, 208, 75, 59, 223, 134, 241, 155, 170, 229, 177, 160, 246, 71, 77, 141, 66, 7, 223, 103, 97, 80, 235, 82, 94, 107, 226, 190, 76, 94, 31, 43 };
                            byte[] baIV = { 142, 96, 41, 14, 206, 132, 173, 19, 12, 50, 124, 121, 42, 27, 35, 9 };
                            Rijndael rijndael = Rijndael.Create();
                            CryptoStream cryptoStream = new CryptoStream(stream, rijndael.CreateEncryptor(baKey, baIV), CryptoStreamMode.Write);
                            //
                            formatter.Serialize(cryptoStream, oListSOMaster);

                            //
                            cryptoStream.Close();
                        }
                        {
                            CResult oResult2 = new CResult();
                            CGRBO oGRBO = new CGRBO();
                            oResult2 = oGRBO.ReduceByItemOID(oSOMaster.SOMstr_DetailsList);
                        }
                        
                        //this.LoadItemList();
                        this.GenerateInvoiceReport(oSOMaster);
                        this.ClearAll();
                        txtbarcode.Select();
                    }
                    //
                }
                // Advance End
            }
        }

        private void GenerateInvoiceReport(CSOMaster oSOMaster)
        {
            POS posdateset = new POS();
            DataTable dtInv = posdateset.Invoice;
            foreach (CSODetails oSODetails in oSOMaster.SOMstr_DetailsList)
            {
                DataRow drInv = dtInv.NewRow();

                drInv["BranchName"] = currentBranch.CompBrn_Name;
                drInv["Address"] = currentBranch.CompBrn_Street;
                drInv["RoadNo"] = currentBranch.CompBrn_Road;
                drInv["City"] = currentBranch.CompBrn_City;
                drInv["Phone"] = currentBranch.CompBrn_Phone;
                drInv["InvoiceNo"] = oSOMaster.SOMstr_Code;
                drInv["VatClnNo"] = oSOMaster.SOMstr_VatClnNo;
                drInv["ItemName"] = oSODetails.SODet_ItemName;
                drInv["Qty"] = oSODetails.SODet_QTY;
                drInv["Price"] = oSODetails.SODet_Price;
                drInv["Amount"] = oSODetails.SODet_Amount;
                drInv["Discount"] = oSODetails.SODet_Discount;
                drInv["VATValue"] = oSODetails.SODet_VATValue;

                dtInv.Rows.Add(drInv);
            }

            rptInvoice objrptInvoice = new rptInvoice();
            objrptInvoice.SetDataSource(dtInv);
            objrptInvoice.SetParameterValue(0, float.Parse(txtDiscountAmount.Text.Trim()));
            objrptInvoice.SetParameterValue(1, currentUser.User_UserName.Trim());
            objrptInvoice.SetParameterValue(2, txtCustomerPaid.Text.Trim());
            objrptInvoice.SetParameterValue(3, txtChange.Text.Trim());
                        
            if (InvoiceRawKind == 0)
            {
                PrintDocument pd = new PrintDocument();
                pd.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("POS", 4, 4);
                InvoiceRawKind = (int)pd.PrinterSettings.DefaultPageSettings.PaperSize.RawKind;
            }

            objrptInvoice.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)InvoiceRawKind;

            objrptInvoice.PrintToPrinter(1, true, 1, 1);


            frmReportView ofrmReportView = new frmReportView();
            CrystalReportViewer orptviewer = (CrystalReportViewer)ofrmReportView.Controls["rptviewer"];
            orptviewer.ReportSource = objrptInvoice;
            orptviewer.AutoSize = false;

            orptviewer.Show();
            ofrmReportView.Show();

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
            oSOMaster.SOMstr_TotalAmt = float.Parse(txtTotalAmount.Text.Trim());
            oSOMaster.SOMstr_DiscAmt = float.Parse(txtDiscountAmount.Text.Trim());
            oSOMaster.SOMstr_NetAmt = float.Parse(this.txtNetPay.Text.Trim());
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

            if (rdCard.Checked)
            {
                oSOMaster.PaymentType = "Card";
                oSOMaster.CardType = ddlCardType.SelectedItem.ToString();
            }
            else
            {
                oSOMaster.PaymentType = "Cash";
                oSOMaster.CardType = "";
            }
            if (ddlSalesExecutive.SelectedIndex != -1)
            {
                oSOMaster.SalesMan = ddlSalesExecutive.SelectedValue.ToString();
            }

            for (int i = 0; i < this.dgvSaleItemList.Rows.Count - 1; i++)
            {
                DataGridViewRow dgvr = this.dgvSaleItemList.Rows[i];

                if (float.Parse(dgvr.Cells["chQty"].Value.ToString()) > 0)
                {
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
                    oSOMaster.SOMstr_DetailsList.Add(oSODetails);
                }
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

        int InvoiceRawKind = 0;

        private void GenerateInvoiceReport(string InvoiceID)
        {

            CSOBO oCSOBO = new CSOBO();
            CResult oResult = new CResult();

            oResult = oCSOBO.ReadInvoiceReport(InvoiceID);
            if (oResult.IsSuccess)
            {
                DataSet ds = (DataSet)oResult.Data;

                POS posdateset = new POS();
                DataTable dtInv = posdateset.Invoice;

                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    DataRow drInv = dtInv.NewRow();

                    drInv["BranchName"] = dr1["BranchName"];
                    drInv["Address"] = dr1["Address"];
                    drInv["RoadNo"] = dr1["RoadNo"];
                    drInv["City"] = dr1["City"];
                    drInv["Phone"] = dr1["Phone"];
                    drInv["InvoiceNo"] = dr1["InvoiceNo"];
                    drInv["VatClnNo"] = dr1["VatClnNo"];
                    drInv["ItemName"] = dr1["ItemName"];
                    drInv["Qty"] = dr1["Qty"];
                    drInv["Price"] = dr1["Price"];
                    drInv["Amount"] = dr1["Amount"];
                    drInv["Discount"] = dr1["Discount"];
                    drInv["VATValue"] = dr1["VATValue"];

                    drInv["TIN"] = dr1["TIN"];

                    drInv["PaymentType"] = dr1["PaymentType"];
                    dtInv.Rows.Add(drInv);
                }


                if (txtDiscountAmount.Text.Trim() == "")
                {
                    txtDiscountAmount.Text = "0";    
                }
                    rptInvoice2nd objrptInvoice = new rptInvoice2nd();
                    objrptInvoice.SetDataSource(dtInv);
                    objrptInvoice.SetParameterValue(0, float.Parse(txtDiscountAmount.Text.Trim()));
                    objrptInvoice.SetParameterValue(1, currentUser.User_UserName.Trim());
                    objrptInvoice.SetParameterValue(2, decimal.Parse(txtCustomerPaid.Text.Trim()));
                    objrptInvoice.SetParameterValue(3, decimal.Parse(txtChange.Text.Trim()));

                     objrptInvoice.PrintToPrinter(1, true, 1, 100);

                    //frmReportView ofrmReportView = new frmReportView();
                    //CrystalReportViewer orptviewer = (CrystalReportViewer)ofrmReportView.Controls["rptviewer"];
                    //orptviewer.ReportSource = objrptInvoice;
                    //orptviewer.Size = new Size(4, 4);
                    //orptviewer.AutoSize = false;

                    //orptviewer.Show();
                    //ofrmReportView.Show();

                
              

                // objrptInvoice.PrintToPrinter(1, true, 1, 100);

                //frmReportView ofrmReportView = new frmReportView();
                //CrystalReportViewer orptviewer = (CrystalReportViewer)ofrmReportView.Controls["rptviewer"];
                //orptviewer.ReportSource = objrptInvoice;
                //orptviewer.Size = new Size(4, 4);
                //orptviewer.AutoSize = false;

                //orptviewer.Show();
                //ofrmReportView.Show();
            }

            else
            {
                MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTotalAmount_TextChanged(object sender, EventArgs e)
        {
            //float a = float.Parse(txtTotalAmount.Text.Trim());
            //float b = float.Parse(txtDiscountAmount.Text.Trim());
            //float result = (a - b) / 100 * 15;
            //txtVat.Text = result.ToString();
        }

        private void txtDiscountperc_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscountperc.Text.Trim().Length > 0)
            {
                this.CalculateTotal();
            }
        }

        private void txtDiscountperc_Click(object sender, EventArgs e)
        {
            this.lastSelection = LastSelected.DiscountPercent;

            this.txtDiscountperc.BackColor = Color.Silver;
            this.txtCustomerPaid.BackColor = Color.White;
        }
        private void txtCustomerPaid_Click(object sender, EventArgs e)
        {
            this.lastSelection = LastSelected.CustomerPaid;

            this.txtDiscountperc.BackColor = Color.White;
            this.txtCustomerPaid.BackColor = Color.Silver;
        }

        private void txtCustomerPaid_TextChanged(object sender, EventArgs e)
        {
            if (this.txtCustomerPaid.Text.Trim().Length > 0)
            {
                if (this.txtCustomerPaid.Text.Trim().Length > 8)
                {

                    MessageBox.Show("Paid Amount Exceeding it's Limit. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtCustomerPaid.Text = "0";
                    this.txtChange.Text = "0";
                }
                txtChange.Text = (Math.Floor(float.Parse(this.txtCustomerPaid.Text.Trim()) - float.Parse(this.txtNetPay.Text.Trim()))).ToString();
            
            }
        }

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

        private void txtCustomerPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 48 && e.KeyChar<=57)&& !(e.KeyChar==8))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                DialogResult res=MessageBox.Show("Confirm Salse", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res.ToString()=="Yes")
                {
                    if (defaultUserMode)
                    {
                        if (ValidateToBSaveData())
                        {
                            CResult oResult = new CResult();
                            CSOBO oSOBO = new CSOBO();
                            CSOMaster oSOMaster = GetToSOFormData();

                            if (oSOMaster.SOMstr_DetailsList.Count > 0)
                            {
                                oResult = oSOBO.Create(oSOMaster);

                                if (oResult.IsSuccess)
                                {
                                    //MessageBox.Show("Successfully Done. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    string SOMstID = (string)oResult.Data;
                                    this.GenerateInvoiceReport(SOMstID);
                                    this.ClearAll();
                                    this.LoadItemList();
                                }
                                else
                                {
                                    MessageBox.Show(oResult.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
            }
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

        private void txtDiscountAmount_TextChanged(object sender, EventArgs e)
        {
            if (dgvSaleItemList.Rows.Count > 1)
            {
                CalculateTotal();
            }
            else
            {
                txtDiscountAmount.Text = "0";
            }
        }


        private void txtDiscountAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 48 && e.KeyChar <= 57) && !(e.KeyChar == 8))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtCustomerPaid.Select();
            }
        }

        private void btnPprice_Click(object sender, EventArgs e)
        {
            if (dgvSaleItemList.Rows.Count > 1)
            {
                List<CItemSales> selectedList = new List<CItemSales>();
                foreach (DataGridViewRow row in dgvSaleItemList.Rows)
                {
                    selectedList.Add((CItemSales)row.Tag);
                }
                frmPriceview oprice = new frmPriceview(selectedList);
                oprice.Show();

            }

        }

        private void loaddiscount()
        {
            CMemberShipBO oMembershipBO = new CMemberShipBO();
            CResult oResult = new CResult();
            List<CMemberShip> oMemberList = new List<CMemberShip>();
            oResult = oMembershipBO.ReadAllByDateAndIsActive(currentBranch.CompBrn_Code, txtDiscountMember.Text.Trim());
            if (oResult.IsSuccess)
            {
                oMemberList = oResult.Data as List<CMemberShip>;

                foreach (CMemberShip oCMemberShip in oMemberList)
                {
                    txtDiscountPersent.Text = oCMemberShip.Member_DiscountAmount.ToString();

                }

                //if (oMemberList.Count > 0)
                //{
                //    txtDiscountAmount.Select();
                //    txtDiscountAmount.BackColor = Color.Green;
                //    txtDiscountAmount.Select();
                //}
                //else
                //{
                //    if (txtDiscountMember.Text != "")
                //    {
                //        MessageBox.Show("Dear Customer your Membership Validation Period has been Expired. \n      Please... Renew your Membership Card. \n      We are sorry for this apologizes.", "ETL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        txtCustomerPaid.Select();
                //    }
                //}
            }
        }

        private void txtDiscountMember_TextChanged(object sender, EventArgs e)
        {
            if (txtNetPay.Text.Trim() != "0" && txtDiscountMember.Text.Length > 10)
            {
                loaddiscount();
            }
        }

        private void txtbarcode_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    txtDiscountMember.Select();
            //}
        }

        private void txtDiscountMember_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCustomerPaid.Select();
            }
        }

        private void txtDiscountMember_Leave(object sender, EventArgs e)
        {
            txtDiscountMember.Text = "";
        }
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i > 300)
            {
                timer1.Enabled = false;
                timer2.Enabled = true;
                lblWelcome.ForeColor = Color.DeepSkyBlue;
            }
            i++;
            lblWelcome.Location = new Point(i, 12);
        }
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (i <= 1)
            {
                timer2.Enabled = false;
                timer1.Enabled = true;
                lblWelcome.ForeColor = Color.Blue;
            }
            i--;
            lblWelcome.Location = new Point(i, 12);

        }

        private void btnGoodReceive_Click(object sender, EventArgs e)
        {
            frmGR ofrmGR = new frmGR();
            ofrmGR.ShowDialog();
            LoadItemList();
        }

        private void txtDiscountPersent_TextChanged(object sender, EventArgs e)
        {
            float a = float.Parse(txtNetPay.Text);
            float b = float.Parse(txtDiscountPersent.Text);
            txtDiscountAmount.Text = (a*b / 100).ToString();
        }



        
    }
    public enum LastSelected
    {
        ItemList = 1,

        DiscountPercent = 2,

        CustomerPaid = 4
    }
}
