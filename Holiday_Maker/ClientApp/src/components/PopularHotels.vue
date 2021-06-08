<template>
    <div class="container1" style="padding-top:100px">
        <h1 style="font-size:40px; border-bottom: 1px black solid">Popular Destinations</h1>
        <div v-for="accomodation in accomodations" :key="accomodation" class="popularHotel bg-green-1 shadow-md op80" style="cursor:pointer">
            <img :src="accomodation.imgSrc" style="height:250px; width:100%; border-radius:7px" @click="goToAccommodation(accomodation.id)">

            <div style="width:79%; height:180px; display:inline-block; padding-top:5px" @click="goToAccommodation(accomodation.id)">
                <h1 style="font-size:20px; height:35px; overflow:hidden">{{accomodation.name}}</h1>

                <h2 style="font-size:16px; height:20px; overflow:hidden">{{accomodation.country}}</h2>
                <h2 style="font-size:14px; height:20px; overflow:hidden">{{accomodation.city}}</h2> 
                
                <div style="margin-top:80px">
                    <div v-if="accomodation.guestRating <= 2">
                        <h2 style="font-size:16px;"><font-awesome-icon :icon="['fas', 'poop']" size="lg" style="color: #52B788;"/> {{accomodation.guestRating}}</h2>
                    </div>
                    <div v-if="accomodation.guestRating > 2 && accomodation.guestRating <= 5">
                        <h2 style="font-size:16px;"><font-awesome-icon :icon="['fas', 'poo']" size="lg" style="color: #52B788;"/> {{accomodation.guestRating}}</h2>
                    </div>
                    <div v-if="accomodation.guestRating > 5 && accomodation.guestRating <= 8">
                        <h2 style="font-size:16px;"><font-awesome-icon :icon="['fas', 'smile']" size="lg" style="color: #52B788;"/> {{accomodation.guestRating}}</h2>
                    </div>
                    <div v-if="accomodation.guestRating > 8">
                        <h2 style="font-size:16px;"><font-awesome-icon :icon="['fas', 'grin-hearts']" size="lg" style="color: #52B788;"/> {{accomodation.guestRating}}</h2>
                    </div>
                </div>
            </div>

            <div style="width:19%; height:180px; display:inline-block; text-align:right; vertical-align:top; padding-top:5px" @click="goToAccommodation(accomodation.id)">
                <div v-for="stars in accomodation.starRating" :key="stars" style="margin-bottom:5px">
                    <font-awesome-icon :icon="['fas', 'star']" size="lg" style="color: #52B788;"/>
                </div>
            </div>
            
        </div>
    </div>
</template>

<script>
export default {
    mounted(){
        this.getPopularHotels()
    },
    data() {
        return{
            accomodations: []
        }
    },
    methods:{
        async getPopularHotels(){
            let response = await fetch('https://localhost:44323/api/Accomodations/GetPopularAccomodations')
            this.accomodations = await response.json()

            this.$store.commit('updateAccomodations', this.accomodations);
        },
        goToAccommodation(accommodationId) {
            this.$router.push({
                name: "Accommodation",
                params: { id: accommodationId },
            });
        },
    }
}
</script>