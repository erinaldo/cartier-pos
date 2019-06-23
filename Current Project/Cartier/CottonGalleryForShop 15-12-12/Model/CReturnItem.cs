using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using ETL.Model;

namespace Model
{
    public class CReturnItem : CBase
    {
        public string Ret_OID { get; set; }
        public string ItemName { get; set; }
        public float Ret_QTY { get; set; }
        public float ItemPrice { get; set; }
        public DateTime date { get; set; }
        public string Ret_BranchOID { get; set; }
        public float Ret_DiscountAmount { get; set; }
        public CReturnItem()
        {
            Ret_OID = string.Empty;
            ItemName = string.Empty;
            Ret_QTY = 0.00f;
            ItemPrice = 0.00f;
            date = DateTime.Now.Date;
            Ret_BranchOID = string.Empty;
            Ret_DiscountAmount = 0.00f;

        }
        
    }
}
