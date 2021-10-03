using HotelManagementSystem.RequestModel;

namespace HotelManagementSystem.BusinessLogic
{
    public interface IBusinessRules
    {
        bool ValidateBusinessRules(BookingRequest request);
    }
}