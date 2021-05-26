<template>
  <div class="flex flex-wrap overflow-hidden">
    <div class="w-full overflow-hidden">
      <h2
        class="uppercase text-lg p-1"
        style="font-weight: bold; font-family: "
      >
        {{ accomodation.name }}
      </h2>
    </div>

    <div class="flex flex-row w-full overflow-hidden"></div>

    <div class="w-full overflow-hidden">
      <div
        v-for="stars in accomodation.starRating"
        :key="stars"
        style="display: inline-block; margin-bottom: 5px"
      >
        <font-awesome-icon
          :icon="['fas', 'star']"
          size="lg"
          style="color: #52b788"
        />
      </div>
      <div v-if="accomodation.guestRating <= 2">
        <h2 style="font-size: 16px">
          <font-awesome-icon
            :icon="['fas', 'poop']"
            size="lg"
            style="color: #52b788"
          />
          {{ accomodation.guestRating }}
        </h2>
      </div>
      <div v-if="accomodation.guestRating > 2 && accomodation.guestRating <= 5">
        <h2 style="font-size: 16px">
          <font-awesome-icon
            :icon="['fas', 'poo']"
            size="lg"
            style="color: #52b788"
          />
          {{ accomodation.guestRating }}
        </h2>
      </div>
      <div v-if="accomodation.guestRating > 5 && accomodation.guestRating <= 8">
        <h2 style="font-size: 16px">
          <font-awesome-icon
            :icon="['fas', 'smile']"
            size="lg"
            style="color: #52b788"
          />
          {{ accomodation.guestRating }}
        </h2>
      </div>
      <div v-if="accomodation.guestRating > 8">
        <h2 style="font-size: 16px">
          <font-awesome-icon
            :icon="['fas', 'grin-hearts']"
            size="lg"
            style="color: #52b788"
          />
          {{ accomodation.guestRating }}
        </h2>
      </div>
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