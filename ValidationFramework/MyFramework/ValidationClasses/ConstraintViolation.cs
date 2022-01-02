namespace MyFramework.ValidationClasses
{
    /// <summary>
    /// Lớp "ràng buộc" để chứa thông tin của field/property gồm: tên, giá trị, trạng thái, thông báo
    /// </summary>
    public class ConstraintViolation
    {
        #region private attributes
        private string _property;   // Tên thuộc tính

        private object _value;      // Giá trị của thuộc tính

        private bool _status = true;       // Trạng thái validate

        private string _message;    // Thông báo lỗi validate
        #endregion

        #region public properties

        public string Property
        {
            get => _property;

            set => _property = value;
        }

        public object Value
        {
            get => _value;

            set => _value = value;
        }

        public bool Status
        {
            get => _status;

            set => _status = value;
        }

        public string Message
        {
            get => _message;

            set => _message = value;
        }
        #endregion
    }
}
