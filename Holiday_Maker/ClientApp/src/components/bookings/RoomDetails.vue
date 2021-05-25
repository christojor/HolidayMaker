<template>
        <div class="flex flex-wrap overflow-hidden divide-y-2 divide-gray-300 border-2 rounded-md border-black shadow-md p-4 bg-green-1">

  <div class="w-full overflow-hidden">
    <h2 class="text-xl text-green-6">Room Details</h2>
  </div>

  <div class="w-full overflow-hidden border-2 rounded-md border-black" v-for="(room, index) in roomDetails.roomInfo" :key="room">
    <h1><b>Room {{ index + 1 }}</b></h1>
    <h1>{{ room.roomType.name }}</h1>
    <h1>{{ room.nbrOfGuests }} bed(s).</h1> 
    <h1>(Travellers + Children) 2 Adults + 1 Child</h1>
    <h1>(checkInDate) Check-in: Sun, 6 Jun</h1>
    <h1>(checkOutDate) Check-out: Mon, 7 Jun</h1>
    <h1>(calcNights) 1-night stay</h1>
  </div>

</div>
</template>

<script>
export default {
    props: {
        roomDetails: {
            type: Object,
            required: true,
        }
    },
    methods:
    {
    incrementIndex: function (index) {
      return index + 1
    }
    }
}
</script>