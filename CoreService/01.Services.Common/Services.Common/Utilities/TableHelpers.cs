using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Services.Common.Utilities
{
    public static class TableHelpers
    {
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        object value = dr[column.ColumnName];
                        if (value == DBNull.Value)
                            value = null;

                        pro.SetValue(obj, value, null);
                    }
                    else
                        continue;
                }
            }
            return obj;
        }
        public static DataTable ConvertToDataTable<T>(this IEnumerable<T> dataList) where T : class
        {
            DataTable convertedTable = new DataTable();
            PropertyInfo[] propertyInfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in propertyInfo)
            {
                convertedTable.Columns.Add(prop.Name);
            }
            foreach (T item in dataList)
            {
                var row = convertedTable.NewRow();
                var values = new object[propertyInfo.Length];
                for (int i = 0; i < propertyInfo.Length; i++)
                {
                    var test = propertyInfo[i].GetValue(item, null);
                    row[i] = propertyInfo[i].GetValue(item, null);
                }
                convertedTable.Rows.Add(row);
            }
            return convertedTable;
        }
    }
}