using System;
using System.Collections.Generic;
using System.Text;

namespace MyFramework
{
    public abstract class Haha
    {
        public abstract Boolean CheckInvalid(Attribute attribute, object value);
        public abstract string GetMessage(Attribute attribute);
    }
}
