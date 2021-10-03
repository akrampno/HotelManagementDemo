using HotelManagementSystem.Models;
using System.Collections.Generic;

namespace HotelManagementSystem.BusinessLogic
{
    public interface IGetBookings
    {
        IEnumerable<BookingDetail> GetAllBookings(int HotelId);
    }
}