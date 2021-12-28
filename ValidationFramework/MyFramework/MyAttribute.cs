using System;
using System.ComponentModel.DataAnnotations;

namespace MyFramework
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MyAnnotation : Attribute
    {
        public string Message { get; set; }

    }  
    
    [AttributeUsage(AttributeTargets.Property)]
    public class Test1Attribute : MyAnnotation
    {
        public Test1Attribute(string _msg = "Day la mot test1")
        {
            this.Message = _msg;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class Test2Attribute : MyAnnotation
    {
        public Test2Attribute(string _msg = "Day la mot test2")
        {
            this.Message = _msg;
        }
    }


    public class User
    {
        [Test1]
        [Test2 (Message = "Day la ten2")]
        public string Name { get; set; }
        public uint Age { get; set; }
        [DataType(DataType.EmailAddress)]
        public uint Email { get; set; }
    }
}