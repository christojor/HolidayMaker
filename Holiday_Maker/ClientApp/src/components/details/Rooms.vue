<template>
<div v-if="roomAvailable">
<b>AVAILABLE ROOMS</b>
<div v-for="room in rooms" :key="room.id">
<div class="flex flex-wrap overflow-hidden border-black border-2 p-1 m-1">

  <div class="w-1/2 overflow-hidden p-2">
    <img class="rounded-md roomImg" :src="room.imgSrc">
   </div>

      <div class="w-1/2 overflow-hidden p-4">
        <button
          class="float-right bg-green-500 hover:bg-green-700 text-white font-bold py-2 px-4 rounded-full"
          @click="addToBooking(room)"
        >
          Add Room
        </button>
        <div>
          <b>Room Type:</b> {{ room.roomType.name }}<br />
          <b>Number of Guests: </b> {{ room.nbrOfGuests }}<br />
          <b>Number of Extra Beds:</b> {{ room.nbrOfExtraBeds }}<br />
          <b>Price:</b> {{ room.price }}€ <br />
          <div v-if="room.isRefundable == true"><b>Refund:</b> Yes<br /></div>
          <div v-if="room.isRefundable == false"><b>Refund:</b> No<br /></div>
          <b>Description:</b> {{ room.description }}<br />
          <b>Extras at extra price: </b>
          <div class="rounded-t-md bg-green-1 search-div shadow-xl w-2/8">
            <div class="text-green-500">
               <div style="text-align:left;margin-left:10px" v-for="Extra in Extras" :key="Extra.id">
                 <input type="checkbox" style="margin-right:10px" :v-model="Extra.Checked" @change="setExtra(Extra)">
                 <label :for="Extra.Name">{{Extra.Name}} {{"+"}} {{Extra.Price}} {{Extra.Currency}}</label>
               </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

</template>


<script>

export default {
  mounted(){
    this.sortExtras();
    var Extra = {Extra: Checked}
    this.setExtra(Extra)
    console.log(this.$store.state.extras)
  },

   computed: {
      extras: {
        get() {
          return this.$store.state.extras
        },
        set (savedExtras){
          this.$store.commit('setExtras', savedExtras)
        }
    }
  },
  


  data() {
    return {
      image: "./assets/images/fullyBooked.png",

      Extras: [
        { Name: "Self-Catering", Checked: false, Price: 5, Currency:"€"},
        { Name: "Half-Board",  Checked: false, Price: 10, Currency:"€"},
        { Name: "Full-board",  Checked: false, Price: 15, Currency:"€"},
        { Name: "Extra bed",  Checked: false, Price: 5, Currency:"€"},
        { Name: "Crib", Checked: false, Price: 5, Currency:"€"},
        { Name: "Self-Catering", Checked: false, Price: 20, Currency:"€"},
        { Name: "Breakfast", Checked: false, Price: 5, Currency:"€"}
      ],
    
        savedExtras: []
    }

    },

   props: {
    rooms: {
      type: Object,
      required: true,
    },
    extrasList: {
      type: Object,
      required: true,
    },
    savedExtras: {
      type: Object,
      required: true,
    }

  },

  computed:{
    roomAvailable(){
     if (this.rooms.length){
       return true;
      }
       else {
         return false;
       }
     }
    },
  
  methods: {
    addToBooking(room) {
      this.$store.state.bookedRooms.push(room);
    },
 
    sortExtras(){
      this.Extras = [];

      if(this.extrasList[0].selfCatering){
        this.Extras.push({ Name: "Self-Catering", Checked: false, Price: 5, Currency: "€"})
      }
      if(this.extrasList[0].halfBoard){
        this.Extras.push({ Name: "Half-Board", Checked: false, Price: 10, Currency: "€"})
      }
      if(this.extrasList[0].fullBoard){
        this.Extras.push({ Name: "Full-board", Checked: false, Price: 15, Currency: "€"})
      }
      if(this.extrasList[0].extraBed){
        this.Extras.push({ Name: "Extra bed", Checked: false, Price: 5, Currency: "€"})
      }
      if(this.extrasList[0].crib){
        this.Extras.push({ Name: "Crib", Checked: false, Price: 5, Currency: "€"})
      }
      if(this.extrasList[0].allInclusive){
        this.Extras.push({ Name: "Self-Catering", Checked: false, Price: 20, Currency: "€"})
      }
      if(this.extrasList[0].breakfast){
        this.Extras.push({ Name: "Breakfast", Checked: false, Price: 5, Currency: "€"})
      }

    },

    setExtra(savedExtras){
        this.savedExtras = [];
        this.$store.commit('setExtras', savedExtras)
        if(Extra.Checked)
        {
          this.savedExtras.push({Extra: Name, Extra: Price})
        }
        console.log(this.$store.state.extras)
     },
    
    // saveSelectedExtras(Extra){
    // const inpt = document.querySelector('input');
    // inpt.onclick = function() {
      
      
    //          if(this.savedSelectedExtras.includes(Extra.Name))
    //          {
    //            this.savedSelectedExtras.filter(extra => {if(extra==Extra.Name){this.savedSelectedExtras.splice(extra,1)}})
    //          }
    //          else
    //          {
    //            this.savedSelectedExtras.push(Extra.Name)
    //          }     
    //          console.log(this.savedSelectedExtras)  
    //         }          
    // }
  }
};
</script>