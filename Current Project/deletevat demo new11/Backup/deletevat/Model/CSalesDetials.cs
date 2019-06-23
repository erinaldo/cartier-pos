using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace deletevat.Model
{
    public class CSalesDetials
    {
            public string SODet_OID { get; set; }
            public string SODet_Branch { get; set; }
            public string SODet_MStrOID { get; set; }
            
            public string SODet_ItemSLNum { get; set; }
            public string SODet_ItemOID { get; set; }
            public string SODet_ItemName { get; set; }
            public float SODet_QTY { get; set; }
            public string SODet_UOM { get; set; }
            public float SODet_Price { get; set; }
            public string SODet_Currency { get; set; }
            public float SODet_Amount { get; set; }

            public float SODet_SDValue { get; set; }
            public float SODet_SDAmount { get; set; }
            public float SODet_VATValue { get; set; }
            public float SODet_VATAmount { get; set; }

            public float SODet_Discount { get; set; }
            public float SODet_NetAmount { get; set; }
            
            public string SODet_BranchOID { get; set; }            
            public string SODet_LocOID { get; set; }
            public float Chrom { get; set; }
            public string Rec_OID { get; set; }

            public CSalesDetials()
            {
               SODet_OID = string.Empty;
               SODet_Branch = string.Empty;
               SODet_MStrOID = string.Empty;
               SODet_ItemSLNum = string.Empty;
               SODet_ItemOID = string.Empty;
               SODet_ItemName = string.Empty;
               SODet_QTY = 0.00f;
               SODet_UOM = string.Empty;
               SODet_Price = 0.00f;
               SODet_Currency = string.Empty;
               SODet_Amount = 0.00f;

               SODet_SDValue = 0.00f;
               SODet_SDAmount = 0.00f;
               SODet_VATValue = 0.00f;
               SODet_VATAmount = 0.00f;

               SODet_Discount = 0.00f;
               SODet_NetAmount = 0.00f;
               Chrom = 0.00f;
               SODet_BranchOID = string.Empty;
               SODet_LocOID = string.Empty;
               Rec_OID = string.Empty;
           }
    }
}
