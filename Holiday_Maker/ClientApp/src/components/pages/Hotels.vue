<template>
    <div class="container1">

        <div class="container2">
            <PropName @filter-search="filterSearch"/>
            <StarRating @filter-search="filterSearch"/>
        </div>

        <div class="container3">
            <API :filter="filter"/>
        </div>

    </div>
</template>

<script>
import API from "/src/components/API.vue"
import PropName from "/src/components/SearchProperty.vue"
import StarRating from "/src/components/SearchStarRating.vue"

export default{
    components: {
        API,
        PropName,
        StarRating,
    },
    methods: {
        filterSearch(filter){
            this.filter.PropName = filter.PropName
            this.filter.PropStars = filter.PropStars
            console.log(filter)
        }
    },
    data() {
        return{
            filter: {
                PropName: ''
            }
        }
    }
}
</script>