using System;
using System.Collections.Generic;
using System.Text;

namespace MyFramework.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EmailAddressAttribute : Attribute
    {
        public EmailAddressAttribute(string msg = "This attribute is not suitable with email address type")
        {
            Message = msg;
        }
        public string Message { get; set; }
    }
}
