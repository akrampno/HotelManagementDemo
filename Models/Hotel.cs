using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace HotelManagementSystem.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string FacilitiesAvailable { get; set; }
        public double LowestPrice { get; set; }
        public string CurrentyCode { get; set; }
        public string HotelImageURL { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
