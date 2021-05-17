<template>

<div>
  <div class="flex flex-wrap overflow-hidden">
   <div class="w-1/2 overflow-hidden"> 
   <div v-for="room in rooms" :key="room">
       <img :src="room.imgSrc"/>
    <b>{{rooms.price}}</b>
</div>
  </div>
    
</template>

<script>
export default {
    props: {
        rooms: {
            type: rooms,
            required: true,
        }
    }
}
</script>