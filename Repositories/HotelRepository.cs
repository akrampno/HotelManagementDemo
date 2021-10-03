using HotelManagementSystem.Contexts;
using HotelManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelContext _context;
        public HotelRepository(HotelContext context)
        {
            _context = context;
        }

        public IEnumerable<Hotel> Get(string Location, string CheckIn, string CheckOut,int RoomTypeCode)
        {
            var AllResult = from d in _context.Hotels.Include(e => e.Rooms) select d;
            
            if(string.IsNullOrEmpty(Location) == false)
            {
                AllResult = AllResult.Where(h => h.Location.Contains(Location));
            }
            if (RoomTypeCode > 0 )
            {
                AllResult = AllResult.Include(r => r.Rooms.Where(o => o.RoomTypeCode == RoomTypeCode));                    
            }            
            return AllResult;           
        }

        public Hotel Get(int Id)
        {
            Hotel Hotel = _context.Hotels.Include(e => e.Rooms).Where(o => o.Id == Id)                
                .FirstOrDefault();
            if (null != Hotel)
                return Hotel;
            else
                return null;
        }


        public async Task<Hotel> Create(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;

        }

        public int GetBookingId()
        {
            //DB logic can be implemented in order to get the Booking ID using sequence.
            return 1;            
        }

        public bool CreateBooking(BookingDetail BookingDetail)
        {
            try
            {
                _context.BookingDetails.Add(BookingDetail);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public IEnumerable<BookingDetail> GetBookings(int HotelId)
        {
            var AllResult = from d in _context.BookingDetails.Where(e => e.HotelId == HotelId) select d;
            return AllResult;
        }


    }
}
