using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;IBrandDal _brandDal;IColorDal _colorDal;
        public CarManager(ICarDal carDal,IBrandDal brandDal,IColorDal colorDal)
        {
            _carDal = carDal;
            _colorDal = colorDal;
            _brandDal = brandDal;
        }

        public void Add()
        {
            Car car = new Car();
            List<Car> temp = _carDal.GetAll();
            car.Id = temp.Count + 1;
            Console.Write("BrandId yi giriniz");
            car.BrandId = Convert.ToInt32(Console.ReadLine());
            Console.Write("ColorId yi giriniz");
            car.ColorId = Convert.ToInt32(Console.ReadLine());
            Console.Write("ModelYear yi giriniz");
            car.ModelYear = Console.ReadLine();
            Console.Write("Description giriniz");
            car.ModelYear = Console.ReadLine();
            _carDal.Add(car); 
        }

        public void Delete()
        {
            Console.WriteLine("Silincek olan aracın idsini giriniz : ");
            int id = Convert.ToInt32(Console.ReadLine());
            _carDal.Delete(_carDal.GetAll().Where(p => p.Id == id).FirstOrDefault());
        }

        public void GetAll()
        {
            foreach (var item in _carDal.GetAll())
            {
                Console.Write(item.Id + " ");
                Console.Write(_brandDal.GetById(item.BrandId).BrandName + " ");
                Console.Write(_colorDal.GetById(item.ColorId).ColorName + " ");
                Console.Write(item.DailyPrice + " ");
                Console.WriteLine(item.Description);
            }
        }

        public List<Car> GetAll2()
        {
            return _carDal.GetAll();
        }
    }
}
