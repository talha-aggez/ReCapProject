using Business.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var item in carManager.GetCarsDetails())
            {
                Console.WriteLine(item.BrandName + " " 
                    + item.ColorName + " " + item.CarName + " " + item.DailyPrice);
            }
        }
    }
}
