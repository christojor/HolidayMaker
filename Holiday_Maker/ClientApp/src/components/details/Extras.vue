
<template>
  <div v-for="extra in extras" :key="extra">
  
    <h2><b>EXTRAS</b></h2>

    <div class="space-x-4 space-y-4">
      <div
        class="inline-block box-border h-10 p-1 border-2 border-green-500 rounded-md"
        v-if="extra.selfCatering == true"
      >
        <font-awesome-icon icon="minus-square" />
        Self Catering
      </div>
      <div
        class="inline-block box-border h-10 p-1 border-2 border-green-500 rounded-md"
        v-if="extra.halfBoard == true"
      >
        <font-awesome-icon icon="square" />
        Half Board
      </div>
      <div
        class="inline-block box-border h-10 p-1 border-2 border-green-500 rounded-md"
        v-if="extra.fullBoard == true"
      >
        <font-awesome-icon icon="plus-square" />
        Full Board
      </div>
      <div
        class="inline-block box-border h-10 p-1 border-2 border-green-500 rounded-md"
        v-if="extra.allInclusive == true"
      >
        <font-awesome-icon icon="hamburger" />
        All Inclusive
      </div>
      <div
        class="inline-block box-border h-10 p-1 border-2 border-green-500 rounded-md"
        v-if="extra.breakfast == true"
      >
        <font-awesome-icon icon="coffee" />
        Breakfast
      </div>
      <div
        class="inline-block box-border h-10 p-1 border-2 border-green-500 rounded-md"
        v-if="extra.extraBed == true"
      >
        <font-awesome-icon icon="bed" />
        Extra Bed
      </div>
      <div
        class="inline-block box-border h-10 p-1 border-2 border-green-500 rounded-md"
        v-if="extra.crib == true"
      >
        <font-awesome-icon icon="baby" />
        Crib
    </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    extras: {
      type: Object,
      required: true,
    },
  },
};
</script>