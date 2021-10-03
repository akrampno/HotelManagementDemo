using HotelManagementSystem.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.BusinessLogic
{
    public class BusinessRules : IBusinessRules
    {
        public bool ValidateBusinessRules(BookingRequest request)
        {
            return true;
        }
    }
}
