<template>
    <nav>
        <a href="/hotels">Hotels</a>
    </nav>
    <router-view/>
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

<script>
import NavBar from '/src/components/NavBar.vue'

export default{
    components: {
        NavBar
    },
}
</script>
