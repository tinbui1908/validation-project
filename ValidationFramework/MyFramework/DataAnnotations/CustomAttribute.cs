using System;

namespace MyFramework.DataAnnotations
{

	[AttributeUsage(AttributeTargets.Property)]
	internal class CustomAttribute : Attribute
	{
		/// <summary>
		/// Hàm tạo
		/// </summary>
		internal CustomAttribute(string msg){
			Message = msg == "" ? "Custom rule - failed" : msg; ;
		} 

		public string Message { get; set; }
	}
}
