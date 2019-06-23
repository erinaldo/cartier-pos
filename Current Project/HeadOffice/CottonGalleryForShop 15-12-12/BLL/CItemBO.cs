using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using System.Data.SqlClient;

using ETL.Model;
using ETL.Common;
using ETL.DAO;


namespace ETL
{
    namespace BLL
    {
        public class CItemBO
        {

            #region "Member variables"

            private SqlConnection conn;
            private CResult oResult;
            private CConManager oConnManager;

            string s_DBError = "";

            #endregion

            #region "Costructor"

            public CItemBO()
            {
                oConnManager = new CConManager();
            }
            #endregion

            private CItemGroup GetResultSetToItemGroup(DataRow dr)
            {
                CItemGroup oItemGroup = new CItemGroup();

                oItemGroup.Catg_OID= dr[0].ToString();
                oItemGroup.Catg_Branch= dr[1].ToString();
                oItemGroup.Catg_Code= dr[2].ToString();
                oItemGroup.Catg_Name= dr[3].ToString();
                oItemGroup.Creator = dr[4].ToString();
                oItemGroup.CreationDate= DateTime.Parse( dr[5].ToString()).Date;
                oItemGroup.UpdateBy= dr[6].ToString();
                oItemGroup.UpdateDate= DateTime.Parse(dr[7].ToString()).Date;
                oItemGroup.IsActive = dr[8].ToString();
                oItemGroup.Remarks = dr[9].ToString();


                return oItemGroup;
            }

            private CItemType GetResultSetToItemType(DataRow dr)
            {
                CItemType oItemType = new CItemType();

                oItemType.ITyp_OID = dr[0].ToString();
                oItemType.ITyp_Branch = dr[1].ToString();
                oItemType.ITyp_Code = dr[2].ToString();
                oItemType.ITyp_Name= dr[3].ToString();
                oItemType.Creator = dr[4].ToString();
                oItemType.CreationDate = DateTime.Parse(dr[5].ToString()).Date;
                oItemType.UpdateBy = dr[6].ToString();
                oItemType.UpdateDate = DateTime.Parse(dr[7].ToString()).Date;
                oItemType.IsActive = dr[8].ToString();
                oItemType.Remarks = dr[9].ToString();

                return oItemType;
            }



            #region "Item"
            
            public CResult Create(CItem oItem)
            {
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.Parameters.Clear();

                    cmd.Transaction = oConnManager.BeginTransaction();
                    try
                    {
                        cmd.CommandText = "sp_Item_InsertWithImage";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Item_OID", oItem.Item_OID);
                        cmd.Parameters.AddWithValue("@Item_Branch", oItem.Item_Branch);
                        cmd.Parameters.AddWithValue("@Item_Code", oItem.Item_Code);
                        cmd.Parameters.AddWithValue("@Item_GroupID", oItem.Item_GroupID);
                        cmd.Parameters.AddWithValue("@Item_TypeID", oItem.Item_TypeID);
                        cmd.Parameters.AddWithValue("@Item_IsRaw", oItem.Item_IsRaw);
                        cmd.Parameters.AddWithValue("@Item_ItemName", oItem.Item_ItemName);
                        cmd.Parameters.AddWithValue("@Item_UOMID", oItem.Item_UOMID);
                        cmd.Parameters.AddWithValue("@Item_Sprice", oItem.Item_Sprice);
                        cmd.Parameters.AddWithValue("@Item_Pprice", oItem.Item_Pprice);
                        cmd.Parameters.AddWithValue("@Item_RQTY", oItem.Item_RQTY);
                        cmd.Parameters.AddWithValue("@Item_Creator", oItem.Creator);
                        cmd.Parameters.AddWithValue("@Item_CreationDate", oItem.CreationDate);
                        cmd.Parameters.AddWithValue("@Item_UpdateBy", oItem.UpdateBy);
                        cmd.Parameters.AddWithValue("@Item_UpdateDate", oItem.UpdateDate);
                        cmd.Parameters.AddWithValue("@Item_IsActive", oItem.IsActive);
                        cmd.Parameters.AddWithValue("@Item_Remarks", oItem.Remarks);
                        cmd.Parameters.AddWithValue("@Item_Priority", oItem.Item_Priority);
                        
                        if (oItem.ItemImage != null)
                        {
                            cmd.Parameters.AddWithValue("@Image_HasImage", "Y");
                            cmd.Parameters.AddWithValue("@Image_Data", oItem.ItemImage);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Image_HasImage", "N");
                            cmd.Parameters.AddWithValue("@Image_Data", new byte[]{1,2,3});
                        }                        

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
            public CResult Update(CItem oItem)
            {
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.Parameters.Clear();

                    cmd.Transaction = oConnManager.BeginTransaction();
                    try
                    {
                        cmd.CommandText = "sp_Item_UpdateWithImage";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Item_OID", oItem.Item_OID);
                        cmd.Parameters.AddWithValue("@Item_Branch", oItem.Item_Branch);
                        cmd.Parameters.AddWithValue("@Item_Code", oItem.Item_Code);
                        cmd.Parameters.AddWithValue("@Item_GroupID", oItem.Item_GroupID);
                        cmd.Parameters.AddWithValue("@Item_TypeID", oItem.Item_TypeID);
                        cmd.Parameters.AddWithValue("@Item_IsRaw", oItem.Item_IsRaw);
                        cmd.Parameters.AddWithValue("@Item_ItemName", oItem.Item_ItemName);
                        cmd.Parameters.AddWithValue("@Item_UOMID", oItem.Item_UOMID);
                        cmd.Parameters.AddWithValue("@Item_Sprice", oItem.Item_Sprice);
                        cmd.Parameters.AddWithValue("@Item_Pprice", oItem.Item_Pprice);
                        cmd.Parameters.AddWithValue("@Item_RQTY", oItem.Item_RQTY);
                        cmd.Parameters.AddWithValue("@Item_Creator", oItem.Creator);
                        cmd.Parameters.AddWithValue("@Item_CreationDate", oItem.CreationDate);
                        cmd.Parameters.AddWithValue("@Item_UpdateBy", oItem.UpdateBy);
                        cmd.Parameters.AddWithValue("@Item_UpdateDate", oItem.UpdateDate);
                        cmd.Parameters.AddWithValue("@Item_IsActive", oItem.IsActive);
                        cmd.Parameters.AddWithValue("@Item_Remarks", oItem.Remarks);
                        cmd.Parameters.AddWithValue("@Item_Priority", oItem.Item_Priority);

                        if (oItem.ItemImage != null)
                        {
                            cmd.Parameters.AddWithValue("@Image_HasImage", "Y");
                            cmd.Parameters.AddWithValue("@Image_Data", oItem.ItemImage);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Image_HasImage", "N");
                            cmd.Parameters.AddWithValue("@Image_Data", new byte[] { 1, 2, 3 });
                        }
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
            public CResult Delete(CItem oItem)
            {
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.Parameters.Clear();

                    cmd.Transaction = oConnManager.BeginTransaction();
                    try
                    {
                        cmd.CommandText = "sp_Item_DeleteWithImage";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Item_OID", oItem.Item_OID);
                        cmd.Parameters.Add("@IsSuccess", SqlDbType.Char, 1);
                        cmd.Parameters["@IsSuccess"].Direction = ParameterDirection.ReturnValue;
                        cmd.ExecuteNonQuery();
                        string st = cmd.Parameters["@IsSuccess"].Value.ToString();
                        oConnManager.Commit();
                        oResult.Data = st;
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
            public CResult Import(CItem oItem)
            {
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.Parameters.Clear();

                    cmd.Transaction = oConnManager.BeginTransaction();
                    try
                    {
                        cmd.CommandText = "sp_Item_Import";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Item_OID", oItem.Item_OID);
                        cmd.Parameters.AddWithValue("@Item_Branch", oItem.Item_Branch);
                        cmd.Parameters.AddWithValue("@Item_Code", oItem.Item_Code);
                        cmd.Parameters.AddWithValue("@Item_GroupID", oItem.Item_GroupID);
                        cmd.Parameters.AddWithValue("@Item_TypeID", oItem.Item_TypeID);
                        cmd.Parameters.AddWithValue("@Item_IsRaw", oItem.Item_IsRaw);
                        cmd.Parameters.AddWithValue("@Item_ItemName", oItem.Item_ItemName);
                        cmd.Parameters.AddWithValue("@Item_UOMID", oItem.Item_UOMID);
                        cmd.Parameters.AddWithValue("@Item_Sprice", oItem.Item_Sprice);
                        cmd.Parameters.AddWithValue("@Item_Pprice", oItem.Item_Pprice);
                        cmd.Parameters.AddWithValue("@Item_RQTY", oItem.Item_RQTY);
                        cmd.Parameters.AddWithValue("@Item_Creator", oItem.Creator);
                        cmd.Parameters.AddWithValue("@Item_CreationDate", oItem.CreationDate);
                        cmd.Parameters.AddWithValue("@Item_UpdateBy", oItem.UpdateBy);
                        cmd.Parameters.AddWithValue("@Item_UpdateDate", oItem.UpdateDate);
                        cmd.Parameters.AddWithValue("@Item_IsActive", oItem.IsActive);
                        cmd.Parameters.AddWithValue("@Item_Remarks", oItem.Remarks);
                        cmd.Parameters.AddWithValue("@Item_Priority", oItem.Item_Priority);

                        if (oItem.ItemImage != null)
                        {
                            cmd.Parameters.AddWithValue("@Image_HasImage", "Y");
                            cmd.Parameters.AddWithValue("@Image_Data", oItem.ItemImage);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Image_HasImage", "N");
                            cmd.Parameters.AddWithValue("@Image_Data", new byte[] { 1, 2, 3 });
                        }
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
                ArrayList oItemList = new ArrayList();


                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_Item_ReadAllItemDataWithPrice";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dtItem = ds.Tables[0];

                        //  oItemList.Add("");
                        foreach (DataRow dr in dtItem.Rows)
                        {
                            oItemList.Add(GetResultSetToItemForPrice(dr));
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oItemList;

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

            public CResult ReadAllItemList()
            {
                ArrayList oItemList = new ArrayList();


                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_Item_ReadAllItem";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dtItem = ds.Tables[0];

                        //  oItemList.Add("");
                        foreach (DataRow dr in dtItem.Rows)
                        {
                            oItemList.Add(GetResultSetToItemForPrice(dr));
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oItemList;

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
            public CResult ReadAllByItemCode(string oItemCode)
            {
                CItem oItem = new CItem();


                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_Item_ReadAllItemWithPriceByItemCode";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ItemCode", oItemCode);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dtItem = ds.Tables[0];

                        //  oItemList.Add("");
                        foreach (DataRow dr in dtItem.Rows)
                        {
                            oItem = GetResultSetToItemForPrice(dr);
                        }
                        oResult.IsSuccess = true;
                        oResult.Data = oItem;

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





            public CResult ReadAllByCond(string stCatOID )
            {
                ArrayList oItemList = new ArrayList();


                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_Item_ReadAllWithImage_ByCond";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CatOID",stCatOID);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dtItem = ds.Tables[0];

                        //  oItemList.Add("");
                        foreach (DataRow dr in dtItem.Rows)
                        {
                            oItemList.Add(GetResultSetToItem(dr));
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oItemList;

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

            //public CResult ReadAllByCatgAndDate(string stCatOID, DateTime fDate, DateTime tDate)
            //{
            //    ArrayList oItemList = new ArrayList();


            //    oResult = new CResult();
            //    conn = oConnManager.GetConnection(out s_DBError);
            //    if (conn != null)
            //    {
            //        try
            //        {
            //            DataSet ds = new DataSet();
            //            SqlCommand cmd = new SqlCommand();

            //            cmd.Connection = conn;
            //            cmd.CommandText = "sp_Item_ReadAllByCatgAndDate";
            //            cmd.CommandType = CommandType.StoredProcedure;

            //            cmd.Parameters.AddWithValue("@C_OID", stCatOID);
            //            cmd.Parameters.AddWithValue("@f_Date", fDate);
            //            cmd.Parameters.AddWithValue("@t_Date", tDate);

            //            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //            da.Fill(ds);
            //            DataTable dtItem = ds.Tables[0];

            //            //  oItemList.Add("");
            //            foreach (DataRow dr in dtItem.Rows)
            //            {
            //                CItem oItem = new CItem();

            //                oItem.Item_OID = dr[0].ToString();
            //                oItem.Item_Branch = dr[1].ToString();
            //                oItem.Item_Code = dr[2].ToString();
            //                oItem.Item_GroupID = dr[3].ToString();
            //                oItem.Item_TypeID = dr[4].ToString();
            //                oItem.Item_IsRaw = dr[5].ToString();
            //                oItem.Item_ItemName = dr[6].ToString();
            //                oItem.Item_UOMID = dr[7].ToString();
            //                oItem.Item_Sprice = float.Parse(dr[8].ToString());
            //                oItem.Item_Pprice = float.Parse(dr[9].ToString());
            //                oItem.Item_RQTY = float.Parse(dr[10].ToString());
            //                oItem.Creator = dr[11].ToString();
            //                oItem.CreationDate = DateTime.Parse(dr[12].ToString()).Date;

            //                oItemList.Add(oItem);
            //            }

            //            oResult.IsSuccess = true;
            //            oResult.Data = oItemList;

            //        }
            //        catch (SqlException e)
            //        {
            //            oResult.IsSuccess = false;
            //            oResult.ErrMsg = e.Message;
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

            public CResult ReadAllFG(CItem oItem)
            {
                ArrayList oItemList = new ArrayList();


                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_Item_ReadAllFGWithImage";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dtItem = ds.Tables[0];

                        //  oItemList.Add("");
                        foreach (DataRow dr in dtItem.Rows)
                        {
                            oItemList.Add(GetResultSetToItem(dr));
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oItemList;

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

            public CResult ReadAllRaw(CItem oItem)
            {
                ArrayList oItemList = new ArrayList();


                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_Item_ReadAllRaw";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dtItem = ds.Tables[0];

                        foreach (DataRow dr in dtItem.Rows)
                        {
                            oItemList.Add(GetResultSetToItem(dr));
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oItemList;

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

            private CItem GetResultSetToItem(DataRow dr)
            {
                CItem oItem = new CItem();

                oItem.Item_OID = dr[0].ToString();
                oItem.Item_Branch = dr[1].ToString();
                oItem.Item_Code = dr[2].ToString();
                oItem.Item_GroupID = dr[3].ToString();
                oItem.Item_TypeID = dr[4].ToString();
                oItem.Item_IsRaw = dr[5].ToString();
                oItem.Item_ItemName = dr[6].ToString();
                oItem.Item_UOMID = dr[7].ToString();
                oItem.Item_Sprice = float.Parse(dr[8].ToString());
                oItem.Item_Pprice = float.Parse(dr[9].ToString());
                oItem.Item_RQTY = float.Parse(dr[10].ToString());
                oItem.Creator = dr[11].ToString();
                oItem.CreationDate = DateTime.Parse(dr[12].ToString()).Date;
                oItem.UpdateBy = dr[13].ToString();
                oItem.UpdateDate = DateTime.Parse(dr[14].ToString()).Date;
                oItem.IsActive = dr[15].ToString();
                oItem.Remarks = dr[16].ToString();
                oItem.Item_Priority = int.Parse(dr[17].ToString());

                if (dr[18] != DBNull.Value)
                {
                    oItem.ItemImage = (byte[])(dr[18]);
                }

                return oItem;
            }

            private CItem GetResultSetToItemForPrice(DataRow dr)
            {
                CItem oItem = new CItem();

                oItem.Item_OID = dr[0].ToString();
                oItem.Item_Branch = dr[1].ToString();
                oItem.Item_Code = dr[2].ToString();
                oItem.Item_GroupID = dr[3].ToString();
                oItem.Item_TypeID = dr[4].ToString();
                oItem.Item_IsRaw = dr[5].ToString();
                oItem.Item_ItemName = dr[6].ToString();
                oItem.Item_UOMID = dr[7].ToString();
                oItem.Item_Sprice = float.Parse(dr[8].ToString());
                oItem.Item_Pprice = float.Parse(dr[9].ToString());
                oItem.Item_RQTY = float.Parse(dr[10].ToString());
                oItem.Creator = dr[11].ToString();
                oItem.CreationDate = DateTime.Parse(dr[12].ToString()).Date;
                oItem.UpdateBy = dr[13].ToString();
                oItem.UpdateDate = DateTime.Parse(dr[14].ToString()).Date;
                oItem.IsActive = dr[15].ToString();
                oItem.Remarks = dr[16].ToString();
                oItem.Item_Priority = int.Parse(dr[17].ToString());
                oItem.Item_Sprice = float.Parse(dr[20].ToString());
                oItem.Item_Pprice = float.Parse(dr[21].ToString());
                if (dr[22] != DBNull.Value)
                {
                    oItem.InvQty = float.Parse(dr[22].ToString());
                }
                if (dr[18] != DBNull.Value)
                {
                    oItem.ItemImage = (byte[])(dr[18]);
                }

                return oItem;
            }
            #endregion

            #region "ItemGroup"
            public CResult ReadAll(CItemGroup oItemGroup)
            {

                ArrayList oItemGroupList = new ArrayList();
                CResult oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_ItemGroup_ReadAll";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dtItem = ds.Tables[0];

                        foreach (DataRow dr in dtItem.Rows)
                        {
                            oItemGroupList.Add(GetResultSetToItemGroup(dr));
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oItemGroupList;

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
            public CResult Create(CItemGroup oItemGroup)
            {
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.Parameters.Clear();

                    cmd.Transaction = oConnManager.BeginTransaction();
                    try
                    {
                        cmd.CommandText = "sp_ItemGroup_Insert";
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@Catg_Branch", oItemGroup.Catg_Branch);
                        cmd.Parameters.AddWithValue("@Catg_Code", oItemGroup.Catg_Code);
                        cmd.Parameters.AddWithValue("@Catg_Name", oItemGroup.Catg_Name);

                        cmd.Parameters.AddWithValue("@Catg_Creator", oItemGroup.Creator);
                        cmd.Parameters.AddWithValue("@Catg_CreationDate", oItemGroup.CreationDate);
                        cmd.Parameters.AddWithValue("@Catg_UpdateBy", oItemGroup.UpdateBy);
                        cmd.Parameters.AddWithValue("@Catg_UpdateDate", oItemGroup.UpdateDate);
                        cmd.Parameters.AddWithValue("@Catg_IsActive", oItemGroup.IsActive);
                        cmd.Parameters.AddWithValue("@Catg_Remarks", oItemGroup.Remarks);

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

            public CResult Update(CItemGroup oItemGroup)
            {
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.Parameters.Clear();

                    cmd.Transaction = oConnManager.BeginTransaction();
                    try
                    {
                        cmd.CommandText = "sp_ItemGroup_Update";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Catg_OID", oItemGroup.Catg_OID);
                        cmd.Parameters.AddWithValue("@Catg_Branch", oItemGroup.Catg_Branch);
                        cmd.Parameters.AddWithValue("@Catg_Code", oItemGroup.Catg_Code);
                        cmd.Parameters.AddWithValue("@Catg_Name", oItemGroup.Catg_Name);
                        cmd.Parameters.AddWithValue("@Catg_Creator", oItemGroup.Creator);
                        cmd.Parameters.AddWithValue("@Catg_CreationDate", oItemGroup.CreationDate);
                        cmd.Parameters.AddWithValue("@Catg_UpdateBy", oItemGroup.UpdateBy);
                        cmd.Parameters.AddWithValue("@Catg_UpdateDate", oItemGroup.UpdateDate);
                        cmd.Parameters.AddWithValue("@Catg_IsActive", oItemGroup.IsActive);
                        cmd.Parameters.AddWithValue("@Catg_Remarks", oItemGroup.Remarks);

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

            public CResult Delete(CItemGroup oItemGroup)
            {
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.Parameters.Clear();

                    cmd.Transaction = oConnManager.BeginTransaction();
                    try
                    {
                        cmd.CommandText = "sp_ItemGroup_Delete";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Catg_OID", oItemGroup.Catg_OID);
                        cmd.Parameters.Add("@IsSuccess", SqlDbType.Char, 1);
                        cmd.Parameters["@IsSuccess"].Direction = ParameterDirection.ReturnValue;
                        cmd.ExecuteNonQuery();
                        string st = cmd.Parameters["@IsSuccess"].Value.ToString();

                        oConnManager.Commit();
                        oResult.Data = st;
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

            public CResult Import(CItemGroup oItemGroup)
            {
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.Parameters.Clear();

                    cmd.Transaction = oConnManager.BeginTransaction();
                    try
                    {
                        cmd.CommandText = "sp_ItemGroup_Import";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Catg_OID", oItemGroup.Catg_OID);
                        cmd.Parameters.AddWithValue("@Catg_Branch", oItemGroup.Catg_Branch);
                        cmd.Parameters.AddWithValue("@Catg_Code", oItemGroup.Catg_Code);
                        cmd.Parameters.AddWithValue("@Catg_Name", oItemGroup.Catg_Name);
                        cmd.Parameters.AddWithValue("@Catg_Creator", oItemGroup.Creator);
                        cmd.Parameters.AddWithValue("@Catg_CreationDate", oItemGroup.CreationDate);
                        cmd.Parameters.AddWithValue("@Catg_UpdateBy", oItemGroup.UpdateBy);
                        cmd.Parameters.AddWithValue("@Catg_UpdateDate", oItemGroup.UpdateDate);
                        cmd.Parameters.AddWithValue("@Catg_IsActive", oItemGroup.IsActive);
                        cmd.Parameters.AddWithValue("@Catg_Remarks", oItemGroup.Remarks);

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

            #region "ItemType"
            public CResult ReadAll(CItemType oitemType)
            {

              ArrayList oItemTypeList = new ArrayList();
              CResult oResult = new CResult();
              conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_ItemType_ReadAll";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dtItem = ds.Tables[0];

                        foreach (DataRow dr in dtItem.Rows)
                        {
                            oItemTypeList.Add(GetResultSetToItemType(dr));
                        }

                        oResult.Data = oItemTypeList;
                        oResult.IsSuccess = true;

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
            public CResult Create(CItemType oitemType)
            {
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.Parameters.Clear();

                    cmd.Transaction = oConnManager.BeginTransaction();
                    try
                    {
                        cmd.CommandText = "sp_ItemType_Insert";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ITyp_Code", oitemType.ITyp_Code);
                        cmd.Parameters.AddWithValue("@ITyp_Name", oitemType.ITyp_Name);
                        cmd.Parameters.AddWithValue("@ITyp_Branch", oitemType.ITyp_Branch);
                        cmd.Parameters.AddWithValue("@Creator", oitemType.Creator);
                        cmd.Parameters.AddWithValue("@CreationDate", oitemType.CreationDate);
                        cmd.Parameters.AddWithValue("@UpdateBy", oitemType.UpdateBy);
                        cmd.Parameters.AddWithValue("@UpdateDate", oitemType.UpdateDate);
                        cmd.Parameters.AddWithValue("@IsActive", oitemType.IsActive);
                        cmd.Parameters.AddWithValue("@Remarks", oitemType.Remarks);
                        
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

            public CResult Update(CItemType oitemType)
            {
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.Parameters.Clear();

                    cmd.Transaction = oConnManager.BeginTransaction();
                    try
                    {
                        cmd.CommandText = "sp_ItemType_Update";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ITyp_OID", oitemType.ITyp_OID);
                        cmd.Parameters.AddWithValue("@ITyp_Code", oitemType.ITyp_Code);
                        cmd.Parameters.AddWithValue("@ITyp_Name", oitemType.ITyp_Name);
                        cmd.Parameters.AddWithValue("@ITyp_Branch", oitemType.ITyp_Branch);
                        cmd.Parameters.AddWithValue("@Creator", oitemType.Creator);
                        cmd.Parameters.AddWithValue("@CreationDate", oitemType.CreationDate);
                        cmd.Parameters.AddWithValue("@UpdateBy", oitemType.UpdateBy);
                        cmd.Parameters.AddWithValue("@UpdateDate", oitemType.UpdateDate);
                        cmd.Parameters.AddWithValue("@IsActive", oitemType.IsActive);
                        cmd.Parameters.AddWithValue("@Remarks", oitemType.Remarks);

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
            public CResult Delete(CItemType oitemType)
            {
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.Parameters.Clear();

                    cmd.Transaction = oConnManager.BeginTransaction();
                    try
                    {
                        cmd.CommandText = "sp_ItemType_Delete";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ITyp_OID", oitemType.ITyp_OID);

                        cmd.Parameters.Add("@IsSuccess", SqlDbType.Char, 1);
                        cmd.Parameters["@IsSuccess"].Direction = ParameterDirection.ReturnValue;
                        cmd.ExecuteNonQuery();
                        string st = cmd.Parameters["@IsSuccess"].Value.ToString();

                        oConnManager.Commit();
                        oResult.Data = st;
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

            public CResult Import(CItemType oitemType)
            {
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.Parameters.Clear();

                    cmd.Transaction = oConnManager.BeginTransaction();
                    try
                    {
                        cmd.CommandText = "sp_ItemType_Import";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ITyp_OID", oitemType.ITyp_OID);
                        cmd.Parameters.AddWithValue("@ITyp_Code", oitemType.ITyp_Code);
                        cmd.Parameters.AddWithValue("@ITyp_Name", oitemType.ITyp_Name);
                        cmd.Parameters.AddWithValue("@ITyp_Branch", oitemType.ITyp_Branch);
                        cmd.Parameters.AddWithValue("@Creator", oitemType.Creator);
                        cmd.Parameters.AddWithValue("@CreationDate", oitemType.CreationDate);
                        cmd.Parameters.AddWithValue("@UpdateBy", oitemType.UpdateBy);
                        cmd.Parameters.AddWithValue("@UpdateDate", oitemType.UpdateDate);
                        cmd.Parameters.AddWithValue("@IsActive", oitemType.IsActive);
                        cmd.Parameters.AddWithValue("@Remarks", oitemType.Remarks);

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


            public CResult ReadAllFGForSalesByBranch(string sBranchOID)
            {
                List<CItemSales> oItemList = new List<CItemSales>();


                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_Item_ReadAllFGForSalesByBranchOID";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BranchOID", sBranchOID);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dtItem = ds.Tables[0];

                        //  oItemList.Add("");
                        foreach (DataRow dr in dtItem.Rows)
                        {
                            oItemList.Add(GetResultSetToSalesItem(dr));
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oItemList;

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
            public CResult ReadAllFGForSalesByBranchAndItem(string sBranchOID,string sItemOID)
            {
                List<CItemSales> oItemList = new List<CItemSales>();


                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_Item_ReadAllFGForSalesByBranchAndItem";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BranchOID", sBranchOID);
                        cmd.Parameters.AddWithValue("@ItemCode",sItemOID);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dtItem = ds.Tables[0];

                        //  oItemList.Add("");
                        foreach (DataRow dr in dtItem.Rows)
                        {
                            oItemList.Add(GetResultSetToSearchItem(dr));
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oItemList;

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
            public CResult ReadAllFGForSalesByBranchAndName(string sBranchOID, string sItemName)
            {
                List<CItemSales> oItemList = new List<CItemSales>();


                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_Item_ReadAllFGForSalesByBranchAndName";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BranchOID", sBranchOID);
                        cmd.Parameters.AddWithValue("@ItemName", sItemName);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dtItem = ds.Tables[0];

                        //  oItemList.Add("");
                        foreach (DataRow dr in dtItem.Rows)
                        {
                            oItemList.Add(GetResultSetToSearchItem(dr));
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oItemList;

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
            private CItemSales GetResultSetToSearchItem(DataRow dr)
            {
                CItemSales oItem = new CItemSales();

                oItem.Item_OID = dr[0].ToString();
                oItem.Item_Branch = dr[1].ToString();
                oItem.Item_Code = dr[2].ToString();
                oItem.Item_ItemName = dr[3].ToString();
                oItem.Item_UOMOID = dr[4].ToString();
                oItem.Item_GroupID = dr[5].ToString();
                oItem.Item_TypeID = dr[6].ToString();
                oItem.Item_Priority = int.Parse(dr[7].ToString());

                if (dr[8] != DBNull.Value)
                {
                    oItem.ItemImage = (byte[])(dr[8]);
                }
                oItem.Item_Price = float.Parse(dr[9].ToString());
                oItem.Item_VatPercent = float.Parse(dr[10].ToString());
                oItem.Item_CurrencyOID = dr[11].ToString();
                oItem.Item_ExistQTY = float.Parse(dr[12].ToString());
                oItem.Item_PPrice = float.Parse(dr["Pprice"].ToString());

                return oItem;
            }
            public CResult ReadAllFByCatg(string sBranchOID, string sCatgOID)
            {
                List<CItemSales> oItemList = new List<CItemSales>();


                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_Item_ReadAllFGByCatg";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BranchOID", sBranchOID);
                        cmd.Parameters.AddWithValue("@ItemGroup", sCatgOID);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dtItem = ds.Tables[0];

                        //  oItemList.Add("");
                        foreach (DataRow dr in dtItem.Rows)
                        {
                            oItemList.Add(GetResultSetToSearchItem(dr));
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oItemList;

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
            public CResult ReadAllFByCatgAndDate(string sBranchOID,string sCatgOID, DateTime fromDate,DateTime toDate)
            {
                List<CItemSales> oItemList = new List<CItemSales>();


                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_Item_ReadAllFGByCatgAndDate";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BranchOID", sBranchOID);
                        cmd.Parameters.AddWithValue("@CatgOID",sCatgOID);
                        cmd.Parameters.AddWithValue("@FromDate", fromDate);
                        cmd.Parameters.AddWithValue("@ToDate",toDate);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dtItem = ds.Tables[0];

                        //  oItemList.Add("");
                        foreach (DataRow dr in dtItem.Rows)
                        {
                            oItemList.Add(GetResultSetToSearchItem(dr));
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oItemList;

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
            private CItemSales GetResultSetToSalesItem(DataRow dr)
            {
                CItemSales oItem = new CItemSales();

                oItem.Item_OID = dr[0].ToString();
                oItem.Item_Branch = dr[1].ToString();
                oItem.Item_Code = dr[2].ToString();
                oItem.Item_ItemName = dr[3].ToString();
                oItem.Item_UOMOID = dr[4].ToString();
                oItem.Item_GroupID = dr[5].ToString();
                oItem.Item_TypeID = dr[6].ToString();
                oItem.Item_Priority = int.Parse(dr[7].ToString());

                if (dr[8] != DBNull.Value)
                {
                    oItem.ItemImage = (byte[])(dr[8]);
                }
                oItem.Item_Price = float.Parse(dr[9].ToString());
                oItem.Item_VatPercent = float.Parse(dr[10].ToString());
                oItem.Item_CurrencyOID = dr[11].ToString();
                oItem.Item_ExistQTY = float.Parse(dr[12].ToString());

                return oItem;
            }

            public CResult ReadAllImages()
            {
                List<CImage> oListImage = new List<CImage>();
                
                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_Images_ReadAll";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dtItem = ds.Tables[0];

                        //  oItemList.Add("");
                        foreach (DataRow dr in dtItem.Rows)
                        {
                            oListImage.Add(GetResultSetToImage(dr));
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oListImage;

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
            private CImage GetResultSetToImage(DataRow dr)
            {
                CImage oImage = new CImage();
                oImage.Images_OId = dr[0].ToString();
                if (dr[1] != DBNull.Value)
                {
                    oImage.Images_Data = (byte[])(dr[1]);
                }
                return oImage;
            }

            public CResult ReadAllForStickerByBranch(DateTime FromDate,DateTime ToDate, string sBranchOID)
            {
                List<CItemSales> oItemList = new List<CItemSales>();


                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_Read_GRItemName";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FromDate", FromDate);
                        cmd.Parameters.AddWithValue("@ToDate", ToDate);
                        cmd.Parameters.AddWithValue("@Branch", sBranchOID);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dtItem = ds.Tables[0];

                        //  oItemList.Add("");
                        foreach (DataRow dr in dtItem.Rows)
                        {
                            oItemList.Add(GetResultSetToStickerItem(dr));
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oItemList;

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

            private CItemSales GetResultSetToStickerItem(DataRow dr)
            {
                CItemSales oItemSates = new CItemSales();
                oItemSates.Item_OID = dr["GRDet_ItemOID"].ToString();
                oItemSates.Item_Branch = dr["Price_Branch"].ToString();
                oItemSates.Item_Code = dr["Item_Code"].ToString();
                oItemSates.Item_ItemName = dr["Item_ItemName"].ToString();
                oItemSates.TotalItem = int.Parse( dr["GRDet_QTY"].ToString());
                oItemSates.Item_Price = float.Parse(dr["Price"].ToString());
                oItemSates.Item_VatPercent = float.Parse(dr["Vat"].ToString());

                return oItemSates;
                
            }

            public DataTable ReadAllItemWithGroup()
            {
                DataTable dtItem = new DataTable();
                ArrayList oItemList = new ArrayList();

                oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "[dbo].[sp_Item_ReadAllItemDataWithPriceAndgroup]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        dtItem = ds.Tables[0];
                        oResult.IsSuccess = true;

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

                return dtItem;

            }


            public CResult ReadAllItemSize()
            {
                ArrayList oUOMList = new ArrayList();
                CResult oResult = new CResult();
                conn = oConnManager.GetConnection(out s_DBError);
                if (conn != null)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "sp_ItemSize_ReadAll";

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dt = ds.Tables[0];

                        foreach (DataRow dr in dt.Rows)
                        {
                            oUOMList.Add(GetResultSetToSize(dr));
                        }

                        oResult.IsSuccess = true;
                        oResult.Data = oUOMList;

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

            private CSize GetResultSetToSize(DataRow dr)
            {
                CSize oCSize = new CSize();

                oCSize.Size_OID = dr[0].ToString();
                oCSize.Size_Code = dr[1].ToString();
                oCSize.Size_Name = dr[2].ToString();
                oCSize.Size_Branch = dr[3].ToString();
                oCSize.Creator = dr[4].ToString();
                oCSize.CreationDate = DateTime.Parse(dr[5].ToString()).Date;
                oCSize.UpdateBy = dr[6].ToString();
                oCSize.UpdateDate = DateTime.Parse(dr[7].ToString()).Date;
                oCSize.IsActive = dr[8].ToString();
                oCSize.Remarks = dr[9].ToString();

                return oCSize;
            }


        }
    }
}
