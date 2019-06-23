using System;
using System.Collections.Generic;
using System.Text;

namespace ETL
{
    namespace Model
    {
        [Serializable]
        public class CMTDetails
        {
                #region "Constructor"
           /// <summary>
           /// Default constructor
           /// </summary>
            public CMTDetails()
            {
                MTDtls_OID = string.Empty;
                MTDtls_Branch = string.Empty;
                MTDtls_MstrOID = string.Empty;
                MTDtls_ItemOID = string.Empty;
                MTDtls_IssQty = 0.00f;
                MTDtls_IssUOMOID = string.Empty;
                MTDtls_SBranOID = string.Empty;
                MTDtls_SrcLocOID = string.Empty;
                MTDtls_SrcInvTyp = -1;
                MTDtls_DBranOID = string.Empty;
                MTDtls_DestLocOID = string.Empty;
                MTDtls_DesInvtyp = -1;
                MTDtls_RQty = 0.00f;
                MTDtls_RUOMOID = string.Empty;
                MTDtls_Status = -1;
            }

            #endregion

            public string MTDtls_OID { get; set; }
            public string MTDtls_Branch { get; set; }
            public string MTDtls_MstrOID { get; set; }
            public string MTDtls_ItemOID { get; set; }
            public float MTDtls_IssQty { get; set; }
            public string MTDtls_IssUOMOID { get; set; }
            public string MTDtls_SBranOID { get; set; }
            public string MTDtls_SrcLocOID { get; set; }
            public int MTDtls_SrcInvTyp { get; set; }
            public string MTDtls_DBranOID { get; set; }
            public string MTDtls_DestLocOID { get; set; }
            public int MTDtls_DesInvtyp { get; set; }
            public float MTDtls_RQty { get; set; }
            public string MTDtls_RUOMOID { get; set; }
            public int MTDtls_Status { get; set; }
         
        }
    }
}
