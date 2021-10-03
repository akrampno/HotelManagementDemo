using HotelManagementSystem.BusinessLogic;
using HotelManagementSystem.Logger;
using HotelManagementSystem.Models;
using HotelManagementSystem.Repositories;
using HotelManagementSystem.RequestModel;
using HotelManagementSystem.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

/*
 * These APIs are customer facing APIs 
 * 
 */

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
        private readonly IConfiguration _Iconfig;
        private readonly ILoggerManager _logger;

        public HotelController(IHotelRepository HotelRepository,
            IGetHotelsList GetHotelsList,
            IGetHotelDetails GetHotelDetails,
            IProcessBooking ProcessBooking,
            IGetBookings GetBookings,
            IConfiguration Iconfig,
            ILoggerManager logger
            )
        {
            _HotelRepository = HotelRepository;
            _GetHotelsList = GetHotelsList;
            _GetHotelDetails = GetHotelDetails;
            _ProcessBooking = ProcessBooking;
            _GetBookings = GetBookings;
            _Iconfig = Iconfig;
            _logger = logger;
        }

        /*
         * GetHotels API will be used by clients to get the list of hotesl 
         * 
         * Search criterias are option and can be provided to filter the search result
         * 
         */
        [HttpGet]
        public IEnumerable<Hotel> GetHotels(string Location, string CheckIn, string CheckOut, int RoomTypeCode)
        {            
            _logger.LogInformation("Received get hotel list request");
            return _GetHotelsList.GetHotels(Location, CheckIn, CheckOut, RoomTypeCode);
        }

        /*
         * GetHotel - API is used to retrieve the details of a particular hotel
         * 
         * Hotel ID must be passed as param
         * 
         * 
         */
        [HttpGet("{Id}")]
        public Hotel GetHotel(int Id)
        {
            _logger.LogInformation("Received get hotel details for hotel id:"+Id);
            return _GetHotelDetails.GetHotel(Id);
        }

        /*
         * 
         * below API will be used to process booking for hotel.
         * 
         * Hotel ID, Room Type, No of days and payment status are some of the mandetory params to process the bookings
         * 
         * 
         */
        [HttpPost]
        [Route("RoomBooking")]
        public BookingConfirmation BookHotel([FromBody] BookingRequest request)
        {
            _logger.LogInformation("Received Booking request:" + JsonSerializer.Serialize(request));
            return _ProcessBooking.DoBooking(request);
        }


        /*
         * 
         * the below API can be exposed to customer for retrieving booking details for a hotel.
         * 
         */
        [HttpGet]
        [Route("Bookings/{HotelId}")]
        public IEnumerable<BookingDetail> GetBooking(int HotelId)
        {
            return _GetBookings.GetAllBookings(HotelId);
        }

        /*
         * 
         * the below API is used to create the hotels and rooms in the database for testing.
         * 
         */
        [HttpPost]
        async Task<ActionResult<Hotel>> PostHotel([FromBody] Hotel hotel)
        {
            Hotel ResponseHotel = await _HotelRepository.Create(hotel);            
            return CreatedAtAction(nameof(GetHotels), new { id = ResponseHotel.Id }, ResponseHotel);
        }

    }
}
