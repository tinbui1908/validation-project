using System;

using MyFramework.DataAnnotations;
using MyFramework.ValidationClasses;

namespace MyFramework.Validators
{
    public class RegexValidator : Validator
    {
        public override bool CheckInvalid(Attribute attribute, object value)
        {
            try
            {
                var attr = attribute as RegExAttribute;
                return !attr.Pattern.IsMatch(value as string);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override string GetMessage(Attribute attribute)
        {
            var regex = attribute as RegExAttribute;
            return regex.Message;
        }
    }
}
