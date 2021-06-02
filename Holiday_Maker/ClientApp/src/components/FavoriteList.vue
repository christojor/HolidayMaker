<template>
    <div class="container1">
        <div class="container2 shadow-md bg-green-1">
            <h1 style="font-size:30px">Favorite Hotels</h1>

            <button @click="getList">Load Hotels</button>

            <h1 v-if="FavList != null">Number of hotels: {{FavList.Length}}</h1>
        </div>

        <div class="container3 shadow-md bg-green-1">
            <div v-if="FavList < 1" style="width:100%">
                <h1 style="text-align:center;font-size:30px">No Favorite Hotels</h1>
            </div>

            <div v-else>
                <div v-for="Fav in FavList" :key="Fav" class="hotel-item shadow-md">

                    <img :src="Fav.imgSrc" alt="" class="hotel-item-img" @click="goToAccommodation(Fav.id)">
                    
                    <div class="hotel-item-desc">
                        <HotelDescription :accomodation="Fav"/>
                    </div>
                
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import HotelDescription from "/src/components/HotelDescription.vue";

export default{
    components:{
        HotelDescription
    },
    data() {
        return{
            userId: 19,
            FavList: null
        }
    },
    methods: {
        async getList(){
            let response = await fetch('https://localhost:44323/api/User/favorites?userId=' + this.userId);
            this.FavList = await response.json();
        }
    }
}
</script>

