using System;

namespace MyFramework.DataAnnotations
{
    /// <summary>
    /// - Lớp attribute min length hỗ trợ validate độ dài bé nhất được phép của chuỗi nhập vào.
    /// - Đối tượng sử dụng: Property.
    /// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class MinLengthAttribute: Attribute
	{
        /// <summary>
		/// Hàm tạo với tham số min length tùy chỉnh và thông báo mặc định
		/// </summary>
		/// <param name="minLength">Min length muốn truyền cho attribute</param>
        public MinLengthAttribute(int minLength)
        {
            Message = "This attribute is not suitable with min length";
            MinLength = minLength;
        }

        /// <summary>
        /// Hàm tạo với tham số min length tùy chỉnh và thông báo tùy chỉnh
        /// </summary>
        /// <param name="minLength">Min length muốn truyền cho attribute</param>
        /// <param name="msg">Thông báo muốn truyền cho attribute</param>
        public MinLengthAttribute(int minLength, string msg)
        {
            Message = msg;
            MinLength = minLength;
        }

        public string Message { get; set; }

        public int MinLength { get; set; }
    }
}
