using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            var result = BusinessRules.Run(
                CheckFindexMax(customer),
                CheckFindexMax(customer));
            if(result != null)
            {
                return result;
            }
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult();
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.CustomersListed);
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.UserId == id));
        }

        public IResult Update(Customer customer)
        {
            var result = BusinessRules.Run(
                CheckFindexMax(customer),
                CheckFindexMax(customer));
            if (result != null)
            {
                return result;
            }
            _customerDal.Update(customer);
            return new SuccessResult();
        }

        public IResult CheckFindexMin(Customer customer)
        {
            if(customer.FindeksScore < 0)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IResult CheckFindexMax(Customer customer)
        {
            if (customer.FindeksScore > 1900)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
