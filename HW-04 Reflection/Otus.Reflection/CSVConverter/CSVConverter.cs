using Microsoft.AspNetCore.HttpLogging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Otus.HW.Reflections
{
    public class CSVConverter
    {
        private static readonly char _equalSign = '=';
        private static readonly char _delemiter = ';';

        /// <summary>
        /// Десериализация объекта
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public static T DeserializeToObject<T>(string str) where T : new()
        {
            if (str == null)
            {
                throw new ArgumentNullException($"{str} can't be null");
            }

            T t = new();
            Type type = typeof(T);

            try
            {
                string[] strArray = str.Split(_delemiter);
                foreach (var s in strArray)
                {
                    string[] sArray = s.Split(_equalSign);
                    if (sArray.Length > 1)
                    {
                        FieldInfo field = type.GetField(sArray[0], BindingFlags.Public | BindingFlags.Instance);
                        if (field != null)
                        {
                            field.SetValue(t, Convert.ChangeType(sArray[1], field.FieldType));
                        }
                        
                        PropertyInfo property = type.GetProperty(sArray[0], BindingFlags.Public | BindingFlags.Instance);
                        if (property != null)
                        {
                            property.SetValue(t, Convert.ChangeType(sArray[1], property.PropertyType));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception($" Can't deserialize {str}, reason : {e.Message}");
            }
            

            return t;
        }

       /// <summary>
       /// Сериализация объекта
       /// </summary>
       /// <param name="obj"></param>
       /// <returns></returns>
       /// <exception cref="ArgumentNullException"></exception>
        public static string SerializeObject(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException($"{obj} can't be null");
            }

            StringBuilder sb = new StringBuilder();
            
            Type type = obj.GetType();
            //получить свойста
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                var propValue = property.GetValue(obj)?.ToString()?? string.Empty;
                sb.Append($"{property.Name}{_equalSign}{propValue}{_delemiter}");
            }

            //получить поля
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (var field in fields)
            {
                var fieldValue = field.GetValue(obj)?.ToString() ?? string.Empty;
                sb.Append($"{field.Name}{_equalSign}{fieldValue}{_delemiter}");
            }

            return sb.ToString();
        }
    }
}
