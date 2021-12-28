using MyFramework.DataAnnotations;
using System;
using System.Reflection;

namespace MyFramework
{
    class Program
    {
        public class User
        {  
            [Regex("^[a,z]...{0,8}.", "hello")]
            public int age { set; get; }
        }
        static void Main(string[] args)
        {
            User a = new User()
            {
                age = 15
            };

            foreach (PropertyInfo thuoctinh in a.GetType().GetProperties())
            {
                foreach (Attribute attr in thuoctinh.GetCustomAttributes(false))
                {
                    RegexAttribute att = attr as RegexAttribute;
                    if (att != null)
                    {
                        Console.WriteLine($"{thuoctinh.Name} : {att.Message}, {att.Pattern}");
                    }
                }
            }
        }
    }
}
