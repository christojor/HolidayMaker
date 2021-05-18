<template>
    <div v-if="!filteredList.length" style="width:100%">
        <h1 style="text-align:center;font-size:30px">Loading hotels...</h1>
    </div>
    
    <div v v-else v-for="accomodation in filteredList" :key="accomodation" class="hotel-item shadow-md">
        <img :src="accomodation.imgSrc" alt="" class="hotel-item-img" @click="goToAccommodation(accomodation.id)">
        
        <div class="hotel-item-desc">
            <HotelDescription :accomodation="accomodation"/>
        </div>
    
    </div>
</template>

<script>
import HotelDescription from '/src/components/HotelDescription.vue';
import { mapGetters } from 'vuex'

export default {
  components:{
    HotelDescription
  },
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
        }
    }
}
</script>
