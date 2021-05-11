using OfficeOpenXml;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SystemHelpers;

namespace DataLodaer
{
    static class EPPlusHelper
    {
        private readonly static ConcurrentDictionary<Type, Func<string, object>> Parsers = new();
        public static IEnumerable<T> GetTable<T>(this ExcelWorksheet worksheet) where T : class, new()
        {
            var set = typeof(Helper).GetMethod(nameof(Helper.SetPropertyValue));
            const int FirstDataRow = 2;
            int columnCount = worksheet.Dimension.Columns;
            int rowsCount = worksheet.Dimension.Rows;
            var titles = new Dictionary<string, int>();
            for (int i = 1; i < columnCount; i++)
                titles.Add(worksheet.GetValue<string>(1, i), i);
            var properties = (from p in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                             let name = p.GetPropertyDisplayName()
                             where p.CanWrite && p.CanRead && titles.ContainsKey(name)
                             let number = titles[name]
                             orderby number
                             select (p.Name, Type: p.PropertyType, ColumnNumber: number)).ToArray();
            //var t = titles.Where(t => !properties.Select(p => p.ColumnNumber).Contains(t.Value)).ToList();
            for (int row = FirstDataRow; row < rowsCount; row++)
            {
                var instance = Helper.ActivateInstance<T>();
                foreach (var (name, type, column) in properties)
                {
                    object value = worksheet.GetValue(row, column).FixType(type);
                    
                    if (type != typeof(string) && value is string str)
                        value = Parsers.GetOrAdd(type, Parse)(str);
                    else if (value == null)
                    {
                        value = type == typeof(string) ? "" : Helper.ActivateInstance(type);
                    }
                    var setT = set.MakeGenericMethod(new[] { typeof(T), value?.GetType() ?? type });
                    _ = setT.Invoke(null, new object[] { instance, name, value });
                }
                yield return instance;
            }
        }

        private static Func<string, object> Parse(Type type)
        {
            var parse = (from m in type.GetMethods()
                         let ps = m.GetParameters()
                         where m.Name == "Parse" && ps.Length == 1 && ps[0].ParameterType == typeof(string)
                         select m).FirstOrDefault();
            return value => parse?.Invoke(null, new[] { value }) ?? throw new InvalidCastException("Данный тип не имеет метода парса");
        }
    }
}
