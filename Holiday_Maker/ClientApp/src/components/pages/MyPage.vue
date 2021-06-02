<template>
    <div class="container1" style="padding-top:10px">
        <div class="bg-green-1 shadow-md" style="width:100%; border-radius:7px">
            <h2 class="header bg-green-2">My Profile</h2>
            <router-link to="/MyBookings" class="myButton bg-green-500 hover:bg-green-700 py-3 px-4 rounded-full shadow-xl" style="width:150px">My Bookings</router-link>
            <router-link to="/MyFavorites" class="myButton bg-green-500 hover:bg-green-700 py-3 px-4 rounded-full shadow-xl" style="width:150px">My Favorites</router-link>
         </div>
        
        <div class="bg-green-2" style="width:48%; margin:1%; display:inline-block">
            <table style="width:100%">
                <tr class="bg-green-1">
                    <th class="headerElements">First name</th>
                    <th class="headerElements">Last name</th>
                </tr>
                <tr>
                    <td class="bookingElements">{{GetUser.firstName}}</td>
                    <td class="bookingElements">{{GetUser.lastName}}</td>
                </tr>
            </table>
            <table style="width:100%">
                <tr class="bg-green-1">
                    <th class="headerElements">E-mail</th>
                </tr>
                <tr>
                    <td class="bookingElements">{{GetUser.email}}</td>
                </tr>
            </table>

            <br/>

            <table style="width:100%">
                <tr class="bg-green-1">
                    <th class="headerElements">Address</th>
                    <th class="headerElements">Zip code</th>
                </tr>
                <tr>
                    <td class="bookingElements">{{GetUser.streetAddress}}</td>
                    <td class="bookingElements">{{GetUser.zipCode}}</td>
                </tr>
                <tr class="bg-green-1">
                    <th class="headerElements">Country</th>
                    <th class="headerElements">City</th>
                </tr>
                <tr>
                    <td class="bookingElements">{{GetUser.country}}</td>
                    <td class="bookingElements">{{GetUser.city}}</td>
                </tr>
            </table>
            <table style="width:100%">
                <tr>
                    <th class="bg-green-1">
                        <button class="bg-gray-500 hover:bg-red-500 text-white font-bold py-2 px-4 rounded-full shadow-xl myButton">Edit</button>
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
                    <td class="bookingElements">{{GetMemberType}}</td>
                    <td class="bookingElements">{{GetUser.memberPoints}}</td>
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
                        <RemoveUserButton/>
                    </th>
                </tr>
            </table>
        </div>
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