using System;

namespace MyFramework.DataAnnotations
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class RequiredAttribute: Attribute
	{
		public RequiredAttribute() => Message = "This attribute is required";
		public RequiredAttribute(string msg) => Message = msg;

		public string Message { get; set; }
	}
}
