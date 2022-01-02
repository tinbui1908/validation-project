using System;
using System.Text.RegularExpressions;

namespace MyFramework.DataAnnotations
{
    /// <summary>
    /// - Lớp attribute no blank hỗ trợ validate theo template mà người dùng mong muốn bằng cách truyền vào tham số thích hợp.
    /// - Đối tượng sử dụng: Property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class RegExAttribute : Attribute
    {
        /// <summary>
        /// Hàm tạo với tham số message mặc định và pattern tùy chỉnh
        /// </summary>
        /// <param name="pattern">Pattern muốn truyền cho attribute</param>
        public RegExAttribute(string pattern)
        {
            Pattern = new Regex(pattern);
            Message = "This attribute is not suitable with regular expression";
        }

        /// <summary>
        /// Hàm tạo với tham số message tùy chỉnh và pattern tùy chỉnh
        /// </summary>
        /// <param name="pattern">Pattern muốn truyền cho attribute</param>
        /// <param name="msg">Thông báo muốn truyền cho attribute</param>
        public RegExAttribute(string pattern, string msg)
        {
            Pattern = new Regex(pattern);
            Message = msg;
        }
        
        public Regex Pattern { get; set; }
        public string Message { get; set; }
    }
}

    
