<template>
    <h2 class="header bg-green-2">My Bookings</h2>
    <table>
        <tr class="tableHeader bg-green-1">
            <th class="headerElements">BookingId</th>
            <th class="headerElements">Accommodation</th>
            <th class="headerElements">Check in Date</th>
            <th class="headerElements">Check out Date</th>
            <th class="headerElements">Price</th>
        </tr>
        <tr class="bookingsList">
            <td class="bookingElements">1234</td>
            <td class="bookingElements">Hotel</td>
            <td class="bookingElements">Today</td>
            <td class="bookingElements">Tomorrow</td>
            <td class="bookingElements">1000</td>
            <td><button class="bg-green-2" style="padding-left:15px; padding-right:10px; font-weight:bold; text-align:center">Edit</button></td>
            <td><button class="bg-green-3" style="padding-left:10px; padding-right:10px; font-weight:bold">Cancel</button></td>
        </tr>
    </table>  
</template>


<script>
import Booking from '/src/components/pages/Booking.vue'

export default {
    components:{
        Booking,
    },
}
</script>

<style>

</style>