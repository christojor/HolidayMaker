<template>
    <div class="container1" style="padding-top:10px">
        <div class="bg-green-1 shadow-md" style=" width:100% ; padding-left:20px">
            <h2 class="header bg-green-2">My Bookings</h2>
            <router-link to="/MyPage" class="myButton bg-green-500 hover:bg-green-700 py-3 px-4 rounded-full shadow-xl" style="width:150px">My Profile</router-link>
        </div>

        <div class="bg-green-2" style="width:98%; margin:1%;">
            <table style="width:100%">
                <tr class="bg-green-1">
                    <th class="headerElements">Booking Id</th>
                    <th class="headerElements">Accommodation</th>
                    <th class="headerElements">Adults</th>
                    <th class="headerElements">Children</th>
                    <th class="headerElements">Check-in Date</th>
                    <th class="headerElements">Check-out Date</th>
                    <th class="headerElements">Booking Date</th>
                    <th class="headerElements">Payment Date</th>
                    <th class="headerElements"></th>
                </tr>
                <tr>
                    <td class="bookingElements">423</td>
                    <td class="bookingElements">Hotel</td>
                    <td class="bookingElements">2</td>
                    <td class="bookingElements">1</td>
                    <td class="bookingElements">2021-02-02</td>
                    <td class="bookingElements">2021-02-03</td>
                    <td class="bookingElements">2021-01-12</td>
                    <td class="bookingElements">2021-01-12</td>
                
                    <th v-if="checkInDate >= currentDate" class="bg-green-1">
                        <button class="headerElements editButton">Cancel Booking</button>
                    </th>
                    <th v-else>
                        <h2 class="headerElements">Date Passed</h2>
                    </th>
                </tr>
            </table>
        </div>
    </div>
</template>