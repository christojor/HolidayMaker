<template>
    <NavBar/>
    <body>
        <router-view/>
    </body>
</template>

<script>
import NavBar from '/src/components/NavBar.vue'

export default{
    components: {
        NavBar,
    },
}
</script>


<style src="./assets/style.css"></style>
