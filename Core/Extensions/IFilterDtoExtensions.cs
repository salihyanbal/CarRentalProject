using Core.Entities.Abstract;
using Core.Utilities.Attributes.FilterAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Core.Extensions
{
    public static class IFilterDtoExtensions
    {
        public static Expression<Func<TEntity, bool>> GetFilterExpression<TEntity>(this IFilterDto filterDto)
        {
            Expression propertyExp, propertyValue, combinedExp;
            Expression<Func<TEntity, bool>> exp = c => true, oldExp;
            var parameterExp = Expression.Parameter(typeof(TEntity), "type");
            foreach (PropertyInfo propertyInfo in filterDto.GetType().GetProperties())
            {
                if (propertyInfo.GetValue(filterDto, null) != null)
                {
                    oldExp = exp;
                    var targetProperty = propertyInfo.GetCustomAttributes<FilterAttribute>(true).ToList()[0].TargetProperty;
                    propertyExp = Expression.Property(parameterExp, targetProperty);
                    propertyValue = Expression.Constant(filterDto.GetType().GetProperty(propertyInfo.Name).GetValue(filterDto));
                    Expression condition = SetConditionType(propertyInfo, propertyExp, propertyValue);
                    exp = Expression.Lambda<Func<TEntity, bool>>(condition, parameterExp);
                    combinedExp = Expression.AndAlso(exp.Body, oldExp.Body);
                    exp = Expression.Lambda<Func<TEntity, bool>>(combinedExp, exp.Parameters[0]);
                }
            }
            return exp;
        }
        static Expression SetConditionType(PropertyInfo propertyInfo, Expression propertyExp, Expression propertyValue)
        {
            var conditionType = propertyInfo.GetCustomAttributes<FilterAttribute>(true).ToList()[0].ConditionType;
            if (conditionType.ToLower() == "max")
            {
                return Expression.LessThan(propertyExp, propertyValue);
            }
            else if (conditionType.ToLower() == "min")
            {
                return Expression.GreaterThan(propertyExp, propertyValue);
            }
            else if (conditionType.ToLower() == "equal")
            {
                var method = typeof(List<int>).GetMethod("Contains", BindingFlags.Instance | BindingFlags.Public);
                var containsMethodExp = Expression.Call(propertyValue, method, propertyExp);
                return containsMethodExp;
            }
            return null;
        }
    }
}
