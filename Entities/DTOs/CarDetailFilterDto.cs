using Core.Entities;
using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailFilterDto : IFilterDto
    {
        public int? BrandId { get; set; }
        public int? ColorId { get; set; }
        public int? Id { get; set; }
        public string CarName { get; set; }
         
    }
}

