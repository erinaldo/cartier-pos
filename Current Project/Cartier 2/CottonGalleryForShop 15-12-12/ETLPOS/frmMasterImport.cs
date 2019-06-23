using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

using ETL.BLL;
using ETL.Common;
using ETL.Model;

namespace ETLPOS
{
    public partial class frmMasterImport : BaseForm
    {
        public frmMasterImport()
        {
            InitializeComponent();
            this.ImportData();
        }

        private void ImportData()
        {
            string m_sMasterImportFileName = DateTime.Now.ToString("dd-MMM-yyyy") + "_" + currentBranch.CompBrn_Name;
            openFileDialog1.FileName = m_sMasterImportFileName;
            openFileDialog1.InitialDirectory = @"H:\";
            openFileDialog1.Filter = "Master File (*.mstrexp)|*.mstrexp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                m_sMasterImportFileName = openFileDialog1.FileName;

                if (File.Exists(m_sMasterImportFileName))
                {
                    IFormatter formatter = new BinaryFormatter();
                    using (Stream stream = new FileStream(m_sMasterImportFileName, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        byte[] baKey = { 51, 208, 75, 59, 223, 134, 241, 155, 170, 229, 177, 160, 246, 71, 77, 141, 66, 7, 223, 103, 97, 80, 235, 82, 94, 107, 226, 190, 76, 94, 31, 43 };
                        byte[] baIV = { 142, 96, 41, 14, 206, 132, 173, 19, 12, 50, 124, 121, 42, 27, 35, 9 };
                        Rijndael rijndael = Rijndael.Create();
                        CryptoStream cryptoStream = new CryptoStream(stream, rijndael.CreateDecryptor(baKey, baIV), CryptoStreamMode.Read);
                        //

                        {
                            CResult oResult;
                            StringBuilder oErrBuilder = new StringBuilder();
                            try{
                                // UOM
                                ArrayList oListUOM = (ArrayList)formatter.Deserialize(cryptoStream);

                                // Item Type
                                ArrayList oListItemType = (ArrayList)formatter.Deserialize(cryptoStream);

                                // Item Group
                                ArrayList oListItemGroup = (ArrayList)formatter.Deserialize(cryptoStream);

                                // Item
                                ArrayList oListItem = (ArrayList)formatter.Deserialize(cryptoStream);

                                // Reorder Level
                                ArrayList oListReorderLevel = (ArrayList)formatter.Deserialize(cryptoStream);

                                // Currency
                                List<CCurrency> oListCurrency = (List<CCurrency>)formatter.Deserialize(cryptoStream);

                                // Price Master
                                ArrayList oListPriceMaster = (ArrayList)formatter.Deserialize(cryptoStream);

                                // Customer
                                ArrayList oListCustomer = (ArrayList)formatter.Deserialize(cryptoStream);

                                // Supplier
                                ArrayList oListSupplier = (ArrayList)formatter.Deserialize(cryptoStream);

                                // Company
                                List<CCompany> oListCompany = (List<CCompany>)formatter.Deserialize(cryptoStream);

                                // Company Branch
                                List<CCompanyBranch> oListCompanyBranch = (List<CCompanyBranch>)formatter.Deserialize(cryptoStream);

                                // Company Vs CompanyBranch
                                ArrayList oListCVB = (ArrayList)formatter.Deserialize(cryptoStream);

                                // Inventory Location
                                ArrayList oListLocation = (ArrayList)formatter.Deserialize(cryptoStream);

                                // CompanyBranch Vs Location
                                ArrayList oListBVL = (ArrayList)formatter.Deserialize(cryptoStream);

                                // Employee
                                ArrayList oListEmployee = (ArrayList)formatter.Deserialize(cryptoStream);

                                // User
                                ArrayList oListUser = (ArrayList)formatter.Deserialize(cryptoStream);



                                
                                //Import UOM
                                oResult = new CResult();
                                CUOMBO oUOMBO = new CUOMBO();
                                foreach (CUOM oUOM in oListUOM)
                                {
                                    oResult = oUOMBO.Import(oUOM);
                                    if (!oResult.IsSuccess)
                                    {
                                        oErrBuilder.Append("UOM : " + oResult.ErrMsg + "/n");
                                    }
                                }

                                //Import Itemtyps
                                oResult = new CResult();
                                CItemBO oItemBO = new CItemBO();
                                foreach (CItemType oItemType in oListItemType)
                                {
                                    oResult = oItemBO.Import(oItemType);
                                    if (!oResult.IsSuccess)
                                    {
                                        oErrBuilder.Append("Item Type : " + oResult.ErrMsg + "\n");
                                    }
                                }

                                //Item Group 
                                oResult = new CResult();
                                foreach (CItemGroup oItemGroup in oListItemGroup)
                                {
                                    oResult = oItemBO.Import(oItemGroup);
                                    if (!oResult.IsSuccess)
                                    {
                                        oErrBuilder.Append("Item Type : " + oResult.ErrMsg + "/n");
                                    }
                                }

                                // Import Item with images
                                oResult = new CResult();
                                foreach (CItem oItem in oListItem)
                                {
                                    oResult = oItemBO.Import(oItem);
                                    if (!oResult.IsSuccess)
                                    {
                                        oErrBuilder.Append("Item : " + oResult.ErrMsg + "/n");
                                    }
                                }

                                // Reorder Level
                                oResult = new CResult();
                                CReorderLevelBO oReorderLevelBO = new CReorderLevelBO();
                                foreach (CReorderLevel oReorderLevel in oListReorderLevel)
                                {
                                    oResult = oReorderLevelBO.Import(oReorderLevel);
                                    if (!oResult.IsSuccess)
                                    {
                                        oErrBuilder.Append("ReorderLevel : " + oResult.ErrMsg + "/n");
                                    }
                                }

                                // IMPORT CURRENCY
                                oResult = new CResult();
                                CCurrencyBO oCurrencyBO = new CCurrencyBO();
                                foreach (CCurrency oCurrency in oListCurrency)
                                {
                                    oResult = oCurrencyBO.Import(oCurrency);
                                    if (!oResult.IsSuccess)
                                    {
                                        oErrBuilder.Append("Currency : " + oResult.ErrMsg + "/n");
                                    }
                                }

                                // Import Pricemaster
                                oResult = new CResult();
                                CPriceMasterBO oPriceMasterBO = new CPriceMasterBO();
                                foreach (CPriceMaster oPriceMaster in oListPriceMaster)
                                {
                                    oResult = oPriceMasterBO.Import(oPriceMaster);
                                    if (!oResult.IsSuccess)
                                    {
                                        oErrBuilder.Append("Price : " + oResult.ErrMsg + "/n");
                                    }
                                }

                                // Import Customer
                                oResult = new CResult();
                                CCustomerBO oCustomerBO = new CCustomerBO();
                                foreach (CCustomer oCustomer in oListCustomer)
                                {
                                    oResult = oCustomerBO.Import(oCustomer);
                                    if (!oResult.IsSuccess)
                                    {
                                        oErrBuilder.Append("Customer : " + oResult.ErrMsg + "/n");
                                    }
                                }


                                // Import supplier
                                oResult = new CResult();
                                CSupplierBO oSupplierBO = new CSupplierBO();
                                foreach (CSupplier oSupplier in oListSupplier)
                                {
                                    oResult = oSupplierBO.Import(oSupplier);
                                    if (!oResult.IsSuccess)
                                    {
                                        oErrBuilder.Append("Supplier : " + oResult.ErrMsg + "/n");
                                    }
                                }

                                // Import company
                                oResult = new CResult();
                                CCompanyBO oCompanyBO = new CCompanyBO();

                                foreach (CCompany oCompany in oListCompany)
                                {
                                    oResult = oCompanyBO.Import(oCompany);
                                    if (!oResult.IsSuccess)
                                    {
                                        oErrBuilder.Append("Company : " + oResult.ErrMsg + "/n");
                                    }
                                }

                                // Import company branch
                                oResult = new CResult();
                                CCompanyBranchBO oCompanyBranchBO = new CCompanyBranchBO();
                                foreach (CCompanyBranch oCompanyBranch in oListCompanyBranch)
                                {
                                    oResult = oCompanyBranchBO.Import(oCompanyBranch);
                                    if (!oResult.IsSuccess)
                                    {
                                        oErrBuilder.Append("Company Branch: " + oResult.ErrMsg + "/n");
                                    }
                                }

                                //Company Vs CompanyBranch
                                oResult = new CResult();
                                CCVBBO oCVBBO = new CCVBBO();
                                foreach (CCVB oCVB in oListCVB)
                                {
                                    oResult = oCVBBO.Import(oCVB);
                                    if (!oResult.IsSuccess)
                                    {
                                        oErrBuilder.Append("Company Vs CompanyBranch : " + oResult.ErrMsg + "/n");
                                    }
                                }

                                // Import Location
                                oResult = new CResult();
                                CLocBO oLocBO = new CLocBO();
                                foreach (CLocation oLocation in oListLocation)
                                {
                                    oResult = oLocBO.Import(oLocation);
                                    if (!oResult.IsSuccess)
                                    {
                                        oErrBuilder.Append("Inventory location: " + oResult.ErrMsg + "/n");
                                    }
                                }

                                // Import CompanyBranch Vs Location
                                oResult = new CResult();
                                foreach (CCVB oCVB in oListBVL)
                                {
                                    oResult = oCVBBO.ImportBVL(oCVB);
                                    if (!oResult.IsSuccess)
                                    {
                                        oErrBuilder.Append("CompanyBranch Vs Location : " + oResult.ErrMsg + "/n");
                                    }
                                }

                                // Import Employee
                                oResult = new CResult();
                                CEmployeeBO oEmployeeBO = new CEmployeeBO();
                                foreach (CEmployee oEmployee in oListEmployee)
                                {
                                    oResult = oEmployeeBO.Import(oEmployee);
                                    if (!oResult.IsSuccess)
                                    {
                                        oErrBuilder.Append("Employee : " + oResult.ErrMsg + "/n");
                                    }
                                }

                                // Import User
                                oResult = new CResult();
                                CUserBO oUserBO = new CUserBO();
                                foreach (CUser oUser in oListUser)
                                {
                                    oResult = oUserBO.Import(oUser);
                                    if (!oResult.IsSuccess)
                                    {
                                        oErrBuilder.Append("User : " + oResult.ErrMsg + "/n");
                                    }
                                }

                                if (oErrBuilder.Length != 0)
                                {
                                    MessageBox.Show(oErrBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("Successfully Imported. ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            //
                            cryptoStream.Close();
                        }
                    }
                }
            }
        }
    }
}

