<template>

<div class="flex flex-wrap overflow-hidden divide-y-2 divide-gray-300 border-2 rounded-md border-black shadow-md p-4 bg-green-1">

  <div class="w-full overflow-hidden">
    <h2 class="text-xl text-green-6">Personal Details</h2>
  </div>

  <div class="w-full overflow-hidden" v-if="userDetails">
    <h1 class="mt-2"><b>Full Name</b></h1>
    <h1>{{ userDetails.firstName }} {{ userDetails.lastName }}</h1>
    <h1 class="mt-2"><b>E-mail</b></h1>
    <h1>{{ userDetails.email }}</h1>
    <h1 class="mt-2"><b>Address</b></h1>
    <h1>{{ userDetails.streetAddress }}, {{ userDetails.zipCode }}, {{ userDetails.city }}, {{ userDetails.country }}</h1>
  </div>

</div>
</template>

<script>
export default {
  props: {
        userDetails: {
            type: Object,
            required: true,
        }
    },
    
}
</script>