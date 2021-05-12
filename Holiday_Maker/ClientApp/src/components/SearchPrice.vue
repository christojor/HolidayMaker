<template>
    <div class="filter-box">

        <button :class="{focus: toggle}" class="price-button" @click="toggleStyle" >
            <h3 style="margin:7px"> Price </h3>

            <span @change="slider">
                <h4 v-if="PropMinPrice <= 9999"  class="slider-text">  
                    From: <input disabled v-model.number="PropMinPrice" type="number"  min="0" max="10000" class="price-box"/></h4> <br/>
                
                <h4 v-if="PropMinPrice == 10000" class="slider-text"> 
                    Over: <input disabled v-model.number="PropMaxPrice" type="number"  min="0" max="10000" class="price-box"/></h4>
                
                <h4 v-else-if="PropMaxPrice == 10000" class="slider-text"> 
                    To over: <input disabled v-model.number="PropMaxPrice" type="number"  min="0" max="10000" class="price-box"/></h4>
                
                <h4 v-else class="slider-text"> 
                    To: <input disabled v-model.number="PropMaxPrice" type="number"  min="0" max="10000" class="price-box"/></h4>
            </span>
        </button>

        <div class="range-slider"  :class="{show: !toggle}">
            
            <input @change="slider" v-model.number="PropMinPrice" min="0" max="10000" step="500" type="range" class="dual-range"/>
            <input @change="slider" v-model.number="PropMaxPrice" min="0" max="10000" step="500" type="range" class="dual-range"/>
            
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
            toggle: false,
            PropMinPrice: "500",
            PropMaxPrice: "10000",
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
