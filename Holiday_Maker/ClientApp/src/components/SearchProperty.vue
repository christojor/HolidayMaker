<template>
    <div class="filter-box">
        <p style="margin:0px">____________________________________</p>
        <h3 style="margin:7px"> Search Property Name </h3>
        <form @enter.prevent="handleSubmit">
            <input type="text" class="search-box" v-model="PropName">
        </form>
    </div>
</template>

<script>
export default{
    data() {
        return {
            PropName: ''
        }
    },
    methods: {
        handleSubmit(){
            let filter = {
                PropName: this.PropName
            }
            
            this.$emit('filter-search', filter);
        }
    },
}
</script>
