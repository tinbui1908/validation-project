using System;
using System.Collections.Generic;
using System.Text;

namespace MyFramework
{
    class ConstraintViolation
    {
        private string _property;

        private object _value;

        private bool _status;

        private string _message;

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
    }
}
