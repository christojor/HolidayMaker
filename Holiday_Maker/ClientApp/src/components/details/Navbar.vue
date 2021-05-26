<template>
<b-navbar>
  <div class="flex flex-wrap overflow-hidden">
  <div class="w-1/2 overflow-hidden">
<ul class="flex">
  <!-- <div class="text-green-500 hover:text-green-800 hover:underline"> -->
  <li class="mr-6">
    <div ref="overview">
    <a style=cursor:pointer class="overview-button text-green-500 hover:text-green-800 hover:underline" @click="scrollPageTo('overview')">Overview</a>
    </div>
  </li>
  <li class="mr-6">
    <div ref="amenities">
      <a style=cursor:pointer class="amenities-button text-green-500 hover:text-green-800 hover:underline" @click="scrollPageTo('amenities')">Amenities</a>
  </div>
  </li>
  <li class="mr-6">
<div ref="extras">
    <a style=cursor:pointer class="rooms-button text-green-500 hover:text-green-800 hover:underline" @click="scrollPageTo('extras')">Extras</a>
    </div>  
    </li>
  <li class="mr-6">
    <div ref="rooms">
    <a style=cursor:pointer class="rooms-button text-green-500 hover:text-green-800 hover:underline" @click="scrollPageTo('rooms')">Available Rooms</a>
    </div>
  </li>
  <!-- </div> -->
</ul>
</div>
<div class="w-1/2 overflow-hidden">
<button class="float-right bg-green-500 hover:bg-green-700 text-white font-bold py-2 px-4 rounded-full" @click="scrollPageTo('rooms')">
      Show Rooms
  </button>
  </div>
  </div>
</b-navbar>
</template>

<script>

export default {
  data(){
    return {
       refName:'room',
       refName: 'amenities',
       refName: 'extras',
       refName: 'overview'
    }
  },
  methods: {
  scrollPageTo(refName) {
    
    var element = this.$refs[refName];
    var top = element.offsetTop;

    window.scrollTo(0, top);
  }
 }
}
</script>