<template>
    <div class="filter-box">
        <h3 style="margin:7px"> Search Property Name </h3>
        <form @submit.prevent="handleSubmit">
            <input hidden>
            <input type="text" class="search-box" v-model="PropName">
            <button hidden>Submit</button>
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
            console.log("shit")
            this.$emit('filter-search', filter);
        }
    },
}
</script>
