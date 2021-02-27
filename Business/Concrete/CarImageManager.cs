using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        ICarService   _carService;
        public CarImageManager(ICarImageDal carImageDal,ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService =  carService;
        }
        public IResult Add(IFormFile file,int id)
        {
            IResult result = BusinessRules.Run(
                CheckIfCarImageLimitExceded(id),CheckCarExistence(id)
           );
            if(result != null)
            {
                return result;
            }
            CarImage carImage = new CarImage
            {
                ImagePath = Guid.NewGuid() + Path.GetExtension(file.FileName),
                Date = DateTime.UtcNow,
                CarId = id,
            };
            UploadFile(file,carImage.ImagePath);
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }
        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(
               CheckCarExistence(carImage.CarId)
           );
            DeleteFile(carImage.CarId,carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImageListed);
        }

        public IDataResult<List<CarImage>> GetCarImageById(int id)
        {
            return new SuccessDataResult<List<CarImage>>
                (CheckDefaultImageNeeded(id), Messages.CarImageListed);
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }
        private List<CarImage> CheckDefaultImageNeeded(int carId)
        {
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName + @"\images\Toyota-Logo.png");
            var result  =_carImageDal.GetAll(p => p.CarId == carId).Any();
            if(!result)
            {
                return new List<CarImage> { new CarImage { CarId = carId, ImagePath = path, Date = DateTime.UtcNow } };
            }
            return _carImageDal.GetAll(p => p.CarId == carId);
        }
        private IResult CheckIfCarImageLimitExceded(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if(result > 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceded);
            }
            return new SuccessResult();
        }
        private IResult CheckCarExistence(int carId)
        {
            var result = _carService.GetAll().Data.Where(P => P.Id == carId).FirstOrDefault();
            if(result != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarNotFound);
        }
        private IResult DeleteFile(int car_id,string path)
        {

            try
            {
                string deletePath = Path.Combine(Directory.GetCurrentDirectory(),
                   $"images/{path}");
                File.Delete(deletePath);
                return new SuccessResult();
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
           
        }
        private IResult UploadFile(IFormFile file,string imageName)
        {
            if (file != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(),
                    $"images/{imageName}");
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                return new SuccessResult();
            }
            else
                return new ErrorResult("Dosya Boş");

        }
    }
}
