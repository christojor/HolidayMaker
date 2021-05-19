<template>
  
    <h3>UserID: {{ userId }}</h3>
    <h3>IsLoggedIn: {{isLoggedIn}}</h3>
    <h3>LoginMessage: {{loginMessage}}</h3>
    <input v-model="username" type="text" placeholder="Username..." />
    <p>username is: {{username}}</p>
    <input v-model="password" type="password" placeholder="Password..." />
    <p>password is: {{password}}</p>
    <button @click="loginAttempt">Login</button>

</template>

<script>
import { useSessionStorage, useLocalStorage } from "@vueuse/core";

export default {

  data(){
    return {
      username: '',
      password: '',
    }
  },
  computed: {
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
        loginAttempt(){
        this.$store.state.userName = this.username;
        this.$store.state.userPassword = this.password;
        this.$store.dispatch("getLoginAttempt");
    }
  }
};
</script>
