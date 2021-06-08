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
  mounted(){
    this.getUserRatings()
  },
  data() {
    return {
      rate: null,
      ratings: []
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
    async getUserRatings(){
      let response = await fetch('https://localhost:44323/api/Accomodations/GetRating?userId=' + this.$store.state.userId);
      this.ratings = await response.json();

      this.ratings.forEach(r => {if(r.accomodationId == this.id){this.rate = r.rating}})
    }
  },
};
</script>
