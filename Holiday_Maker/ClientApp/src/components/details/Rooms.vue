<template>
<div v-if="roomAvailable">
<b>AVAILABLE ROOMS</b>
<div v-for="room in rooms" :key="room.id">
<div class="flex flex-wrap overflow-hidden border-black border-2 p-1 m-1">

  <div class="w-1/2 overflow-hidden p-2">
    <img class="rounded-md roomImg" :src="room.imgSrc">
   </div>

      <div class="w-1/2 overflow-hidden p-4">
        <button
          class="float-right bg-green-500 hover:bg-green-700 text-white font-bold py-2 px-4 rounded-full"
          @click="addToBooking(room)"
        >
          Add Room
        </button>
        <div>
          <b>Room Type:</b> {{ room.roomType.name }}<br />
          <b>Number of Guests: </b> {{ room.nbrOfGuests }}<br />
          <b>Number of Extra Beds:</b> {{ room.nbrOfExtraBeds }}<br />
          <b>Price:</b> {{ room.price }}€ <br />
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
      this.$store.state.bookedRooms.push(room);
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
    }
  }
};
</script>