using System.Collections.Generic;
using MyFramework.Validators;

namespace MyFramework.ValidationClasses
{
    /// <summary>
    /// Lớp factory, quản lý việc tạo lập các Available validator
    /// </summary>
    public class ValidatorFactory
    {
        /// <summary>
        /// Một dictonary để lưu trữ các Prototype validator hỗ trợ sẵn trong Framework
        /// </summary>
        private static Dictionary<ValidatorType, Validator>
            validators = new Dictionary<ValidatorType, Validator>();

        /// <summary>
        /// Hàm tạo static cho lớp Validator factory
        /// </summary>
        static ValidatorFactory()
        {
            // Nếu dictonary trống, tiến hành khởi tạo các validator
            if (validators.Count == 0)
            {
                InitPrototypes();
            }
            else
            {
                /* Do nothing */
            }

        }

        /// <summary>
        /// Khởi tạo dictionary
        /// </summary>
        private static void InitPrototypes()
        {
            validators.Add(ValidatorType.REQUIRED, new RequiredValidator());
            validators.Add(ValidatorType.REGEX, new RegexValidator());
            validators
                .Add(ValidatorType.EMAIL_ADDRESS, new EmailAddressValidator());
            validators.Add(ValidatorType.MIN, new MinValidator());
            validators.Add(ValidatorType.MAX, new MaxValidator());
            validators.Add(ValidatorType.MIN_LENGTH, new MinLengthValidator());
            validators.Add(ValidatorType.MAX_LENGTH, new MaxLengthValidator());
            validators.Add(ValidatorType.NO_BLANK, new NoBlankValidator());
        }

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
                else { /* Do nothing */ }

            }
            return null;
        }
    }
}
