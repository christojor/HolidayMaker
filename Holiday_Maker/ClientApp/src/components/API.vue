<template>
    <div v-if="!filteredList.length" style="width:100%">
      <h1 style="text-align:center;font-size:30px">Loading hotels...</h1>
    </div>
    
    <div v v-else v-for="accomodation in filteredList" :key="accomodation" class="hotel-item shadow-md">
        <img :src="accomodation.imgSrc" alt="" class="hotel-item-img">
        <div class="hotel-item-desc">
        <h1>{{accomodation.name}}</h1>
        <h1>{{accomodation.description}}</h1>
        <button @click="goToAccommodation(accomodation.id)">
            <b>Go to Details</b>
          </button>
        </div>
    </div>
</template>

<script>
import { mapGetters } from 'vuex'

export default {
  computed:{ 
      ...mapGetters([
          'filteredList'
      ])
  },
  methods: {
    goToAccommodation(accommodationId) {
      this.$router.push({
        name: "Accommodation",
        params: { id: accommodationId },
      });
    },
  }
}
</script>
