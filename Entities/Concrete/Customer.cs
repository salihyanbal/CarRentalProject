using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Customer:IEntity
    {
        [Key]
        public int UserId { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int FindeksScore { get; set; }
    }
}
