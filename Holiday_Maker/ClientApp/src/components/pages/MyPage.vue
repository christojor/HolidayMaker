<template>
    <h2 class="header bg-green-2" style="width:190px; padding-left:35px">My Profile</h2>
        <br><br>
        <table>
        <tr class="bg-green-1">
            <th class="headerElements">E-mail</th>
            <th class="headerElements">First name</th>
            <th class="headerElements">Last name</th>
            <th class="headerElements">Street address</th>
            <th class="headerElements">Zip code</th>
            <th class="headerElements">City</th>
            <th class="headerElements">Country</th>
            <th class="headerElements">Member type</th>
            <th class="headerElements">Member points</th>
            <th class="headerElements">Credit card</th>
        </tr>
        <tr>
            <td class="bookingElements">User e-mail</td>
            <td class="bookingElements">Admin</td>
            <td class="bookingElements">Adminsson</td>
            <td class="bookingElements">Adminstreet 12</td>
            <td class="bookingElements">12345</td>
            <td class="bookingElements">AdminCity</td>
            <td class="bookingElements">Adminlandet</td>
            <td class="bookingElements">2</td>
            <td class="bookingElements">725</td>
            <td class="bookingElements"></td>
            <td><button class="editButton">Edit</button></td>
        </tr>
    </table> 
    <br>
    <div class="container2 bg-green-1 shadow-md" style="height:70px; width:190px; padding-left:20px">
        <router-link to="/MyBookings" class="myButton bg-green-500 hover:bg-green-700 py-3 px-4 rounded-full shadow-xl" style="width:150px">My Bookings</router-link>
    </div>

    <div>
        <article v-for="user in users" :key="user.id">
            <h2>User name</h2>
            <h2>{{ user.Username }}</h2>
        </article>
    </div>
   
</template>

<script>
export default {
    computed:{
        users(){
            return this.$store.state.users
        }
    }
}
</script>

