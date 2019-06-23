using System;
using System.Collections.Generic;
using System.Text;
using ETL.Model;

namespace Model
{
    [Serializable]
   public  class CMemberShip:CBase
    {
        public string ID { get; set; }
        public string MembershipID { get; set; }
        public string Branch { get; set; }
        public string MemberName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Fromdate { get; set; }
        public DateTime Todate { get; set; }
        public string Address { get; set; }
        public string Area { get; set; }
        public string PostCode { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Occupation { get; set; }
        public int FamilyMember { get; set; }
        public int IsActiveMenber { get; set; }
        public float Member_DiscountAmount { get; set; }

        public CMemberShip()
        {
            ID = string.Empty;
            MembershipID = string.Empty;
            Branch = string.Empty;
            MemberName = string.Empty;
            DateOfBirth = DateTime.Now;
            Fromdate = DateTime.Now;
            Todate = DateTime.Now;
            Address = string.Empty;
            Area = string.Empty;
            PostCode = string.Empty;
            Phone=string.Empty;
            Mobile=string.Empty;
            Email=string.Empty;
            Occupation=string.Empty;
            FamilyMember=0;
            IsActiveMenber = -1;
            Member_DiscountAmount = 0.00f;
        }
    }
}
