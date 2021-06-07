<template>
  <select v-model="rate" @change="setRating()">
    <option value="1">1</option>
    <option value="2">2</option>
    <option value="3">3</option>
    <option value="4">4</option>
    <option value="5">5</option>
    <option value="6">6</option>
    <option value="7">7</option>
    <option value="8">8</option>
    <option value="9">9</option>
    <option value="10">10</option>
  </select>
</template>

<script>
export default {
  data() {
    return {
      rate: null,
    };
  },
  props: {
    id: null,
  },
  methods: {
    async setRating() {
      var ratingObject = {
        accomodationId: this.id,
        userId: this.$store.state.userId,
        rating: this.rate,
      };
      console.log(JSON.stringify(ratingObject));
      await fetch("https://localhost:44323/api/Accomodations/UpdateRating", {
        method: "post",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(ratingObject),
      });
    },
  },
};
</script>
