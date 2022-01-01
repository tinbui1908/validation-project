using System;

namespace MyFramework.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MinAttribute: Attribute
	{
        public MinAttribute(double min)
        {
            Message = "This attribute is not suitable with min value";
            Min = min;
        }

        public MinAttribute(double min, string msg)
        {
            Message = msg;
            Min = min;
        }

        public string Message { get; set; }

        public double Min { get; set; }
    }
}
