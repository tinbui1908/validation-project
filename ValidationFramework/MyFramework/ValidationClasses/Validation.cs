using System;
using System.Collections.Generic;
using System.Reflection;

namespace MyFramework
{
    /// <summary>
    /// Lớp hỗ trợ validate một object 
    /// </summary>
    public class Validation
    {
        /// <summary>
        /// Hàm tạo private
        /// </summary>
        private Validation() { }

        /// <summary>
        /// Instance của Validation (Singleton)
        /// </summary>
        private static Validation _instance;

        /// <summary>
        /// Hàm lấy Instance của lớp
        /// </summary>
        /// <returns>Một instance của object Validation</returns>
        public static Validation GetInstance()
        {
            // Nếu chưa được khởi tạo, tiến hành khởi tạo
            if (_instance == null)
            {
                _instance = new Validation();
            }

            return _instance;
        }

        /// <summary>
        /// Validate một object
        /// </summary>
        /// <param name="obj">object cần validate</param>
        /// <returns>Trả về</returns>
        public HashSet<ConstraintViolation> DoValidate(Object obj)
        {
            HashSet<ConstraintViolation> validateResults = new HashSet<ConstraintViolation>(); // Biến lưu kết quả lỗi của quá trình validate

            // Duyệt qua các property của object
            foreach (PropertyInfo property in obj.GetType().GetProperties())
            {
                // Duyệt qua các attribute hiện có trong property
                foreach (Attribute attr in property.GetCustomAttributes(false))
                {
                    string attrType = attr.GetType().ToString();
                    // Tra trong mapping lấy ra loại validator
                    ValidatorType? valType = ValidatorTypeMapping.GetType(attrType);
                    // Nếu không có - không hỗ trợ valdiate
                    if (valType == null)
                    {
                        continue;
                    }
                    else
                    {
                        Validator validator = ValidatorFactory.createValidator(valType);
                        // Nếu khởi tạo không thành công - không hỗ trợ validate
                        if (validator == null)
                        {
                            continue;
                        }
                        // Gọi hàm validate của validator tương ứng với attr
                        ConstraintViolation constraint;
                        try
                        {
                            constraint = validator.DoValidate(obj, property, attr);
                        }
                        catch (Exception e)
                        {
                            constraint = new ConstraintViolation()
                            {
                                Message = e.Message,
                                Property = property.Name,
                                Value = property.GetValue(obj)
                            };
                            validateResults.Add(constraint);
                            continue;
                        }
                        // Nếu có lỗi, thêm vào kết quả validate
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
