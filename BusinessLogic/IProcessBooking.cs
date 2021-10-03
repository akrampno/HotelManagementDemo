using HotelManagementSystem.RequestModel;
using HotelManagementSystem.ResponseModels;

namespace HotelManagementSystem.BusinessLogic
{
    public interface IProcessBooking
    {
        BookingConfirmation DoBooking(BookingRequest request);
    }
}