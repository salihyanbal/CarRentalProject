using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear=2010,DailyPrice=15,Description="2010 model beyaz BMW araba"},
                new Car{Id=2,BrandId=1,ColorId=2,ModelYear=2020,DailyPrice=15,Description="2010 model kırmızı BMW araba"},
                new Car{Id=3,BrandId=2,ColorId=2,ModelYear=2014,DailyPrice=15,Description="2014 model kırmızı Mercedes araba"},
                new Car{Id=4,BrandId=3,ColorId=3,ModelYear=2010,DailyPrice=15,Description="2010 model gri Renault araba"},
                new Car{Id=5,BrandId=4,ColorId=4,ModelYear=2018,DailyPrice=15,Description="2018 model siyah Wolkswagen araba"},

            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public List<CarDetailDto> GetAllCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetAllCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetAllCarDetailsByFilter(CarDetailFilterDto filter)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(p=> p.Id == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
