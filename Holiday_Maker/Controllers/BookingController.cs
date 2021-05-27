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


        [HttpPost("CreateBooking")]
        public async Task<bool> CreateBooking(BookingHelper booking)
        {
            return await _bookingService.CreateBooking(booking);
        }
    }
}
