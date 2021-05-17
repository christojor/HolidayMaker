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
            <HotelList/>
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
        },
        filterList(filter){
            this.$store.commit("updateFilter", filter)
        }
    },
    data() {
        return{
            filter: {
                PropName: '',
                PropStars: 5,
                PropRating: 0,
                PropMinPrice: 50,
                PropMaxPrice: 3000,
                PropExtras: [],
                PropAmenities: [],
                PropRooms: [],
            }
        }
    },
    created() {
    this.$store.dispatch("getAccomodations");
  },
}
</script>