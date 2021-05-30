<template>
    <div class="flex flex-wrap overflow-hidden  border-2 rounded-md border-black shadow-md p-4 bg-green-1">

        <div class="w-full overflow-hidden">
            <h2 class="text-xl text-green-6">Room Details</h2>
        </div>

        <div class="w-full overflow-hidden border-2 rounded-md border-gray-300 mb-2" v-for="(rooms, index) in roomDetails.roomInfo" :key="rooms.id">
            
            <div class="w-full overflow-hidden">
                <DeleteButton class="float-right" @click="deleteRoom(index)" />
                <h1 class="ml-2"><b>Room {{ index + 1 }}</b></h1>
            </div>
            
            <div class="w-full overflow-hidden ml-2">
                <h1>{{ rooms.roomType.name }} - {{ rooms.nbrOfGuests }} bed(s).</h1>
                <h1>{{ rooms.price }}€ / night</h1>
                <h1 v-if="booking.travellersChildren">{{ booking.travellersAdults }} Adult(s) + {{ booking.travellersChildren }} Child(ren)</h1>
                <h1 v-else>{{ booking.travellersAdults }} Adult(s)</h1>
                <h1>Check-in: {{ booking.checkIn }}</h1>
                <h1>Check-out: {{ booking.checkOut }}</h1>
                <h1>Staying {{ nbrOfNights }} nights</h1>
            </div>
        </div>

    </div>
</template>

<script>
import DeleteButton from '/src/components/bookings/elements/deleteBtn.vue'

export default {

    components:{
        DeleteButton
    },

    data: function () {
        return {
            booking: this.roomDetails.bookingInfo,
        }
    },

    props: {
        roomDetails: {
            type: Object,
            required: true,
        }
    },

    methods: {
        incrementIndex: function (index) {
            return index + 1
        },

        deleteRoom: function(index){
            this.roomDetails.roomInfo.splice(index, 1);
        },
        setNbrOfNights(payload) {
            this.$store.commit("setNbrOfNights", payload);
        },
    },
    computed: {
        nbrOfNights(){
            var date1 = new Date(this.booking.checkIn);
            var date2 = new Date(this.booking.checkOut);
            var dateDifference = date2 - date1;
            var daysBetween = dateDifference / (1000 * 3600 * 24);
            this.setNbrOfNights(daysBetween)
            return daysBetween
        },
    }
}
</script>