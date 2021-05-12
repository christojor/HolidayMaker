import { createStore } from "vuex" 

// const state = {

//     text: "Unchanged"

// }


// const mutations = {

//   // state här nedan (in-argument) är hela state-objektet ovan fast samlat i en variabeln som mutationen använder 
//   // för att updatera de olika data-variablerna i state-objektet.
//   // In-argumentet value är helt enkelt det nya värdet man vill uppdatera data-variablen i state-objektet med.
//   // Detta värdet skickar men med ifrån komponenten.

//     changeText(state, value){

//       state.text = value;

//     }

// }

//  export default createStore({state, mutations})

///////////////////////////////////////////////////////////////////////////////////////

const store = createStore({

    // Properties
   state:{

        text: "Unchanged",
        headline: "Welcome to our awesome website!",
        information: "This is just some random text.",
        accomodations: []
   },

   // Methods for changing states synchronously
   mutations:{

       setName(state, x){

           state.name = x

       },

       changeText(state, value){

           state.text = value;

       },

       getAccomodationsData(state, payload) {

        state.accomodations = payload;
  
      },

   },

   // Functions that call mutations asynchronously. Called by using dispatch (instead of state) in component.
   actions:{

    // In-argumentet commit här nedan ska omslutas av måsvingar. Detta kallas för destructuring. 
    // Länk finns längre ner på sidan. Via commit kan du komma åt alla dina mutationer ovan.
    // Syntaxen är viktig. commit följt av paranteser där det första in-argumentet är en sträng med önskad 
    // mutationnamn och "the payload" som andra argument.

        async getAccomodations({ commit }) {

            let response = await fetch('https://localhost:44323/api/accomodations');
      
            let json = await response.json();
      
            commit('getAccomodationsData', json);

   }
}

})

export default store