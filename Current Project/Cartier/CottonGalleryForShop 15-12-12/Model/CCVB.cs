using System;

namespace ETL
{
    namespace Model
    {
        [Serializable]
        public class CCVB
        {

            #region "Constructor"
            public CCVB()
            {
                OID = string.Empty;
               
                Comp_OID = string.Empty;
                Company = string.Empty;
                Bran_OID = string.Empty;
                Branch = string.Empty;
                Loc_OID = string.Empty;
                Location = string.Empty;
                Remarks = string.Empty;



            }
            #endregion




            #region "Properties"
            public string OID { get; set; }
            public string Comp_OID { get; set; }
            public string Company { get; set; }
            public string Bran_OID { get; set; }
            public string Branch { get; set; }
            public string Loc_OID { get; set; }
            public string Location { get; set; }
            public string Remarks { get; set; }


            #endregion






        }
    }
}