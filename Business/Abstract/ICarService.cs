using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetCarsByBrand(int brandId);
        IDataResult<List<Car>> GetCarsByColor(int colorId);
        IDataResult<List<CarDetailDto>> GetCarsDetails(CarDetailFilterDto filterDto);
    }
}
