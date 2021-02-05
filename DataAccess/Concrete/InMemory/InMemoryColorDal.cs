using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryColorDal:IColorDal
    {
        List<Color> _colors;
        public InMemoryColorDal()
        {
            _colors = new List<Color>
            {
                new Color
                {
                    Id = 1,
                    ColorName = "Red"
                },
                new Color
                {
                    Id = 2,
                    ColorName = "Blue",
                },
                new Color
                {
                    Id = 3,
                    ColorName = "Black"
                }
            };
        }

        public void Add(Color entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Color entity)
        {
            throw new NotImplementedException();
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetAll()
        {
            return _colors;
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Color GetById(int id)
        {
            return _colors.Where(p => p.Id == id).FirstOrDefault();
        }

        public void Update(Color entity)
        {
            throw new NotImplementedException();
        }
    }
}
