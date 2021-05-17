<template>
    <div class="filter-box">
        <h3 style="margin:7px"> Property Rating </h3>

        <p class="slider-text">1</p> 
        <input type="range" min="1" max="5" class="search-box" v-model="PropStars" @click="handleSubmit">
        <p class="slider-text">5</p>
        
        <h4 v-if="PropStars > 1" class="slider-stars">1 - {{PropStars}} stars</h4>
        <h4 v-else class="slider-stars">{{PropStars}} star</h4>
    </div>
</template>

<script>
export default{
    data() {
        return {
            PropStars: 5
        }
    },
    methods: {
        handleSubmit(){
            let filter = {
                PropStars: this.PropStars,
            }
            
            this.$emit('filter-search', filter);
        }
    },
}
</script>
