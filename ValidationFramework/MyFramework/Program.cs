using System;
using System.Linq;
using System.Reflection;

namespace MyFramework
{
    class Program
    {
        //public class User
        //{  
        //    [Required]
        //    public int age { set; get; }
        //}
        static void Main(string[] args)
        {
            User user = new User { Age = 18, Name = "Nguyeen Hoajdhbfsjgdfuskdng Khang" };

            foreach (var thuoctinh in user.GetType().GetProperties())
            {
                foreach (Attribute attr in thuoctinh.GetCustomAttributes(false))
                {
                    var type_str = attr.GetType().ToString();
                    //Console.WriteLine(type_str);
                }
            }

            var subclassTypes = Assembly
                   .GetAssembly(typeof(MyAnnotation))
                   .GetTypes()
                   .Where(t => t.IsSubclassOf(typeof(MyAnnotation)))
                   .Select(type => type.ToString())
                   .ToHashSet<string>();

            foreach (var subclass in subclassTypes)
            {
                Console.WriteLine(subclass);
            }

            //Console.WriteLine(subclassTypes.Contains("MyFramework.Test2Attribute"));

            //User a = new User();

            //foreach (PropertyInfo thuoctinh in a.GetType().GetProperties())
            //{
            //    foreach (Attribute attr in thuoctinh.GetCustomAttributes(false))
            //    {
            //        RequiredValidator validator = new RequiredValidator();
            //        Console.WriteLine(a);

            //        //if (validator.CheckInvalid(attr, thuoctinh.GetValue(a)))
            //        //{
            //        //    string msg = validator.GetMessage(attr);
            //        //    Console.WriteLine($"thong bao: {msg}");
            //        //}

            //    }
            //}
        }
    }
}
