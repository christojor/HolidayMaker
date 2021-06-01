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
            <td class="bookingElements">{{GetUser.email}}</td>
            <td class="bookingElements">{{GetUser.firstName}}</td>
            <td class="bookingElements">{{GetUser.lastName}}</td>
            <td class="bookingElements">{{GetUser.streetAddress}}</td>
            <td class="bookingElements">{{GetUser.zipCode}}</td>
            <td class="bookingElements">{{GetUser.city}}</td>
            <td class="bookingElements">{{GetUser.country}}</td>
            <td class="bookingElements">{{GetMemberType}}</td>
            <td class="bookingElements">{{GetUser.memberPoints}}</td>
            <td class="bookingElements">{{GetUser.creditCard}}</td>
            <td><button class="editButton">Edit</button></td>
        </tr>
    </table> 
    <br>
    <RemoveUserButton/>
    <div class="container2 bg-green-1 shadow-md" style="height:70px; width:190px; padding-left:20px">
        <router-link to="/MyBookings" class="myButton bg-green-500 hover:bg-green-700 py-3 px-4 rounded-full shadow-xl" style="width:150px">My Bookings</router-link>
        
    </div>
</template>

<script>
import RemoveUserButton from '/src/components/RemoveUserButton.vue'
export default {
    components:{
        RemoveUserButton
    },
    computed:{
        GetUser(){
            return this.$store.state.user;
        },
        GetMemberType(){
            if(this.GetUser.memberTypeId == 1){
                return 'Standard';
            }else if(this.GetUser.memberTypeId == 2){
                return 'Premium';
            }
        }
    }
}
</script>