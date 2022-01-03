using System;

using MyFramework.DataAnnotations;
using MyFramework.ValidationClasses;

namespace MyFramework.Validators
{
    internal class CustomValidator : Validator
    {
        private Func<Attribute, object, bool> myCustomRule;

        public void SetChecker(Func<Attribute, object, bool> newChecker)
        {
            myCustomRule = newChecker;
        }

        public override bool CheckInvalid(Attribute attribute, object value)
        {
            return this.myCustomRule(attribute, value);
        }

        public override string GetMessage(Attribute attribute)
        {
            CustomAttribute attr = attribute as CustomAttribute;
            return attr.Message;
        }
    }
}