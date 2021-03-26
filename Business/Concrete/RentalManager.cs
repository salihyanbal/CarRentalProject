using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(
                IsRentable(rental));
            if (result != null)
            {
                return result;
            }
            rental.RentDate = DateTime.Now;
            _rentalDal.Add(rental);
            return new SuccessResult();

        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<Rental>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarId == carId));
        }

        public IDataResult<Rental> GetLastByCarId(int carId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.GetAll(r => r.CarId == carId).LastOrDefault());
        }

        public IDataResult<List<Rental>> GetAllByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.UserId == customerId));
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        public IResult IsDelivered(Rental rental)
        {
            var result = this.GetAllByCarId(rental.CarId).Data.LastOrDefault();
            if (result == null || result.ReturnDate != default)
                return new SuccessResult();
            return new ErrorResult();

        }

        public IResult IsRentable(Rental rental)
        {
            var result = this.GetAllByCarId(rental.CarId).Data;
            foreach (var pastRental in result)
            {
                if ((!IsDelivered(pastRental).Success) && 
                    ((rental.RentStartDate <= pastRental.RentEndDate && rental.RentStartDate >= pastRental.RentStartDate) ||
                    (rental.RentEndDate <= pastRental.RentEndDate && rental.RentEndDate >= pastRental.RentStartDate) ||
                    (rental.RentStartDate <= pastRental.RentStartDate && rental.RentEndDate >= pastRental.RentEndDate))) 
                {
                    return new ErrorResult();
                }
            }
            return new SuccessResult();
        }

        public IDataResult<List<RentalDetailDto>> GetAllRentalsDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetAllRentalDetails());
        }
        
    }
}
