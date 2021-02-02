using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        void GetAll();
        List<Car> GetAll2();
        void Add();
        void Delete();
    }
}
