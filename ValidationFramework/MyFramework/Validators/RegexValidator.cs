using System;
using System.Collections.Generic;
using System.Text;
using MyFramework.DataAnnotations;

namespace MyFramework.Validators
{
    public class RegexValidator: Validator
    {
        public override Boolean CheckInvalid(Attribute attribute, object value)
        {
            var attr = attribute as RegExAttribute;
            return !attr.Pattern.IsMatch(value as string);
        }

        public override string GetMessage(Attribute attribute)
        {
            var regex = attribute as RegExAttribute;
            return regex.Message;
        }
    }
}
