using Stripe;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Holiday_Maker.Services
{
    public class PaymentService
    {
        private readonly Secret stripeAPI;

        public PaymentService()
        {
            string readText = System.IO.File.ReadAllText(@".\secrets.json");
            StripeConfiguration.ApiKey = JsonSerializer.Deserialize<Secret>(readText).Key;
        }

        public PaymentIntent CreatePaymentIntent()
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = 250,
                Currency = "usd",
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },
            };
            PaymentIntentService service = new PaymentIntentService();
            PaymentIntent intent = service.Create(options);
            return intent;
        }

    }
}
