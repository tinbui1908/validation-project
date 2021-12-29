using System;
using System.Collections.Generic;
using System.Text;

namespace MyFramework.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NoBlankAttribute : Attribute
    {
        public NoBlankAttribute()
        {
            Message = "This attribute is not suitable with blank and no other characters";
        }
        public NoBlankAttribute(string msg)
        {
            Message = msg;
        }
        public string Message { get; set; }
    }
}
