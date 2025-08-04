using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain._Helpers
{
    public static class ConvertingClass
    {

        public static DataTable ListToDataTable<T> (this List<T> list) {
            DataTable dt = new DataTable();

            PropertyInfo[] props = typeof(T).GetProperties();

            foreach (PropertyInfo prop in props) {
                dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            foreach (T item in list) { 
             var values= new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    values[i]= props[i].GetValue(item,null); 
                }
                dt.Rows.Add(values);
            } 

            return dt;  
        } 


    }
}
