<template>
  <div class="flex flex-wrap overflow-hidden divide-y-2 divide-gray-300 border-2 rounded-md border-black shadow-md p-4 bg-green-1">

    <div class="w-full overflow-hidden">
      <h2 class="text-xl text-green-6">Rewards & Points</h2>
    </div>

    <div v-if="this.$store.state.isLoggedIn" class="w-full overflow-hidden">
      <h1 class="mt-2"><b>Every 1€ spent is converted to 1 point</b></h1>
      <h1 style="font-size:10px">(tax not included)</h1>
      <h1 style="font-size:10px">(Premium Members recieve extra 25%)</h1>

      <h1 v-if="this.$store.state.user.memberTypeId == 1" class="mt-2"><b>Reward Points earned: </b></h1>
      <h1 v-if="this.$store.state.user.memberTypeId == 1" class="mt-2">{{totalPoints}}</h1>

      <h1 v-if="this.$store.state.user.memberTypeId == 2" class="mt-2"><b>Reward Points earned: </b></h1>
      <h1 v-if="this.$store.state.user.memberTypeId == 2">{{totalPoints}} + {{totalPoints * 0.25}}</h1>
      <h1 v-if="this.$store.state.user.memberTypeId == 2" style="font-size:12px">Thank you for being a Premium Member</h1>

      <h1 class="mt-2"><b>Currrent Points: </b></h1>
      <h1>{{this.$store.state.user.memberPoints}}</h1>
    </div>

    <div v-else class="w-full overflow-hidden">
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