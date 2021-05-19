using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holiday_Maker.Services;
using Stripe;

namespace Holiday_Maker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private PaymentService _paymentService;
        public PaymentController()
        {
            _paymentService = new PaymentService();
        }
        // GET: api/PaymentIntent
        [HttpPost("PaymentIntent")]
        public async Task<string> PaymentIntent()
        {
            return _paymentService.MakePayment().ToJson();
        }
    }
}
