using System;
namespace ETL
{
namespace Model
{
    [Serializable]
   public class CUserAndBranch
    {
        

        #region "Constructor"
       public CUserAndBranch()
       {
           User = null;
           Branch = null;
       }
        #endregion


        #region "Properties"
       public CUser User { get; set; }
       public CCompanyBranch Branch { get; set; }

        #endregion


    }
}
}