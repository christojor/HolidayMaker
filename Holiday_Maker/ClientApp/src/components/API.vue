<template>
        
        <h1>{{filter.PropName}}</h1>
    <div v-for="accomodation in getAccomodations" :key="accomodation" class="hotel-item">
        <img :src="accomodation.imgSrc" alt="" class="hotel-item-img">
        <div class="hotel-item-desc">
        <h1>{{accomodation.name}}</h1>
        <h1>{{accomodation.description}}</h1>
        </div>
    </div>
</template>

<script>

    let rawResponse = await fetch('https://localhost:44323/api/accomodations');
    let getAccomodations = await rawResponse.json();

export default {
  props: {
    filter: Object
  },
  data()
  {
    return{
      getAccomodations
    }
  }
}
</script>
