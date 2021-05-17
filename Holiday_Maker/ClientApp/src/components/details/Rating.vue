<template>
<div class="flex flex-wrap overflow-hidden">

  <div class="w-full overflow-hidden">
    <h2 class="uppercase text-lg p-1" style="font-weight: bold; font-family: ">{{ accomodation.name }}</h2>
  </div>

  <div class="flex flex-row w-full overflow-hidden">
    <StarIcon class="h-5 w-5 text-green-500"/>
    <StarIcon class="h-5 w-5 text-green-500"/>
  </div>

  <div class="w-full overflow-hidden">
    <p><b>1,5/5 (Sucks)</b></p>
  </div>

</div>
    
</template>

<script>

import { StarIcon } from '@heroicons/vue/solid'

export default {

    components: { 
        StarIcon,
    },

    props: {
            accomodation: {
                type: Object,
                required: true,
            },
        },
};
</script>