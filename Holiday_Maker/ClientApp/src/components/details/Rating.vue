<template>
<div class="flex flex-wrap overflow-hidden">

  <div class="w-full overflow-hidden">
    <h2 class="uppercase text-lg p-1" style="font-weight: bold; font-family: ">{{ accomodation.name }}</h2>
  </div>

  <div class="flex flex-row w-full overflow-hidden">
    
    
  </div>

  <div class="w-full overflow-hidden">
      <div v-for="stars in accomodation.starRating" :key="stars" style="display:inline-block; margin-bottom:5px">
        <font-awesome-icon :icon="['fas', 'star']" size="lg" style="color: #52B788;"/>
    </div><br/>
  </div>

</div>
    
</template>

<script>
export default {
    props: {
            accomodation: {
                type: Object,
                required: true,
            },
        },
};
</script>