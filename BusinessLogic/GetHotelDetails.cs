using HotelManagementSystem.Models;
using HotelManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.BusinessLogic
{
    public class GetHotelDetails : IGetHotelDetails
    {
        private readonly IHotelRepository _HotelRepository;
        public GetHotelDetails(IHotelRepository HotelRepository)
        {
            _HotelRepository = HotelRepository;
        }
        public Hotel GetHotel(int Id)
        {
            return  _HotelRepository.Get(Id);
        }
    }
}
