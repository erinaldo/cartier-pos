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
    public partial class frmMasterExport : BaseForm
    {
        public frmMasterExport()
        {
            InitializeComponent();
            this.ExportData();
        }

        private void ExportData()
        {
            string m_sMasterExportFileName = DateTime.Now.ToString("dd-MMM-yyyy") + "_" + currentBranch.CompBrn_Name;
            saveFileDialog1.FileName = m_sMasterExportFileName;
            saveFileDialog1.InitialDirectory = @"H:\";
            saveFileDialog1.Filter = "Master File (*.mstrexp)|*.mstrexp";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                m_sMasterExportFileName = saveFileDialog1.FileName;

                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(m_sMasterExportFileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    byte[] baKey = { 51, 208, 75, 59, 223, 134, 241, 155, 170, 229, 177, 160, 246, 71, 77, 141, 66, 7, 223, 103, 97, 80, 235, 82, 94, 107, 226, 190, 76, 94, 31, 43 };
                    byte[] baIV = { 142, 96, 41, 14, 206, 132, 173, 19, 12, 50, 124, 121, 42, 27, 35, 9 };
                    Rijndael rijndael = Rijndael.Create();
                    CryptoStream cryptoStream = new CryptoStream(stream, rijndael.CreateEncryptor(baKey, baIV), CryptoStreamMode.Write);
                    //

                    {
                        CResult oResult;
                        
                        // UOM
                        oResult = new CResult();
                        CUOMBO oUOMBO = new CUOMBO();
                        oResult = oUOMBO.ReadAll();
                        if (oResult.IsSuccess)
                        {
                            ArrayList oListUOM = (ArrayList)oResult.Data;
                            formatter.Serialize(cryptoStream, oListUOM);
                        }                        
                        // Item Type
                        oResult = new CResult();
                        CItemBO oItemBO = new CItemBO();
                        oResult = oItemBO.ReadAll(new CItemType());
                        if (oResult.IsSuccess)
                        {
                            ArrayList oListItemType = (ArrayList)oResult.Data;
                            formatter.Serialize(cryptoStream, oListItemType);
                        }
                        // Item Group
                        oResult = new CResult();
                        oItemBO = new CItemBO();
                        oResult = oItemBO.ReadAll(new CItemGroup());
                        if (oResult.IsSuccess)
                        {
                            ArrayList oListItemGroup = (ArrayList)oResult.Data;
                            formatter.Serialize(cryptoStream, oListItemGroup);
                        }
                        // Item
                        oResult = new CResult();
                        oItemBO = new CItemBO();
                        oResult = oItemBO.ReadAll();
                        if (oResult.IsSuccess)
                        {
                            ArrayList oListItem = (ArrayList)oResult.Data;
                            formatter.Serialize(cryptoStream, oListItem);
                        }
                        // Reorder Level
                        oResult = new CResult();
                        CReorderLevelBO oReorderLevelBO = new CReorderLevelBO();
                        oResult = oReorderLevelBO.ReadAllReorderLevelData(new CReorderLevel());
                        if (oResult.IsSuccess)
                        {
                            ArrayList oListReorderLevel = (ArrayList)oResult.Data;
                            formatter.Serialize(cryptoStream, oListReorderLevel);
                        }
                        // Currency
                        oResult = new CResult();
                        CCurrencyBO oCurrencyBO = new CCurrencyBO();
                        oResult = oCurrencyBO.ReadAll();
                        if (oResult.IsSuccess)
                        {
                            List<CCurrency> oListCurrency = (List<CCurrency>)oResult.Data;
                            formatter.Serialize(cryptoStream, oListCurrency);
                        }
                        // Price Master
                        oResult = new CResult();
                        CPriceMasterBO oPriceMasterBO = new CPriceMasterBO();
                        oResult = oPriceMasterBO.ReadAll();
                        if (oResult.IsSuccess)
                        {
                            ArrayList oListPriceMaster = (ArrayList)oResult.Data;
                            formatter.Serialize(cryptoStream, oListPriceMaster);
                        }
                        // Customer
                        oResult = new CResult();
                        CCustomerBO oCustomerBO = new CCustomerBO();
                        oResult = oCustomerBO.ReadAll(new CCustomer());
                        if (oResult.IsSuccess)
                        {
                            ArrayList oListCustomer = (ArrayList)oResult.Data;
                            formatter.Serialize(cryptoStream, oListCustomer);
                        }
                        // Supplier
                        oResult = new CResult();
                        CSupplierBO oSupplierBO = new CSupplierBO();
                        oResult = oSupplierBO.ReadAll(new CSupplier());
                        if (oResult.IsSuccess)
                        {
                            ArrayList oListSupplier = (ArrayList)oResult.Data;
                            formatter.Serialize(cryptoStream, oListSupplier);
                        }
                        // Company
                        oResult = new CResult();
                        CCompanyBO oCompanyBO = new CCompanyBO();
                        oResult = oCompanyBO.ReadAll();
                        if (oResult.IsSuccess)
                        {
                            List<CCompany> oListCompany = (List<CCompany>)oResult.Data;
                            formatter.Serialize(cryptoStream, oListCompany);
                        }
                        // Company Branch
                        oResult = new CResult();
                        CCompanyBranchBO oCompanyBranchBO = new CCompanyBranchBO();
                        oResult = oCompanyBranchBO.ReadAll();
                        if (oResult.IsSuccess)
                        {
                            List<CCompanyBranch> oListCompanyBranch = (List<CCompanyBranch>)oResult.Data;
                            formatter.Serialize(cryptoStream, oListCompanyBranch);
                        }
                        // Company Vs CompanyBranch
                        oResult = new CResult();
                        CCVBBO oCVBBO = new CCVBBO();
                        oResult = oCVBBO.ReadAllCVB(new CCVB());
                        if (oResult.IsSuccess)
                        {
                            ArrayList oListCVB = (ArrayList)oResult.Data;
                            formatter.Serialize(cryptoStream, oListCVB);
                        }
                        // Inventory Location
                        oResult = new CResult();
                        CLocBO oLocBO = new CLocBO();
                        oResult = oLocBO.ReadAll();
                        if (oResult.IsSuccess)
                        {
                            ArrayList oListLocation = (ArrayList)oResult.Data;
                            formatter.Serialize(cryptoStream, oListLocation);
                        }
                        // CompanyBranch Vs Location
                        oResult = new CResult();
                        oCVBBO = new CCVBBO();
                        oResult = oCVBBO.ReadAllBVL(new CCVB());
                        if (oResult.IsSuccess)
                        {
                            ArrayList oListCVB = (ArrayList)oResult.Data;
                            formatter.Serialize(cryptoStream, oListCVB);
                        }
                        // Employee
                        oResult = new CResult();
                        CEmployeeBO oEmployeeBO = new CEmployeeBO();
                        oResult = oEmployeeBO.ReadAllEmployee(new CEmployee());
                        if (oResult.IsSuccess)
                        {
                            ArrayList oListEmployee = (ArrayList)oResult.Data;
                            formatter.Serialize(cryptoStream, oListEmployee);
                        }
                        // User
                        oResult = new CResult();
                        CUserBO oUserBO = new CUserBO();
                        oResult = oUserBO.ReadAllUserData(new CUser());
                        if (oResult.IsSuccess)
                        {
                            ArrayList oListUser = (ArrayList)oResult.Data;
                            formatter.Serialize(cryptoStream, oListUser);
                        }
                    }                    
                    //
                    cryptoStream.Close();
                }
            }
            this.Close();
        }
    }
}
