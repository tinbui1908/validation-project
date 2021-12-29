using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MyFramework.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RegExAttribute : Attribute
    {
        public RegExAttribute(string pattern)
        {
            Pattern = new Regex(pattern);
            Message = "This attribute is not suitable with regular expression";
        }

        public RegExAttribute(string pattern, string msg)
        {
            Pattern = new Regex(pattern);
            Message = msg;
        }
        
        public Regex Pattern { get; set; }
        public string Message { get; set; }
    }
}

    
