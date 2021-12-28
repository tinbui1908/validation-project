using System;

namespace MyFramework
{
    //public abstract class Validator
    //{
    //    public abstract Boolean CheckInvalid(Attribute attribute, object value);
    //    public abstract string GetMessage(Attribute attribute);
    //} 
    public class Validator
    {
        public virtual Boolean CheckInvalid(Attribute attribute, object value) { return false; }
        public virtual string GetMessage(Attribute attribute) { return ""; }
    }
}
