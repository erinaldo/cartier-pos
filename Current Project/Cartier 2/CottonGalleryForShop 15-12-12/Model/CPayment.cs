using System;
using System.Collections.Generic;
using System.Text;
using ETL.Model;

namespace Model
{
    public class CPayment:CBase
    {
        public string Payment_OID { get; set; }
        public string Payment_Branch { get; set; }
        public DateTime Payment_Date { get; set; }
        public string Payment_PartyOID { get; set; }
        public string Payment_PartyName { get; set; }
        public float Payment_Amount { get; set; }
        public string Payment_CurrencyOID { get; set; }
        public string Payment_CurrencyName { get; set; }
        public float Payment_CurrencyRate { get; set; }
        public float Payment_BDT { get; set; }
        public string Payment_Media { get; set; }
        public int Payment_RecieptConfirmation { get; set; }
        public DateTime Payment_ReceivedDate { get; set; }
        public string Payment_Creator { get; set; }
        public DateTime Payment_CreationDate { get; set; }
        public string Payment_UpdateBy { get; set; }
        public DateTime Payment_UpdateDate { get; set; }

        public CPayment()
        {
            Payment_OID = string.Empty;
            Payment_Branch = string.Empty;
            Payment_Date = DateTime.Now.Date;
            Payment_OID = string.Empty;
            Payment_PartyName = string.Empty;
            Payment_Amount = 0.00f;
            Payment_CurrencyOID = string.Empty;
            Payment_CurrencyName = string.Empty;
            Payment_CurrencyRate = 0.00f;
            Payment_BDT = 0.00f;
            Payment_Media = string.Empty;
            Payment_RecieptConfirmation = 1;
            Payment_ReceivedDate = DateTime.Now.Date;
            Payment_Creator = string.Empty;
            Payment_CreationDate = DateTime.Now.Date;
            Payment_UpdateBy = string.Empty;
            Payment_UpdateDate = DateTime.Now.Date;

        }
        
    }
}
