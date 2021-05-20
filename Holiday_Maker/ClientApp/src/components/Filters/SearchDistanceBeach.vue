<template>
    <div class="filter-box">
        <h3 style="margin:7px"> Distance to Beach </h3>
        
        <input type="range" min="0" max="5000" step="100" class="search-box" v-model="DistanceBeach" @click="handleSubmit">
        
        <h4 v-if="DistanceBeach == 5000" class="slider-stars">Any distance</h4>
        <h4 v-else-if="DistanceBeach > 0" class="slider-stars">0 - {{DistanceBeach}}m</h4>
        <h4 v-else class="slider-stars">Distance not counted</h4>
    </div>
</template>

<script>
export default{
    data() {
        return {
            DistanceBeach: 5000
        }
    },
    methods: {
        handleSubmit(){
            let filter = {
                DistanceBeach: this.DistanceBeach
            }
            
            this.$emit('filter-search', filter);
        }
    },
}
</script>
