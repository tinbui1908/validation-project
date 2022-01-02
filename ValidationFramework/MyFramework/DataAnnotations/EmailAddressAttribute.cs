using System;

namespace MyFramework.DataAnnotations
{
    /// <summary>
    /// - Lớp attribute email hỗ trợ validate email.
    /// - Đối tượng sử dụng: Property.
    /// - Ví dụ:
        /// class User {
        ///     ...
        ///     [EmailAddress]
        ///     public string Email { get; set; }
        ///     ...
        /// }
        /// 
        ///  class Account {
        ///     ...
        ///     [EmailAddress (Message = "This is an email address")]
        ///     public string Email { get; set; }
        ///     ...
        /// }
    /// 
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class EmailAddressAttribute : Attribute
    {
        /// <summary>
        /// Hàm tạo với tham số mặc định
        /// </summary>
        /// <param name="msg">Thông báo muốn truyền cho attribute</param>
        public EmailAddressAttribute(string msg = "This attribute is not suitable with email address type")
        {
            Message = msg;
        }
        public string Message { get; set; }
    }
}
