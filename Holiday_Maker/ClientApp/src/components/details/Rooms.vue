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
    <button class="float-right bg-green-500 hover:bg-green-700 text-white font-bold py-2 px-4 rounded-full">
      Book Room
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
    }
    
}
</script>