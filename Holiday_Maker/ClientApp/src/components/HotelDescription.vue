<template>
    
    <div class="hotel-item-desc-left"  @click="goToAccommodation(accomodation.id)">
        <h1 style="font-size:20px; height: 30px; overflow: hidden">{{accomodation.name}}</h1>
        <h2 style="font-size:16px; display:inline;">{{accomodation.country}}</h2>
        <h2 style="font-size:14px; display:inline;">, {{accomodation.city}}</h2>
        <p style="height: 100px; margin-top: 5px; overflow: hidden; border-top: 1px solid green">{{accomodation.description}}</p>

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
    <div class="hotel-item-desc-right">
    
        <div style="height: 120px">
            <div v-for="stars in accomodation.starRating" :key="stars" style="display:inline-block; margin-bottom:5px;">
                <font-awesome-icon :icon="['fas', 'star']" size="lg" style="color: #52B788;"/>
            </div><br/>
        
            <FavoriteButton v-if="this.$store.state.isLoggedIn" :accomodationObject="accomodation"/>
        </div>
        <div v-if="lowestRoom(accomodation.id) == Infinity">
            <p style="font-size:14px;">Go to hotel</p>
            <p style="font-size:12px;">To see prices</p>
        </div>
        <div v-else>
            <p style="font-size:14px;">From</p>
            <h2 style="font-size:20px;">{{lowestRoom(accomodation.id)}}€</h2>
            <p style="font-size:12px;">per night</p>
        </div>
    </div>
</template>

<script>
import FavoriteButton from '/src/components/FavoriteButton.vue'
import { mapGetters } from 'vuex'

export default ({
    props: {
        accomodation: Object,
    },
    components:{
        FavoriteButton,
    },
    methods: {
        lowestRoom(accomodationId){
            if (!accomodationId) return accomodationId
    
            let hotel = this.filteredList.filter(item => item.id == accomodationId)
            let low = []
            hotel.forEach(item => {
                item.rooms.forEach(room => low.push(room.price))
            });
            low = Math.min(...low)

            return low
        },
        goToAccommodation(accommodationId) {
            this.$router.push({
                name: "Accommodation",
                params: { id: accommodationId },
            });
        }
    },
    computed:{ 
        ...mapGetters([
            'filteredList'
        ])
    }
})
</script>
