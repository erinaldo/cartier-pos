using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using Common;
using ETL.Model;
using ETL.BLL;
using ETL.Common;

namespace ETLPOS
{
    public partial class ExportItem : Form
    {
        public ExportItem()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Save an CSV File";
            saveFileDialog1.FileName = "ItemExport.csv";
            saveFileDialog1.Filter = "Text files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog1.ShowDialog();
            string url = "";
            if (saveFileDialog1.FileName != "")
            {
                url = saveFileDialog1.FileName;
            }
            else
            {
                url = "ItemExport.csv";
            }
            CItemBO item = new CItemBO();
            DataTable dt = item.ReadAllItemWithGroup();
            string sb = dt.ToCSV();
            File.WriteAllText(url, sb, Encoding.Default);
            MessageBox.Show("File export sucessfully done");
            //csv.Export();
            //csv.ExportToFile(url);   
        }
        
        private string MakeValueCsvFriendly(object value)
        {
            if (value == null) return "";
            if (value is Nullable && ((System.Data.SqlTypes.INullable)value).IsNull) return "";

            if (value is DateTime)
            {
                if (((DateTime)value).TimeOfDay.TotalSeconds == 0)
                    return ((DateTime)value).ToString("yyyy-MM-dd");
                return ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
            }
            string output = value.ToString();

            if (output.Contains(",") || output.Contains("\""))
                output = '"' + output.Replace("\"", "\"\"") + '"';

            return output;

        }


        private void LoadComapanyBranch()
        {
            CResult oResult = new CResult();
            CCompanyBranchBO oCompanyBranchBO = new CCompanyBranchBO();
            oResult = oCompanyBranchBO.ReadAll();

            if (oResult.IsSuccess)
            {
                cmbBranch.DataSource = oResult.Data as List<CCompanyBranch>;
                cmbBranch.DisplayMember = "CompBrn_Code";
                cmbBranch.ValueMember = "CompBrn_OId";
            }
            else
            {
                MessageBox.Show("Loading error...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportItem_Load(object sender, EventArgs e)
        {
            LoadComapanyBranch();
        }
    }
        public class CsvExport<T> where T : class
        {
            public List<T> Objects;

            public CsvExport(List<T> objects)
            {
                Objects = objects;
            }

            public string Export()
            {
                return Export(true);
            }

            public string Export(bool includeHeaderLine)
            {

                StringBuilder sb = new StringBuilder();
                //Get properties using reflection.
                IList<PropertyInfo> propertyInfos = typeof(T).GetProperties();

                if (includeHeaderLine)
                {
                    //add header line.
                    foreach (PropertyInfo propertyInfo in propertyInfos)
                    {
                        sb.Append(propertyInfo.Name).Append(",");
                    }
                    sb.Remove(sb.Length - 1, 1).AppendLine();
                }

                //add value for each property.
                foreach (T obj in Objects)
                {
                    foreach (PropertyInfo propertyInfo in propertyInfos)
                    {
                        sb.Append(MakeValueCsvFriendly(propertyInfo.GetValue(obj, null))).Append(",");
                    }
                    sb.Remove(sb.Length - 1, 1).AppendLine();
                }

                return sb.ToString();
            }

            //export to a file.
            public void ExportToFile(string path)
            {
                File.WriteAllText(path, Export());
            }

            //export as binary data.
            public byte[] ExportToBytes()
            {
                return Encoding.UTF8.GetBytes(Export());
            }

            //get the csv value for field.
            private string MakeValueCsvFriendly(object value)
            {
                if (value == null) return "";
                if (value is Nullable && ((System.Data.SqlTypes.INullable)value).IsNull) return "";

                if (value is DateTime)
                {
                    if (((DateTime)value).TimeOfDay.TotalSeconds == 0)
                        return ((DateTime)value).ToString("yyyy-MM-dd");
                    return ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
                }
                string output = value.ToString();

                if (output.Contains(",") || output.Contains("\""))
                    output = '"' + output.Replace("\"", "\"\"") + '"';

                return output;

            }
        }
    }

