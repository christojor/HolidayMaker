<template>
    <nav>
        <aside>
            <router-link to="/"><img src="https://media.discordapp.net/attachments/770341448536686613/837608040978972678/Expoodia.png?width=100&height=70"></router-link>
        </aside>
        <router-link to="/seachbar" style="margin-right:20px">Search hotels</router-link>
        
        <router-link to="/hotels" style="margin-right:20px">View hotels</router-link>
        <Themes/>
    </nav>
</template>

<script>
import Themes from '/src/components/Themes.vue'

export default{
    components: {
        Themes
    },
}
</script>


