using Business.Abstract;
using Business.Constants;
using Business.Rules;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentaldal;
        public RentalManager(IRentalDal rentaldal)
        {
            _rentaldal = rentaldal;
        }
        public IResult Add(Rental rental)
        {
            if (RentalRules.RentalAddingCheck(rental, _rentaldal) == true)
            {
                _rentaldal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            else
                return new ErrorResult(Messages.RentalCantAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentaldal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentaldal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<Rental> GetRental(int id)
        {
            return new SuccessDataResult<Rental>(_rentaldal.Get(p => p.Id == id), Messages.RentalListed);
        }

        public IResult Update(Rental rental)
        {
            _rentaldal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
