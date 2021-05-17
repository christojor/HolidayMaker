import { createStore } from "vuex" 

const store = createStore({

    // Properties
   state:{

        text: "Unchanged",
        headline: "Welcome to our awesome website!",
        information: "This is just some random text.",
        message: 'Hello Vuex',
        accomodations: [],
        rooms: [],
        userId: null,
        accomodationId: null,
        groupName: null

   },

   // Methods for changing states synchronously
   mutations:{

       setName(state, x){

           state.name = x

       },

       changeText(state, value){

           state.text = value

       },

       getAccomodationsData(state, payload) {

        state.accomodations = payload;
  
      },
      updateMessage(state, message) {
        state.message = message
      },
      getRoomsData(state, payload) {
        state.rooms = payload
      },
   },

   // Functions that call mutations asynchronously. Called by using dispatch (instead of state) in component.
   actions:{

    // In-argumentet commit här nedan ska omslutas av måsvingar. Detta kallas för destructuring. 
    // Länk finns längre ner på sidan. Via commit kan du komma åt alla dina mutationer ovan.
    // Syntaxen är viktig. commit följt av paranteser där det första in-argumentet är en sträng med önskad 
    // mutationnamn och "the payload" som andra argument.
    async getRooms({ commit }) {
    let response = await fetch('https://localhost:44323/api/accomodations/rooms');
    let json = await response.json();
 
    commit('getRoomsData', json);
 },

        async getAccomodations({ commit }) {

            let response = await fetch('https://localhost:44323/api/accomodations');
      
            let json = await response.json();
      
            commit('getAccomodationsData', json);

   },
},

})

export default store