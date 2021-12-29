using System;
using System.Collections.Generic;
using System.Text;

namespace MyFramework.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxAttribute: Attribute
	{
        public MaxAttribute(double max)
        {
            Message = "This attribute is not suitable with max value";
            Max = max;
        }

        public MaxAttribute(double max, string msg)
        {
            Message = msg;
            Max = max;
        }

        public string Message { get; set; }

        public double Max { get; set; }
    }
}
