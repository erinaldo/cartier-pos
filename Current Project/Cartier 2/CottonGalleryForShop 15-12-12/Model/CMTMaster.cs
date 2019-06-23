using System;
using System.Collections.Generic;
using System.Text;

namespace ETL
{
    namespace Model
    {
        public enum EMTStatus
        {
            OPEN = 0,
            INPROCESS = 1,
            CLOSE = 2
        }
        public enum EInvType
        {
            GOOD = 0,
            DAMAGE = 1,
            SHORTAGE = 2
        }

        [Serializable]
        public class CMTMaster:CBase
        {
                #region "Constructor"
           /// <summary>
           /// Default constructor
           /// </summary>
            public CMTMaster()
            {
                MTMstr_OID = string.Empty;
                MTMstr_Code = string.Empty;
                MTMstr_DOrder = string.Empty;
                MTMstr_Branch = string.Empty;
                MTMstr_Date = DateTime.Now.Date;
                MTMstr_DetailsList=new List<CMTDetails>();
            }

            #endregion

            public string MTMstr_OID { get; set; }
            public string MTMstr_Code { get; set; }
            public DateTime MTMstr_Date { get; set; }
            public string MTMstr_DOrder { get; set; }
            public string MTMstr_Branch { get; set; }
            public List<CMTDetails> MTMstr_DetailsList { get; set; }
        }
    }
}
