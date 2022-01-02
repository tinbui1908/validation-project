using System;

using MyFramework.DataAnnotations;
using MyFramework.ValidationClasses;


namespace MyFramework.Validators
{
    public class NoBlankValidator : Validator
    {
        public override bool CheckInvalid(Attribute attribute, object value)
        {
            try
            {
                return ((string)value).Contains(" ");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override string GetMessage(Attribute attribute)
        {
            NoBlankAttribute noBlank = attribute as NoBlankAttribute;
            return noBlank.Message;
        }
    }
}
