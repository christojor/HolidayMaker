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
                <td><input type="password" class="form-input" id="Password" v-model="Pwd"></td>
            </tr>
            </tbody>
        </table>
        <!-----Only for testing------------->
        <p>UserId: {{userId}}</p>
        <p>loginAttempt: {{isLoggedIn}}</p>
        <p>Login message: {{loginMessage}}</p>        
        <button type="submit" class="mt-6 w-1/2 bg-green-500 hover:bg-green-700 text-white font-bold py-2 px-4 rounded-full shadow-xl">Log in</button>
        
        <!---------------------------------->
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
            error: '',
        }
    },
    computed:{
     userId() {
         var localUserId = localStorage.getItem('userId');
         if(localUserId != null){
             return localUserId;
         }
      return this.$store.state.userId;
      },
      isLoggedIn(){
          var localLoginStatus = localStorage.getItem('loggedIn');
          if(localLoginStatus != null){
              return localLoginStatus;
          }
        return this.$store.state.isLoggedIn;
      },
      loginMessage(){
        return this.$store.state.loginAttemptMessage;
      }
    },
    methods:{
        async loginAttempt(){

        //Old code, keep if needed in future or changes
        //    this.$store.state.userEmail = this.Email;
        //    this.$store.state.userPassword = this.Pwd;
        //    this.$store.dispatch("getLoginAttempt");
           
           let userLogin = {
               Email: this.Email,
               Password: this.Pwd
           }

            let response = await fetch('https://localhost:44323/api/User/login',{
                method:'post',

                headers: {'Content-Type': 'application/json'},

                body: JSON.stringify(userLogin)
            }) 
            let json = await response.json();

            if(json.isLoggedIn === true)
            {
                this.$store.state.userId = json.userId;
                this.$store.state.isLoggedIn = json.isLoggedIn;
                localStorage.setItem('userId', this.userId);
                localStorage.setItem('loggedIn', this.isLoggedIn);
                console.log(json.isLoggedIn);
                this.$router.push('/');
            }

           if(this.isLoggedIn == false){
                this.error = this.loginMessage;
            }
        },
    },
}
</script>