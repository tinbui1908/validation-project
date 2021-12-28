using MyFramework.DataAnnotations;
using MyFramework.Validator;
using System;
using System.Reflection;

namespace MyFramework
{
    class Program
    {
        public class User
        {  
            [Required]
            public int age { set; get; }
        }
        static void Main(string[] args)
        {
            User a = new User();

            foreach (PropertyInfo thuoctinh in a.GetType().GetProperties())
            {
                foreach (Attribute attr in thuoctinh.GetCustomAttributes(false))
                {
                    RequiredValidator validator = new RequiredValidator();
                    Console.WriteLine(a);

                    //if (validator.CheckInvalid(attr, thuoctinh.GetValue(a)))
                    //{
                    //    string msg = validator.GetMessage(attr);
                    //    Console.WriteLine($"thong bao: {msg}");
                    //}
                  
                }
            }
        }
    }
}
