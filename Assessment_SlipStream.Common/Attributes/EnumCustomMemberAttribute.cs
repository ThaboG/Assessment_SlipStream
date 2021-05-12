using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment_SlipStream.Common.Attributes
{
    public class EnumCustomMemberAttribute : Attribute
    {
        public string Color
        {
            get; set;
        }
        public string Text
        {
            get; set;
        }
        public string CssClas
        {
            get; set;
        }
        //bool _Editable = false;
        //public bool Editable
        //{
        //    get => _Editable; set
        //    {
        //        _Editable = value;
        //    }
        //}
        public bool IsValueSetExplicitly
        {
            get
            {
                return true;
            }
        }

        public EnumCustomMemberAttribute()
        {

        }
    }
}
