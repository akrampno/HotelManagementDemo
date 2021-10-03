using HotelManagementSystem.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Models
{
    public class BookingDetail
    {
        [Key]
        public string BookingId { get; set; }
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }        
        public PaymentStatus PaymentStatus { get; set; }
    }
}
