using System;
namespace ETL
{
namespace Model
{
    [Serializable]
   public class CReorderLevel
    {
        
       #region "Constructor"
       public CReorderLevel()
       {
           OID = string.Empty;
           Branch_ID = string.Empty;
           Branch_Name = string.Empty;
           Item_ID = string.Empty;
           Item_Name = string.Empty;
           Location_ID = string.Empty;
           Location_Name = string.Empty;
           Quantity = string.Empty;
           Remarks = string.Empty;
       
       
       
       }
        #endregion




        #region "Properties"
       public string OID { get; set; }
       public string Branch_ID { get; set; }
       public string Branch_Name { get; set; }
       public string Item_Name { get; set; }
       public string Item_ID { get; set; }
       
       public string Location_Name { get; set; }
       public string Location_ID { get; set; }

       public string Quantity { get; set; }
       public string Remarks { get; set; }
       

        #endregion


    }
}
}