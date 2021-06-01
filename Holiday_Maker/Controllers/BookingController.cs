using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holiday_Maker.Helper;
using Holiday_Maker.Models;
using Holiday_Maker.Services;

namespace Holiday_Maker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        private readonly BookingService _bookingService;

        public BookingController()
        {
            _bookingService = new BookingService();
        }

        //Creates a booking
        [HttpPost("CreateBooking")]
        public async Task<bool> CreateBooking(BookingHelper booking)
        {
            return await _bookingService.CreateBooking(booking);
        }

        //"Cancels" a booking, sets the Cancellation date to the current date.
        [HttpPut("CancelBooking/{id}")]
        public async Task<bool> CancelBooking(int id)
        {
            return await _bookingService.CancelBooking(id);
        }
        
    }
}
