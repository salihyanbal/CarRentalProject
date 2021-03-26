using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.Ef
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetAllRentalDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from rent in context.Rentals
                             join car in context.Cars
                             on rent.CarId equals car.Id
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join customer in context.Customers
                             on rent.UserId equals customer.UserId
                             join user in context.Users
                             on customer.UserId equals user.Id
                             select new RentalDetailDto
                             {
                                 RentalId = rent.Id,
                                 CarName = brand.Name + car.CarName,
                                 CustomerFullName = user.FirstName + user.LastName,
                                 RentDate = rent.RentDate,
                                 RentStartDate = rent.RentStartDate,
                                 RentEndDate = rent.RentEndDate,
                                 ReturnDate = rent.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
