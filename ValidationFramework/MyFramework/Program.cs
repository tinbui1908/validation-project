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
            //[Required]
            [EmailAddress]
            public string email { set; get; }
        }
        static void Main(string[] args)
        {
            User user = new User() { age = "as", email= "tin" };

            foreach (PropertyInfo thuoctinh in user.GetType().GetProperties())
            {
                foreach (Attribute attr in thuoctinh.GetCustomAttributes(false))
                {
                    var validation = Validation.GetInstance();
                    var constraints = validation.DoValidate(user);

                    foreach (var item in constraints)
                    {
                        Console.WriteLine(item.Message);
                    }
                }
            }
        }
    }
}
