import { createStore } from "vuex" 
import { getByName, getByStars, getByRating , getByMaxPrice, getByMinPrice, getByAmenities, getByExtras, getByRooms, getByBeach, getByCity, getByWifi} from "../assets/filterMethods.js"
import enums from "../assets/enums.js";
import countries from "../assets/countries.js";

const store = createStore({

    // Properties
   state:{

        headline: "Welcome to our awesome website!",
        accomodations: [],
        filter: [],
        userId: localStorage.getItem('userId'),
        isLoggedIn: localStorage.getItem('loggedIn'),
        userEmail: null,
        userPassword: null,
        loginAttemptMessage: null,
        destination: null,
        apiState: enums.init,
        countries: countries.data,

        // Booking States
        bookedRooms: [],
        bookingParams: null,
        booking: {
            UserId: null,
            AccomodationId: null,
            NbrOfAdults: null,
            NbrOfChildren: null,
            CheckOutDate: null,
            CheckInDate: null,
            PaymentDate: null,
            RoomIds: []
        },
   },

   // Methods for changing states synchronously
   mutations:{
        getAccomodationsData(state, payload) {
            state.accomodations = payload;
            state.filteredAccomodations = payload;
            state.apiState = enums.loaded;
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
        setUserEmail(state, usrEmail){
            state.userEmail = usrEmail;
        },
        setUserPassword(state, usrPassword){
            state.userPassword = usrPassword;
        },
        setDestination(state, searchQuery){
            state.destination = searchQuery;
        },
        setBookingParameters (state, payload) {
            state.bookingParams = payload;
        },
        updateAccomodations (state, payload) {
            state.accomodations = payload;
            state.apiState = enums.loaded;
        },
        setAccomodationsNull (state, payload){
            state.accomodations = payload;
            state.apiState = enums.init;
        },
        setApiState (state, apiState) {
            state.apiState = apiState;
        },
        setBookedRooms (state, payload) {
            state.bookedRooms = payload;
        },
        setBooking (state, payload) {
            state.booking = payload;
        },
   },
   getters: {
        filteredList(state){
            return getByWifi(getByCity(getByBeach(getByRooms(getByExtras(getByAmenities(getByName(getByRating(getByStars(getByMaxPrice(getByMinPrice(state.accomodations, state.filter), state.filter), state.filter), state.filter), state.filter), state.filter), state.filter), state.filter), state.filter), state.filter), state.filter)
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
        },

        //Old code, but keep for science and if needed to change back
        // async getLoginAttempt({commit}){
        //     let response = await fetch('https://localhost:44323/api/User/login?email='+ this.state.userEmail + '&password=' + this.state.userPassword,{
        //         method:'post'
        //     })
        //     let json = await response.json();
        //     commit('setUserId', json.userId);
        //     commit('setLoggedInState', json.isLoggedIn)
        //     commit('setLoginAttemptMessage', json.loggedInMessage)
        //     if(json.isLoggedIn === true){
        //         localStorage.setItem('userId', this.state.userId);
        //         localStorage.setItem('loggedIn', this.state.isLoggedIn);
        //     }
        // },
        async getQueriedDestinations({commit}){

            let response = await fetch('https://localhost:44323/api/Accomodations/search?destination='+ this.state.destination)

            if(response.status != (204))
            {
            let json = await response.json();
            commit('updateAccomodations', json);
            }
            else {
                commit('updateAccomodations', null);
            }
        },
    }
})

export default store