using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        ICarImageService _carImageService;

        public CarManager(ICarDal carDal,ICarImageService carImageService)
        {
            _carDal = carDal;
            _carImageService = carImageService;
        }

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult();
        }
        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("admin")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            _carImageService.DeleteByCarId(car.Id);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.ProductsListed);
        }
        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == id));
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrand(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId));
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColor(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId));
        }
        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("admin")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetails(CarDetailFilterDto filterDto)
        {
            //Expression propertyExp,someValue,containsMethodExp,combinedExp;
            //Expression<Func<Car, bool>> exp = c => true, oldExp;
            //MethodInfo method;
            //var parameterExp = Expression.Parameter(typeof(Car), "type");
            //foreach (PropertyInfo propertyInfo in filterDto.GetType().GetProperties())
            //{
            //    if (propertyInfo.GetValue(filterDto,null) != null)
            //    {
            //        oldExp = exp;
            //        propertyExp = Expression.Property(parameterExp, propertyInfo.Name);
            //        method = typeof(int).GetMethod("Equals", new[] { typeof(int) });
            //        someValue = Expression.Constant(filterDto.GetType().GetProperty(propertyInfo.Name).GetValue(filterDto, null), typeof(int));
            //        containsMethodExp = Expression.Call(propertyExp, method, someValue);
            //        exp = Expression.Lambda<Func<Car, bool>>(containsMethodExp, parameterExp);
            //        combinedExp = Expression.AndAlso(exp.Body,oldExp.Body);
            //        exp = Expression.Lambda<Func<Car, bool>>(combinedExp, exp.Parameters[0]);
            //    }
            //}
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetailsByFilter(filterDto));
        }
    }
}
