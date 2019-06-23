/* File Name		: CGRDetails.cs
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
        public class CBase
        {

            #region "Constructor"

          public CBase()
          {
              m_sCreator = string.Empty;
              m_dtCreationDate = DateTime.MinValue;
              m_sUpdateBy = string.Empty;
              m_dtUpdateDate = DateTime.MinValue;
              m_sIsActive = string.Empty;
              m_sRemarks = string.Empty;
          }
            #endregion
          #region "Member variables"
          protected string m_sCreator;
          protected DateTime m_dtCreationDate;
          protected string m_sUpdateBy;
          protected DateTime m_dtUpdateDate;
          protected string m_sIsActive;
          protected string m_sRemarks;
          #endregion

          #region "Properties"
          public string Creator
          {
              get { return m_sCreator; }
              set { m_sCreator = value; }
          }

          public DateTime CreationDate
          {
              get { return m_dtCreationDate; }
              set { m_dtCreationDate = value; }
          }

          public string UpdateBy
          {
              get { return m_sUpdateBy; }
              set { m_sUpdateBy = value; }
          }

          public DateTime UpdateDate
          {
              get { return m_dtUpdateDate; }
              set { m_dtUpdateDate = value; }
          }

          public string IsActive
          {
              get { return m_sIsActive; }
              set { m_sIsActive = value; }
          }

          public string Remarks
          {
              get { return m_sRemarks; }
              set { m_sRemarks = value; }
          }

          #endregion
        }
    }
}
