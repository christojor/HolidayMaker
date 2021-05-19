<template>
    <div class="filter-box">
        <h3 style="margin:7px"> Distance to City Center </h3>
        
        <input id="cityslider" class="search-box" type="range" min="0" max="5000" step="100" v-model="distanceToCity" @click="handleSubmit">
        <h3 class="slider-stars">
            <output for="cityslider" :value="2500 + ' m'">{{distanceToCity}} m</output>
        </h3>
    </div>
</template>

<script>
export default{
    data() {
        return {
            distanceToCity: 2500
        }
    },
    methods: {
        handleSubmit(){
            let filter = {
                distanceToCity: this.distanceToCity
            }
            
            this.$emit('filter-search', filter);
        }
    },
}
</script>
