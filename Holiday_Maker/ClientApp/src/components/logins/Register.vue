<template>
    <form @submit.prevent="handleSubmit" style="text-align:right" :class="{show : toggle}">
        <h1 class="form-head">Register</h1>

        <input v-if="error != ''" class="error-box" v-model="error"> <br/>

        <label for="Name" style="font-size:20px;">Full name:</label>
        <input type="text" class="form-input" id="Name" v-model="Name"> <br/>

        <label for="Email" style="font-size:20px">Email:</label>
        <input type="text" class="form-input" id="Email" v-model="Email"> <br/>

        <label for="PhoneNumber" style="font-size:20px">Phone number:</label>
        <input type="number" class="form-input" id="PhoneNumber" v-model="PhoneNumber"> <br/>

        <label for="Address" style="font-size:20px">Address:</label>
        <input type="text" class="form-input" id="Address" v-model="Address"> <br/>

        <label for="ZipCode" style="font-size:20px">ZipCode:</label>
        <input type="text" class="form-input" id="ZipCode" v-model="ZipCode"> <br/>

        <label for="Town" style="font-size:20px">Town:</label>
        <input type="text" class="form-input" id="Town" v-model="Town"> <br/>

        <label for="Country" style="font-size:20px">Country:</label>
        <input type="text" class="form-input" id="Country" v-model="Country"> <br/>

        <label for="Password" style="font-size:20px">Password:</label>
        <input type="text" class="form-input" id="Password" v-model="Pwd"> <br/>

        <label for="Password2" style="font-size:20px">Repeat password:</label>
        <input type="text" class="form-input" id="Password2" v-model="Pwd2"> <br/>

        <button class="form-button bg-green-5">Register</button>
        
        <p style="text-align:left">Already have an account?</p>
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
            PhoneNumber: '',
            ZipCode: '',
            Town: '',
            Country: '',
            Pwd: '',
            Pwd2: '',
            error: '',
        }
    },
    methods:{
        handleSubmit(){
            this.error = ''

            if(this.Pwd != this.Pwd2){
                this.error = "Please enter matching passwords"
            }

            let newUser = {
                Name: this.Name,
                Email: this.Email,
                PhoneNumber: this.PhoneNumber,
                ZipCode: this.ZipCode,
                Town: this.Town,
                Country: this.Country,
                Address: this.Address,
                Password: this.Pwd,
            }
            
        }
    }
}
</script>