using System;
using System.Collections.Generic;

namespace MyFramework
{
    public class Validation
    {
        private Validation(){}

        private static Validation _instance;

        public static Validation GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Validation();
            }

            return _instance;
        }

        public HashSet<ConstraintViolation> DoValidate()
        {
            throw new NotImplementedException();
        }
    }
}
