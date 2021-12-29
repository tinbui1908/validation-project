using System;
using System.Collections.Generic;

namespace MyFramework
{
    /// <summary>
    /// Định nghĩa các kiểu Validator
    /// </summary>
    public enum ValidatorType
    {
        // Not null type
        REQUIRED,
        // Regular expression type
        REGEX,
        // Min length of string
        MIN_LENGTH,
        // Max length of string
        MAX_LENGTH,
        // Min of value
        MIN,
        // Max of value
        MAX,
        // Email type
        EMAIL_ADDRESS,
        // No blank type
        NO_BLANK
     }

    /// <summary>
    /// Lớp xử lí mapping giữa Validatory type và Annotation type
    /// </summary>
    public class ValidatorTypeMapping
    {
        /// <summary>
        /// Dictionary dùng để mapping
        /// </summary>
        private static Dictionary<string, ValidatorType> types = new Dictionary<string, ValidatorType>();

        /// <summary>
        /// Hàm tạo static
        /// </summary>
        static ValidatorTypeMapping()
        {
            // Nếu dictonary trống, tiến hành khởi tạo các mapping
            if (types.Count == 0)
            {
                InitDictionary();
            }
            else { /* Do nothing */ };
        }

        /// <summary>
        /// Hàm khởi tạo dictionary
        /// </summary>
        private static void InitDictionary()
        {
            types.Add("MyFramework.DataAnnotations.RequiredAttribute",
                        ValidatorType.REQUIRED);
            //types.Add("MyFramework.DataAnnotations.RegexAttribute",
            //          ValidatorType.REGEX);
            types.Add("MyFramework.DataAnnotations.MinLengthAttribute",
					  ValidatorType.MIN_LENGTH);
			types.Add("MyFramework.DataAnnotations.MaxLengthAttribute",
					  ValidatorType.MAX_LENGTH);
			types.Add("MyFramework.DataAnnotations.MinAttribute",
					  ValidatorType.MIN);
			types.Add("MyFramework.DataAnnotations.MaxAttribute",
					  ValidatorType.MAX);
            //types.Add("MyFramework.DataAnnotations.EmailAddressAttribute",
            //          ValidatorType.EMAIL_ADDRESS);
            types.Add("MyFramework.DataAnnotations.NoBlankAttribute",
                      ValidatorType.NO_BLANK);
        }

        /// <summary>
        /// Hàm tìm Validator type tương ứng với Annotation name
        /// </summary>
        /// <param name="_annotationName">Tên của annotation</param>
        /// <returns>Validator type hoặc null</returns>
        public static ValidatorType? GetType(string _annotationName)
        {
            if (CheckInclude(_annotationName))
            {
                return types[_annotationName];
            }
            return null;
        }

        /// <summary>
        /// Hàm kiểm tra Annotation name đã được mapping chưa (có hỗ trợ không)
        /// </summary>
        /// <param name="_annotationName">Tên của annotation</param>
        /// <returns>Giá trị true/false tương ứng kết quả kiểm tra</returns>
        private static bool CheckInclude(string _annotationName)
        {
            return types.ContainsKey(_annotationName);
        }
    }
}