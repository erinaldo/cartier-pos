using System;
using System.Collections.Generic;
using System.Text;
using ETL.Model;

namespace Model
{
    public class CPurchase:CBase
    {
        public string Purchase_OID { get; set; }
        public string Purchase_Branch { get; set; }
        public string Purchase_PartyOID { get; set; }
        public string Purchase_PartyName { get; set; }
        public string Purchase_GroupID { get; set; }
        public string Purchase_GroupName { get; set; }
        public string Purchase_Description { get; set; }
        public float Purchase_Quantity { get; set; }
        public float Purchase_Amount { get; set; }
        public string Purchase_CurrencyOID { get; set; }
        public string Purchase_CurrencyName { get; set; }
        public float Purchase_CurrencyRate { get; set; }
        public string Purchase_Invoice { get; set; }
        public DateTime Purchase_Date { get; set; }
        public int Purchase_Status { get; set; }
        public string Purchase_Creator { get; set; }
        public DateTime Purchase_CreationDate { get; set; }
        public string Purchase_UpdateBy { get; set; }
        public DateTime Purchase_UpdateDate { get; set; }

        public CPurchase()
        {
            Purchase_OID = string.Empty;
            Purchase_Branch = string.Empty;
            Purchase_PartyOID = string.Empty;
            Purchase_PartyName = string.Empty;
            Purchase_GroupID = string.Empty;
            Purchase_GroupName = string.Empty;
            Purchase_Description = string.Empty;
            Purchase_Quantity = 0.00f;
            Purchase_Amount = 0.00f;
            Purchase_CurrencyOID = string.Empty;
            Purchase_CurrencyName = string.Empty;
            Purchase_CurrencyRate = 0.00f;
            Purchase_Invoice = string.Empty;
            Purchase_Date = DateTime.Now.Date;
            Purchase_Status = 1;
            Purchase_Creator = string.Empty;
            Purchase_CreationDate = DateTime.Now.Date;
            Purchase_UpdateBy = string.Empty;
            Purchase_UpdateDate = DateTime.Now.Date;
        }
    }
}
