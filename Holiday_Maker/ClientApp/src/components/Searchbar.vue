<template>
<!-- Background image -->
        <div class="search-dest-box">
            <form>

                <!-- Begin input fields -->
                <div class="flex flex-row flex-wrap gap-3 mt-8">
        <div class="rounded-t-md bg-green-1 search-div shadow-xl w-4/8">

    <!-- Search Destination -->
        <div class="text-green-500">
        <font-awesome-icon :icon="['fas', 'map-marker-alt']" class="mt-3 mr-4 fa-2x float-left" style="color: #52B788;"/>
        <AutoComplete />
      </div>
            </div>
                    <!-- Check-in -->
                    <div class="rounded-t-md bg-green-1 search-div shadow-xl w-1/8">
                    <div class="text-green-500">
                    <p class="float-left mt-2 ml-2" style="font-size: 10pt; font-weight: bold;">Check-in</p>
                        <input class="border-2 border-green-500 bg-white h-10 px-1 mt-2 pr-2 rounded-lg text-lg focus:outline-none" ref="check_in" v-model="check_in" type="date">
                    </div>
                    </div>
                    
                    <!-- Check-out -->
                    <div class="rounded-t-md bg-green-1 search-div shadow-xl w-1/8">
                    <div class="text-green-500">
                        <p class="float-left mt-2 ml-2" style="font-size: 10pt; font-weight: bold;">Check-out</p>
                        <input class="border-2 border-green-500 bg-white h-10 px-1 mt-2 pr-2 rounded-lg text-lg focus:outline-none" ref="check_out" v-model="check_out" type="date">
                    </div>
                    </div>
                    
                    <!-- Number of travellers -->
                    <div class="rounded-t-md bg-green-1 search-div shadow-xl w-2/8">
                    <div class="text-green-500">
                        <font-awesome-icon :icon="['fas', 'users']" class="mt-3 mr-4 fa-2x float-left" style="color: #52B788;"/>
                        <select class="float-left border-2 border-green-500 bg-white h-10 px-5 mt-2 pr-4 rounded-lg text-lg focus:outline-none" v-model="selected">
                            <option disabled value="">Number of Travellers</option>
                            <option>1</option>
                            <option>2</option>
                            <option>3</option>
                            <option>4</option>
                        </select>
                    </div>
                    </div>
                          <!-- End input fields -->
                </div>

                <!-- Search Button -->
                <div style="text-align:center">
            <input type="submit" value="Search" @click="search" class="mt-6 w-2/6 bg-green-500 hover:bg-green-700 text-white font-bold py-3 px-4 rounded-full shadow-xl"/>
        </div>
            </form>
        </div>
        
</template>

<script>
import enums from "../assets/enums.js";
import AutoComplete from "../components/search/AutoComplete.vue";

export default {
    mounted(){
        this.setApiState(enums.init)
        console.log("ApiStateMounted:" + this.$store.state.apiState)
    },
    data()
    {
        return{
            destinationSearch: '',
            check_in: '',
            check_out: '',
            selected: '',
            image: "./assets/images/front-bg.jpg",
        }
    },
    components:{
        AutoComplete,
    },
    methods:{
        formatQuery(){
            this.destinationSearch = this.destinationSearch.trim()
            this.destinationSearch  = this.destinationSearch.toLowerCase()
            this.destinationSearch  = this.destinationSearch.charAt(0).toUpperCase() + this.destinationSearch.slice(1)
        },
        async search()
        {
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
                        
                        // Get accomodations from API and write to state
                        this.getQueriedDestinations(this.$store.state.destination)
                    }
            }
            else {
                 // Get all accommodations
                this.$store.dispatch("getAccomodations");
            }

            // Route to results page
            this.$router.push({ name: "Hotels"})

        },

    // Set destination in state to formatted search parameter
    setDestination(searchQuery) {
      this.$store.commit("setDestination", searchQuery);
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