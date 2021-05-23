<template>
        <div class="flex flex-wrap overflow-hidden divide-y-2 divide-gray-300 border-2 rounded-md border-black shadow-md p-4 bg-green-1">

  <div class="w-full overflow-hidden">
    <h2 class="text-xl text-green-6">Room Details</h2>
  </div>

  <div class="w-full overflow-hidden">
    <h1>Room 1</h1>
    <h1>Shared</h1>
    <h1>Multiple Beds</h1> 
    <h1>(2 Adults + 1 Child)</h1>
    <h1>Breakfast included  Free WiFi</h1>
    <h1>Check-in: Sun, 6 Jun</h1>
    <h1>Check-out: Mon, 7 Jun</h1>
    <h1>1-night stay</h1>
  </div>

</div>
</template>

<script>
export default {
    prop:{
        accomodation:{
            type: Object,
            required: true,
             }
        },
}
</script>