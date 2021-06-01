<template>
    <div :class="{show:Toggle}">
        <button @click="approveCancellation" class="mt-6 bg-gray-500 hover:bg-red-500 text-white font-bold py-2 px-4 rounded-full shadow-xl">Cancel Booking</button>
        <br>
    </div>
    <div :class="{show:!Toggle}">
        <button @click="cancelBooking" class="mt-6 bg-gray-500 hover:bg-red-500 text-white font-bold py-2 px-4 rounded-full shadow-xl">Yes</button>
        <button @click="approveCancellation" class="mt-6 bg-gray-500 hover:bg-green-500 text-white font-bold py-2 px-4 rounded-full shadow-xl">No</button>
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

    props:{
        bookingId: null
    },

    methods:{
        async cancelBooking(){
            let response = await fetch('https://localhost:44323/api/Booking/CancelBooking/' + this.bookingId ,{
                method:'put',
            })
            if(response)
            {
                this.Toggle = true;
                return "The booking have been cancelled!"
            } 
        },
        approveCancellation(){
            if(this.Toggle){
                this.Toggle = false;
            }else{
                this.Toggle = true;
            }
        }
    },
}
</script>