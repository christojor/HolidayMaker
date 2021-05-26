<template>
  <div class="border-2 rounded-md border-black shadow-md p-4 bg-green-1 divide-y-2 divide-gray-300 border-2">

    <form  id="payment-form">
      <label>
        <div class="w-full overflow-hidden">
            <h2 class="text-xl text-green-6">Payment Details</h2>
        </div>
        </label>
        <div id="card-element" class="mt-2 mb-2"></div>
      <button type="submit">Submit payment</button>
    </form>
    <div id="SuccessMessage" class="alert" style="display:none">
      <span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span> 
      <strong>Payment done!</strong> 
    </div>
  </div>
</template>

<style>
.alert{
  padding: 20px;
  background-color: #04AA6D;
  color: white;
}
.closebtn {
  margin-left: 15px;
  color: white;
  font-weight: bold;
  float: right;
  font-size: 22px;
  line-height: 20px;
  cursor: pointer;
  transition: 0.3s;
}
.closebtn:hover {
  color: black;
}
</style>


<script>
export default {
  mounted: function () {
    //Building payment form starts here
    var stripe = Stripe(
      "pk_test_51IsjoPK0RxPPVgejwsizP9ghkzrEOEAho8VjGbz0Rtn2i31J5t5zr6NGp04eZD0ZHF5TwIzvCZf2XFmZR4syWqiY00ldbn6Luv"
    );
    var elements = stripe.elements();
    var style = {
      base: {
        color: "#32325d",
        fontFamily: '"Helvetica Neue", Helvetica, sans-serif',
        fontSmoothing: "antialiased",
        fontSize: "16px",
        "::placeholder": {
          color: "#aab7c4",
        },
      },
      invalid: {
        color: "#000000",
        iconColor: "#000000",
      },
    };
    var cardElement = elements.create("card", { style: style });
    cardElement.mount("#card-element");
    //Payment for ends here
    //PaymentMethod starts here
    
    var self = this;
    var form = document.getElementById("payment-form");
    form.addEventListener("submit", function (event) {
      event.preventDefault();
      stripe
        .createPaymentMethod({
          type: "card",
          card: cardElement,
          billing_details: {
            //Placeholder name
            name: "Johan Rova",
          },
        })
        .then(self.stripePaymentMethodHandler);
    });
  },
  methods: {
    stripePaymentMethodHandler(result) {
      var self = this;
      console.log("Hello this is the payment method handler greeting you!");
      if (result.error) {
        //show error in payment form
        console.log("Error firing");
      } else {
        //otherwise send paymentMethod.id to your server
        console.log(result);
        fetch("https://localhost:44323/api/Payment/Pay", {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify({
            PaymentMethodId: result.paymentMethod.id,
          }),
        }).then(function (result) {
          //handle server response step 4
          result.json().then(function (json) {
            self.handleServerResponse(json);
          });
        });
      }
    },
    handleServerResponse(response){
      if(response.error){
        //Show error from server on payment form
        console.log("Show error message")
      } else if (response.requires_action){
        //Use stripe.js to handle required card action
        console.log("Requires card action")
        stripe.handleCardAction(
          response.payment_intent_client_secret
        ).then(this.handleStripeJsResult);
      } else {
        //show success message
        console.log(response)
        this.showSuccess();
        console.log("show success message")
      }
    },
    handleStripeJsResult(result)
    {
      if(result.error){
        //Show error in payment form
      } else {
        //The card action has been handled
        //The paymentIntent can be confirmed again on the server
        fetch("https://localhost:44323/api/Payment/Pay", {
          method: 'POST',
          headers: {'Content-Type': 'application/json' },
          body: JSON.stringify({ paymentIntentId: result.paymentIntent.id })
        }).then(function(confirmResult) {
          return confirmResult.json();
        }).then(this.handleServerResponse);
      }
    },
        lolgsomeshit(){
      console.log("fucker");
    },
    logToConsole() {
      console.log("lmsssssssssssssssssao");
    },
    showSuccess(){
      var lol = document.getElementById("SuccessMessage");
      lol.style.display = "block";
    }
  },
};
</script>