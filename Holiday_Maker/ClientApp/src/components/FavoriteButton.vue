<template>
  <font-awesome-icon :icon="['fas', IconType]" size="lg" @click="ChangeIcon(); DeleteFavorite();" :class="{show:Toggle}"/>
  <font-awesome-icon :icon="['far', IconType]" size="lg" @click="ChangeIcon(); SetFavorite();" :class="{show:!Toggle}"/>
</template>


<script>

export default {

  created(){
  },

  data() {
    return {
      Toggle: true,
      IconType: 'heart'
    }
  },
  props:{
    accomodationObject:{
      type: Object,
    }
  },
  methods: {
    ChangeIcon() {
      this.Toggle = !this.Toggle
    },
    async SetFavorite(){
      let data = { userId: 1, accomodationId: this.accomodationObject.id, groupName: 'lulxd' };
      let rawResponse = await fetch('https://localhost:44323/api/User/favorites', {
       // tell the server we want to send/create data
      method: 'post',
       // and that we will send data json formatted
      headers: { 'Content-Type': 'application/json' },
       // the data encoded as json
       body: JSON.stringify(data)
});
    },
    async DeleteFavorite(){
      let data = { userId: 1, accomodationId: this.accomodationObject.id};
      // let rawResponse = await fetch('https://localhost:44323/api/User/favorites?userId='+1+'&accomodationId='+this.accomodationObject.id, {
      let rawResponse = await fetch('https://localhost:44323/api/User/favorites', {
      // tell the server we want to send/create data
      method: 'delete',

      headers: { 'Content-Type': 'application/json' },
       // the data encoded as json
      body: JSON.stringify(data)
});
    }

  },
};
</script>