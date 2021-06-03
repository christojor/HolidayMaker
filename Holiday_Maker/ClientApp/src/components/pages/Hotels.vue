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
            <DistanceBeach @filter-search="filterBeach"/>
            <DistanceCity @filter-search="filterCity"/>
            <Wifi @filter-search="filterWifi"/>
        </div>

        <div class="container3 shadow-md bg-green-1" v-if="this.$store.state.accomodations != null">
            <HotelList/>
        </div>
        <div class="container3 shadow-md bg-green-1" v-else>
            <NoResults />
        </div>

    </div>
</template>

<script>
import HotelList from "/src/components/HotelList.vue"
import Name from "/src/components/filters/SearchProperty.vue"
import StarRating from "/src/components/filters/SearchStarRating.vue"
import UserRating from "/src/components/filters/SearchUserRating.vue"
import Price from "/src/components/filters/SearchPrice.vue"
import Extras from "/src/components/filters/SearchExtras.vue"
import Themes from "/src/components/Themes.vue"
import Amenities from "/src/components/filters/SearchAmenities.vue"
import RoomType from "/src/components/filters/SearchRoomType.vue"
import DistanceBeach from "/src/components/filters/SearchDistanceBeach.vue"
import DistanceCity from "/src/components/filters/SearchDistanceCity.vue"
import Wifi from "/src/components/filters/SearchWifi.vue"
import NoResults from "/src/components/pages/NoResults.vue"

export default{
    components: {
        HotelList,
        Name,
        StarRating,
        UserRating,
        Price,
        Themes,
        Extras,
        Amenities,
        RoomType,
        DistanceBeach,
        DistanceCity,
        Wifi,
        NoResults
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
            this.filter.DistanceBeach = this.filter.DistanceBeach
            this.filter.DistanceCity = this.filter.DistanceCity
            this.filter.PropWifi = this.filter.PropWifi

            this.filterList(this.filter)
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
            this.filter.DistanceBeach = this.filter.DistanceBeach
            this.filter.DistanceCity = this.filter.DistanceCity
            this.filter.PropWifi = this.filter.PropWifi

            this.filterList(this.filter)
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
            this.filter.DistanceBeach = this.filter.DistanceBeach
            this.filter.DistanceCity = this.filter.DistanceCity
            this.filter.PropWifi = this.filter.PropWifi

            this.filterList(this.filter)
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
            this.filter.DistanceBeach = this.filter.DistanceBeach
            this.filter.DistanceCity = this.filter.DistanceCity
            this.filter.PropWifi = this.filter.PropWifi

            this.filterList(this.filter)
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
            this.filter.DistanceBeach = this.filter.DistanceBeach
            this.filter.DistanceCity = this.filter.DistanceCity
            this.filter.PropWifi = this.filter.PropWifi

            this.filterList(this.filter)
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
            this.filter.DistanceBeach = this.filter.DistanceBeach
            this.filter.DistanceCity = this.filter.DistanceCity
            this.filter.PropWifi = this.filter.PropWifi

            this.filterList(this.filter)
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
            this.filter.DistanceBeach = this.filter.DistanceBeach
            this.filter.DistanceCity = this.filter.DistanceCity
            this.filter.PropWifi = this.filter.PropWifi

            this.filterList(this.filter)
        },
        filterBeach(filter){
            this.filter.PropName = this.filter.PropName
            this.filter.PropStars = this.filter.PropStars
            this.filter.PropRating = this.filter.PropRating
            this.filter.PropMinPrice = this.filter.PropMinPrice
            this.filter.PropMaxPrice = this.filter.PropMaxPrice
            this.filter.PropExtras = this.filter.PropExtras
            this.filter.PropAmenities = this.filter.PropAmenities
            this.filter.PropRooms = this.filter.PropRooms
            this.filter.DistanceBeach = filter.DistanceBeach
            this.filter.DistanceCity = this.filter.DistanceCity
            this.filter.PropWifi = this.filter.PropWifi

            this.filterList(this.filter)
        },
        filterCity(filter){
            this.filter.PropName = this.filter.PropName
            this.filter.PropStars = this.filter.PropStars
            this.filter.PropRating = this.filter.PropRating
            this.filter.PropMinPrice = this.filter.PropMinPrice
            this.filter.PropMaxPrice = this.filter.PropMaxPrice
            this.filter.PropExtras = this.filter.PropExtras
            this.filter.PropAmenities = this.filter.PropAmenities
            this.filter.PropRooms = this.filter.PropRooms
            this.filter.DistanceBeach = this.filter.DistanceBeach
            this.filter.DistanceCity = filter.DistanceCity
            this.filter.PropWifi = this.filter.PropWifi

            this.filterList(this.filter)
        },
        filterWifi(filter){
            this.filter.PropName = this.filter.PropName
            this.filter.PropStars = this.filter.PropStars
            this.filter.PropRating = this.filter.PropRating
            this.filter.PropMinPrice = this.filter.PropMinPrice
            this.filter.PropMaxPrice = this.filter.PropMaxPrice
            this.filter.PropExtras = this.filter.PropExtras
            this.filter.PropAmenities = this.filter.PropAmenities
            this.filter.PropRooms = this.filter.PropRooms
            this.filter.DistanceBeach = this.filter.DistanceBeach
            this.filter.DistanceCity = this.filter.DistanceCity
            this.filter.PropWifi = filter.PropWifi

            this.filterList(this.filter)
        },
        filterList(filter){
            this.$store.commit("updateFilter", filter)
        }
    },
    data() {
        return{
            filter: {
                PropName: '',
                PropStars: 1,
                PropRating: 0,
                PropMinPrice: 0,
                PropMaxPrice: 750,
                PropExtras: [],
                PropAmenities: [],
                PropRooms: [],
                DistanceBeach: 5000,
                DistanceCity: 5000,
                PropWifi: 0,
            }
        }
    },
}
</script>