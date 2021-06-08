<template>
    <div :class="{show:Toggle}">
        <button @click="approveRemoval" class="bg-gray-500 hover:bg-red-500 text-white font-bold py-2 px-4 rounded-full shadow-xl myButton">Remove User</button>
        <br>
    </div>
    <div :class="{show:!Toggle}">
        <button @click="removeUser" class="mt-6 bg-gray-500 hover:bg-green-500 text-white font-bold py-2 px-4 rounded-full shadow-xl">Yes</button>
        <button @click="approveRemoval" class="mt-6 bg-gray-500 hover:bg-red-500 text-white font-bold py-2 px-4 rounded-full shadow-xl">No</button>
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
        getUserId(){
            return this.$store.state.userId;
        }
    },
    methods:{
        async removeUser(){
            let response = await fetch('https://localhost:44323/api/User/' + this.getUserId,{
                method:'delete',
            })
            if(response)
            {
                this.$router.push('/UserRemoval');
                localStorage.clear();
                this.$store.state.isLoggedIn = false;
                this.$store.state.userId = 0;
            } 
        },
        approveRemoval(){
            if(this.Toggle){
                this.Toggle = false;
            }else{
                this.Toggle = true;
            }
        }
    },
}
</script>