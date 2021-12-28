using System;
using System.Collections.Generic;

namespace MyFramework
{
    /// <summary>
    /// Định nghĩa các kiểu Validator
    /// </summary>
    public enum ValidatorType
    {


        //// Max length of string type
        //LENGTH,
        //// Scope of number (from .. to) type
        //RANGE,
        //// Have no blank ('_') type
        //NO_BLANK,
        // Have blank(s) ('_') type
        //BLANK,
        // Is a number type
        //IS_NUMBER

        // Not null type
        REQUIRED,
        // Regular expression type
        REGEX,
        MIN_LENGTH,
        MAX_LENGTH,
        MIN,
        MAX,
        EMAIL_ADDRESS,
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
            //types.Add("MyAnnotation",
            //          ValidatorType.REGEX);
            //types.Add("MyAnnotation",
            //          ValidatorType.MIN_LENGTH);
            //types.Add("MyAnnotation",
            //          ValidatorType.MAX_LENGTH);
            //types.Add("MyAnnotation",
            //          ValidatorType.MIN);
            //types.Add("MyAnnotation",
            //          ValidatorType.MAX);
            //types.Add("MyAnnotation",
            //          ValidatorType.EMAIL_ADDRESS);
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