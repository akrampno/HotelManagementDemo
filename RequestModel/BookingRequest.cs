using HotelManagementSystem.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.RequestModel
{
    public class BookingRequest
    {
        [Required(ErrorMessage ="HotelId is required in the request")]
        [Range(1, int.MaxValue, ErrorMessage = "Valid HotelId is required in the request")]
        public int HotelId{ get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Valid RoomId is required in the request")]
        public int RoomId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Valid RoomTypeCode is required in the request")]
        public int RoomTypeCode { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Valid NoofDays is required in the request")]
        public int NoofDays { get; set; }
        [Required]        
        [DataType(DataType.DateTime)]
        public DateTime? FromDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? ToDate { get; set; }
        [Required]
        public PaymentStatus PaymentStatus { get; set; }
    }
}
