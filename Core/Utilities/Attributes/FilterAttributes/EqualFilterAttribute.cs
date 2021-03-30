using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Attributes.FilterAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class EqualFilterAttribute : FilterAttribute
    {
        public EqualFilterAttribute(string targetProperty) : base(targetProperty, "equal")
        {
        }
    }
}
