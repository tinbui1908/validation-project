using System;
using System.Text;
using MyFramework.DataAnnotations;
using System.Collections.Generic;

namespace MyFramework.Validators
{
	public class MinLengthValidator: Validator
	{
        public override Boolean CheckInvalid(Attribute attribute, object value)
        {
            MinLengthAttribute minLength = attribute as MinLengthAttribute;

            return minLength.MinLength > ((string)value).Length;
        }

        public override string GetMessage(Attribute attribute)
        {
            MinLengthAttribute minLength = attribute as MinLengthAttribute;
            return minLength.Message;
        }
    }
}
