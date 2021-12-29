using System;
using System.Text;
using MyFramework.DataAnnotations;
using System.Collections.Generic;


namespace MyFramework.Validators
{
	public class MaxValidator : Validator
	{
        public override Boolean CheckInvalid(Attribute attribute, object value)
        {
            MaxAttribute max = attribute as MaxAttribute;

            return max.Max > Convert.ToInt32(value);
        }

        public override string GetMessage(Attribute attribute)
        {
            MaxAttribute max = attribute as MaxAttribute;
            return max.Message;
        }
    }
}
