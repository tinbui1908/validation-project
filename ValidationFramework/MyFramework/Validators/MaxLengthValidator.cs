using System;

using MyFramework.DataAnnotations;
using MyFramework.ValidationClasses;

namespace MyFramework.Validators
{
    public class MaxLengthValidator : Validator
    {
        public override bool CheckInvalid(Attribute attribute, object value)
        {
            try
            {
                MaxLengthAttribute maxLength = attribute as MaxLengthAttribute;

                return maxLength.MaxLength < ((string)value).Length;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override string GetMessage(Attribute attribute)
        {
            MaxLengthAttribute maxLength = attribute as MaxLengthAttribute;
            return maxLength.Message;
        }
    }
}

