<template>
<div v-for="amenity in amenities" :key="amenity">
<h2><b>AMENITIES</b></h2>
     <div class="space-x-4 space-y-4">
       <div class="inline-block">
            <div class="inline-block box-border h-10 p-1 border-2 border-green-500 rounded-md" v-if="amenity.entertainment"><font-awesome-icon icon="music"/> Entertainment: Yes</div>
            <div class="inline-block box-border h-10 p-1 border-2 border-green-500 rounded-md" v-else><font-awesome-icon icon="music"/> Entertainment: No</div>
        </div>
        <div class="inline-block">
            <div class="inline-block box-border h-10 p-1 border-2 border-green-500 rounded-md" v-if="amenity.kidClub"><font-awesome-icon icon="baby"/> Kid Club: Yes</div>
            <div class="inline-block box-border h-10 p-1 border-2 border-green-500 rounded-md" v-else><font-awesome-icon icon="baby"/> Kid Club: No</div>
        </div>
        <div class="inline-block">
            <div class="inline-block box-border h-10 p-1 border-2 border-green-500 rounded-md" v-if="amenity.gym"><font-awesome-icon icon="dumbbell"/> Gym: Yes</div>
            <div class="inline-block box-border h-10 p-1 border-2 border-green-500 rounded-md" v-else><font-awesome-icon icon="dumbbell"/> Gym: No</div>
        </div>
        <div class="inline-block">
            <div class="inline-block box-border h-10 p-1 border-2 border-green-500 rounded-md" v-if="amenity.pool"><font-awesome-icon icon="swimming-pool"/> Pool: Yes</div>
            <div class="inline-block box-border h-10 p-1 border-2 border-green-500 rounded-md" v-else><font-awesome-icon icon="swimming-pool"/> Pool: No</div>
        </div>
        <div class="inline-block">
            <div class="inline-block box-border h-10 p-1 border-2 border-green-500 rounded-md" v-if="amenity.wiFi"><font-awesome-icon icon="wifi"/> WiFi: Yes</div>
            <div class="inline-block box-border h-10 p-1 border-2 border-green-500 rounded-md" v-else><font-awesome-icon icon="wifi"/> WiFi: No</div>  
        </div>
        <div class="inline-block"> 
          <div class="inline-block box-border h-10 p-1 border-2 border-green-500 rounded-md" v-if="amenity.resturant"><font-awesome-icon icon="utensils"/> Resturant: Yes</div>
          <div class="inline-block box-border h-10 p-1 border-2 border-green-500 rounded-md" v-else><font-awesome-icon icon="utensils"/> Restaurant: No</div> 
      </div>
    </div>
</div>
</template>

<script>
export default {
  props: {
    amenities: {
      type: Object,
      required: true,
    },
  },
};
</script>