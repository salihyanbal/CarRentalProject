using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFakeCardService
    {
        IResult Add(FakeCard fakeCard);
        IResult Delete(FakeCard fakeCard);
        IResult Update(FakeCard fakeCard);
        IDataResult<List<FakeCard>> GetAll();
        IDataResult<FakeCard> GetById(int id);
        IDataResult<List<FakeCard>> GetByCardNumber(string cardNumber);
        IResult IsCardExist(FakeCard fakeCard);
    }
}
