using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Repositories
{
    public interface IHotelRepository
    {
        IEnumerable<Hotel> Get(string Location, string CheckIn, string CheckOut, int RoomTypeCode);
        Hotel Get(int Id);
        Task<Hotel> Create(Hotel hotel);
        public int GetBookingId();
        public bool CreateBooking(BookingDetail BookingDetail);
        public IEnumerable<BookingDetail> GetBookings(int HotelId);
    }
}
