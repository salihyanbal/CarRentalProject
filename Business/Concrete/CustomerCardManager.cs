using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerCardManager : ICustomerCardService
    {
        ICustomerCardDal _customerCardDal;

        public CustomerCardManager(ICustomerCardDal customerCardDal)
        {
            _customerCardDal = customerCardDal;
        }

        public IResult Add(CustomerCard customerCard)
        {
            _customerCardDal.Add(customerCard);
            return new SuccessResult(Messages.CardSaved);
        }

        public IResult Delete(CustomerCard customerCard)
        {
            _customerCardDal.Delete(customerCard);
            return new SuccessResult(Messages.CardDeleted);
        }

        public IDataResult<List<CustomerCard>> GetAll()
        {
            return new SuccessDataResult<List<CustomerCard>>(_customerCardDal.GetAll());
        }

        public IDataResult<List<CustomerCard>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CustomerCard>>(_customerCardDal.GetAll(cc => cc.CustomerId == customerId));
        }

        public IResult Update(CustomerCard customerCard)
        {
            _customerCardDal.Update(customerCard);
            return new SuccessResult();
        }
    }
}
