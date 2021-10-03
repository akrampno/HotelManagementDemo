using HotelManagementSystem.Models;
using HotelManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.BusinessLogic
{
    public class GetHotelsList : IGetHotelsList
    {
        private readonly IHotelRepository _HotelRepository;
        public GetHotelsList(IHotelRepository HotelRepository)
        {
            _HotelRepository = HotelRepository;
        }
        public IEnumerable<Hotel> GetHotels(string Location, string CheckIn, string CheckOut,
            int RoomTypeCode)
        {            
            return  _HotelRepository.Get(Location, CheckIn, CheckOut, RoomTypeCode);
        }
    }
}
