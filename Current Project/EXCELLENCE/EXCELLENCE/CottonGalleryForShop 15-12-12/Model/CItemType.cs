/* File Name		: CItemType.cs
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
       public class CItemType:CBase
        {
           public string ITyp_OID {get;set; }
           public string ITyp_Code { get; set; }
           public string ITyp_Name { get; set; }
           public string ITyp_Branch { get; set; }

           public CItemType()
           {
               ITyp_OID = string.Empty;
               ITyp_Code = string.Empty;
               ITyp_Name = string.Empty;
               ITyp_Branch = string.Empty;
           }
        }
    }
}