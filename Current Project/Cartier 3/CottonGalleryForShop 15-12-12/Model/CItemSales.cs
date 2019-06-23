
using System;

namespace ETL
{
    namespace Model
    {
        [Serializable]
        public class CItemSales:CBase
        {

            public CItemSales()
            {
                Item_OID = string.Empty;
                Item_Branch = string.Empty;
                Item_Code = string.Empty;
                Item_ItemName = string.Empty;
                Item_UOMOID = string.Empty;
                Item_GroupID = string.Empty;
                Item_TypeID = string.Empty;
                Item_Priority = -1;
                ItemImage = null;
                TotalItem = 0;
                Item_Price = 0.00f;
                Item_CurrencyOID = string.Empty;
                Item_ExistQTY = 0.00f;

                Item_PPrice = 0.00f;
            }

            public string Item_OID { get; set; }
            public string Item_Branch { get; set; }
            public string Item_Code { get; set; }
            public string Item_ItemName { get; set; }
            public string Item_UOMOID { get; set; }
            public string Item_GroupID { get; set; }
            public string Item_TypeID { get; set; }           
            public int Item_Priority { get; set; }
            public byte[] ItemImage { get; set; }
            public int TotalItem { get; set; }
            public float Item_Price { get; set; }
            public float Item_VatPercent { get; set; }
            public string Item_CurrencyOID { get; set; }
            public float Item_ExistQTY { get; set; }

            public float Item_PPrice { get; set; }
        }
    }
}
