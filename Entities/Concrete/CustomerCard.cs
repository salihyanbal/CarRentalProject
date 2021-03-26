using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class CustomerCard : IEntity
    {
        public int CustomerId { get; set; }
        public int CardId { get; set; }
    }
}
