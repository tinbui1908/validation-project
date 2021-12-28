using System;
using System.Collections.Generic;
using System.Text;
using MyFramework.DataAnnotations;

namespace MyFramework.Validator
{
    public class RequiredValidator: Haha
    {
        public override Boolean CheckInvalid(Attribute attribute, object value)
        {
            Console.WriteLine(value);
            return string.IsNullOrEmpty((string)value);
        }

        public override string GetMessage(Attribute attribute)
        {
            RequiredAttribute required = attribute as RequiredAttribute;
            return required.Message;
        }
    }
}
