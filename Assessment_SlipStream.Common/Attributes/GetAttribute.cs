using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment_SlipStream.Common.Attributes
{
    public static class GetAttribute
    {
        public static EnumCustomMemberAttribute GetEnumAttribute(Type t)
        {
            return (EnumCustomMemberAttribute)Attribute.GetCustomAttribute(t, typeof(EnumCustomMemberAttribute));
        }

        public static string Text(Type t)
        {
            return GetEnumAttribute(t)?.Text ?? t.GetType().Name;
        }
    }
}
