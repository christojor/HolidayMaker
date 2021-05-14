<template>

<div v-for="accomodation in accomodations" :key="accomodation">
     <div v-if="id == accomodation.id">


<div class="flex flex-wrap overflow-hidden xl:-mx-1 shadow-md rounded-sm" style="width: 600px">

  <div class="w-full overflow-hidden xl:my-1 xl:px-1 xl:w-full">
    <b>{{ accomodation.name }}</b>
  </div>

  <div class="w-full overflow-hidden xl:my-1 xl:px-1 xl:w-full">
    <img :src="accomodation.imgSrc" class="img-fluid">
  </div>

  <div class="w-full overflow-hidden xl:my-1 xl:px-1 xl:w-full">
    <h1><b>Description</b></h1>
    {{ accomodation.description }}
  </div>

  <!-- <div class="w-full overflow-hidden xl:my-1 xl:px-1 xl:w-full" v-for="amenity in accomodation.amenities" :key="amenity">
    Entertainment: {{ amenity.entertainment }} <br>
    Kid Club: {{ amenity.entertainment }} <br>
    Gym: {{ amenity.gym }} <br>
    Pool: {{ amenity.pool }} <br>
    WiFi: {{ amenity.wifi }} <br>
    Resturant: {{ amenity.resturant }} <br>
  </div> -->

</div>
     </div>
    </div>

</template>

<script>
export default {
  props: ["id"],

  computed: {
    accomodations() {
      return this.$store.state.accomodations;
    },
  },
};
</script>