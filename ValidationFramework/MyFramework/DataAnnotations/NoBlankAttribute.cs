using System;

namespace MyFramework.DataAnnotations
{
    /// <summary>
    /// - Lớp attribute no blank hỗ trợ validate những trường không được phép có khoảng trắng.
    /// - Đối tượng sử dụng: Property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class NoBlankAttribute : Attribute
    {
        /// <summary>
		/// Hàm tạo với tham số tùy chỉnh
		/// </summary>
        public NoBlankAttribute()
        {
            Message = "This attribute is not suitable with blank and no other characters";
        }

        /// <summary>
		/// Hàm tạo với tham số tùy chỉnh
		/// </summary>
		/// <param name="msg">Thông báo muốn truyền cho attribute</param>
        public NoBlankAttribute(string msg)
        {
            Message = msg;
        }
        public string Message { get; set; }
    }
}
