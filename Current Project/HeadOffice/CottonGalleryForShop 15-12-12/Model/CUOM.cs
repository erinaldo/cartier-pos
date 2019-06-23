/* File Name		: CUOM.cs
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
       public  class CUOM:CBase
        {
           public string UOM_OID{get;set;}
           public string UOM_Code { get; set; }
           public string UOM_Name { get; set; }
           public string UOM_Branch { get; set; }

            #region "Constructor"
           /// <summary>
           /// Default constructor
           /// </summary>
           public CUOM()
           {
               UOM_OID=string.Empty;
               UOM_Code =string.Empty;
               UOM_Name=string.Empty;
               UOM_Branch=string.Empty;
           }
            #endregion
        }
    }
}
