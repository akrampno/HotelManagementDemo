using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelManagementSystem.BusinessLogic
{
    public interface IGetHotelDetails
    {
        Hotel GetHotel(int Id);
    }
}