<template>
    <div :key="componentkey" class="container1" style="padding-top:10px" >
        <div class="bg-green-1 shadow-md" style=" width:100% ; padding-left:20px">
            <h2 class="header bg-green-2">My Bookings</h2>
            <router-link to="/MyPage" class="myButton bg-green-500 hover:bg-green-700 py-3 px-4 rounded-full shadow-xl" style="width:150px">My Profile</router-link>
            <router-link to="/MyFavorites" class="myButton bg-green-500 hover:bg-green-700 py-3 px-4 rounded-full shadow-xl" style="width:150px">My Favorites</router-link>
        </div>
        
        <div class="bg-green-2" style="width:98%; margin:1%; display:inline-block">
    <table>
        <tr class="bg-green-1">
            <th class="headerElements">Booking Id</th>
            <th class="headerElements">Accommodation</th>
            <th class="headerElements">Adults</th>
            <th class="headerElements">Cildren</th>
            <th class="headerElements">Check-in Date</th>
            <th class="headerElements">Check-out Date</th>
            <th class="headerElements">Booking Date</th>
            <th class="headerElements">Payment Date</th>
            <th class="headerElements">Cancellation Date</th>
            <th class="headerElements">Rating</th>
            <th class="headerElements"></th>
            <th class="headerElements">Cancel Booking</th>
        </tr>

        <tr v-if="!Bookings.length">
            <th class="bookingElements">
                No Bookings Made
            </th>
        </tr>

        <tr v-else v-for="Booking in Bookings" :key="Booking.id">
                <td class="bookingElements">{{Booking.id}}</td>
                <td class="bookingElements">{{Booking.accomodationId}}</td>
                <td class="bookingElements">{{Booking.nbrOfAdults}}</td>
                <td class="bookingElements">{{Booking.nbrOfChildren}}</td>
                <td class="bookingElements">{{Booking.checkInDate}}</td>
                <td class="bookingElements">{{Booking.checkOutDate}}</td>
                <td class="bookingElements">{{Booking.bookingDate}}</td>
                <td class="bookingElements">{{Booking.paymentDate}}</td>
                <td v-if="Booking.cancellationDate != null" style="background: #FFCCCB" class="bookingElements">{{Booking.cancellationDate}}</td>
                <td v-if="Booking.cancellationDate == null" class="bookingElements">{{Booking.cancellationDate}}</td>
                <td v-if="Booking.checkOutDate < currentDateTime() && Booking.cancellationDate == null" class="bookingElements">
                    <select v-model="rate" @click="setRating(Booking.accomodationId)"
                    >
                    <option :value="1">1</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                    <option value="4">4</option>
                    <option value="5">5</option>
                    <option value="6">6</option>
                    <option value="7">7</option>
                    <option value="8">8</option>
                    <option value="9">9</option>
                    <option value="10">10</option>
                    </select></td>
                    <td v-else class="bookingElements"></td> 
                <td class="bookingElements"><button v-if="Booking.cancellationDate == null && Booking.checkOutDate > currentDateTime()" class="editButton">Edit</button></td>
            <td class="bookingElements"><CancelButton v-if="Booking.cancellationDate == null && Booking.checkOutDate > currentDateTime()" :bookingId="Booking.id"/></td>
            
        </tr>
    </table> 
        </div> 
    </div>
</template>


<script>
import Booking from '/src/components/pages/Booking.vue'
import MyPage from '/src/components/pages/MyPage.vue'
import CancelButton from '/src/components/CancelBookingButton.vue'
import Mixins from '/src/mixins.js'


export default {
    
    mixins:[Mixins],

    data(){
        return{
            componentkey: 0,
            rate: null,
        };
    },

    mounted(){
        this.SetUserBookings();
    },
    components:{
        Booking,
        MyPage,
        CancelButton,
    },

    computed:{
        GetUserId(){
            return this.$store.state.userId;
        },
        Bookings(){
            return this.$store.state.userBookings;
        }
    },

    methods:{
        async SetUserBookings(){
            let response = await fetch('https://localhost:44323/api/Booking?userId=' + this.GetUserId);
            let bookings = await response.json();
            this.$store.commit('setUserBookings', bookings);

        },
        setRating(Id){
            var ratingObject = {
                accomodationId: Id,
                userId: this.$store.state.userId,
                rating: this.rate
            }
            console.log(JSON.stringify(ratingObject))
            this.sendRating(ratingObject)
            

        },
        async sendRating(ratingObject){
            await fetch('https://localhost:44323​/api​/Accomodations​/UpdateRating', {
                method: 'post',
                headers: {'Content-Type': 'application/json'},
                body: JSON.stringify(ratingObject)
            });
        }
        
    },
    

}
</script>

<style>

</style>