using System;

namespace ETL
{
    namespace Model
    {
        [Serializable]
        public class CCompany : CBase
        {
            #region "Properties"

            public string Comp_OId { get; set; }
            public string Comp_Branch { get; set; }
            public string Comp_Code { get; set; }
            public string Comp_Name { get; set; }

            public string Comp_FullName { get; set; }
            public string Comp_Street { get; set; }
            public string Comp_Road { get; set; }
            public string Comp_City { get; set; }
            public string Comp_Country { get; set; }
            public string Comp_Phone { get; set; }
            public string Comp_Mobile { get; set; }
            public string Comp_Email { get; set; }
            public string Comp_Web { get; set; }
            public string Comp_PostalCode { get; set; }

            #endregion

            #region "Consturctor"
            /// <summary>
            /// Default consturctor
            /// </summary>
            public CCompany()
            {
                this.Comp_OId = string.Empty;
                this.Comp_Branch = string.Empty;
                this.Comp_Code = string.Empty;
                this.Comp_Name = string.Empty;

                this.Comp_FullName = string.Empty;
                this.Comp_Street = string.Empty;
                this.Comp_Road = string.Empty;
                this.Comp_City = string.Empty;
                this.Comp_Country = string.Empty;
                this.Comp_Phone = string.Empty;
                this.Comp_Mobile = string.Empty;
                this.Comp_Email = string.Empty;
                this.Comp_Web = string.Empty;
                this.Comp_PostalCode = string.Empty;
            }
            #endregion
        }
    }
}
