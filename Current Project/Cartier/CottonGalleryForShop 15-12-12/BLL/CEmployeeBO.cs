using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using ETL.Model;
using ETL.Common;
using ETL.DAO;



namespace ETL
{
    namespace BLL
    {
       public class CEmployeeBO
        {

            #region "Declaration"
            SqlConnection conn;

            CResult oResult;
            CConManager oConnManager;

            string s_DBError = "";

            #endregion

            #region "Constructor"

            public CEmployeeBO()
            {
                oConnManager = new CConManager();

            }
            
            #endregion
           
            #region "Methods"

            public CResult Create(CEmployee oEmployee)
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
                        cmd.CommandText = "sp_EmployeeInsert";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EmpID", oEmployee.EmpID);
                        cmd.Parameters.AddWithValue("@Name", oEmployee.Name);
                        cmd.Parameters.AddWithValue("@FName", oEmployee.FName);
                        cmd.Parameters.AddWithValue("@MName", oEmployee.MName);
                        cmd.Parameters.AddWithValue("@SName", oEmployee.SName);
                        cmd.Parameters.AddWithValue("@PerAddress", oEmployee.PerAddress);
                        cmd.Parameters.AddWithValue("@PerDistrict", oEmployee.PerDistrict);
                        cmd.Parameters.AddWithValue("@PreAddress", oEmployee.PreAddress);
                        cmd.Parameters.AddWithValue("@PreDistrict", oEmployee.PreDistrict);
                        cmd.Parameters.AddWithValue("@DOB", oEmployee.DOB);
                        cmd.Parameters.AddWithValue("@BloodGroup", oEmployee.BloodGroup);
                        cmd.Parameters.AddWithValue("@DOJ", oEmployee.DOJ);
                        cmd.Parameters.AddWithValue("@PcardNo", oEmployee.PcardNo);
                        cmd.Parameters.AddWithValue("@Sex", oEmployee.Sex);
                        cmd.Parameters.AddWithValue("@UnitID", oEmployee.UnitID);
                        cmd.Parameters.AddWithValue("@EmployeeType", oEmployee.EmployeeType);
                        cmd.Parameters.AddWithValue("@FloorID", oEmployee.FloorID);
                        cmd.Parameters.AddWithValue("@SectionID", oEmployee.SectionID);
                        cmd.Parameters.AddWithValue("@BlockID", oEmployee.BlockID);
                        cmd.Parameters.AddWithValue("@DesignationID", oEmployee.DesignationID);
                        cmd.Parameters.AddWithValue("@GradeID", oEmployee.GradeID);
                        cmd.Parameters.AddWithValue("@Basic", oEmployee.Basic);
                        cmd.Parameters.AddWithValue("@HouseRent", oEmployee.HouseRent);
                        cmd.Parameters.AddWithValue("@Medical", oEmployee.Medical);
                        cmd.Parameters.AddWithValue("@Conveyance", oEmployee.Conveyance);
                        cmd.Parameters.AddWithValue("@Shift", oEmployee.Shift);
                        cmd.Parameters.AddWithValue("@IsAllowance", oEmployee.IsAllowance);
                        cmd.Parameters.AddWithValue("@IsAttendanceBonus", oEmployee.IsAttendanceBonus);
                        cmd.Parameters.AddWithValue("@IsOT", oEmployee.IsOT);
                        cmd.Parameters.AddWithValue("@IsActive", oEmployee.IsActive);
                        cmd.Parameters.AddWithValue("@Education", oEmployee.Education);
                        cmd.Parameters.AddWithValue("@Remarks", oEmployee.Remarks);

                        //cmd.Parameters.AddWithValue("@GName", oGroup.GName);
                        //cmd.Parameters.AddWithValue("@SID", oGroup.SID);

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
            public CResult Update(CEmployee oEmployee)
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
                        cmd.CommandText = "sp_EmployeeUpdate";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", oEmployee.ID);
                        cmd.Parameters.AddWithValue("@EmpID", oEmployee.EmpID);
                        cmd.Parameters.AddWithValue("@Name", oEmployee.Name);
                        cmd.Parameters.AddWithValue("@FName", oEmployee.FName);
                        cmd.Parameters.AddWithValue("@MName", oEmployee.MName);
                        cmd.Parameters.AddWithValue("@SName", oEmployee.SName);
                        cmd.Parameters.AddWithValue("@PerAddress", oEmployee.PerAddress);
                        cmd.Parameters.AddWithValue("@PerDistrict", oEmployee.PerDistrict);
                        cmd.Parameters.AddWithValue("@PreAddress", oEmployee.PreAddress);
                        cmd.Parameters.AddWithValue("@PreDistrict", oEmployee.PreDistrict);
                        cmd.Parameters.AddWithValue("@DOB", oEmployee.DOB);
                        cmd.Parameters.AddWithValue("@BloodGroup", oEmployee.BloodGroup);
                        cmd.Parameters.AddWithValue("@DOJ", oEmployee.DOJ);
                        cmd.Parameters.AddWithValue("@PcardNo", oEmployee.PcardNo);
                        cmd.Parameters.AddWithValue("@Sex", oEmployee.Sex);
                        cmd.Parameters.AddWithValue("@UnitID", oEmployee.UnitID);
                        cmd.Parameters.AddWithValue("@EmployeeType", oEmployee.EmployeeType);
                        cmd.Parameters.AddWithValue("@FloorID", oEmployee.FloorID);
                        cmd.Parameters.AddWithValue("@SectionID", oEmployee.SectionID);
                        cmd.Parameters.AddWithValue("@BlockID", oEmployee.BlockID);
                        cmd.Parameters.AddWithValue("@DesignationID", oEmployee.DesignationID);
                        cmd.Parameters.AddWithValue("@GradeID", oEmployee.GradeID);
                        cmd.Parameters.AddWithValue("@Basic", oEmployee.Basic);
                        cmd.Parameters.AddWithValue("@HouseRent", oEmployee.HouseRent);
                        cmd.Parameters.AddWithValue("@Medical", oEmployee.Medical);
                        cmd.Parameters.AddWithValue("@Conveyance", oEmployee.Conveyance);
                        cmd.Parameters.AddWithValue("@Shift", oEmployee.Shift);
                        cmd.Parameters.AddWithValue("@IsAllowance", oEmployee.IsAllowance);
                        cmd.Parameters.AddWithValue("@IsAttendanceBonus", oEmployee.IsAttendanceBonus);
                        cmd.Parameters.AddWithValue("@IsOT", oEmployee.IsOT);
                        cmd.Parameters.AddWithValue("@IsActive", oEmployee.IsActive);
                        cmd.Parameters.AddWithValue("@Education", oEmployee.Education);
                        cmd.Parameters.AddWithValue("@Remarks", oEmployee.Remarks);

                        //cmd.Parameters.AddWithValue("@GName", oGroup.GName);
                        //cmd.Parameters.AddWithValue("@SID", oGroup.SID);

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
            public CResult Delete(CEmployee oEmployee)
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
                        cmd.CommandText = "sp_EmployeeDelete";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", oEmployee.ID);
                        cmd.Parameters.AddWithValue("@EmpID", oEmployee.EmpID);
                        cmd.Parameters.AddWithValue("@Name", oEmployee.Name);
                        cmd.Parameters.AddWithValue("@FName", oEmployee.FName);
                        cmd.Parameters.AddWithValue("@MName", oEmployee.MName);
                        cmd.Parameters.AddWithValue("@SName", oEmployee.SName);
                        cmd.Parameters.AddWithValue("@PerAddress", oEmployee.PerAddress);
                        cmd.Parameters.AddWithValue("@PerDistrict", oEmployee.PerDistrict);
                        cmd.Parameters.AddWithValue("@PreAddress", oEmployee.PreAddress);
                        cmd.Parameters.AddWithValue("@PreDistrict", oEmployee.PreDistrict);
                        cmd.Parameters.AddWithValue("@DOB", oEmployee.DOB);
                        cmd.Parameters.AddWithValue("@BloodGroup", oEmployee.BloodGroup);
                        cmd.Parameters.AddWithValue("@DOJ", oEmployee.DOJ);
                        cmd.Parameters.AddWithValue("@PcardNo", oEmployee.PcardNo);
                        cmd.Parameters.AddWithValue("@Sex", oEmployee.Sex);
                        cmd.Parameters.AddWithValue("@UnitID", oEmployee.UnitID);
                        cmd.Parameters.AddWithValue("@EmployeeType", oEmployee.EmployeeType);
                        cmd.Parameters.AddWithValue("@FloorID", oEmployee.FloorID);
                        cmd.Parameters.AddWithValue("@SectionID", oEmployee.SectionID);
                        cmd.Parameters.AddWithValue("@BlockID", oEmployee.BlockID);
                        cmd.Parameters.AddWithValue("@DesignationID", oEmployee.DesignationID);
                        cmd.Parameters.AddWithValue("@GradeID", oEmployee.GradeID);
                        cmd.Parameters.AddWithValue("@Basic", oEmployee.Basic);
                        cmd.Parameters.AddWithValue("@HouseRent", oEmployee.HouseRent);
                        cmd.Parameters.AddWithValue("@Medical", oEmployee.Medical);
                        cmd.Parameters.AddWithValue("@Conveyance", oEmployee.Conveyance);
                        cmd.Parameters.AddWithValue("@Shift", oEmployee.Shift);
                        cmd.Parameters.AddWithValue("@IsAllowance", oEmployee.IsAllowance);
                        cmd.Parameters.AddWithValue("@IsAttendanceBonus", oEmployee.IsAttendanceBonus);
                        cmd.Parameters.AddWithValue("@IsOT", oEmployee.IsOT);
                        cmd.Parameters.AddWithValue("@IsActive", oEmployee.IsActive);
                        cmd.Parameters.AddWithValue("@Education", oEmployee.Education);
                        cmd.Parameters.AddWithValue("@Remarks", oEmployee.Remarks);

                        //cmd.Parameters.AddWithValue("@GName", oGroup.GName);
                        //cmd.Parameters.AddWithValue("@SID", oGroup.SID);

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


            public CResult ReadAllEmployee(CEmployee oEmployee)
            {

                ArrayList oComapanyList = new ArrayList();
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {


                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "Select * from t_Employee";

                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dt = ds.Tables[0];

                        foreach (DataRow dr in dt.Rows)
                        {
                            oComapanyList.Add(GetresultoEmployee(dr));

                        }


                        oResult.Data = oComapanyList;

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
            private CEmployee GetresultoEmployee(DataRow dr)
            {
                CEmployee oEmployee = new CEmployee();
                oEmployee.ID = dr[0].ToString();
                oEmployee.EmpID = dr[1].ToString();
                oEmployee.Name = dr[2].ToString();
                oEmployee.DesignationID = dr[20].ToString();
                oEmployee.UnitID = dr[15].ToString();
                oEmployee.SectionID = dr[18].ToString();
                oEmployee.BlockID = dr[19].ToString();
                oEmployee.EmployeeType = dr[16].ToString();
                oEmployee.DOB = DateTime.Parse(dr["DOB"].ToString());
                oEmployee.DOJ = DateTime.Parse(dr["DOJ"].ToString());

                return oEmployee;
            }
            //public CResult SearchEmployee(String Unit, String Floor, String Section, String Block, String Shift, String Designation, String Education, String EmpID)
            //{

            //    ArrayList oEmployeeList = new ArrayList();
            //    oResult = new CResult();
            //    conn = oConnManager.GetConnection(out s_DBError);
            //    if (conn != null)
            //    {


            //        try
            //        {
            //            SqlCommand cmd = new SqlCommand();
            //            cmd.Connection = conn;
            //            String str = "select * from t_employee "; ;
            //            int Temp = 0;
            //            if ((Unit != "") || (Floor != ""))
            //            {
            //                if (Unit != "")
            //                {
            //                    if (Temp == 0)
            //                    {
            //                        str += " where UnitID = '" + Unit + "'";
            //                        Temp = 1;
            //                    }
            //                    else
            //                    {
            //                        // " And Employee.EmployeeID='" + txtEmployeeID.Text.Trim() + "'";
            //                        str += " where UnitID = '" + Unit + "'";
            //                        Temp = 1;
            //                    }

            //                }

            //                if (Floor != "")
            //                {

            //                    if (Temp == 0)
            //                    {
            //                        str += " where FloorID = '" + Floor + "'";
            //                        Temp = 1;
            //                    }

            //                    else
            //                    {
            //                        // " And Employee.EmployeeID='" + txtEmployeeID.Text.Trim() + "'";
            //                        str += " and FloorID = '" + Floor + "'";
            //                        Temp = 1;
            //                    }

            //                }

            //                if (Section != "")
            //                {

            //                    if (Temp == 0)
            //                    {
            //                        str += " where SectionID = '" + Section + "'";
            //                        Temp = 1;
            //                    }

            //                    else
            //                    {
            //                        // " And Employee.EmployeeID='" + txtEmployeeID.Text.Trim() + "'";
            //                        str += " and SectionID = '" + Section + "'";
            //                        Temp = 1;
            //                    }

            //                }



            //                if (Block != "")
            //                {

            //                    if (Temp == 0)
            //                    {
            //                        str += " where BlockID = '" + Block + "'";
            //                        Temp = 1;
            //                    }

            //                    else
            //                    {
            //                        // " And Employee.EmployeeID='" + txtEmployeeID.Text.Trim() + "'";
            //                        str += " and BlockID = '" + Block + "'";
            //                        Temp = 1;
            //                    }

            //                }


            //                if (Shift != "")
            //                {

            //                    if (Temp == 0)
            //                    {
            //                        str += " where Shift = '" + Shift + "'";
            //                        Temp = 1;
            //                    }

            //                    else
            //                    {
            //                        // " And Employee.EmployeeID='" + txtEmployeeID.Text.Trim() + "'";
            //                        str += " and Shift = '" + Shift + "'";
            //                        Temp = 1;
            //                    }

            //                }

            //                if (Designation != "")
            //                {

            //                    if (Temp == 0)
            //                    {
            //                        str += " where DesignationID = '" + Designation + "'";
            //                        Temp = 1;
            //                    }

            //                    else
            //                    {
            //                        // " And Employee.EmployeeID='" + txtEmployeeID.Text.Trim() + "'";
            //                        str += " and DesignationID = '" + Designation + "'";
            //                        Temp = 1;
            //                    }

            //                }


            //                if (Education != "")
            //                {

            //                    if (Temp == 0)
            //                    {
            //                        str += " where EducationID = '" + Education + "'";
            //                        Temp = 1;
            //                    }

            //                    else
            //                    {
            //                        // " And Employee.EmployeeID='" + txtEmployeeID.Text.Trim() + "'";
            //                        str += " and EducatrionID = '" + Section + "'";
            //                        Temp = 1;
            //                    }

            //                }

            //                if (EmpID != "")
            //                {

            //                    if (Temp == 0)
            //                    {
            //                        str += " where EmpID = '" + EmpID + "'";
            //                        Temp = 1;
            //                    }

            //                    else
            //                    {
            //                        // " And Employee.EmployeeID='" + txtEmployeeID.Text.Trim() + "'";
            //                        str += " and EmpID = '" + EmpID + "'";
            //                        Temp = 1;
            //                    }

            //                }




            //            }



            //            cmd.CommandText = str;

            //            DataSet ds = new DataSet();
            //            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //            da.Fill(ds);
            //            DataTable dt = ds.Tables[0];

            //            foreach (DataRow dr in dt.Rows)
            //            {
            //                oEmployeeList.Add(GetresultoEmployee(dr));

            //            }


            //            oResult.Data = oEmployeeList;

            //            oResult.IsSuccess = true;
            //        }
            //        catch (SqlException e)
            //        {
            //            string sRollbackError = oConnManager.Rollback();

            //            oResult.IsSuccess = false;
            //            oResult.ErrMsg = sRollbackError.Equals("") ? oConnManager.GetErrorMessage(e) : sRollbackError;
            //        }
            //        finally
            //        {
            //            oConnManager.Close();
            //        }
            //    }
            //    else
            //    {
            //        oResult.IsSuccess = false;
            //        oResult.ErrMsg = s_DBError;
            //    }
            //    return oResult;

            //}

            //private CEmployee GetresultoEmployee(DataRow dr)
            //{
            //    CEmployee oEmployee = new CEmployee();
            //    oEmployee.ID = dr[0].ToString();
            //    oEmployee.EmpID = dr[1].ToString();
            //    oEmployee.Name = dr[2].ToString();
            //    oEmployee.DesignationID = dr[20].ToString();
            //    oEmployee.UnitID = dr[15].ToString();
            //    oEmployee.SectionID = dr[18].ToString();
            //    oEmployee.BlockID = dr[19].ToString();

            //    return oEmployee;
            //}


            public CResult ReadEmployeeByCond(CEmployee oEmployee)
            {
                oResult = new CResult();
                ArrayList arEmployeeList = new ArrayList();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {


                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    cmd.Transaction = oConnManager.BeginTransaction();
                    try
                    {
                        DataSet ds = new DataSet();
                        cmd.Connection = conn;
                        //cmd.CommandText = "Select * from t_Employee where OrderID='" + oEmployee.OrdreID + "'";
                        cmd.CommandText = "sp_Employee_ReadByCondition";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EmpID", oEmployee.EmpID.Trim());

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);

                        DataTable dt = ds.Tables[0];

                        oResult.IsSuccess = true;
                        oResult.Data = dt;
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

            public CResult Import(CEmployee oEmployee)
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
                        cmd.CommandText = "sp_Employee_Import";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", oEmployee.ID);
                        cmd.Parameters.AddWithValue("@EmpID", oEmployee.EmpID);
                        cmd.Parameters.AddWithValue("@Name", oEmployee.Name);
                        cmd.Parameters.AddWithValue("@FName", oEmployee.FName);
                        cmd.Parameters.AddWithValue("@MName", oEmployee.MName);
                        cmd.Parameters.AddWithValue("@SName", oEmployee.SName);
                        cmd.Parameters.AddWithValue("@PerAddress", oEmployee.PerAddress);
                        cmd.Parameters.AddWithValue("@PerDistrict", oEmployee.PerDistrict);
                        cmd.Parameters.AddWithValue("@PreAddress", oEmployee.PreAddress);
                        cmd.Parameters.AddWithValue("@PreDistrict", oEmployee.PreDistrict);
                        cmd.Parameters.AddWithValue("@DOB", oEmployee.DOB);
                        cmd.Parameters.AddWithValue("@BloodGroup", oEmployee.BloodGroup);
                        cmd.Parameters.AddWithValue("@DOJ", oEmployee.DOJ);
                        cmd.Parameters.AddWithValue("@PcardNo", oEmployee.PcardNo);
                        cmd.Parameters.AddWithValue("@Sex", oEmployee.Sex);
                        cmd.Parameters.AddWithValue("@UnitID", oEmployee.UnitID);
                        cmd.Parameters.AddWithValue("@EmployeeType", oEmployee.EmployeeType);
                        cmd.Parameters.AddWithValue("@FloorID", oEmployee.FloorID);
                        cmd.Parameters.AddWithValue("@SectionID", oEmployee.SectionID);
                        cmd.Parameters.AddWithValue("@BlockID", oEmployee.BlockID);
                        cmd.Parameters.AddWithValue("@DesignationID", oEmployee.DesignationID);
                        cmd.Parameters.AddWithValue("@GradeID", oEmployee.GradeID);
                        cmd.Parameters.AddWithValue("@Basic", oEmployee.Basic);
                        cmd.Parameters.AddWithValue("@HouseRent", oEmployee.HouseRent);
                        cmd.Parameters.AddWithValue("@Medical", oEmployee.Medical);
                        cmd.Parameters.AddWithValue("@Conveyance", oEmployee.Conveyance);
                        cmd.Parameters.AddWithValue("@Shift", oEmployee.Shift);
                        cmd.Parameters.AddWithValue("@IsAllowance", oEmployee.IsAllowance);
                        cmd.Parameters.AddWithValue("@IsAttendanceBonus", oEmployee.IsAttendanceBonus);
                        cmd.Parameters.AddWithValue("@IsOT", oEmployee.IsOT);
                        cmd.Parameters.AddWithValue("@IsActive", oEmployee.IsActive);
                        cmd.Parameters.AddWithValue("@Education", oEmployee.Education);
                        cmd.Parameters.AddWithValue("@Remarks", oEmployee.Remarks);

                        //cmd.Parameters.AddWithValue("@GName", oGroup.GName);
                        //cmd.Parameters.AddWithValue("@SID", oGroup.SID);

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



            #endregion
       }
    }
}