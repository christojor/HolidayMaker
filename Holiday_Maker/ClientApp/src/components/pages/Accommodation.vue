<template>
  <div v-for="accomodation in accomodations" :key="accomodation">
    <div v-if="id == accomodation.id">
      <div class="flex flex-wrap overflow-hidden mt-3">

        <div class="w-1/6 overflow-hidden">
          <!-- Column Content -->
        </div>

        <div class="w-4/6 overflow-hidden shadow-md rounded-md divide-y-2 divide-black bg-green-1">

        <div class="w-full overflow-hidden xl:my-1 xl:px-1 xl:w-full">
            <router-link to="/hotels">Back to list</router-link>
          </div>

          <div class="w-full overflow-hidden xl:my-1 xl:px-1 xl:w-full p-2">
            <Gallery :accomodation="accomodation" />
          </div>
          
          <div class="w-full overflow-hidden xl:my-1 xl:px-1 xl:w-full p-2">
            <Navbar/>
          </div>

          <div class="w-full overflow-hidden xl:my-1 xl:px-1 xl:w-full p-2">
            <Rating :accomodation="accomodation" />
          </div>

          <div class="w-full overflow-hidden xl:my-1 xl:px-1 xl:w-full p-2">
            <Description :accomodation="accomodation" />
          </div>

          <div class="flex flex-wrap overflow-hidden xl:my-1 xl:px-1 xl:w-full divide-x divide-black">

            <div class="w-1/2 overflow-hidden p-2">

            <Amenities :amenities="accomodation.amenities" />
             
            </div>
            
            <div class="w-1/2 overflow-hidden p-2">
            
            <Extras :extras="accomodation.extras" />

            </div>
        </div>
        <div class="w-full overflow-hidden xl:my-1 xl:px-1 xl:w-full p-2">
            <Rooms :rooms="accomodation.rooms" />
          </div>
        </div>

        <div class="w-1/6 overflow-hidden">
          <!-- Column Content -->
        </div>

      </div>
    </div>
  </div>
</template>


<script>

import Amenities from "/src/components/details/Amenities.vue"
import Extras from "/src/components/details/Extras.vue"
import Description from "/src/components/details/Description.vue"
import Gallery from "/src/components/details/Gallery.vue"
import Navbar from "/src/components/details/Navbar.vue"
import Rating from "/src/components/details/Rating.vue"
import Rooms from "/src/components/details/Rooms.vue"

export default {
    props: ["id"],

    computed: {
    accomodations() {
      return this.$store.state.accomodations;
    },
  },

components: { 
Extras,
Amenities,
Description,
Gallery,
Navbar,
Rating,
Rooms,
  },
};
</script>