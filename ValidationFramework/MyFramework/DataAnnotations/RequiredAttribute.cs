using System;

namespace MyFramework.DataAnnotations
{
	/// <summary>
	/// - Lớp attribute required hỗ trợ validate những trường không được phép bỏ trống.
	/// - Đối tượng sử dụng: Property.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class RequiredAttribute: Attribute
	{
		/// <summary>
		/// Hàm tạo với tham số mặc định
		/// </summary>
		public RequiredAttribute() => Message = "This attribute is required";
		/// <summary>
		/// Hàm tạo với tham số tùy chỉnh
		/// </summary>
		/// <param name="msg">Thông báo muốn truyền cho attribute</param>
		public RequiredAttribute(string msg) => Message = msg;

		public string Message { get; set; }
	}
}
