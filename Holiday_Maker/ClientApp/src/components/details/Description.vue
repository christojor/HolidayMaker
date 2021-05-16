<template>

<h2><b>ABOUT</b></h2>
<p>{{ accomodation.description }}</p>
    
</template>

<script>

export default {
    props: {
            accomodation: {
                type: Object,
                required: true,
            },
        },
};
</script>