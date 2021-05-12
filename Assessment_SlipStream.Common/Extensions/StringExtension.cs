using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Assessment_SlipStream.Common.Extensions
{
    public static class StringExtension
    {
        public static string ToCSVString<T>(this List<T> types, List<string> IgnoreList) where T : class
        {
            var csv = new StringBuilder();

            types.ForEach(item =>
            {
                csv.AppendLine(item.ToCSVString(IgnoreList));
            });
            return csv.ToString();
        }
        public static string ToCSVString<T>(this T type, List<string> IgnoreList) where T : class
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            return string.Join(",", properties.Where(p => !IgnoreList.Contains(p.Name)).Select(p => p.GetValue(type)));
        }
    }
}
