using System;
using System.Reflection;

namespace MyFramework
{
    public abstract class Validator
    {
        public abstract Boolean CheckInvalid(Attribute attribute, object value);
        public abstract string GetMessage(Attribute attribute);

        public ConstraintViolation DoValidate(PropertyInfo property, object obj, Attribute attribute)
        {
            // Step1: get value object
            var value = property.GetValue(obj);

            // Step2: create constraintViolation
            ConstraintViolation constraint = CreateConstraintViolation(property.Name, value);

            // Step3: validate
            if (this.CheckInvalid(attribute, value))
            {
                constraint.Message = this.GetMessage(attribute);
                constraint.Status = false;
            }

            return constraint;
        }

        private ConstraintViolation CreateConstraintViolation(string propertyName, object propertyValue)
        {
            return new ConstraintViolation()
            {
                Property = propertyName,
                Value = propertyValue
            };
        }
    }
}
