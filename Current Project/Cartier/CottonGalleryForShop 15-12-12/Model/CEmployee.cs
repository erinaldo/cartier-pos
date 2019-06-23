using System;
using System.Collections.Generic;
using System.Text;


namespace ETL
{
    namespace Model
    {
        [Serializable]
       public class CEmployee
       {

           #region "Constructors"
           public CEmployee()
           {
               m_ID = string.Empty;
               m_EmpID = string.Empty;
               m_Name = string.Empty;
               m_FName = string.Empty;
               m_MName = string.Empty;
               m_SName = string.Empty;
               m_PerAddress = string.Empty;
               m_PerDistrict = string.Empty;
               m_PreAddress = string.Empty;
               m_PreDistrict = string.Empty;
               m_DOB = DateTime.MinValue;
               m_BloodGroup = string.Empty;
               m_DOJ = DateTime.MinValue;
               m_PcardNo = string.Empty;
               m_Sex = string.Empty;
               m_UnitID = string.Empty;
               m_EmployeeType = string.Empty;
               m_FloorID = string.Empty;
               m_SectionID = string.Empty;
               m_BlockID = string.Empty;
               m_DesignationID = string.Empty;
               m_GradeID = string.Empty;
               m_Shift = string.Empty;
               m_Basic = string.Empty;
               m_HouseRent = string.Empty;
               m_Medical = string.Empty;
               m_Conveyance = string.Empty;
               m_IsAllowance = false;
               m_IsAttendanceBonus = false;
               m_IsOT = false;
               m_IsActive = false;
               m_Education = String.Empty;
               m_Remarks = string.Empty;

                      
           
           }
           #endregion

           #region "Member Variables"
           
           protected string m_ID;
           protected string m_EmpID;
           protected string m_Name;
           protected string m_FName;
           protected string m_MName;
           protected string m_SName;
           protected string m_PerAddress;
           protected string m_PerDistrict;
           protected string m_PreAddress;
           protected string m_PreDistrict;
           protected DateTime m_DOB;
           protected string m_BloodGroup;
           protected DateTime m_DOJ;
           protected string m_PcardNo;
           protected string m_Sex;
           protected string m_UnitID;
           protected string m_EmployeeType;
           protected string m_FloorID;
           protected string m_SectionID;
           protected string m_BlockID;
           protected string m_DesignationID;
           protected string m_GradeID;
           protected string m_Shift;
           protected string m_Basic;
           protected string m_HouseRent;
           protected string m_Medical;
           protected string m_Conveyance;
           protected bool m_IsAllowance;
           protected bool m_IsAttendanceBonus;
           protected bool m_IsOT;
           protected bool m_IsActive;
           protected String m_Education;
           protected string m_Remarks;
          
           #endregion


           #region "Properties"

           public string ID
           {
               get { return m_ID; }
               set { m_ID = value; }
           }
           public string EmpID
           {
               get { return m_EmpID; }
               set { m_EmpID = value; }
           }
           public string Name
           {
               get { return m_Name; }
               set { m_Name = value; }
           }
           public string FName
           {
               get { return m_FName; }
               set { m_FName = value; }
           }
           public string MName
           {
               get { return m_MName; }
               set { m_MName = value; }
           }
           public string SName
           {
               get { return m_SName; }
               set { m_SName = value; }
           }
           public string PerAddress
           {
               get { return m_PerAddress; }
               set { m_PerAddress = value; }
           }
           public string PerDistrict
           {
               get { return m_PerDistrict; }
               set { m_PerDistrict = value; }
           }
           public string PreAddress
           {
               get { return m_PreAddress; }
               set { m_PreAddress = value; }
           }
           public string PreDistrict
           {
               get { return m_PreDistrict; }
               set { m_PreDistrict = value; }
           }
           public DateTime DOB
           {
               get { return m_DOB; }
               set { m_DOB = value; }
           }
           public string BloodGroup
           {
               get { return m_BloodGroup; }
               set { m_BloodGroup = value; }
           }
           public DateTime DOJ
           {
               get { return m_DOJ; }
               set { m_DOJ = value; }
           }
           public string PcardNo
           {
               get { return m_PcardNo; }
               set { m_PcardNo = value; }
           }
           public string Sex
           {
               get { return m_Sex; }
               set { m_Sex = value; }
           }
           public string UnitID
           {
               get { return m_UnitID; }
               set { m_UnitID = value; }
           }
           public string EmployeeType
           {
               get { return m_EmployeeType; }
               set { m_EmployeeType = value; }
           }
           public string FloorID
           {
               get { return m_FloorID; }
               set { m_FloorID = value; }
           }
           public string SectionID
           {
               get { return m_SectionID; }
               set { m_SectionID = value; }
           }
           public string BlockID
           {
               get { return m_BlockID; }
               set { m_BlockID = value; }
           }
           public string DesignationID
           {
               get { return m_DesignationID; }
               set { m_DesignationID = value; }
           }
           public string GradeID
           {
               get { return m_GradeID; }
               set { m_GradeID = value; }
           }

           public string Shift
           {
               get { return m_Shift; }
               set { m_Shift = value; }
           }

           public string Basic
           {
               get { return m_Basic; }
               set { m_Basic = value; }
           }
          
           public string HouseRent
           {
               get { return m_HouseRent; }
               set { m_HouseRent = value; }
           }


           public string Conveyance
           {
               get { return m_Conveyance; }
               set { m_Conveyance = value; }
           }


           public string Medical
           {
               get { return m_Medical; }
               set { m_Medical = value; }
           }


           public bool IsAllowance
           {
               get { return m_IsAllowance; }
               set { m_IsAllowance = value; }
           }
           public bool IsAttendanceBonus
           {
               get { return m_IsAttendanceBonus; }
               set { m_IsAttendanceBonus = value; }
           }
           public bool IsOT
           {
               get { return m_IsOT; }
               set { m_IsOT = value; }
           }
           public bool IsActive
           {
               get { return m_IsActive; }
               set { m_IsActive = value; }
           }

           public string Education
           {
               get { return m_Education; }
               set { m_Education = value; }
           }
           
           public string Remarks
           {
               get { return m_Remarks; }
               set { m_Remarks = value; }
           }
           
           #endregion
       
       
       }
    }
}