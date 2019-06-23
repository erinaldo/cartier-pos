using System;
using System.Collections.Generic;
using System.Text;
using ETL.Model;

namespace Model
{
    public class CParty:CBase
    {
        public string Party_OID { get; set; }
        public string Party_Branch { get; set; }
        public string Party_Name { get; set; }
        public string Party_Address { get; set; }
        public string Party_City { get; set; }
        public string Party_Country { get; set; }
        public string Party_Phone { get; set; }
        public string Party_Mobile { get; set; }
        public string Party_Email { get; set; }
        public string Party_ContactPerson1 { get; set; }
        public string Party_Phone1 { get; set; }
        public string Party_Contactperson2 { get; set; }
        public string Party_Phone2 { get; set; }

        public CParty()
        {
            this.Party_OID = string.Empty;
            this.Party_Branch = string.Empty;
            this.Party_Name = string.Empty;
            this.Party_Address = string.Empty;
            this.Party_City = string.Empty;
            this.Party_Country = string.Empty;
            this.Party_Phone = string.Empty;
            this.Party_Mobile = string.Empty;
            this.Party_Email = string.Empty;
            this.Party_ContactPerson1 = string.Empty;
            this.Party_Phone1 = string.Empty;
            this.Party_Contactperson2 = string.Empty;
            this.Party_Phone2 = string.Empty;
        }
    }
}
