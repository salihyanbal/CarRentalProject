using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class FakeCard : IEntity
    {
        public int Id { get; set; }
        public string NameOnTheCard { get; set; }
        public string CardNumber { get; set; }
        public string CardCvv { get; set; }
        public string expirationDate { get; set; }
        public decimal MoneyInTheCard { get; set; }
    }
}
