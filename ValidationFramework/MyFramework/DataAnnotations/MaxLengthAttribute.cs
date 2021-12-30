using System;
using System.Collections.Generic;
using System.Text;

namespace MyFramework.DataAnnotations
{
    /// <summary>
    /// - Lớp attribute max length hỗ trợ validate độ dài lớn nhất được phép của chuỗi nhập vào.
    /// - Đối tượng sử dụng: Property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLengthAttribute : Attribute
    {
        /// <summary>
		/// Hàm tạo với tham số max length tùy chỉnh và thông báo mặc định
		/// </summary>
		/// <param name="maxLength">Max length muốn truyền cho attribute</param>
        public MaxLengthAttribute(int maxLength)
        {
            Message = "This attribute is not suitable with max length";
            MaxLength = maxLength;
        }

        /// <summary>
        /// Hàm tạo với tham số max length tùy chỉnh và thông báo tùy chỉnh
        /// </summary>
        /// <param name="maxLength">Max length muốn truyền cho attribute</param>
        /// <param name="msg">Thông báo muốn truyền cho attribute</param>
        public MaxLengthAttribute(int maxLength, string msg)
        {
            Message = msg;
            MaxLength = maxLength;
        }

        public string Message { get; set; }

        public int MaxLength { get; set; }
    }
}
