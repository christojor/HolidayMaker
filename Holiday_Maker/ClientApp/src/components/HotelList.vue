<template>
    <div v-if="!filteredList.length" style="width:100%">
        <h1 style="text-align:center;font-size:30px">Loading hotels...</h1>
    </div>
    
    <div v v-else v-for="accomodation in filteredList" :key="accomodation" class="hotel-item shadow-md">
        <img :src="accomodation.imgSrc" alt="" class="hotel-item-img" @click="goToAccommodation(accomodation.id)">
        
        <div class="hotel-item-desc" @click="goToAccommodation(accomodation.id)">
            <HotelDescription :accomodation="accomodation"/>
        </div>
    </div>
</template>

<script>
import FavoriteButton from '/src/components/FavoriteButton.vue'
import HotelDescription from '/src/components/HotelDescription.vue';
import { mapGetters } from 'vuex'

export default {
  components:{
    FavoriteButton,
    HotelDescription
  },
  computed:{ 
      ...mapGetters([
          'filteredList'
      ])
  }
}
</script>
