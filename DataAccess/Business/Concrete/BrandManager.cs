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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandal = brandDal;
        }
        public IResult Add(Brand brand)
        {
            _brandal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            _brandal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
           return new SuccessDataResult<List<Brand>>(_brandal.GetAll(),Messages.BrandListed);
        }

        public IDataResult<Brand> GetBrand(int id)
        {
            return new SuccessDataResult<Brand>(_brandal.Get(p => p.Id == id),Messages.BrandListed);
        }

        public IResult Update(Brand brand)
        {
            _brandal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
