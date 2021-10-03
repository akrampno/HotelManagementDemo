using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public int RoomTypeCode { get; set; }
        public string RoomType { get; set; }
        public int TotalRooms { get; set; }
        public int AvailableRooms { get; set; }
        public double ActualPricePerNight { get; set; }
        public double PromotionalPricePerNight { get; set; }
        public bool IsPromotionAvailable { get; set; }
        
    }
}
