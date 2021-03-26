using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FakeCardManager : IFakeCardService
    {
        IFakeCardDal _fakeCardDal;

        public FakeCardManager(IFakeCardDal fakeCardDal)
        {
            _fakeCardDal = fakeCardDal;
        }

        public IResult Add(FakeCard fakeCard)
        {
            _fakeCardDal.Add(fakeCard);
            return new SuccessResult();
        }

        public IResult Delete(FakeCard fakeCard)
        {
            _fakeCardDal.Delete(fakeCard);
            return new SuccessResult();
        }

        public IDataResult<List<FakeCard>> GetAll()
        {
            return new SuccessDataResult<List<FakeCard>>(_fakeCardDal.GetAll());
        }

        public IDataResult<FakeCard> GetById(int id)
        {
            return new SuccessDataResult<FakeCard>(_fakeCardDal.Get(c=> c.Id==id));
        }

        public IDataResult<List<FakeCard>> GetByCardNumber(string cardNumber)
        {
            return new SuccessDataResult<List<FakeCard>>(_fakeCardDal.GetAll(c => c.CardNumber == cardNumber));
        }

        public IResult IsCardExist(FakeCard fakeCard)
        {
            var result = _fakeCardDal.Get(c => c.NameOnTheCard == fakeCard.NameOnTheCard && 
            c.CardNumber == fakeCard.CardNumber && 
            c.CardCvv == fakeCard.CardCvv && 
            c.expirationDate == fakeCard.expirationDate);
            if (result == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IResult Update(FakeCard fakeCard)
        {
            _fakeCardDal.Update(fakeCard);
            return new SuccessResult();
        }
    }
}
