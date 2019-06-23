using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using deletevat.BO;
using deletevat.Model;
using System.Data.SqlClient;


namespace deletevat
{
    public partial class Sales : BaseForm
    {
        public string CurrentUser = "PULAK";
        public string Salaes_id = string.Empty;
        public string Receive_id = string.Empty;

        #region Constractor
        public Sales()
        {
            InitializeComponent();
        }
        #endregion

        #region Form Load Event
        private void frmMain_Load(object sender, EventArgs e)
        {
            //AllseslProduct();
            GrandNetAmount();
        }

        #endregion

        #region Private Method
        //private void AllseslProduct()
        //{
        //    CDeleteSalesPorduct oSelsproduct = new CDeleteSalesPorduct();
        //    CSalesproduct[] oSaleproList = oSelsproduct.allselsproduct(CurrentUser).ToArray();

        //    if (oSaleproList != null)
        //    {
        //        //int i = 1;
        //        foreach (CSalesproduct oSales in oSaleproList)
        //        {
        //            dgvSaleaProduct.Rows.Add(oSales.SOMstr_OID, oSales.SOMstr_Branch, oSales.SOMstr_Code, oSales.SOMstr_Date, oSales.SOMstr_TotalAmt, oSales.SOMstr_NetAmt);

        //        }
        //    }
        //}

        #endregion

        #region Grand Total

        private void GrandNetAmount()
        {
            float temp = 0;
            float total = 0;
            if (this.dgvSaleaProduct.Rows.Count > 0)
            {
                for (int i = 0; i < this.dgvSaleaProduct.Rows.Count - 1; i++)
                {

                    DataGridViewRow dgvr = this.dgvSaleaProduct.Rows[i];

                    temp += float.Parse(dgvr.Cells["SOMstr_NetAmt"].Value.ToString());
                }
                txtTotalNetAmount.Text = temp.ToString();
            }

        }


        private void GrandTotal()
        {
            float temp = 0;
            float total = 0;
            if (this.dgvSaleaDetails.Rows.Count > 0)
            {
                for (int i = 0; i < this.dgvSaleaDetails.Rows.Count - 1; i++)
                {

                    DataGridViewRow dgvr = this.dgvSaleaDetails.Rows[i];

                    temp += float.Parse(dgvr.Cells["SODet_Amount"].Value.ToString());
                    total += float.Parse(dgvr.Cells["SODet_VATValue"].Value.ToString());
                }
                txtTotalPrice.Text = temp.ToString();
                txtSaleaVatAmount.Text = total.ToString();
            }

        }

        #endregion

        #region Grid Cel Click Event
        private void dgvSaleaDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CDeleteSalesPorduct oSaleaProduct = new CDeleteSalesPorduct();
            if (dgvSaleaDetails.Rows.Count > 0)
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == 11)
                    {
                        string SODet_OID = dgvSaleaDetails.Rows[e.RowIndex].Cells["SODet_OID"].Value.ToString();
                        float qty = float.Parse(dgvSaleaDetails.Rows[e.RowIndex].Cells["SODet_QTY"].Value.ToString());
                        string ItemID = dgvSaleaDetails.Rows[e.RowIndex].Cells["ItemID"].Value.ToString();
                        string Rec_OID = dgvSaleaDetails.Rows[e.RowIndex].Cells["ReceiveID"].Value.ToString();
                       // float amount = float.Parse(dgvSaleaDetails.Rows[e.RowIndex].Cells["SODet_Amount"].Value.ToString());
                        //CSalesDetials oSalsedetails = oSaleaProduct.DeleteFromdetails(SODet_OID, ItemID, qty, Rec_OID,CurrentUser);

                        dgvSaleaDetails.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }

        }

        private void dgvSaleaProduct_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != null)
            {

                CDeleteSalesPorduct oSelsproduct = new CDeleteSalesPorduct();
                if (dgvSaleaProduct.Rows.Count > 0)
                {
                    dgvSaleaDetails.Rows.Clear();

                    if (dgvSaleaProduct.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    {
                        Salaes_id = dgvSaleaProduct.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    }

                    CSalesDetials[] oSalesDetailsList = oSelsproduct.Saleadetels(Salaes_id, CurrentUser).ToArray();
                    if (oSalesDetailsList != null)
                    {
                        foreach (CSalesDetials odetails in oSalesDetailsList)
                        {
                            dgvSaleaDetails.Rows.Add(odetails.SODet_OID, odetails.SODet_Branch, odetails.SODet_QTY, odetails.SODet_Price, odetails.SODet_Amount, odetails.SODet_SDValue, odetails.SODet_SDAmount, odetails.SODet_VATValue, odetails.SODet_VATAmount, odetails.SODet_Discount, odetails.SODet_NetAmount);

                        }
                    }

                }

                if (e.ColumnIndex == 0)
                {
                    GrandTotal();
                    txtTotalAmount.Text = (float.Parse(txtTotalPrice.Text) + float.Parse(txtSaleaVatAmount.Text)).ToString();
                    string str = txtTotalAmount.Text;
                    double d = Convert.ToDouble(str);
                    double total = System.Math.Ceiling(d);
                    txtTotaln.Text = total.ToString();

                }
            }
        }

        private void GridRefresh()
        {
            dgvSaleaDetails.Refresh();
        }

        private void dgvSaleaProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CDeleteSalesPorduct oSaleaProduct = new CDeleteSalesPorduct();

            
                if (dgvSaleaProduct.Rows.Count > 0)
                {
                    if (e.RowIndex != -1)
                    {
                        if (e.ColumnIndex == 6)
                        {
                            if (MessageBox.Show("Are You Sure You Want TO Delete Sales Data?", "Sales Delete!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                              string SODMas_OID = dgvSaleaProduct.Rows[e.RowIndex].Cells["CSalesID"].Value.ToString();

                              CSalesproduct oSalseMaster = oSaleaProduct.DeleteFromMaster(SODMas_OID, CurrentUser);
                              dgvSaleaProduct.Rows.RemoveAt(e.RowIndex);
                             
                              dgvSaleaProduct.Refresh();
                              dgvSaleaDetails.Rows.Clear();  
                             
                            }
                        }
                    }
                }
            }

        private void btnCancel_Click(object sender, EventArgs e)
        {
             this.Close();
        }

        }

        #endregion

     

    }


