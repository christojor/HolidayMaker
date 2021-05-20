<template>
    <form @submit.prevent="loginAttempt" style="text-align:center; " :class="{show : toggle}">
        <h2 class="form-head text-green-6">Log in</h2>

        <input v-if="error != ''" class="error-box" v-model="error"> <br/>

        <table style="table-layout:fixed; width:70%; margin-left:15%">
            <colgroup>
                <col style="width: 100px">
                <col style="width: 40%">
            </colgroup>
            <tbody>
            <tr>
                <td>Email:</td>
                <td><input type="text" class="form-input" id="Email" v-model="Email"></td>
            </tr>
            <tr>
                <td>Password:</td>
                <td><input type="text" class="form-input" id="Password" v-model="password"></td>
            </tr>
            </tbody>
        </table>
        <p>UserId: {{userId}}</p>
        <p>loginAttempt: {{isLoggedIn}}</p>
        <p>Login message: {{loginMessage}}</p>        
        <button class="mt-6 w-1/2 bg-green-500 hover:bg-green-700 text-white font-bold py-2 px-4 rounded-full shadow-xl">Log in</button>
        
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
            username: '',
            password: '',
        }
    },
    computed:{
     userId() {
      return this.$store.state.userId;
      },
      isLoggedIn(){
        return this.$store.state.isLoggedIn;
      },
      loginMessage(){
        return this.$store.state.loginAttemptMessage;
      }

    },
    methods:{
        handleSubmit(){
            this.error = ''
            
            if(this.Pwd != 'Real Password'){
                this.error = "Email or password incorrect"
            }            
        },
        loginAttempt(){
        this.$store.state.userEmail = this.Email;
        this.$store.state.userPassword = this.password;
        this.$store.dispatch("getLoginAttempt");
        }
    },
}
</script>