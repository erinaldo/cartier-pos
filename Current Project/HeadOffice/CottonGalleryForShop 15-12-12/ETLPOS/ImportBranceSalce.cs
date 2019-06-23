using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ETL.Model;
using ETL.Common;
using ETL.BLL;
using Common;

namespace ETLPOS
{
    public partial class ImportBranceSalce : Form
    {
        public ImportBranceSalce()
        {
            InitializeComponent();
        }

        private void btnSalesExport_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string fileName = openFileDialog1.FileName;
            DataTable dt = TransferCSVToTable(fileName);

            List<DataTable> dts = new List<DataTable>();
            dts = SplitTable(dt, 6);
        }

        public DataTable TransferCSVToTable(string filePath)
        {
            DataTable dt = new DataTable();

            string[] csvRows = System.IO.File.ReadAllLines(filePath);
            int i = 1;
            foreach (string columnsRow in csvRows)
            {
                if (i == 1)
                {
                    string[] columns = columnsRow.Split(',');
                    foreach (string column in columns)
                        dt.Columns.Add(column);
                }
                else
                {
                    string[] fields = null;
                    //foreach (string csvRow in csvRows)
                    //{
                    fields = columnsRow.Split(',');
                    DataRow row = dt.NewRow();
                    row.ItemArray = fields;
                    dt.Rows.Add(row);
                    // }

                }
                i++;
                dt.AcceptChanges();
            }
            return dt;
        }

        private static List<DataTable> SplitTable(DataTable table, int batchSize)
        {
            List<DataTable> dts = new List<DataTable>();
            DataColumn[] itemcols = table.Columns.Cast<DataColumn>()
                                 .Where(c => c.ColumnName.StartsWith("SOM"))
                                 .Select(c => new DataColumn(c.ColumnName, c.DataType))
                                 .ToArray();
            DataColumn[] uoCols = table.Columns.Cast<DataColumn>()
                .Where(c => c.ColumnName.StartsWith("SOD"))
                .Select(c => new DataColumn(c.ColumnName, c.DataType))
                .ToArray();


            var t_SOMstr = new DataTable();
            t_SOMstr.Columns.AddRange(itemcols);

            var t_SODet = new DataTable();
            t_SODet.Columns.AddRange(uoCols);



            foreach (DataRow row in table.Rows)
            {
                DataRow aRow = t_SOMstr.Rows.Add();
                DataRow bRow = t_SODet.Rows.Add();


                foreach (DataColumn aCol in itemcols)
                    aRow.SetField(aCol, row[aCol.ColumnName]);
                foreach (DataColumn bCol in uoCols)
                    bRow.SetField(bCol, row[bCol.ColumnName]);
            }
            // DataTable dt = new DataTable();
            List<CSOMaster> items = t_SOMstr.DataTableToList<CSOMaster>();

            string TobeDistinct = "SOMstr_OID";
           // DataTable dtDistinct = GetDistinctRecords(t_SOMstr, TobeDistinct);
             
            //Following function will return Distinct records for Name, City and State column.
            var distinctList = from p in items
                               group p by new { p.SOMstr_Code } //or group by new {p.ID, p.Name, p.Whatever}
                                   into mygroup
                                   select mygroup.FirstOrDefault();
            foreach (var item in items)
            {

                CSOMaster oitem = item;
                CSOBO oitembo = new CSOBO();
                CResult oresult = new CResult();
                oitem.CreationDate = Convert.ToDateTime(t_SOMstr.Rows[0]["SOMstr_CreationDate"].ToString());
                oitem.Creator = t_SOMstr.Rows[0]["SOMstr_Creator"].ToString();
                oitem.UpdateBy = t_SOMstr.Rows[0]["SOMstr_UpdateBy"].ToString();
                oitem.UpdateDate = Convert.ToDateTime(t_SOMstr.Rows[0]["SOMstr_UpdateDate"].ToString());
                oitem.IsActive = t_SOMstr.Rows[0]["SOMstr_IsActive"].ToString();
                oitem.Remarks = t_SOMstr.Rows[0]["SOMstr_Remarks"].ToString();

                List<CSODetails> umos = t_SODet.DataTableToList<CSODetails>();
                foreach (var sodetails in umos)
                {
                    CSODetails ouom = sodetails;
                    oitem.SOMstr_DetailsList.Add(ouom);
                    //oresult = oitembo.CreateImport(ouom);
                }
                oresult = oitembo.CreateSalesImport(oitem);
            }
            // dts.Add(t_Item);
            //dts.Add(t_UOM);




            return dts;
        }

        public static DataTable GetDistinctRecords(DataTable dt, string Columns)
        {
            var distinctValues = dt.AsEnumerable()
                           .Select(row => new
                           {
                               attribute1_name = row.Field<string>(Columns)
                           })
                           .Distinct();
            DataTable dts = new DataTable();
            foreach (var item in distinctValues.ToList())
            {
                dts.Rows.Add(item);
                dts.AcceptChanges();
            }

            return dts;
        }
    }
}
