using MyFramework.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFramework.Validators
{
    public class MinValidator : Validator
    {
        public override Boolean CheckInvalid(Attribute attribute, object value)
        {
            MinAttribute min = attribute as MinAttribute;

            return min.Min > Convert.ToInt32(value);
        }

        public override string GetMessage(Attribute attribute)
        {
            MinAttribute min = attribute as MinAttribute;
            return min.Message;
        }
    }
}





































