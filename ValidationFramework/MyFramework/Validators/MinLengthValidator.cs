using System;

using MyFramework.DataAnnotations;
using MyFramework.ValidationClasses;

namespace MyFramework.Validators
{
    public class MinLengthValidator : Validator
    {
        public override bool CheckInvalid(Attribute attribute, object value)
        {
            try
            {
                MinLengthAttribute minLength = attribute as MinLengthAttribute;

                return minLength.MinLength > ((string)value).Length;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override string GetMessage(Attribute attribute)
        {
            MinLengthAttribute minLength = attribute as MinLengthAttribute;
            return minLength.Message;
        }
    }
}
