using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public void Add(Brand entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Brand entity)
        {
            throw new NotImplementedException();
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll()
        {
            return _brands;
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Brand GetById(int id)
        {
            return _brands.Where(p => p.Id == id).FirstOrDefault();
        }

        public void Update(Brand entity)
        {
            throw new NotImplementedException();
        }
    }
}
