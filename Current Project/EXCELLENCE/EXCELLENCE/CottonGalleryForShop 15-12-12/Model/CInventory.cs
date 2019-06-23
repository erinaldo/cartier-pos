using System;
using System.Collections.Generic;
using System.Text;


namespace ETL
{
    namespace Model
    {
        [Serializable]
        public class CInventory : CBase
        {
            public string Invt_OID { get; set; }
            public string Invt_Branch { get; set; }
            public string Invt_ItemOID { get; set; }
            public string Invt_ItemName { get; set; }
            public float Invt_QTY { get; set; }
            public int Invt_InvType { get; set; }
            public string Invt_BranchOID { get; set; }
            public string Invt_LocOID { get; set; }
            
            public CInventory()
            {
                Invt_OID = string.Empty;
                Invt_Branch = string.Empty;
                Invt_ItemOID = string.Empty;
                Invt_ItemName = string.Empty;
                Invt_QTY = 0.00f;
                Invt_InvType = -1;
                Invt_BranchOID = string.Empty;
                Invt_LocOID = string.Empty;
           }
        }
    }
}