using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace deletevat.Model
{
    public class CSGoodsReceive
    {
        public string Rec_OID { get; set; }
        public string Rec_ReqID { get; set; }
        public string Rec_IssueID { get; set; }
        public string Rec_BranchID { get; set; }
        public string Rec_ProductID { get; set; }

        public int Rec_WantedQTY { get; set; }
        public int Rec_IssueQTY { get; set; }
        public string Rec_Remark { get; set; }
        public int Rec_ReceivedQty { get; set; }
        public string Item_Name { get; set; }
       // public List<CGRDetails> GRMstr_DetailsList { get; set; }

        public CSGoodsReceive()
        {
            Rec_OID = string.Empty;
            Rec_ReqID = string.Empty;
            Rec_IssueID = string.Empty;
            Rec_BranchID = string.Empty;
            Rec_ProductID = string.Empty;
            Rec_WantedQTY = 0;
            Rec_IssueQTY = 0;
            Rec_Remark = string.Empty;
            Rec_ReceivedQty = 0;
            Item_Name = string.Empty;

        }
    }
}
