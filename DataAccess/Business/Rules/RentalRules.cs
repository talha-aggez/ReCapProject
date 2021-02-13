using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Rules
{
    public static class RentalRules
    { 
        public static bool RentalAddingCheck(Rental rental, IRentalDal rentalDal)
        {
            foreach (Rental item in rentalDal.GetAll(p => p.CustomerId == rental.CustomerId))
            {
                if (item.ReturnDate == new DateTime(1753, 1, 1))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
