<template>
    <div class="flex flex-wrap overflow-hidden  border-2 rounded-md border-black shadow-md p-4 bg-green-1">

        <div class="w-full overflow-hidden">
            <h2 class="text-xl text-green-6">Room Details</h2>
        </div>

        <div class="w-full overflow-hidden border-2 rounded-md border-gray-300 mb-2" v-for="(room, index) in roomDetails.roomInfo" :key="room.id">
            <div class="flex flex-wrap overflow-hidden">
                <div class="w-1/2 overflow-hidden">
                    <h1 class="ml-2"><b>Room {{ index + 1 }}</b></h1>
                </div>
                
                <div class="w-1/2 overflow-hidden" v-if="roomDetails.roomInfo.length > 1 && guestsAtRoomCapacity()">
                    <DeleteButton class="float-right" @click="deleteRoom(index)" />
                </div>
            </div>
            
            <div class="w-full overflow-hidden ml-2">
                <h1>{{ room.roomType.name }} - {{ room.nbrOfGuests }} bed(s).</h1>
                <h1>{{ room.price }}€ / night</h1>
                <h1 v-if="booking.travellersChildren">{{ booking.travellersAdults }} Adult(s) + {{ booking.travellersChildren }} Child(ren)</h1>
                <h1 v-else>{{ booking.travellersAdults }} Adult(s)</h1>
                <h1>Check-in: {{ booking.checkIn }}</h1>
                <h1>Check-out: {{ booking.checkOut }}</h1>
                <h1>Staying {{ nbrOfNights }} nights</h1>
                <h1>Extras: </h1>
                <h1 v-for="extra in roomExtras(room.id)" :key="extra">{{extra.name}}</h1>
            </div> 
        </div>
    </div>
</template>

<script>
import DeleteButton from '/src/components/bookings/elements/deleteBtn.vue'

export default {

    props: {
        roomDetails: {
            type: Object,
            required: true,
        }
    },

    components:{
        DeleteButton
    },

    data() {
        return {
            booking: this.roomDetails.bookingInfo,
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
        guestsAtRoomCapacity(){
            if ((this.nbrOfGuests + this.lowestRoomCapacity) <= this.totalRoomCapacity){
                return true
            }
            else{
                return false
            }
        },
        roomExtras(id){
            let roomExtras = this.selectedExtras.filter(extra => (extra.roomId == id) == true)
            let extrasPrice = {price: 0, roomId: id}
            roomExtras.forEach(extra => extrasPrice.price += extra.price)
            this.$store.commit('updateExtrasPrice', extrasPrice)
            return roomExtras
        }
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
        nbrOfGuests(){
            let totalGuests = parseInt(this.roomDetails.bookingInfo.travellersAdults) + parseInt(this.roomDetails.bookingInfo.travellersChildren)
            return totalGuests;
        },
        totalRoomCapacity(){
            let totalCapacity = null

            this.roomDetails.roomInfo.forEach(room => {
                    totalCapacity += parseInt(room.nbrOfGuests)
            });
            return totalCapacity;
        },
        lowestRoomCapacity(){
            let lowestRoomCapacity = parseInt(this.roomDetails.roomInfo[0].nbrOfGuests);

            //  (parseInt(this.roomDetails.roomInfo[0].maxNbrOfGuests) + parseInt(this.roomDetails.roomInfo[0].nbrOfExtraBeds)); - Save for when choosing extras is implemented

            this.roomDetails.roomInfo.forEach(room => {
                if (lowestRoomCapacity > parseInt(room.nbrOfGuests)){
                    lowestRoomCapacity = parseInt(room.nbrOfGuests)
                }
            });

            return lowestRoomCapacity;
        },
        selectedExtras(){
            return this.$store.state.selectedExtras
        }
    }
}
</script>