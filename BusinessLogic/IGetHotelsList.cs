using HotelManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagementSystem.BusinessLogic
{
    public interface IGetHotelsList
    {
        IEnumerable<Hotel> GetHotels(string Location, string CheckIn, string CheckOut,
            int RoomTypeCode);
    }
}