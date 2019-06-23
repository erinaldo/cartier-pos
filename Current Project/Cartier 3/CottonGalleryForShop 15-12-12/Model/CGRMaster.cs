
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;


namespace ETL
{
    namespace Model
    {
        public enum EGRType
        {
            WithDO = 0,
            OpeningBalance = 1,
            Others = 2,
            Return =3
        }

        [Serializable]
        public class CGRMaster:CBase
        {
          public string GRMstr_OID { get; set; }
          public string GRMstr_Branch { get; set; }
          public string GRMstr_Code { get; set; }
          public DateTime GRMstr_Date { get; set; }
          public int GRMstr_Type { get; set; }

          public string GRMstr_By { get; set; }
          public string GRMstr_RefBy { get; set; }
          public string GRMstr_VendorID { get; set; }
          public float GRMstr_TotalAmt { get; set; }
          public int GRMstr_IsImported { get; set; }
          public List<CGRDetails> GRMstr_DetailsList { get; set; }
         
          public CGRMaster()
          {
               GRMstr_OID = string.Empty;
               GRMstr_Branch = string.Empty;
               GRMstr_Code = string.Empty;
               GRMstr_Date = DateTime.Now.Date;
               GRMstr_Type = -1;
               GRMstr_By = string.Empty;
               GRMstr_RefBy = string.Empty;
               GRMstr_VendorID = string.Empty;
               GRMstr_TotalAmt = 0.00f;
               GRMstr_IsImported = -1;
               GRMstr_DetailsList = new List<CGRDetails>();
          }
        }
    }
}
