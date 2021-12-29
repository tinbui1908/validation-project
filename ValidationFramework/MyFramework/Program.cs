using System;
using System.Reflection;
using MyFramework.DataAnnotations;

namespace MyFramework
{
    class Program
    {
        public class User
        {
            [MinLength(3)]
            public string age { set; get; }
        }
        static void Main(string[] args)
        {

            //  var subclassTypes = Assembly
            //       .GetAssembly(typeof(MyAnnotation))
            //       .GetTypes()
            //       .Where(t => t.IsSubclassOf(typeof(MyAnnotation)))
            //       .Select(type => type.ToString())
            //       .ToHashSet<string>();

            //foreach (var subclass in subclassTypes)
            //{
            //    Console.WriteLine(subclass);
            //}


            User user = new User() { age = "as" };

            foreach (PropertyInfo thuoctinh in user.GetType().GetProperties())
            {
                foreach (Attribute attr in thuoctinh.GetCustomAttributes(false))
                {
                    //RequiredValidator validator = new RequiredValidator();
                    //Console.WriteLine(a);

                    //if (validator.CheckInvalid(attr, thuoctinh.GetValue(a)))
                    //{
                    //    string msg = validator.GetMessage(attr);
                    //    Console.WriteLine($"thong bao: {msg}");
                    //}

                    var validation = Validation.GetInstance();
                    var constraints = validation.DoValidate(user);

                    foreach(var item in constraints)
                    {
                        Console.WriteLine(item.Message);
                    }

                }
            }
        }
    }
}
