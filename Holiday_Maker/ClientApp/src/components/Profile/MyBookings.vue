<template>

    <div :key="componentkey" class="container1" style="padding-top:10px" >
        <div class="bg-green-1 shadow-md op90" style="width:100%; border-radius:7px">
            <h2 class="header bg-green-2">My Bookings</h2>
            <router-link to="/MyPage" class="myButton bg-green-500 hover:bg-green-700 py-3 px-4 rounded-full shadow-xl" style="width:150px">My Profile</router-link>
            <router-link to="/MyFavorites" class="myButton bg-green-500 hover:bg-green-700 py-3 px-4 rounded-full shadow-xl" style="width:150px">My Favorites</router-link>
        </div>
        
        <div class="bg-green-2 op80" style="width:98%; margin:1%; display:inline-block">
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
                <td v-if="this.getAccomodationName(Booking.accomodationId) != null" class="bookingElements">{{this.getAccomodationName(Booking.accomodationId)}}</td>
                <td v-else class="bookingElements">{{Booking.accomodationId}}</td>
                <td class="bookingElements">{{Booking.nbrOfAdults}}</td>
                <td class="bookingElements">{{Booking.nbrOfChildren}}</td>
                <td class="bookingElements">{{Booking.checkInDate}}</td>
                <td class="bookingElements">{{Booking.checkOutDate}}</td>
                <td class="bookingElements">{{Booking.bookingDate}}</td>
                <td class="bookingElements">{{Booking.paymentDate}}</td>
                <td v-if="Booking.cancellationDate != null" style="background: #FFCCCB" class="bookingElements">{{Booking.cancellationDate}}</td>
                <td v-if="Booking.cancellationDate == null" class="bookingElements">{{Booking.cancellationDate}}</td>
                <td v-if="Booking.checkOutDate < currentDateTime() && Booking.cancellationDate == null" class="bookingElements">
                    <HotelBookingRating :id="Booking.accomodationId"/>
                </td>
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
import CancelButton from '/src/components/Profile/CancelBookingButton.vue'
import Mixins from '/src/mixins.js'
import HotelBookingRating from '/src/components/Profile/HotelBookingRating.vue'


export default {
    
    mixins:[Mixins],

    data(){
        return{
            componentkey: 0,
        };
    },

    mounted(){
        this.SetUserBookings();
    },
    components:{
        Booking,
        MyPage,
        CancelButton,
        HotelBookingRating
    },

    computed:{
        GetUserId(){
            return this.$store.state.userId;
        },
        Bookings(){
            return this.$store.state.userBookings;
        },
        Accomodations(){
            return this.$store.state.accomodations;
        }
    },

    methods:{
        async SetUserBookings(){
            let response = await fetch('https://localhost:44323/api/Booking?userId=' + this.GetUserId);
            let bookings = await response.json();
            this.$store.commit('setUserBookings', bookings);
        },
        getAccomodationName(id){
            let accomodation = this.Accomodations.filter(a => (a.id == id) == true)
            if(accomodation != ''){
                return accomodation[0].name
            }
            return null
        }
    },
}
</script>
