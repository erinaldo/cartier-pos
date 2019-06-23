using System;
namespace ETL
{
namespace Model
{
    [Serializable]
   public class CUser
    {
        #region "Declaration"
       string m_OID;
       string m_Branch;
       string m_UserID;
       string m_UserName;
       string m_Passward;
       string m_UserType;
       string m_UserStatus;
       DateTime m_CreatedDate;

        #endregion


        #region "Constructor"
       public CUser()
       {
           m_OID = string.Empty;
           m_Branch = string.Empty; ;
           m_UserID = string.Empty;
           m_UserName = string.Empty;
           m_Passward = string.Empty;
           m_UserType = string.Empty;
           m_UserStatus = string.Empty;
           m_CreatedDate = DateTime.MinValue.Date;
       
       
       
       }
        #endregion




        #region "Properties"
       public string User_OID
       {
           get { return m_OID; }
           set { m_OID = value; }
       }
       public string User_Branch
       {
           get { return m_Branch; }
           set { m_Branch = value; }
       }
       public string User_UserID
       {
           get { return m_UserID; }
           set { m_UserID = value; }
       }
       public string User_UserName
       {
           get { return m_UserName; }
           set { m_UserName = value; }
       }
       public string User_Passward
       {
           get { return m_Passward; }
           set { m_Passward = value; }
       }
       public string User_UserType
       {
           get { return m_UserType; }
           set { m_UserType = value; }
       }
       public string User_UserStatus
       {
           get { return m_UserStatus; }
           set { m_UserStatus = value; }
       }
       public DateTime User_CreatedDate
       {
           get { return m_CreatedDate; }
           set { m_CreatedDate = value; }
       }
       
       

        #endregion


    }
}
}