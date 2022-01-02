using System;

namespace MyFramework.DataAnnotations
{

	[AttributeUsage(AttributeTargets.Property)]
	internal class CustomAttribute : Attribute
	{
		/// <summary>
		/// Hàm tạo với tham số mặc định
		/// </summary>
		public CustomAttribute(string msg){
			Message = msg == "" ? "Custom rule" : msg; ;
		} 
		public string Message { get; set; }
	}
}
