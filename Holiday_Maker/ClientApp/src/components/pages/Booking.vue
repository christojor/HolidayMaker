<template>
    <div v-for="accomodation in accomodations" :key="accomodation">
        <div v-for="room in accomodation.rooms" :key="room">
            <div v-if="id == room.id">

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
    <Rewards />
    </div>

    <div class="my-1 px-1 w-full overflow-hidden">
    <PersonalDetails />
    </div>

  <div class="my-1 px-1 w-full overflow-hidden">
    <RoomDetails :roomDetails="roomDetails" />
  </div>

  <div class="my-1 px-1 w-full overflow-hidden">
    <PaymentDetails />
  </div>

  <div class="my-1 px-1 w-full overflow-hidden">
    <BuyNow />
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
    <PriceDetails />
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
  </div>
  <!-- End Logic Divs -->
</template>

<script>
import PriceDetails from '/src/components/bookings/PriceDetails.vue'
import BuyNow from '/src/components/bookings/BuyNow.vue'
import HotelDetails from '/src/components/bookings/HotelDetails.vue'
import PaymentDetails from '/src/components/bookings/PaymentDetails.vue'
import Rewards from '/src/components/bookings/Rewards.vue'
import RoomDetails from '/src/components/bookings/RoomDetails.vue'
import PersonalDetails from '/src/components/bookings/PersonalDetails.vue'

export default {
    created(){
        this.roomDetailsObjects.bookingInfo = this.bookingParams;
        this.roomDetailsObjects.roomInfo = this.bookedRooms;
    },

    data(){
        return {
            roomDetailsObjects: {
                bookingInfo: null, 
                roomInfo: null,
                }
        }
    },

    props: ["id"],

    components:{
        PriceDetails,
        BuyNow,
        HotelDetails,
        PaymentDetails,
        Rewards,
        RoomDetails,
        PersonalDetails,
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
            console.log(this.roomDetailsObjects)
            return this.roomDetailsObjects;
            },
        }
}
</script>