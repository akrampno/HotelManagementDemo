using HotelManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Contexts
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {
            Database.EnsureCreated();            
        }
        public DbSet<Hotel> Hotels { get; set; }        
        public DbSet<BookingDetail> BookingDetails { get; set; }
        
    }
}
