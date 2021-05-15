<template>
    <div class="filter-box" @mouseover="hover = false" @mouseleave="hover = true">

        <h3 style="margin:7px"> Price </h3>

        <span @change="slider" class="toggle">
            <h4 v-if="PropMinPrice <= 2999"  class="slider-text">  
                From: <input disabled v-model.number="PropMinPrice" type="number" class="price-box"/></h4> <br/>
            
            <h4 v-if="PropMinPrice == 3000" class="slider-text"> 
                Over: <input disabled v-model.number="PropMaxPrice" type="number" class="price-box"/></h4>
            
            <h4 v-else-if="PropMaxPrice == 3000" class="slider-text"> 
                To over: <input disabled v-model.number="PropMaxPrice" type="number" class="price-box"/></h4>
            
            <h4 v-else class="slider-text"> 
                To: <input disabled v-model.number="PropMaxPrice" type="number" class="price-box"/></h4>
        </span>

        <div :class="{show: hover}" class="range-slider">
            
            <input @change="slider" v-model.number="PropMinPrice" min="0" max="3000" step="50" type="range" class="dual-range"/>
            <input @change="slider" v-model.number="PropMaxPrice" min="0" max="3000" step="50" type="range" class="dual-range"/>
            
            <svg width="80%" height="24">
                <line x1="4" y1="0" x2="300" y2="0" stroke="#444" stroke-width="12" stroke-dasharray="1 28"></line>
            </svg>
        </div>
    </div>
</template>

<script>

export default{
    data() {
        return {
            PropMinPrice: 50,
            PropMaxPrice: 3000,
            hover: true,
        }
    },
    methods: {
        toggleStyle() {
            this.toggle = !this.toggle;
        },
        slider() {
            if (this.PropMinPrice > this.PropMaxPrice) {
                var tmp = this.PropMaxPrice;
                this.PropMaxPrice = this.PropMinPrice;
                this.PropMinPrice = tmp;
            }

            let filter = {
                PropMinPrice: this.PropMinPrice,
                PropMaxPrice: this.PropMaxPrice
            }

            this.$emit('filter-search', filter);
            
        }
    },
}
</script>
