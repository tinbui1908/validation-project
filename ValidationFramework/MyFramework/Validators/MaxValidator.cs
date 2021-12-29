using System;
using System.Text;
using MyFramework.DataAnnotations;
using System.Collections.Generic;


namespace MyFramework.Validators
{
    public class MaxValidator : Validator
    {
        public override bool CheckInvalid(Attribute attribute, object value)
        {
            try
            {
                MaxAttribute max = attribute as MaxAttribute;

                return max.Max < Convert.ToInt32(value);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override string GetMessage(Attribute attribute)
        {
            MaxAttribute max = attribute as MaxAttribute;
            return max.Message;
        }
    }
}
