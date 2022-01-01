using System;

using MyFramework.DataAnnotations;
using MyFramework.ValidationClasses;

namespace MyFramework.Validators
{
    public class RequiredValidator : Validator
    {
        public override bool CheckInvalid(Attribute attribute, object value)
        {
            if (value != null)
            {

                try
                {
                    return string.IsNullOrEmpty(value.ToString());
                }
                catch (Exception e)
                {
                    return true;
                    //throw new Exception(e.Message);
                }
            }
            return true;
        }

        public override string GetMessage(Attribute attribute)
        {
            RequiredAttribute required = attribute as RequiredAttribute;
            return required.Message;
        }
    }
}
