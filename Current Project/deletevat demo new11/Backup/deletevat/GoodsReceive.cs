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
    public partial class GoodsReceive : BaseForm
    {
        public string CurrentUser = "PULAK";
        public string Receive_id = string.Empty;

        #region Constractor
        public GoodsReceive()
        {
            InitializeComponent();
        }
        #endregion

        #region From Load Event

        private void GoodsReceive_Load(object sender, EventArgs e)
        {
            BindGoodsReceive();
        }
        #endregion

        #region Private Method
        private void BindGoodsReceive()
        {
            CDeleteSalesPorduct oGoodReceiveMaster = new CDeleteSalesPorduct();
            CSGoodsReceive[] oGoodReceiveList = oGoodReceiveMaster.allGoodsReceive(CurrentUser).ToArray();

            if (oGoodReceiveList != null)
            {

                foreach (CSGoodsReceive oGoodsReceive in oGoodReceiveList)          //oGoodsReceiveMaster.GRMstr_Code,oGoodsReceiveMaster.GRMstr_Type,
                {
                    dgvGoodsReceive.Rows.Add(oGoodsReceive.Rec_OID,oGoodsReceive.Rec_ReqID,oGoodsReceive.Rec_IssueID, oGoodsReceive.Rec_BranchID, oGoodsReceive.Rec_ProductID,oGoodsReceive.Rec_WantedQTY,oGoodsReceive.Rec_IssueQTY,oGoodsReceive.Rec_Remark,oGoodsReceive.Rec_ReceivedQty);

                }
            }
        }
        #endregion

        #region Cell Click Event
        //private void dgvGoodsReceiveMaster_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex != null)
        //    {

        //        CDeleteSalesPorduct oGoodReceiveDetails = new CDeleteSalesPorduct();
        //        if (dgvGoodsReceiveMaster.Rows.Count > 0)
        //        {
        //            dgvGoodsReceiveDet.Rows.Clear();

        //            if (dgvGoodsReceiveMaster.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
        //            {
        //                Receive_id = dgvGoodsReceiveMaster.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        //            }

        //            CGoodsReceiveDetails[] oReceiveDetailsList = oGoodReceiveDetails.AllGoodsReceiveDetails(Receive_id, CurrentUser).ToArray();
        //            if (oReceiveDetailsList != null)
        //            {
        //                foreach (CGoodsReceiveDetails oReceivedetails in oReceiveDetailsList)
        //                {
        //                    dgvGoodsReceiveDet.Rows.Add(oReceivedetails.GRDet_OID, oReceivedetails.GRDet_Branch, oReceivedetails.GRDet_MStrOID, oReceivedetails.GRDet_ItemOID, oReceivedetails.GRDet_QTY, oReceivedetails.GRDet_UOM, oReceivedetails.GRDet_BranchOID, oReceivedetails.GRDet_LocOID, oReceivedetails.GRDet_InvType, oReceivedetails.GRDet_Currency, oReceivedetails.GRDet_Price, oReceivedetails.GRDet_Amount);

        //                }
        //            }

        //        }
        //    }
        //}

        //private void dgvGoodsReceiveDet_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    CDeleteSalesPorduct oGoodsReceive = new CDeleteSalesPorduct();
        //    if (dgvGoodsReceive.Rows.Count > 1)
        //    {
        //        if (e.RowIndex != -1)
        //        {
        //            if (e.ColumnIndex == 8)
        //            {
        //                string GRDetID = dgvGoodsReceive.Rows[e.RowIndex].Cells["GRDet_OID"].Value.ToString();

        //                CGoodsReceiveDetails oGoodsReceivedetails = oGoodsReceive.DeleteGoodsReceivede(GRDetID, CurrentUser);

        //                dgvGoodsReceive.Rows.RemoveAt(e.RowIndex);
        //            }
        //        }
        //    }
        //}

        //private void dgvGoodsReceiveMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    CDeleteSalesPorduct oSaleaProduct = new CDeleteSalesPorduct();
        //    if (dgvGoodsReceive.Rows.Count == 1)
        //    {
        //        if (dgvGoodsReceive.Rows.Count > 1)
        //        {
        //            if (e.RowIndex != -1)
        //            {
        //                if (e.ColumnIndex == 3)
        //                {
        //                    dgvGoodsReceive.Rows.RemoveAt(e.RowIndex);
        //                }
        //            }
        //        }

        //    }

        //}
        #endregion

        #region Button Event
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void dgvGoodsReceive_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CDeleteSalesPorduct oGoodsReceive = new CDeleteSalesPorduct();
            if (dgvGoodsReceive.Rows.Count > 0)
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == 9)
                    {
                        string Rec_OID = dgvGoodsReceive.Rows[e.RowIndex].Cells["Rec_OID"].Value.ToString();
                        string Rec_ProductID = dgvGoodsReceive.Rows[e.RowIndex].Cells["Rec_ProductID"].Value.ToString();

                        CSGoodsReceive oGoodReceiveProduct = oGoodsReceive.DeleteGoodsReceivede(Rec_OID,Rec_ProductID, CurrentUser); 

                        dgvGoodsReceive.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }

    }
}
