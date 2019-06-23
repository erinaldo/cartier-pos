using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;

namespace Common
{
   public static class ExtensionClass
    {
       public static List<TSource> ToList<TSource>(this DataTable dataTable) where TSource : new()
       {
           var dataList = new List<TSource>();
           const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;
           var objFieldNames = (from PropertyInfo aProp in typeof(TSource).GetProperties()
                                select new
                                {
                                    Name = aProp.Name,
                                    Type = Nullable.GetUnderlyingType(aProp.PropertyType) ?? aProp.PropertyType
                                }).ToList();
           var dataTblFieldNames = (from DataColumn aHeader in dataTable.Columns
                                    select new { Name = aHeader.ColumnName, Type = aHeader.DataType }).ToList();
           var commonFields = objFieldNames.Intersect(dataTblFieldNames).ToList();

           foreach (DataRow dataRow in dataTable.AsEnumerable().ToList())
           {
               var aTSource = new TSource();
               foreach (var aField in commonFields)
               {
                   PropertyInfo propertyInfos = aTSource.GetType().GetProperty(aField.Name);
                   propertyInfos.SetValue(aTSource, dataRow[aField.Name], null);
               }
               dataList.Add(aTSource);
           }
           
           return dataList;
       }

         public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
    {
        try
        {
            List<T> list = new List<T>();

            foreach (var row in table.AsEnumerable())
            {
                T obj = new T();

                foreach (var prop in obj.GetType().GetProperties())
                {
                    try
                    {
                        PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                        propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                    }
                    catch
                    {
                        continue;
                    }
                }

                list.Add(obj);
            }

            return list;
        }
        catch
        {
            return null;
        }
    }

    }
}
