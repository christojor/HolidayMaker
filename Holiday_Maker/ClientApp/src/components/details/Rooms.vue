<template>
<div v-if="roomAvailable">
<b>AVAILABLE ROOMS</b> from <b>{{ bookingParams.checkIn }}</b> to <b>{{ bookingParams.checkOut }}</b>
<div v-for="room in rooms" :key="room.id">
<div class="flex flex-wrap overflow-hidden border-black border-2 p-1 m-1">

  <div class="w-1/2 overflow-hidden p-2">
    <img class="rounded-md roomImg" :src="room.imgSrc">
   </div>

   <div class="w-1/2 overflow-hidden p-4">
    <form>     
     <button type="button" :class="toggleClass.add" @click="toggleAddRemoveButton($event); addToBooking(room)">
       Add / Remove
     </button>
     </form>
     <div>
     <b>Room Type:</b> {{ room.roomType.name }}<br>
     <b>Number of Guests: </b> {{ room.nbrOfGuests }}<br>
     <b>Number of Extra Beds:</b> {{ room.nbrOfExtraBeds }}<br>
     <b>Price:</b> {{ room.price }}€ <br>
     <div v-if="room.isRefundable == true"><b>Refund:</b> Yes<br /></div>
          <div v-if="room.isRefundable == false"><b>Refund:</b> No<br /></div>
          <b>Description:</b> {{ room.description }}<br />
          <b>Extras at extra price: </b>
          <Extras :extrasList="extrasList" @addExtra="addExtraMethod" @removeExtra="removeExtraMethod"/>
          </div>
        </div>
      </div>
    </div>
  </div>

</template>


<script>
import Extras from "/src/components/details/RoomExtras.vue";

export default {
  components:{
    Extras
  },
  data() {
    return {
      image: "./assets/images/fullyBooked.png",
      savedExtras: [],
      totalPrice: 0,
      toggleClass:{
        add: "float-right bg-green-500 hover:bg-green-700 text-white font-bold py-2 px-4 rounded-full",
        added:"float-right bg-red-500 hover:bg-red-700 text-white font-bold py-2 px-4 rounded-full"
      },
    }
  },

   props: {
    rooms: {
      type: Object,
      required: true,
    },
    extrasList: {
      type: Object,
      required: true,
    },
    bookingParams: {
      type: Object,
      required: true,
    }
  },

  computed:{
    roomAvailable(){
     if (this.rooms.length){
       return true;
      }
       else {
         return false;
       }
     }
    },

  methods: {
    addToBooking(room) {
      if (this.roomAdded(room))
      {
        window.alert('Room added to booking.')
      this.$store.commit("addToBookedRooms", room)
      }
      else{
        window.alert('Room removed from booking.')
        this.$store.commit("removeFromBookedRooms", room)
      }
    },
    addExtraMethod(Extra){
      this.savedExtras.push(Extra.Name)

      this.totalPrice += Extra.Price

      this.$store.commit('updateExtrasPrice', this.totalPrice)
      this.$store.commit('updateSelectedExtras', this.savedExtras)

      console.log(this.$store.state.extrasPrice)
      console.log(this.$store.state.selectedExtras)
    },
    removeExtraMethod(Extra){
      this.savedExtras.filter(extra => {if(extra.name == Extra.Name){this.savedExtras.splice(extra,1)}})

      this.totalPrice -= Extra.Price

      this.$store.commit('updateExtrasPrice', this.totalPrice)
      this.$store.commit('updateSelectedExtras', this.savedExtras)

      console.log(this.$store.state.extrasPrice)
      console.log(this.$store.state.selectedExtras)
    },
    roomAdded(room){
       if (this.$store.state.bookedRooms.some(bookedRoom => bookedRoom.id === room.id)){
         return false;
       }
       else{
         return true;
       }
     },
    toggleAddRemoveButton(event) {
      if(event.target.className == this.toggleClass.add){
        event.target.className = this.toggleClass.added;
      }
      else{
        event.target.className = this.toggleClass.add;
      }
    },
}
}
</script>