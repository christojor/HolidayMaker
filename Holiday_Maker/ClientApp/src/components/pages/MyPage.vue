<template>
    <h2 class="header bg-green-2">My Page</h2>
        <table>
        <tr class="bg-green-1">
            <th class="headerElements">Title</th>
            <th class="headerElements">Name</th>
            <th class="headerElements">Address</th>
            <th class="headerElements">e-mail</th>
            <th class="headerElements">Phone number</th>
            <th class="headerElements">Member type</th>
        </tr>
        <tr>
            <td class="bookingElements">Mrs.</td>
            <td class="bookingElements">Diana Cross</td>
            <td class="bookingElements">1st Avenue</td>
            <td class="bookingElements">crisscross@loosypants.com</td>
            <td class="bookingElements">1564784321</td>
            <td class="bookingElements">Golden fever</td>
            <td><button class="editButton">Edit</button></td>
            <td><button class="editButton">Cancel</button></td>
        </tr>
    </table> 
    <div class="container2 bg-green-1 shadow-md" style="height:70px">
        <router-link to="/MyBookings" class="myButton bg-green-500 hover:bg-green-700 py-3 px-4 rounded-full shadow-xl">My Bookings</router-link>
    </div>
</template>