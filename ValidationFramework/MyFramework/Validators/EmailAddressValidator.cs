using MyFramework.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFramework
{
    public class EmailAddressValidator : Validator
    {
        public override bool CheckInvalid(Attribute attribute, object value)
        {
            throw new NotImplementedException();
        }

        public override string GetMessage(Attribute attribute)
        {
            EmailAddressAttribute newAttribute = attribute as EmailAddressAttribute;

            return newAttribute.Message;
        }
    }
}