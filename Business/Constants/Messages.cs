using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        //--------------- Marka Mesajları----------------
        public static string BrandAdded = "Marka Eklendi..";
        public static string BrandDeleted = "Marka Silindi";
        public static string BrandUpdated = "Marka Güncellendi";
        public static string BrandListed = "Markalar Listelendi";
        //-------------- Araba Mesajları -----------------
        public static string CarAdded = "Araba Eklendi";
        public static string CarDeleted = "Araba Silindi";
        public static string CarListed = "Arabalar Listelendi";
        public  static string CarUpdated = "Arabalar Güncellendi";
        //------------- Color Mesajları -----------------------
        public  static string ColorAdded = "Renk Eklendi";
        public static string ColorListed = "Renk Listelendi";
        public static string ColorDeleted = "Renk Silindi";
        public static string ColorUpdated = "Renk Güncellendi";
        //------------- Rental Messajları ----------------------
        public  static string RentalAdded = "Kiralama Eklendi";
        public static string RentalDeleted = "Kiralama Silindi";
        public static string RentalListed = "Kiralama Listelendi";
        public static string RentalUpdated = "Kiralama Güncellendi";
        public static string RentalCantAdded = "Kiralama Yapılamadı";
        //User Mesajları
        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UserListed = "Kullanıcı Listelendi";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        //Customer Mesajları
        public static string Added = "Müşteri Eklendi";
        public static string Deleted = "Müşteri Silindi";
        public static string CustomerListed = "Müşteri Listelendi";
        public static string CustomerUpdated = "Müşteri Güncellendi";
        //Car Image Messages
        public static string CarImageAdded = "Car Image Added";
        public static string CarImageDeleted = "Car Image Deleted";
        public static string CarImageListed = "Car Images Listed";
        public static string CarImageUpdated = "Car Image Updated";
        public static string CarImageLimitExceded = "Car Image Exceeded";
        internal static string CarImageEmpty = "File empty";
        internal static string CarNotFound = "Car Not Found";
    }
}
