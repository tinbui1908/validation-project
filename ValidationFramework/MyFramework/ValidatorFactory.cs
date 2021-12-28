using System;
using System.Collections.Generic;
using System.Text;

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
            validators.Add(ValidatorType.NOT_NULL, new Validator());
            validators.Add(ValidatorType.BLANK, new Validator());
            validators.Add(ValidatorType.NO_BLANK, new Validator());
            validators.Add(ValidatorType.REGEX, new Validator());
            validators.Add(ValidatorType.PHONE_NUMBER, new Validator());
            validators.Add(ValidatorType.DATE_OF_BIRTH, new Validator());
            validators.Add(ValidatorType.LENGTH, new Validator());
            validators.Add(ValidatorType.RANGE, new Validator());
            validators.Add(ValidatorType.IS_NUMBER, new Validator());

        }

        /// <summary>
        /// Tạo validator
        /// </summary>
        /// <param name="validatorType">Kiểu của validator</param>
        /// <returns></returns>
        public static Validator createValidator(ValidatorType validatorType)
        {
            Validator validator = null;
            // Xét xem đã có sẵn trong dictonary chưa
            if (validators.ContainsKey(validatorType))
            {
                validator = validators[validatorType];
            }
            else { /* Do nothing */ };

            return validator;
        }
    }
}