<template>
    <div class="container1">

        <div class="container2 shadow-md bg-green-1">
            <Name @filter-search="filterName"/>
            <StarRating @filter-search="filterStars"/>
            <UserRating @filter-search="filterRating"/>
            <Price @filter-search="filterPrice"/>
            <Extras @filter-search="filterExtras"/>
            <RoomType @filter-search="filterRooms"/>
        </div>

        <div class="container3 shadow-md bg-green-1">
            <API :filter="filter" :getAccomodations="getAccomodations"/>
        </div>

    </div>
</template>

<script>
import API from "/src/components/API.vue"
import Name from "/src/components/SearchProperty.vue"
import StarRating from "/src/components/SearchStarRating.vue"
import UserRating from "/src/components/SearchUserRating.vue"
import Price from "/src/components/SearchPrice.vue"
import Extras from "/src/components/SearchExtras.vue"
import RoomType from "/src/components/SearchRoomType.vue"
import Themes from '/src/components/Themes.vue'

    let rawResponse = await fetch('https://localhost:44323/api/accomodations');
    let getAccomodations = await rawResponse.json();

export default{
    components: {
        API,
        Name,
        StarRating,
        UserRating,
        Price,
        Themes,
        Extras,
        RoomType,
    },
    methods: {
        filterName(filter){
            this.filter.PropName = filter.PropName
            this.filter.PropStars = this.filter.PropStars
            this.filter.PropRating = this.filter.PropRating
            this.filter.PropMinPrice = this.filter.PropMinPrice
            this.filter.PropMaxPrice = this.filter.PropMaxPrice
            this.filter.PropExtras = this.filter.PropExtras
            this.filter.PropRooms = this.filter.PropRooms
        },
        filterStars(filter){
            this.filter.PropName = this.filter.PropName
            this.filter.PropStars = filter.PropStars
            this.filter.PropRating = this.filter.PropRating
            this.filter.PropMinPrice = this.filter.PropMinPrice
            this.filter.PropMaxPrice = this.filter.PropMaxPrice
            this.filter.PropExtras = this.filter.PropExtras
            this.filter.PropRooms = this.filter.PropRooms
        },
        filterRating(filter){
            this.filter.PropName = this.filter.PropName
            this.filter.PropStars = this.filter.PropStars
            this.filter.PropRating = filter.PropRating
            this.filter.PropMinPrice = this.filter.PropMinPrice
            this.filter.PropMaxPrice = this.filter.PropMaxPrice
            this.filter.PropExtras = this.filter.PropExtras
            this.filter.PropRooms = this.filter.PropRooms
        },
        filterPrice(filter){
            this.filter.PropName = this.filter.PropName
            this.filter.PropStars = this.filter.PropStars
            this.filter.PropRating = this.filter.PropRating
            this.filter.PropMinPrice = filter.PropMinPrice
            this.filter.PropMaxPrice = filter.PropMaxPrice
            this.filter.PropExtras = this.filter.PropExtras
            this.filter.PropRooms = this.filter.PropRooms
        },
        filterExtras(filter){
            this.filter.PropName = this.filter.PropName
            this.filter.PropStars = this.filter.PropStars
            this.filter.PropRating = this.filter.PropRating
            this.filter.PropMinPrice = this.filter.PropMinPrice
            this.filter.PropMaxPrice = this.filter.PropMaxPrice
            this.filter.PropExtras = filter.PropExtras
            this.filter.PropRooms = this.filter.PropRooms
        },
        filterRooms(filter){
            this.filter.PropName = this.filter.PropName
            this.filter.PropStars = this.filter.PropStars
            this.filter.PropRating = this.filter.PropRating
            this.filter.PropMinPrice = this.filter.PropMinPrice
            this.filter.PropMaxPrice = this.filter.PropMaxPrice
            this.filter.PropExtras = this.filter.PropExtras
            this.filter.PropRooms = filter.PropRooms
        }
    },
    data() {
        return{
            filter: {
                PropName: '',
                PropStars: 5,
                PropRating: 0,
                PropMinPrice: 500,
                PropMaxPrice: 10000,
                PropExtras: [],
                PropRooms: [],
            },
            getAccomodations
        }
    }
}
</script>