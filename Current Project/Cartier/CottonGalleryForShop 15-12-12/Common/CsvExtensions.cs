using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace Common
{
   public static class CsvExtensions
    {
       public static string ToCSV(this DataTable dt)
       {
           StringBuilder sb = new StringBuilder();

           string[] columnNames = dt.Columns.Cast<DataColumn>().
                                             Select(column => column.ColumnName).
                                             ToArray();
           sb.AppendLine(string.Join(",", columnNames));

           foreach (DataRow row in dt.Rows)
           {
               string[] fields = row.ItemArray.Select(field => field.ToString()).
                                               ToArray();
               sb.AppendLine(string.Join(",", fields));
           }
          return sb.ToString();
       }
    }
}
