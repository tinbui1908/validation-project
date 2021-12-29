using MyFramework.DataAnnotations;
using System;

namespace MyFramework
{
    public class RequiredValidator: Validator
    {
        public override bool CheckInvalid(Attribute attribute, object value)
        {
            //Console.WriteLine(value);
            //Console.WriteLine(value.GetType());

            return string.IsNullOrEmpty(value.ToString());
        }

        public override string GetMessage(Attribute attribute)
        {
            RequiredAttribute required = attribute as RequiredAttribute;
            return required.Message;
        }
    }
}
