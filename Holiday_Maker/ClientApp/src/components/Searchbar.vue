<template>
        <div class="rounded search-dest-box" style="">

            <h class="text-2xl">Search for hotels</h>
            <form>
                <div class="rounded flex flex-row flex-wrap gap-3">
                    <div class="rounded bg-green-3 search-div">
                        <p>Destination</p>
                        <input class="rounded search-input" v-model="destination" type="text" placeholder="Enter your destination">
                    </div>
                    
                    <div class="rounded bg-green-3 search-div">
                        <p>Check in date</p>
                        <input class="rounded search-input" ref="check_in" v-model="check_in" type="date">
                    </div>
                    
                    <div class="rounded bg-green-3 search-div">
                        <p>Check out date</p>
                        <input class="rounded search-input" ref="check_out" v-model="check_out" type="date">
                    </div>
                    
                    <div class="rounded bg-green-3 search-div">
                        <p>Guests</p>
                        <select class="rounded search-input" v-model="selected">
                            <option disabled value="">Number of guests</option>
                            <option>1</option>
                            <option>2</option>
                            <option>3</option>
                        </select>
                    </div>      
                </div>
                <div class="flex flex-row flex-wrap gap-2" style="justify-content:center;padding:1em">
                    <div class="border-2 rounded" style="padding-left:1em;padding-right:1em">
                        <label for="beachslider" style="padding-right:1em">Distance to beach</label>
                        <input id="beechslider" type="range" min="50" v-model="distanceToBeech" max="1000" step="50" style="flex:1">
                        <output for="beechslider" :value="500 + ' m'">{{distanceToBeech}} m</output>
                    </div>
                    <div class="border-2 rounded" style="padding-left:1em;padding-right:1em">
                        <label for="cityslider" style="padding-right:1em">Distance to city center</label>
                        <input id="cityslider" type="range" min="50" v-model="distanceToCity" max="1000" step="50" style="flex:1">
                        <output for="cityslider" :value="500 + ' m'">{{distanceToCity}} m</output>
                    </div>
                </div>
            </form>
        </div>
        <div style="width:100vw; text-align:center">
            <button @click="search" class="rounded-full border-2" style="top:10px;width:20em;">
                Search
            </button>
        </div>
</template>

<script>
export default {
    data()
    {
        return{
            distanceToCity: 500,
            distanceToBeech: 500,
            destination: '',
            check_in: '',
            check_out: '',
            selected: '',
        }
    },
    methods:{
        async search()
        {
            var presplit = this.$refs.destination.value
            var splitted = presplit.split(" ")
            console.log(splitted)

            let rawResponse = await fetch('https://localhost:44323/api/Accomodations/search?country=' + splitted[0] + '&city=' + splitted[1])
            console.log(rawResponse)
            let respone = await rawResponse.json()
            console.log(respone)

        },
    }
}
</script>