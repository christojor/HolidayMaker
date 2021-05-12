<template>
    <NavBar/>
    <router-view/>
</template>

<style src="./assets/style.css"></style>

<script>
import NavBar from '/src/components/NavBar.vue'

export default{
    components: {
        NavBar
    },
}
</script>
