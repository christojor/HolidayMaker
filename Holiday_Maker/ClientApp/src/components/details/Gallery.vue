<template>
    <img :src="accomodation.imgSrc"
          class="img-fluid rounded-md"
          style="width: 300px; height: auto"/>
</template>

<script>
export default {
    props: {
            accomodation: {
                type: Object,
                required: true,
            },
        },
}
</script>