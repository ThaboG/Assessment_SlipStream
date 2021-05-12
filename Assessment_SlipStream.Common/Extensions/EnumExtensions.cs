using Assessment_SlipStream.Common.Attributes;
using Assessment_SlipStream.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Assessment_SlipStream.Common.Extensions
{
    public static class EnumExtensions
    {
        public static EnumDetails GetEnumMemberAttrValue(this Enum enumText)
        {

            var enumType = enumText.GetType().GetField(enumText.ToString());
            if (enumType == null)
            {
                return new EnumDetails() { Value = -1, Color = "", DefualtText = enumText.ToString(), Text = enumText.ToString() };
            }

            var attr = (EnumCustomMemberAttribute)enumType.GetCustomAttribute(typeof(EnumCustomMemberAttribute));
            //var attr = memInfo.FirstOrDefault()?.GetCustomAttributes(false).OfType<EnumCustomMemberAttribute>().FirstOrDefault();
            return
                new EnumDetails()
                {
                    Text = attr?.Text ?? "",
                    Color = attr?.Color ?? "",
                    DefualtText = enumText.ToString(),
                    Value = Convert.ToInt32(enumText),
                    CssClass = attr?.CssClas ?? "",
                    Name = GetAttribute.Text(enumText.GetType())
                };
        }
      

        public static List<EnumDetails> GetEnumDetails<T>(this EnumDetails enumDetails) where T : Enum
        {
            List<EnumDetails> res = new List<EnumDetails>();
            foreach (var item in Enum.GetValues(typeof(T)))
            {
                res.Add(((T)item).GetEnumMemberAttrValue());
            }
            return res;
        }
        public static string Text<T>(this T item) where T : Enum
        {
            var txt = item.GetEnumMemberAttrValue().Text;
            return !string.IsNullOrEmpty(txt) ? txt : item.ToString();
        }
        public static string Color<T>(this T item) where T : Enum
        {
            return item.GetEnumMemberAttrValue().Color;
        }
        public static string DefaultValue<T>(this T item) where T : Enum
        {
            return item.GetEnumMemberAttrValue().DefualtText;
        }
        public static string CssClass<T>(this T item) where T : Enum
        {
            return item.GetEnumMemberAttrValue().CssClass;
        }
        public static int val<T>(this T item) where T : Enum
        {
            return item.GetEnumMemberAttrValue().Value;
        }
        //List<(string ParamName, string ParamValue)> paramsList
        public static (string ParamName, string ParamValue) GetParametaDictionary<T>(this T item, string ParameterName) where T : Enum
        {
            return (ParameterName, item.val().ToString());
        }
        public static T ByText<T>(this T enumType, string enumText) where T : Enum
        {

            var defaultT = (new EnumDetails()).GetEnumDetails<T>()?.First(p => p.Text == enumText)?.DefualtText ?? "";
            try
            {
                return (T)System.Enum.Parse(typeof(T), enumText);
            }
            catch
            {
                if (!string.IsNullOrEmpty(defaultT))
                {
                    return (T)System.Enum.Parse(typeof(T), defaultT);
                }
                throw new Exception("Enum Value Not Found");
            }
        }
    }
}
