<template>
    
    <div class="hotel-item-desc-left">
        <h1 style="font-size:20px;">{{accomodation.name}}</h1>
        <h2 style="font-size:16px; display:inline;">{{accomodation.country}}</h2>
        <h2 style="font-size:14px; display:inline;">, {{accomodation.city}}</h2>
        <p style="height: 100px">{{accomodation.description}}</p>

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
    
    <div v-for="stars in accomodation.starRating" :key="stars" style="display:inline-block; margin-bottom:5px">
        <font-awesome-icon :icon="['fas', 'star']" size="lg" style="color: #52B788;"/>
    </div><br/>
    
    <FavoriteButton :accomodationObject="accomodation" />
    
        <h2 style="font-size:20px; margin-top:115px">{{lowestRoom(accomodation.id)}}€</h2>
    </div>
</template>

<script>
import FavoriteButton from '/src/components/FavoriteButton.vue'
import { mapGetters } from 'vuex'

export default ({
  components:{
    FavoriteButton
  },
    props: {
        accomodation: Object
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
        }
    },
  computed:{ 
      ...mapGetters([
          'filteredList'
      ])
  }
})
</script>
