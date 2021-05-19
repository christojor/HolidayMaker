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
        <input class="float-left border-2 border-green-500 bg-white h-10 px-5 mt-2 pr-20 rounded-lg text-lg focus:outline-none" 
        id="destination" name="destination" v-model="destination" type="text" placeholder="Destination..." 
        autocomplete="country-name, address-level1" spellcheck="false">
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
export default {
    created() {
    this.$store.dispatch("getAccomodations");
    },

    data()
    {
        return{
            distanceToCity: 500,
            distanceToBeech: 500,
            destination: '',
            check_in: '',
            check_out: '',
            selected: '',
            image: "./assets/images/front-bg.jpg",
        }
    },
    methods:{
        async search()
        {
            // Format destination input (Refactor later!)
            if (this.destination.match(/\b\w+\b/g) > 1){
            this.destination = this.destination.trim()
            this.destination = this.destination.toLowerCase()
            this.destination = this.destination.charAt(0).toUpperCase() + this.destination.slice(1)
            }
            else{
            this.destination = this.destination.split(" ")[0]
            this.destination = this.destination.trim()
            this.destination = this.destination.toLowerCase()
            this.destination = this.destination.charAt(0).toUpperCase() + this.destination.slice(1)
            }

            // Get current data from store
            let allAccomodations = this.$store.state.accomodations
            let queriedAccomodations = []
            console.log(queriedAccomodations)
            console.log(this.destination)

            // Check country and city
            if (this.destination.length){
                allAccomodations.forEach(accomodation => {
                if(accomodation.country == this.destination || accomodation.city == this.destination)
                {
                    queriedAccomodations.push(accomodation);
                    console.log(accomodation)
                }
            });
            } 
            else {
                queriedAccomodations = allAccomodations
            }

            this.updateAccomodations(queriedAccomodations)

            this.$router.push({ name: "Hotels"}) //Ok

        },

    getAccomodations() {
      this.$store.dispatch("getAccomodations");
    },
    updateAccomodations(queriedAccomodations) {
      this.$store.commit("updateAccomodations", queriedAccomodations);
    },
    filterList(filter){
            this.$store.commit("updateFilter", filter)
        }
    }
}
</script>