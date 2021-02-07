using Business.Abstract;
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
        public void Add(Brand brand)
        {
            _brandal.Add(brand);
        }

        public void Delete(Brand brand)
        {
            _brandal.Delete(brand);
        }

        public List<Brand> GetAll()
        {
           return _brandal.GetAll();
        }

        public Brand GetBrand(int id)
        {
            return _brandal.Get(p => p.Id == id);
        }

        public void Update(Brand brand)
        {
            _brandal.Update(brand);
        }
    }
}
