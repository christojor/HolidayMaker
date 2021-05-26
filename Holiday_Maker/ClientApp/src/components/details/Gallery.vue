<template>
<img :src="accomodation.imgSrc"
          class="img-fluid rounded-md"
          style="width: 500px; height: 500px"/>
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