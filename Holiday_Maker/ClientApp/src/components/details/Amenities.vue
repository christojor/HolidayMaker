<template>
  <div v-for="amenity in amenities" :key="amenity">
    <h2><b>AMENITIES</b></h2>
    <div class="space-x-4 space-y-4">
      <div
        class="inline-block box-border h-10 p-1 border-2 border-green-500 rounded-md"
        v-if="amenity.entertainment == true"
      >
        <font-awesome-icon icon="music" /> Entertainment
      </div>
      <div
        class="inline-block box-border h-10 p-1 border-2 border-green-500 rounded-md"
        v-if="amenity.kidClub == true"
      >
        <font-awesome-icon icon="baby" /> Kid Club
      </div>
      <div
        class="inline-block box-border h-10 p-1 border-2 border-green-500 rounded-md"
        v-if="amenity.gym == true"
      >
        <font-awesome-icon icon="dumbbell" />Gym
      </div>
      <div
        class="inline-block box-border h-10 p-1 border-2 border-green-500 rounded-md"
        v-if="amenity.pool == true"
      >
        <font-awesome-icon icon="swimming-pool" />Pool
      </div>
      <div
        class="inline-block box-border h-10 p-1 border-2 border-green-500 rounded-md"
        v-if="amenity.wiFi == true"
      >
        <font-awesome-icon icon="wifi" />WiFi
      </div>

      <div
        class="inline-block box-border h-10 p-1 border-2 border-green-500 rounded-md"
        v-if="amenity.resturant == true"
      >
        <font-awesome-icon icon="utensils" />Resturant
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    amenities: {
      type: Object,
      required: true,
    },
  },
};
</script>