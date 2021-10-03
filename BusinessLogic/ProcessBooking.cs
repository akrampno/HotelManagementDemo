using HotelManagementSystem.Models;
using HotelManagementSystem.Repositories;
using HotelManagementSystem.RequestModel;
using HotelManagementSystem.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.BusinessLogic
{
    public class ProcessBooking : IProcessBooking
    {
        private readonly IBusinessRules _BusinessRules;
        private readonly IHotelRepository _HotelRepository;
        public ProcessBooking(IBusinessRules BusinessRules, IHotelRepository HotelRepository)
        {
            _BusinessRules = BusinessRules;
            _HotelRepository = HotelRepository;
        }

        public BookingConfirmation DoBooking(BookingRequest request)
        {
            BookingConfirmation Response = new BookingConfirmation();

            if (_BusinessRules.ValidateBusinessRules(request))
            {
                //Hotel Hotel = _HotelRepository.Get(request.HotelId);
                //Room Room = Hotel.Rooms.Where(o => o.RoomId == request.RoomId).Single();
                string BookingConfirmationNo = Guid.NewGuid().ToString().Replace("-", "").ToUpper();
                BookingDetail BookingDetail = new BookingDetail();
                BookingDetail.BookingId = BookingConfirmationNo;
                BookingDetail.HotelId = request.HotelId;
                BookingDetail.RoomId = request.RoomId;
                BookingDetail.FromDate = (DateTime)request.FromDate;
                BookingDetail.ToDate = (DateTime)request.ToDate;
                BookingDetail.PaymentStatus = request.PaymentStatus;
                //Room.BookingDetail = BookingDetail;

                if (_HotelRepository.CreateBooking(BookingDetail))
                {
                    Response.ResponseCode = 0;
                    Response.ResponseDescription = "Success";
                    Response.BookingConfirmationNo = BookingConfirmationNo;
                    Response.BookingStatus = "Confirmed";
                    Response.HotelId = request.HotelId;
                    Response.RoomTypeCode = request.RoomTypeCode;
                    Response.NoofDayBooked = request.NoofDays;
                    return Response;
                }
                else
                {
                    Response.ResponseCode = 0;
                    Response.ResponseDescription = "Booking Failed";
                    return Response;
                }

            }
            else
            {
                Response.ResponseCode = 99;
                Response.ResponseDescription = "Booking Failed. Please validate the request";
                return Response;
            }
            
        }

        
    }
}
