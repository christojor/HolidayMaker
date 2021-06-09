<template>
    <div :class="{show:Toggle}">
        <button @click="approveCancellation" class="outline bg-gray-500 hover:bg-red-500 text-white font-bold py-2 px-4 rounded-full shadow-xl">Cancel</button>
        <br>
    </div>
    <div :class="{show:!Toggle}" style="width:150px">
        <button @click="cancelBooking" class="outline bg-gray-500 hover:bg-red-500 text-white font-bold py-2 px-4 rounded-full shadow-xl">Yes</button>
        <button @click="approveCancellation" class="outline bg-gray-500 hover:bg-green-500 text-white font-bold py-2 px-4 rounded-full shadow-xl">No</button>
        <br>
        Are you sure?
    </div>
</template>



<script>
export default {
    
    data(){
        return{
            Toggle: false,
        }
    },

    computed:{
        GetUserId(){
            return this.$store.state.userId;
        }
    },
    
    props:{
        bookingId: null
    },

    methods:{

        async SetUserBookings(){
            let response = await fetch('https://localhost:44323/api/Booking?userId=' + this.GetUserId);
            let bookings = await response.json();
            this.$store.commit('setUserBookings', bookings);
        },


        async cancelBooking(){
            let response = await fetch('https://localhost:44323/api/Booking/CancelBooking/' + this.bookingId ,{
                method:'put',
            })
            if(response)
            {
                this.Toggle = true;
                this.SetUserBookings();
            } 
        },
        approveCancellation(){
            if(this.Toggle){
                this.Toggle = false;
            }else{
                this.Toggle = true;
            }
        },
    },
}
</script>