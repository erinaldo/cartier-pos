using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace deletevat.Model
{
   public class CGoodsReceiveDetails
    {
        public string GRDet_OID { get; set; }
        public string GRDet_Branch { get; set; }
        public string GRDet_MStrOID { get; set; }
        public string GRDet_ItemOID { get; set; }
        public float GRDet_QTY { get; set; }
        public string GRDet_UOM { get; set; }
        public string GRDet_BranchOID { get; set; }
        public string GRDet_LocOID { get; set; }
        public int GRDet_InvType { get; set; }
        public float GRDet_Price { get; set; }
        public string GRDet_Currency { get; set; }
        public float GRDet_Amount { get; set; }

        public CGoodsReceiveDetails()
        {
            GRDet_OID = string.Empty;
            GRDet_Branch = string.Empty;
            GRDet_MStrOID = string.Empty;
            GRDet_ItemOID = string.Empty;
            GRDet_QTY = 0.00f;
            GRDet_UOM = string.Empty;
            GRDet_BranchOID = string.Empty;
            GRDet_LocOID = string.Empty;
            GRDet_InvType = -1;
            GRDet_Price = 0.00f;
            GRDet_Currency = string.Empty;
            GRDet_Amount = 0.00f;
        }
    }
}
