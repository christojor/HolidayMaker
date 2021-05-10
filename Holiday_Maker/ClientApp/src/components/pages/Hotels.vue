<template>
    <div class="container1">

        <div class="container2">
            <SearchProp @filter-search="filterSearch"/>
        </div>

        <div class="container3">
            <API/>
        </div>

    </div>
</template>

<script>
import API from "/src/components/API.vue"
import SearchProp from "/src/components/SearchProperty.vue"

export default{
    components: {
        API,
        SearchProp,
    },
    methods: {
        filterSearch(filter){
            
        }
    },
}
</script>