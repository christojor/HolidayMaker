<template>
  <div>
    <form  id="payment-form">
      <label>
        Card details
        <!-- placeholder for elements -->
        <div id="card-element"></div>
      </label>
      <button type="submit">Submit payment</button>
    </form>
    <button v-on:click="lolgsomeshit">click me </button>
  </div>
</template>

<script>
export default {
  mounted: function () {
    console.log("lmao");
    this.logToConsole;
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
        color: "#fa755a",
        iconColor: "#fa755a",
      },
    };
    var cardElement = elements.create("card", { style: style });
    cardElement.mount("#card-element");
    //Payment for ends here
    //PaymentMethod starts here

    var form = document.getElementById("payment-form");
    form.addEventListener("submit", function (event) {
      event.preventDefault();
      stripe
        .createPaymentMethod({
          type: "card",
          card: cardElement,
          billing_details: {
            name: "Johan Rova",
          },
        })
        .then(function(result)
        {
          console.log(result);
          if(result.error)
          {
            console.log("error");
          }
          else
          {
            let rawResponse = fetch("Api/Payment/Pay", {
              method: "POST",
              headers: {"Content-Type": "application/json" },
              body: JSON.stringify({
                payment_method_id: result.payment_method_id,
              }),
            })
            console.log("API call executed")
            console.log(rawResponse)
          }
        });
    });
  },
  methods: {
    stripePaymentMethodHandler(result) {
      console.log("Hello this is the payment method handler greeting you!");
      if (result.error) {
        //show error in payment form
        console.log("Error firing");
      } else {
        //otherwise send paymentMethod.id to your server
        console.log("Paymenthandler firing");
        fetch("/pay", {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify({
            payment_method_id: result.paymentMethod.id,
          }),
        }).then(function (result) {
          //handle server response step 4
          result.json().then(function (json) {
            handleServerResponse(json);
          });
        });
      }
    },
        lolgsomeshit(){
      console.log("fucker");
    },
    logToConsole() {
      console.log("lmsssssssssssssssssao");
    }
  },
};
</script>