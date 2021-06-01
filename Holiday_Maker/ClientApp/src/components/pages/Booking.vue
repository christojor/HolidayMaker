<template>
    <PaymentModal :toggleModal="toggleModal" @emitToggle="toggleModalMethod"/>
    <div v-for="accomodation in accomodations" :key="accomodation">
            <div v-if="id == accomodation.id">

<div class="flex flex-wrap overflow-hidden mt-3 mb-3">

  <div class="w-1/6 overflow-hidden">
    <!-- Filler Div -->
  </div>
  <!-- Begin Content Div -->

  <div class="w-4/6 overflow-hidden">
  <h2 class="text-green-6 mb-2" style="font-size: 40px;">Booking Summary</h2>
    <div class="flex flex-wrap overflow-hiddenshadow-md rounded-md">

  <div class="w-1/2 overflow-hidden">
    <!-- Rewards / Rooms / Payment Info / Book Now -->
    
    <div class="flex flex-wrap overflow-hidden">

    <div class="my-1 px-1 w-full overflow-hidden">
      <Rewards :roomPrices="bookedRooms"/>
    </div>

    <div class="my-1 px-1 w-full overflow-hidden" v-if="this.isLoggedIn()">
      <PersonalDetails :userDetails="currentUser" />
    </div>

    <div class="my-1 px-1 w-full overflow-hidden" v-else>
    <h1><b>You must be logged in to complete your booking.</b></h1>
    </div>

  <div class="my-1 px-1 w-full overflow-hidden">
    <RoomDetails :roomDetails="roomDetails" />
  </div>

</div>

  </div>

  <div class="w-1/2 overflow-hidden">
    <!-- Hotel Info / Price Summary -->

    <div class="flex flex-wrap overflow-hidden">

  <div class="my-1 px-1 w-full overflow-hidden">
    <!-- Hotel Summary -->
    <HotelDetails :accomodation="accomodation" />
  </div>

  <div class="my-1 px-1 w-full overflow-hidden">
    <PriceDetails :roomPrices="bookedRooms" />
  </div>

   <div class="my-1 px-1 w-full overflow-hidden">
    <PaymentDetails :makeBooking="bookingDetails" @emitToggle="toggleModalMethod" :roomPrices="bookedRooms"/>
  </div>

</div>
  </div>
</div>
  </div>
  <!-- End Content Div -->
  <div class="w-1/6 overflow-hidden">
    <!-- Filler Div -->
  </div>
</div>                 
<!-- End Design Divs -->
    </div>
  </div>
  <!-- End Logic Divs -->
</template>

<script>
import PriceDetails from '/src/components/bookings/PriceDetails.vue'
import HotelDetails from '/src/components/bookings/HotelDetails.vue'
import PaymentDetails from '/src/components/bookings/PaymentDetails.vue'
import Rewards from '/src/components/bookings/Rewards.vue'
import RoomDetails from '/src/components/bookings/RoomDetails.vue'
import PersonalDetails from '/src/components/bookings/PersonalDetails.vue'
import PaymentModal from '/src/components/bookings/elements/PaymentModal.vue'
import mixin from '/src/mixins.js'

export default {
    mixins: [mixin],

    beforeRouteLeave (to, from , next) {
        const answer = window.confirm('Your booking will be cancelled if you leave this page. Are you sure?')

        if (answer) {
          next()
        } 
        else {
          next(false)
        }
    },

    created(){
        this.roomDetailsObjects.bookingInfo = this.bookingParams;
        this.roomDetailsObjects.roomInfo = this.bookedRooms;

        // Check if user is logged in, but user state is null then get user
        if (this.isLoggedIn == true && this.$store.state.user == null){
          this.$store.dispatch("getUser");
        }
    },

    beforeUnmount() {
      this.setBookedRooms([]);
      console.log(this.$store.state.bookedRooms);
    },

    data(){
        return {
            roomDetailsObjects: {
                bookingInfo: null, 
                roomInfo: null,
                },

            bookingObject: {
              booking: {
                UserId: null,
                AccomodationId: null,
                NbrOfAdults: null,
                NbrOfChildren: null,
                CheckOutDate: null,
                CheckInDate: null,
                PaymentDate: null,
              },
              bookedRoom: []
            },
            toggleModal: false
        }
    },

    props: ["id"],

    components:{
        PriceDetails,
        HotelDetails,
        PaymentDetails,
        Rewards,
        RoomDetails,
        PersonalDetails,
        PaymentModal,
    },

    computed: {
        accomodations() {
            return this.$store.state.accomodations;
        },
        bookedRooms() {
            return this.$store.state.bookedRooms;
        },
        bookingParams() {
            return this.$store.state.bookingParams;
        },
        roomDetails() {
            return this.roomDetailsObjects;
        },
        bookingDetails() {
            this.bookingObject.booking.UserId = this.$store.state.userId;
            this.bookingObject.booking.AccomodationId = this.id;
            this.bookingObject.booking.NbrOfAdults = this.bookingParams.travellersAdults;
            this.bookingObject.booking.NbrOfChildren = this.bookingParams.travellersChildren;
            this.bookingObject.booking.CheckInDate = this.bookingParams.checkIn;
            this.bookingObject.booking.CheckOutDate = this.bookingParams.checkOut;
            this.bookingObject.bookedRoom = this.bookedRooms

            for (var i = 0; i < this.bookingObject.bookedRoom.length; i++){
            this.bookingObject.bookedRoom[i].roomId = this.bookingObject.bookedRoom[i].id;}

            return this.bookingObject;
        },
        currentUser() {
            return this.$store.state.user;
        },
    },
    methods: {
      setBookedRooms(payload){
        this.$store.commit("setBookedRooms", payload);
      },
      toggleModalMethod(toggleModal){
        this.toggleModal = toggleModal
      },
      
    }
  }
</script>