using Business.Concrete;
using DataAccess.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal(),new InMemoryBrandDal(),new InMemoryColorDal());
            int i = 0;
            do
            {
                Console.WriteLine("0-) Cıkıs 1-) Sil 2-) Ekle 3-) Listele");
                i = Convert.ToInt32(Console.ReadLine());
                switch(i){
                    case 0: Console.WriteLine("Çıkış"); break;
                    case 1: carManager.Delete(); break;
                    case 2: carManager.Add();break;
                    case 3: carManager.GetAll(); break;
                    default: Console.WriteLine("Yanlış Girdiniz"); break;
                }
            } while (i != 0);
        }
    }
}
