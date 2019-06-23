/* File Name		: CItem.cs
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
using System.Collections;

namespace ETL
{
    namespace Model
    {
        [Serializable]
        public class CItem:CBase
        {

            public CItem()
            {
                Item_OID = string.Empty;
                Item_Branch = string.Empty;
                Item_Code = string.Empty;
                Item_GroupID = string.Empty;
                Item_TypeID = string.Empty;
                Item_IsRaw = string.Empty;
                Item_ItemName = string.Empty;
                Item_UOMID = string.Empty;
                Item_Sprice = 0.00f;
                Item_Pprice = 0.00f;
                Item_RQTY = 0.00f;
                ItemImage = null;
                InvQty = 0.00f;
            }

            public string Item_OID { get; set; }
            public string Item_Branch { get; set; }
            public string Item_Code { get; set; }
            public string Item_GroupID { get; set; }
            public string Item_TypeID { get; set; }
            public string Item_IsRaw { get; set; }
            public string Item_ItemName { get; set; }
            public string Item_UOMID { get; set; }
            public float Item_Sprice { get; set; }
            public float Item_Pprice { get; set; }
            public float Item_RQTY { get; set; }

            public int Item_Priority { get; set; }
            public float InvQty { get; set; }

            public byte[] ItemImage { get; set; }

        }
    }
}
