<template>
<b>AVAILABLE ROOMS</b>
<div v-for="room in rooms" :key="room">
<div class="flex flex-wrap overflow-hidden border-black border-2 p-1 m-1">

  <div class="w-1/2 overflow-hidden p-2">
    <img class="rounded-md roomImg" :src="room.imgSrc">
   </div>

   <div class="w-1/2 overflow-hidden p-4">     
     <button class="float-right bg-green-500 hover:bg-green-700 text-white font-bold py-2 px-4 rounded-full" @click="addToBooking(room)">
      Book Room
     </button> 
     <div>
     <b>Room Type:</b> {{ room.roomType.name }}<br>
     <b>Number of Guests: </b> {{ room.nbrOfGuests }}<br>
     <b>Number of Extra Beds:</b> {{ room.nbrOfExtraBeds }}<br>
     <b>Price:</b> {{ room.price }}€ <br>
     <div v-if="room.isRefundable==true">
       <b>Refund:</b> Yes<br>
       </div>
     <div v-if="room.isRefundable==false">
     <b>Refund:</b> No<br>
     </div>
     <b>Description:</b> {{room.description}}<br>
    </div>
    </div>
</div>
</div>
    
</template>

<script>

export default {
    props: {
        rooms: {
            type: Object,
            required: true,
        }
    },
      methods: {
        addToBooking(room) {
          console.log(room)
          this.$store.state.bookedRooms.push(room)
          console.log(this.$store.state.bookedRooms)
        }
}
    
}
</script>