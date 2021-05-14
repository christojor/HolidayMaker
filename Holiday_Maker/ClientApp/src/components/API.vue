<template>
    <div v-for="accomodation in getAccomodations" :key="accomodation" class="hotel-item shadow-md">
        <img :src="accomodation.imgSrc" alt="" class="hotel-item-img">
        <div class="hotel-item-desc">
        <h1>{{accomodation.name}}</h1>
        <h1>{{accomodation.description}}</h1>
        <button @click="goToAccommodation(accomodation.id)">
            <b>Go to Details</b>
          </button>
        </div>
    </div>
        
        <h1>{{filter.PropName}}</h1>
        <h1>{{filter.PropStars}}</h1>
        <h1>{{filter.PropRating}}</h1>
        <h1>{{filter.PropMinPrice}}</h1>
        <h1>{{filter.PropMaxPrice}}</h1>
        <h1 v-for="Extra in filter.PropExtras" :key="Extra"><h1 v-if="Extra.Checked == true">{{Extra.Extra}}</h1></h1>
</template>

<script>
export default {
  props: {
    filter: Object,
    getAccomodations: Object
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
