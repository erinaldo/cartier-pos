using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PULAK.DAL;
using deletevat.Model;
using System.Data;
using Model;

namespace deletevat.BO
{
    public class CDeleteSalesPorduct
    {
        CConManager oManager = null;
        public bool SalesMstrHasNoData = false;
        public string SODet_MStrOID = "";
        string strSQL = string.Empty;

        #region Sales Delete
        public CSalesproduct DeleteFromMaster(string SOMaster_OID, string uID)
        {
            CSalesproduct oSaleaProduct = new CSalesproduct();
            DataTable oDt = null;
            try
            {
                strSQL = "delete from t_SODet where  SODet_MStrOID = '" + SOMaster_OID + "'";

                oManager = new CConManager();
                oDt = oManager.Read(strSQL);

                strSQL = string.Empty;

                strSQL="delete from t_SOMstr where  SOMstr_OID = '" + SOMaster_OID + "'";

                oManager = new CConManager();
                oDt = oManager.Read(strSQL);

                //strSQL = "Update t_SOMstr set SOMstr_OID='" +  + "'";
            }
            catch (Exception ex)
            {
                CConManager oManager = new CConManager();
                oManager.s_ErrorMessage = ex.Message;

            }
            return oSaleaProduct;

        }

        //public List<CHijibi> amount(string uID)
        //{
        //    List<CHijibi> oamount =new List<CHijibi>();
        //    DataTable oDt = null;
        //    strSQL = "select * from t_Mozila";
        //    oManager = new CConManager();
        //    oDt = oManager.Read(strSQL, uID);
        //    if (oDt != null)
        //    {
        //        foreach (DataRow dr in oDt.Rows)
        //        {
        //            CHijibi oamounta = new CHijibi();
        //            oamounta.Chrom = float.Parse(dr["Chrom"].ToString());
        //            oamount.Add(oamounta);

        //            oamounta = null;
        //        }
        //    }

        //    return oamount;
        //}

        //public CSalesproduct CreateMaxID(string uID)
        //{
        //    string MasterID = string.Empty;
        //    DataTable oDt = null;
        //    try
        //    {
        //        strSQL = string.Format("SELECT  SOMstr_OID FROM t_SOMstr ");
        //        oManager = new CConManager();
        //        oDt = oManager.Read(strSQL, uID);
        //        if (oDt != null)
        //        {
        //            if (oDt.Rows.Count == 0)//BIL-NO-00001
        //            {
        //                MasterID = "SOMstrXXBRN01 0000000001";
        //            }
        //            else
        //            {

        //                DataRow dr = oDt.Rows[0];
        //                MasterID = dr["Bill_Id"].ToString();
        //                MasterID = MasterID.Remove(0, 13);

        //                MasterID = (Convert.ToInt64(MasterID) + 1).ToString();
        //                MasterID = MasterID.PadLeft(2, '0');
        //                MasterID = MasterID.PadLeft(3, '0');
        //                MasterID = MasterID.PadLeft(4, '0');
        //                MasterID = MasterID.PadLeft(5, '0');
        //                MasterID = MasterID.PadLeft(6, '0');
        //                MasterID = MasterID.PadLeft(7, 'O');
        //                MasterID = MasterID.PadLeft(8, '0');
        //                MasterID = MasterID.PadLeft(9, '0');
        //                MasterID = MasterID.PadLeft(10, '0');
        //                MasterID = MasterID.PadLeft(11,  ' ');
        //                MasterID = MasterID.PadLeft(12, '1');
        //                MasterID = MasterID.PadLeft(13, '0');
        //                MasterID = MasterID.PadLeft(14, 'N');
        //                MasterID = MasterID.PadLeft(15, 'R');
        //                MasterID = MasterID.PadLeft(16, 'B');
        //                MasterID = MasterID.PadLeft(17, 'X');
        //                MasterID = MasterID.PadLeft(18, 'X');
        //                MasterID = MasterID.PadLeft(19, 'r');
        //                MasterID = MasterID.PadLeft(20, 't');
        //                MasterID = MasterID.PadLeft(21, 's');
        //                MasterID = MasterID.PadLeft(22, 'M');
        //                MasterID = MasterID.PadLeft(23, 'O');
        //                MasterID = MasterID.PadLeft(23, 'S');

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        oManager.s_ErrorMessage = ex.Message;
        //        MasterID = string.Empty;
        //    }
        //    finally
        //    {
        //        oManager = null;
        //        strSQL = string.Empty;
        //    }
        //    return null;
        //}

        public CSalesDetials DeleteFromdetails(string ItemID, string So_detailsID, float qty, string receiveID, string MasterID, float detamount, string uID)
        {
            CSalesDetials oSaleaDetails = new CSalesDetials();
            DataTable oDt = null;
            try
            {
                strSQL = "delete from t_SODet where SODet_OID='" + So_detailsID + "'";

                //strSQL = @"IF(EXISTS(SELECT ID FROM t_SODet WHERE SODet_ItemOID='" + Rec_OID + "'))BEGIN UPDATE t_GReceive SET Rec_ReceivedQty=Rec_ReceivedQty-" + oSaleaDetails.SODet_QTY + "where Rec_ProductID='" + Rec_OID + "' END";
                //sqlList.Add(strSQL);

                oManager = new CConManager();
                oDt = oManager.Read(strSQL);

                strSQL = string.Empty;

                strSQL = "Update t_GReceive set Rec_ReceivedQty=Rec_ReceivedQty- " + qty + " where Rec_OID='" + receiveID + "' and Rec_ProductID = '" + ItemID + "'";

                oManager = new CConManager();
                oDt = oManager.Read(strSQL);

                strSQL = string.Empty;
                strSQL = "Update t_SOMstr set SOMstr_NetAmt=SOMstr_NetAmt- " + detamount + " where SOMstr_OID='" + MasterID + "'";

                oManager = new CConManager();
                oDt = oManager.Read(strSQL);
                
                //float deletedAmount = Actualamount - amount;
               // float percentage = (deletedAmount * 100) / Actualamount;
                
            }
            catch (Exception ex)
            {
                CConManager oManager = new CConManager();
                oManager.s_ErrorMessage = ex.Message;

            }
            return oSaleaDetails;

        }
        #endregion

        #region Select event
        public List<CSalesDetials> Saleadetels(string SODet_MStrOID, string uID)
        {

            List<CSalesDetials> oSalesDetails = new List<CSalesDetials>();
            DataTable oDt = null;
            try
            {                //SELECT     dbo.t_Item.Item_ItemName, dbo.t_SODet.* FROM dbo.t_Item LEFT OUTER JOIN dbo.t_SODet ON dbo.t_Item.Item_OID = dbo.t_SODet.SODet_ItemOID
                strSQL = @"SELECT     dbo.t_SODet.SODet_OID, dbo.t_SODet.SODet_Branch, dbo.t_SODet.SODet_MStrOID, dbo.t_SODet.SODet_ItemSLNum, dbo.t_SODet.SODet_ItemOID, 
                      dbo.t_SODet.SODet_QTY, dbo.t_SODet.SODet_UOM, dbo.t_SODet.SODet_Price, dbo.t_SODet.SODet_Currency, dbo.t_SODet.SODet_Amount, 
                      dbo.t_SODet.SODet_SDValue, dbo.t_SODet.SODet_SDAmount, dbo.t_SODet.SODet_VATValue, dbo.t_SODet.SODet_VATAmount, dbo.t_SODet.SODet_Discount, 
                      dbo.t_SODet.SODet_NetAmount, dbo.t_SODet.SODet_BranchOID, dbo.t_SODet.SODet_LocOID, dbo.t_GReceive.Rec_ReceivedQty, dbo.t_GReceive.Rec_IssueQTY, 
                      dbo.t_GReceive.Rec_WantedQTY, dbo.t_GReceive.Rec_ProductID, dbo.t_GReceive.Rec_OID, dbo.t_GReceive.Rec_BranchID, dbo.t_Item.Item_ItemName
                      FROM         dbo.t_Item LEFT OUTER JOIN
                      dbo.t_SODet ON dbo.t_Item.Item_OID = dbo.t_SODet.SODet_ItemOID LEFT OUTER JOIN
                      dbo.t_GReceive ON dbo.t_SODet.SODet_ItemOID = dbo.t_GReceive.Rec_ProductID where SODet_MStrOID= '" + SODet_MStrOID + "'";

                oManager = new CConManager();
                oDt = oManager.Read(strSQL);
                if (oDt.Rows.Count > 0)
                {

                    foreach (DataRow dr in oDt.Rows)
                    {
                        CSalesDetials salesDetails = new CSalesDetials();
                        salesDetails.SODet_OID = dr["SODet_OID"].ToString();
                        salesDetails.SODet_MStrOID = dr["SODet_MStrOID"].ToString();
                        salesDetails.SODet_ItemName = dr["Item_ItemName"].ToString();
                        salesDetails.SODet_Branch = dr["SODet_Branch"].ToString();
                        //salesDetails.SODet_ItemSLNum = dr["SODet_ItemSLNum"].ToString();
                        salesDetails.SODet_ItemOID = dr["SODet_ItemOID"].ToString();
                        //salesDetails.SODet_ItemName = dr["SODet_ItemName"].ToString();
                        salesDetails.SODet_QTY = float.Parse(dr["SODet_QTY"].ToString());
                        //salesDetails.SODet_UOM = dr["SODet_UOM"].ToString();
                        salesDetails.SODet_Price = float.Parse(dr["SODet_Price"].ToString());
                        //salesDetails.SODet_Currency = dr["SODet_Currency"].ToString();
                        salesDetails.SODet_Amount = float.Parse(dr["SODet_Amount"].ToString());
                        salesDetails.SODet_SDValue = float.Parse(dr["SODet_SDValue"].ToString());
                        salesDetails.SODet_SDAmount = float.Parse(dr["SODet_SDAmount"].ToString());
                        salesDetails.SODet_VATValue = float.Parse(dr["SODet_VATValue"].ToString());
                        salesDetails.SODet_VATAmount = float.Parse(dr["SODet_VATAmount"].ToString());
                        salesDetails.SODet_Discount = float.Parse(dr["SODet_Discount"].ToString());
                        salesDetails.SODet_NetAmount = float.Parse(dr["SODet_NetAmount"].ToString());
                        salesDetails.Rec_OID = dr["Rec_OID"].ToString();
                        //salesDetails.SODet_LocOID = dr["SODet_LocOID"].ToString();


                        oSalesDetails.Add(salesDetails);

                        salesDetails = null;
                    }
                }

                //else
                //{
                //    strSQL = @"delete from t_SOMstr where SOMstr_OID = '" + SODet_MStrOID + "'";

                //    oManager = new CConManager();
                //    oDt = oManager.Read(strSQL, uID);
                //}
            }
            catch (Exception ex)
            {

                CConManager oManager = new CConManager();
                oManager.s_ErrorMessage = ex.Message;

            }
            return oSalesDetails;

        }

        public List<CSalesproduct> Scarch(DateTime dtDate, string branch)
        {
            List<CSalesproduct> salesproductList = new List<CSalesproduct>();
            DataTable oDt = null;
            try
            {
                strSQL = string.Format("SELECT *  FROM dbo.t_SOMstr where SOMstr_Date= '" + dtDate + "' AND SOMstr_Branch = '" + branch + "' ");

                oManager = new CConManager();
                oDt = oManager.Read(strSQL);
                if (oDt != null)
                {

                    foreach (DataRow dr in oDt.Rows)
                    {
                        CSalesproduct osalesproduct = new CSalesproduct();
                        osalesproduct.SOMstr_OID = dr["SOMstr_OID"].ToString();
                        osalesproduct.SOMstr_Code = dr["SOMstr_Code"].ToString();
                        osalesproduct.SOMstr_Branch = dr["SOMstr_Branch"].ToString();
                        osalesproduct.SOMstr_Code = dr["SOMstr_Code"].ToString();
                        osalesproduct.SOMstr_Date = DateTime.Parse(dr["SOMstr_Date"].ToString());
                        osalesproduct.SOMstr_TotalAmt =float.Parse( dr["SOMstr_TotalAmt"].ToString());
                        osalesproduct.SOMstr_NetAmt = float.Parse(dr["SOMstr_NetAmt"].ToString());

                        salesproductList.Add(osalesproduct);

                        osalesproduct = null;
                    }
                }

            }
            catch (Exception ex)
            {

                CConManager oManager = new CConManager();
                oManager.s_ErrorMessage = ex.Message;

            }
            return salesproductList;

        }

        public List<CSalesproduct> allselsproduct(string uID)
        {
            List<CSalesproduct> salesproductList = new List<CSalesproduct>();
            DataTable oDt = null;
            try
            {
                strSQL = string.Format("SELECT SOMstr_OID, SOMstr_Branch, SOMstr_Code, SOMstr_Date,SOMstr_TotalAmt,SOMstr_NetAmt FROM dbo.t_SOMstr ");

                oManager = new CConManager();
                oDt = oManager.Read(strSQL);
                if (oDt != null)
                {

                    foreach (DataRow dr in oDt.Rows)
                    {
                        CSalesproduct osalesproduct = new CSalesproduct();
                        osalesproduct.SOMstr_OID = dr["SOMstr_OID"].ToString();
                        osalesproduct.SOMstr_Branch = dr["SOMstr_Branch"].ToString();
                        osalesproduct.SOMstr_Code = dr["SOMstr_Code"].ToString();
                        osalesproduct.SOMstr_Date = DateTime.Parse(dr["SOMstr_Date"].ToString());
                        osalesproduct.SOMstr_TotalAmt =float.Parse( dr["SOMstr_TotalAmt"].ToString());
                        osalesproduct.SOMstr_NetAmt = float.Parse(dr["SOMstr_NetAmt"].ToString());
                        salesproductList.Add(osalesproduct);

                        osalesproduct = null;
                    }
                }

            }
            catch (Exception ex)
            {

                CConManager oManager = new CConManager();
                oManager.s_ErrorMessage = ex.Message;

            }
            return salesproductList;

        }
        #endregion

        #region All Goods Receive Master
        public List<CSGoodsReceive> allGoodsReceive(string uID)
        {
            List<CSGoodsReceive> oGoodsReceiveList = new List<CSGoodsReceive>();
            DataTable oDt = null;
            try
            {
                strSQL = string.Format("SELECT     dbo.t_GReceive.Rec_OID, dbo.t_GReceive.Rec_ReqID, dbo.t_GReceive.Rec_IssueID, dbo.t_GReceive.Rec_BranchID, dbo.t_GReceive.Rec_ProductID, dbo.t_GReceive.Rec_WantedQTY, dbo.t_GReceive.Rec_IssueQTY, dbo.t_GReceive.Rec_Remark, dbo.t_GReceive.Rec_ReceivedQty, dbo.t_Item.Item_ItemName FROM  dbo.t_Item RIGHT OUTER JOIN dbo.t_GReceive ON dbo.t_Item.Item_OID = dbo.t_GReceive.Rec_ProductID");

                oManager = new CConManager();
                oDt = oManager.Read(strSQL);
                if (oDt != null)
                {

                    foreach (DataRow dr in oDt.Rows)
                    {
                        CSGoodsReceive oGoodReceives = new CSGoodsReceive();
                        oGoodReceives.Item_Name = dr["Item_ItemName"].ToString();
                        oGoodReceives.Rec_OID = dr["Rec_OID"].ToString();
                        oGoodReceives.Rec_ReqID = dr["Rec_ReqID"].ToString();
                        oGoodReceives.Rec_IssueID = dr["Rec_IssueID"].ToString();
                        oGoodReceives.Rec_BranchID = dr["Rec_BranchID"].ToString();
                        oGoodReceives.Rec_ProductID = dr["Rec_ProductID"].ToString();
                        oGoodReceives.Rec_WantedQTY = Int32.Parse( dr["Rec_WantedQTY"].ToString());
                        oGoodReceives.Rec_IssueQTY = Int32.Parse( dr["Rec_IssueQTY"].ToString());
                        oGoodReceives.Rec_Remark = dr["Rec_Remark"].ToString();
                        oGoodReceives.Rec_ReceivedQty = Int32.Parse(dr["Rec_ReceivedQty"].ToString());
                        oGoodsReceiveList.Add(oGoodReceives);

                        oGoodReceives = null;
                    }
                }

            }
            catch (Exception ex)
            {

                CConManager oManager = new CConManager();
                oManager.s_ErrorMessage = ex.Message;

            }
            return oGoodsReceiveList;
        }

        #endregion

        #region Good Receive Details
        //public List<CGoodsReceiveDetails> AllGoodsReceive(string Rec_OID, string uID)
        //{

        //    List<CGoodsReceiveDetails> oGoodReceiveList = new List<CGoodsReceiveDetails>();
        //    DataTable oDt = null;
        //    try
        //    {
        //        strSQL = @"select  * from t_GRDet where GRDet_MStrOID= '" + GRMstr_ID + "'";

        //        oManager = new CConManager();
        //        oDt = oManager.Read(strSQL, uID);
        //        if (oDt.Rows.Count > 0)
        //        {

        //            foreach (DataRow dr in oDt.Rows)
        //            {
        //                CGoodsReceiveDetails oGoodsReceiveDetails = new CGoodsReceiveDetails();
        //                oGoodsReceiveDetails.GRDet_OID = dr["GRDet_OID"].ToString();
        //                oGoodsReceiveDetails.GRDet_Branch = dr["GRDet_Branch"].ToString();
        //                oGoodsReceiveDetails.GRDet_MStrOID = dr["GRDet_MStrOID"].ToString();
        //                oGoodsReceiveDetails.GRDet_ItemOID = dr["GRDet_ItemOID"].ToString();
        //                oGoodsReceiveDetails.GRDet_QTY = float.Parse(dr["GRDet_QTY"].ToString());
        //                oGoodsReceiveDetails.GRDet_UOM = dr["GRDet_UOM"].ToString();
        //                oGoodsReceiveDetails.GRDet_BranchOID =dr["GRDet_BranchOID"].ToString();
        //                oGoodsReceiveDetails.GRDet_LocOID = dr["GRDet_LocOID"].ToString();
        //                oGoodsReceiveDetails.GRDet_InvType = int.Parse(dr["GRDet_InvType"].ToString());
        //                oGoodsReceiveDetails.GRDet_Currency = dr["GRDet_Currency"].ToString();
        //                oGoodsReceiveDetails.GRDet_Price = float.Parse(dr["GRDet_Price"].ToString());
        //                oGoodsReceiveDetails.GRDet_Amount = float.Parse(dr["GRDet_Amount"].ToString());
        
        //                oGoodReceiveList.Add(oGoodsReceiveDetails);
        //                oGoodsReceiveDetails = null;
        //            }
        //        }

        //        else
        //        {
        //            strSQL = @"delete from t_GRMstr where GRMstr_OID = '" + GRMstr_ID + "'";

        //            oManager = new CConManager();
        //            oDt = oManager.Read(strSQL, uID);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        CConManager oManager = new CConManager();
        //        oManager.s_ErrorMessage = ex.Message;

        //    }
        //    return oGoodReceiveList;

        //}
        #endregion

        #region Delete GoodsReceive Details

        public CSGoodsReceive UpdateGoodsReceivede(CSGoodsReceive ogoodreceive, string uID)
        {
            CSGoodsReceive oReceiveDetails = new CSGoodsReceive();
            DataTable oDt = null;
            try
            {
                strSQL = "Update t_GReceive set Rec_ReceivedQty= " + ogoodreceive.Rec_ReceivedQty + "where Rec_OID = " + ogoodreceive.Rec_OID + " and Rec_ProductID = '" + ogoodreceive.Rec_ProductID + "' ";

                oManager = new CConManager();
                oDt = oManager.Read(strSQL);
            }
            catch (Exception ex)
            {
                CConManager oManager = new CConManager();
                oManager.s_ErrorMessage = ex.Message;

            }
            return oReceiveDetails;

        }

        public CSGoodsReceive DeleteGoodsReceivede(string Rec_OID,string Rec_ProductID, string uID)
        {
            CSGoodsReceive oReceiveDetails = new CSGoodsReceive();
            DataTable oDt = null;
            try
            {
                strSQL = "delete from t_GReceive where Rec_OID = '" + Rec_OID + "' and Rec_ProductID = '" + Rec_ProductID + "' ";

                oManager = new CConManager();
                oDt = oManager.Read(strSQL);
            }
            catch (Exception ex)
            {
                CConManager oManager = new CConManager();
                oManager.s_ErrorMessage = ex.Message;

            }
            return oReceiveDetails;

        }
        #endregion
    }
}



