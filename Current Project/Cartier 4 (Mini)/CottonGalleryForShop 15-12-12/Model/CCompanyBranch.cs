using System;

namespace ETL
{
    namespace Model
    {
        [Serializable]
        public class CCompanyBranch : CBase
        {
            #region "Properties"

            public string CompBrn_OId { get; set; }
            public string CompBrn_Branch { get; set; }
            public string CompBrn_Code { get; set; }
            public string CompBrn_TIN { get; set; }
            public string CompBrn_Name { get; set; }

            public string CompBrn_FullName { get; set; }
            public string CompBrn_Street { get; set; }
            public string CompBrn_Road { get; set; }
            public string CompBrn_City { get; set; }
            public string CompBrn_Country { get; set; }
            public string CompBrn_Phone { get; set; }
            public string CompBrn_Mobile { get; set; }
            public string CompBrn_Email { get; set; }
            public string CompBrn_Web { get; set; }
            public string CompBrn_PostalCode { get; set; }
            public string CompBrn_IsHeadoffice { get; set; }

            #endregion

            #region "Consturctor"
            /// <summary>
            /// Default consturctor
            /// </summary>
            public CCompanyBranch()
            {
                this.CompBrn_OId = string.Empty;
                this.CompBrn_Branch = string.Empty;
                this.CompBrn_Code = string.Empty;
                this.CompBrn_Name = string.Empty;
                this.CompBrn_TIN = string.Empty;
                this.CompBrn_FullName = string.Empty;
                this.CompBrn_Street = string.Empty;
                this.CompBrn_Road = string.Empty;
                this.CompBrn_City = string.Empty;
                this.CompBrn_Country = string.Empty;
                this.CompBrn_Phone = string.Empty;
                this.CompBrn_Mobile = string.Empty;
                this.CompBrn_Email = string.Empty;
                this.CompBrn_Web = string.Empty;
                this.CompBrn_PostalCode = string.Empty;
                this.CompBrn_IsHeadoffice = string.Empty;
            }
            #endregion
        }
    }
}
