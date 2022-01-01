using System;

namespace MyFramework.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLengthAttribute : Attribute
    {
        public MaxLengthAttribute(int maxLength)
        {
            Message = "This attribute is not suitable with max length";
            MaxLength = maxLength;
        }

        public MaxLengthAttribute(int maxLength, string msg)
        {
            Message = msg;
            MaxLength = maxLength;
        }

        public string Message { get; set; }

        public int MaxLength { get; set; }
    }
}
