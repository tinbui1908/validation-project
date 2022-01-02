using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MyFramework.ValidationClasses
{
    public abstract class Validator
    {
        /// <summary>
        /// Hàm kiểm ra giá trị có không hợp lệ không
        /// </summary>
        /// <param name="attribute">Ràng buộc cần xét</param>
        /// <param name="value">Giá trị cần kiểm tra</param>
        /// <returns>Giá trị true/false kết quả kiểm tra</returns>
        public abstract bool CheckInvalid(Attribute attribute, object value);
        /// <summary>
        /// Hàm lấy thông báo từ ràng buộc
        /// </summary>
        /// <param name="attribute">Ràng buộc cần lấy thông báo</param>
        /// <returns>Thông báo lấy được</returns>
        public abstract string GetMessage(Attribute attribute);

        /// <summary>
        /// Hàm thực hiện validate một thuộc tính của đối tượng, theo luật xác định
        /// </summary>
        /// <param name="obj">Đối tượng cần validate</param>
        /// <param name="property">Thuộc tính cần validate</param>
        /// <param name="attribute">Ràng buộc của thuộc tính</param>
        /// <returns>Biến "ràng buộc" chứa kết quả validate</returns>
        public ConstraintViolation DoValidate(object obj, PropertyInfo property, Attribute attribute)
        {
            // Bước 1: Đọc giá trị của thuộc tính property từ obj
            object value = property.GetValue(obj);

            // Bước 2: Khởi tạo biến "ràng buộc"
            ConstraintViolation constraint = CreateConstraintViolation(property.Name, value);

            // Bước 3: Kiểm tra giá trị có null không
            if (attribute.GetType() != typeof(RequiredAttribute) 
                && value == null)
            {
                constraint.Message = $"{constraint.Property} is null";
                constraint.Status = false;
                return constraint;
            }

            // Bước 4: Thực hiện validate
            bool isInvalid = this.CheckInvalid(attribute, value);

            // Bước 4: Gán thông báo nếu có lỗi
            if (isInvalid)
            {
                constraint.Message = this.GetMessage(attribute);
                constraint.Status = false;
            }

            return constraint;
        }

        internal static bool TryValidateObject(Program.User user, ValidationContext context, List<ValidationResult> results, bool v)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Hàm tạo một biến "ràng buộc" để chứa thông tin validate của một field/property
        /// </summary>
        /// <param name="propertyName">Tên trường</param>
        /// <param name="propertyValue">Giá trị của trường</param>
        /// <returns>Biến "ràng buộc"</returns>
        private ConstraintViolation CreateConstraintViolation(string propertyName, object propertyValue)
        {
            // Tạo mới và gán tên + giá trị cho biến
            ConstraintViolation newConstraint = new ConstraintViolation()
            {
                Property = propertyName,
                Value = propertyValue
            };

            return newConstraint;
        }
    }
}
