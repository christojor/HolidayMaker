<template>

<div class="overflow-hidden border-2 rounded-md border-black shadow-md p-4 bg-green-1 divide-y-2 divide-gray-300">
  <form  id="payment-form">
    <div>
      <label>
        <div class="w-full overflow-hidden">
          <h2 class="text-xl text-green-6">Payment Details</h2>
        </div>
      </label>

      <h2 class="text-m text-green-6">Credit Card</h2>
      <div id="card-element" class="mt-2 mb-2 border-2 border-gray-300" v-if="this.isLoggedIn()">
      </div>
      <div v-else>
        <h1><b>Log in to submit payment.</b></h1>
      </div>

    <div id="SuccessMessage" class="alert" style="display:none">
      <span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
      <strong>Payment successful!</strong>
    </div>
  </div>

  <div class="flex flex-wrap overflow-hidden bg-green-1 mt-2">


    <div class="w-full overflow-hidden" v-if="this.isLoggedIn()">
      <button type="submit" class="bg-green-500 w-1/2 hover:bg-green-700 text-white font-bold py-2 px-2 mt-2 rounded-full">
        Buy Now
      </button>
    </div>

    <div class="w-full overflow-hidden" v-else>
      <button type="button" class="bg-gray-500 w-1/2 text-white font-bold py-2 px-2 mt-2 rounded-full">
        Buy Now
      </button>
    </div>
  </div>
  </form>
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
import mixin from '/src/mixins.js'

export default {
    mixins: [mixin],

  mounted() {
    //Building payment form starts here
    if(this.isLoggedIn()){
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
      this.awaitingPayment = true;
      event.preventDefault();
      stripe
        .createPaymentMethod({
          type: "card",
          card: cardElement,
          billing_details: {
            //Placeholder name
            name: self.$store.state.user.firstName + " " + self.$store.state.user.lastName,
            email: self.$store.state.user.email,
          },
        })
        .then(self.stripePaymentMethodHandler);
    });
    }
  },

  props: {
      makeBooking: {
        type: Object,
        required: true,
      },
      roomPrices: {
        type: Object,
        required: true,
      }
    },

    computed:{
      totalPoints(){
        return this.roomPrices.reduce((sum, room) => {
            return sum += room.price * this.nbrOfNights;
        }, 0);
      },
      nbrOfNights(){
        return this.$store.state.nbrOfNights
      }
    },

  methods: {
    
    async sendBooking() {
      this.$store.commit("setBooking", this.makeBooking);

      this.$store.dispatch("sendBooking");

      if(this.$store.state.user.memberTypeId == 1){
        this.$store.commit("setMemberPoints", this.totalPoints);
      }
      else if(this.$store.state.user.memberTypeId == 2){
        this.$store.commit("setMemberPoints", this.totalPoints * 1.25);
      }
      this.$store.dispatch("updateMemberPoints");
      },

    async stripePaymentMethodHandler(result) {
      var self = this;
      console.log("Hello this is the payment method handler greeting you!");
      if (result.error) {
        //show error in payment form
        console.log("Error firing");
      } else {
        this.$store.commit("setPaymentFailed", false)
        this.$store.commit("setPaymentFailureMessage", null)
        //otherwise send paymentMethod.id to your server
        await fetch("https://localhost:44323/api/Payment/Pay", {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify({
            PaymentMethodId: result.paymentMethod.id,
            totalPrice: this.$store.state.totalPrice,
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
        this.$store.commit("setPaymentFailed", true)
        this.$store.commit("setPaymentFailureMessage", response.error)
        this.$emit('emitToggle', this.toggleModal)
        console.log(this.$store.state.paymentError)
        console.log(this.$store.state.paymentErrorMessage)

      } else if (response.requires_action){
        //Use stripe.js to handle required card action
        console.log("Requires card action")
        stripe.handleCardAction(
          response.payment_intent_client_secret
        ).then(this.handleStripeJsResult);
      } else {
        //show success message
        console.log(response)
        // this.showSuccess();
        this.sendBooking()
        this.$emit('emitToggle', this.toggleModal)
        console.log("show success message")
      }
    },

    async handleStripeJsResult(result)
    {
      if(result.error){
        //Show error in payment form
      } else {
        //The card action has been handled
        //The paymentIntent can be confirmed again on the server
        await fetch("https://localhost:44323/api/Payment/Pay", {
          method: 'POST',
          headers: {'Content-Type': 'application/json' },
          body: JSON.stringify({ paymentIntentId: result.paymentIntent.id })
        }).then(function(confirmResult) {
          return confirmResult.json();
        }).then(this.handleServerResponse);
      }
    },
    showSuccess(){
      var successMessage = document.getElementById("SuccessMessage");
      successMessage.style.display = "block";
    }
  },
  data(){
    return{
      toggleModal: true,
    }
  }
};

</script>