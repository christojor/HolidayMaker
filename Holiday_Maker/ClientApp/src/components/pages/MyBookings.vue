<template>
    <h2 class="header bg-green-2" style="width:190px; padding-left:35px">My Bookings</h2>
    <br><br>
    <table>
        <tr class="bg-green-1">
            <th class="headerElements">BookingId</th>
            <th class="headerElements">Accommodation</th>
            <th class="headerElements">Check in Date</th>
            <th class="headerElements">Check out Date</th>
            <th class="headerElements">Price</th>
        </tr>
        <tr>
            <td class="bookingElements">1234</td>
            <td class="bookingElements">Hotel</td>
            <td class="bookingElements">Today</td>
            <td class="bookingElements">Tomorrow</td>
            <td class="bookingElements">1000</td>
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
    components:{
        Booking,
        MyPage,
    },
}
</script>

<style>

</style>