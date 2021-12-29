using System;
using System.Text;
using MyFramework.DataAnnotations;
using System.Collections.Generic;

namespace MyFramework.Validators
{
    public class MaxLengthValidator : Validator
    {
        public override Boolean CheckInvalid(Attribute attribute, object value)
        {
            MaxLengthAttribute maxLength = attribute as MaxLengthAttribute;

            return maxLength.MaxLength > ((string)value).Length;
        }

        public override string GetMessage(Attribute attribute)
        {
            MaxLengthAttribute maxLength = attribute as MaxLengthAttribute;
            return maxLength.Message;
        }
    }
}

