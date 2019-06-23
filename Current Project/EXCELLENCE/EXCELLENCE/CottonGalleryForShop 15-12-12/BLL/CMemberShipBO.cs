using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ETL.Common;
using ETL.DAO;
using Model;
using System.Data;

namespace BLL
{
    public class CMemberShipBO
    {
        
            #region "Member variables"

            private SqlConnection conn;
            private CResult oResult;
            private CConManager oConnManager;

            string s_DBError = "";

            #endregion

            #region "Costructor"

            public CMemberShipBO()
            {
                oConnManager = new CConManager();
            }
            #endregion


            public CResult Create(CMemberShip oMemberShip)
            {
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    cmd.Transaction = oConnManager.BeginTransaction();
                    try
                    {
                        StringBuilder sBuilder = new StringBuilder();
                        sBuilder.Append("DECLARE @NextId NCHAR(24);");
                        sBuilder.Append("EXEC sp_GetNextId 'Member_OID','Member', @Member_Branch, @NextId OUTPUT;");
                        sBuilder.Append(" Insert into t_Member values(@NextId,@Member_Branch,");
                        sBuilder.Append("@Member_MembershipID,@Member_Name,@Member_Mobile,@Member_DateOfBirth,");
                        sBuilder.Append("@Member_FromDate,@Member_ToDate,@Member_Address,");
                        sBuilder.Append("@Member_Area,@Member_PostCode,@Member_Phone,@Member_Email,@Member_Occupation,@Member_FamilyMember,");
                        sBuilder.Append("@Member_CreatedBy,@Member_CreationDate,@Member_UpdateBy,@Member_UpdateDate,@Member_IsActive,@Member_DiscountAmount)");

                        cmd.CommandText = sBuilder.ToString();
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@Member_Branch", oMemberShip.Branch);
                        cmd.Parameters.AddWithValue("@Member_MembershipID", oMemberShip.MembershipID);
                        cmd.Parameters.AddWithValue("@Member_Name", oMemberShip.MemberName);
                        cmd.Parameters.AddWithValue("@Member_Mobile", oMemberShip.Mobile);
                        cmd.Parameters.AddWithValue("@Member_DateOfBirth", oMemberShip.DateOfBirth);
                        cmd.Parameters.AddWithValue("@Member_FromDate", oMemberShip.Fromdate);
                        cmd.Parameters.AddWithValue("@Member_ToDate", oMemberShip.Todate);
                        cmd.Parameters.AddWithValue("@Member_Address", oMemberShip.Address);
                        cmd.Parameters.AddWithValue("@Member_Area", oMemberShip.Area);
                        cmd.Parameters.AddWithValue("@Member_PostCode", oMemberShip.PostCode);
                        cmd.Parameters.AddWithValue("@Member_Phone", oMemberShip.Phone);
                        cmd.Parameters.AddWithValue("@Member_Email", oMemberShip.Email);
                        cmd.Parameters.AddWithValue("@Member_Occupation", oMemberShip.Occupation);
                        cmd.Parameters.AddWithValue("@Member_FamilyMember", oMemberShip.FamilyMember);
                        cmd.Parameters.AddWithValue("@Member_CreatedBy", oMemberShip.Creator);
                        cmd.Parameters.AddWithValue("@Member_CreationDate", oMemberShip.CreationDate);
                        cmd.Parameters.AddWithValue("@Member_UpdateBy", "");
                        cmd.Parameters.AddWithValue("@Member_UpdateDate", "");
                        cmd.Parameters.AddWithValue("@Member_IsActive", 1);
                        cmd.Parameters.AddWithValue("@Member_DiscountAmount", oMemberShip.Member_DiscountAmount);

                        cmd.ExecuteNonQuery();
                        oConnManager.Commit();
                        oResult.IsSuccess = true;
                    }
                    catch (SqlException e)
                    {
                        string sRollbackError = oConnManager.Rollback();

                        oResult.IsSuccess = false;
                        oResult.ErrMsg = sRollbackError.Equals("") ? oConnManager.GetErrorMessage(e) : sRollbackError;
                    }
                    finally
                    {
                        oConnManager.Close();
                    }
                }
                else
                {
                    oResult.IsSuccess = false;
                    oResult.ErrMsg = s_DBError;
                }

                return oResult;
            }

         public CResult Update(CMemberShip oMemberShip)
            {
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    cmd.Transaction = oConnManager.BeginTransaction();
                    try
                    {
                        StringBuilder sBuilder = new StringBuilder();
                        sBuilder.Append("Update t_Member set Member_Branch=@Member_Branch,Member_MembershipID=@Member_MembershipID,Member_Name=@Member_Name,");
                        sBuilder.Append("Member_Mobile=@Member_Mobile,Member_DateOfBirth=@Member_DateOfBirth,Member_FromDate=@Member_FromDate,Member_ToDate=@Member_ToDate,");
                        sBuilder.Append("Member_Address=@Member_Address,Member_Area=@Member_Area,Member_PostCode=@Member_PostCode,Member_Phone=@Member_Phone,");
                        sBuilder.Append("Member_Email=@Member_Email,Member_Occupation=@Member_Occupation,Member_FamilyMember=@Member_FamilyMember,");
                        sBuilder.Append("Member_UpdateBy=@Member_UpdateBy,Member_UpdateDate=@Member_UpdateDate,Member_IsActive=@Member_IsActive,Member_DiscountAmount=@Member_DiscountAmount ");
                        sBuilder.Append("where Member_OID=@MemberOID");
                        cmd.CommandText = sBuilder.ToString();
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@MemberOID", oMemberShip.ID);
                        cmd.Parameters.AddWithValue("@Member_Branch", oMemberShip.Branch);
                        cmd.Parameters.AddWithValue("@Member_MembershipID", oMemberShip.MembershipID);
                        cmd.Parameters.AddWithValue("@Member_Name", oMemberShip.MemberName);
                        cmd.Parameters.AddWithValue("@Member_Mobile", oMemberShip.Mobile);
                        cmd.Parameters.AddWithValue("@Member_DateOfBirth", oMemberShip.DateOfBirth);
                        cmd.Parameters.AddWithValue("@Member_FromDate", oMemberShip.Fromdate);
                        cmd.Parameters.AddWithValue("@Member_ToDate", oMemberShip.Todate);
                        cmd.Parameters.AddWithValue("@Member_Address", oMemberShip.Address);
                        cmd.Parameters.AddWithValue("@Member_Area", oMemberShip.Area);
                        cmd.Parameters.AddWithValue("@Member_PostCode", oMemberShip.PostCode);
                        cmd.Parameters.AddWithValue("@Member_Phone", oMemberShip.Phone);
                        cmd.Parameters.AddWithValue("@Member_Email", oMemberShip.Email);
                        cmd.Parameters.AddWithValue("@Member_Occupation", oMemberShip.Occupation);
                        cmd.Parameters.AddWithValue("@Member_FamilyMember", oMemberShip.FamilyMember);
                        cmd.Parameters.AddWithValue("@Member_UpdateBy", oMemberShip.UpdateBy);
                        cmd.Parameters.AddWithValue("@Member_UpdateDate", oMemberShip.UpdateDate);
                        cmd.Parameters.AddWithValue("@Member_IsActive", oMemberShip.IsActiveMenber);
                        cmd.Parameters.AddWithValue("@Member_DiscountAmount", oMemberShip.Member_DiscountAmount);

                        cmd.ExecuteNonQuery();
                        oConnManager.Commit();
                        oResult.IsSuccess = true;
                    }
                    catch (SqlException e)
                    {
                        string sRollbackError = oConnManager.Rollback();

                        oResult.IsSuccess = false;
                        oResult.ErrMsg = sRollbackError.Equals("") ? oConnManager.GetErrorMessage(e) : sRollbackError;
                    }
                    finally
                    {
                        oConnManager.Close();
                    }
                }
                else
                {
                    oResult.IsSuccess = false;
                    oResult.ErrMsg = s_DBError;
                }

                return oResult;
            }



         public CResult Delete(string oMemberOID)
         {
             oResult = new CResult();
             conn = oConnManager.GetConnection(out s_DBError);
             if (conn != null)
             {
                 SqlCommand cmd = new SqlCommand();
                 cmd.Connection = conn;

                 cmd.Transaction = oConnManager.BeginTransaction();
                 try
                 {
                     StringBuilder sBuilder = new StringBuilder();
                     cmd.CommandText = "sp_MemberShip_Delete";
                     cmd.CommandType = CommandType.StoredProcedure;

                     cmd.Parameters.AddWithValue("@Member_OID", oMemberOID);


                     cmd.ExecuteNonQuery();

                     oConnManager.Commit();
                     oResult.IsSuccess = true;
                 }
                 catch (SqlException e)
                 {
                     string sRollbackError = oConnManager.Rollback();

                     oResult.IsSuccess = false;
                     oResult.ErrMsg = sRollbackError.Equals("") ? oConnManager.GetErrorMessage(e) : sRollbackError;
                 }
                 finally
                 {
                     oConnManager.Close();
                 }
             }
             else
             {
                 oResult.IsSuccess = false;
                 oResult.ErrMsg = s_DBError;
             }

             return oResult;
         }

         public CResult ReadAll()
         {
             List<CMemberShip> oMemberList = new List<CMemberShip>();
             oResult = new CResult();
             conn = oConnManager.GetConnection(out s_DBError);
             if (conn != null)
             {
                 try
                 {
                     SqlCommand cmd = new SqlCommand();

                     cmd.Connection = conn;
                     cmd.CommandText = "Select * from t_Curr order by Curr_OID";
                     cmd.CommandType = CommandType.Text;

                     SqlDataReader oReader = cmd.ExecuteReader();
                     if (oReader.HasRows)
                     {
                         while (oReader.Read())
                         {
                             CMemberShip oMembership = new CMemberShip();
                             oMembership.ID = oReader["Curr_OID"].ToString();
                             oMembership.Branch = oReader["Curr_Branch"].ToString();
                             oMembership.Branch = oReader["Curr_Code"].ToString();
                             oMembership.Branch = oReader["Curr_Name"].ToString();
                             oMemberList.Add(oMembership);
                         }
                     }
                     oReader.Close();

                     oResult.IsSuccess = true;
                     oResult.Data = oMemberList;
                 }
                 catch (SqlException e)
                 {
                     oResult.IsSuccess = false;
                     oResult.ErrMsg = e.Message;
                 }
                 finally
                 {
                     oConnManager.Close();
                 }
             }
             else
             {
                 oResult.IsSuccess = false;
                 oResult.ErrMsg = s_DBError;
             }

             return oResult;
         }

         public CResult ReadAllByDateAndIsActive(string Branch,string MembershipID)
         {
             List<CMemberShip> oMemberList = new List<CMemberShip>();
             oResult = new CResult();
             conn = oConnManager.GetConnection(out s_DBError);
             if (conn != null)
             {
                 try
                 {
                     SqlCommand cmd = new SqlCommand();

                     cmd.Connection = conn;
                     cmd.CommandText = "sp_ReadAllByDateAndIsActiveMember";
                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.AddWithValue("@Member_Bracch", Branch);
                     cmd.Parameters.AddWithValue("@Member_MembershipID", MembershipID);

                     SqlDataReader oReader = cmd.ExecuteReader();
                     if (oReader.HasRows)
                     {
                         while (oReader.Read())
                         {

                             CMemberShip oMembership = SetMembership(oReader);
                             oMemberList.Add(oMembership);
                         }
                     }
                     oReader.Close();

                     oResult.IsSuccess = true;
                     oResult.Data = oMemberList;
                 }
                 catch (SqlException e)
                 {
                     oResult.IsSuccess = false;
                     oResult.ErrMsg = e.Message;
                 }
                 finally
                 {
                     oConnManager.Close();
                 }
             }
             else
             {
                 oResult.IsSuccess = false;
                 oResult.ErrMsg = s_DBError;
             }

             return oResult;
         }




        public CResult ReadAllByBranch(string Branch)
         {
             List<CMemberShip> oMemberList = new List<CMemberShip>();
             oResult = new CResult();
             conn = oConnManager.GetConnection(out s_DBError);
             if (conn != null)
             {
                 try
                 {
                     SqlCommand cmd = new SqlCommand();

                     cmd.Connection = conn;
                     cmd.CommandText = "sp_ReadAllByBranch";
                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.AddWithValue("@Member_Branch",Branch);

                     SqlDataReader oReader = cmd.ExecuteReader();
                     if (oReader.HasRows)
                     {
                         while (oReader.Read())
                         {
                             CMemberShip oMembership = SetMembership(oReader);
                             oMemberList.Add(oMembership);
                         }
                     }
                     oReader.Close();

                     oResult.IsSuccess = true;
                     oResult.Data = oMemberList;
                 }
                 //catch (SqlException e)
                 //{
                 //    oResult.IsSuccess = false;
                 //    oResult.ErrMsg = e.Message;
                 //}
                 finally
                 {
                     oConnManager.Close();
                 }
             }
             else
             {
                 oResult.IsSuccess = false;
                 oResult.ErrMsg = s_DBError;
             }

             return oResult;
         }

        private static CMemberShip SetMembership(SqlDataReader oReader)
        {
            CMemberShip oMembership = new CMemberShip();
            oMembership.ID = oReader["Member_OID"].ToString();
            oMembership.Branch = oReader["Member_Branch"].ToString();
            oMembership.MembershipID = oReader["Member_MembershipID"].ToString();
            oMembership.MemberName = oReader["Member_Name"].ToString();
            oMembership.Mobile = oReader["Member_Mobile"].ToString();
            oMembership.DateOfBirth = DateTime.Parse(oReader["Member_DateOfBirth"].ToString());
            oMembership.Fromdate = DateTime.Parse(oReader["Member_FromDate"].ToString());
            oMembership.Todate = DateTime.Parse(oReader["Member_ToDate"].ToString());
            oMembership.Address = oReader["Member_Address"].ToString();
            oMembership.Area = oReader["Member_Area"].ToString();
            oMembership.PostCode = oReader["Member_PostCode"].ToString();
            oMembership.Phone = oReader["Member_Phone"].ToString();
            oMembership.Email = oReader["Member_Email"].ToString();
            oMembership.Occupation = oReader["Member_Occupation"].ToString();
            oMembership.FamilyMember = int.Parse(oReader["Member_FamilyMember"].ToString());
            oMembership.Member_DiscountAmount = float.Parse(oReader["Member_DiscountAmount"].ToString());
            if ((bool)oReader["Member_IsActive"] == true)
            {
                oMembership.IsActiveMenber = 1;
            }
            else if ((bool)oReader["Member_IsActive"] == false)
            {
                oMembership.IsActiveMenber = 0;
            }
            return oMembership;
        }


    }
}
