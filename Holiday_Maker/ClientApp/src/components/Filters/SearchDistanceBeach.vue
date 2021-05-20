<template>
    <div class="filter-box">
        <h3 style="margin:7px"> Distance to Beach </h3>
        
        <input id="beachslider" class="search-box" type="range" min="0" max="5000" step="100" v-model="distanceToBeach" @click="handleSubmit">
        <h3 class="slider-stars">
            <output for="beachslider" :value="2500 + ' m'">{{distanceToBeach}} m</output>
        </h3>
    </div>
</template>

<script>
export default{
    data() {
        return {
            distanceToBeach: 2500
        }
    },
    methods: {
        handleSubmit(){
            let filter = {
                distanceToBeach: this.distanceToBeach
            }
            
            this.$emit('filter-search', filter);
        }
    },
}
</script>
