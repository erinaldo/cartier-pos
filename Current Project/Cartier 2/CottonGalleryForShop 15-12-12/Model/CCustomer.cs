using System;
namespace ETL
{
    namespace Model
    {
        public enum ECSType
        {
            CUSTOMER=0,
            SUPPLIER=1
        }

        [Serializable]
        public class CCustomer : CBase
        {
            #region "Properties"

            public string Cust_OId { get; set; }
            public string Cust_Branch { get; set; }
            
            public string Cust_Id { get; set; }
            public string Cust_Name { get; set; }
            public ECSType Cust_CSType { get; set; }
            public string Cust_ContactP { get; set; }
            public string Cust_Address { get; set; }
            public string Cust_Cell { get; set; }
            public string Cust_Phone { get; set; }
            public string Cust_Email { get; set; }
            public string Cust_Fax { get; set; }
            public string Cust_Web { get; set; }
            public string Cust_IsActive { get; set; }
            public float Cust_DiscRate { get; set; }

            #endregion

            #region "constructor"

            /// <summary>
            /// Default constructor.
            /// </summary>
            public CCustomer()
            {
                this.Cust_OId = string.Empty;
                this.Cust_Branch = string.Empty;
                this.Cust_Id = string.Empty;
                this.Cust_Name = string.Empty;
                this.Cust_CSType = ECSType.CUSTOMER;
                this.Cust_ContactP = string.Empty;
                this.Cust_Address = string.Empty;
                this.Cust_Cell = string.Empty;
                this.Cust_Email = string.Empty;
                this.Cust_Fax = string.Empty;
                this.Cust_Web = string.Empty;
                this.Cust_IsActive = "N";
                this.Cust_DiscRate = 0.00f;
            }

            #endregion

        }
    }
}