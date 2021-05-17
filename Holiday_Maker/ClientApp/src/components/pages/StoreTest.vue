<template>
  <h1>{{ text }} <button @click="changeText">Change Text</button></h1>

  <input v-model="message" />
  <p>{{ message }}</p>

  <div v-for="room in rooms" :key="room">
    <p>{{room.id}}</p>
  </div>



  <div v-for="accomodation in accomodations" :key="accomodation">
    <ul>
      <li>
        <b>{{ accomodation.id }}. {{ accomodation.name }}</b>
        <img :src="accomodation.imgSrc" style="width: 25%; height: auto" />
        <h1>
          <button @click="goToAccommodation(accomodation.id)">
            <b>Go to Details</b>
          </button>
        </h1>
        <br />
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  created() {
    // Life cycle hook - Created, Mounted, Updated, Destroyed. PS. Benjamin gör mig arg.

    // Anropar async action i store, som sedan anropar mutation getAccomodationsData som sedan uppdaterar accomodations property i state
    this.$store.dispatch("getAccomodations");
    this.$store.dispatch("getRooms");
  },

  computed: {
    // Computed properties that can also be used to get and manipulate data from store

    text() {
      let text = this.$store.state.text;

      text += " - Text added to property value from store.";

      return text;
    },
    headline() {
      return this.$store.state.headline;
    },
    accomodations() {
      return this.$store.state.accomodations;
    },
    rooms() {
      return this.$store.state.rooms;
    },

    // Computed property with two-way data binding

    message: {
      get() {
        return this.$store.state.message;
      },
      set(value) {
        this.$store.commit("updateMessage", value);
      },
    },
  },

  methods: {
    changeText() {
      // Två in-argument här, den första avser den mutationen man vill utföra i store,
      // OBS - Måste vara en sträng som har samma namn som mutationen i store.
      // Det andra argumentet är själva "the payload" - nya värdet man vill skicka med som kommer
      // att användas när mutationen updaterar data-variablen i state. Den kan vara av vilken datatyp som helst,
      // men den måste ju stämma överens med den avsedda data-variablen i state.

      this.$store.commit("changeText", "Changed"); // Commit used for calling mutations in store
    },
    getAccomodations() {
      this.$store.dispatch("getAccomodations"); // Dispatch used for calling actions in store
    },
    goToAccommodation(accommodationId) {
      this.$router.push({
        name: "Accommodation",
        params: { id: accommodationId },
      });
    },
    getRooms() {
      this.$store.dispatch("getRooms");
    },
  },
};
</script>
