using Core.Entities.Abstract;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Core.Extensions
{
    public static class IFilterDtoExtensions
    {

        public static Expression<Func<TEntity, bool>> GetFilterExpression<TEntity>(this IFilterDto filterDto)
        {
            Expression propertyExp, someValue, containsMethodExp, combinedExp;
            Expression<Func<TEntity, bool>> exp = c => true, oldExp;
            MethodInfo method;
            var parameterExp = Expression.Parameter(typeof(TEntity), "type");
            foreach (PropertyInfo propertyInfo in filterDto.GetType().GetProperties())
            {
                if (propertyInfo.GetValue(filterDto, null) != null)
                {
                    oldExp = exp;
                    propertyExp = Expression.Property(parameterExp, propertyInfo.Name);
                    method = typeof(object).GetMethod("Equals", new[] { typeof(object) });
                    someValue = Expression.Constant(filterDto.GetType().GetProperty(propertyInfo.Name).GetValue(filterDto, null), typeof(object));
                    containsMethodExp = Expression.Call(propertyExp, method, someValue);
                    exp = Expression.Lambda<Func<TEntity, bool>>(containsMethodExp, parameterExp);
                    combinedExp = Expression.AndAlso(exp.Body, oldExp.Body);
                    exp = Expression.Lambda<Func<TEntity, bool>>(combinedExp, exp.Parameters[0]);
                }
            }
            return exp;
        }
    }
}
