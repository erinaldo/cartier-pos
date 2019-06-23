using System;
using System.Collections.Generic;
using System.Text;


namespace ETL
{
    namespace Model
    {
        [Serializable]
       public class CLocation
        {
           public string Loc_OID { get; set; }
           public string Loc_Branch { get; set; }
           public string Loc_Code { get; set; }
           public string Loc_Name { get; set; }

            #region "Constructor"
            /// <summary>
            /// Default consturctor
            /// </summary>
           public CLocation()
            {
               Loc_OID = string.Empty;
               Loc_Branch = string.Empty;
               Loc_Code = string.Empty;
               Loc_Name = string.Empty;
            }
            #endregion

        }
    }
}
