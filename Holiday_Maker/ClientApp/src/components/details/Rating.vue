<template>

<h2 class="uppercase text-lg p-1" style="font-weight: bold; font-family: ">
              {{ accomodation.name }}
              <StarIcon class="h-5 w-5 text-blue-500"/>
              
            </h2>
    
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