using System;
using System.Collections.Generic;
using System.Text;

namespace MyFramework.DataAnnotations
{
	[AttributeUsage(AttributeTargets.Property)]
	public class MinLengthAttribute: Attribute
	{
        public MinLengthAttribute(int minLength)
        {
            Message = "This attribute is not suitable with min length";
            MinLength = minLength;
        }

        public MinLengthAttribute(int minLength, string msg)
        {
            Message = msg;
            MinLength = minLength;
        }

        public string Message { get; set; }

        public int MinLength { get; set; }
    }
}
