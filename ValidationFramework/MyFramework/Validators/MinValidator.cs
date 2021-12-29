using MyFramework.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFramework.Validators
{
    public class MinValidator : Validator
    {
        public override bool CheckInvalid(Attribute attribute, object value)
        {
            try
            {
                MinAttribute min = attribute as MinAttribute;

                return min.Min > Convert.ToInt32(value);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override string GetMessage(Attribute attribute)
        {
            MinAttribute min = attribute as MinAttribute;
            return min.Message;
        }
    }
}





































