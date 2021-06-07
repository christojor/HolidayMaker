<template>
    <div class="container1 op90" style="padding-top:10px">
        <div class="bg-green-1 shadow-md op90" style="width:100%; border-radius:7px">
            <h2 class="header bg-green-2">My Favorites</h2>
            <router-link to="/MyBookings" class="myButton bg-green-500 hover:bg-green-700 py-3 px-4 rounded-full shadow-xl" style="width:150px">My Bookings</router-link>
            <router-link to="/MyPage" class="myButton bg-green-500 hover:bg-green-700 py-3 px-4 rounded-full shadow-xl" style="width:150px">My Profile</router-link>
        </div>

        <div class="container2 op80">

            <div class="favSideItem shadow-md bg-green-1">
                <h1 style="font-size:30px">Hotel Lists</h1>
                
                <h1>Sort By List</h1>

                <div v-for="group in groupList" :key="group">
                    <a style="cursor: pointer" class="hover:text-green-800 hover:underline" @click="SortListNames();SortList(group);">{{group}}</a>
                    <button class="bg-gray-500 hover:bg-red-500 text-white px-2 rounded-full shadow-xl" style="float:right; height:20px;">REMOVE</button><br/>
                </div>
                
                <a style="cursor: pointer" class="hover:text-green-800 hover:underline" @click="SortList('all')">Show All Hotels</a>
            </div>

            <div class="favSideItem shadow-md bg-green-1">
                <h1 style="font-size:30px">Favorite Hotels</h1>

                <h1 v-if="FavList != null">Number of hotels: </h1>
                <h2>{{AccomodationList.length}}</h2>
                <br/>

                <h1 v-if="FavList != null">Highest rated hotel: </h1>
                <h2 style="cursor: pointer" class="hover:text-green-800 hover:underline" @click="goToAccommodation(highestRatingId)">{{highestRating}}</h2>
                <br/>
                
                <h1 v-if="FavList != null">Most Liked hotel: </h1>
                <h2 style="cursor: pointer" class="hover:text-green-800 hover:underline" @click="goToAccommodation(mostLikedId)">{{mostLiked}}</h2>
                <br/>
                
                <h1 v-if="FavList != null">Closest to city: </h1>
                <h2 style="cursor: pointer" class="hover:text-green-800 hover:underline" @click="goToAccommodation(closestCityId)">{{closestCity}}</h2>
                <br/>
                
                <h1 v-if="FavList != null">Closest to beach: </h1>
                <h2 style="cursor: pointer" class="hover:text-green-800 hover:underline" @click="goToAccommodation(closestBeachId)">{{closestBeach}}</h2>
            </div>
        </div>

        <div class="container3 shadow-md bg-green-1">
            <div v-if="AccomodationList < 1" style="width:100%">
                <h1 style="text-align:center;font-size:30px">No Favorite Hotels</h1>
            </div>

            <div v-else>
                <div v-for="Accomodation in AccomodationList" :key="Accomodation" class="hotel-item shadow-md">

                    <img :src="Accomodation.imgSrc" alt="" class="hotel-item-img" @click="goToAccommodation(Accomodation.id)">
                    
                    <div class="hotel-item-desc">
                        <HotelDescription :accomodation="Accomodation"/>
                    </div>
                
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import HotelDescription from "/src/components/HotelDescription.vue";

export default{
    mounted(){
        this.SortListNames();

        this.AccomodationList = this.GetUserFavorites.accomodation;
        this.FavList = this.GetUserFavorites.userFavorite;
    },
    components:{
        HotelDescription
    },
    data() {
        return{
            AccomodationList: [],
            FavList: [],
            groupList: [],
        }
    },
    methods:{
        goToAccommodation(accommodationId) {
            this.$router.push({
                name: "Accommodation",
                params: { id: accommodationId },
            });
        },
        SortListNames(){
            this.AccomodationList = this.GetUserFavorites.accomodation;
            this.FavList = this.GetUserFavorites.userFavorite;

            this.groupList = []

            this.FavList.forEach(item => {if(!this.groupList.includes(item.groupName)){this.groupList.push(item.groupName)}})
        },
        SortList(group){
            if(group == 'all'){
                this.AccomodationList = this.GetUserFavorites.accomodation;
                return this.AccomodationList
            }
            
            this.AccomodationList = []

            this.FavList.forEach(item => {
            if(item.groupName == group){
                this.GetUserFavorites.accomodation.forEach(a => {
                if(a.id == item.accomodationId){    
                    this.AccomodationList.push(a)
                }})
            }})
        }
    },
    computed:{
        GetUserFavorites(){
            return this.$store.state.userFavorites;
        },
        highestRating(){
            let high = []
            this.AccomodationList.forEach(item => { high.push(item.starRating)
            });
            high = Math.max(...high)

            let highHotel = []
            this.AccomodationList.forEach(item => { 
                if(item.starRating == high && highHotel.length == 0)
                    highHotel.push(item.name)
            });

            return highHotel.toString()
        },
        highestRatingId(){
            let high = []
            this.AccomodationList.forEach(item => { high.push(item.starRating)
            });
            high = Math.max(...high)

            let highHotel = []
            this.AccomodationList.forEach(item => { 
                if(item.starRating == high && highHotel.length == 0)
                    highHotel.push(item.id)
            });

            return highHotel.toString()
        },
        mostLiked(){
            let high = []
            this.AccomodationList.forEach(item => { high.push(item.guestRating)
            });
            high = Math.max(...high)

            let highHotel = []
            this.AccomodationList.forEach(item => { 
                if(item.guestRating == high && highHotel.length == 0)
                    highHotel.push(item.name)
            });

            return highHotel.toString()
        },
        mostLikedId(){
            let high = []
            this.AccomodationList.forEach(item => { high.push(item.guestRating)
            });
            high = Math.max(...high)

            let highHotel = []
            this.AccomodationList.forEach(item => { 
                if(item.guestRating == high && highHotel.length == 0)
                    highHotel.push(item.id)
            });

            return highHotel.toString()
        },
        closestCity(){
            let low = []
            this.AccomodationList.forEach(item => { low.push(item.distanceToCenter)
            });
            low = Math.min(...low)

            let lowHotel = []
            this.AccomodationList.forEach(item => { 
                if(item.distanceToCenter == low && lowHotel.length == 0)
                    lowHotel.push(item.name)
            });

            return lowHotel.toString()
        },
        closestCityId(){
            let low = []
            this.AccomodationList.forEach(item => { low.push(item.distanceToCenter)
            });
            low = Math.min(...low)

            let lowHotel = []
            this.AccomodationList.forEach(item => { 
                if(item.distanceToCenter == low && lowHotel.length == 0)
                    lowHotel.push(item.id)
            });

            return lowHotel.toString()
        },
        closestBeach(){
            let low = []
            this.AccomodationList.forEach(item => { low.push(item.distanceToBeach)
            });
            low = Math.min(...low)

            let lowHotel = []
            this.AccomodationList.forEach(item => { 
                if(item.distanceToBeach == low && lowHotel.length == 0)
                    lowHotel.push(item.name)
            });

            return lowHotel.toString()
        },
        closestBeachId(){
            let low = []
            this.AccomodationList.forEach(item => { low.push(item.distanceToBeach)
            });
            low = Math.min(...low)

            let lowHotel = []
            this.AccomodationList.forEach(item => { 
                if(item.distanceToBeach == low && lowHotel.length == 0)
                    lowHotel.push(item.id)
            });

            return lowHotel.toString()
        }
    }
}
</script>

