<template>
<!-- <div v-for="room in rooms" :key="room">
</div>
<div>

<div class="flex flex-wrap overflow-hidden">
   
   <div class="grid gap-12">

    <div class="w-1/2 overflow-hidden xl:my-5 xl:px-5">
    
    <div>
     <table class="table-auto">
                <thead>
                  <tr>
                    <th align="left" class="w-1/2 overflow-hidden xl:my-5 xl:px-5">ROOMS</th>
                    <th align="right">DETAILS</th>
                   
                  </tr>
                </thead>
                <tbody>
                  <tr>
                    <td>Room ID {{room.id}}</td>
                    <td><img :src="room.imgSrc"></td>
                  </tr>
                  <tr>
                    <td>Price</td>
                    <td>{{room.price}}</td>
                  </tr>
                </tbody>
              </table> -->
<h2><b>ROOMS</b></h2>
<div v-for="room in rooms" :key="room">
<div class="flex-wrap overflow-hidden xl:-mx-5 xl:px-5 xl:w-1/2">
   <img :src="room.imgSrc">
  <div text-align:right class="flex-wrap overflow-hidden xl:my-5 xl:px-5 xl:w-1/2">
    <!-- Column Content -->
    <h6><b>DETAILS</b></h6>
    <p>Price is {{room.price}}</p>
    <p>Type of the room {{roomType.Name}}</p>
  </div>
 <div class="w-full overflow-hidden xl:my-5 xl:px-5 xl:w-1/2">
    <!-- Column Content -->
  </div>

  <div class="w-full overflow-hidden xl:my-5 xl:px-5 xl:w-1/2">
    <!-- Column Content -->
  </div>

  <div class="w-full overflow-hidden xl:my-5 xl:px-5 xl:w-1/2">
    <!-- Column Content -->
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
        },
        roomType: {
            type: Object,
            required: true,
        }
    }
}
</script>