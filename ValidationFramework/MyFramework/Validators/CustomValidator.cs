using System;

using MyFramework.DataAnnotations;
using MyFramework.ValidationClasses;

namespace MyFramework.Validators
{
    internal class CustomValidator : Validator
    {
        /// <summary>
        /// Con trỏ hàm đại diện cho logic validate của Custom validator
        /// </summary>
        private Func<Attribute, object, bool> myCustomRule;

        /// <summary>
        /// Hàm thiết lập luật validate mới
        /// </summary>
        /// <param name="newRule">Luật validator mới</param>
        public void SetChecker(Func<Attribute, object, bool> newRule)
        {
            myCustomRule = newRule;
        }

        public override bool CheckInvalid(Attribute attribute, object value)
        {
            try
            {
                return this.myCustomRule(attribute, value);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public override string GetMessage(Attribute attribute)
        {
            CustomAttribute attr = attribute as CustomAttribute;
            return attr.Message;
        }
    }
}