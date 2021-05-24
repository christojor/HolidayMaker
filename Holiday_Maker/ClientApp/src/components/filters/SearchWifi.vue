<template>
    <div class="filter-box">
        <h3 style="margin:7px"> Wifi quality </h3>

        <p class="slider-text">0</p> 
        <input type="range" min="0" max="5" class="search-box" v-model="PropWifi" @click="handleSubmit">
        <p class="slider-text">5</p>
        
        <h4 v-if="PropWifi == 5" class="slider-stars"><font-awesome-icon :icon="['fas', 'poo']" size="10x" style="color: #52B788;"/></h4>

        <h4 v-if="PropWifi == 4" class="slider-stars"><font-awesome-icon :icon="['fas', 'poo']" size="3x" style="color: #52B788;"/>
        - <font-awesome-icon :icon="['fas', 'poo']" size="4x" style="color: #52B788;"/></h4>

        <h4 v-if="PropWifi == 3" class="slider-stars"><font-awesome-icon :icon="['fas', 'poo']" size="2x" style="color: #52B788;"/>
        - <font-awesome-icon :icon="['fas', 'poo']" size="4x" style="color: #52B788;"/></h4>
        
        <h4 v-if="PropWifi == 2" class="slider-stars"><font-awesome-icon :icon="['fas', 'poo']" size="lg" style="color: #52B788;"/>
        - <font-awesome-icon :icon="['fas', 'poo']" size="4x" style="color: #52B788;"/></h4>

        <h4 v-if="PropWifi == 1" class="slider-stars"><font-awesome-icon :icon="['fas', 'poo']" size="sm" style="color: #52B788;"/>
        - <font-awesome-icon :icon="['fas', 'poo']" size="4x" style="color: #52B788;"/></h4>

        <h4 v-if="PropWifi == 0" class="slider-stars"><font-awesome-icon :icon="['fas', 'poo']" size="xs" style="color: #52B788;"/>
        - <font-awesome-icon :icon="['fas', 'poo']" size="4x" style="color: #52B788;"/></h4>

    </div>
</template>

<script>
export default{
    data() {
        return {
            PropWifi: 0
        }
    },
    methods: {
        handleSubmit(){
            let filter = {
                PropWifi: this.PropWifi,
            }
            
            this.$emit('filter-search', filter);
        }
    },
}
</script>
