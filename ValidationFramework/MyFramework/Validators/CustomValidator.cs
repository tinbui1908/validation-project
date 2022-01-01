using MyFramework.ValidationClasses;
using System;

namespace MyFramework.Validators
{
    internal class CustomValidator : Validator
    {
        private Func<Attribute, object, bool> myCustomeRule;
        private string message;

        public void SetChecker(Func<Attribute, object, bool> newChecker)
        {
            myCustomeRule = newChecker;
        }

        public void SetMessage(string newMsg)
        {
            this.message = newMsg;
        }

        public override bool CheckInvalid(Attribute attribute, object value)
        {
            return this.myCustomeRule(attribute, value);
        }

        public override string GetMessage(Attribute attribute)
        {
            return this.message;
        }
    }
}