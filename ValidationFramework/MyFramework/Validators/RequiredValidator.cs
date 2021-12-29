using MyFramework.DataAnnotations;
using System;

namespace MyFramework
{
    public class RequiredValidator : Validator
    {
        public override bool CheckInvalid(Attribute attribute, object value)
        {
            try
            {
                return string.IsNullOrEmpty(value.ToString());

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override string GetMessage(Attribute attribute)
        {
            RequiredAttribute required = attribute as RequiredAttribute;
            return required.Message;
        }
    }
}
