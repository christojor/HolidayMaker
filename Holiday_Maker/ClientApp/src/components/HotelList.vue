<template>
    <div v-if="!filteredList.length || apiState.loaded" style="width:100%">
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
import { mapState } from 'vuex'
import enums from "../assets/enums.js";

export default {
  components:{
    HotelDescription
  },
  computed:{ 
      ...mapGetters([
          'filteredList'
      ]),
    ...mapState({
      apiState: state => state.apiState
    }),
    apiStateLoaded() {
      return this.apiState === enums.loaded;
    },
    apiStateLoading() {
        console.log(this.apiState)
      return this.apiState === enums.loaded || this.apiState === enums.init;
    },
    apiStateError() {
      return this.apiState === enums.error;
    },
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
