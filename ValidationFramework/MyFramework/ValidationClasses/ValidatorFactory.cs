using System.Collections.Generic;

namespace MyFramework
{
    public class ValidatorFactory
    {
        /// <summary>
        /// Một dictonary để lưu trữ các Prototype validator hỗ trợ sẵn trong Framework
        /// </summary>
        private static Dictionary<ValidatorType, Validator> validators = new Dictionary<ValidatorType, Validator>();

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
            else { /* Do nothing */ };
        }

        /// <summary>
        /// Khởi tạo dictionary
        /// </summary>
        private static void InitPrototypes()
        {
            validators.Add(ValidatorType.REQUIRED, new RequiredValidator());
            //validators.Add(ValidatorType.REGEX, new Validator());
            //validators.Add(ValidatorType.EMAIL_ADDRESS, new Validator());
            //validators.Add(ValidatorType.MIN, new Validator());
            //validators.Add(ValidatorType.MAX, new Validator());
            //validators.Add(ValidatorType.MIN_LENGTH, new Validator());
            //validators.Add(ValidatorType.MAX_LENGTH, new Validator());

        }

        /// <summary>
        /// Tạo validator
        /// </summary>
        /// <param name="validatorType">Kiểu của validator</param>
        /// <returns></returns>
        public static Validator? createValidator(ValidatorType? validatorType)
        {
            if (validatorType != null)
            {
                Validator validator = null;
                // Xét xem đã có sẵn trong dictonary chưa
                if (validators.ContainsKey((ValidatorType)validatorType))
                {
                    validator = validators[(ValidatorType)validatorType];
                }
                else { /* Do nothing */ };

                return validator;
            }
            return null;
        }
    }
}