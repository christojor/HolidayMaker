<template>
<div class="flex flex-wrap overflow-hidden">

  <div class="w-full overflow-hidden">
    <h2 class="uppercase text-lg p-1" style="font-weight: bold; font-family: ">{{ accomodation.name }}</h2>
  </div>

  <div class="flex flex-row w-full overflow-hidden">
    <font-awesome-icon :icon="['fas', 'star']" size="lg" style="color: #52B788;"/>
    <font-awesome-icon :icon="['fas', 'star']" size="lg" style="color: #52B788;"/>
  </div>

  <div class="w-full overflow-hidden">
    <p><b>1,5/5 (Sucks)</b></p>
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