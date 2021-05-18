<template>
    <form @submit.prevent="handleSubmit" style="text-align:right" :class="{show : toggle}">
        <h1 class="form-head">Log in</h1>

        <input v-if="error != ''" class="error-box" v-model="error"> <br/>

        <label for="Email" style="font-size:20px;">Email:</label>
        <input type="text" class="form-input" id="Email" v-model="Email"> <br/>

        <label for="Password" style="font-size:20px">Password:</label>
        <input type="text" class="form-input" id="Password" v-model="Pwd"> <br/>

        <button class="form-button bg-green-5">Log in</button>
        
        <p style="text-align:left">Don't have an account?</p>
    </form>
</template>

<script>
export default {
    props:{
        toggle: Boolean
    },
    data(){
        return{
            Name: '',
            Email: '',
            Address: '',
            Pwd: '',
            Pwd2: '',
            error: '',
        }
    },
    methods:{
        handleSubmit(){
            this.error = ''
            
            if(this.Pwd != 'Real Password'){
                this.error = "Email or password incorrect"
            }            
        }
    }
}
</script>