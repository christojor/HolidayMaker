<template>

<div class="col-md-12" v-for="accomodation in accomodations" :key="accomodation">
     <div v-if="id == accomodation.id">


<div class="flex flex-wrap overflow-hidden">

  <div class="w-full overflow-hidden xl:w-full">
    <b>{{ accomodation.name }}</b>
  </div>

  <div class="w-full overflow-hidden xl:w-full">
    <img :src="accomodation.imgSrc" class="img-fluid">
  </div>

  <div class="w-full overflow-hidden xl:w-full">
    {{ accomodation.description }}
  </div>

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