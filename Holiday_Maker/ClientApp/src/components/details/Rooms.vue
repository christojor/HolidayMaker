<template>
<b>AVAILABLE ROOMS</b>
<div v-for="room in rooms" :key="room">
<div class="flex flex-wrap overflow-hidden border-black border-2 p-1 m-1">

  <div class="w-1/2 overflow-hidden p-2">
    <img class="rounded-md" :src="room.imgSrc">
</div>

  <div class="w-1/2 overflow-hidden p-4">
  <b>{{ room.roomType.name }}</b><br>
    <b>Price:</b> {{ room.price }}€
    <button class="float-right bg-green-500 hover:bg-green-700 text-white font-bold py-2 px-4 rounded-full" @click="addToBooking(room)">
      Add Room
  </button>
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
        // goToBooking(roomId) {
        //   console.log(roomId)
        //     this.$router.push({
        //         name: "Booking",
        //         params: { id: roomId },
        //     });
        // },
        addToBooking(room) {
          console.log(room)
          this.$store.state.bookedRooms.push(room)
          console.log(this.$store.state.bookedRooms)
        }
}
    
}
</script>