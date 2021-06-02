<template>
    <div class="container1" style="padding-top:10px">
        <div class="bg-green-1 shadow-md" style=" width:100% ; padding-left:20px">
            <h2 class="header bg-green-2">My Profile</h2>
            <router-link to="/MyBookings" class="myButton bg-green-500 hover:bg-green-700 py-3 px-4 rounded-full shadow-xl" style="width:150px">My Bookings</router-link>
        </div>
        
        <div class="bg-green-2" style="width:48%; margin:1%; display:inline-block">
            <table style="width:100%">
                <tr class="bg-green-1">
                    <th class="headerElements">First name</th>
                    <th class="headerElements">Last name</th>
                </tr>
                <tr>
                    <td class="bookingElements">{{this.$store.state.user.firstName}}</td>
                    <td class="bookingElements">{{this.$store.state.user.lastName}}</td>
                </tr>
            </table>
            <table style="width:100%">
                <tr class="bg-green-1">
                    <th class="headerElements">E-mail</th>
                </tr>
                <tr>
                    <td class="bookingElements">{{this.$store.state.user.email}}</td>
                </tr>
            </table>

            <br/>

            <table style="width:100%">
                <tr class="bg-green-1">
                    <th class="headerElements">Address</th>
                    <th class="headerElements">Zip code</th>
                </tr>
                <tr>
                    <td class="bookingElements">{{this.$store.state.user.streetAddress}}</td>
                    <td class="bookingElements">{{this.$store.state.user.zipCode}}</td>
                </tr>
                <tr class="bg-green-1">
                    <th class="headerElements">Country</th>
                    <th class="headerElements">City</th>
                </tr>
                <tr>
                    <td class="bookingElements">{{this.$store.state.user.country}}</td>
                    <td class="bookingElements">{{this.$store.state.user.city}}</td>
                </tr>
            </table>
            <table style="width:100%">
                <tr>
                    <th class="bg-green-1">
                        <button class="headerElements editButton">Edit</button>
                    </th>
                </tr>
            </table>
        </div>

        <div class="bg-green-2" style="width:48%; margin:1%; display:inline-block">
            <table style="width:100%">
                <tr class="bg-green-1">
                    <th class="headerElements">Member Type</th>
                    <th class="headerElements">Member Points</th>
                </tr>
                <tr>
                    <td v-if="this.$store.state.user.memberTypeId==1" class="bookingElements">Standard</td>
                    <td v-if="this.$store.state.user.memberTypeId==2" class="bookingElements">Premium</td>
                    <td class="bookingElements">{{this.$store.state.user.memberPoints}}</td>
                </tr>
            </table>

            <table style="width:100%">
                <tr class="bg-green-1">
                    <th class="headerElements">Credit Card Details</th>
                </tr>
                <tr>
                    <td class="bookingElements">You Poor</td>
                </tr>
            </table>

            <br/>
            
            <table style="width:100%">
                <tr>
                    <th class="bg-green-1">
                        <button class="headerElements editButton">Remove Account</button>
                    </th>
                </tr>
            </table>
        </div>
    </div>   
</template>