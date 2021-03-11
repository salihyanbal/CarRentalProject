using Business.Concrete;
using DataAccess.Concrete.Ef;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleIU
{
    class Program
    {
        //static CarManager _carManager = new CarManager(new EfCarDal());
        //static ColorManager _colorManager = new ColorManager(new EfColorDal());
        //static BrandManager _brandManager = new BrandManager(new EfBrandDal());
        //static UserManager _userManager = new UserManager(new EfUserDal());
        //static CustomerManager _customerManager = new CustomerManager(new EfCustomerDal());
        //static RentalManager _rentalManager = new RentalManager(new EfRentalDal());
        static void Main(string[] args)
        {
            //addUsers();
            //addCustomers();
            //_rentalManager.Add(new Rental { CarId=1,CustomerId=1,RentDate=DateTime.Now,ReturnDate=DateTime.Now});
            //foreach (var item in _rentalManager.GetAll().Data)
            //{
            //    Console.WriteLine(item.ReturnDate);
            //}
        }

        //private static void addCustomers()
        //{
        //    _customerManager.Add(new Customer { UserId = 1, CompanyName = "Gündüzler" });
        //    _customerManager.Add(new Customer { UserId = 2, CompanyName = "Kahraman" });
        //    _customerManager.Add(new Customer { UserId = 3, CompanyName = "Yesiltas" });
        //    _customerManager.Add(new Customer { UserId = 4, CompanyName = "Kazan" });
        //    _customerManager.Add(new Customer { UserId = 5, CompanyName = "Ses" });
        //    _customerManager.Add(new Customer { UserId = 6, CompanyName = "Gündüzler" });
        //}

        //private static void addUsers()
        //{
        //    _userManager.Add(new User { FirstName = "Mehmet", LastName = "Akgündüz", Email = "makgunduz@gmail.com", Password = "cantshow" });
        //    _userManager.Add(new User { FirstName = "Kahraman", LastName = "Solmaz", Email = "kahramanslmz@gmail.com", Password = "cantshow" });
        //    _userManager.Add(new User { FirstName = "Merve", LastName = "Seven", Email = "msvn@gmail.com", Password = "cantshow" });
        //    _userManager.Add(new User { FirstName = "Hasan", LastName = "Kanun", Email = "hkanun@gmail.com", Password = "cantshow" });
        //    _userManager.Add(new User { FirstName = "Alperen", LastName = "Sesli", Email = "asesli@gmail.com", Password = "cantshow" });
        //    _userManager.Add(new User { FirstName = "Sevgi", LastName = "Gündüz", Email = "sevgigndz@gmail.com", Password = "cantshow" });
        //    _userManager.Add(new User { FirstName = "Nisa", LastName = "Sevilen", Email = "nsevilen@gmail.com", Password = "cantshow" });
        //}

        //private static void addBrands()
        //{
        //    _brandManager.Add(new Brand { Name = "Mercedes" });
        //    _brandManager.Add(new Brand { Name = "BMW" });
        //    _brandManager.Add(new Brand { Name = "Renault" });
        //    _brandManager.Add(new Brand { Name = "Volkswagen" });
        //    _brandManager.Add(new Brand { Name = "Chevrolet" });
        //}

        //private static void addColors()
        //{
        //    _colorManager.Add(new Color { Name = "Siyah" });
        //    _colorManager.Add(new Color { Name = "Beyaz" });
        //    _colorManager.Add(new Color { Name = "Gri" });
        //    _colorManager.Add(new Color { Name = "Kırmızı" });
        //    _colorManager.Add(new Color { Name = "Mavi" });
        //}

        //private static void addCars()
        //{
        //    _carManager.Add(new Car { BrandId = 1, ColorId = 1, ModelYear = 2021, CarName = "BENZ", DailyPrice = 270, Description = "Son model siyah Mercedes BENZ" });
        //    _carManager.Add(new Car { BrandId = 1, ColorId = 2, ModelYear = 2018, CarName = "BENZ", DailyPrice = 200, Description = "2018 model beyaz Mercedes BENZ" });
        //    _carManager.Add(new Car { BrandId = 2, ColorId = 1, ModelYear = 2021, CarName = "320i", DailyPrice = 270, Description = "Son model siyah BMW 320i" });
        //    _carManager.Add(new Car { BrandId = 2, ColorId = 2, ModelYear = 2019, CarName = "320i", DailyPrice = 200, Description = "2019 model siyah BMW 320i" });
        //    _carManager.Add(new Car { BrandId = 2, ColorId = 3, ModelYear = 2010, CarName = "Fluence", DailyPrice = 120, Description = "2010 model gri Renault Fluence" });
        //    _carManager.Add(new Car { BrandId = 4, ColorId = 4, ModelYear = 2015, CarName = "Passat", DailyPrice = 170, Description = "2015 model siyah Volkswagen Passat" });
        //    _carManager.Add(new Car { BrandId = 5, ColorId = 4, ModelYear = 2021, CarName = "Cruze", DailyPrice = 250, Description = "Son model gri Chevrolet Cruze" });
        //}
    }
}
