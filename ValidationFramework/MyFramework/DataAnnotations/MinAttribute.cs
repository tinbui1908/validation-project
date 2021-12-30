using System;
using System.Collections.Generic;
using System.Text;

namespace MyFramework.DataAnnotations
{
    /// <summary>
    /// - Lớp attribute min hỗ trợ validate giá trị bé nhất được phép của value.
    /// - Đối tượng sử dụng: Property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MinAttribute: Attribute
	{
        /// <summary>
		/// Hàm tạo với tham số min value tùy chỉnh và thông báo mặc định
		/// </summary>
		/// <param name="min">Min value muốn truyền cho attribute</param>
        public MinAttribute(double min)
        {
            Message = "This attribute is not suitable with min value";
            Min = min;
        }

        /// <summary>
		/// Hàm tạo với tham số min value tùy chỉnh và thông báo tùy chỉnh
		/// </summary>
		/// <param name="min">Min value muốn truyền cho attribute</param>
		/// <param name="msg">Thông báo value muốn truyền cho attribute</param>
        public MinAttribute(double min, string msg)
        {
            Message = msg;
            Min = min;
        }

        public string Message { get; set; }

        public double Min { get; set; }
    }
}
