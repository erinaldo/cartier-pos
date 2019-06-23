using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace ETL
{
    namespace Model
    {
        public class ReturnProduct : CBase
        {
            public string Ret_OID { get; set; }
            public string Ret_Branch { get; set; }
            public string Ret_ItemOID { get; set; }
            public string Ret_ItemName { get; set; }
            public float  Ret_QTY { get; set; }
            public int    Ret_InvType { get; set; }
            public string Ret_BranchOID { get; set; }
            public string Ret_LocOID { get; set; }
            public float Ret_DiscountAmount { get; set; }

            public ReturnProduct()
            {
                Ret_OID = string.Empty;
                Ret_Branch = string.Empty;
                Ret_ItemOID = string.Empty;
                Ret_ItemName = string.Empty;
                Ret_QTY = 0.00f;
                Ret_InvType = -1;
                Ret_BranchOID = string.Empty;
                Ret_LocOID = string.Empty;
                Ret_DiscountAmount = 0.00f;
           }
        }
    }
}
