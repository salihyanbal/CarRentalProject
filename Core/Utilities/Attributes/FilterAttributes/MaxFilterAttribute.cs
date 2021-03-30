using System;

namespace Core.Utilities.Attributes.FilterAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class MaxFilterAttribute : FilterAttribute
    {
        public MaxFilterAttribute(string targetProperty) : base(targetProperty, "max")
        {
        }
    }
}
