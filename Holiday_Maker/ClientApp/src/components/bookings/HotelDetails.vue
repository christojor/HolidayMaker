<template>
    <div class="flex flex-wrap overflow-hidden divide-y-2 divide-gray-300 border-2 rounded-md border-black shadow-md p-4 bg-green-1">

  <div class="w-full overflow-hidden">
    <h2 class="text-xl text-green-6">{{ accomodation.name }}</h2>
  </div>

  <div class="w-full overflow-hidden">
    <img :src="accomodation.imgSrc" class="img-fluid rounded-md mt-2" style="width: 300px; height: auto" />
    <h1>{{ accomodation.starRating }}/5 stars.</h1>
    <h1>Guests rated this property {{ accomodation.guestRating }}/5.</h1>
  </div>

</div>
</template>

<script>
export default {
    props: {
        accomodation: {
            type: Object,
            required: true,
        }
    },
    
}
</script>