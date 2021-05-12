<template>
    <div class="filter-box">
        <h3 style="margin:7px"> User Rating </h3>

        <p class="slider-text">0</p> 
        <input type="range" min="0" max="10" class="search-box" v-model="PropRating" @click="handleSubmit">
        <p class="slider-text">10</p>
        
        <h3 class="slider-stars">{{PropRating}}+</h3>
    </div>
</template>

<script>
export default{
    data() {
        return {
            PropRating: 0
        }
    },
    methods: {
        handleSubmit(){
            let filter = {
                PropRating: this.PropRating
            }
            
            this.$emit('filter-search', filter);
        }
    },
}
</script>
