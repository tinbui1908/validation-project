using System.Collections.Generic;
using MyFramework.Validators;

namespace MyFramework.ValidationClasses
{
    public class ValidatorFactory
    {
        /// <summary>
        /// Tạo validator
        /// </summary>
        /// <param name="validatorType">Kiểu của validator</param>
        /// <returns></returns>

        #nullable enable
        public static Validator? CreateValidator(ValidatorType? validatorType)
        {
            if (validatorType != null)
            {
                Validator validator;
                // Xét xem đã có sẵn trong dictonary chưa
                if (validators.ContainsKey((ValidatorType)validatorType))
                {
                    validator = validators[(ValidatorType)validatorType];
                    return validator;
                }
                else {
                    return null;
                };

            }
            return null;
        }
    }
}