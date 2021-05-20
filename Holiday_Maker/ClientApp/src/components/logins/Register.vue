<template>
    <form @submit.prevent="handleSubmit" style="text-align:center;" :class="{show : toggle}">
        <h2 class="form-head text-green-6">Register</h2>
        
        <table style="table-layout:fixed; width:70%; margin-left:15%">
            <colgroup>
                <col style="width: 100px">
                <col style="width: 40%">
            </colgroup>
            <tbody>
            <tr>
                <td>Full name:</td>
                <td><input type="text" class="form-input" id="Name" v-model="Name"></td>
            </tr>
            <tr>
                <td>Email:</td>
                <td><input type="text" class="form-input" id="Email" v-model="Email"></td>
            </tr>
            <tr>
                <td>Phone number:</td>
                <td><input type="number" class="form-input" id="PhoneNumber" v-model="PhoneNumber"></td>
            </tr>
            <tr>
                <td>Address:</td>
                <td><input type="text" class="form-input" id="Address" v-model="Address"></td>
            </tr>
            <tr>
                <td>ZipCode:</td>
                <td><input type="text" class="form-input" id="ZipCode" v-model="ZipCode"></td>
            </tr>
            <tr>
                <td>Town:</td>
                <td><input type="text" class="form-input" id="Town" v-model="Town"></td>
            </tr>
            <tr>
                <td>Country:</td>
                <td><input type="text" class="form-input" id="Country" v-model="Country"></td>
            </tr>
            <tr>
                <td>Password:</td>
                <td><input type="password" class="form-input" id="Password" v-model="Pwd"></td>
            </tr>
            <tr>
                <td>Repeat password:</td>
                <td><input type="password" class="form-input" id="Password2" v-model="Pwd2"></td>
            </tr>
            </tbody>
        </table>
        <button class="mt-6 w-1/2 bg-green-500 hover:bg-green-700 text-white font-bold py-2 px-4 rounded-full shadow-xl">Register</button>
        
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