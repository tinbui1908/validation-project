using System;
using System.Collections.Generic;
using System.Reflection;

namespace MyFramework
{
    public class Validation
    {
        private Validation() { }

        private static Validation _instance;

        public static Validation GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Validation();
            }

            return _instance;
        }

        public HashSet<ConstraintViolation> DoValidate(Object obj)
        {
            HashSet<ConstraintViolation> validateResults = new HashSet<ConstraintViolation>();

            foreach (PropertyInfo property in obj.GetType().GetProperties())
            {
                foreach (Attribute attr in property.GetCustomAttributes(false))
                {
                    string attrType = attr.GetType().ToString();

                    ValidatorType? valType = ValidatorTypeMapping.GetType(attrType);

                    if (valType == null)
                    {
                        continue;
                    }
                    else
                    {
                        Validator validator = ValidatorFactory.createValidator(valType);
                        if(validator == null)
                        {
                            continue;
                        }

                        ConstraintViolation constraint = validator.DoValidate(property, obj, attr);

                        if (constraint.Status != true)
                        {
                            validateResults.Add(constraint);
                        }
                    }

                }
            }


            return validateResults;
        }

    }
}
