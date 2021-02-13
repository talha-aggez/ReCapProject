using Business.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarDetail();
            Rental rental = new Rental
            {
                CarId  = 2,
                RentDate = new DateTime(2012, 12, 02),
                CustomerId = 3,
            };
            RentalManager rentalManager
                = new RentalManager(new EfRentalDal());
            Console.WriteLine(rentalManager.Add(rental).Message);
        }

        private static void CarDetail()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var item in carManager.GetCarsDetails().Data)
            {
                Console.WriteLine(item.BrandName + " "
                    + item.ColorName + " " + item.CarName + " " + item.DailyPrice);
            }
        }
    }
}
