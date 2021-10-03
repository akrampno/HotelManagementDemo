using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.ResponseModels
{
    public class BookingConfirmation
    {
        public int ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public string BookingConfirmationNo { get; set; }
        public string BookingStatus { get; set; }
        public int HotelId { get; set; }
        public int RoomTypeCode { get; set; }
        public int NoofDayBooked { get; set; }
    }
}
