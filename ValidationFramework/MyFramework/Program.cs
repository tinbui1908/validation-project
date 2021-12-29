using System;
using System.Reflection;
using MyFramework.DataAnnotations;

namespace MyFramework
{
    class Program
    {
        public class User
        {
            [RegEx(
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z")]
            public string email1 { get; set; }
            [Max(3)]
            public string age { set; get; }
            //[Required]
            [EmailAddress]
            public string email2 { set; get; }
        }
        static void Main(string[] args)
        {
            User user = new User() { age = "as", email1= "tin", email2="abc" };

            var validation = Validation.GetInstance();
            var constraints = validation.DoValidate(user);

            foreach (var item in constraints)
            {
                Console.WriteLine(item.Message);
            }
        }
    }
}
