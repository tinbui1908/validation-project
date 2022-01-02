using System;
using MyFramework.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using MyFramework.ValidationClasses;

namespace MyFramework.Validators
{
    public class EmailAddressValidator : Validator
    {
        public override bool CheckInvalid(Attribute attribute, object value)
        {
            try
            {
                var str = value.ToString();
                if (string.IsNullOrEmpty(str))
                {
                    return true;
                }
                bool checkEmail = MailAddress.TryCreate(str, out var emailAddress);
                // Nếu tạo được email
                if (checkEmail)
                {
                    var hostParts = emailAddress.Host.Split('.');

                    if (hostParts.Length == 1                                           // No dot.
                        || hostParts.Any(p => p == string.Empty)                        // Double dot.
                        || hostParts[^1].Length < 2                                     // TLD only one letter.
                        || emailAddress.User.Contains(' ')
                        || emailAddress.User.Split('.').Any(p => p == string.Empty))    // Double dot or dot at end of user part.
                        return true;
                }

                return !checkEmail;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public override string GetMessage(Attribute attribute)
        {
            EmailAddressAttribute newAttribute = attribute as EmailAddressAttribute;

            return newAttribute.Message;
        }
    }
}