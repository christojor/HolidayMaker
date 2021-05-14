<template>
        <div class="border-4 border-solid rounded border-black" style="">

            <h class="text-2xl">Search for hotels</h>
            <form>
                <div class="border-0 border-green-400 border-solid rounded flex flex-row flex-wrap gap-3" style="place-items:center;align-items:stretch;">
                    <div class="border-8 border-solid rounded content-end" style="background-color:#74C69D;border-color:#1b4332;flex:1;">
                        <input v-model="destination" class="rounded-t1-sm" ref="destination" type="text" placeholder="Enter your destination" style="magin:auto;display:inline-block;margin-top:5.5%">
                    </div>
                    <div class="border-8 border-solid rounded" style="background-color:#74C69D;border-color:#1b4332;flex:1;">
                        <p>Check in date</p>
                        <input class="rounded" ref="check_in" v-model="check_in" type="date">
                    </div>
                    <div class="border-8 border-solid rounded" style="background-color:#74C69D;border-color:#1b4332;flex:1">
                        <p>Check out date</p>
                        <input class="rounded" ref="check_out" v-model="check_out" type="date" style="margin:2%">
                    </div>
                    <div class="border-8 border-solid rounded" style="background-color:#74C69D;border-color:#1b4332;flex:1;justify-content:center">
                        <select class="rounded" v-model="selected" style="margin-top:5.5%;">
                            <option disabled value="">Number of guests</option>
                            <option>1</option>
                            <option>2</option>
                            <option>3</option>
                        </select>
                    </div>      
                </div>
                <div class="flex flex-row flex-wrap gap-2" style="display:flex;justify-content:center;text-align:center;align-items:center;padding:1em">
                    <div class="border-2 rounded" style="padding-left:1em;padding-right:1em">
                        <label for="beachslider" style="padding-right:1em">Distance to beach</label>
                        <input id="beechslider" type="range" min="50" v-model="distanceToBeech" max="1000" step="50" style="flex:1" @change="outputUpdate">
                        <output for="beechslider" :value="500 + ' m'">{{distanceToBeech}}</output>
                    </div>
                    <div class="border-2 rounded" style="padding-left:1em;padding-right:1em">
                        <label for="cityslider" style="padding-right:1em">Distance to city center</label>
                        <input id="cityslider" type="range" min="50" v-model="distanceToCity" max="1000" step="50" style="flex:1" @change="outputUpdate">
                        <output for="cityslider" :value="500 + ' m'">{{distanceToCity + " m"}}</output>
                    </div>
                </div>
                
            </form>
        </div>
        <div>
            <button @click="search()" class="rounded-full border-2 border-green-800" style="position:relative;top:10px;width:20em;">
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
            distanceToBeech: 500
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

    },
    data() {

        return {
            destination: '',
            check_in: '',
            check_out: '',
        }
        
    },
}
</script>