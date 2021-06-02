<template>
    <h2 class="header bg-green-2" style="width:190px; padding-left:35px">My Bookings</h2>
    <br><br>
    <table>
        <tr class="bg-green-1">
            <th class="headerElements">Booking Id</th>
            <th class="headerElements">Accommodation</th>
            <th class="headerElements">Number of adults</th>
            <th class="headerElements">Number of children</th>
            <th class="headerElements">Check in Date</th>
            <th class="headerElements">Check out Date</th>
            <th class="headerElements">Booking date</th>
            <th class="headerElements">Payment date</th>
            <th class="headerElements">Cancellation Date</th>
        </tr>
        <tr :v-for="booking in testbooking" :key="booking">
            <td class="bookingElements">{{ booking.id }}</td>
            <td class="bookingElements">Hotel</td>
            <td class="bookingElements">1</td>
            <td class="bookingElements">1</td>
            <td class="bookingElements">Today</td>
            <td class="bookingElements">Tomorrow</td>
            <td class="bookingElements">Yesterday</td>
            <td class="bookingElements">Yesterday</td>
            <td class="bookingElements"></td>
            <td><button class="editButton">Edit</button></td>
            <td><button class="editButton">Cancel</button></td>
        </tr>
    </table>  
    <!--<br>
        <div class="container2 bg-green-1 shadow-md" style="height:70px; width:190px; padding-left:20px">
            <router-link to="/MyPage" class="myButton bg-green-500 hover:bg-green-700 py-3 px-4 rounded-full shadow-xl" style="width:150px">My Profile</router-link>
        </div>-->
</template>


<script>
import Booking from '/src/components/pages/Booking.vue'
import MyPage from '/src/components/pages/MyPage.vue'

export default {
    
    mounted(){
        this.GetBookingsByUser();
        console.log(this.GetBookingsByUser());
    },

    data(){
        return {
            testbooking: this.GetBookingsByUser(),
        }
    },

    components:{
        Booking,
        MyPage,
    },

    computed:{
        GetUserId(){
            return this.$store.state.userId;
        },
        Bookings(){
            return this.GetBookingsByUser();
        }
    },

    methods:{
        async GetBookingsByUser(){
            var response = await fetch('https://localhost:44323/api/Booking?userId=' + this.GetUserId);
            let bookings = await response.json();
            return bookings;
        }
    }
}
</script>

<style>

</style>