using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Color> GetAll()
        {
            return _colors;
        }

        public Color GetById(int id)
        {
            return _colors.Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
