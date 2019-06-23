using System;
using System.Data;
using System.Windows.Forms;
using ETL.Model;
using ETL.BLL;
using ETL.Common;
using ETLPOS.Reports;
using CrystalDecisions.Windows.Forms;
using Proshot.UtilityLib.CommonDialogs;
using System.Collections;




namespace ETLPOS
{
    public partial class ETLPOSMDI : BaseForm
    {
        bool IsdefaultUser = false;
        public ETLPOSMDI()
        {
            InitializeComponent();
           
        }
        public ETLPOSMDI(bool flag)
        {
            InitializeComponent();

            IsdefaultUser = flag;
        }

        private void CloseAllChild()
        {
            for (int i = 0; i < this.MdiChildren.Length; i++)
            {
                Form frm = (Form)this.MdiChildren[i];
                frm.Dispose();
            }
        }

        private void unitOfMasurementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            frmUOM oUOM = new frmUOM();
            oUOM.MdiParent = this;
            oUOM.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            Application.Exit();
        }

        private void itemTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            frmItemType oItemType = new frmItemType();
            oItemType.MdiParent = this;
            oItemType.Show();
        }

        private void itemGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            frmItemGroup oItemGroup = new frmItemGroup();
            oItemGroup.MdiParent = this;
            oItemGroup.Show();
        }

        private void itemEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            frmItem ofrmItem = new frmItem();
            ofrmItem.MdiParent = this;
            ofrmItem.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            frmCustomer ofrmCustomer = new frmCustomer();
            ofrmCustomer.MdiParent = this;
            ofrmCustomer.Show();
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            frmSupplier ofrmsupplier = new frmSupplier();            
            ofrmsupplier.MdiParent = this;
            ofrmsupplier.Show();
        }

        private void priceMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            frmPriceMaster ofrmPriceMaster = new frmPriceMaster();
            ofrmPriceMaster.MdiParent = this;
            ofrmPriceMaster.Show();
        }

        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            frmCompany ofrmCompany = new frmCompany();
            ofrmCompany.MdiParent = this;
            ofrmCompany.Show();
        }

        private void companyCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            frmCompanyBranch ofrmCompanyBranch = new frmCompanyBranch();
            ofrmCompanyBranch.MdiParent = this;
            ofrmCompanyBranch.Show();
        }
        private void companyVsCompanyCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompanyToBranch obran = new frmCompanyToBranch();
            obran.MdiParent = this;
            obran.Show();
        }

        private void locationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            frmLocation ofrmLocation = new frmLocation();
            ofrmLocation.MdiParent = this;
            ofrmLocation.Show();
        }

        private void currencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            frmCurrency ofrmCurrency = new frmCurrency();
            ofrmCurrency.MdiParent = this;
            ofrmCurrency.Show();
        }

        private void newEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            frmGR ofrmGR = new frmGR();
            ofrmGR.MdiParent = this;
            ofrmGR.Show();
        }

        private void salesOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CloseAllChild();
            frmSales ofrmSales = new frmSales();
            ofrmSales.MdiParent = this;
            ofrmSales.Show();
        }

        private void employeeMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();

            frmEmployee ofrmEmployee = new frmEmployee();
            ofrmEmployee.MdiParent = this;
            ofrmEmployee.Show();
        }

        private void reOrderLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            frmReorderLevel oReorderLevel = new frmReorderLevel();
            oReorderLevel.MdiParent = this;
            oReorderLevel.Show();
        }

        

        private void locationVsCompanyBranchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            frmLocationToBranch oLoc = new frmLocationToBranch();
            oLoc.MdiParent = this;
            oLoc.Show();
        }

        private void ETLPOSMDI_Load(object sender, EventArgs e)
        {
            this.Text = "REX Point Of Sale : " + currentBranch.CompBrn_Name + " : " + currentUser.User_UserName;
            //AlertForItemShortage();
           // timer1.Enabled = true;
           // timer2.Enabled = true;
            //AlertForItemPrice();
            if (currentBranch.CompBrn_IsHeadoffice == "Y")
            {
                this.exportDataToolStripMenuItem.Enabled = true;
            }
            else
            {
                this.exportDataToolStripMenuItem.Enabled = false;
            }

            if (IsdefaultUser)
            {
                this.goodsRecToolStripMenuItem.Enabled = false;
                this.masterToolStripMenuItem.Enabled = false;
                this.reportsToolStripMenuItem.Enabled = false;
                this.partyMamagementToolStripMenuItem.Enabled = false;
            }
            else
            {
                this.goodsRecToolStripMenuItem.Enabled = true;
                this.masterToolStripMenuItem.Enabled = true;
                this.reportsToolStripMenuItem.Enabled = true;
                this.partyMamagementToolStripMenuItem.Enabled = true;
            }

            
        }

        private void dailySalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            DailySaleDateInput oDailySaleDateInput = new DailySaleDateInput();
            //frmPALReport oDailySaleDateInput = new frmPALReport();
            oDailySaleDateInput.MdiParent = this;
            oDailySaleDateInput.Show();
        }

        private void stockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            PopulateReport();
        }

        private void PopulateReport()
        {

            CSOBO oCSOBO = new CSOBO();
            CResult oResult = new CResult();

            oResult = oCSOBO.DailyCurrentStockReport(currentBranch.CompBrn_OId.Trim());

            if (oResult.IsSuccess)
            {
                DataSet ds = (DataSet)oResult.Data;

                POS posdateset = new POS();
                DataTable dtDailySale = posdateset.Stock;

                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    DataRow drDailySale = dtDailySale.NewRow();

                    drDailySale["Qty"] = dr1["Qty"];
                    drDailySale["ItemName"] = dr1["ItemName"];
                    drDailySale["Invtype"] = Enum.GetName(typeof(EInvType), dr1["Invt_InvType"]);

                    dtDailySale.Rows.Add(drDailySale);
                }

                rptCurrStock oStockrpt = new rptCurrStock();
                oStockrpt.SetDataSource(dtDailySale);
                oStockrpt.SetParameterValue(0, currentUser.User_UserName.Trim());
                oStockrpt.SetParameterValue(1, currentBranch.CompBrn_Branch.Trim());

                frmReportView ofrmReportView = new frmReportView();
                CrystalReportViewer orptviewer = (CrystalReportViewer)ofrmReportView.Controls["rptviewer"];
                orptviewer.ReportSource = oStockrpt;
                orptviewer.Show();
                ofrmReportView.Show();
            }

            else
            {
                MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        
         //Report Stock Details-----------
        private void ReportStockDetails()
        {

            CSOBO oCSOBO = new CSOBO();
            CResult oResult = new CResult();

            oResult = oCSOBO.ReportStockDatials(currentBranch.CompBrn_OId.Trim());

            if (oResult.IsSuccess)
            {
                DataSet ds = (DataSet)oResult.Data;

                POS posdateset = new POS();
                DataTable dtStockDetail = posdateset.StockDetail;

                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    DataRow drStockDetail = dtStockDetail.NewRow();
                    drStockDetail["ItemName"] = dr1["Item_ItemName"];
                    drStockDetail["Qty"] = dr1["QTY"];
                    drStockDetail["Pprice"] = dr1["Pprice"];
                    drStockDetail["Sprice"] = dr1["Price"];
                    drStockDetail["ItemGroupCode"] = dr1["Item_GroupID"];
                    drStockDetail["ItemGroupName"] = dr1["CatCode"];
                    drStockDetail["ItemCode"] = dr1["Item_Code"];
                    dtStockDetail.Rows.Add(drStockDetail);
                }

                rptStockDetails oStockrpt = new rptStockDetails();
                oStockrpt.SetDataSource(dtStockDetail);
                oStockrpt.SetParameterValue(0, currentBranch.CompBrn_Branch.Trim());

                frmReportView ofrmReportView = new frmReportView();
                CrystalReportViewer orptviewer = (CrystalReportViewer)ofrmReportView.Controls["rptviewer"];
                orptviewer.ReportSource = oStockrpt;
                orptviewer.Show();
                ofrmReportView.Show();
            }

            else
            {
                MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            frmLogin ofrmLogin = new frmLogin();
            ofrmLogin.Show();
            this.Close();
        }

        private void newEditToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            frmMaterialTransfer ofrmMaterialTransfer = new frmMaterialTransfer();
            ofrmMaterialTransfer.MdiParent = this;
            ofrmMaterialTransfer.Show();
        }

        private void exportDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMTExpItems ofrmMaterialTransfer = new frmMTExpItems();
            ofrmMaterialTransfer.MdiParent = this;
            ofrmMaterialTransfer.Show();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            frmUser oUser = new frmUser();
            oUser.MdiParent = this;
            oUser.Show();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMasterExport ofrmMasterExport = new frmMasterExport();
            ofrmMasterExport.MdiParent = this;
            //ofrmMasterExport.Show();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMasterImport ofrmMasterImport = new frmMasterImport();
            ofrmMasterImport.MdiParent = this;
            //ofrmMasterImport.Show();
        }


        private void AlertForItemShortage()
        {

            CReorderLevelBO oReorderLevelBO = new CReorderLevelBO();
            CResult oResultReorderLevel = new CResult();
            CReorderLevel oReorderLevel = new CReorderLevel();
            String ItemName = null;

            oResultReorderLevel = oReorderLevelBO.ReadAllReorderLevelData(oReorderLevel);
            if (oResultReorderLevel.IsSuccess)
            {
                foreach (CReorderLevel obj in oResultReorderLevel.Data as ArrayList)
                {
                    oReorderLevel.Quantity = obj.Quantity;

                    CInventoryBO oInventoryBO = new CInventoryBO();
                    CResult oResultInventory = new CResult();
                    CInventory oInventory = new CInventory();
                    oInventory.Invt_BranchOID = obj.Branch_ID;
                    oInventory.Invt_LocOID = obj.Location_ID;
                    oInventory.Invt_ItemOID = obj.Item_ID;
                    oResultInventory = oInventoryBO.ReadForROL(oInventory);
                    if (oResultInventory.IsSuccess)
                    {
                        foreach (CInventory oInv in oResultInventory.Data as ArrayList)
                        {
                            if (int.Parse(oInv.Invt_QTY.ToString()) < int.Parse(oReorderLevel.Quantity.ToString()))
                            {
                                ItemName = ItemName + oInv.Invt_ItemName.ToString() + "\n";
                                // MessageBox.Show("Item", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                           
                        }

                    }
                }
                //MessageBox.Show("Shortage Of Following Items "+ItemName+"", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (ItemName != null)
                {
                    frmPopup ofrmPopUp = new frmPopup(PopupSkins.AlertSkin);
                    ofrmPopUp.ShowPopup("Item Shortage!!", "Shortage Of Following Items-" + ItemName + "", 500, 2000, 500);
                }
            }
        }

     
        private void AlertForItemPrice()
        {

            String ItemName = null;
            // DateTime CurrentDate;
            CPriceMasterBO oPriceMasterBO = new CPriceMasterBO();
            CResult oResultPriceMaster = new CResult();
            CPriceMaster oPriceMaster = new CPriceMaster();

            oResultPriceMaster = oPriceMasterBO.ReadAllForAlert();
            if (oResultPriceMaster.IsSuccess)
            {
                DataTable dt = oResultPriceMaster.Data as DataTable;
                foreach (DataRow dr in dt.Rows)
                {
                    oPriceMaster.Price_ToDate = DateTime.Parse(dr["Price_ToDate"].ToString());          //ToString("dd-MM-yy");
                    oPriceMaster.Price_ItemOId = dr["Price_ItemOId"].ToString();
                    oPriceMaster.Price_ItemName = dr["ItemName"].ToString();
                    // if (oPriceMaster.Price_ToDate < CurrentDate)

                    ItemName = ItemName + oPriceMaster.Price_ItemName.ToString() + "\n";



                }

            }
            if (ItemName != null)
            {

                frmPopup ofrmPopUp = new frmPopup(PopupSkins.AlertSkin);
                ofrmPopUp.ShowPopup("Price Update!!", "Price Should Be Updated Following Items-" + ItemName + "", 500, 10000, 500);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            AlertForItemPrice();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            AlertForItemShortage();
        }

        private void stickerPrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            frmsticker ofrmstk = new frmsticker();
            ofrmstk.MdiParent = this;
            ofrmstk.Show();
        }

        private void searchItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void itemSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            frmSearchItem ofrmstk = new frmSearchItem();
            ofrmstk.MdiParent = this;
            ofrmstk.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            //ItemUpdate ofrmstk = new ItemUpdate();
            //ofrmstk.MdiParent = this;
            //ofrmstk.Show();
            
        }

        private void dataBaseBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            frmBackup oBackup = new frmBackup();
            oBackup.MdiParent = this;
            oBackup.Show();
        }

        private void currentStockDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            ReportStockDetails();
        }

        private void memoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMemoReport ofrmMemoReport = new frmMemoReport();
            ofrmMemoReport.ShowDialog();
        }

        private void databaseBackupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBackupDB ofrmBackupDB = new frmBackupDB();
            //ofrmBackupDB.buttneVisibility = false;
            //ofrmBackupDB.ShowDialog();
        }

        private void databaseImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            frmGoodsImport ofrmImport = new frmGoodsImport();
            ofrmImport.ShowDialog();
        }

        private void partyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            frmPartyEntry oParty = new frmPartyEntry();
            //oParty.ShowDialog();
            oParty.MdiParent = this;
            oParty.Show();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            frmPurchase ofrmPurchase = new frmPurchase();
            ofrmPurchase.MdiParent = this;
            ofrmPurchase.Show();
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            frmPayment ofrmPayment = new frmPayment();
            ofrmPayment.MdiParent = this;
            ofrmPayment.Show();
        }

        private void paymentViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            frmPaymentView ofrmPaymentView = new frmPaymentView();
            ofrmPaymentView.MdiParent = this;
            ofrmPaymentView.Show();
        }

        private void purchaseViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CloseAllChild();
            frmPurchaseView ofrmPurchaseView = new frmPurchaseView();
            ofrmPurchaseView.MdiParent = this;
            ofrmPurchaseView.Show();
        }

        private void memberEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            frmMemberShip ofrmMembership = new frmMemberShip();
            ofrmMembership.MdiParent = this;
            ofrmMembership.Show();
        }

        private void memberDetailEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            frmMemberShipDetails ofrmMembershipDetails = new frmMemberShipDetails();
            ofrmMembershipDetails.MdiParent = this;
            ofrmMembershipDetails.Show();
        }

        private void itemsStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmItemStatus oItem = new frmItemStatus();
            oItem.ShowDialog();
        }

        private void dalilyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmDailySalesNew odailySalesInput = new frmDailySalesNew();
            //odailySalesInput.ShowDialog();

            adailysalesrep p = new adailysalesrep();
            p.Show();
        }

        private void returnProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Return_Product oRet = new Return_Product();
            oRet.ShowDialog();
        }

        private void returnReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportReturn oreportReturn = new frmReportReturn();
            oreportReturn.Show();
        }

        private void itemAndCategoryExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportItem frmItemExport = new ExportItem();
            frmItemExport.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProductSize oSize = new frmProductSize();
            oSize.Show();
        }

        private void salesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ImportBranceSalce oSales = new ImportBranceSalce();
            oSales.ShowDialog();
        }

        private void cardSaleCashSaleReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CardSaleCashSaleReport sale = new CardSaleCashSaleReport();
            sale.ShowDialog();
        }

        private void membershipToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmMemberShip member = new frmMemberShip();
            member.Show();
        }

        //private void gggToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    adailysalesrep p = new adailysalesrep();
        //    p.Show();
        //}



    }
}
