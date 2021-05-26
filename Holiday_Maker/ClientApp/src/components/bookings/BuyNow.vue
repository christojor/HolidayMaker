<template>
  <div class="flex flex-wrap overflow-hidden divide-y-2 divide-gray-300 border-2 rounded-md border-black shadow-md p-4 bg-green-1">

  <div class="w-full overflow-hidden">
    <button class="bg-green-500 w-1/2 hover:bg-green-700 text-white font-bold py-2 px-4 p-4 mt-3 rounded-full" @click="sendBooking()">
      Buy Now
  </button>
  </div>

</div>
</template>

<script>
export default {
  props: {
        makeBooking: {
            type: Object,
            required: true,
        }
    },

    methods:{
      sendBooking() {
      this.$store.commit("setBooking", this.makeBooking);
    },
    }
    
}
</script>