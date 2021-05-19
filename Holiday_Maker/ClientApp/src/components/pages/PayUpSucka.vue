<template>
  <div></div>
</template>

<script>
    card = undefined;

export default {
  mounted: function () {
    card = elements.create('card');
    card.mount(this.$refs.card);
  }
};
</script>