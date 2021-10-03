using HotelManagementSystem.BusinessLogic;
using HotelManagementSystem.Models;
using HotelManagementSystem.Repositories;
using HotelManagementSystem.RequestModel;
using HotelManagementSystem.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository _HotelRepository;
        private readonly IGetHotelsList _GetHotelsList;
        private readonly IGetHotelDetails _GetHotelDetails;
        private readonly IProcessBooking _ProcessBooking;
        private readonly IGetBookings _GetBookings;
        public HotelController(IHotelRepository HotelRepository,
            IGetHotelsList GetHotelsList,
            IGetHotelDetails GetHotelDetails,
            IProcessBooking ProcessBooking,
            IGetBookings GetBookings
            )
        {
            _HotelRepository = HotelRepository;
            _GetHotelsList = GetHotelsList;
            _GetHotelDetails = GetHotelDetails;
            _ProcessBooking = ProcessBooking;
            _GetBookings = GetBookings;
        }

        [HttpGet]
        public IEnumerable<Hotel> GetHotels(string Location, string CheckIn, string CheckOut, int RoomTypeCode)
        {            
            return _GetHotelsList.GetHotels(Location, CheckIn, CheckOut, RoomTypeCode);
        }

        [HttpGet("{Id}")]
        public Hotel GetHotel(int Id)
        {            
            return _GetHotelDetails.GetHotel(Id);
        }


        [HttpPost]
        [Route("RoomBooking")]
        public BookingConfirmation BookHotel([FromBody] BookingRequest request)
        {
            return _ProcessBooking.DoBooking(request);
        }


        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel([FromBody] Hotel hotel)
        {
            Hotel ResponseHotel = await _HotelRepository.Create(hotel);
            //return ResponseHotel;
            return CreatedAtAction(nameof(GetHotels), new { id = ResponseHotel.Id }, ResponseHotel);
        }


        [HttpGet]
        [Route("Bookings/{HotelId}")]
        public IEnumerable<BookingDetail> GetBooking(int HotelId)
        {
            return _GetBookings.GetAllBookings(HotelId);
        }
    }
}
