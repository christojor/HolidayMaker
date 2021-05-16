<template>

            {{ accomodation.description }}
    
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