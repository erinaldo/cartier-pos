using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using ETL.BLL;
using ETL.Model;
using ETL.Common;
using ETL.DAO;

namespace ETLPOS
{
    public partial class ItemUpdate : Form
    {
        public ItemUpdate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn=null;
            CConManager oConnManager=new CConManager();

            string s_DBError = "";

            string Item_OID = "";
            string ItemCode = txtStartCode.Text;
            int st = Convert.ToInt32(txtStart.Text);
            int en = Convert.ToInt32(txtend.Text);
            conn = oConnManager.GetConnection(out s_DBError);
             if (conn != null)
             {

                 for (; st <= en; st++)
                 {


                     string strItemCode = ItemCode.Substring(0, 4);
                     string strCode = "" + Convert.ToString(Convert.ToInt32(ItemCode.Substring(4)) + 1);
                     for (int j = 5; j > (strCode.Length); j--)
                     {
                         strItemCode += "0";
                     }
                     ItemCode = strItemCode + strCode;

                     for (int j = 10; j > (st.ToString().Length); j--)
                     {
                         Item_OID += "0";
                     }
                     Item_OID += st.ToString();

                     string sql = "UPDATE t_Item SET Item_Code = '"+ItemCode+"' WHERE Item_OID='ItemXXXXBRN01 "+Item_OID+"'";

                     try
                     {
                         SqlCommand cmd = new SqlCommand();

                         cmd.Connection = conn;
                         cmd.CommandText = sql;
                         cmd.CommandType = CommandType.Text;
                         cmd.ExecuteNonQuery();
                        

                     }
                     catch (SqlException ewe)
                     {
                        
                     }
                     Item_OID = "";

                 }
             }
             oConnManager.Close();
             txtStartCode.Text = ItemCode;
        }
    }
}
