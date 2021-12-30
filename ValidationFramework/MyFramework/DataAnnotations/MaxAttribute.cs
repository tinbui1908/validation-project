using System;
using System.Collections.Generic;
using System.Text;

namespace MyFramework.DataAnnotations
{
    /// <summary>
    /// - Lớp attribute max hỗ trợ validate giá trị lớn nhất được phép của value.
    /// - Đối tượng sử dụng: Property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxAttribute: Attribute
	{
        /// <summary>
        /// Hàm tạo với message mặc định và giá trị max tùy chỉnh
        /// </summary>
        /// <param name="max">Giá trị max muốn truyền cho attribute</param>
        public MaxAttribute(double max)
        {
            Message = "This attribute is not suitable with max value";
            Max = max;
        }

        /// <summary>
        /// Hàm tạo với message tùy chỉnh và giá trị max tùy chỉnh
        /// </summary>
        /// <param name="max">Giá trị max muốn truyền cho attribute</param>
        /// <param name="msg">Giá trị message muốn truyền cho attribute</param>
        public MaxAttribute(double max, string msg)
        {
            Message = msg;
            Max = max;
        }

        public string Message { get; set; }

        public double Max { get; set; }
    }
}
