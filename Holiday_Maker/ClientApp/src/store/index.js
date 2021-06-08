import { createStore } from "vuex" 
import { getByName, getByStars, getByRating , getByMaxPrice, getByMinPrice, getByAmenities, getByExtras, getByRooms, getByBeach, getByCity, getByWifi} from "../assets/filterMethods.js"
import enums from "../assets/enums.js";
import countries from "../assets/countries.js";

const store = createStore({

    // Properties
   state:{
        totalPrice: 0,
        accomodations: [],
        filter: [],
        userId: localStorage.getItem('userId'),
        isLoggedIn: localStorage.getItem('loggedIn'),
        user:{
            id: localStorage.getItem('userId'),
            userName: null,
            email: null,
            firstName: null,
            lastName: null,
            country: null,
            city: null,
            streetAddress: null,
            zipCode: null,
            memberTypeId: null,
            creditCard: null,
            memberPoints: null
        },
        userEmail: null,
        userPassword: null,
        userFavorites: null,
        addedMemberPoints: null,
        loginAttemptMessage: null,
        destination: null,
        apiState: enums.init,
        countries: countries.data,
        // Booking States

        userBookings: [],
        bookedRooms: [],
        bookingParams: null,
        nbrOfNights: 1,
        bookingObject: {
            booking:{},
            bookedRoom: []
              },
        paymentError: null,
        paymentErrorMessage: null,
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
            state.user.id = payload.Id
            state.user.userName = payload.userName;
            state.user.email = payload.email;
            state.user.firstName = payload.firstName;
            state.user.lastName = payload.lastName;
            state.user.country = payload.country;
            state.user.city = payload.city;
            state.user.streetAddress = payload.streetAddress;
            state.user.zipCode = payload.zipCode;
            state.user.memberTypeId = payload.memberTypeId;
            state.user.memberPoints = payload.memberPoints;
        },
        setMemberPoints (state, payload){
            state.user.memberPoints += payload;
        },
        setTotalPrice(state, payload){
            state.totalPrice = payload;
        },
        setUserFavorites(state, payload){
            state.userFavorites = payload;
        },
        setUserBookings(state, payload){
            state.userBookings = payload;
        },
        setPaymentFailed(state, payload){
            state.paymentError = payload;
        },
        setPaymentFailureMessage(state, payload){
            state.paymentErrorMessage = payload
        }
   },
   getters: {
        filteredList(state){
            return getByWifi(getByCity(getByBeach(getByRooms(getByExtras(getByAmenities(getByName(getByRating(getByStars(getByMaxPrice(getByMinPrice(state.accomodations, state.filter), state.filter), state.filter), state.filter), state.filter), state.filter), state.filter), state.filter), state.filter), state.filter), state.filter)
        },
    },

    // Functions that call mutations asynchronously. Called by using dispatch (instead of state) in component.
    actions:{
        async getUserFavorites({commit}){
            let response = await fetch('https://localhost:44323/api/User/favorites?userId=' + this.state.userId);
            let json = await response.json();
            commit('setUserFavorites', json);
        },

        

        async getAccomodations({ commit }) {

            let response = await fetch('https://localhost:44323/api/accomodations');
            let json = await response.json();

            sessionStorage.setItem('accomodations', JSON.stringify(json))
            commit('getAccomodationsData', json);
        },

        async getQueriedDestinations({commit}){

            let response = await fetch('https://localhost:44323/api/Accomodations/search?destination='+ this.state.destination + '&checkInDate=' + this.state.bookingParams.checkIn + '&checkOutDate=' + this.state.bookingParams.checkOut)

            if(response.status != (204))
            {
                let json = await response.json();

                sessionStorage.setItem('accomodations', JSON.stringify(json))
                commit('updateAccomodations', json);
            }
            else {
                sessionStorage.clear()
                commit('updateAccomodations', null);
            }
        },

        // This method fetches a user with an API GET. Name should be getUser. The mutation sets the data.
        // Name change also broke my code, so I changed it back. /CJ
        // Fuck you, eat shit. Best regards, GR
        // XOXOXO. Love you too. /CJ
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

        async updateMemberPoints(){
                this.state.user.id = this.state.userId;

                await fetch('https://localhost:44323/api/User/UpdateMemberPoints', { 
                method: 'post',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(this.state.user)
            });
        }
    }
})

export default store