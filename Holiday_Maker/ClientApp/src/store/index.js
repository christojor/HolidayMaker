import { createStore } from "vuex" 
import { getByName, getByStars, getByRating , getByMaxPrice, getByMinPrice, getByAmenities, getByExtras, getByRooms} from "../assets/filterMethods.js"

const store = createStore({

    // Properties
   state:{

        text: "Unchanged",
        headline: "Welcome to our awesome website!",
        information: "This is just some random text.",
        message: 'Hello Vuex',
        accomodations: [],
        filter: [],
        userId: null,
        isLoggedIn: false,
        userName: null,
        userPassword: null,
        loginAttemptMessage: null
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
            state.filteredAccomodations = payload;
        },
        updateMessage (state, message) {
            state.message = message
        },
        updateFilter (state, filter) {
            state.filter = filter
        },
        setUserId(state, id){
            state.userId = id;
        },
        setLoggedInState(state, bool){
            state.isLoggedIn = bool;
        },
        setLoginAttemptMessage(state, message){
            state.loginAttemptMessage = message;
        },
        setUsername(state, usrName){
            state.userName = usrName;
        },
        setUserPassword(state, usrPassword){
            state.userPassword = usrPassword;
        },
        },
        updateAccomodations (state, payload) {
            console.log(payload)
            state.accomodations = payload
        },
   },
   getters: {
        filteredList(state){
            return getByRooms(getByExtras(getByAmenities(getByName(getByRating(getByStars(getByMaxPrice(getByMinPrice(state.accomodations, state.filter), state.filter), state.filter), state.filter), state.filter), state.filter), state.filter), state.filter)
        }
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
        },
        async getLoginAttempt({commit}){
            let response = await fetch('https://localhost:44323/api/User/login?username='+ this.state.userName + '&password=' + this.state.userPassword,{
                method:'post'
            })
            let json = await response.json();
            commit('setUserId', json.userId);
            commit('setLoggedInState', json.isLoggedIn)
            commit('setLoginAttemptMessage', json.loggedInMessage)
        }
    }
})

export default store