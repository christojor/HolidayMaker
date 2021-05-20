<template>
<div style="width:100%" class="bg-green-1 border border-red-500 text-red-700 px-4 py-3 rounded relative" role="alert">
  <strong class="font-bold">No results found. </strong>
  <span class="block sm:inline"><router-link to="/"  class="hover:text-red-800 hover:underline" style="margin-right:20px">Try again?</router-link></span>
    </div>
</template>

<script>
export default {
  created(){
    // this.$store.commit("setDestination", null);
  },
}
</script>