using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public IResult Add(Car added)
        {
            _carDal.Delete(added);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car deleted)
        {
            _carDal.Delete(deleted);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new 
                SuccessDataResult<List<Car>>
                (_carDal.GetAll(p => p.BrandId == brandId),Messages.CarListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>
                (_carDal.GetAll(p => p.ColorId == colorId),Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>
                (_carDal.GetCarsDetails(),Messages.CarListed);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}

