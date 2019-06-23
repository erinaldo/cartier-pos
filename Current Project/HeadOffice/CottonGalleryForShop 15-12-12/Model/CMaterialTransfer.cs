using System;
using System.Collections.Generic;
using System.Text;

namespace ETL
{
    namespace Model
    {
        public enum EWOStatus
        {
            OPEN = 0,
            INPROCESS = 1,
            CLOSE = 2
        }

        [Serializable]
        public class CMaterialTransfer
        {
                #region "Constructor"
           /// <summary>
           /// Default constructor
           /// </summary>
            public CMaterialTransfer()
           {
               m_sMTID = string.Empty;
               m_fOQTY = 0.00f;
               m_fFQTY = 0.00f;
               m_sISWO=string.Empty;
               m_sISWO1=string.Empty;
           }

            #endregion

           #region "Member variables"

           protected string m_sMTID;
           protected DateTime m_dtEffectiveDate;
           protected float m_fOQTY;
           protected float m_fFQTY;
           protected EWOStatus m_eLineStatus;
           protected float m_fRQTY;
           protected DateTime m_dtRDate;
           protected DateTime m_dtAEDate;
           protected string m_sISWO;
           protected string m_sISWO1;
            protected string m_sISWO2;

           #endregion

           #region "Properties"


            public string MTID
            {
                get { return m_sMTID; }
                set { m_sMTID = value; }
            }
         
            public string ItemCode
            {
                get { return m_sISWO2; }
                set { m_sISWO2 = value; }
            }
           public string SourceLoc
           {
               get { return m_sISWO; }
               set { m_sISWO = value; }
           }
              public string ProdLine
           {
               get { return m_sISWO1; }
               set { m_sISWO1 = value; }
           }
 
           public float PQTY
           {
               get { return m_fOQTY; }
               set { m_fOQTY = value; }
           }
           public float IQTY
           {
               get { return m_fFQTY; }
               set { m_fFQTY = value; }
           }

                 
           #endregion
        }
    }
}
