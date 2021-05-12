<template>

    <h1>{{ text }} <button @click="changeText">Change Text</Button></h1>

      <div v-for="accomodation in accomodations" :key="accomodation">
      <ul>
        <li>
          <b>{{ accomodation.id }}. {{ accomodation.name }}</b>
          <img :src="accomodation.imgSrc" style="width: 25%; height: auto;">
          <br>
        </li>
      </ul>
    </div>

</template>


<script>

export default {

  created(){ // Life cycle hook - Created, Mounted, Updated, Destroyed

  // Anropar async action i store, som sedan anropar mutation getAccomodationsData som sedan uppdaterar accomodations property i state
      this.$store.dispatch('getAccomodations');

    },

  computed: {

    text(){

    // En simpel kodrad för att komma åt en data-variabel i state.
    // OBS - Glöm inte $-tecknet, och att en computed ALLTID måste returnera ett värde!

      return this.$store.state.text;

    },
    headline(){

      return this.$store.state.headline;

    },
    accomodations(){

        return this.$store.state.accomodations;

      }
  },


  methods:{

    changeText(){

    // Två in-argument här, den första avser den mutationen man vill utföra i store,
    // OBS - Måste vara en sträng som har samma namn som mutationen i store. 
    // Det andra argumentet är själva "the payload" - nya värdet man vill skicka med som kommer
    // att användas när mutationen updaterar data-variablen i state. Den kan vara av vilken datatyp som helst, 
    // men den måste ju stämma överens med den avsedda data-variablen i state.

      this.$store.commit('changeText', 'Changed');

    },
    getAccomodations(){

      this.$store.dispatch('getAccomodations');

    }

  }

 }

 </script>