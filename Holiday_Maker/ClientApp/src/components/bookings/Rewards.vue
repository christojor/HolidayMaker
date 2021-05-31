<template>
  <div class="flex flex-wrap overflow-hidden divide-y-2 divide-gray-300 border-2 rounded-md border-black shadow-md p-4 bg-green-1">

    <div class="w-full overflow-hidden">
      <h2 class="text-xl text-green-6">Rewards & Points</h2>
    </div>

    <div v-if="this.$store.state.isLoggedIn" class="w-full overflow-hidden">
      <h1>Every 1€ spent is converted to 1 point</h1>
      <h1 style="font-size:10px">(tax not included)</h1>
      <h1>Reward Points earned: {{totalPoints}}</h1>
    </div>

    <div v-if="this.$store.state.isLoggedIn" class="w-full overflow-hidden">
      <h1>Log in to get Reward Points</h1>
    </div>
  </div>
</template>

<script>
export default {

  props: {
    roomPrices: {
      type: Object,
      required: true,
      }
    },
  
  computed:{
    totalPoints(){
        return this.roomPrices.reduce((sum, room) => {
            return sum += room.price * this.nbrOfNights;
        }, 0);
    },
    nbrOfNights(){
      return this.$store.state.nbrOfNights
    }
  }  
}

</script>