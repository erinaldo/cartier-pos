
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Model;


namespace ETL
{
    namespace Model
    {[Serializable]
      public class CSOMaster:CBase
        {
          public string SOMstr_OID { get; set; }
          public string SOMstr_Branch { get; set; }
          public string SOMstr_Code { get; set; }
          public DateTime SOMstr_Date { get; set; }
          
          public string SOMstr_By { get; set; }
          public string SOMstr_CustomerID { get; set; }
          public float SOMstr_TotalAmt { get; set; }
          public float SOMstr_DiscAmt { get; set; }
          public float SOMstr_NetAmt { get; set; }

          public string SOMstr_FinalDest { get; set; }
          public string SOMstr_TransportType { get; set; }
          public string SOMstr_TransportNo { get; set; }
          
          public string SOMstr_VatClnNo { get; set; }
          public DateTime SOMstr_VatDate { get; set; }
          
          public DateTime SOMstr_PricingDate { get; set; }
          
          public List<CSODetails> SOMstr_DetailsList { get; set; }
          public CSODetails SOMstr_DtailList { get; set; }
          public List<CReturnItem> oReturnItemsList { get; set; }
          public string PaymentType { get; set; }
          public string CardType { get; set; }
          public string SalesMan { get; set; }

          public string ExportedToBrnOID { get; set; }
          public float TotalReturn { get; set; }
         
          public CSOMaster()
          {
               SOMstr_OID = string.Empty;
               SOMstr_Branch = string.Empty;
               SOMstr_Code = string.Empty;
               SOMstr_Date = DateTime.Now.Date;
               SOMstr_By = string.Empty;
               SOMstr_CustomerID = string.Empty;
               SOMstr_TotalAmt = 0.00f;
               SOMstr_DiscAmt = 0.00f;
               SOMstr_NetAmt = 0.00f;

               SOMstr_FinalDest = string.Empty;
               SOMstr_TransportType = string.Empty;
               SOMstr_TransportNo = string.Empty;
          
               SOMstr_VatClnNo = string.Empty;
               SOMstr_VatDate = DateTime.Now.Date;

               SOMstr_PricingDate = DateTime.Now.Date;

               SOMstr_DetailsList = new List<CSODetails>();

               ExportedToBrnOID = string.Empty;
               TotalReturn = 0.0f;
          }
        }
    }
}
