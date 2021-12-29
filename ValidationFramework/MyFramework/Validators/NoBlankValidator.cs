using MyFramework.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFramework.Validators
{
    public class NoBlankValidator : Validator
    {
        public override Boolean CheckInvalid(Attribute attribute, object value)
        {
            return ((string)value).Contains(" ");
        }

        public override string GetMessage(Attribute attribute)
        {
            NoBlankAttribute noBlank = attribute as NoBlankAttribute;
            return noBlank.Message;
        }
    }
}
