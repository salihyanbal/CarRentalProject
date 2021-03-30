using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Utilities.Attributes.FilterAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public abstract class FilterAttribute : Attribute
    {
        [Required]
        public string TargetProperty { get; }
        [Required]
        public bool IsMultiple { get; }
        public string ConditionType { get; }


        public FilterAttribute(string targetProperty, string conditionType)
        {
            TargetProperty = targetProperty;
            ConditionType = conditionType;
        }
    }
}
