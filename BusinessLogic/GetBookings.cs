using HotelManagementSystem.Models;
using HotelManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.BusinessLogic
{
    public class GetBookings : IGetBookings
    {
        private readonly IHotelRepository _HotelRepository;
        public GetBookings(IHotelRepository HotelRepository)
        {
            _HotelRepository = HotelRepository;
        }
        public IEnumerable<BookingDetail> GetAllBookings(int HotelId)
        {
            return _HotelRepository.GetBookings(HotelId);
        }
    }
}
