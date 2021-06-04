<template>
  <FavModal :accomodationObject="accomodationObject" :toggleModal="ToggleModal" @emitToggle="ToggleModalMethod"/>

  <font-awesome-icon :icon="['fas', IconType]" size="lg" @click="ToggleModalMethod(false); DeleteFavorite();" :class="{show:!ToggleIcon}" style="cursor:pointer;"/>
  <font-awesome-icon :icon="['far', IconType]" size="lg" @click="ToggleModalMethod(true);" :class="{show:ToggleIcon}" style="cursor:pointer;"/>
</template>

<script>
import FavModal from "/src/components/favoriteModal.vue";

export default {
  components:{
    FavModal
  },
  mounted(){
    this.GetUserFavorites();
  },
  data() {
    return {
      ToggleIcon: false,
      ToggleModal: false,
      IconType: 'heart',
    }
  },
  props:{
    accomodationObject:{
      type: Object,
    },
  },
  computed:{
    UserFavorites(){
      return this.$store.state.userFavorites;
    }
  },
  methods: {
    ToggleModalMethod(toggleModal, toggleIcon) {
      this.ToggleModal = toggleModal
      this.ToggleIcon = toggleIcon
    },
    GetUserFavorites(){
      if(this.UserFavorites != null){
        for(var i = 0; i < this.UserFavorites.length; i++){
          if(this.accomodationObject.id == this.UserFavorites[i].id){
            this.ToggleIcon = !this.ToggleIcon;
          }
        }
      }
    },
    async DeleteFavorite(){
      let data = { userId: this.$store.state.userId, accomodationId: this.accomodationObject.id};
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