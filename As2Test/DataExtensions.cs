using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.ComponentModel;

namespace As2Test
{
  
  public static partial class Extensions
    {
        public static DataTable ExecuteDataTable(this SqlCommand @this)
        {
            var dt = new DataTable();
            using (var dataAdapter = new SqlDataAdapter(@this))
            {
                dataAdapter.Fill(dt);
            }

            return dt;
        }
    
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection props =
            TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }
      
    }


}
