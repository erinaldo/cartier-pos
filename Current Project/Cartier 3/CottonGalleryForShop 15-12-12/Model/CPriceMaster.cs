using System;
using System.Collections.Generic;
using System.Text;

namespace ETL
{
    namespace Model
    {
        [Serializable]
        public class CPriceMaster : CBase
        {
            #region "Properties"

            public string Price_OId { get; set; }
            public string Price_Branch { get; set; }

            public string Price_ItemOId { get; set; }
            public string Price_ItemName { get; set; }
            public DateTime Price_FromDate { get; set; }
            public DateTime Price_ToDate { get; set; }
            public string Price_Currency { get; set; }


            public float Price_FactoryPrice { get; set; }
            public float Price_ListPrice { get; set; }
            public float Price_VatPercent { get; set; }
            public float Price_VatPrice { get; set; }
            public float Price_Disc { get; set; }
            public float Price_DiscPrice { get; set; }



            #endregion

            #region "Constructor"
            /// <summary>
            /// Default constructor
            /// </summary>
            public CPriceMaster()
            {
                this.Price_OId = string.Empty;
                this.Price_Branch = string.Empty;

                this.Price_ItemOId = string.Empty;
                this.Price_ItemName = string.Empty;
                this.Price_FromDate = DateTime.Now.Date;
                this.Price_ToDate = DateTime.Now.Date;
                this.Price_Currency = string.Empty;

                this.Price_FactoryPrice = 0.00f;
                this.Price_ListPrice = 0.00f;
                this.Price_VatPercent = 0.00f;
                this.Price_VatPrice = 0.00f;
                this.Price_Disc = 0.00f;
                this.Price_DiscPrice = 0.00f;
            }
            #endregion
        }
    }
}
