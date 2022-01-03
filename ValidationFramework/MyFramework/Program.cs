using System;

using MyFramework.DataAnnotations;
using MyFramework.ValidationClasses;

namespace MyFramework
{
    class Program
    {
        public class User
        {
            [DataAnnotations.Required]
            [DataAnnotations.MaxLength(255)]
            public string FirstName { get; set; }

            [DataAnnotations.MaxLength(255)]
            public string LastName { get; set; }

            [DataAnnotations.Required]
            [RegEx(
    @"/^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$/")]
            public string Password { get; set; }

            [DataAnnotations.Required]
            [DataAnnotations.MaxLength(20)]
            public string Username { get; set; }

            [Min(16, "Age must be greater than 16")]
            public string Age { get; set; }

            [DataAnnotations.Required]
            [DataAnnotations.EmailAddress]
            public string Email { get; set; }


        }
        static void Main(string[] args)
        {
            User user = new User() { Age= "16"};

            var validation = Validation.GetInstance();

            validation.AddNewRule(
                "",
                typeof(User).Name,
                nameof(User.Age),
                
                 (o) => { return (string)o == "16"; },
                "New custom message"
            );

            var constraints = validation.DoValidate(user);

            // Duyệt qua các attribute hiện có trong property
            foreach (var c in constraints)
            {
                Console.WriteLine(c.Property + ": " + c.Message);
            }
        }

    }
}

