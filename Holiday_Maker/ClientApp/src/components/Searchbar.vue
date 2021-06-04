<template>
<!-- Background image -->
    <div class="search-dest-box">
        <form>
            <!-- Begin input fields -->
            <div class="flex flex-row flex-wrap gap-3 mt-8 op90">
                <div class="rounded-t-md bg-green-1 search-div shadow-xl w-4/8">
        
                    <!-- Search Destination -->
                    <div class="text-green-500">
                        <font-awesome-icon :icon="['fas', 'map-marker-alt']" class="mt-3 mr-4 fa-2x float-left" style="color: #52B788;"/>

                        <AutoComplete
                            v-model="destinationSearch"
                            :suggestions="filteredCountries" 
                            @complete="searchCountry($event)"
                            @item-select="setInput($event)"
                            field="name" 
                            class="float-left border-2 border-green-500 bg-white h-10 px-5 mt-2 pr-20 rounded-lg text-lg"
                            placeholder="Destination..."
                        />

                    </div>
                </div>
                <!-- Check-in -->
                <div class="rounded-t-md bg-green-1 search-div shadow-xl w-1/8">
                    <div class="text-green-500">
                        <p class="float-left mt-2 ml-2" style="font-size: 10pt; font-weight: bold;">Check-in</p>
                        <input class="border-2 border-green-500 bg-white h-10 px-1 mt-2 pr-2 rounded-lg text-lg focus:outline-none" ref="checkOut" v-model="bookingParams.checkIn" type="date">
                    </div>
                </div>
                
                <!-- Check-out -->
                <div class="rounded-t-md bg-green-1 search-div shadow-xl w-1/8">
                    <div class="text-green-500">
                        <p class="float-left mt-2 ml-2" style="font-size: 10pt; font-weight: bold;">Check-out</p>
                        <input class="border-2 border-green-500 bg-white h-10 px-1 mt-2 pr-2 rounded-lg text-lg focus:outline-none" ref="checkOut" v-model="bookingParams.checkOut" type="date">
                    </div>
                </div>
                
                <!-- Number of travellers -->
                <div class="rounded-t-md bg-green-1 search-div shadow-xl w-2/8">
                    <div class="text-green-500">
                        <font-awesome-icon :icon="['fas', 'users']" class="mt-3 mr-4 fa-2x float-left" style="color: #52B788;"/>
                        <select class="float-left border-2 border-green-500 bg-white h-10 w-40 px-5 mt-2 pr-4 rounded-lg text-lg focus:outline-none" v-model="bookingParams.travellersAdults">
                            <option disabled selected value="">Adults</option>
                            <option>1</option>
                            <option>2</option>
                            <option>3</option>
                        </select>
                        <select class="float-left border-2 border-green-500 bg-white h-10 w-40 px-5 mt-2 ml-2 pr-4 rounded-lg text-lg focus:outline-none" v-model="bookingParams.travellersChildren">
                            <option disabled selected value="">Children</option>
                            <option>1</option>
                            <option>2</option>
                            <option>3</option>
                        </select>
                    </div>
                </div>
                <!-- End input fields -->        
            </div>
            <!-- End input fields container -->

            <!-- Begin Tabs -->
            <div class="flex flex-row flex-wrap gap-3">
                <div class="nav-div w-4/8">
                    <!-- Accommodation and Flight Tabs-->
                    <div>
                        <ul class="flex items-stretch op90">
                            <li class="w-1/2">
                                <a class="flex border rounded-b-lg border-green-500 rounded py-2 px-4 bg-green-1 text-green-500 font-bold" href="#">
                                <font-awesome-icon :icon="['fas', 'home']" class="mt-1 mr-4 float-left" style="color: #52B788;"/>Accommodations</a>
                            </li>
                            <li class="w-1/2">
                                <a class="flex border rounded-b-lg border-green-500 hover:border-green-100 bg-green-500 text-green-100 py-2 px-4" href="#">
                                <font-awesome-icon :icon="['fas', 'plane']" class="mt-1 mr-4 float-left" style="color: #D8F3DC;"/>Flights</a>
                            </li>
                        </ul>
                    </div>
                </div>
                <!-- Filler container -->
                <div class="nav-div w-1/8">
                    <div>
                    </div>
                </div>
                    
                <!-- Filler container-->
                <div class="nav-div w-1/8">
                    <div>
                      
                    </div>
                </div>
                    
                <!-- Filler container -->
                <div class="nav-div w-2/8">
                    <div>

                    </div>
                </div>
            </div>
                
            <!-- Search Button -->
            <div class="op90" style="text-align:center">
                <input type="submit" value="SEARCH" @click="search" class="mt-6 w-2/6 bg-green-500 hover:bg-green-700 text-white font-bold py-3 px-4 rounded-full shadow-xl"/>
            </div>
        </form>
    </div>
</template>

<script>
import enums from "../assets/enums.js";
import mixin from "../mixins.js"

export default {
    mixins: [mixin],

    mounted(){
        this.setApiState(enums.init)
    },

    data()
    {
        return{
            destinationSearch: '',

            // Booking parameters with default values
            bookingParams:{
                checkIn: this.currentDate(0),
                checkOut: this.currentDate(1),
                travellersAdults: '',
                travellersChildren: '',
            },
            image: "./assets/images/front-bg.jpg",

            //Autocomplete Data
            countries: this.$store.state.countries,
            selectedCountry: null,
            selectedCity: null,
            filteredCities: null,
            filteredCountries: null,
            selectedCountries: [],
        }
    },

    methods:{
        formatQuery(){
            this.destinationSearch = this.destinationSearch.trim()
            this.destinationSearch  = this.destinationSearch.toLowerCase()
            this.destinationSearch  = this.destinationSearch.charAt(0).toUpperCase() + this.destinationSearch.slice(1)
        },

        checkBookingParams(){
            if (this.bookingParams.checkIn == ''){
                this.bookingParams.checkIn = this.currentDate(0)
            }
                
            if (this.bookingParams.checkOut == ''){
                this.bookingParams.checkOut = this.currentDate(1)
            }
            
            if (this.bookingParams.travellersAdults == ''){
                this.bookingParams.travellersAdults = 1
            }

            if (this.bookingParams.travellersChildren == ''){
                this.bookingParams.travellersChildren = 0
            }
        },

        async search(e)
        {
            e.preventDefault()

            if(this.destinationSearch.length > 1)
            {   // Format destinationSearch if more than one word
                if (this.destinationSearch.match(/\b\w+\b/g) > 1){
                    this.formatQuery()
                    }
                else{
                        this.destinationSearch = this.destinationSearch.split(" ")[0]
                        this.formatQuery()
                        
                        // Write formatted destination to state
                        this.setDestination(this.destinationSearch)

                        // Check if booking parameters have values, if not then set default values
                        this.checkBookingParams()

                        // Write checkIn, checkOut, adults and children to state
                        this.setBookingParameters(this.bookingParams)
                        console.log(this.$store.state.bookingParams.checkIn)
                        
                        // Get accomodations from API and write to state
                        this.getQueriedDestinations()
                    }
            }
            else {
                // Write checkIn, checkOut, adults and children to state
                this.setBookingParameters(this.bookingParams)

                this.checkBookingParams()
                        
                 // Get all accommodations
                this.$store.dispatch("getAccomodations");
            }

            // Route to results page
            this.$router.push({ name: "Hotels"})

        },
        // Autocomplete events
        searchCountry(event) {
            setTimeout(() => {
                if (!event.query.trim().length) {
                    this.filteredCountries = [...this.countries];
                }
                else {
                    this.filteredCountries = this.countries.filter((country) => {
                        return country.name.toLowerCase().startsWith(event.query.toLowerCase());
                    });
                }
            }, 250);
        },

        setInput(event) {
            this.destinationSearch = event.value.name
        },

    // Set destination in state to formatted search parameter
    setDestination(searchQuery) {
      this.$store.commit("setDestination", searchQuery);
    },
    setBookingParameters(payload) {
      this.$store.commit("setBookingParameters", payload);
    },
    setApiState(newState) {
      this.$store.commit("setApiState", newState);
    },
    // Call API and update accomodations state based on destination state
    getQueriedDestinations() {
      this.$store.dispatch("getQueriedDestinations");
    },
    // Get all accommodations (no search query)
    getAccomodations() {
      this.$store.dispatch("getAccomodations");
    },
        },
}
</script>