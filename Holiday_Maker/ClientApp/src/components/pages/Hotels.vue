<template>
    <div class="container1">

        <div class="container2 shadow-md bg-green-1">
            <Name @filter-search="filterName"/>
            <StarRating @filter-search="filterStars"/>
            <UserRating @filter-search="filterRating"/>
            <Price @filter-search="filterPrice"/>
            <Extras @filter-search="filterExtras"/>
            <Amenities @filter-search="filterAmenities"/>
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
import Themes from "/src/components/Themes.vue"
import Amenities from "/src/components/SearchAmenities.vue"
import RoomType from "/src/components/SearchRoomType.vue"

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
        Amenities,
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
            this.filter.PropAmenities = this.filter.PropAmenities
            this.filter.PropRooms = this.filter.PropRooms
        },
        filterStars(filter){
            this.filter.PropName = this.filter.PropName
            this.filter.PropStars = filter.PropStars
            this.filter.PropRating = this.filter.PropRating
            this.filter.PropMinPrice = this.filter.PropMinPrice
            this.filter.PropMaxPrice = this.filter.PropMaxPrice
            this.filter.PropExtras = this.filter.PropExtras
            this.filter.PropAmenities = this.filter.PropAmenities
            this.filter.PropRooms = this.filter.PropRooms
        },
        filterRating(filter){
            this.filter.PropName = this.filter.PropName
            this.filter.PropStars = this.filter.PropStars
            this.filter.PropRating = filter.PropRating
            this.filter.PropMinPrice = this.filter.PropMinPrice
            this.filter.PropMaxPrice = this.filter.PropMaxPrice
            this.filter.PropExtras = this.filter.PropExtras
            this.filter.PropAmenities = this.filter.PropAmenities
            this.filter.PropRooms = this.filter.PropRooms
        },
        filterPrice(filter){
            this.filter.PropName = this.filter.PropName
            this.filter.PropStars = this.filter.PropStars
            this.filter.PropRating = this.filter.PropRating
            this.filter.PropMinPrice = filter.PropMinPrice
            this.filter.PropMaxPrice = filter.PropMaxPrice
            this.filter.PropExtras = this.filter.PropExtras
            this.filter.PropAmenities = this.filter.PropAmenities
            this.filter.PropRooms = this.filter.PropRooms
        },
        filterExtras(filter){
            this.filter.PropName = this.filter.PropName
            this.filter.PropStars = this.filter.PropStars
            this.filter.PropRating = this.filter.PropRating
            this.filter.PropMinPrice = this.filter.PropMinPrice
            this.filter.PropMaxPrice = this.filter.PropMaxPrice
            this.filter.PropExtras = filter.PropExtras
            this.filter.PropAmenities = this.filter.PropAmenities
            this.filter.PropRooms = this.filter.PropRooms
        },
        filterAmenities(filter){
            this.filter.PropName = this.filter.PropName
            this.filter.PropStars = this.filter.PropStars
            this.filter.PropRating = this.filter.PropRating
            this.filter.PropMinPrice = this.filter.PropMinPrice
            this.filter.PropMaxPrice = this.filter.PropMaxPrice
            this.filter.PropExtras = this.filter.PropExtras
            this.filter.PropAmenities = filter.PropAmenities
            this.filter.PropRooms = this.filter.PropRooms
        },
        filterRooms(filter){
            this.filter.PropName = this.filter.PropName
            this.filter.PropStars = this.filter.PropStars
            this.filter.PropRating = this.filter.PropRating
            this.filter.PropMinPrice = this.filter.PropMinPrice
            this.filter.PropMaxPrice = this.filter.PropMaxPrice
            this.filter.PropExtras = this.filter.PropExtras
            this.filter.PropAmenities = this.filter.PropAmenities
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
                PropAmenities: [],
                PropRooms: [],
            },
            getAccomodations
        }
    }
}
</script>