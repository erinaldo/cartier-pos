/* File Name		: CResult.cs
 * Author			: Tanvir
 * Creation Date	: 29-09-07
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


namespace ETL
{
    namespace Common
    {
        public class CResult
        {
            /// <summary>
            /// Default Constructor
            /// </summary>
            public CResult()
            {
                m_bIsSuccess = false;
                m_sErrMsg = string.Empty;
                m_oData = null;
                m_sSuccMsg = string.Empty;
                m_sPK = string.Empty;
            }

            #region "member variables"

            protected bool m_bIsSuccess;
            protected string m_sErrMsg;
            protected object m_oData;
            protected string m_sSuccMsg;
            protected string m_sPK;

            #endregion

            #region "Properties"
           
            public bool IsSuccess
            {
                get { return m_bIsSuccess; }
                set { m_bIsSuccess = value; }
            }
            
            public string ErrMsg
            {
                get { return m_sErrMsg; }
                set { m_sErrMsg = value; }
            }

            public object Data
            {
                get { return m_oData; }
                set { m_oData = value; }
            }

            public string SuccMsg
            {
                get { return m_sSuccMsg; }
                set { m_sSuccMsg = value; }
            }

            public string PK
            {
                get { return m_sPK; }
                set { m_sPK = value; }
            }

            #endregion

        }
    }
}
