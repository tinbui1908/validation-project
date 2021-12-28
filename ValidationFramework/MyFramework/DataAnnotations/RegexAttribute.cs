using System;
using System.Collections.Generic;
using System.Text;

namespace MyFramework.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RegexAttribute : Attribute
    {
        public RegexAttribute(string pattern)
        {
            Pattern = pattern;
            Message = "This attribute is not suitable with regular expression";
        }

        public RegexAttribute(string pattern, string msg)
        {
            Pattern = pattern;
            Message = msg;
        }
        
        public string Pattern { get; set; }
        public string Message { get; set; }
    }
}
