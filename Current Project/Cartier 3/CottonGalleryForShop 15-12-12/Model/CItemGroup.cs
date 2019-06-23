/* File Name		: CItemGroup.cs
 * Author			: sarwar
 * Creation Date	: 15-03-07
 * 
 * Modification History 
 * 
 * Author						Modification Date		Purpose
 * 
 * 
 * 
 * Copyright@ 2007 Epsilonn Technilogies Ltd.
 * 
 * */

using System;
using System.Collections.Generic;
using System.Text;


namespace ETL
{
    namespace Model
    {
        [Serializable]
        public class CItemGroup:CBase
        {
            public string Catg_OID { get; set; }
            public string Catg_Branch { get; set; }
            public string Catg_Code { get; set; }
            public string Catg_Name { get; set; }
           

            public CItemGroup()
            {
                Catg_OID = string.Empty;
                Catg_Branch = string.Empty;
                Catg_Code = string.Empty;
                Catg_Name = string.Empty;
            }
        }
    }
}
