/* File Name		: CBase2.cs
 * Author			: Prince
 * Creation Date	: 08-09-08
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
        public class CBase2
        {

            #region "Constructor"

          public CBase2()
          {
              m_sCreator = string.Empty;
              m_dtCreationDate = DateTime.Now;
              m_sUpdateBy = string.Empty;
              m_dtUpdateDate = DateTime.Now;
              m_bIsActive = false;
              m_sRemarks = string.Empty;
          }
            #endregion
          #region "Member variables"
          protected string m_sCreator;
          protected DateTime m_dtCreationDate;
          protected string m_sUpdateBy;
          protected DateTime m_dtUpdateDate;
          protected bool m_bIsActive;
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

          public bool IsActive
          {
              get { return m_bIsActive; }
              set { m_bIsActive = value; }
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
