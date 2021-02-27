using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IResult Update(CarImage brand);
        IResult Add(IFormFile file,int id);
        IResult Delete(CarImage carImage);
        IDataResult<List<CarImage>> GetCarImageById(int id);
    }
}
