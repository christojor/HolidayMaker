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
                <td>First name:</td>
                <td><input required type="text" class="form-input" id="Name" v-model="FirstName"></td>
            </tr>
            <tr>
                <td>Last name:</td>
                <td><input required type="text" class="form-input" id="Name" v-model="LastName"></td>
            </tr>
            <tr>
                <td>Email:</td>
                <td><input required type="text" class="form-input" id="Email" v-model="Email"></td>
            </tr>
            <tr>
                <td>Address:</td>
                <td><input required type="text" class="form-input" id="Address" v-model="StreetAddress"></td>
            </tr>
            <tr>
                <td>ZipCode:</td>
                <td><input required type="text" class="form-input" id="ZipCode" v-model="ZipCode"></td>
            </tr>
            <tr>
                <td>City:</td>
                <td><input required type="text" class="form-input" id="Town" v-model="City"></td>
            </tr>
            <tr>
                <td>Country:</td>
                <td><input required type="text" class="form-input" id="Country" v-model="Country"></td>
            </tr>
            <tr>
                <td>Password:</td>
                <td><input required type="password" class="form-input" id="Password" v-model="Pwd"></td>
            </tr>
            <tr>
                <td>Repeat password:</td>
                <td><input required type="password" class="form-input" id="Password2" v-model="Pwd2"></td>
            </tr>
            </tbody>
        </table>
        <div id="SuccessMessage" class="alert" style="display:none">
             <span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
             <strong>Your account have been registered!</strong>
        </div>
        <div id="ErrorMessage" class="alert" style="display:none">
             <span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
             <strong>A user with that email already exists!</strong>
        </div>
        <button class="outline mt-6 w-1/2 bg-green-500 hover:bg-green-700 text-white font-bold py-2 px-4 rounded-full shadow-xl">Register</button>
        
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
            FirstName: '',
            LastName: '',
            Email: '',
            StreetAddress: '',
            PhoneNumber: '',
            ZipCode: '',
            City: '',
            Country: '',
            Pwd: '',
            Pwd2: '',
            error: '',
        }
    },
    methods:{
        showSuccess(){
            var lol = document.getElementById("SuccessMessage");
            lol.style.display = "block";
        },
        showError(){
            var lol = document.getElementById("ErrorMessage");
            lol.style.display = "block";

        },


        async handleSubmit(){
            this.error = ''

            if(this.Pwd != this.Pwd2){
                this.error = "Please enter matching passwords"
            }

            let newUser = {
                FirstName: this.FirstName,
                LastName: this.LastName,
                Email: this.Email,
                ZipCode: this.ZipCode,
                City: this.City,
                Country: this.Country,
                StreetAddress: this.StreetAddress,
                Password: this.Pwd,
                MemberTypeId: 1,
            }
            
            let rawResponse = await fetch('https://localhost:44323/api/User/register', {
            // tell the server we want to send/create data
            method: 'post',
            // and that we will send data json formatted
            headers: { 'Content-Type': 'application/json' },
            // the data encoded as json
            body: JSON.stringify(newUser)
            });
            let response = await rawResponse.json();

            if(response){
                this.showSuccess();
            }else if(!response){
                this.showError();
            }
        }
    }
}
</script>