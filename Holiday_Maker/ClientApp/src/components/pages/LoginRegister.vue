<template>
    <div class="container1">
        <div class="container2 bg-green-1 shadow-md">
            <Info/>
        </div>

        <div class="container3 bg-green-1 shadow-md">
            <Login :toggle="!toggle"/>
            <Register :toggle="toggle"/>

            <a v-if="!toggle == false" @click="toggleForm" class="text-green-500 hover:text-green-800 hover:underline" href="#">Register</a>
            <a v-else @click="toggleForm" class="text-green-500 hover:text-green-800 hover:underline" href="#">Login</a>
        </div>
        <div class="container2 bg-green-1 shadow-md" style="height:70px">
            <router-link to="/MyPage" class="myButton bg-green-500 hover:bg-green-700 py-3 rounded-full shadow-xl" style="width:70%">My Page</router-link>
        </div>
    </div>
</template>

<script>
import Login from '/src/components/logins/Login.vue'
import Register from '/src/components/logins/Register.vue'
import Info from '/src/components/logins/Info.vue'
import MyPage from '/src/components/pages/MyPage.vue'

export default({
    components:{
        Login,
        Info,
        Register,
        MyPage,
    },
    data(){
        return{
        toggle: true
        }
    },
    methods:{
        toggleForm(){
            this.toggle = !this.toggle
        }
    }
})
</script>
