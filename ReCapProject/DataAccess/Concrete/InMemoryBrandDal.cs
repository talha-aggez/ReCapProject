using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryBrandDal : IBrandDal
    {
        List<Brand> _brands;
        public InMemoryBrandDal()
        {
            _brands = new List<Brand>
            {
                new Brand
                {
                    Id = 1,
                    BrandName = "Toyota"
                },
                new Brand
                {
                    Id = 2,
                    BrandName = "BMW"
                },
                new Brand
                {
                    Id = 3,
                    BrandName = "KIA"
                }
            };
        }
        public List<Brand> GetAll()
        {
            return _brands;
        }

        public Brand GetById(int id)
        {
            return _brands.Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
