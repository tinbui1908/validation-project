using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyFramework.ValidationClasses;

namespace MyFramework.Validators
{
    public class CustomValidator : Validator
    {
        public override bool CheckInvalid(Attribute attribute, object value)
        {
            throw new NotImplementedException();
        }

        public override string GetMessage(Attribute attribute)
        {
            throw new NotImplementedException();
        }
    }
}