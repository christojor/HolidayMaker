<template>
        <div class="search-dest-box bg-contain" style="background-image: url(src/assets/images/front-bg.jpg)">
            <form>
                <div class="rounded flex flex-row flex-wrap gap-3 mt-5">
                    <div class="rounded bg-green-1 search-div shadow-xl">
                        <p>Destination</p>
                        <font-awesome-icon :icon="['fas', 'map-marker-alt']" size="lg" style="color: #52B788;"/>
                        <input class="rounded search-input" v-model="destination" type="text" placeholder="Enter destination...">
                    </div>
                    
                    <div class="rounded bg-green-1 search-div shadow-xl">
                        <p>Check-in Date</p>
                        <input class="rounded search-input" ref="check_in" v-model="check_in" type="date">
                    </div>
                    
                    <div class="rounded bg-green-1 search-div shadow-xl">
                        <p>Check-out Date</p>
                        <input class="rounded search-input" ref="check_out" v-model="check_out" type="date">
                    </div>
                    
                    <div class="rounded bg-green-1 search-div shadow-xl">
                        <p>Guests</p>
                        <font-awesome-icon :icon="['fas', 'users']" size="lg" style="color: #52B788;"/>
                        <select class="rounded search-input" v-model="selected">
                            <option disabled value="">Number of Guests</option>
                            <option>1</option>
                            <option>2</option>
                            <option>3</option>
                        </select>
                    </div>      
                </div>
                <div class="flex flex-row flex-wrap gap-2 mt-2" style="justify-content:center;padding:1em">
                    <div class="border-2 border-green-5 rounded bg-green-1" style="padding-left:1em;padding-right:1em">
                        <label for="beachslider" style="padding-right:1em">Distance to Beach</label>
                        <input id="beechslider" type="range" min="50" v-model="distanceToBeech" max="1000" step="50" style="flex:1">
                        <output for="beechslider" :value="500 + ' m'">{{distanceToBeech}} m</output>
                    </div>
                    <div class="border-2 border-green-5 rounded bg-green-1" style="padding-left:1em;padding-right:1em">
                        <label for="cityslider" style="padding-right:1em">Distance to City Center</label>
                        <input id="cityslider" type="range" min="50" v-model="distanceToCity" max="1000" step="50" style="flex:1">
                        <output for="cityslider" :value="500 + ' m'">{{distanceToCity}} m</output>
                    </div>
                </div>
                <div style="width:100vw; text-align:center">
            <input type="submit" value="Search" @click="search" class="mt-6 w-1/2 bg-green-500 hover:bg-green-700 text-white font-bold py-2 px-4 rounded-full shadow-xl"/>
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