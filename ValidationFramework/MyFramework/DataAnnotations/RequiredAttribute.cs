using System;
using System.Collections.Generic;
using System.Text;

namespace MyFramework.DataAnnotations
{
	[AttributeUsage(AttributeTargets.Property)]
	public class RequiredAttribute: Attribute
	{
		public RequiredAttribute() => Message = "This attribute is required";
		public RequiredAttribute(string msg) => Message = msg;

		public string Message { get; set; }
	}
}
