<template>
    <div class="filter-box">
        <h3 style="margin:7px"> Distance to City Center </h3>
        
        <input type="range" min="0" max="5000" step="100" class="search-box" v-model="DistanceCity" @click="handleSubmit">
        
        <h4 v-if="DistanceCity == 5000" class="slider-stars">Any distance</h4>
        <h4 v-else-if="DistanceCity > 0" class="slider-stars">0 - {{DistanceCity}}m</h4>
        <h4 v-else class="slider-stars">Distance not counted</h4>
    </div>
</template>

<script>
export default{
    data() {
        return {
            DistanceCity: 5000
        }
    },
    methods: {
        handleSubmit(){
            let filter = {
                DistanceCity: this.DistanceCity
            }
            
            this.$emit('filter-search', filter);
        }
    },
}
</script>
