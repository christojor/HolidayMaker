<template>
    <div v-for="accomodation in getAccomodations" :key="accomodation">
        <h1>{{accomodation.name}}</h1>
        <h1>{{accomodation.description}}</h1>
        <img :src="accomodation.imgSrc" alt="">
    </div>
</template>

<script>

    let rawResponse = await fetch('https://localhost:44323/api/accomodations');
    let getAccomodations = await rawResponse.json();

export default {
  
  data()
  {
    return{
      getAccomodations
    }
  }
}
</script>
