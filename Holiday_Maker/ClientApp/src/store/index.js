import { createStore } from "vuex" 
import { getByName, getByStars, getByRating , getByMaxPrice, getByMinPrice, getByAmenities, getByExtras, getByRooms, getByBeach, getByCity, getByWifi} from "../assets/filterMethods.js"
import enums from "../assets/enums.js";
import countries from "../assets/countries.js";

const store = createStore({

    // Properties
   state:{
        accomodations: [],
        filter: [],
        userId: localStorage.getItem('userId'),
        isLoggedIn: localStorage.getItem('loggedIn'),
        user: null,
        userEmail: null,
        userPassword: null,
        addedMemberPoints: null,
        loginAttemptMessage: null,
        destination: null,
        apiState: enums.init,
        countries: countries.data,

        // Booking States
        bookedRooms: [],
        bookingParams: null,
        nbrOfNights: 1,
        bookingObject: {
            booking:{},
            bookedRoom: []
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
            state.bookingObject = payload;
        },
        setNbrOfNights (state, payload) {
            state.nbrOfNights = payload;
        },
        setUser (state, payload) {
            state.user = payload;
        },
        setMemberPoints (state, payload){
            state.user.memberPoints += payload;
        },
   },
   getters: {
        filteredList(state){
            return getByWifi(getByCity(getByBeach(getByRooms(getByExtras(getByAmenities(getByName(getByRating(getByStars(getByMaxPrice(getByMinPrice(state.accomodations, state.filter), state.filter), state.filter), state.filter), state.filter), state.filter), state.filter), state.filter), state.filter), state.filter), state.filter)
        },
    },

    // Functions that call mutations asynchronously. Called by using dispatch (instead of state) in component.
    actions:{

        async getAccomodations({ commit }) {

            let response = await fetch('https://localhost:44323/api/accomodations');
            let json = await response.json();

            commit('getAccomodationsData', json);
        },

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

        async getUser({commit}){
            let response = await fetch('https://localhost:44323/api/User/' + this.state.userId)
            let json = await response.json();

            commit('setUser', json);
        },

        async sendBooking(){
            await fetch('https://localhost:44323/api/Booking/CreateBooking', {
                method: 'post',
                headers: {'Content-Type': 'application/json'},
                body: JSON.stringify(this.state.bookingObject)
            });
        },

        async updateMemberPoints({commit}){
            let response = await fetch('https://localhost:44323/api/User/UpdateMemberPoints', { 
                method: 'post',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(this.state.user)
            });
            let json = await response.json();

            commit('setUser', json);
        }
    }
})

export default store