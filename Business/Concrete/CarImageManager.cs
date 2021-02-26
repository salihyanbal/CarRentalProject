using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Business.FileManager;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage,IFormFile file)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageLimitExpired(carImage.CarId),
                CheckIfImageExtensionValid(file)
                );

            if (result!=null)
            {
                return result;
            }

            carImage.ImagePath = CarImagesFileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageExists(carImage.Id)
                );
            if (result != null)
            {
                return result;
            }
            string path = GetById(carImage.Id).Data.ImagePath;
            CarImagesFileHelper.Delete(path);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarHaveNoImage(carId));
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage carImage,IFormFile file)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageLimitExpired(carImage.CarId),
                CheckIfImageExtensionValid(file),
                CheckIfImageExists(carImage.Id)
                );

            if (result != null)
            {
                return result;
            }

            carImage.Date = DateTime.Now;
            string OldPath = GetById(carImage.Id).Data.ImagePath;
            CarImagesFileHelper.Update(file, OldPath);
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckIfImageLimitExpired(int carId)
        {
            int result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
                return new ErrorResult(Messages.ImageLimitExpiredForCar);
            return new SuccessResult();
        }

        private IResult CheckIfImageExtensionValid(IFormFile file)
        {
            bool isValidFileExtension = Messages.ValidImageFileTypes.Any(t => t == Path.GetExtension(file.FileName).ToUpper());
            if (!isValidFileExtension)
                return new ErrorResult(Messages.InvalidImageExtension);
            return new SuccessResult();

        }

        private List<CarImage> CheckIfCarHaveNoImage(int carId)
        {
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName + @"\Images\default.png");
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (!result.Any())
                return new List<CarImage>{new CarImage { CarId = carId, ImagePath = path }};
            return result;
        }

        private IResult CheckIfImageExists(int id)
        {
            if (_carImageDal.IsExist(id))
                return new SuccessResult();
            return new ErrorResult(Messages.CarImageMustBeExists);
        }
    }
}
