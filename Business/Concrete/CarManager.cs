using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
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

        public CarManager(ICarDal carDal, IBrandDal brandDal, IColorDal colorDal)
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
            Console.WriteLine("Name ' i  giriniz");
            car.Name = Console.ReadLine();
            if (car.Name.Length < 2)
            {
                Console.WriteLine("İkiden az karakter girdiniz.");
                return;
            }
            Console.Write("BrandId yi giriniz");
            car.BrandId = Convert.ToInt32(Console.ReadLine());
            Console.Write("ColorId yi giriniz");
            car.ColorId = Convert.ToInt32(Console.ReadLine());
            Console.Write("ModelYear yi giriniz");
            car.ModelYear = Console.ReadLine();
            Console.WriteLine("DailyPrice'ı giriniz");
            car.DailyPrice = Convert.ToInt32(Console.ReadLine());
            if(car.DailyPrice <= 0)
            {
                Console.WriteLine("Daily Price sıfır veya daha az girdiniz");
                return;
            }
            Console.Write("Description giriniz");
            car.ModelYear = Console.ReadLine();
            _carDal.Add(car);
        }

        public void Delete()
        {
            Console.WriteLine("Silincek olan aracın idsini giriniz : ");
            int id = Convert.ToInt32(Console.ReadLine());
            _carDal.Delete(_carDal.Get(p => p.Id == id));
        }

        public void GetAll()
        {
            foreach (var item in _carDal.GetAll())
            {
                Console.Write(item.Id + " ");
                Console.Write(_brandDal.Get(p => p.Id == item.BrandId).BrandName + " ");
                Console.Write(_colorDal.Get(p => p.Id == item.ColorId).ColorName + " ");
                Console.Write(item.DailyPrice + " ");
                Console.WriteLine(item.Description);
            }
        }

        public List<Car> GetAll2()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(p => p.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(p => p.ColorId == colorId);
        }
    }
}

