<template>
    <h1>You are now logged out!</h1>
</template>


<script>
export default {
    created(){
        this.logout();
    },
    methods:{
        logout(){
            localStorage.clear();
            this.$store.state.isLoggedIn = false;
            this.$store.state.userId = 0;
            this.$store.state.userFavorites = null;
        }
    }
}
</script>