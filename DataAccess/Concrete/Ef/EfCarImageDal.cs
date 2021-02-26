using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.Ef
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, CarRentalContext>, ICarImageDal
    {
        public bool IsExist(int id)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.CarImages.Any(p => p.Id == id);
            }
        }

    }
}
