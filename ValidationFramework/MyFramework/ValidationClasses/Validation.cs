using System;
using System.Collections.Generic;
using System.Reflection;
using MyFramework.DataAnnotations;
using MyFramework.Validators;

namespace MyFramework.ValidationClasses
{
    /// <summary>
    /// Cấu trúc lưu mục tiêu validator, gồm tên class và tên property
    /// </summary>
    struct TargetValidate
    {
        public string TargetClass { get; set; }
        public string TargetProperty { get; set; }
    }

    /// <summary>
    /// Cấu trục luật validate, bao gồm tên, validator và attribute để lưu thông báo
    /// </summary>
    struct CustomValidateRule
    {
        public string RuleName { get; set; }
        public CustomAttribute Attribute { get; set; }
        public CustomValidator Validator { get; set; }

    }

    /// <summary>
    /// Lớp hỗ trợ validate một object 
    /// </summary>
    public class Validation
    {
        private Dictionary<TargetValidate, List<CustomValidateRule>> _cumstomRules
            = new Dictionary<TargetValidate, List<CustomValidateRule>>();

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
            Type type = obj.GetType();
            string strType = type.Name;

            // Duyệt qua các property của object
            foreach (PropertyInfo property in type.GetProperties())
            {
                string strPropertyName = property.Name;

                #region Validate with Available validator(s)
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
                        Validator validator = ValidatorFactory.CreateValidator(valType);
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
                #endregion

                #region Validate with Custom validator(s)
                // Tạo một đối tượng targe để xét custom Validate
                TargetValidate target = new TargetValidate
                {
                    TargetClass = strType,
                    TargetProperty = strPropertyName
                };
                // Nếu có tồn tại trong danh sách các rules
                if (CheckContainCustomRule(target))
                {
                    List<CustomValidateRule> rules = _cumstomRules[target];

                    foreach (CustomValidateRule rule in rules)
                    {
                        ConstraintViolation constraint;

                        try
                        {
                            CustomValidator validator = rule.Validator;

                            constraint = validator.DoValidate(obj, property, rule.Attribute);
                        }
                        catch (Exception e)
                        {
                            constraint = new ConstraintViolation()
                            {
                                Message = rule.RuleName + ": " + e.Message,
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
                #endregion
            }

            return validateResults;
        }

        /// <summary>
        /// Hàm thêm một luật validate cho một property của class
        /// </summary>
        /// <param name="name">Tên của luật validate (Mặc định Custom rule: {targetClassName}-{targetPropertyName})</param>
        /// <param name="targetClassName">Tên class</param>
        /// <param name="targetPropertyName">Tên property</param>
        /// <param name="validateFunc">Hàm logic kiểm tra</param>
        /// <param name="errorMessage">Thông báo lỗi nếu kiểm tra không đạt</param>
        /// <returns></returns>
        public bool AddNewRule(
            string name,
            string targetClassName,
            string targetPropertyName,
            Func<object, bool> validateFunc,
            string errorMessage)
        {
            // Tạo một CustomValidator mới
            CustomValidator newCustomValidator = new CustomValidator();
            // Thiết đặt logic kiểm tra cho CustomValidator
            newCustomValidator.SetChecker(
                (attr, obj) => { return !validateFunc(obj); });

            // Mục tiêu kiểm tra
            var target = new TargetValidate
            {
                TargetClass = targetClassName,
                TargetProperty = targetPropertyName
            };
            // Đặt tên của luật
            string ruleName = name == "" ? $"Custom rule {targetClassName}-{targetPropertyName}" : name;
            // Tạo mới luật kiểm tra
            var customRule = new CustomValidateRule
            {
                RuleName = ruleName,
                Attribute = new CustomAttribute(errorMessage),
                Validator = newCustomValidator
            };
            // Kiểm tra tồn tại rule trong từ điển chưa
            if (CheckContainCustomRule(target)) // Nếu tồn tại thêm rule mới vào list rule của target
            {
                _cumstomRules[target].Add(customRule);
            }
            else // Nếu chưa, khởi tạo list rule và thêm vào từ điển
            {
                List<CustomValidateRule> rules = new List<CustomValidateRule>() { customRule };
                _cumstomRules.Add(target, rules);
            }

            return true;
        }

        /// <summary>
        /// Hàm kiểm tra xem target đã được thiết lập rule chưa
        /// </summary>
        /// <param name="target">target cần xét</param>
        /// <returns>Giá trị true/false tương ứng kết quả kiểm tra</returns>
        private bool CheckContainCustomRule(TargetValidate target)
        {
            return _cumstomRules.ContainsKey(target);
        }
    }
}

