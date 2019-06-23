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
using Model;

namespace deletevat
{
    public partial class firmMerge : BaseForm
    {
        public string CurrentUser = "PULAK";
        public string Salaes_id = string.Empty;
        public string Receive_id = string.Empty;

        #region Constrator
        public firmMerge()
        {
            InitializeComponent();
        }
        #endregion

        #region Sales

        #region From Load Event
        private void firmMerge_Load_1(object sender, EventArgs e)
        {
            //AllseslProduct();
            GrandNetAmount();
            //BindGoodsReceive();
        }

        #endregion

        #region Button Event
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Grand Total

        private void GrandNetAmount()
        {
            float temp = 0;
            //float total = 0;
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
        #endregion

        #region Grid Cel Click Event

        private void dgvSaleaProduct_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            CDeleteSalesPorduct oSaleaProduct = new CDeleteSalesPorduct();


            if (dgvSaleaProduct.Rows.Count > 0)
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == 4)
                    {
                        if (MessageBox.Show("Are You Sure You Want TO Delete Sales Data?", "Sales Delete!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            string SODMas_OID = dgvSaleaProduct.Rows[e.RowIndex].Cells["CSalesID"].Value.ToString();
                            float amount = float.Parse(dgvSaleaProduct.Rows[e.RowIndex].Cells["SOMstr_NetAmt"].Value.ToString());
                            float NetAmount = float.Parse(txtTotalNetAmount.Text);
                            //float deletedAmount = NetAmount - amount;
                            float percentage = (amount * 100) / NetAmount;
                            txtDeletedAmount.Text = percentage.ToString();

                            CSalesproduct oSalseMaster = oSaleaProduct.DeleteFromMaster(SODMas_OID, CurrentUser);
                            dgvSaleaProduct.Rows.RemoveAt(e.RowIndex);

                            btnScarch_Click(sender, e);
                            //dgvSaleaDetails.Rows.Clear();
                            //getmaxID();

                        }
                    }
                }
            }


        }
        #endregion

        private void btnScarch_Click(object sender, EventArgs e)
        {
            
            List<CSalesproduct> oListSOProduct = new List<CSalesproduct>();

            CDeleteSalesPorduct oCDeleteSalesPorduct = new CDeleteSalesPorduct();
            DateTime date = dtpScarch.Value.Date;
            string branch = ddlbranch.Text;
            CSalesproduct[] oReceiveDetailsList = oCDeleteSalesPorduct.Scarch(date, branch).ToArray();

            if (oReceiveDetailsList != null)
            {
                dgvSaleaProduct.Rows.Clear();
                    foreach (CSalesproduct odetails in oReceiveDetailsList)
                    {
                        dgvSaleaProduct.Rows.Add(odetails.SOMstr_OID, odetails.SOMstr_Branch, odetails.SOMstr_Date, odetails.SOMstr_NetAmt, odetails.SOMstr_NetAmt);

                    }
              
            }
            GrandNetAmount();

        }
       
        #endregion
    }
}
