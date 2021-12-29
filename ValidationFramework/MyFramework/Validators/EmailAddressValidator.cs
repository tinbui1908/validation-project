using MyFramework.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace MyFramework
{
    public class EmailAddressValidator : Validator
    {
        public override bool CheckInvalid(Attribute attribute, object value)
        {
            if (value != null)
            {
                try
                {
                    var str = value.ToString();
                    bool checkEmail = MailAddress.TryCreate(str, out var emailAddress);

                    var hostParts = emailAddress.Host.Split('.');
                    if (hostParts.Length == 1)
                        return true; // No dot.
                    if (hostParts.Any(p => p == string.Empty))
                        return true; // Double dot.
                    if (hostParts[^1].Length < 2)
                        return true; // TLD only one letter.

                    if (emailAddress.User.Contains(' '))
                        return true;
                    if (emailAddress.User.Split('.').Any(p => p == string.Empty))
                        return true; // Double dot or dot at end of user part.

                    return !checkEmail;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

            }
            return true;
        }

        public override string GetMessage(Attribute attribute)
        {
            EmailAddressAttribute newAttribute = attribute as EmailAddressAttribute;

            return newAttribute.Message;
        }
    }
}